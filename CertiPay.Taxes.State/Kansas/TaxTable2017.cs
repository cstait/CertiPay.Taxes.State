using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.Kansas
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 14000; } }

        protected override decimal PersonalAllowance { get { return 2250; } }

        protected override IEnumerable<TaxableWithholding> TaxableWithholdings
        {
            get
            {
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedOrHoH, TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 6000.00m, TaxRate = 0.00m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedOrHoH, TaxBase = 0.00m, StartingAmount = 6000.00m, MaximumWage = 36000.00m, TaxRate = .027m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.MarriedOrHoH, TaxBase = 37.50m, StartingAmount = 36000.00m, MaximumWage = decimal.MaxValue, TaxRate = .046m };

                //Married or HoH

                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 3000.00m, TaxRate = 0.00m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 0.00m, StartingAmount = 3000.00m, MaximumWage = 18000.00m, TaxRate = .027m };
                yield return new TaxTable.TaxableWithholding { FilingStatus = FilingStatus.Single, TaxBase = 405.00m, StartingAmount = 18000.00m, MaximumWage = Decimal.MaxValue, TaxRate = .046m };
            }
        }
    }
}