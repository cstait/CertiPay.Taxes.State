using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CertiPay.Taxes.State.Utah
{
    public class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get; internal set; } = StateOrProvince.UT;

        public override decimal SUI_Wage_Base
        {
            get
            {
                switch (Year)
                {
                    case 2016:
                        return 32200;

                    case 2017:
                        return 33100;
                }

                throw new NotImplementedException($"SUI Wage Base is not configured for Utah for {Year}");
            }
        }

        public Decimal Allowance { get; set; } = 125;

        public Decimal TaxRateA { get; set; } = .05m;

        public Decimal TaxRateB { get; set; } = .013m;

        protected IEnumerable<BaseAllowance> BaseAllowances
        {
            get
            {
                yield return new BaseAllowance { FilingStatus = FilingStatus.Single, Amount = 250 };
                yield return new BaseAllowance { FilingStatus = FilingStatus.Married, Amount = 375 };
            }
        }

        protected IEnumerable<StandardDeduction> StandardDeductions
        {
            get
            {
                yield return new StandardDeduction { FilingStatus = FilingStatus.Single, Amount = 12000 };
                yield return new StandardDeduction { FilingStatus = FilingStatus.Married, Amount = 18000 };
            }
        }

        /// <summary>
        /// Returns Utah State Withholding when given a non-negative value for gross wages and exemptions.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="filingStatus"></param>
        /// <param name="exemptions"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, FilingStatus filingStatus, int exemptions = 0)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");
            if (exemptions < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(exemptions)} cannot be a negative number");

            var annualized_wages = frequency.CalculateAnnualized(grossWages);

            var taxedWages = annualized_wages * TaxRateA;

            var allowances = GetAllowances(filingStatus, exemptions);

            annualized_wages -= GetStandardDeduction(filingStatus);

            annualized_wages = annualized_wages * TaxRateB;

            var deduction = allowances - annualized_wages;

            var taxWithheld = taxedWages - deduction;

            return frequency.CalculateDeannualized(Math.Max(taxWithheld, 0));
        }

        protected Decimal GetAllowances(FilingStatus filingStatus, int exemptions)
        {
            return
                BaseAllowances
                .Where(x => x.FilingStatus == filingStatus)
                .Select(x => x.Amount)
                .Single() + (exemptions * Allowance);
        }

        protected Decimal GetStandardDeduction(FilingStatus filingStatus)
        {
            return StandardDeductions
                .Where(x => x.FilingStatus == filingStatus)
                .Select(x => x.Amount)
                .Single();
        }

        protected class BaseAllowance
        {
            public FilingStatus FilingStatus { get; set; }
            public decimal Amount { get; set; }
        }

        protected class StandardDeduction : BaseAllowance
        { };
    }
}