using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.Alabama
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 8000; } }

        public override IEnumerable<DependentAllowance> DependentAllowances
        {
            get
            {
                yield return new DependentAllowance { Floor = 0.00m, Ceiling = 20000.00m, Amount = 1000.00m };
                yield return new DependentAllowance { Floor = 20000.00m, Ceiling = 100000.00m, Amount = 500.00m };
                yield return new DependentAllowance { Floor = 100000.00m, Ceiling = decimal.MaxValue, Amount = 300.00m };
            }
        }

        public override IEnumerable<TaxTable.StandardDeduction> StandardDeductions
        {
            get
            {
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Single, Floor = 0.00m, Ceiling = 20499.00m, Amount = 2500.00m};
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Single, Floor = 20499.00m, Ceiling = 30000.00m, Amount = 2500.00m, Increment = 25.00m, IncrementDivisor = 500.00m };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Single, Floor = 30000.00m, Ceiling = decimal.MaxValue, Amount = 2000.00m };

                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.MarriedFilingSeparate, Floor = 0.00m, Ceiling = 10249.00m, Amount = 3750.00m };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.MarriedFilingSeparate, Floor = 10249.00m, Ceiling = 15000.00m, Amount = 3750.00m, Increment = 88.00m, IncrementDivisor = 250.00m };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.MarriedFilingSeparate, Floor = 15000.00m, Ceiling = decimal.MaxValue, Amount = 2000.00m };

                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Married, Floor = 0.00m, Ceiling = 20499.00m, Amount = 7500.00m };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Married, Floor = 20499.00m, Ceiling = 30000.00m, Amount = 7500.00m, Increment = 175.00m, IncrementDivisor = 500.00m };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Married, Floor = 30000.00m, Ceiling = decimal.MaxValue, Amount = 4000.00m };

                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.HeadOfFamily, Floor = 0.00m, Ceiling = 20499.00m, Amount = 4700.00m };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.HeadOfFamily, Floor = 20499.00m, Ceiling = 30000.00m, Amount = 4700.00m, Increment = 135.00m, IncrementDivisor = 500.00m };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.HeadOfFamily, Floor = 30000.00m, Ceiling = decimal.MaxValue, Amount = 2000.00m };
            }
            
        }

        public override IEnumerable<TaxTable.StandardDeduction> PersonalAllowances
        {
            get
            {
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Single, Amount = 1500};
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.MarriedFilingSeparate, Amount = 1500 };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.HeadOfFamily, Amount = 3000 };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Married, Amount = 3000};

            }
        }
        

        public override IEnumerable<TaxableWithholding> TaxableWithholdings
        {
            get
            {
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, TaxAmount = 500, TaxRate = 0.02m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, TaxAmount = 2500, TaxRate = 0.04m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, TaxAmount = 3000, TaxRate = 0.05m };

                yield return new TaxableWithholding { FilingStatus = FilingStatus.HeadOfFamily, TaxAmount = 500, TaxRate = 0.02m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.HeadOfFamily, TaxAmount = 2500, TaxRate = 0.04m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.HeadOfFamily, TaxAmount = 3000, TaxRate = 0.05m };

                yield return new TaxableWithholding { FilingStatus = FilingStatus.MarriedFilingSeparate, TaxAmount = 500, TaxRate = 0.02m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.MarriedFilingSeparate, TaxAmount = 2500, TaxRate = 0.04m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.MarriedFilingSeparate, TaxAmount = 3000, TaxRate = 0.05m };

                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, TaxAmount = 1000, TaxRate = 0.02m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, TaxAmount = 5000, TaxRate = 0.04m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, TaxAmount = 6000, TaxRate = 0.05m };

            }
        }
    }
}