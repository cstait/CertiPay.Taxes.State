﻿using CertiPay.Payroll.Common;
using System;

namespace CertiPay.Taxes.State.Massachusettes
{
    public class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.MA; } }

        public override Decimal SUI_Wage_Base { get { return 15000; } }

        public virtual Decimal WorkForce_Development_Rate { get; } = 0.00056m;

        public virtual Decimal WorkForce_Development_RateCap { get { return SUI_Wage_Base; } }

        internal virtual Decimal TaxRate { get; } = 0.051m;

        internal virtual Decimal Max_FICA_Deduction { get; } = 2000;

        internal virtual Decimal Exemption_Value { get; } = 1000;

        internal virtual Decimal Is_HoH_Allowance { get; } = 122.40m;

        internal virtual Decimal Is_Blind_Allowance { get; } = 112.20m;

        internal virtual Decimal Exemption_Bonus { get; } = 3400;

        /// <summary>
        /// Returns Massachusettes State Withholding when provided with a non-negative value for Fica Withholding, Gross Wages and Exemptions.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="ytd_Fica_Withholding"></param>
        /// <param name="exemptions"></param>
        /// <param name="isBlind"></param>
        /// <param name="isHeadOfHousehold"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, Decimal ytd_Fica_Withholding, int exemptions = 1, bool isBlind = false, bool isHeadOfHousehold = false)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");
            if (ytd_Fica_Withholding < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(ytd_Fica_Withholding)} cannot be a negative number");
            if (exemptions < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(exemptions)} cannot be a negative number");

            // Note: This does not take into account other retirement systems i.e. US and Railroad Retirement Systems

            Decimal taxable_wages = grossWages;

            // Step (1) Then we can deduct the amount paid into FICA and Medicare through this pay period up to the Max_FICA_Deduction amount

            //ref:
            //Subtract the amount deducted for the U.S. Social Security (FICA),
            //Medicare, Massachusetts, United States or Railroad Retirement systems.
            //The total amount subtracted may not exceed $2,000.When,
            //during the year, the total amount subtracted reaches the equivalent
            //of the $2,000 maximum allowable as a deduction by Massachusetts,
            //discontinue this step.

            taxable_wages -= Math.Min(Max_FICA_Deduction, ytd_Fica_Withholding);

            // Step (2) Then, we reduce the taxable wages by the exemptions

            taxable_wages -= Get_Exemption_Value(frequency, exemptions);

            // Step (3) Next, we multiply the annualized taxable wages minus allowances times the tax rate

            var withholding = taxable_wages * TaxRate;

            // Step (4) If filing as Head of Household, reduce the withholding by the given amount

            if (isHeadOfHousehold)
            {
                withholding -= Get_HoH_Allowance(frequency);
            }

            // Step (5) Blind/With Blind Spouse, reduce the withholding by the given amount

            if (isBlind)
            {
                withholding -= Get_Blind_Allowance(frequency);
            }

            return Math.Max(0, withholding).Round();
        }

        internal virtual Decimal Get_HoH_Allowance(PayrollFrequency frequency)
        {
            return frequency.CalculateDeannualized(Is_HoH_Allowance);
        }

        internal virtual Decimal Get_Blind_Allowance(PayrollFrequency frequency)
        {
            return frequency.CalculateDeannualized(Is_Blind_Allowance);
        }

        internal virtual Decimal Get_Exemption_Value(PayrollFrequency frequency, int number_of_exemptions)
        {
            switch (number_of_exemptions)
            {
                // "If an employee claims '0' exemptions, discontinue this step"

                case 0:
                    return Decimal.Zero;

                default:
                    return frequency.CalculateDeannualized((number_of_exemptions * Exemption_Value) + Exemption_Bonus);
            }
        }
    }
}