using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.NJ
{
    using FilingStatus = NewJersey.FilingStatus;

    [TestFixture]
    public class TaxTable2017Tests
    {
        [Test]
        public void Married_SingleIncome_with_Dependents()
        {
            var table = TaxTables.GetForState(StateOrProvince.NJ, year: 2017) as NewJersey.TaxTable;

            var result = table.Calculate(750m, PayrollFrequency.SemiMonthly, FilingStatus.MarriedWithOneIncome, 2);

            Assert.AreEqual(10.00m, result);
        }

        [Test]        
        [TestCase(0, PayrollFrequency.Monthly, FilingStatus.Single, 1, 0)]
        [TestCase(1, PayrollFrequency.Monthly, FilingStatus.Single, 1, 0)]
        [TestCase(1500, PayrollFrequency.Monthly, FilingStatus.Single, 1, 21.25)]
        [TestCase(1500, PayrollFrequency.Monthly, FilingStatus.MarriedWithTwoIncomes, 1, 21.25)]
        [TestCase(1500, PayrollFrequency.Monthly, FilingStatus.MarriedFilingSeparate, 1, 21.25)]
        [TestCase(3000, PayrollFrequency.Monthly, FilingStatus.MarriedFilingSeparate, 1, 50.00)]
        [TestCase(1500, PayrollFrequency.Monthly, FilingStatus.HeadOfHousehold, 1, 21.25)]
        public void Checks_And_Balances(decimal grossWages, PayrollFrequency freq, FilingStatus status, int personalAllowances, decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.NJ, year: 2017) as NewJersey.TaxTable;

            var result = table.Calculate(grossWages, freq, status, personalAllowances);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(-1, PayrollFrequency.Monthly, FilingStatus.Single, 1)]
        public void Checks_And_Balances(decimal grossWages, PayrollFrequency freq, FilingStatus status, int personalAllowances)
        {
            var table = TaxTables.GetForState(StateOrProvince.NJ, year: 2017) as NewJersey.TaxTable;

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, freq, status, personalAllowances));
        }
    }
}