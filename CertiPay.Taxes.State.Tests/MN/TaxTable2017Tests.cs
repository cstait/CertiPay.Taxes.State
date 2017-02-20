﻿using CertiPay.Payroll.Common;
using NUnit.Framework;

namespace CertiPay.Taxes.State.Tests.MN
{
    [TestFixture]
    public class TaxTable2017Tests
    {
        [Test]
        //Verified by hand
        [TestCase(4600, PayrollFrequency.BiWeekly, FilingStatus.Single, 1, 299.67)]
        [TestCase(500, PayrollFrequency.BiWeekly, FilingStatus.Married, 0, 8.95)]
        public void Minnesota_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, FilingStatus filingStatus, int personalAllowances,decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.MN, year: 2017) as Minnesota.TaxTable2017;

            var result = table.Calculate(grossWages, freq, filingStatus, personalAllowances);

            Assert.AreEqual(expected, result);
        }
    }
}