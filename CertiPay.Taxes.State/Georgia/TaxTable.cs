using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CertiPay.Taxes.State.Georgia
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.GA; } }

        public abstract IEnumerable<StandardDeduction> StandardDeductions { get; }

        public abstract IEnumerable<StandardDeduction> PersonalAllowances { get; }

        public abstract Decimal DependentAllowances { get; }

        public abstract IEnumerable<TaxableWithholding> TaxableWithholdings { get; }
        /// <summary>
        /// Returns Georgia State Withholding when provided with a non-negative value for Gross Wages, Personal Allowances, and Dependent Allowances.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="filingStatus"></param>
        /// <param name="personalAllowances"></param>
        /// <param name="dependentAllowances"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, FilingStatus filingStatus = FilingStatus.Single, int personalAllowances = 1, int dependentAllowances = 0)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");            
            if (personalAllowances < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(personalAllowances)} cannot be a negative number");
            if (dependentAllowances < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(dependentAllowances)} cannot be a negative number");
            var taxableWages = frequency.CalculateAnnualized(grossWages);

            // Note: Tax exemptions should be handled before we get to this call

            // if (FilingStatus.Exempt == filingStatus) return Decimal.Zero;

            //Use these instructions to calculate employee withholding using the percentage method.

            //(1) Subtract the applicable standard deduction as indicated in column(1) - (3) of Table E.

            taxableWages -= GetStandardDeduction(filingStatus);

            //(2) Subtract from the amount arrived at in (1) the appropriate amount of personal allowance as set out in column(4) – (6) of Table E.

            taxableWages -= GetPersonalAllowance(filingStatus, personalAllowances);

            //(3) If employees claim dependents other than themselves and/or their spouses, subtract from the amount arrived at in (2) the appropriate dependent amount as set out in column(7) of Table E.

            taxableWages -= GetDependentAllowance(filingStatus, dependentAllowances);

            if (taxableWages <= 0)
            {
                return 0;
            }

            //(4) Determine the amount of tax to be withheld from the applicable payroll line in Tables F, G, or H.

            var selected_row = GetTaxWithholding(filingStatus, taxableWages);

            // Calculate the withholding from the percentages

            var taxWithheld = selected_row.TaxBase + ((taxableWages - selected_row.StartingAmount) * selected_row.TaxRate);

            //(5) If zero exemption is claimed, subtract the standard deduction only.

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

        internal virtual Decimal GetPersonalAllowance(FilingStatus filingStatus, int personalAllowances = 1)
        {
            // Note: A married couple filing joint with one spouse working and who only claims 1 allowance should use column (6) (married filing separate) for their personal allowance

            if (personalAllowances == 1 && FilingStatus.MarriedWithOneIncome == filingStatus)
            {
                filingStatus = FilingStatus.MarriedFilingSeparate;
            }

            var allowance_value =
                PersonalAllowances
                .Where(d => d.FilingStatus == filingStatus)
                .Select(d => d.Amount)
                .Single();

            return allowance_value * personalAllowances;
        }

        internal virtual Decimal GetDependentAllowance(FilingStatus filingStatus, int dependentAllowances = 0)
        {
            return DependentAllowances * dependentAllowances;
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

        public class StandardDeduction : DependentAllowance
        {
            public FilingStatus FilingStatus { get; set; }
        }

        public class DependentAllowance
        {
            public Decimal Amount { get; set; }
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