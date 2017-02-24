﻿using CertiPay.Payroll.Common;
using NUnit.Framework;

namespace CertiPay.Taxes.State.Tests.UT
{
    [TestFixture]
    public class TaxTable2017Tests
    {
        [Test]
        //verified with PCC
        [TestCase(400, PayrollFrequency.Weekly, FilingStatus.Single, 1, 14.99)]
        [TestCase(2500, PayrollFrequency.Monthly, FilingStatus.Married, 3, 75.5)]
        [TestCase(1000, PayrollFrequency.BiWeekly, FilingStatus.Single, 2, 37.77)]
        public void Utah_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, FilingStatus filingStatus, int personalAllowances, decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.UT, year: 2017) as Utah.TaxTable;

            var result = table.Calculate(grossWages, freq, filingStatus, personalAllowances);

            Assert.AreEqual(expected, result);
        }
    }
}