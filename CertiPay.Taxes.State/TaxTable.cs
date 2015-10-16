﻿using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State
{
    public class TaxEntry
    {
        /// <summary>
        /// The tax year represented
        /// </summary>
        public int Year { get; internal set; }

        /// <summary>
        /// The state or province that the tax entry is valid for
        /// </summary>
        public StateOrProvince State { get; internal set; }

        /// <summary>
        /// The Federal Unemployment Tax Act requires that each state's taxable wage base must at least equal
        /// the FUTA wage base of $7,000 per employee, although most states exceed that. This value is the
        /// wage base for given state and year, multiplied by the SUI rate offered to a company by the state.
        /// </summary>
        public Decimal SUI_Wage_Base { get; internal set; }

        /// <summary>
        /// The decimal percentage of reduction on the FUTA credit for SUI taxes paid due to non-repaid money due
        /// to the federal government by the state
        /// </summary>
        public Decimal FUTA_Reduction_Rate { get; internal set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class TaxTables
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
    }

    public interface TaxTable
    {
        int Year { get; }

        IEnumerable<TaxEntry> Entries { get; }
    }
}