using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CertiPay.Taxes.State.Mississippi
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get; internal set; } = StateOrProvince.MS;

        protected virtual IEnumerable<StandardDeduction> StandardDeductions { get; }

        /// <summary>
        /// Returns Mississippi State Withholding when given a non-negative vlaue for Gross Wages and Exemptions.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="filingStatus"></param>
        /// <param name="exemption"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, FilingStatus filingStatus, decimal exemption)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");
            if (exemption < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(exemption)} cannot be a negative number");

            var taxableWages = frequency.CalculateAnnualized(grossWages);

            taxableWages -= GetStandardDeduction(filingStatus);

            taxableWages -= exemption;

            var withheldWages = FindWithholding(taxableWages);

            return frequency.CalculateDeannualized(Math.Max(0, withheldWages)).Round(decimals: 0);
        }

        protected virtual Decimal GetStandardDeduction(FilingStatus filingStatus)
        {
            return StandardDeductions
                .Where(x => x.FilingStatus == filingStatus)
                .Select(x => x.Amount)
                .Single();
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

        protected virtual IEnumerable<Bracket> Brackets { get; }

        public class Exemption : StandardDeduction
        {
            public Decimal AdditionalAmount { get; set; }
        }

        public class StandardDeduction
        {
            public Decimal Amount { get; set; }

            public FilingStatus FilingStatus { get; set; }
        };

        public class Bracket
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
                return a.Equals(b);
            }

            public static bool operator !=(Bracket a, Bracket b)
            {
                return !(a == b);
            }
        }
    }

    public enum FilingStatus : byte
    {
        Single = 0,

        [Display(Name = "Head of Family")]
        HeadOfFamily = 1,

        Married = 2
    }
}