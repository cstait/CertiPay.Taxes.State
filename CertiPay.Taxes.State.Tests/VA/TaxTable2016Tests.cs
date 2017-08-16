using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.VA
{
    public class TaxTable2016Tests
    {
        [Test]        
        [TestCase(PayrollFrequency.Weekly, 0, 2, 0d)]
        [TestCase(PayrollFrequency.Weekly, 1, 2, 0d)]
        [TestCase(PayrollFrequency.Weekly, 450, 2, 15.55d)]
        [TestCase(PayrollFrequency.BiWeekly, 1000, 1, 38.90d)]
        [TestCase(PayrollFrequency.SemiMonthly, 1000, 2, 35.13d)]
        public void Checks_And_Balances(PayrollFrequency frequency, Decimal grossWages, int allowances, Decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.VA, year: 2016) as Virginia.TaxTable;

            var result = table.Calculate(grossWages, frequency, allowances);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(PayrollFrequency.Weekly, -1, 2)]
        public void NegativeValues_Checks_And_Balances(PayrollFrequency frequency, Decimal grossWages, int allowances)
        {
            var table = TaxTables.GetForState(StateOrProvince.VA, year: 2016) as Virginia.TaxTable;            

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, frequency, allowances));
        }
    }
}