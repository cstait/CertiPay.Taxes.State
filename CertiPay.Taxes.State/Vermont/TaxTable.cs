using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CertiPay.Taxes.State.Vermont
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.VT; } }
        public abstract decimal AllowanceValue { get; }
        public abstract IEnumerable<TaxableWithholding> TaxableWithholdings { get; }

        /// <summary>
        /// Returns Vermont State Withholding when given a non-negative value for Gross Wages, Withholding Allowans and Non Resident Percentage.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="filingStatus"></param>
        /// <param name="withholdingAllowances"></param>
        /// <param name="nonresidentPercentage"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, FilingStatus filingStatus = FilingStatus.Single, int withholdingAllowances = 1, decimal nonresidentPercentage = 0.00m)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");            
            if (withholdingAllowances < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(withholdingAllowances)} cannot be a negative number");
            if (nonresidentPercentage < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(withholdingAllowances)} cannot be a negative number");


            var taxableWages = frequency.CalculateAnnualized(grossWages);            

            taxableWages -= GetWitholdingAllowance(withholdingAllowances);

            if (taxableWages <= 0)
                return 0;

            var selected_row = GetTaxWithholding(filingStatus, taxableWages);            

            var taxWithheld = selected_row.TaxBase + ((taxableWages - selected_row.StartingAmount) * selected_row.TaxRate);

            if (nonresidentPercentage == 0.00m)
                return frequency.CalculateDeannualized(taxWithheld);
            else
                return nonresidentPercentage * frequency.CalculateDeannualized(taxWithheld);
        }

        public decimal GetWitholdingAllowance(int withholdingAllowance)
        {
            return withholdingAllowance * AllowanceValue;
        }

        internal virtual TaxableWithholding GetTaxWithholding(FilingStatus filingStatus, Decimal taxableWages)
        {            
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

}
