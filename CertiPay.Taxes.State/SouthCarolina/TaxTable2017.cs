using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.SouthCarolina
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 14000; } }

        public override Decimal StandardDeduction(Decimal annualizedWages)
        {
            // 10% up to $2,860.00 if claiming 1 or more exemptions

            return Math.Min(2860, annualizedWages * 0.10m);
        }

        public override Decimal ExemptionValue { get { return 2370; } }

        public override IEnumerable<TableRow> Table
        {
            //addition method
            get
            {
                yield return new TableRow { StartingAmount = 0, MaximumWage = 2140, TaxBase = 0, TaxRate = 0.017m };

                yield return new TableRow { StartingAmount = 2140, MaximumWage = 4280, TaxBase = 36.38m, TaxRate = 0.03m };

                yield return new TableRow { StartingAmount = 4280, MaximumWage = 6420, TaxBase = 100.58m, TaxRate = 0.04m };

                yield return new TableRow { StartingAmount = 6420, MaximumWage = 8560, TaxBase = 186.18m, TaxRate = 0.05m };

                yield return new TableRow { StartingAmount = 8560, MaximumWage = 10700, TaxBase = 293.18m, TaxRate = 0.06m };

                yield return new TableRow { StartingAmount = 10700, MaximumWage = Decimal.MaxValue, TaxBase = 421.58m, TaxRate = 0.07m };
            }
        }
    }
}