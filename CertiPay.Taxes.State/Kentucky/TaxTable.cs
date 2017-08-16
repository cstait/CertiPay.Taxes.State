using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CertiPay.Taxes.State.Kentucky
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get; internal set; } = StateOrProvince.KY;

        protected virtual Decimal StandardDeduction { get; }

        protected virtual Decimal Exemption { get; }

        protected abstract IEnumerable<Bracket> Brackets { get; }

        /// <summary>
        /// Returns Kentucky State Withholding when given a non-negative value for Gross Wages and Exemptions.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="exemptions"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, int exemptions = 0)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");
            if (exemptions < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(exemptions)} cannot be a negative number");

            var taxableWages = frequency.CalculateAnnualized(grossWages);

            taxableWages -= StandardDeduction;

            var withheldWages = FindWithholding(taxableWages);

            withheldWages -= GetExemptions(exemptions);

            return Math.Max(0, frequency.CalculateDeannualized(withheldWages));
        }

        protected virtual Decimal GetExemptions(int exemptions)
        {
            return exemptions * Exemption;
        }

        protected virtual Decimal FindWithholding(decimal withheldWages)
        {
            decimal sum = 0.00m;

            foreach (var bracket in Brackets)
            {
                if (withheldWages > bracket.Amount && bracket != Brackets.Last())
                {
                    sum += bracket.Amount * bracket.Percentage;
                    withheldWages -= bracket.Amount;
                }
                else if (bracket == Brackets.Last())
                {
                    sum += bracket.Percentage * withheldWages;
                }
                else
                {
                    sum += bracket.Percentage * withheldWages;
                    break;
                }
            }
            return sum;
        }

        protected class Bracket
        {
            public Decimal Amount { get; set; }

            public Decimal Percentage { get; set; }

            public override bool Equals(System.Object obj)
            {
                // If parameter is null return false.
                if (obj == null)
                {
                    return false;
                }

                // If parameter cannot be cast to Point return false.
                Bracket p = obj as Bracket;
                if ((System.Object)p == null)
                {
                    return false;
                }

                // Return true if the fields match:
                return (Amount == p.Amount) && (Percentage == p.Percentage);
            }

            public static bool operator ==(Bracket a, Bracket b)
            {
                // If both are null, or both are same instance, return true.
                if (System.Object.ReferenceEquals(a, b))
                {
                    return true;
                }

                // If one is null, but not both, return false.
                if (((object)a == null) || ((object)b == null))
                {
                    return false;
                }

                // Return true if the fields match:
                return a.Percentage == b.Percentage && a.Amount == b.Amount;
            }

            public static bool operator !=(Bracket a, Bracket b)
            {
                return !(a == b);
            }
        }
    }
}