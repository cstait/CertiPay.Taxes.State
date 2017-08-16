using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.SC
{
    public class TaxTable2016Tests
    {
        [Test]
        [TestCase(3000, 0, PayrollFrequency.Monthly, 185)]
        [TestCase(2500, 0, PayrollFrequency.Monthly, 150)]
        [TestCase(3000, 1, PayrollFrequency.Monthly, 156.42)]
        [TestCase(3000, 2, PayrollFrequency.Monthly, 143)]
        [TestCase(4000, 0, PayrollFrequency.Monthly, 255)]
        [TestCase(4000, 1, PayrollFrequency.Monthly, 226.42)]
        [TestCase(4000, 2, PayrollFrequency.Monthly, 213)]
        [TestCase(300, 0, PayrollFrequency.Weekly, 15.23)]
        [TestCase(300, 1, PayrollFrequency.Weekly, 10.03)]
        [TestCase(300, 2, PayrollFrequency.Weekly, 7.05)]
        [TestCase(700, 0, PayrollFrequency.Weekly, 43.23)]
        [TestCase(700, 1, PayrollFrequency.Weekly, 36.63)]
        [TestCase(700, 2, PayrollFrequency.Weekly, 33.54)]
        public void Checks_And_Balances(Decimal grossWages, int exemptions, PayrollFrequency payrollFrequency, Decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.SC, year: 2016) as SouthCarolina.TaxTable;

            var result = table.Calculate(grossWages, payrollFrequency, exemptions);

            Assert.AreEqual(expected, result);
        }
    }
}