using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.Vermont
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get; internal set; } = 2017;

        public override decimal SUI_Wage_Base { get; internal set; } = 17300;

        public override decimal AllowanceValue { get {return 4050.00m;}}

        public override IEnumerable<TaxableWithholding> TaxableWithholdings
        {
            get
            {
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 0, MaximumWage = 2650.00m, TaxBase = 0, TaxRate = 0};
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 2650, MaximumWage = 40250.00m, TaxBase = 0, TaxRate = 0.0355m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 40250, MaximumWage = 94200.00m, TaxBase = 1334.80m, TaxRate = 0.0680m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 94200, MaximumWage = 193950.00m, TaxBase = 5003.40m, TaxRate = 0.0780m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 193950, MaximumWage = 419000.00m, TaxBase = 12783.90m, TaxRate = 0.0880m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 419000, MaximumWage = decimal.MaxValue, TaxBase = 32588.30m, TaxRate = 0.0895m };

                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 0, MaximumWage = 8000.00m, TaxBase = 0, TaxRate = 0 };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 8000, MaximumWage = 70500.00m, TaxBase = 0, TaxRate = 0.0355m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 70500, MaximumWage = 161750.00m, TaxBase = 2218.75m, TaxRate = 0.0680m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 161750, MaximumWage = 242000.00m, TaxBase = 8423.75m, TaxRate = 0.0780m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 242000, MaximumWage = 425350.00m, TaxBase = 14683.25m, TaxRate = 0.0880m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 425350, MaximumWage = decimal.MaxValue, TaxBase = 30818.05m, TaxRate = 0.0895m };
            }
        }
    }
}