using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.Nebraska
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 9000; } }

        protected override decimal PersonalAllowances { get { return 1960; } }
                
        protected override IEnumerable<TaxableWithholding> TaxableWithholdings
        {
            get
            {
                // Percentage method for computing tax on wages subject to withholding

                // Single Individual

                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 0.00m, StartingAmount = 0, MaximumWage = 7100.00m, TaxRate = 0 };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 0.00m, StartingAmount = 7100.00m, MaximumWage = 10610.00m, TaxRate = .0226m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 79.33m, StartingAmount = 10610.00m, MaximumWage = 26420.00m, TaxRate = .0322m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 588.41m, StartingAmount = 26420.00m, MaximumWage = 41100.00m, TaxRate = .0491m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 1309.20m, StartingAmount = 41100.00m, MaximumWage = 50990.00m, TaxRate = .0620m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 1922.38m, StartingAmount = 50990.00m, MaximumWage = 67620.00m, TaxRate = .0659m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 3018.30m, StartingAmount = 67620.00m, MaximumWage = Decimal.MaxValue, TaxRate = .0695m };

                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 0.00m, StartingAmount = 0, MaximumWage = 2975.00m, TaxRate = 0 };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 0.00m, StartingAmount = 2975.00m, MaximumWage = 5480.00m, TaxRate = .0226m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 56.61m, StartingAmount = 5480.00m, MaximumWage = 17790.00m, TaxRate = .0322m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 452.99m, StartingAmount = 17790.00m, MaximumWage = 25780.00m, TaxRate = .0491m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 845.30m, StartingAmount = 25780.00m, MaximumWage = 32730.00m, TaxRate = .0620m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 1276.20m, StartingAmount = 32730.00m, MaximumWage = 61470.00m, TaxRate = .0659m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 3170.17m, StartingAmount = 61470.00m, MaximumWage = Decimal.MaxValue, TaxRate = .0695m };

            }
        }
    }
}