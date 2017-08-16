using CertiPay.Payroll.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace CertiPay.Taxes.State.Arizona
{
    public class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get; internal set; } = StateOrProvince.AZ;

        public override decimal SUI_Wage_Base
        {
            get
            {
                switch (Year)
                {
                    case 2016:
                    case 2017:
                        return 7000;
                }

                throw new NotImplementedException($"SUI Wage Base is not configured for Arizona for {Year}");
            }
        }

        /// <summary>
        /// Returns the state withholding amount for Arizona when given a non-negative gross wage.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="taxRate"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, TaxRate taxRate = TaxRate.TwoPointSevenPercent)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");

            return grossWages * GetTaxRate(taxRate);
            
        }

        internal decimal GetTaxRate(TaxRate taxRate)
        {
            switch (taxRate)
            {
                case TaxRate.ZeroPointEightPercent:
                    return 0.008m;

                case TaxRate.OnePointThreePercent:
                    return 0.013m;

                case TaxRate.OnePointEightPercent:
                    return 0.018m;

                case TaxRate.TwoPointSevenPercent:
                    return 0.027m;

                case TaxRate.ThreePointSixPercent:
                    return 0.036m;

                case TaxRate.FourPointTwoPercent:
                    return 0.042m;

                case TaxRate.FivePointOnePercent:
                    return 0.051m;

                default:
                    return 0.00m;
            }
        }
    }

    public enum TaxRate : Byte
    {
        [Display(Name = "0.8%")]
        ZeroPointEightPercent = 0,

        [Display(Name = "1.3%")]
        OnePointThreePercent = 1,

        [Display(Name = "1.8%")]
        OnePointEightPercent = 2,

        [Display(Name = "2.7%")]
        TwoPointSevenPercent = 3,

        [Display(Name = "3.6%")]
        ThreePointSixPercent = 4,

        [Display(Name = "4.2%")]
        FourPointTwoPercent = 5,

        [Display(Name = "5.1%")]
        FivePointOnePercent = 6
    }
}