using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.Michigan
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 9500; } }

        public override decimal Exemption { get { return 4000; } }

        public override decimal Tax { get { return 0.0425m; } }
    }
}