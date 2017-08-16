using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State
{
    /// <summary>
    /// Describes a common, shared filing status used across many states
    /// </summary>
    public enum FilingStatus : byte
    {
        Single = 0,

        Married = 1,

        Exempt = byte.MaxValue
    }

    public static class FilingStatuses
    {
        public static IEnumerable<String> ForState(StateOrProvince state)
        {
            if (state.HasWithholding())
            {
                switch (state)
                {
                    // TODO Louisiana, Mississippi, Missouri

                    case StateOrProvince.KS:
                        yield return Kansas.FilingStatus.Single.ToString();
                        yield return Kansas.FilingStatus.MarriedOrHoH.ToString();
                        break;

                    case StateOrProvince.NJ:
                        yield return NewJersey.FilingStatus.Single.ToString();
                        yield return NewJersey.FilingStatus.MarriedWithTwoIncomes.ToString();
                        yield return NewJersey.FilingStatus.MarriedWithOneIncome.ToString();
                        yield return NewJersey.FilingStatus.MarriedFilingSeparate.ToString();
                        yield return NewJersey.FilingStatus.HeadOfHousehold.ToString();
                        break;

                    case StateOrProvince.DE:
                        yield return Delaware.FilingStatus.Single.ToString();
                        yield return Delaware.FilingStatus.MarriedFilingJointly.ToString();
                        yield return Delaware.FilingStatus.MarriedFilingSeperate.ToString();
                        break;

                    case StateOrProvince.CT:
                        yield return Connecticut.WithholdingCode.A.ToString();
                        yield return Connecticut.WithholdingCode.B.ToString();
                        yield return Connecticut.WithholdingCode.C.ToString();
                        yield return Connecticut.WithholdingCode.D.ToString();
                        yield return Connecticut.WithholdingCode.E.ToString();
                        yield return Connecticut.WithholdingCode.F.ToString();
                        break;

                    case StateOrProvince.AL:
                        yield return Alabama.FilingStatus.Single.ToString();
                        yield return Alabama.FilingStatus.Married.ToString();
                        yield return Alabama.FilingStatus.MarriedFilingSeparate.ToString();
                        yield return Alabama.FilingStatus.HeadOfFamily.ToString();
                        break;

                    case StateOrProvince.OH:
                    case StateOrProvince.MI:
                    case StateOrProvince.KY:
                    case StateOrProvince.PA:
                        yield return "Normal";
                        yield return "% of Gross";
                        break;

                    case StateOrProvince.GA:
                        yield return Georgia.FilingStatus.Single.ToString();
                        yield return Georgia.FilingStatus.MarriedWithOneIncome.ToString();
                        yield return Georgia.FilingStatus.MarriedWithTwoIncomes.ToString();
                        yield return Georgia.FilingStatus.MarriedFilingSeparate.ToString();
                        yield return Georgia.FilingStatus.HeadOfHousehold.ToString();
                        break;

                    case StateOrProvince.NC:
                    case StateOrProvince.CA:
                        yield return NorthCarolina.FilingStatus.Single.ToString();
                        yield return NorthCarolina.FilingStatus.Married.ToString();
                        yield return NorthCarolina.FilingStatus.HeadOfHousehold.ToString();
                        break;

                    case StateOrProvince.NE:
                    case StateOrProvince.OK:
                    case StateOrProvince.NM:
                    case StateOrProvince.MD:
                    case StateOrProvince.CO:
                    case StateOrProvince.ND:
                    case StateOrProvince.MN:
                    case StateOrProvince.ME:
                    case StateOrProvince.VT:
                    case StateOrProvince.NY:
                    case StateOrProvince.OR:
                    case StateOrProvince.UT:
                    case StateOrProvince.ID:
                    case StateOrProvince.HI:
                    case StateOrProvince.WI:
                        yield return FilingStatus.Single.ToString();
                        yield return FilingStatus.Married.ToString();
                        break;

                    case StateOrProvince.WV:
                        yield return WestVirginia.FilingStatus.Single_Earning.ToString();
                        yield return WestVirginia.FilingStatus.Two_Earnings.ToString();
                        break;

                    // MA: Technically, you could be both blind and head of household, but we don't have a good way to indicate that via status

                    case StateOrProvince.MA:
                        yield return "Normal";
                        yield return "HeadOfHousehold";
                        yield return "Personal and/or Spouse Blindness";
                        break;

                    case StateOrProvince.AZ:
                        yield return Arizona.TaxRate.ZeroPointEightPercent.ToString();
                        yield return Arizona.TaxRate.OnePointThreePercent.ToString();
                        yield return Arizona.TaxRate.OnePointEightPercent.ToString();
                        yield return Arizona.TaxRate.TwoPointSevenPercent.ToString();
                        yield return Arizona.TaxRate.ThreePointSixPercent.ToString();
                        yield return Arizona.TaxRate.FourPointTwoPercent.ToString();
                        yield return Arizona.TaxRate.FivePointOnePercent.ToString();
                        break;

                    default:
                        yield return "Normal";
                        break;
                }

                yield return FilingStatus.Exempt.ToString();
            }
        }
    }
}