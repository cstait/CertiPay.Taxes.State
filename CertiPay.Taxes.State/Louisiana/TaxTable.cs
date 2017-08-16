using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CertiPay.Taxes.State.Louisiana
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get; internal set; } = StateOrProvince.LA;

        public virtual Decimal PersonalExemption { get; }

        public virtual Decimal DependentExemption { get; }

        public virtual IEnumerable<Rate> Rates { get; }

        /// <summary>
        /// Returns Lousiana State Withholding when given a non-negative value for Gross Wages, Personal Exemptions, and Dependents.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="filingStatus"></param>
        /// <param name="personalExemptions"></param>
        /// <param name="dependents"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, FilingStatus filingStatus, int personalExemptions = 0, int dependents = 0)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");
            if (personalExemptions < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(personalExemptions)} cannot be a negative number");
            if (dependents < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(dependents)} cannot be a negative number");
            
            var TaxableWages = frequency.CalculateAnnualized(grossWages);

            var rate = GetRate(filingStatus, personalExemptions);

            var deductions = GetDeductions(rate, personalExemptions, dependents);

            var withholding = Math.Max(0, GetWithholding(rate, TaxableWages, deductions));

            return frequency.CalculateDeannualized(withholding);
        }

        protected virtual Decimal GetWithholding(Rate rate, decimal taxableWages, decimal deductions)
        {
            if (taxableWages < rate.LowerCeiling)
                return (rate.HighRate * taxableWages) - deductions;
            else if (taxableWages >= rate.LowerCeiling && taxableWages < rate.HigherCeiling)
                return (rate.HighRate * taxableWages) + rate.MiddleRate * (Math.Max(0, taxableWages - rate.LowerCeiling)) - deductions;
            else
                return (rate.HighRate * taxableWages) + rate.MiddleRate * (Math.Max(0, taxableWages - rate.LowerCeiling)) + rate.LowRate * (Math.Max(0, taxableWages - rate.HigherCeiling)) - deductions;
        }

        protected virtual Rate GetRate(FilingStatus filingStatus, int personalExemptions)
        {
            return Rates
                .Where(x => x.FilingStatus == filingStatus && x.Exemptions == personalExemptions)
                .Select(x => x)
                .Single();
        }

        protected virtual Decimal GetDeductions(Rate rate, int personalExemptions, int dependents)
        {
            return (rate.HighRate * ((personalExemptions * PersonalExemption) + (dependents * DependentExemption))) + (Math.Max(0, rate.MiddleRate * ((personalExemptions * PersonalExemption) + (dependents * DependentExemption) - rate.ExemptionCap)));
        }

        public class Rate
        {
            public Decimal LowerCeiling { get; set; }
            public Decimal HigherCeiling { get; set; }
            public Decimal HighRate { get; set; }
            public Decimal MiddleRate { get; set; }
            public Decimal LowRate { get; set; }
            public Decimal Exemptions { get; set; }
            public Decimal ExemptionCap { get; set; }
            public FilingStatus FilingStatus { get; set; }
        }
    }
}