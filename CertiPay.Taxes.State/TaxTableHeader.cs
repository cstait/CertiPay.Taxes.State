using CertiPay.Payroll.Common;
using System;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("CertiPay.Taxes.State.Tests")]

namespace CertiPay.Taxes.State
{
    public class TaxTableHeader
    {
        /// <summary>
        /// The tax year represented
        /// </summary>
        public virtual int Year { get; internal set; }

        /// <summary>
        /// The state or province that the tax entry is valid for
        /// </summary>
        public virtual StateOrProvince State { get; internal set; }

        /// <summary>
        /// The Federal Unemployment Tax Act requires that each state's taxable wage base must at least equal
        /// the FUTA wage base of $7,000 per employee, although most states exceed that. This value is the
        /// wage base for given state and year, multiplied by the SUI rate offered to a company by the state.
        /// </summary>
        public virtual Decimal SUI_Wage_Base { get; internal set; }

        /// <summary>
        /// The decimal percentage of reduction on the FUTA credit for SUI taxes paid due to non-repaid money due
        /// to the federal government by the state
        /// </summary>
        [Obsolete(message: "This is not determined until late into the tax year, and should not be relied upon.")]
        public virtual Decimal FUTA_Reduction_Rate { get; internal set; }
    }
}