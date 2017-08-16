using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.NorthDakota
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 35100; } }

        protected override decimal PersonalAllowances { get { return 4050; } }

        protected override IEnumerable<TaxableWithholding> TaxableWithholdings
        {
            get
            {
                // Percentage method for computing tax on wages subject to withholding

                // Single Individual

                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 0.00m, StartingAmount = 0, MaximumWage = 10000.00m, TaxRate = 0 };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 0.00m, StartingAmount = 10000.00m, MaximumWage = 72000.00m, TaxRate = .0110m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 682.0m, StartingAmount = 72000.00m, MaximumWage = 136000.00m, TaxRate = .0204m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 1987.60m, StartingAmount = 136000.00m, MaximumWage = 242000.00m, TaxRate = .0227m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 4393.80m, StartingAmount = 242000.00m, MaximumWage = 423000.00m, TaxRate = .0264m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 9172.20m, StartingAmount = 423000.00m, MaximumWage = Decimal.MaxValue, TaxRate = .0290m };

                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 0.00m, StartingAmount = 0, MaximumWage = 4300.00m, TaxRate = 0 };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 0.00m, StartingAmount = 4300.00m, MaximumWage = 41000.00m, TaxRate = .0110m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 403.70m, StartingAmount = 41000.00m, MaximumWage = 84000.00m, TaxRate = .0204m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 1280.90m, StartingAmount = 84000.00m, MaximumWage = 194000.00m, TaxRate = .0227m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 3777.90m, StartingAmount = 194000.00m, MaximumWage = 416000.00m, TaxRate = .0264m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 9638.70m, StartingAmount = 416000.00m, MaximumWage = Decimal.MaxValue, TaxRate = .0290m };

            }
        }
    }
}