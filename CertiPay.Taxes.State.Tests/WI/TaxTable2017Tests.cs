using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.WI
{
    [TestFixture]
    public class TaxTable2017Tests
    {
        //Verified with PCC
        [TestCase(0, PayrollFrequency.Weekly, FilingStatus.Single, 1, 0)]
        [TestCase(1, PayrollFrequency.Weekly, FilingStatus.Single, 1, 0)]
        [TestCase(300, PayrollFrequency.Weekly, FilingStatus.Single, 1, 7.32)]
        [TestCase(500, PayrollFrequency.Weekly, FilingStatus.Single, 3, 19.01)]
        [TestCase(1000, PayrollFrequency.BiWeekly, FilingStatus.Married, 3, 32.37)]
        public void Wisconsin_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, FilingStatus filingStatus, int personalAllowances, decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.WI, year: 2017) as Wisconsin.TaxTable2017;

            var result = table.Calculate(grossWages, freq, filingStatus, personalAllowances);
                           
            Assert.AreEqual(expected, result);
        }

        [Test]        
        [TestCase(-1, PayrollFrequency.Weekly, FilingStatus.Single, 1)]
        public void NegativeValue_Wisconsin_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, FilingStatus filingStatus, int personalAllowances)
        {
            var table = TaxTables.GetForState(StateOrProvince.WI, year: 2017) as Wisconsin.TaxTable2017;

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, freq, filingStatus, personalAllowances));

        }

    }
}