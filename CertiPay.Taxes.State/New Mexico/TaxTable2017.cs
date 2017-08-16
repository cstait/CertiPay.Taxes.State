using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.NewMexico
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 24300; } }

        protected override decimal PersonalAllowances { get { return 4050; } }
                
        protected override IEnumerable<TaxableWithholding> TaxableWithholdings
        {
            get
            {
                // Percentage method for computing tax on wages subject to withholding

                // Single Individual

                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 0.00m, StartingAmount = 0, MaximumWage = 8650.00m, TaxRate = 0 };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 0.00m, StartingAmount = 8650.00m, MaximumWage = 16650.00m, TaxRate = .017m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 136.0m, StartingAmount = 16650.00m, MaximumWage = 24650.00m, TaxRate = .032m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 392.00m, StartingAmount = 24650.00m, MaximumWage = 32650.00m, TaxRate = .047m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 768.000m, StartingAmount = 32650.00m, MaximumWage = 48650.00m, TaxRate = .049m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 1552.00m, StartingAmount = 48650.00m, MaximumWage = 72650.00m, TaxRate = .049m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 2728.00m, StartingAmount = 72650.00m, MaximumWage = 108650.00m, TaxRate = .049m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 4492.00m, StartingAmount = 108650.00m, MaximumWage = Decimal.MaxValue, TaxRate = .049m };

                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 0.00m, StartingAmount = 0, MaximumWage = 2300.00m, TaxRate = 0 };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 0.00m, StartingAmount = 2300.00m, MaximumWage = 7800.00m, TaxRate = .017m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 93.50m, StartingAmount = 7800.00m, MaximumWage = 13300.00m, TaxRate = .032m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 269.50m, StartingAmount = 13300.00m, MaximumWage = 18300.00m, TaxRate = .047m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 504.50m, StartingAmount = 18300.00m, MaximumWage = 28300.00m, TaxRate = .049m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 994.50m, StartingAmount = 28300.00m, MaximumWage = 44300.00m, TaxRate = .049m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 1778.50m, StartingAmount = 44300.00m, MaximumWage = 67300.00m, TaxRate = .049m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 2905.50m, StartingAmount = 67300.00m, MaximumWage = Decimal.MaxValue, TaxRate = .049m };

            }
        }
    }
}