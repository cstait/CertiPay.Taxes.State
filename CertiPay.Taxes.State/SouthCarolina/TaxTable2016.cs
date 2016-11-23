using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.SouthCarolina
{
    public class TaxTable2016 : TaxTable
    {
        public override int Year { get { return 2016; } }

        public override Decimal SUI_Wage_Base { get { return 14000; } }

        public override Decimal StandardDeduction(Decimal annualizedWages)
        {
            // 10% up to $2,600.00 if claiming 1 or more exemptions

            return Math.Min(2600, annualizedWages * 0.10m);
        }

        public override Decimal ExemptionValue { get { return 2300; } }

        public override IEnumerable<TableRow> Table
        {
            get
            {
                yield return new TableRow { StartingAmount = 0, MaximumWage = 2920, TaxBase = 0, TaxRate = 0.00m };

                yield return new TableRow { StartingAmount = 2920, MaximumWage = 5840, TaxBase = 0, TaxRate = 0.03m };

                yield return new TableRow { StartingAmount = 5840, MaximumWage = 8760, TaxBase = 87.60m, TaxRate = 0.04m };

                yield return new TableRow { StartingAmount = 8760, MaximumWage = 11680, TaxBase = 204.40m, TaxRate = 0.05m };

                yield return new TableRow { StartingAmount = 11680, MaximumWage = 14600, TaxBase = 350.40m, TaxRate = 0.06m };

                yield return new TableRow { StartingAmount = 14600, MaximumWage = Decimal.MaxValue, TaxBase = 525.60m, TaxRate = 0.07m };
            }
        }
    }
}