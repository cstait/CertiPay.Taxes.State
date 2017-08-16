using CertiPay.Payroll.Common;
using System;

namespace CertiPay.Taxes.State.Michigan
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get; internal set; } = StateOrProvince.MI;

        public virtual Decimal Exemption { get; }

        public virtual Decimal Tax { get; }


        /// <summary>
        /// Returns Michigan State Withholding when given a non-negative value for Gross Wages, Personal Exemptions and Dependents.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="personalExemptions"></param>
        /// <param name="dependents"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, int personalExemptions = 0, int dependents = 0)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");
            if (personalExemptions < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(personalExemptions)} cannot be a negative number");
            if (dependents < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(dependents)} cannot be a negative number");
            

            var taxableWages = frequency.CalculateAnnualized(grossWages);

            taxableWages -= GetDeductions(personalExemptions + dependents);

            var taxWithheld = taxableWages * Tax;

            return frequency.CalculateDeannualized(Math.Max(0, taxWithheld));
        }

        protected virtual Decimal GetDeductions(int exemptions)
        {
            return exemptions * Exemption;
        }
    }
}