using CertiPay.Payroll.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace CertiPay.Taxes.State.NorthCarolina
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.NC; } }

        public abstract Decimal StandardDeduction(FilingStatus taxStatus);

        public abstract Decimal AllowanceValue { get; }

        public abstract Decimal TaxRate { get; }

        /// <summary>
        /// Returns North Carolina State Withholding when provided with a non-negative value for Gross Wages and Allowances.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="taxStatus"></param>
        /// <param name="allowances"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, FilingStatus taxStatus = FilingStatus.Single, int allowances = 0)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");
            if (allowances < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(allowances)} cannot be a negative number");
            
            // Withholding Statuses: Single, Married, Head of Household

            var annualized_wages = frequency.CalculateAnnualized(grossWages);

            // The standard deduction is taken from the annualized wages before further reducing by the allowances values

            annualized_wages -= (allowances * AllowanceValue + StandardDeduction(taxStatus));

            // Multiply the annualized wages by the given tax rate and deannualize back for the period
            // Round off the final result of calculations to the nearest whole dollar

            return frequency.CalculateDeannualized(Math.Max(0, annualized_wages * TaxRate)).Round(decimals: 0);
        }
    }

    public enum FilingStatus : byte
    {
        Single,

        Married,

        [Display(Name = "Head of Household")]
        HeadOfHousehold
    }
}
