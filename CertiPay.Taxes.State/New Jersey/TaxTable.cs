using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CertiPay.Taxes.State.NewJersey
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.NJ; } }

        public abstract decimal PersonalAllowances { get; }

        public abstract IEnumerable<TaxableWithholding> TaxableWithholdings { get; }

        /// <summary>
        /// Returns New Jersey State Withholding when given a non-negative value for Gross Wages and Personal Allowances.
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

            taxableWages -= GetPersonalAllowance(personalAllowances);

            if (taxableWages <= 0)
                return 0;

            var selected_row = GetTaxWithholding(filingStatus, taxableWages);

            var taxWithheld = selected_row.TaxBase + ((taxableWages - selected_row.StartingAmount) * selected_row.TaxRate);

            return Math.Max(0, frequency.CalculateDeannualized(taxWithheld));
        }

        internal virtual Decimal GetPersonalAllowance(int numOfPersonalAllowances)
        {
            return PersonalAllowances * numOfPersonalAllowances;
        }

        internal virtual TaxableWithholding GetTaxWithholding(FilingStatus filingStatus, Decimal taxableWages)
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

        public class TaxableWithholding
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
        // A) Single
        // B) Married - 2 incomes
        // C) Married - 1 income
        // D) Married filing separate
        // E) Head of Household

        [Display(Name = "A - Single")]
        Single = 0,

        [Display(Name = "B - Married Filing Jointly, Both Spouses Working")]
        MarriedWithTwoIncomes = 1,

        [Display(Name = "C - Married Filing Jointly, One Spouse Working")]
        MarriedWithOneIncome = 2,

        [Display(Name = "D - Married Filing Separately")]
        MarriedFilingSeparate = 3,

        [Display(Name = "E - Head of Household")]
        HeadOfHousehold = 4
    }
}