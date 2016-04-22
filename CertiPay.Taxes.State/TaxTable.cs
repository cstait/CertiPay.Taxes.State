﻿using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;

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
        public static IEnumerable<TaxTable> Values()
        {
            yield return new TaxTable2014();
            yield return new TaxTable2015();
            yield return new TaxTable2016();
        }

        /// <summary>
        /// Returns true if the given state has tax withholding on employee pay
        /// </summary>
        public static Boolean HasWithholding(this StateOrProvince state)
        {
            switch (state)
            {
                case StateOrProvince.FL:
                case StateOrProvince.AL:
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
    }

    public interface TaxTable
    {
        int Year { get; }

        IEnumerable<TaxEntry> Entries { get; }
    }
}