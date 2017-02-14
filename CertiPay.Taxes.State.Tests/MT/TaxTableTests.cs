﻿using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.MT
{
    public class TaxTableTests
    {
        [Test]
        [TestCase(PayrollFrequency.SemiMonthly, 550, 5, 3d)]
        [TestCase(PayrollFrequency.BiWeekly, 2950, 2, 152d)]
        [TestCase(PayrollFrequency.Weekly, 135, 1, 2d)]
        public void Checks_And_Balances(PayrollFrequency frequency, Decimal grossWages, int allowances, Decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.MT, year: 2017) as Montana.TaxTable;

            var result = table.Calculate(grossWages, frequency, allowances);

            Assert.AreEqual(expected, result);
        }
    }
}