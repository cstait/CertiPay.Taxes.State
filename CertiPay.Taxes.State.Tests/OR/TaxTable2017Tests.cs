using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.OR
{
    [TestFixture]
    public class TaxTable2017Tests
    {
        [Test]
        //Verified with Example        
        [TestCase(0, PayrollFrequency.Annually, 1440, FilingStatus.Single, 0, 0)]
        [TestCase(1, PayrollFrequency.Annually, 1440, FilingStatus.Single, 0, 0)]
        [TestCase(15000, PayrollFrequency.Annually, 1440, FilingStatus.Single,  0, 984)]
        //Verified with PCC
        [TestCase(132000, PayrollFrequency.Annually, 22315.0, FilingStatus.Married,  3, 9832.00)]
        [TestCase(132000, PayrollFrequency.Annually, 29297.75, FilingStatus.Single,  3, 10662)]
        public void Oregon_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, decimal federalWithholding, FilingStatus filingStatus, int personalAllowances, decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.OR, year: 2017) as Oregon.TaxTable2017;

            var result = table.Calculate(grossWages, freq, federalWithholding, filingStatus, personalAllowances);

            Assert.AreEqual(expected, result);
        }

        [Test]        
        [TestCase(-1, PayrollFrequency.Annually, 1440, FilingStatus.Single, 0)]
        public void NegativeValue_Oregon_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, decimal federalWithholding, FilingStatus filingStatus, int personalAllowances)
        {
            var table = TaxTables.GetForState(StateOrProvince.OR, year: 2017) as Oregon.TaxTable2017;

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, freq, federalWithholding, filingStatus, personalAllowances));

            
        }
    }
}