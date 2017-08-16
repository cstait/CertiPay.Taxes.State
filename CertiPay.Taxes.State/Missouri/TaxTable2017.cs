using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.Missouri
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }
        public override Decimal SUI_Wage_Base { get { return 13000; } }
        protected override Decimal TaxRate { get { return 0.015m; } }
        protected override Decimal TaxAmount { get { return 1008; } }
        protected override Decimal TaxIncrement { get { return 0.005m; } }

        protected override IEnumerable<StandardDeduction> FederalWithholdings
        {
            get
            {
                yield return new StandardDeduction { FilingStatus = FilingStatus.Single, Amount = 5000 };
                yield return new StandardDeduction { FilingStatus = FilingStatus.MarriedWithTwoIncomes, Amount = 5000 };
                yield return new StandardDeduction { FilingStatus = FilingStatus.HeadOfHousehold, Amount = 5000 };
                yield return new StandardDeduction { FilingStatus = FilingStatus.MarriedWithOneIncome, Amount = 10000 };
            }
        }

        protected override IEnumerable<TaxTable.StandardDeduction> StandardDeductions
        {
            get
            {
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Single, Amount = 6350 };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.MarriedWithOneIncome, Amount = 12700 };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.MarriedWithTwoIncomes, Amount = 6350 };
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.HeadOfHousehold, Amount = 9350 };
            }
        }

        protected override IEnumerable<TaxTable.Allowance> PersonalAllowances
        {
            get
            {
                yield return new Allowance { FilingStatus = FilingStatus.Single, Amount = 2100, AdditionalAmount = 1200 };
                yield return new Allowance { FilingStatus = FilingStatus.MarriedWithTwoIncomes, Amount = 2100, AdditionalAmount = 1200 };
                yield return new Allowance { FilingStatus = FilingStatus.MarriedWithOneIncome, Amount = 2100, AdditionalAmount = 1200 };
                yield return new Allowance { FilingStatus = FilingStatus.HeadOfHousehold, Amount = 3500, AdditionalAmount = 1200 };
            }
        }
    }
}    
