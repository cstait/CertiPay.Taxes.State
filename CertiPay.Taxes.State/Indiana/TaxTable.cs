using CertiPay.Payroll.Common;
using System;

namespace CertiPay.Taxes.State.Indiana
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.IN; } }

        public abstract Decimal PersonalAllowances { get; }

        public abstract Decimal DependentAllowances { get; }

        public abstract Decimal StateTaxRate { get; }


        /// <summary>
        /// Returns Indiana State Withholding when a non-negative value is given for gross wages, personal allowances and dependent allowances.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="personalAllowances"></param>
        /// <param name="dependentAllowances"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, int personalAllowances = 1, int dependentAllowances = 0)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");
            if (personalAllowances < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(personalAllowances)} cannot be a negative number");
            if (dependentAllowances< Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(dependentAllowances)} cannot be a negative number");

            var taxableWages = frequency.CalculateAnnualized(grossWages);

            taxableWages -= GetPersonalAllowance(personalAllowances);

            taxableWages -= GetDependentAllowance(dependentAllowances);

            var taxWithheld = GetTaxWithholding(taxableWages);

            return Math.Max(0, frequency.CalculateDeannualized(taxWithheld));
        }

        internal virtual Decimal GetPersonalAllowance(int personalAllowances = 1)
        {
            return PersonalAllowances * personalAllowances;
        }

        internal virtual Decimal GetDependentAllowance(int dependentAllowances = 0)
        {
            return DependentAllowances * dependentAllowances;
        }

        internal virtual Decimal GetTaxWithholding(Decimal taxableWages)
        {
            return StateTaxRate * taxableWages;
        }
    }
}