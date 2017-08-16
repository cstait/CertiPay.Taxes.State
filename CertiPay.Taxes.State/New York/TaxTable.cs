using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CertiPay.Taxes.State.NewYork
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.NY; } }

        public abstract IEnumerable<DeductionAllowance> DeductionAllowances { get; }

        public abstract Decimal ExemptionAllowance { get; }

        public abstract IEnumerable<TaxableWithholding> TaxableWithholdings { get; }

        /// <summary>
        /// Returns New York State Withholding when given a non-negative value for Gross Wages and Dependent Allowances.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="region"></param>
        /// <param name="filingStatus"></param>
        /// <param name="exemptionAllowances"></param>
        /// <param name="dependentAllowances"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, Region region, FilingStatus filingStatus = FilingStatus.Single, int exemptionAllowances = 1, int dependentAllowances = 0)
        {

            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");        
            if (dependentAllowances < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(dependentAllowances)} cannot be a negative number");

            var taxableWages = frequency.CalculateAnnualized(grossWages);

            // Note: Tax exemptions should be handled before we get to this call

            // if (FilingStatus.Exempt == filingStatus) return Decimal.Zero;

            //Use these instructions to calculate employee withholding using the percentage method.

            //(1) Subtract the applicable standard deduction as indicated in column(1) - (3) of Table E.

            taxableWages -= GetDeductionAllowance(filingStatus, region);

            //(2) Subtract from the amount arrived at in (1) the appropriate amount of personal allowance as set out in column(4) – (6) of Table E.

            taxableWages -= GetExemptionAllowance(filingStatus, exemptionAllowances);

            if (taxableWages <= 0)
                return 0;
            //(3) If employees claim dependents other than themselves and/or their spouses, subtract from the amount arrived at in (2) the appropriate dependent amount as set out in column(7) of Table E.

            //(4) Determine the amount of tax to be withheld from the applicable payroll line in Tables F, G, or H.

            var selected_row = GetTaxWithholding(filingStatus, taxableWages, region);

            // Calculate the withholding from the percentages

            var taxWithheld = selected_row.TaxBase + ((taxableWages - selected_row.StartingAmount) * selected_row.TaxRate);

            //(5) If zero exemption is claimed, subtract the standard deduction only.

            return frequency.CalculateDeannualized(taxWithheld);
        }

        internal virtual Decimal GetDeductionAllowance(FilingStatus filingStatus, Region region)
        {
            return
                DeductionAllowances
                .Where(d => d.FilingStatus == filingStatus && d.Region == region)
                .Select(d => d.Amount)
                .Single();
        }

        internal virtual Decimal GetExemptionAllowance(FilingStatus filingStatus, int exemptionAllowances = 1)
        {
            return ExemptionAllowance * exemptionAllowances;
        }

        internal virtual TaxableWithholding GetTaxWithholding(FilingStatus filingStatus, Decimal taxableWages, Region region)
        {
            if (taxableWages < Decimal.Zero) return new TaxableWithholding { };

            return
                TaxableWithholdings
                .Where(d => d.Region == region)
                .Where(d => d.FilingStatus == filingStatus)
                .Where(d => d.StartingAmount <= taxableWages)
                .Where(d => taxableWages < d.MaximumWage)
                .Select(d => d)
                .Single();
        }

        public class DeductionAllowance
        {
            public FilingStatus FilingStatus { get; set; }

            public Decimal Amount { get; set; }

            public Region Region { get; set; }
        }

        public class TaxableWithholding
        {
            public FilingStatus FilingStatus { get; set; } = FilingStatus.Single;

            public Decimal TaxBase { get; set; }

            public Decimal StartingAmount { get; set; }

            public Decimal MaximumWage { get; set; }

            public Decimal TaxRate { get; set; }

            public Region Region { get; set; }
        }
    }

    public enum Region : byte
    {
        // A) New York State
        // B) Yonkers
        // C) New York City

        [Display(Name = "New York State")]
        NewYorkState = 0,

        [Display(Name = "Yonkers")]
        Yonkers = 1,

        [Display(Name = "New York City")]
        NewYorkCity
    }
}