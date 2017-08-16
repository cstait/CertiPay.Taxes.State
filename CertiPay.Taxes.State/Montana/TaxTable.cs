using CertiPay.Payroll.Common;
using System;

namespace CertiPay.Taxes.State.Montana
{
    public class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.MT; } }

        public override Decimal SUI_Wage_Base
        {
            get
            {
                switch (Year)
                {
                    case 2016:
                        return 30500;

                    case 2017:
                        return 31400;
                }

                throw new NotImplementedException($"SUI Wage Base is not configured for Montana for {Year}");
            }
        }

        public Decimal AllowanceValue { get; } = 1900;

        /// <summary>
        /// Returns Montana State Withholding when given a non-negative value for Gross Wages and Allowances.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="allowances"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, int allowances = 0)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");
            if (allowances < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(allowances)} cannot be a negative number");

            // The MT Withholding Tables were last revisted 10-January 2005

            // The amount of tax you withhold from an employee’s pay depends upon three factors:
            // (1) the length of your payroll period,
            // (2) the employee’s gross pay, and
            // (3) the number of withholding allowances claimed on the withholding allowance certificate(W - 4)

            // Step 1: Calculate Taxable earnings "T" -> T = Gross Earnings for Period - ($1,900 x Number of allowances)
            // Step 2: Calculate Withholding Tax "W" -> W = A (Flat Amount) + (Percentage x (Taxable Earnings - Bottom of Bracket)

            Decimal annualized_wages = frequency.CalculateAnnualized(grossWages);

            Decimal taxable_earnings = annualized_wages - (AllowanceValue * allowances);

            Decimal flat_amount = 0, bracket_floor = 0, percentage = 0m;

            if (taxable_earnings <= 0)
            {
                return 0;
            }
            else if (taxable_earnings < 7000)
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

            Decimal annual_withholding = flat_amount + (percentage * (taxable_earnings - bracket_floor));

            // Round ALL to the nearest dollar

            return frequency.CalculateDeannualized(annual_withholding).Round(decimals: 0);
        }
    }
}