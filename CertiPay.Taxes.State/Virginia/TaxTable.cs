﻿using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CertiPay.Taxes.State.Virginia
{
    public class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.VA; } }

        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, int exemptions = 0)
        {
            var annualized_wages = frequency.CalculateAnnualized(grossWages);

            // G(P) - [$3,000 + (E1 x $930) + (E2 x $800)] = T

            // Gross Pay for Period * Number of pay periods per year - (3000 + Personal+Dependent Exemptions x 930 + Age 65 and Over & Blind Exemptions x $800)

            annualized_wages -= 3000; // Standard Deduction

            annualized_wages -= (exemptions * 930); // Personal + Dependent Exemptions

            var annualized_taxes = 0;

            if(annualized_wages < 3000)
            {
                annualized_taxes = annualized_wages * 0.02m;
            }
            else if(annualized_wages < 5000)
            {
                annualized_taxes = 60 + (annualized_wages - 3000) * 0.03m;
            }
            else if(annualized_wages < 17000)
            {
                annualized_taxes = 120 + (annualized_wages - 5000) * 0.05m;
            }
            else
            {
                annualized_taxes = 720 + (annualized_wages - 17000) * 0.0575m;
            }

            return frequency.CalculateDeannualized(annualized_taxes);
        }
    }
}