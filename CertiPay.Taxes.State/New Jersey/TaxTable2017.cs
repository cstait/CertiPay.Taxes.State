using System;
using System.Collections.Generic;
namespace CertiPay.Taxes.State.NewJersey
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 33500; } }

        public override decimal PersonalAllowances
        {
            get {
                return 1000m;
            }                                       
        }

        public override IEnumerable<TaxableWithholding> TaxableWithholdings
        {
            get
            {
                // Single, Rate A
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 20000m, TaxRate = .015m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 300m, StartingAmount = 20000.00m, MaximumWage = 35000.00m, TaxRate = .02m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 600m, StartingAmount = 35000.00m, MaximumWage = 40000.00m, TaxRate = .039m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 795m, StartingAmount = 40000.00m, MaximumWage = 75000.00m, TaxRate = .061m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 2930m, StartingAmount = 75000.00m, MaximumWage = Decimal.MaxValue, TaxRate = .07m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 32680m, StartingAmount = 500000.00m, MaximumWage = Decimal.MaxValue, TaxRate = .099m };

                // Married Filing Separate Return, Rate A

                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedFilingSeparate, TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 20000m, TaxRate = .015m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedFilingSeparate, TaxBase = 300m, StartingAmount = 20000.00m, MaximumWage = 35000.00m, TaxRate = .02m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedFilingSeparate, TaxBase = 600m, StartingAmount = 35000.00m, MaximumWage = 40000.00m, TaxRate = .039m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedFilingSeparate, TaxBase = 795m, StartingAmount = 40000.00m, MaximumWage = 75000.00m, TaxRate = .061m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedFilingSeparate, TaxBase = 2930m, StartingAmount = 75000.00m, MaximumWage = Decimal.MaxValue, TaxRate = .07m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedFilingSeparate, TaxBase = 32680m, StartingAmount = 500000.00m, MaximumWage = Decimal.MaxValue, TaxRate = .099m };

                // Head of Household, Rate B

                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 20000.00m, TaxRate = .015m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 300.00m, StartingAmount = 20000.00m, MaximumWage = 50000.00m, TaxRate = .02m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 900.00m, StartingAmount = 50000.00m, MaximumWage = 70000.00m, TaxRate = .027m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 1440.00m, StartingAmount = 70000.00m, MaximumWage = 80000.00m, TaxRate = .039m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 1830.00m, StartingAmount = 80000.00m, MaximumWage = 150000.00m, TaxRate = .061m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 6100.00m, StartingAmount = 150000.00m, MaximumWage = Decimal.MaxValue, TaxRate = .070m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 30600.00m, StartingAmount = 500000.00m, MaximumWage = Decimal.MaxValue, TaxRate = .099m };

                //Married Filing Joint Return (with one spouse having income), Rate B

                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithOneIncome, TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 20000.00m, TaxRate = .015m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithOneIncome, TaxBase = 300.00m, StartingAmount = 20000.00m, MaximumWage = 50000.00m, TaxRate = .02m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithOneIncome, TaxBase = 900.00m, StartingAmount = 50000.00m, MaximumWage = 70000.00m, TaxRate = .027m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithOneIncome, TaxBase = 1440.00m, StartingAmount = 70000.00m, MaximumWage = 80000.00m, TaxRate = .039m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithOneIncome, TaxBase = 1830.00m, StartingAmount = 80000.00m, MaximumWage = 150000.00m, TaxRate = .061m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithOneIncome, TaxBase = 6100.00m, StartingAmount = 150000.00m, MaximumWage = Decimal.MaxValue, TaxRate = .070m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithOneIncome, TaxBase = 30600.00m, StartingAmount = 500000.00m, MaximumWage = Decimal.MaxValue, TaxRate = .099m };

                //Married Filing Joint Return (with both spouse having income), Rate B
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithTwoIncomes, TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 20000.00m, TaxRate = .015m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithTwoIncomes, TaxBase = 300.00m, StartingAmount = 20000.00m, MaximumWage = 50000.00m, TaxRate = .02m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithTwoIncomes, TaxBase = 900.00m, StartingAmount = 50000.00m, MaximumWage = 70000.00m, TaxRate = .027m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithTwoIncomes, TaxBase = 1440.00m, StartingAmount = 70000.00m, MaximumWage = 80000.00m, TaxRate = .039m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithTwoIncomes, TaxBase = 1830.00m, StartingAmount = 80000.00m, MaximumWage = 150000.00m, TaxRate = .061m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithTwoIncomes, TaxBase = 6100.00m, StartingAmount = 150000.00m, MaximumWage = Decimal.MaxValue, TaxRate = .070m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithTwoIncomes, TaxBase = 30600.00m, StartingAmount = 500000.00m, MaximumWage = Decimal.MaxValue, TaxRate = .099m };
            }
        }
    }
}