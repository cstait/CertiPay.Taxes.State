using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CertiPay.Taxes.State.Delaware
{
    public class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get; internal set; } = StateOrProvince.DE;

        public override decimal SUI_Wage_Base
        {
            get
            {
                switch (Year)
                {
                    case 2016:
                    case 2017:
                        return 18500;
                }

                throw new NotImplementedException($"SUI Wage Base is not configured for Delaware for {Year}");
            }
        }

        /// <summary>
        /// Returns Delaware State Withholding when given a non-negative value for Gross Wages and Personal Allowances.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="filingStatus"></param>
        /// <param name="personalAllowances"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, FilingStatus filingStatus = FilingStatus.Single, int personalAllowances = 1)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");            
            if (personalAllowances < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(personalAllowances)} cannot be a negative number");
            
            var taxableWages = frequency.CalculateAnnualized(grossWages);                        

            taxableWages -= GetStandardDeduction(filingStatus);

            if (taxableWages <= 0)
                return 0;

            var selected_row = GetTaxWithholding(taxableWages);            

            var taxWithheld = selected_row.TaxBase + ((taxableWages - selected_row.StartingAmount) * selected_row.TaxRate);

            taxWithheld -= GetPersonalAllowance(personalAllowances);
            
            return frequency.CalculateDeannualized(taxWithheld);
        }

        internal virtual Decimal GetStandardDeduction(FilingStatus filingStatus)
        {
            return
                StandardDeductions
                .Where(d => d.FilingStatus == filingStatus)
                .Select(d => d.Amount)
                .Single();
        }

        internal virtual Decimal GetPersonalAllowance(int personalAllowances = 1)
        {                               
            return PersonalAllowanceValue * personalAllowances;
        }
      

        internal virtual TaxableWithholding GetTaxWithholding(Decimal taxableWages)
        {            
            return
                TaxableWithholdings                
                .Where(d => d.StartingAmount <= taxableWages)
                .Where(d => taxableWages < d.MaximumWage)
                .Select(d => d)
                .Single();
        }

        internal class StandardDeduction
        {
            public FilingStatus FilingStatus { get; set; }
            public Decimal Amount { get; set; }
        }       

        internal class TaxableWithholding
        {            
            public Decimal TaxBase { get; set; }

            public Decimal StartingAmount { get; set; }

            public Decimal MaximumWage { get; set; }

            public Decimal TaxRate { get; set; }
        }


        private IEnumerable<TaxTable.StandardDeduction> StandardDeductions
        {
            get
            {
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.MarriedFilingSeperate, Amount = 3250.00m };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Single, Amount = 3250.00m };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.MarriedFilingJointly, Amount = 6500.00m };
            }
        }

        public decimal PersonalAllowanceValue { get; } = 110.00m;

        private IEnumerable<TaxableWithholding> TaxableWithholdings
        {
            get
            {
                yield return new TaxTable.TaxableWithholding { TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 2000.00m, TaxRate = .00m };
                yield return new TaxTable.TaxableWithholding { TaxBase = 0.00m, StartingAmount = 2000.00m, MaximumWage = 5000.00m, TaxRate = .0220m };
                yield return new TaxTable.TaxableWithholding { TaxBase = 66.00m, StartingAmount = 5000.00m, MaximumWage = 10000.00m, TaxRate = .0390m };
                yield return new TaxTable.TaxableWithholding { TaxBase = 261.00m, StartingAmount = 10000.00m, MaximumWage = 20000.00m, TaxRate = .0480m };
                yield return new TaxTable.TaxableWithholding { TaxBase = 741.00m, StartingAmount = 20000.00m, MaximumWage = 25000.00m, TaxRate = .0520m };
                yield return new TaxTable.TaxableWithholding { TaxBase = 1001.00m, StartingAmount = 25000.00m, MaximumWage = 60000.00m, TaxRate = .0555m };
                yield return new TaxTable.TaxableWithholding { TaxBase = 2943.50m, StartingAmount = 60000.00m, MaximumWage = Decimal.MaxValue, TaxRate = .0660m };
            }
        }
    }

    public enum FilingStatus : byte
    {
        // A) Single
        // B) Married - 2 incomes
        // C) Married - 1 income        

        [Display(Name = "A - Single")]
        Single = 0,

        [Display(Name = "B - Married Filing Jointly")]
        MarriedFilingJointly = 1,

        [Display(Name = "C - Married Filing Seperately")]
        MarriedFilingSeperate = 2,        
    }
   
}