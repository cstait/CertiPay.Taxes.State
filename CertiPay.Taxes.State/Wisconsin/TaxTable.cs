using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CertiPay.Taxes.State.Wisconsin
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.WI; } }

        protected abstract IEnumerable<StandardDeduction> StandardDeductions { get; }

        protected abstract Decimal PersonalAllowances { get; }

        protected abstract IEnumerable<TaxableWithholding> TaxableWithholdings { get; }

        /// <summary>
        /// Returns Wisconsin State Withholding when given a non-negative value for Gross Wages, Dependent Allowances and Personal Allowances.
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

            taxableWages -= GetStandardDeduction(filingStatus, taxableWages);
            taxableWages -= GetPersonalAllowance(personalAllowances);

            if (taxableWages <= 0)
                return 0;

            var selected_row = GetTaxWithholding(taxableWages);

            var taxWithheld = selected_row.TaxBase + ((taxableWages - selected_row.StartingAmount) * selected_row.TaxRate);

            return frequency.CalculateDeannualized(Math.Max(0, taxWithheld));
        }

        protected virtual Decimal GetStandardDeduction(FilingStatus filingStatus, decimal wages)
        {
            var deduction =
                StandardDeductions
                .Where(d => d.FilingStatus == filingStatus)
                .Where(d => d.StartingAmount <= wages && wages < d.MaximumWage)
                .Select(d => d)
                .Single();

            if (deduction.Percentage > Decimal.Zero)
                return deduction.Amount - (deduction.Percentage * (wages - deduction.StartingAmount));
            else
                return deduction.Amount;
        }

        protected virtual Decimal GetPersonalAllowance(int personalAllowances = 1)
        {
            return PersonalAllowances * personalAllowances;
        }

        protected virtual TaxableWithholding GetTaxWithholding(Decimal taxableWages)
        {
            if (taxableWages < Decimal.Zero) return new TaxableWithholding { };

            return
                TaxableWithholdings
                .Where(d => d.StartingAmount <= taxableWages)
                .Where(d => taxableWages < d.MaximumWage)
                .Select(d => d)
                .Single();
        }

        protected class StandardDeduction
        {
            public FilingStatus FilingStatus { get; set; }

            public Decimal StartingAmount { get; set; }

            public Decimal MaximumWage { get; set; }

            public Decimal Amount { get; set; }

            public Decimal Percentage { get; set; } = Decimal.Zero;
        }

        protected class TaxableWithholding
        {
            public Decimal TaxBase { get; set; }

            public Decimal StartingAmount { get; set; }

            public Decimal MaximumWage { get; set; }

            public Decimal TaxRate { get; set; }
        }
    }
}