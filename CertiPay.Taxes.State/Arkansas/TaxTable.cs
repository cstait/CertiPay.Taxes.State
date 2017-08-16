using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CertiPay.Taxes.State.Arkansas
{
    public class TaxTable : TaxTableHeader
    {
        // These tables have been in effect since 1-Jan 2007

        public override StateOrProvince State { get; internal set; } = StateOrProvince.AR;

        private const decimal roundingValue = 50000;

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

                throw new NotImplementedException($"SUI Wage Base is not configured for Arkansas for {Year}");
            }
        }

        public Decimal StandardDeductionValue { get; } = 2200;

        public Decimal ExemptionValue { get; } = 26;


        /// <summary>
        /// Returns Arkansas State Withholding when given a non-negative value for Gross Wages and Exemptions.
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
            taxableWages -= StandardDeductionValue;
            if (taxableWages < roundingValue)
            {
                taxableWages = applyMidpoint(taxableWages);
            }

            if (taxableWages <= 0)
                return 0;

            var withholdingTable = getBracket(taxableWages);
            taxableWages = (withholdingTable.Percentage * taxableWages) - withholdingTable.FlatAmount;
            taxableWages -= getExemptions(taxableWages, exemptions);

            return Math.Max(Decimal.Zero, frequency.CalculateDeannualized(taxableWages));
        }

        private Bracket getBracket(decimal taxableWages)
        {
            return Brackets
                .Where(x => x.Floor <= taxableWages && x.Ceiling > taxableWages)
                .Select(x => x)
                .Single();
        }

        private Decimal getExemptions(decimal taxableWages, int exemptions)
        {
            return ExemptionValue * exemptions;
        }

        private Decimal applyMidpoint(decimal taxableWages)
        {
            var doublewages = (double)taxableWages;
            var decimalplaces = Math.Floor(Math.Log10(doublewages) - 1);
            if ((doublewages / (Math.Pow(10, decimalplaces))) > 50)
                return (decimal)(Math.Floor(doublewages / 50) * 50.0);
            else
                return (decimal)(Math.Ceiling(doublewages / 50) * 50.0);
        }

        private IEnumerable<Bracket> Brackets
        {
            get
            {
                return new[]
                {
                    new Bracket { Floor = Decimal.MinValue, Percentage = Decimal.Zero },
                    new Bracket { Floor = 0, Ceiling = 4300, FlatAmount = 0.00m, Percentage = 0.09m },
                    new Bracket { Floor = 4300, Ceiling = 8400, FlatAmount = 64.49m, Percentage = 0.024m },
                    new Bracket { Floor = 8400, Ceiling = 12600, FlatAmount = 148.48m, Percentage = 0.034m },
                    new Bracket { Floor = 12600, Ceiling = 21000, FlatAmount = 274.47m, Percentage = 0.044m },
                    new Bracket { Floor = 21000, Ceiling = 35100, FlatAmount = 589.45m, Percentage = 0.059m },
                    new Bracket {  Floor = 35100, Ceiling = Decimal.MaxValue, FlatAmount = 940.44m, Percentage = 0.069m },
                };
            }
        }

        private class Bracket
        {
            public Decimal Floor { get; set; }

            public Decimal Ceiling { get; set; }

            public Decimal FlatAmount { get; set; }

            public Decimal Percentage { get; set; }
        }
    }
}