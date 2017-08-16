using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.CO
{

    public class TaxTableTests
    {
        [Test]       
        [TestCase(PayrollFrequency.Weekly, 0, FilingStatus.Single, 1, 0)]
        [TestCase(PayrollFrequency.Weekly, 1, FilingStatus.Single, 1, 0)]
        //verified with pcc
        [TestCase(PayrollFrequency.Weekly, 210, FilingStatus.Single, 1, 4.00)]
        [TestCase(PayrollFrequency.Weekly, 1250, FilingStatus.Married, 2, 43.00)]
        [TestCase(PayrollFrequency.Weekly, 500, FilingStatus.Married, 4, 1.00)]
        public void Colorado_2017_Checks_And_Balances(PayrollFrequency frequency, Decimal grossWages, FilingStatus status, int allowances, Decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.CO, year: 2017) as Colorado.TaxTable2017;

            var result = table.Calculate(grossWages, frequency, status, allowances);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(PayrollFrequency.Weekly, -1, FilingStatus.Single, 1)]
        public void NegativeValues_Colorado_2017_Checks_And_Balances(PayrollFrequency frequency, Decimal grossWages, FilingStatus status, int allowances)
        {
            var table = TaxTables.GetForState(StateOrProvince.CO, year: 2017) as Colorado.TaxTable2017;

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, frequency, status, allowances));
        }
    }
}



