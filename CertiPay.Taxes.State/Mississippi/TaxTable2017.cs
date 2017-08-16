using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.Mississippi
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 14000; } }

        protected override IEnumerable<StandardDeduction> StandardDeductions
        {
            get
            {
                yield return new StandardDeduction { FilingStatus = FilingStatus.Single, Amount = 2300.00m };
                yield return new StandardDeduction { FilingStatus = FilingStatus.HeadOfFamily, Amount = 3400.00m };
                yield return new StandardDeduction { FilingStatus = FilingStatus.Married, Amount = 4600.00m };
            }
        }

        protected override IEnumerable<Bracket> Brackets
        {
            get
            {
                yield return new Bracket { Amount = 5000, Percentage = 0.03m };
                yield return new Bracket { Amount = 5000, Percentage = 0.04m };
                yield return new Bracket { Amount = 10000, Percentage = 0.05m };
            }
        }
    }
}