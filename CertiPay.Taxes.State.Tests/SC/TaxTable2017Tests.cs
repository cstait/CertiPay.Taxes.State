using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.SC
{
    public class TaxTable2017Tests
    {
        [Test]        
        [TestCase(0, 0, PayrollFrequency.Monthly, 0)]
        [TestCase(1, 0, PayrollFrequency.Monthly, 0.02)]
        [TestCase(3000, 0, PayrollFrequency.Monthly, 182.72)]
        [TestCase(2500, 0, PayrollFrequency.Monthly, 147.72)]
        [TestCase(3000, 1, PayrollFrequency.Monthly, 152.21)]
        [TestCase(3000, 2, PayrollFrequency.Monthly, 138.38)]
        [TestCase(4000, 0, PayrollFrequency.Monthly, 252.72)]
        [TestCase(4000, 1, PayrollFrequency.Monthly, 222.21)]
        [TestCase(4000, 2, PayrollFrequency.Monthly, 208.38)]
        [TestCase(300, 0, PayrollFrequency.Weekly, 14.70)]
        [TestCase(300, 1, PayrollFrequency.Weekly, 9.41)]
        [TestCase(300, 2, PayrollFrequency.Weekly, 6.49)]
        [TestCase(700, 0, PayrollFrequency.Weekly, 42.7)]
        [TestCase(700, 1, PayrollFrequency.Weekly, 35.66)]
        [TestCase(700, 2, PayrollFrequency.Weekly, 32.47)]
        public void Checks_And_Balances(Decimal grossWages, int exemptions, PayrollFrequency payrollFrequency, Decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.SC, year: 2017) as SouthCarolina.TaxTable;

            var result = table.Calculate(grossWages, payrollFrequency, exemptions);

            Assert.AreEqual(expected, result);
        }


        [Test]
        [TestCase(-1, 0, PayrollFrequency.Monthly)]
        public void NegativeValues_Checks_And_Balances(Decimal grossWages, int exemptions, PayrollFrequency payrollFrequency)
        {
            var table = TaxTables.GetForState(StateOrProvince.SC, year: 2017) as SouthCarolina.TaxTable;

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, payrollFrequency, exemptions));
        }
    }
}