﻿using CertiPay.Payroll.Common;
using NUnit.Framework;

namespace CertiPay.Taxes.State.Tests.MI
{    
    [TestFixture]
    public class TaxTable2017Tests
    {     
     

        [Test]
        //Verified with Tax Tables
        [TestCase(4600, PayrollFrequency.BiWeekly, 1, 1,  182.42)]
        [TestCase(1000, PayrollFrequency.BiWeekly, 0, 0, 42.5)]
        [TestCase(5, PayrollFrequency.BiWeekly, 2, 2, 0)]


        public void Michigan_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, int personalAllowances, int dependents, decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.MI, year: 2017) as Michigan.TaxTable2017;

            var result = table.Calculate(grossWages, freq, personalAllowances, dependents);

            Assert.AreEqual(expected, result);
        }
    }
}