using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.Kentucky
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 14000; } }

        protected override decimal StandardDeduction { get { return 2480; } }

        protected override decimal Exemption { get { return 10; } }

        protected override IEnumerable<Bracket> Brackets
        {
            get
            {
                yield return new TaxTable.Bracket { Amount = 3000.00m, Percentage = 0.02m };
                yield return new TaxTable.Bracket { Amount = 1000.00m, Percentage = 0.03m };
                yield return new TaxTable.Bracket { Amount = 1000.00m, Percentage = 0.04m };
                yield return new TaxTable.Bracket { Amount = 3000.00m, Percentage = 0.05m };
                yield return new TaxTable.Bracket { Amount = 67000.00m, Percentage = 0.058m };
                yield return new TaxTable.Bracket { Amount = 75000.00m, Percentage = 0.06m };
            }
        }
    }
}