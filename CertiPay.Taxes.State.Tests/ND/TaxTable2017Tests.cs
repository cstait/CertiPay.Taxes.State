using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.ND
{
    [TestFixture]
    public class TaxTable2017Tests
    {
        [Test]
        //Documentation example        
        [TestCase(0, PayrollFrequency.Weekly, FilingStatus.Single, 2, 0)]
        [TestCase(1, PayrollFrequency.Weekly, FilingStatus.Single, 2, 0)]
        [TestCase(600, PayrollFrequency.Weekly, FilingStatus.Single, 2, 4.00)]
        //PCC
        [TestCase(3000, PayrollFrequency.BiWeekly, FilingStatus.Married, 2, 25.00)]
        [TestCase(9001, PayrollFrequency.BiWeekly, FilingStatus.Single, 0, 186.00)]

        public void NorthDakota_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, FilingStatus filingStatus, int personalAllowances, decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.ND, year: 2017) as NorthDakota.TaxTable2017;

            var result = table.Calculate(grossWages, freq, filingStatus, personalAllowances);

            Assert.AreEqual(expected, result);
        }


        [Test]        
        [TestCase(-1, PayrollFrequency.Weekly, FilingStatus.Single, 2)]
        public void NorthDakota_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, FilingStatus filingStatus, int personalAllowances)
        {
            var table = TaxTables.GetForState(StateOrProvince.ND, year: 2017) as NorthDakota.TaxTable2017;

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, freq, filingStatus, personalAllowances));
        }
    }
}