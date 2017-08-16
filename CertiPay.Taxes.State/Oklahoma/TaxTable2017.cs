using CertiPay.Payroll.Common;
using System;

namespace CertiPay.Taxes.State.Oklahoma
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get; internal set; } = 2017;

        public override decimal SUI_Wage_Base { get; internal set; } = 17700;


        /// <summary>
        /// Returns Oklahoma State Withholding when given a non-negative value for Gross Wages and Allowances.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="isMarried"></param>
        /// <param name="allowances"></param>
        /// <returns></returns>
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

            if (taxable_earnings <= 0)
                return 0;

            if (isMarried)
            {
                if (taxable_earnings < 12700)
                {
                    flat_amount = 0;
                    bracket_floor = 0;
                    percentage = 0;
                }
                else if (taxable_earnings < 14700)
                {
                    flat_amount = 0;
                    bracket_floor = 12700;
                    percentage = 0.005m;
                }
                else if (taxable_earnings < 17700)
                {
                    flat_amount = 10;
                    bracket_floor = 14700;
                    percentage = 0.01m;
                }
                else if (taxable_earnings < 20200)
                {
                    flat_amount = 40;
                    bracket_floor = 17700;
                    percentage = 0.02m;
                }
                else if (taxable_earnings < 22500)
                {
                    flat_amount = 90;
                    bracket_floor = 20200;
                    percentage = 0.03m;
                }
                else if (taxable_earnings < 24900)
                {
                    flat_amount = 159;
                    bracket_floor = 22500;
                    percentage = 0.04m;
                }
                else
                {
                    flat_amount = 255;
                    bracket_floor = 24900;
                    percentage = 0.05m;
                }
            }
            else
            {
                if (taxable_earnings < 6350)
                {
                    flat_amount = 0;
                    bracket_floor = 0;
                    percentage = 0;
                }
                else if (taxable_earnings < 7350)
                {
                    flat_amount = 0;
                    bracket_floor = 6350;
                    percentage = 0.005m;
                }
                else if (taxable_earnings < 8850)
                {
                    flat_amount = 5;
                    bracket_floor = 7350;
                    percentage = 0.01m;
                }
                else if (taxable_earnings < 10100)
                {
                    flat_amount = 20;
                    bracket_floor = 8850;
                    percentage = 0.02m;
                }
                else if (taxable_earnings < 11250)
                {
                    flat_amount = 45;
                    bracket_floor = 10100;
                    percentage = 0.03m;
                }
                else if (taxable_earnings < 13550)
                {
                    flat_amount = 79.50m;
                    bracket_floor = 11250;
                    percentage = 0.04m;
                }
                else
                {
                    flat_amount = 171.50m;
                    bracket_floor = 13550;
                    percentage = 0.05m;
                }
            }

            Decimal annual_withholding = flat_amount + (percentage * (taxable_earnings - bracket_floor));

            // Round ALL to the nearest dollar

            return frequency.CalculateDeannualized(annual_withholding).Round(decimals: 0);
        }
    }
}