﻿using CertiPay.Payroll.Common;
using System;

namespace CertiPay.Taxes.State.Oklahoma
{
    public class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.OK; } }

        public override Decimal SUI_Wage_Base
        {
            get
            {
                switch (Year)
                {
                    case 2016:
                        return 17500;

                    case 2017:
                        return 17700;
                }

                throw new NotImplementedException($"SUI Wage Base is not configured for Oklahoma for {Year}");
            }
        }

        public Decimal AllowanceValue { get; } = 1000;

        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, Boolean isMarried = false, int allowances = 0)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");
            if (allowances < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(allowances)} cannot be a negative number");

            Decimal annualized_wages = frequency.CalculateAnnualized(grossWages);

            // Multiple WH allowance amount for the payroll frequency by total number of allowances
            // SUbtract this amount from the individual's gross payment for the period

            Decimal taxable_earnings = annualized_wages - (AllowanceValue * allowances);

            // Use the appropriate rate to figure the amount to be withheld

            Decimal flat_amount = 0, bracket_floor = 0, percentage = 0m;

            if (isMarried)
            {
                if (taxable_earnings < 7000)
                {
                    flat_amount = 0;
                    bracket_floor = 0;
                    percentage = 0.018m;
                }
                else if (taxable_earnings < 15000)
                {
                    flat_amount = 126;
                    bracket_floor = 7000;
                    percentage = 0.044m;
                }
                else if (taxable_earnings < 120000)
                {
                    flat_amount = 478;
                    bracket_floor = 15000;
                    percentage = 0.06m;
                }
                else
                {
                    flat_amount = 6778;
                    bracket_floor = 120000;
                    percentage = 0.066m;
                }
            }
            else
            {
                if (taxable_earnings < 6300)
                {
                    flat_amount = 0;
                    bracket_floor = 0;
                    percentage = 0;
                }
                else if (taxable_earnings < 7300)
                {
                    flat_amount = 0;
                    bracket_floor = 6300;
                    percentage = 0.005m;
                }
                else if (taxable_earnings < 8800)
                {
                    flat_amount = 5;
                    bracket_floor = 7300;
                    percentage = 0.01m;
                }
                else if (taxable_earnings < 10050)
                {
                    flat_amount = 20;
                    bracket_floor = 8800;
                    percentage = 0.02m;
                }
                else if (taxable_earnings < 11200)
                {
                    flat_amount = 45;
                    bracket_floor = 10050;
                    percentage = 0.03m;
                }
                else if (taxable_earnings < 13500)
                {
                    flat_amount = 171.50m;
                    bracket_floor = 11200;
                    percentage = 0.04m;
                }
                else
                {
                    flat_amount = 171.50m;
                    bracket_floor = 13500;
                    percentage = 0.05m;
                }
            }

            Decimal annual_withholding = flat_amount + (percentage * (taxable_earnings - bracket_floor));

            // Round ALL to the nearest dollar

            return frequency.CalculateDeannualized(annual_withholding).Round(decimals: 0);
        }
    }
}