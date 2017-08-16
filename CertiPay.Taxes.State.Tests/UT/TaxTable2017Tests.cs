using CertiPay.Payroll.Common;
using NUnit.Framework;

namespace CertiPay.Taxes.State.Tests.UT
{
    [TestFixture]
    public class TaxTable2017Tests
    {
        [Test]
        //verified with PCC
        
        [TestCase(0, PayrollFrequency.Weekly, FilingStatus.Single, 1, 0)]
        [TestCase(1, PayrollFrequency.Weekly, FilingStatus.Single, 1, 0)]
        [TestCase(400, PayrollFrequency.Weekly, FilingStatus.Single, 1, 14.99)]
        [TestCase(2500, PayrollFrequency.Monthly, FilingStatus.Married, 3, 75.5)]
        [TestCase(1000, PayrollFrequency.BiWeekly, FilingStatus.Single, 2, 37.77)]
        [TestCase(855, PayrollFrequency.SemiMonthly, FilingStatus.Married, 4, 7.66)]
        public void Utah_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, FilingStatus filingStatus, int personalAllowances, decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.UT, year: 2017) as Utah.TaxTable;

            var result = table.Calculate(grossWages, freq, filingStatus, personalAllowances);

            Assert.AreEqual(expected, result);
        }



        [Test]
        [TestCase(-1, PayrollFrequency.Weekly, FilingStatus.Single, 1)]
        public void NegativeValue_Utah_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, FilingStatus filingStatus, int personalAllowances)
        {
            var table = TaxTables.GetForState(StateOrProvince.UT, year: 2017) as Utah.TaxTable;

            Assert.Throws<System.ArgumentOutOfRangeException>(() => table.Calculate(grossWages, freq, filingStatus, personalAllowances));
        }

        
    }
}

