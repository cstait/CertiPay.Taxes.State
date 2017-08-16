using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.AL
{
    [TestFixture]
    public class TaxTable2017Tests
    {
        [Test]        
        [TestCase(0, PayrollFrequency.Weekly, 41.40, FilingStatus.Married, 2, 0)]
        [TestCase(1, PayrollFrequency.Weekly, 41.40, FilingStatus.Married, 2, 0)]
        //example from page
        [TestCase(850, PayrollFrequency.Weekly, 41.40, FilingStatus.Married, 2, 31.20)]
        //verified with paycheck city
        [TestCase(850, PayrollFrequency.Weekly, 84.62, FilingStatus.Married, 2, 29.04)]
        [TestCase(850, PayrollFrequency.Monthly, 65.83, FilingStatus.Single, 2, 10.88)]
        public void Alabama_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, decimal federalWithholding, Alabama.FilingStatus status, int dependentAllowances, decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.AL, year: 2017) as Alabama.TaxTable;

            var result = table.Calculate(grossWages, freq, federalWithholding, status, dependentAllowances);

            Assert.AreEqual(expected, result);
        }


        [Test]
        [TestCase(-1, PayrollFrequency.Weekly, 41.40, FilingStatus.Married, 2)]
        public void NegativeValues_Alabama_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, decimal federalWithholding, Alabama.FilingStatus status, int dependentAllowances)
        {
            var table = TaxTables.GetForState(StateOrProvince.AL, year: 2017) as Alabama.TaxTable;

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, freq, federalWithholding, status, dependentAllowances));
        }
    }
}