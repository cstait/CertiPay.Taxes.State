using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.NM
{
    [TestFixture]
    public class TaxTable2017Tests
    {
        [Test]
        //Verified with PCC        
        [TestCase(0, PayrollFrequency.BiWeekly, FilingStatus.Married, 2, 0)]
        [TestCase(1, PayrollFrequency.BiWeekly, FilingStatus.Married, 2, 0)]
        [TestCase(2205, PayrollFrequency.BiWeekly, FilingStatus.Married, 2, 60.79)]
        [TestCase(2205, PayrollFrequency.BiWeekly, FilingStatus.Single, 0, 92.96)]
        [TestCase(5, PayrollFrequency.BiWeekly, FilingStatus.Married, 2, 0)]
        public void NewMexico_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, FilingStatus filingStatus, int personalAllowances, decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.NM, year: 2017) as NewMexico.TaxTable2017;

            var result = table.Calculate(grossWages, freq, filingStatus, personalAllowances);

            Assert.AreEqual(expected, result);
        }

        [Test]        
        [TestCase(-1, PayrollFrequency.BiWeekly, FilingStatus.Married, 2)]
        public void NewMexico_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, FilingStatus filingStatus, int personalAllowances)
        {
            var table = TaxTables.GetForState(StateOrProvince.NM, year: 2017) as NewMexico.TaxTable2017;

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, freq, filingStatus, personalAllowances));
        }
    }
}