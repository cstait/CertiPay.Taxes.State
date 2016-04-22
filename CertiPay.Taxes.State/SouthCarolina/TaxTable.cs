﻿using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CertiPay.Taxes.State.SouthCarolina
{
    public abstract class TaxTable
    {
        public abstract int Year { get; }

        public abstract Decimal StandardDeduction(Decimal annualizedWages);

        public abstract Decimal ExemptionValue { get; }

        public abstract IEnumerable<TableRow> Table { get; }

        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, int exemptions = 0)
        {
            var annualized_wages = frequency.CalculateAnnualized(grossWages);

            // If zero exemptions were claimed, do not deduct standard deduction

            if (exemptions > Decimal.Zero)
            {
                annualized_wages -= (exemptions * ExemptionValue);

                annualized_wages -= StandardDeduction(annualized_wages);
            }

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