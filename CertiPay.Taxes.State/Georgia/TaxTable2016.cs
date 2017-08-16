using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.Georgia
{
    public class TaxTable2016 : TaxTable
    {
        public override int Year { get { return 2016; } }

        public override Decimal SUI_Wage_Base { get { return 9500; } }

        public override IEnumerable<TaxTable.StandardDeduction> StandardDeductions
        {
            get
            {
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.MarriedWithOneIncome, Amount = 3000 };

                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Single, Amount = 2300 };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.HeadOfHousehold, Amount = 2300 };

                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.MarriedWithTwoIncomes, Amount = 1500 };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.MarriedFilingSeparate, Amount = 1500 };
            }
        }

        public override IEnumerable<TaxTable.StandardDeduction> PersonalAllowances
        {
            get
            {
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Single, Amount = 2700 };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.HeadOfHousehold, Amount = 2700 };

                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.MarriedWithOneIncome, Amount = 3700 };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.MarriedWithTwoIncomes, Amount = 3700 };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.MarriedFilingSeparate, Amount = 3700 };
            }
        }

        public override Decimal DependentAllowances { get; } = 3000;

        public override IEnumerable<TaxableWithholding> TaxableWithholdings
        {
            get
            {
                // Percentage method for computing tax on wages subject to withholding

                // Single Individual

                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 750.00m, TaxRate = .01m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 7.50m, StartingAmount = 750.00m, MaximumWage = 2250.00m, TaxRate = .02m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 37.50m, StartingAmount = 2250.00m, MaximumWage = 3750.00m, TaxRate = .03m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 82.50m, StartingAmount = 3750.00m, MaximumWage = 5250.00m, TaxRate = .04m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 142.50m, StartingAmount = 5250.00m, MaximumWage = 7000.00m, TaxRate = .05m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 230.00m, StartingAmount = 7000.00m, MaximumWage = Decimal.MaxValue, TaxRate = .06m };

                // Married Filing Joint Return (with one spouse having income) OR Head of Household

                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 1000.00m, TaxRate = .01m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 10.00m, StartingAmount = 1000.00m, MaximumWage = 3000.00m, TaxRate = .02m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 50.00m, StartingAmount = 3000.00m, MaximumWage = 5000.00m, TaxRate = .03m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 110.00m, StartingAmount = 5000.00m, MaximumWage = 7000.00m, TaxRate = .04m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 190.00m, StartingAmount = 7000.00m, MaximumWage = 10000.00m, TaxRate = .05m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 340.00m, StartingAmount = 10000.00m, MaximumWage = Decimal.MaxValue, TaxRate = .06m };

                //Married Filing Joint Return (with one spouse having income)

                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithOneIncome, TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 1000.00m, TaxRate = .01m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithOneIncome, TaxBase = 10.00m, StartingAmount = 1000.00m, MaximumWage = 3000.00m, TaxRate = .02m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithOneIncome, TaxBase = 50.00m, StartingAmount = 3000.00m, MaximumWage = 5000.00m, TaxRate = .03m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithOneIncome, TaxBase = 110.00m, StartingAmount = 5000.00m, MaximumWage = 7000.00m, TaxRate = .04m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithOneIncome, TaxBase = 190.00m, StartingAmount = 7000.00m, MaximumWage = 10000.00m, TaxRate = .05m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithOneIncome, TaxBase = 340.00m, StartingAmount = 10000.00m, MaximumWage = Decimal.MaxValue, TaxRate = .06m };

                // Married Filing Joint Return (both spouses having income) OR Married Filing Separate Return

                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedFilingSeparate, TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 500.00m, TaxRate = .01m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedFilingSeparate, TaxBase = 5.00m, StartingAmount = 500.00m, MaximumWage = 1500.00m, TaxRate = .02m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedFilingSeparate, TaxBase = 25.00m, StartingAmount = 1500.00m, MaximumWage = 2500.00m, TaxRate = .03m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedFilingSeparate, TaxBase = 55.00m, StartingAmount = 2500.00m, MaximumWage = 3500.00m, TaxRate = .04m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedFilingSeparate, TaxBase = 95.00m, StartingAmount = 3500.00m, MaximumWage = 5000.00m, TaxRate = .05m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedFilingSeparate, TaxBase = 170.00m, StartingAmount = 5000.00m, MaximumWage = Decimal.MaxValue, TaxRate = .06m };

                //Married Filing Joint Return (with both spouse having income)

                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithTwoIncomes, TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 500.00m, TaxRate = .01m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithTwoIncomes, TaxBase = 5.00m, StartingAmount = 500.00m, MaximumWage = 1500.00m, TaxRate = .02m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithTwoIncomes, TaxBase = 25.00m, StartingAmount = 1500.00m, MaximumWage = 2500.00m, TaxRate = .03m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithTwoIncomes, TaxBase = 55.00m, StartingAmount = 2500.00m, MaximumWage = 3500.00m, TaxRate = .04m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithTwoIncomes, TaxBase = 95.00m, StartingAmount = 3500.00m, MaximumWage = 5000.00m, TaxRate = .05m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedWithTwoIncomes, TaxBase = 170.00m, StartingAmount = 5000.00m, MaximumWage = Decimal.MaxValue, TaxRate = .06m };
            }
        }
    }
}