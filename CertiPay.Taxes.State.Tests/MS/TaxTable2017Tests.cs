using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.MS
{
    using FilingStatus = Mississippi.FilingStatus;

    [TestFixture]
    public class TaxTable2017Tests
    {
        [Test]        
        [TestCase(0, PayrollFrequency.BiWeekly, FilingStatus.Single, 6000, 0.00)]
        [TestCase(1, PayrollFrequency.BiWeekly, FilingStatus.Single, 6000, 0.00)]
        [TestCase(1000, PayrollFrequency.BiWeekly, FilingStatus.Single, 6000, 28.00)]
        [TestCase(1000, PayrollFrequency.BiWeekly, FilingStatus.HeadOfFamily, 9500, 19)]
        [TestCase(1000, PayrollFrequency.BiWeekly, FilingStatus.Married, 12000, 13)]
        public void Mississippi_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, FilingStatus filingStatus, int personalAllowances, decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.MS, year: 2017) as Mississippi.TaxTable2017;

            var result = table.Calculate(grossWages, freq, filingStatus, personalAllowances);

            Assert.AreEqual(expected, result);
        }


        [Test]
        [TestCase(-1, PayrollFrequency.BiWeekly, FilingStatus.Single, 6000, 0.00)]
        public void NegativeValue_Mississippi_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, FilingStatus filingStatus, int personalAllowances, decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.MS, year: 2017) as Mississippi.TaxTable2017;

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, freq, filingStatus, personalAllowances));
        }




        
    }
}