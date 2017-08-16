using CertiPay.Payroll.Common;
using CertiPay.Taxes.State.NewYork;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.NY
{
    [TestFixture]
    public class TaxTable2017Tests
    {
        private NewYork.TaxTable2017 ny2017 = new NewYork.TaxTable2017();

        [Test]        
        [TestCase(0, PayrollFrequency.Monthly, Region.NewYorkState, FilingStatus.Single, 1, 0)]
        [TestCase(1, PayrollFrequency.Monthly, Region.NewYorkState, FilingStatus.Single, 1, 0)]
        [TestCase(1500, PayrollFrequency.Monthly, Region.NewYorkState, FilingStatus.Single, 1, 32.46)]
        [TestCase(1500, PayrollFrequency.Monthly, Region.NewYorkState, FilingStatus.Married, 1, 30.40)]
        [TestCase(1500, PayrollFrequency.Monthly, Region.Yonkers, FilingStatus.Single, 1, 32.46)]
        [TestCase(1500, PayrollFrequency.Monthly, Region.Yonkers, FilingStatus.Married, 1, 30.40)]
        [TestCase(1500, PayrollFrequency.Monthly, Region.NewYorkCity, FilingStatus.Single, 1, 22.78)]
        [TestCase(1500, PayrollFrequency.Monthly, Region.NewYorkCity, FilingStatus.Married, 1, 21.48)]
        public void NewYorkTaxTable2017(decimal grossWages, PayrollFrequency freq, Region region, FilingStatus status, int personalAllowances, decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.NY, year: 2017) as NewYork.TaxTable;

            var result = table.Calculate(grossWages, freq, region, status, personalAllowances);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(-1, PayrollFrequency.Monthly, Region.NewYorkState, FilingStatus.Single, 1)]
        public void NegativeValues_NewYorkTaxTable2017(decimal grossWages, PayrollFrequency freq, Region region, FilingStatus status, int personalAllowances)
        {
            var table = TaxTables.GetForState(StateOrProvince.NY, year: 2017) as NewYork.TaxTable;

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, freq, region, status, personalAllowances));
        }
    }
}