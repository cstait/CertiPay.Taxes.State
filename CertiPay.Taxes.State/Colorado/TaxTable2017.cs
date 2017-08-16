using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.Colorado
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }
        public override Decimal SUI_Wage_Base { get { return 12500; } }
        protected override decimal Allowance { get { return 4050; } }

        protected override IEnumerable<TaxableWithholding> TaxableWithholdings
        {
            get
            {
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 0.00m, MaximumWage = 2300, TaxRate = 0.00m, TaxBase = 0.00m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 2300, MaximumWage = decimal.MaxValue, TaxRate = 0.0463m, TaxBase = 0.00m };

                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 0.00m, MaximumWage = 8650, TaxRate = 0.00m, TaxBase = 0.00m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 8650, MaximumWage = decimal.MaxValue, TaxRate = 0.0463m, TaxBase = 0.00m };
            }
        }
    }
}