using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.AR
{
    [TestFixture]
    public class TaxTable2017Tests
    {
        [Test]       
        [TestCase(0, PayrollFrequency.Monthly, 2, 0)]
        [TestCase(1, PayrollFrequency.Monthly, 2, 0)]
        [TestCase(2127, PayrollFrequency.Monthly, 2, 61.35)]
        [TestCase(1250, PayrollFrequency.Weekly, 2, 64.25)]
        [TestCase(954, PayrollFrequency.Weekly, 1, 44.38)]
        public void AR_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency frequency, int exemptions, decimal expected)
        {            
            var taxTable = TaxTables.GetForState(StateOrProvince.AR, year: 2017) as Arkansas.TaxTable;

            var result = taxTable.Calculate(grossWages, frequency, exemptions);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(PayrollFrequency.Weekly, 25, 5)]
        [TestCase(PayrollFrequency.Annually, 2500, 5)]
        public void Ensure_Guards_For_Wage_Ranges(PayrollFrequency frequency, Decimal grossWages, int exemptions)
        {
            var taxTable = TaxTables.GetForState(StateOrProvince.AR, year: 2017) as Arkansas.TaxTable;

            var result = taxTable.Calculate(grossWages, frequency, exemptions);

            Assert.AreEqual(Decimal.Zero, result);
        }

        [Test]
        [TestCase(-1, PayrollFrequency.Monthly, 2)]
        public void NegativeValues_AR_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency frequency, int exemptions)
        {
            var taxTable = TaxTables.GetForState(StateOrProvince.AR, year: 2017) as Arkansas.TaxTable;

            Assert.Throws<ArgumentOutOfRangeException>(() => taxTable.Calculate(grossWages, frequency, exemptions));
        }
    }

}