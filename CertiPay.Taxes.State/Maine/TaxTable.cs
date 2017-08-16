using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CertiPay.Taxes.State.Maine
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.ME; } }

        public abstract IEnumerable<StandardDeduction> StandardDeductions { get; }

        public abstract Decimal WithholdingAllowance { get; }

        public abstract IEnumerable<TaxableWithholding> TaxableWithholdings { get; }

        /// <summary>
        /// Returns Maine State Withholding when given a non-negative value for Gross Wages and Withholding Allowances.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="filingStatus"></param>
        /// <param name="withholdingAllowances"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, FilingStatus filingStatus = FilingStatus.Single, int withholdingAllowances = 1)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");
            if (withholdingAllowances < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(withholdingAllowances)} cannot be a negative number");
            
            var taxableWages = frequency.CalculateAnnualized(grossWages);

            var annualWages = taxableWages;

            taxableWages -= GetWitholdingAllowance(withholdingAllowances);

            taxableWages -= GetStandardDeduction(filingStatus, annualWages);

            if (taxableWages > 0)
            {
                var selected_row = GetTaxWithholding(filingStatus, taxableWages);
                var taxWithheld = selected_row.TaxBase + ((taxableWages - selected_row.StartingAmount) * selected_row.TaxRate);
                return frequency.CalculateDeannualized(taxWithheld);
            }
            else return 0;
        }

        internal virtual Decimal GetWitholdingAllowance(int withholdingAllowances)
        {
            return withholdingAllowances * WithholdingAllowance;
        }

        internal virtual Decimal GetStandardDeduction(FilingStatus filingStatus, Decimal annualWages)
        {
            var standardDeduction = StandardDeductions
                .Where(x => x.FilingStatus == filingStatus)
                .First(x => x.FloorAmount <= annualWages && x.CeilingAmount > annualWages);

            if (standardDeduction.CalcValue > 0.00m)
                return (1 - (Math.Round(((annualWages - standardDeduction.FloorAmount) / standardDeduction.CalcValue), 4)) * standardDeduction.Amount);
            else
                return standardDeduction.Amount;
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

        public class StandardDeduction
        {
            public Decimal FloorAmount { get; set; }
            public Decimal CeilingAmount { get; set; }
            public FilingStatus FilingStatus { get; set; }
            public Decimal Amount { get; set; }

            //certain deductions require an additional calculation step
            public Decimal CalcValue { get; set; } = 0.00m;
        }
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