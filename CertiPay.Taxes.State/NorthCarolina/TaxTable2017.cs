using System;

namespace CertiPay.Taxes.State.NorthCarolina
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 23100; } }

        public override Decimal AllowanceValue { get { return 2500; } }

        public override Decimal TaxRate { get { return 0.05599m; } }

        public override Decimal StandardDeduction(FilingStatus taxStatus)
        {
            switch (taxStatus)
            {
                case FilingStatus.HeadOfHousehold:
                    return 14000;

                default:
                    return 8750;
            }
        }
    }
}