using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.California
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }
        public override Decimal SUI_Wage_Base { get { return 44000; } }
        protected override decimal Deduction { get { return 1000; } }
        protected override decimal Exemption { get { return 122.10m; } }
        protected override IEnumerable<IncomeBracket> IncomeBrackets
        {
            get
            {
                yield return new IncomeBracket { FilingStatus = FilingStatus.Single, Amount = 13687 };
                yield return new IncomeBracket { FilingStatus = FilingStatus.HeadOfHousehold, Amount = 27373 };
            }
        }

        protected override IEnumerable<StandardDeduction> StandardDeductions
        {
            get
            {
                yield return new StandardDeduction { FilingStatus = FilingStatus.Single, Amount = 4129 };
                yield return new StandardDeduction { FilingStatus = FilingStatus.HeadOfHousehold, Amount = 8258 };
            }
        }

        protected override IEnumerable<TaxableWithholding> TaxableWithholdings
        {
            get
            {
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 0.00m, MaximumWage = 8015, TaxRate = 0.011m, TaxBase = 0.00m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 8015, MaximumWage = 19001, TaxRate = 0.022m, TaxBase = 88.17m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 19001, MaximumWage = 29989, TaxRate = 0.044m, TaxBase = 329.86m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 29989, MaximumWage = 41629, TaxRate = 0.066m, TaxBase = 813.33m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 41629, MaximumWage = 52612, TaxRate = 0.088m, TaxBase = 1581.57m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 52612, MaximumWage = 268750, TaxRate = 0.1023m, TaxBase = 2548.07m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 268750, MaximumWage = 322499, TaxRate = 0.1133m, TaxBase = 24658.99m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 322499, MaximumWage = 537498, TaxRate = 0.1243m, TaxBase = 30748.75m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 537498, MaximumWage = 1000000, TaxRate = 0.1353m, TaxBase = 57473.13m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 1000000, MaximumWage = decimal.MaxValue, TaxRate = 0.1463m, TaxBase = 120049.65m };

                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 0.00m, MaximumWage = 16030, TaxRate = 0.011m, TaxBase = 0.00m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 16030, MaximumWage = 38002, TaxRate = 0.022m, TaxBase = 176.33m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 38002, MaximumWage = 59978, TaxRate = 0.044m, TaxBase = 659.71m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 59978, MaximumWage = 83258, TaxRate = 0.066m, TaxBase = 1626.65m};
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 83258, MaximumWage = 105224, TaxRate = 0.088m, TaxBase = 3163.13m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 105224, MaximumWage = 537500, TaxRate = 0.1023m, TaxBase = 5096.14m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 537500, MaximumWage = 644998, TaxRate = 0.1133m, TaxBase = 49317.97m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 644998, MaximumWage = 1000000, TaxRate = 0.1243m, TaxBase = 61497.49m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 1000000, MaximumWage = 1074996, TaxRate = 0.1353m, TaxBase = 105624.24m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 1074966, MaximumWage = decimal.MaxValue, TaxRate = 0.1463m, TaxBase = 115771.20m };

                yield return new TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, StartingAmount = 0.00m, MaximumWage = 16040, TaxRate = 0.011m, TaxBase = 0.00m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, StartingAmount = 16040, MaximumWage = 38003, TaxRate = 0.022m, TaxBase = 176.44m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, StartingAmount = 38003, MaximumWage = 48990, TaxRate = 0.044m, TaxBase = 659.63m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, StartingAmount = 48990, MaximumWage = 60630, TaxRate = 0.066m, TaxBase = 1143.06m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, StartingAmount = 60630, MaximumWage =  71615, TaxRate = 0.088m, TaxBase = 1911.30m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, StartingAmount = 71615, MaximumWage = 365499, TaxRate = 0.1023m, TaxBase = 2877.98m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, StartingAmount = 365499, MaximumWage = 438599, TaxRate = 0.1133m, TaxBase = 32942.31m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, StartingAmount = 438599, MaximumWage =  730997, TaxRate = 0.1243m, TaxBase = 41224.54m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, StartingAmount = 730997, MaximumWage = 1000000, TaxRate = 0.1353m, TaxBase = 77569.61m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, StartingAmount = 1074966, MaximumWage = decimal.MaxValue, TaxRate = 0.1463m, TaxBase = 113965.72m };
            }
        }
    }
}