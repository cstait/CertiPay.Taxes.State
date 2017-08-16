using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CertiPay.Taxes.State.California
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.CA; } }
        protected abstract Decimal Deduction { get; }
        protected abstract Decimal Exemption { get; }
        protected abstract IEnumerable<StandardDeduction> StandardDeductions { get; }        
        protected abstract IEnumerable<IncomeBracket> IncomeBrackets { get;}               
        protected abstract IEnumerable<TaxableWithholding> TaxableWithholdings { get; }

        /// <summary>
        /// Returns California state withholding when given a non-negative value for Gross Wages, Personal Allowances and Deductions.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="filingStatus"></param>
        /// <param name="personalAllowances"></param>
        /// <param name="deductions"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, FilingStatus filingStatus, int personalAllowances, int deductions)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");            
            if (personalAllowances < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(personalAllowances)} cannot be a negative number");
            if (deductions < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(deductions)} cannot be a negative number");

            var taxableWages = frequency.CalculateAnnualized(grossWages);
            var withholdingFilingStatus = CheckFilingStatus(filingStatus, personalAllowances);

            if (!CheckIncome(withholdingFilingStatus, taxableWages, personalAllowances))
            {
                return 0;
            }

            taxableWages -= GetDeduction(deductions);
            taxableWages -= GetStandardDeduction(withholdingFilingStatus);

            if (taxableWages <= 0)
                return 0;

            var taxRate = GetTaxWithholding(filingStatus, taxableWages);
            taxableWages = taxRate.TaxBase + ((taxableWages - taxRate.StartingAmount) * taxRate.TaxRate);
            var taxWithheld = taxableWages - GetPersonalAllowance(personalAllowances);

            return frequency.CalculateDeannualized(Math.Max(0, taxWithheld));
        }

        protected virtual Decimal GetDeduction(int deductions)
        {
            return deductions * Deduction;
        }

        protected virtual Decimal GetPersonalAllowance(int personalAllowances)
        {
            return personalAllowances * Exemption;
        }

        protected virtual Decimal GetStandardDeduction(FilingStatus filingStatus)
        {
            return
                StandardDeductions
                .Where(d => d.FilingStatus == filingStatus)
                .Select(d => d.Amount)
                .Single();
        }

        protected virtual Boolean CheckIncome(FilingStatus filingStatus, decimal taxableWages, int allowances)
        {
            var bracket = IncomeBrackets
                .Where(x => x.FilingStatus == filingStatus)
                .Select(x => x.Amount)
                .Single();

            return bracket <= taxableWages;

        }

        protected virtual FilingStatus CheckFilingStatus(FilingStatus filingStatus, int allowances)
        {
            if (filingStatus == FilingStatus.Married && allowances >= 2)
                return FilingStatus.HeadOfHousehold;
            else if (filingStatus == FilingStatus.Married && allowances < 2)
                return FilingStatus.Single;

            else return filingStatus;
        }
            
       protected virtual TaxableWithholding GetTaxWithholding(FilingStatus filingStatus, Decimal taxableWages)
        {
            if (taxableWages < Decimal.Zero) return new TaxableWithholding { };

            return
                TaxableWithholdings
                .Where(d => d.FilingStatus == filingStatus)
                .Where(d => d.StartingAmount <= taxableWages)
                .Where(d => taxableWages < d.MaximumWage)
                .Select(d => d)
                .Single();
        }

        protected class StandardDeduction
        {
            public FilingStatus FilingStatus { get; set; }

            public Decimal Amount { get; set; }
        }
     
        protected class IncomeBracket
        {
           public FilingStatus FilingStatus { get; set; }
            public Decimal Amount { get; set; }
        }
                  
        protected class TaxableWithholding
        {
            public FilingStatus FilingStatus { get; set; } = FilingStatus.Single;

            public Decimal TaxBase { get; set; }

            public Decimal StartingAmount { get; set; }

            public Decimal MaximumWage { get; set; }

            public Decimal TaxRate { get; set; }
        }
    }

        public enum FilingStatus : byte
        {        
            Single = 0,        
            Married = 1,
            [Display(Name = "Head of Household")]
            HeadOfHousehold= 2,       
        }
    }