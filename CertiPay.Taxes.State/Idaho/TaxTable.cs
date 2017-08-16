using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CertiPay.Taxes.State.Idaho
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.ID; } }

        public abstract Decimal AnnualAllowance { get; }

        public abstract IEnumerable<TaxableWithholding> TaxableWithholdings { get; }

        /// <summary>
        /// Returns Idaho State Withholding when given a non-negative value for gross wages and personal allowances.
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

            var taxWithheld = Math.Round(selected_row.TaxBase + ((taxableWages - selected_row.StartingAmount) * selected_row.TaxRate), MidpointRounding.AwayFromZero);

            return Math.Round(frequency.CalculateDeannualized(taxWithheld), MidpointRounding.AwayFromZero);
        }

        internal virtual Decimal GetPersonalAllowance(int personalAllowances = 1)
        {
            return AnnualAllowance * personalAllowances;
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
        [Display(Name = "Single")]
        Single = 0,

        [Display(Name = "Married")]
        Married = 1,

        [Display(Name = "Head of Household")]
        HeadOfHousehold = 2
    }
}