using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.Minnesota
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 32000; } }

        public override decimal Allowance { get { return 4050; } }

        public override IEnumerable<TaxableWithholding> TaxableWithholdings
        {
            get
            {
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 0.00m, MaximumWage = 2300.00m, TaxRate = 0.00m, TaxBase = 0.00m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 2300.00m, MaximumWage = 27690.00m, TaxRate = 0.0535m, TaxBase = 0.00m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 27690.00m, MaximumWage = 85700.00m, TaxRate = 0.0705m, TaxBase = 1358.37m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 85700.00m, MaximumWage = 159210.00m, TaxRate = 0.0785m, TaxBase = 5448.08m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 159210.00m, MaximumWage = decimal.MaxValue, TaxRate = 0.0985m, TaxBase = 11218.62m };

                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 0.00m, MaximumWage = 8650.00m, TaxRate = 0.00m, TaxBase = 0.00m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 8650.00m, MaximumWage = 45760.00m, TaxRate = 0.0535m, TaxBase = 0.00m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 45760.00m, MaximumWage = 156100.00m, TaxRate = 0.0705m, TaxBase = 1985.39m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 156100.00m, MaximumWage = 270160.00m, TaxRate = 0.0785m, TaxBase = 9764.36m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 270160.00m, MaximumWage = decimal.MaxValue, TaxRate = 0.0985m, TaxBase = 18718.07m };
            }
        }


    }
}