using System;
using System.Collections.Generic;
namespace CertiPay.Taxes.State.RhodeIsland
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 22400.00m; } }

        public override decimal ExemptionAmount { get { return 1000.00m; } }

        public override decimal ExemptionExclusionAmount { get {return 217350.00m; } }

        public override IEnumerable<TaxableWithholding> TaxableWithholdings
        {
            get
            {                
                yield return new TaxTable.TaxableWithholding {TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 61300.00m, TaxRate = .0375m };
                yield return new TaxTable.TaxableWithholding { TaxBase = 2298.75m, StartingAmount = 61300.00m, MaximumWage = 139400.00m, TaxRate = .0475m };
                yield return new TaxTable.TaxableWithholding { TaxBase = 6008.50m, StartingAmount = 139400.00m, MaximumWage = decimal.MaxValue, TaxRate = .0599m };                
            }
        }
    }
}