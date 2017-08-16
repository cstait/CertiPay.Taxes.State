using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CertiPay.Taxes.State.Colorado
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.CO; } }
        protected abstract Decimal Allowance { get; }
        protected abstract IEnumerable<TaxableWithholding> TaxableWithholdings { get; }

        /// <summary>
        /// Returns Colorado State Withholding when given a non-negative value for Gross Wages and Personal Allowances.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="filingStatus"></param>
        /// <param name="personalAllowances"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, FilingStatus filingStatus, int personalAllowances)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");            
            if (personalAllowances < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(personalAllowances)} cannot be a negative number");
            
            var taxableWages = frequency.CalculateAnnualized(grossWages);
            taxableWages -= GetPersonalAllowance(personalAllowances);

            if (taxableWages <= 0)
            {
                return 0;
            }

            var taxRate = GetTaxWithholding(filingStatus, taxableWages);
            var taxWithheld = taxRate.TaxBase + ((taxableWages - taxRate.StartingAmount) * taxRate.TaxRate);

            return frequency.CalculateDeannualized(Math.Max(0, taxWithheld)).Round(decimals: 0);
        }

        protected virtual Decimal GetPersonalAllowance(int personalAllowances)
        {
            return personalAllowances * Allowance;
        }


        protected virtual TaxableWithholding GetTaxWithholding(FilingStatus filingStatus, Decimal taxableWages)
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


        protected class TaxableWithholding
        {
            public FilingStatus FilingStatus { get; set; } = FilingStatus.Single;
            public Decimal TaxBase { get; set; }
            public Decimal StartingAmount { get; set; }
            public Decimal MaximumWage { get; set; }
            public Decimal TaxRate { get; set; }
        }
    }
}