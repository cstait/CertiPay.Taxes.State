using CertiPay.Payroll.Common;
using System;

namespace CertiPay.Taxes.State.Oklahoma
{
    public class TaxTable2016 : TaxTable
    {
        public override int Year { get; internal set; } = 2016;

        public override decimal SUI_Wage_Base { get; internal set; } = 17500;

        public override Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, Boolean isMarried = false, int allowances = 0)
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
                if (taxable_earnings < 12600)
                {
                    flat_amount = 0;
                    bracket_floor = 0;
                    percentage = 0;
                }
                else if (taxable_earnings < 14600)
                {
                    flat_amount = 0;
                    bracket_floor = 12600;
                    percentage = 0.005m;
                }
                else if (taxable_earnings < 17600)
                {
                    flat_amount = 10;
                    bracket_floor = 14600;
                    percentage = 0.01m;
                }
                else if (taxable_earnings < 20100)
                {
                    flat_amount = 40;
                    bracket_floor = 17600;
                    percentage = 0.02m;
                }
                else if (taxable_earnings < 22400)
                {
                    flat_amount = 90;
                    bracket_floor = 20100;
                    percentage = 0.03m;
                }
                else if (taxable_earnings < 24800)
                {
                    flat_amount = 159;
                    bracket_floor = 22400;
                    percentage = 0.04m;
                }
                else
                {
                    flat_amount = 255;
                    bracket_floor = 24800;
                    percentage = 0.05m;
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