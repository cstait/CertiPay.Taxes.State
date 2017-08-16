using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CertiPay.Taxes.State.WestVirginia
{
    public class TaxTable : TaxTableHeader
    {
        // These tables have been in effect since 1-Jan 2007

        public override StateOrProvince State { get; internal set; } = StateOrProvince.WV;

        public override decimal SUI_Wage_Base
        {
            get
            {
                switch (Year)
                {
                    case 2016:
                    case 2017:
                        return 12000;
                }

                throw new NotImplementedException($"SUI Wage Base is not configured for West Virginia for {Year}");
            }
        }

        public Decimal ExemptionValue { get; } = 2000;


        /// <summary>
        /// Returns West Virginia State Withholding when given a non-negative value for Gross Wages and Exemptions.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="status"></param>
        /// <param name="exemptions"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, FilingStatus status = FilingStatus.Two_Earnings, int exemptions = 0)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");
            if (exemptions < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(exemptions)} cannot be a negative number");

            var annualized_wages = frequency.CalculateAnnualized(grossWages);

            annualized_wages -= exemptions * ExemptionValue;

            if (annualized_wages <= 0)
                return 0;

            var bracket =
                Brackets
                .Where(_ => _.Status == status)
                .Where(_ => _.Floor < annualized_wages)
                .Where(_ => _.Ceiling >= annualized_wages)
                .Single();

            var annualized_withholding = bracket.FlatAmount + bracket.Percentage * (annualized_wages - bracket.Floor);

            // Round to the nearest dollar

            return frequency.CalculateDeannualized(annualized_withholding).Round(decimals: 0);
        }

        private IEnumerable<Bracket> Brackets
        {
            get
            {
                return new[]
                {
                    new Bracket { Status = FilingStatus.Two_Earnings, Floor = 0, Percentage = 0.03m },
                    new Bracket { Status = FilingStatus.Two_Earnings, Floor = 6000, Ceiling = 15000, FlatAmount = 180, Percentage = 0.04m },
                    new Bracket { Status = FilingStatus.Two_Earnings, Floor = 15000, Ceiling = 24000, FlatAmount = 540, Percentage = 0.045m },
                    new Bracket { Status = FilingStatus.Two_Earnings, Floor = 24000, Ceiling = 36000, FlatAmount = 945, Percentage = 0.06m },
                    new Bracket { Status = FilingStatus.Two_Earnings, Floor = 36000, Ceiling = Decimal.MaxValue, FlatAmount = 1665, Percentage = 0.065m },

                    new Bracket { Status = FilingStatus.Single_Earning, Floor = 0, Ceiling = 10000, Percentage = 0.03m },
                    new Bracket { Status = FilingStatus.Single_Earning, Floor = 10000, Ceiling = 25000, FlatAmount = 300, Percentage = 0.04m },
                    new Bracket { Status = FilingStatus.Single_Earning, Floor = 25000, Ceiling = 40000, FlatAmount = 900, Percentage = 0.045m },
                    new Bracket { Status = FilingStatus.Single_Earning, Floor = 40000, Ceiling = 60000, FlatAmount = 1575, Percentage = 0.06m },
                    new Bracket { Status = FilingStatus.Single_Earning, Floor = 60000, Ceiling = Decimal.MaxValue, FlatAmount = 2775, Percentage = 0.065m }
                };
            }
        }

        internal class Bracket
        {
            public FilingStatus Status { get; set; } = FilingStatus.Two_Earnings;

            public Decimal Floor { get; set; }

            public Decimal Ceiling { get; set; }

            public Decimal FlatAmount { get; set; }

            public Decimal Percentage { get; set; }
        }
    }

    public enum FilingStatus
    {
        [Display(Name = "Single, head of household or married with nonemployed spouse")]
        Single_Earning,

        [Display(Name = "Married filing jointly, both working/individual earning wages from two jobs")]
        Two_Earnings
    }
}