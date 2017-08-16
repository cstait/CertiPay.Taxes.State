using System;

namespace CertiPay.Taxes.State.Indiana
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 9500; } }

        public override Decimal DependentAllowances { get; } = 1500;

        public override Decimal PersonalAllowances { get; } = 1000;

        public override Decimal StateTaxRate { get; } = 0.0323m;
    }
}