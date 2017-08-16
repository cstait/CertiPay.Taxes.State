using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.OH
{
    [TestFixture]
    public class TaxTable2017Tests
    {        

        [Test]        
        [TestCase(0, PayrollFrequency.Monthly, 1, 0)]
        [TestCase(1, PayrollFrequency.Monthly, 1, 0)]
        [TestCase(1500, PayrollFrequency.Monthly, 1, 21.66)]
        [TestCase(1500, PayrollFrequency.Monthly, 3, 18.65)]
        [TestCase(80000, PayrollFrequency.Monthly, 5, 4256.87)]

        public void Ohio_2017_TaxTable(decimal grossWages, PayrollFrequency freq, int exemptions, decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.OH, year: 2017) as Ohio.TaxTable2017;

            var result = table.Calculate(grossWages, freq, exemptions);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(-1, PayrollFrequency.Monthly, 1)]
        public void NegativeValues_Ohio_2017_TaxTable(decimal grossWages, PayrollFrequency freq, int exemptions)
        {
            var table = TaxTables.GetForState(StateOrProvince.OH, year: 2017) as Ohio.TaxTable2017;

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, freq, exemptions));
        }
    }
}