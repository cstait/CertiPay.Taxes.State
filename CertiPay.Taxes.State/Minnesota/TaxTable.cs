using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CertiPay.Taxes.State.Minnesota
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get; internal set; } = StateOrProvince.MN;
        public virtual Decimal Allowance { get; }
        public virtual IEnumerable<TaxableWithholding> TaxableWithholdings { get; }

        /// <summary>
        /// Returns Minnestoa State Withholding when given a non-negative value for Gross Wages and Allowances.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="filingStatus"></param>
        /// <param name="allowances"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, FilingStatus filingStatus, int allowances = 0)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");
            if (allowances < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(allowances)} cannot be a negative number");

            var taxableWages = frequency.CalculateAnnualized(grossWages);

            taxableWages -= GetAllowance(allowances);

            if (taxableWages <= 0)
                return 0;

            var selectedRow = GetTaxableWithholding(filingStatus, taxableWages);

            var taxWithheld = selectedRow.TaxBase + ((taxableWages - selectedRow.StartingAmount) * selectedRow.TaxRate);

            return frequency.CalculateDeannualized(Math.Max(0, taxWithheld));
        }

        protected virtual Decimal GetAllowance(int allowances)
        {
            return Allowance * allowances;
        }

        protected virtual TaxableWithholding GetTaxableWithholding(FilingStatus filingStatus, decimal taxableWages)
        {
            return TaxableWithholdings
                .Where(x => x.FilingStatus == filingStatus)
                .Where(x => x.StartingAmount <= taxableWages && x.MaximumWage > taxableWages)
                .Select(x => x)
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
}
