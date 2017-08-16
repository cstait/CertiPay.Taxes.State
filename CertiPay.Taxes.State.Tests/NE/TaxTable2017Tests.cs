using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.NE
{
    [TestFixture]
    public class TaxTable2017Tests
    {
        [Test]
        //Verified with PCC        
        [TestCase(0, PayrollFrequency.BiWeekly, FilingStatus.Married, 1, 0)]
        [TestCase(1, PayrollFrequency.BiWeekly, FilingStatus.Married, 1, 0)]
        [TestCase(4600, PayrollFrequency.BiWeekly, FilingStatus.Married, 1, 249.80)]
        [TestCase(4600, PayrollFrequency.BiWeekly, FilingStatus.Single, 0, 277.32)]
        [TestCase(5, PayrollFrequency.BiWeekly, FilingStatus.Married, 2, 0)]
        public void Nebraska_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, FilingStatus filingStatus, int personalAllowances, decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.NE, year: 2017) as Nebraska.TaxTable2017;

            var result = table.Calculate(grossWages, freq, filingStatus, personalAllowances);

            Assert.AreEqual(expected, result);
        }

        [Test]        
        [TestCase(-1, PayrollFrequency.BiWeekly, FilingStatus.Married, 1)]
        public void NegativeValues_Nebraska_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, FilingStatus filingStatus, int personalAllowances)
        {
            var table = TaxTables.GetForState(StateOrProvince.NE, year: 2017) as Nebraska.TaxTable2017;

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, freq, filingStatus, personalAllowances));
        }
    }
}