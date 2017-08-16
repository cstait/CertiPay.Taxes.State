using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.Virginia
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 8000; } }
    }
}