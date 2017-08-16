using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.IL
{
    public class TaxTable2016Tests
    {
        [Test]        
        [TestCase(PayrollFrequency.Weekly, 0, 2, 0, 0)]
        [TestCase(PayrollFrequency.Weekly, 1, 2, 0, 0)]
        [TestCase(PayrollFrequency.Weekly, 450, 2, 0, 13.74d)]
        [TestCase(PayrollFrequency.Weekly, 875, 3, 1, 27.39d)]
        [TestCase(PayrollFrequency.SemiMonthly, 875, 2, 0, 26.02d)]
        [TestCase(PayrollFrequency.SemiMonthly, 875, 1, 1, 27.85d)]
        public void Checks_And_Balances(PayrollFrequency frequency, Decimal grossWages, int basicAllowances, int additionalAllowances, Decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.IL, year: 2016) as Illinois.TaxTable;

            var result = table.Calculate(grossWages, frequency, basicAllowances, additionalAllowances);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(PayrollFrequency.Weekly, -1, 2, 0)]
        public void NegativeValue_Checks_And_Balances(PayrollFrequency frequency, Decimal grossWages, int basicAllowances, int additionalAllowances)
        {
            var table = TaxTables.GetForState(StateOrProvince.IL, year: 2016) as Illinois.TaxTable;

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, frequency, basicAllowances, additionalAllowances));
        }
    }
}