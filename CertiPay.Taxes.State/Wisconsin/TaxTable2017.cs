using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.Wisconsin
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 14000; } }

        protected override IEnumerable<TaxTable.StandardDeduction> StandardDeductions
        {
            get
            {
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Single, StartingAmount = 0.00m, MaximumWage = 15200.00m, Amount = 5730.00m};
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Single, StartingAmount = 15200.00m, MaximumWage = 62950.00m, Amount = 5730.00m, Percentage = 0.12m };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Single, StartingAmount = 62950.00m, MaximumWage = decimal.MaxValue, Amount = 0.00m};

                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Married, StartingAmount = 0.00m, MaximumWage = 21400.00m, Amount = 7870.00m };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Married, StartingAmount = 21400.00m, MaximumWage = 60750.00m, Amount = 7870.00m, Percentage = 0.20m };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Married, StartingAmount = 60750.00m, MaximumWage = decimal.MaxValue, Amount = 0.00m };
            }
        }

        protected override decimal PersonalAllowances
        {
            get
            {
                return 400;
            }
        }

        protected override IEnumerable<TaxableWithholding> TaxableWithholdings
        {
            get
            {
                yield return new TaxableWithholding { StartingAmount = 0.00m, MaximumWage = 10910.00m, TaxBase = 0.00m, TaxRate = .04m };
                yield return new TaxableWithholding { StartingAmount = 10910.00m, MaximumWage = 21820.00m, TaxBase = 436.40m, TaxRate = .0584m };
                yield return new TaxableWithholding { StartingAmount = 21820.00m, MaximumWage = 240190.00m, TaxBase = 1073.54m, TaxRate = .0627m };
                yield return new TaxableWithholding { StartingAmount = 240190.00m, MaximumWage = decimal.MaxValue, TaxBase = 14765.34m, TaxRate = .0765m };
            }
        }

    }
}
