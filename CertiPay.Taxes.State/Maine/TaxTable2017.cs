using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.Maine
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 12000; } }

        public override Decimal WithholdingAllowance { get { return 4050.00m; } }

        public override IEnumerable<StandardDeduction> StandardDeductions
        {
            get
            {
                yield return new StandardDeduction { FilingStatus = FilingStatus.Single, FloorAmount = 0.00m, CeilingAmount = 70000.00m, CalcValue = 0.00m, Amount = 8750.00m };
                yield return new StandardDeduction { FilingStatus = FilingStatus.Single, FloorAmount = 700000.00m, CeilingAmount = 145000.00m, CalcValue = 75000.00m, Amount = 8750.00m };
                yield return new StandardDeduction { FilingStatus = FilingStatus.Single, FloorAmount = 145000.00m, CeilingAmount = decimal.MaxValue, CalcValue = 0.00m, Amount = 0.00m };

                yield return new StandardDeduction { FilingStatus = FilingStatus.Married, FloorAmount = 0.00m, CeilingAmount = 140000.00m, CalcValue = 0.00m, Amount = 20350.00m };
                yield return new StandardDeduction { FilingStatus = FilingStatus.Married, FloorAmount = 140000.00m, CeilingAmount = 290000.00m, CalcValue = 150000.00m, Amount = 20350.00m };
                yield return new StandardDeduction { FilingStatus = FilingStatus.Married, FloorAmount = 290000.00m, CeilingAmount = decimal.MaxValue, CalcValue = 0.00m, Amount = 0.00m };
            }
        }

        public override IEnumerable<TaxableWithholding> TaxableWithholdings
        {
            get
            {
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 0.00m, MaximumWage = 21100.00m, TaxBase = 0.00m, TaxRate = 0.0580m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 21100.00m, MaximumWage = 50000.00m, TaxBase = 1224.00m, TaxRate = 0.0675m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 50000.00m, MaximumWage = 200001.00m, TaxBase = 3175.00m, TaxRate = 0.0715m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, StartingAmount = 200001.00m, MaximumWage = decimal.MaxValue, TaxBase = 13900.00m, TaxRate = 0.01015m };

                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 0.00m, MaximumWage = 42250.00m, TaxBase = 0.00m, TaxRate = 0.058m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 42250.00m, MaximumWage = 100000.00m, TaxBase = 2451.00m, TaxRate = 0.0675m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 100000.00m, MaximumWage = 200001.00m, TaxBase = 6349.00m, TaxRate = 0.0715m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, StartingAmount = 200001.00m, MaximumWage = decimal.MaxValue, TaxBase = 13499.00m, TaxRate = 0.1015m };
            }
        }
    }
}