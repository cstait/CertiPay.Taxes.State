using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.Ohio
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 9000; } }

        protected override Decimal Exemption { get { return 650; } }

        protected override Decimal TaxRate { get { return 1.112m; } }

        protected override IEnumerable<TaxableWithholding> TaxableWithholdings
        {
            get
            {                
                yield return new TaxTable.TaxableWithholding { TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 5000.00m, TaxRate = .005m };
                yield return new TaxTable.TaxableWithholding { TaxBase = 25.00m, StartingAmount = 5000.00m, MaximumWage = 10000.00m, TaxRate = .01m };
                yield return new TaxTable.TaxableWithholding { TaxBase = 75.00m, StartingAmount = 10000.00m, MaximumWage = 15000.00m, TaxRate = .02m };
                yield return new TaxTable.TaxableWithholding { TaxBase = 175.00m, StartingAmount = 15000.00m, MaximumWage = 20000.00m, TaxRate = .025m };
                yield return new TaxTable.TaxableWithholding { TaxBase = 300.00m, StartingAmount = 20000.00m, MaximumWage = 40000.00m, TaxRate = .03m };
                yield return new TaxTable.TaxableWithholding { TaxBase = 900.00m, StartingAmount = 40000.00m, MaximumWage = 80000.00m, TaxRate = .035m };
                yield return new TaxTable.TaxableWithholding { TaxBase = 2300.00m, StartingAmount = 80000.00m, MaximumWage = 100000.00m, TaxRate = .04m };
                yield return new TaxTable.TaxableWithholding { TaxBase = 3100.00m, StartingAmount = 100000.00m, MaximumWage = Decimal.MaxValue, TaxRate = .05m };
            }
        }
    }
}