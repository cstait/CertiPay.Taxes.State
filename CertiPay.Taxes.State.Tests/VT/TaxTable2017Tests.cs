using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.VT
{
    public class TaxTable2017Tests
    {
        [Test]
        
        [TestCase(0, 1, FilingStatus.Single, PayrollFrequency.Monthly, 0)]
        [TestCase(1, 1, FilingStatus.Single, PayrollFrequency.Monthly, 0)]
        [TestCase(3000, 1, FilingStatus.Married, PayrollFrequency.Monthly, 70.85)]
        [TestCase(2500, 1, FilingStatus.Single, PayrollFrequency.Monthly, 68.93)]
        public void VT_2017_Checks_And_Balances(Decimal grossWages, int exemptions, FilingStatus filingStatus, PayrollFrequency payrollFrequency, Decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.VT, year: 2017) as Vermont.TaxTable;

            var result = table.Calculate(grossWages, payrollFrequency, filingStatus, exemptions);

            Assert.AreEqual(expected, result);
        }



        [Test]
        [TestCase(-1, 1, FilingStatus.Single, PayrollFrequency.Monthly)]
        public void NegativeValues_VT_2017_Checks_And_Balances(Decimal grossWages, int exemptions, FilingStatus filingStatus, PayrollFrequency payrollFrequency)
        {
            var table = TaxTables.GetForState(StateOrProvince.WI, year: 2017) as Wisconsin.TaxTable2017;

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, payrollFrequency, filingStatus, exemptions));

        }
    }
}