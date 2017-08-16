using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.MT
{
    public class TaxTableTests
    {
        [Test]        
        [TestCase(PayrollFrequency.SemiMonthly, 0, 5, 0)]
        [TestCase(PayrollFrequency.SemiMonthly, 1, 5, 0)]
        [TestCase(PayrollFrequency.SemiMonthly, 550, 5, 3d)]
        [TestCase(PayrollFrequency.BiWeekly, 2950, 2, 152d)]
        [TestCase(PayrollFrequency.Weekly, 135, 1, 2d)]
        public void Checks_And_Balances(PayrollFrequency frequency, Decimal grossWages, int allowances, Decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.MT, year: 2017) as Montana.TaxTable;

            var result = table.Calculate(grossWages, frequency, allowances);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(PayrollFrequency.SemiMonthly, -1, 5)]
        public void NegativeValues_Checks_And_Balances(PayrollFrequency frequency, Decimal grossWages, int allowances)
        {
            var table = TaxTables.GetForState(StateOrProvince.MT, year: 2017) as Montana.TaxTable;            

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, frequency, allowances));
        }
        
    }
}