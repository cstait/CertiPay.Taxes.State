using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;
namespace CertiPay.Taxes.State.Tests.KY
{
    [TestFixture]
    public class TaxTable2017Tests
    {       

        [Test]        
        [TestCase(0, PayrollFrequency.Monthly, 1, 0)]
        [TestCase(1, PayrollFrequency.Monthly, 1, 0)]
        //documentation verification
        [TestCase(3020, PayrollFrequency.Monthly, 1, 147.01)]
        //paycheckcity verification
        [TestCase(150000, PayrollFrequency.Monthly, 5, 8955.60)]
        public void Kentucky_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, int exemptions, decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.KY, year: 2017) as Kentucky.TaxTable2017;

            var result = table.Calculate(grossWages, freq, exemptions);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(-1, PayrollFrequency.Monthly, 1)]
        public void NegativeValues_Kentucky_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, int exemptions)
        {
            var table = TaxTables.GetForState(StateOrProvince.KY, year: 2017) as Kentucky.TaxTable2017;

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, freq, exemptions));
        }
    }
}