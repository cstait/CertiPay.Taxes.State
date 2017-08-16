using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CertiPay.Taxes.State.SouthCarolina
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.SC; } }

        public abstract Decimal StandardDeduction(Decimal annualizedWages);

        public abstract Decimal ExemptionValue { get; }

        public abstract IEnumerable<TableRow> Table { get; }

        /// <summary>
        /// Returns South Carolina Withholding when given a non-negative value for Gross Wages and Exemptions.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="exemptions"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, int exemptions = 0)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");
            if (exemptions < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(exemptions)} cannot be a negative number");
            
            var annualized_wages = frequency.CalculateAnnualized(grossWages);

            // If zero exemptions were claimed, do not deduct standard deduction

            if (exemptions > Decimal.Zero)
            {
                // The standard deduction is taken from the annualized wages before further reducing by the exemption values

                annualized_wages -= (exemptions * ExemptionValue + StandardDeduction(annualized_wages));
            }

            if (annualized_wages <= 0)
                return 0;

            var tax_table =
                Table
                .Where(row => row.StartingAmount <= annualized_wages)
                .Where(row => row.MaximumWage > annualized_wages)
                .Single();

            var annualized_taxes = tax_table.TaxBase + (annualized_wages - tax_table.StartingAmount) * tax_table.TaxRate;

            return frequency.CalculateDeannualized(annualized_taxes);
        }

        public class TableRow
        {
            public Decimal TaxBase { get; set; }

            public Decimal StartingAmount { get; set; }

            public Decimal MaximumWage { get; set; }

            public Decimal TaxRate { get; set; }
        }
    }
}