﻿using CertiPay.Payroll.Common;
using NUnit.Framework;

namespace CertiPay.Taxes.State.Tests.MA
{
    [TestFixture]
    public class Massachusetts_Tests
    {
        [Test]
        //[TestCase(350, PayrollFrequency.Weekly, 4, 26.78, false, false, 9.51)] This was based on 2012 amounts
        [TestCase(1500, PayrollFrequency.Monthly, 1, 2000, true, true, 29.75)] // Bad test case, we don't have 2k of FICA in one period
        [TestCase(4000, PayrollFrequency.Monthly, 2, 2000, false, false, 172.55)] // Bad test case, we don't have 2k of FICA in one period
        [TestCase(1500, PayrollFrequency.BiWeekly, 2, 114.75, false, false, 61.98)] // FICA 93 + MEDI 21.75 => capped at $2k
        [TestCase(2800, PayrollFrequency.Weekly, 3, 214.20, false, false, 134.56)] // FICA 173.60 + MEDI 40.60 => capped at $2k
        public void MA2016_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, int numExemptions, decimal FICADeductions, bool IsBlind, bool IsHoH, decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.MA, year: 2016) as Massachusettes.TaxTable;

            var result = table.Calculate(grossWages, freq, FICADeductions, numExemptions, IsBlind, IsHoH);

            Assert.AreEqual(expected, result);
        }
    }
}