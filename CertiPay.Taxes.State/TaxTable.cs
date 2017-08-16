using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CertiPay.Taxes.State
{
    /// <summary>
    /// Static methods relating to tax tables for states
    /// </summary>
    public static class TaxTables
    {
        /// <summary>
        /// Returns a list of configured state tax entries
        /// </summary>
        private static IEnumerable<TaxTable> Tables
        {
            get
            {
                yield return new TaxTable2014();
                yield return new TaxTable2015();
                yield return new TaxTable2016();
                yield return new TaxTable2017();
            }
        }

        /// <summary>
        /// Find the tax table header for the given state and year
        /// </summary>
        public static TaxTableHeader GetForState(StateOrProvince state, int year)
        {
            var header =
                Tables
                .Where(table => table.Year == year)
                .SelectMany(table => table.Entries)
                .Where(entry => entry.State == state)
                .SingleOrDefault();

            if (header == null)
            {
                throw new ArgumentOutOfRangeException($"{state.DisplayName()} is not supported for year {year}");
            }

            return header;
        }

        /// <summary>
        /// Find the tax table implementation for the given state and year
        /// </summary>
        public static T GetForState<T>(StateOrProvince state, int year) where T : TaxTableHeader
        {
            T header =
                Tables
                .Where(table => table.Year == year)
                .SelectMany(table => table.Entries)
                .Where(entry => entry.State == state)
                .OfType<T>()
                .SingleOrDefault();

            if (header == null)
            {
                throw new ArgumentOutOfRangeException($"{state.DisplayName()} is not supported for year {year}");
            }

            return header;
        }

        /// <summary>
        /// U.S. territories are islands under the jurisdiction of the United States which are not States of the United States.
        /// Those that have their own governments and their own tax systems (Puerto Rico, U.S. Virgin Islands, Guam, American Samoa, and The Commonwealth of the Northern Mariana Islands)
        /// and are not subject to the income taxes and withholding of U.S. federal income taxes.
        /// </summary>
        public static Boolean HasFederalWithholding(this StateOrProvince state)
        {
            switch (state)
            {
                // Have their own gov't and tax systems, do not fall under the Federal income taxes

                case StateOrProvince.GU:
                case StateOrProvince.PR:
                case StateOrProvince.VI:
                case StateOrProvince.AS:
                case StateOrProvince.MP:

                // Also include the unknown case, we won't flag them for withholding

                case StateOrProvince.Unknown:

                    return false;

                default:
                    return true;
            }
        }

        /// <summary>
        /// Returns true if the given state has tax withholding on employee pay
        /// </summary>
        public static Boolean HasWithholding(this StateOrProvince state)
        {
            switch (state)
            {
                // Also include the unknown case, we won't flag them for withholding
                case StateOrProvince.Unknown:

                // TODO These provinces have their own tax systems, and may or may not have province-specific withholding

                case StateOrProvince.GU:
                case StateOrProvince.PR:
                case StateOrProvince.VI:
                case StateOrProvince.AS:
                case StateOrProvince.MP:

                // States that don't have income withholding

                case StateOrProvince.FL:
                case StateOrProvince.AK:
                case StateOrProvince.NV:
                case StateOrProvince.NH:
                case StateOrProvince.SD:
                case StateOrProvince.TN:
                case StateOrProvince.TX:
                case StateOrProvince.WY:
                    return false;

                default:
                    return true;
            }
        }

        /// <summary>
        /// Returns true if the given state has a statutory disability plan program obligation
        /// </summary>
        public static Boolean HasStatutoryDisabilityPlan(this StateOrProvince state)
        {
            switch (state)
            {
                case StateOrProvince.NY:
                case StateOrProvince.NJ:
                case StateOrProvince.RI:
                case StateOrProvince.CA:
                case StateOrProvince.HI:
                case StateOrProvince.PR:
                    return true;

                default:
                    return false;
            }
        }

        /// <summary>
        /// Returns true if the given state has an employee deduction requirement for Unemployment Insurance
        /// </summary>
        public static Boolean HasUnemploymentEmployeeDeduction(this StateOrProvince state)
        {
            switch (state)
            {
                case StateOrProvince.AK:
                case StateOrProvince.NJ:
                case StateOrProvince.PA:
                    return true;

                default:
                    return false;
            }
        }
    }

    public interface TaxTable
    {
        int Year { get; }

        IEnumerable<TaxTableHeader> Entries { get; }
    }
}