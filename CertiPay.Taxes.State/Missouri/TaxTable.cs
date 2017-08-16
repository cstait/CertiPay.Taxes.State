using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CertiPay.Taxes.State.Missouri
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.MO; } }
        protected abstract IEnumerable<StandardDeduction> StandardDeductions { get; }
        protected abstract IEnumerable<Allowance> PersonalAllowances { get; }
        protected abstract IEnumerable<StandardDeduction> FederalWithholdings { get; }
        protected abstract Decimal TaxRate { get; }
        protected abstract Decimal TaxAmount { get; }
        protected abstract Decimal TaxIncrement { get; }

        /// <summary>
        /// Returns Missouri Withholding when given a non-negative value for Gross Wages, Federal Withholding and Personal Allowances.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="filingStatus"></param>
        /// <param name="federalWithholding"></param>
        /// <param name="personalAllowances"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, FilingStatus filingStatus, Decimal federalWithholding, int personalAllowances)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");
            if (personalAllowances < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(personalAllowances)} cannot be a negative number");
            if (federalWithholding < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(federalWithholding)} cannot be a negative number");

            var taxableWages = frequency.CalculateAnnualized(grossWages);
            var fedWithholding = frequency.CalculateAnnualized(federalWithholding);

            taxableWages -= GetStandardDeduction(filingStatus);

            taxableWages -= GetPersonalAllowance(filingStatus, personalAllowances);

            taxableWages -= GetFederalWithholding(filingStatus, federalWithholding);

            var taxWithheld = GetTaxWithholding(filingStatus, taxableWages);

            return frequency.CalculateDeannualized(Math.Max(0, taxWithheld)).Round(decimals : 0);
        }

        protected virtual Decimal GetStandardDeduction(FilingStatus filingStatus)
        {
            return
                StandardDeductions
                .Where(d => d.FilingStatus == filingStatus)
                .Select(d => d.Amount)
                .Single();
        }

        protected virtual Decimal GetPersonalAllowance(FilingStatus filingStatus, int personalAllowances)
        {
            var allowance_value =
                PersonalAllowances
                .Where(d => d.FilingStatus == filingStatus)                
                .Single();

            if (filingStatus == FilingStatus.MarriedWithOneIncome)
            {
                if (personalAllowances == 1)
                {
                    return allowance_value.Amount;
                }
                else if (personalAllowances == 2)
                {
                    return allowance_value.Amount * 2;
                }
                else if (personalAllowances >= 3)
                {
                    return (allowance_value.Amount * 2) + (allowance_value.AdditionalAmount * (personalAllowances - 2));
                }
                else
                    return 0;
            }
            else
            {
                if (personalAllowances == 1)
                {
                    return allowance_value.Amount;
                }
                else if (personalAllowances >= 2)
                {
                    return allowance_value.Amount + (allowance_value.AdditionalAmount * (personalAllowances - 1));
                }
                else
                    return 0;
            }
        }


        protected virtual Decimal GetFederalWithholding(FilingStatus filingStatus, Decimal federalWithholding)
        {
            return Math.Min(FederalWithholdings
                .Where(x => x.FilingStatus == filingStatus)
                .Select(x => x.Amount)
                .Single(), federalWithholding);
        }

        protected virtual decimal GetTaxWithholding(FilingStatus filingStatus, Decimal taxableWages)
        {
            Decimal taxWithheld = 0;
            Decimal taxRate = TaxRate;
            for (int i = 0; i < 9; i++)
            {
                if (taxableWages > taxWithheld)
                {
                    taxWithheld += (TaxAmount * taxRate).Round(decimals : 0);
                    taxableWages -= TaxAmount;                    
                    taxRate += TaxIncrement;
                }
                else
                {
                    break;
                }
            }
            taxWithheld += taxableWages * taxRate;

            return taxWithheld;
        }

        protected class StandardDeduction
        {
            public FilingStatus FilingStatus { get; set; }
            public Decimal Amount { get; set; }
        }

        protected class Allowance : StandardDeduction
        {
            public Decimal AdditionalAmount { get; set; }
        }


        public enum FilingStatus : byte
        {

            [Display(Name = "Single")]
            Single = 0,

            [Display(Name = "Married With One Income")]
            MarriedWithOneIncome = 1,

            [Display(Name = "Married With Two Incomes")]
            MarriedWithTwoIncomes = 2,

            [Display(Name = "Head of Household")]
            HeadOfHousehold = 3
        }
    }
}