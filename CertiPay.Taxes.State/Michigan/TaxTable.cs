﻿using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CertiPay.Taxes.State.Michigan
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get; internal set; } = StateOrProvince.MI;

        public virtual Decimal Exemption { get; }

        public virtual Decimal Tax { get; }

        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, int personalExemptions = 0, int dependents = 0)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");
            if (personalExemptions < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(personalExemptions)} cannot be a negative number");

            var taxableWages = frequency.CalculateAnnualized(grossWages);

            taxableWages -= GetDeductions(personalExemptions + dependents);

            var taxWithheld = taxableWages * Tax;

            return frequency.CalculateDeannualized(Math.Max(0, taxWithheld));
        }

        protected virtual Decimal GetDeductions(int exemptions)
        {
            return exemptions * Exemption;
        }


    }
}