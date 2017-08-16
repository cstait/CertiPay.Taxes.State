using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.IN
{
    [TestFixture]
    public class TaxTable2017Tests
    {       

        [Test]        
        [TestCase(0, PayrollFrequency.Weekly, 5, 3, 0)]
        [TestCase(1, PayrollFrequency.Weekly, 5, 3, 0)]
        [TestCase(800, PayrollFrequency.Weekly, 5, 3, 19.94)]       
        public void IN_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, int personalAllowances, int dependentAllowances, decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.IN, year: 2017) as Indiana.TaxTable2017;

            var result = table.Calculate(grossWages, freq, personalAllowances, dependentAllowances);

            Assert.AreEqual(expected, result);
        }


        [Test]
        [TestCase(-1, PayrollFrequency.Weekly, 5, 3)]
        public void NegativeValues_IN_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, int personalAllowances, int dependentAllowances)
        {
            var table = TaxTables.GetForState(StateOrProvince.IN, year: 2017) as Indiana.TaxTable2017;

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, freq, personalAllowances, dependentAllowances));
        }
    }
}