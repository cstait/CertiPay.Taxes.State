using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.OK
{
    public class TaxTableTests
    {
        [Test]
        [TestCase(PayrollFrequency.SemiMonthly, 1725, true, 2, 41d)]
        public void Checks_And_Balances_2016(PayrollFrequency frequency, Decimal grossWages, Boolean isMarried, int allowances, Decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.OK, year: 2016) as Oklahoma.TaxTable;

            var result = table.Calculate(grossWages, frequency, isMarried, allowances);

            Assert.AreEqual(expected, result);
        }

        [Test]        
        [TestCase(PayrollFrequency.SemiMonthly, 0, true, 2, 0)]
        [TestCase(PayrollFrequency.SemiMonthly, 1, true, 2, 0)]
        [TestCase(PayrollFrequency.SemiMonthly, 1825, true, 2, 46d)]
        [TestCase(PayrollFrequency.BiWeekly, 2500, true, 2, 83d)]
        public void Checks_And_Balances_2017(PayrollFrequency frequency, Decimal grossWages, Boolean isMarried, int allowances, Decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.OK, year: 2017) as Oklahoma.TaxTable;

            var result = table.Calculate(grossWages, frequency, isMarried, allowances);

            Assert.AreEqual(expected, result);
        }


        [Test]
        [TestCase(PayrollFrequency.SemiMonthly, -1, true, 2)]
        public void NegativeValues_Checks_And_Balances_2017(PayrollFrequency frequency, Decimal grossWages, Boolean isMarried, int allowances)
        {
            var table = TaxTables.GetForState(StateOrProvince.OK, year: 2017) as Oklahoma.TaxTable;            

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, frequency, isMarried, allowances));
        }
        
    }
}