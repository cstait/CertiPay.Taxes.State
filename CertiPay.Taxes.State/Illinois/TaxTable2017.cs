using System;

namespace CertiPay.Taxes.State.Illinois
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 12960; } }
    }
}