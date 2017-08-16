using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CertiPay.Taxes.State.Alabama
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.AL; } }

        public abstract IEnumerable<StandardDeduction> StandardDeductions { get; }

        public abstract IEnumerable<StandardDeduction> PersonalAllowances { get; }

        public abstract IEnumerable<DependentAllowance> DependentAllowances { get; }

        public abstract IEnumerable<TaxableWithholding> TaxableWithholdings { get; }


        /// <summary>
        /// Returns State Withholding for Alabama, when provided with a non-negative value for Gross Wages, Federal Withholding and Dependent Allowances. 
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="federalWithholding"></param>
        /// <param name="filingStatus"></param>
        /// <param name="dependentAllowances"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, decimal federalWithholding, FilingStatus filingStatus = FilingStatus.Single, int dependentAllowances = 0)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");
            if (federalWithholding < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(federalWithholding)} cannot be a negative number");
            if (dependentAllowances < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(dependentAllowances)} cannot be a negative number");

            var taxableWages = frequency.CalculateAnnualized(grossWages);

            var annualWages = taxableWages;

            taxableWages -= frequency.CalculateAnnualized(federalWithholding);

            taxableWages -= GetStandardDeduction(filingStatus, annualWages);

            taxableWages -= GetPersonalAllowance(filingStatus);
  
            taxableWages -= GetDependentAllowance(annualWages, dependentAllowances);

            var taxWithheld = GetTaxWithholding(filingStatus, taxableWages);

            return Math.Max(Decimal.Zero, frequency.CalculateDeannualized(taxWithheld));
        }

        internal virtual Decimal GetStandardDeduction(FilingStatus filingStatus, decimal grossWages)
        {
            var sd =
                StandardDeductions
                .Where(d => d.FilingStatus == filingStatus)
                .FirstOrDefault(d => d.Floor <= grossWages && d.Ceiling > grossWages);

            if (sd.Increment > 0.00m)            
                return sd.Amount - ((int)((grossWages - sd.Floor) / sd.IncrementDivisor) * sd.Increment);            
            else
                return sd.Amount;
        }

        internal virtual Decimal GetPersonalAllowance(FilingStatus filingStatus)
        {
            // Note: A married couple filing joint with one spouse working and who only claims 1 allowance should use column (6) (married filing separate) for their personal allowance
            

            var allowance_value =
                PersonalAllowances
                .Where(d => d.FilingStatus == filingStatus)
                .Select(d => d.Amount)
                .Single();

            return allowance_value;
        }

        internal virtual Decimal GetDependentAllowance(decimal grossWages, int dependentAllowances = 0)
        {
            return DependentAllowances
                   .Where(x => x.Floor <= grossWages && x.Ceiling > grossWages)
                   .Select(x => x.Amount)
                   .Single() * dependentAllowances;
        }

        internal virtual decimal GetTaxWithholding(FilingStatus filingStatus, Decimal taxableWages)
        {
            var wages = taxableWages;
            var withholdings = TaxableWithholdings
             .Where(x => x.FilingStatus == filingStatus);                
            decimal sum = 0.00m;
            withholdings.OrderBy(x => x.TaxAmount);
            var numOfWithholdings = withholdings.Count();

            for (int i = 0; i < numOfWithholdings; i++)
            {
                if (i == (numOfWithholdings - 1))
                {
                    wages -= withholdings.ElementAt(i).TaxAmount;
                    sum += wages * withholdings.ElementAt(i).TaxRate;
                    return sum;
                }

                if (wages > withholdings.ElementAt(i).TaxAmount)
                {                    
                    sum += withholdings.ElementAt(i).TaxAmount * withholdings.ElementAt(i).TaxRate;
                }
                else
                {
                    sum += wages * withholdings.ElementAt(i).TaxRate;
                    return sum;
                }
            }
            return sum;            
        }

        public class StandardDeduction : DependentAllowance
        {
            public FilingStatus FilingStatus { get; set; }

            public Decimal Increment { get; set; } = 0.00m;

            public Decimal IncrementDivisor { get; set; } = 0.00m;
        }

        public class DependentAllowance
        {
            public Decimal Amount { get; set; }
            public Decimal Ceiling { get; set; }
            public Decimal Floor { get; set; }
        }

        public class TaxableWithholding
        {
            public FilingStatus FilingStatus { get; set; } = FilingStatus.Single;

            public Decimal TaxAmount { get; set; }

            public Decimal TaxRate { get; set; }
        }
    }

    public enum FilingStatus : byte
    {    

        [Display(Name = "A - Single")]
        Single = 0,

        [Display(Name = "B - Married Filing Jointly")]
        Married = 1,        

        [Display(Name = "C - Married Filing Separately")]
        MarriedFilingSeparate = 2,

        [Display(Name = "D - Head of Family")]
        HeadOfFamily = 3
    }
}