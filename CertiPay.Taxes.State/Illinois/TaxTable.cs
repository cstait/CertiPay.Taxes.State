using CertiPay.Payroll.Common;
using System;

namespace CertiPay.Taxes.State.Illinois
{
    public class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.IL; } }


        /// <summary>
        /// Returns Illinois State Withholding when provided with a non-negative value for Gross Wages, basic allowances and aditional allowances.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="basicAllowances"></param>
        /// <param name="additionalAllowances"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, int basicAllowances = 0, int additionalAllowances = 0)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");            
            if (additionalAllowances < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(additionalAllowances)} cannot be a negative number");
            if (basicAllowances < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(basicAllowances)} cannot be a negative number");

            var annualized_wages = frequency.CalculateAnnualized(grossWages);

            //Step 1 Determine the wages paid for the payroll period.

            //Step 2 Figure your employee’s exemptions using the allowances claimed on Form IL-W - 4.

            //a Multiply the number of allowances your employee claimed on Form IL - W - 4, Line 1, by $2,175.

            annualized_wages -= (basicAllowances * 2175);

            //b Multiply the number of allowances your employee claimed on Form IL - W - 4, Line 2, by $1,000.

            annualized_wages -= (additionalAllowances * 1000);

            //c Add your answers from Step 2a and Step 2b.

            //d Divide the result of Step 2c by the number of pay periods from the table. The result is your employee’s exemptions.

            //Step 3 Subtract the exemptions from the wages paid.The result is the taxable amount.

            //Step 4 Multiply the taxable amount by 3.75 percent(.0375).You must withhold this amount.

            //Step 5 Add any additional amount from Form IL-W - 4, Line 3.This is the total amount you withhold.

            // Note, we handle additional withholding requested on the processing side

            var annualized_taxes = annualized_wages * 0.0375m;

            return Math.Max(0, frequency.CalculateDeannualized(annualized_taxes));
        }
    }
}