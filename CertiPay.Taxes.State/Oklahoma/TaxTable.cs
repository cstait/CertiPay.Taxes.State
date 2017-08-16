using CertiPay.Payroll.Common;
using System;

namespace CertiPay.Taxes.State.Oklahoma
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.OK; } }

        public Decimal AllowanceValue { get; } = 1000;

        public abstract Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, Boolean isMarried = false, int allowances = 0);
    }
}