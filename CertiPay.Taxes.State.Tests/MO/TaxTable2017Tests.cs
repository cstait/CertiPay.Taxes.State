using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.MO
{
    using FilingStatus = Missouri.TaxTable.FilingStatus;

    public class TaxTable2017Tests
    {
        [Test]                
        //official documentation was off, but matched it up until the final addition        
        [TestCase(PayrollFrequency.Annually, 0, FilingStatus.MarriedWithTwoIncomes, 2270, 2, 0)]
        [TestCase(PayrollFrequency.Annually, 1, FilingStatus.MarriedWithTwoIncomes, 2270, 2, 0)]
        [TestCase(PayrollFrequency.Annually, 30000, FilingStatus.MarriedWithTwoIncomes, 2270, 2, 855)]
        //pcc
        [TestCase(PayrollFrequency.Annually, 9001, FilingStatus.Single, 670.10, 5, 0)]
        [TestCase(PayrollFrequency.Annually, 800000, FilingStatus.MarriedWithOneIncome, 258605.40, 1, 46283)]
        public void Missouri_2017_Checks_And_Balances(PayrollFrequency frequency, Decimal grossWages, FilingStatus filingStatus, decimal federalWithholding, int allowances, Decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.MO, year: 2017) as Missouri.TaxTable2017;

            var result = table.Calculate(grossWages, frequency, filingStatus, federalWithholding, allowances);

            Assert.AreEqual(expected, result);
        }


        [Test]
        [TestCase(PayrollFrequency.Annually, -1, FilingStatus.MarriedWithTwoIncomes, 2270, 2)]
        public void Missouri_2017_Checks_And_Balances(PayrollFrequency frequency, Decimal grossWages, FilingStatus filingStatus, decimal federalWithholding, int allowances)
        {
            var table = TaxTables.GetForState(StateOrProvince.MO, year: 2017) as Missouri.TaxTable2017;

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, frequency, filingStatus, federalWithholding, allowances));
        }
    }
}