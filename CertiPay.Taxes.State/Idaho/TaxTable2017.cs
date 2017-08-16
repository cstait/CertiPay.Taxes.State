using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.Idaho
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 37800; } }

        public override Decimal AnnualAllowance { get { return 4050; } }

        public override IEnumerable<TaxableWithholding> TaxableWithholdings
        {
            get
            {
                // Percentage method for computing tax on wages subject to withholding

                // Single Individual

                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 0.00m, StartingAmount = 1m, MaximumWage = 2250, TaxRate = .016m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 0.00m, StartingAmount = 2250, MaximumWage = 3704, TaxRate = .016m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 23.00m, StartingAmount = 3704, MaximumWage = 5158, TaxRate = .036m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 75.00m, StartingAmount = 5158, MaximumWage = 6612, TaxRate = .041m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 135.00m, StartingAmount = 6612, MaximumWage = 8066, TaxRate = .051m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 209.00m, StartingAmount = 8066, MaximumWage = 9520, TaxRate = .061m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 298.00m, StartingAmount = 9520, MaximumWage = 13155, TaxRate = .071m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 556.00m, StartingAmount = 13155, MaximumWage = Decimal.MaxValue, TaxRate = .074m };

                // Married Filing Joint Return (with one spouse having income) OR Head of Household

                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 0.00m, StartingAmount = 1, MaximumWage = 2250, TaxRate = .016m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 0.00m, StartingAmount = 2250, MaximumWage = 3704, TaxRate = .016m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 23.00m, StartingAmount = 3704, MaximumWage = 5158, TaxRate = .036m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 75.00m, StartingAmount = 5158, MaximumWage = 6612, TaxRate = .041m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 135.00m, StartingAmount = 6612, MaximumWage = 8066, TaxRate = .051m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 209.00m, StartingAmount = 8066, MaximumWage = 9520, TaxRate = .061m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 298.00m, StartingAmount = 9520, MaximumWage = 13155, TaxRate = .071m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.HeadOfHousehold, TaxBase = 556.00m, StartingAmount = 13155, MaximumWage = Decimal.MaxValue, TaxRate = .074m };

                //Married Filing Joint Return (with one spouse having income)

                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 0.00m, StartingAmount = 1, MaximumWage = 8550, TaxRate = .016m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 0.00m, StartingAmount = 8550, MaximumWage = 11458, TaxRate = .016m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 47.00m, StartingAmount = 11458, MaximumWage = 14366, TaxRate = .036m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 152.00m, StartingAmount = 14366, MaximumWage = 17274, TaxRate = .041m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 271.00m, StartingAmount = 17274, MaximumWage = 20182, TaxRate = .051m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 419.00m, StartingAmount = 20182, MaximumWage = 23090, TaxRate = .061m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 596.00m, StartingAmount = 23090, MaximumWage = 30360, TaxRate = .071m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Married, TaxBase = 1112.00m, StartingAmount = 30360, MaximumWage = Decimal.MaxValue, TaxRate = .074m };
            }
        }
    }
}