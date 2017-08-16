using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.WV
{
    using FilingStatus = WestVirginia.FilingStatus;

    public class TaxTableTests
    {
        [Test]        
        [TestCase(PayrollFrequency.SemiMonthly, 0, FilingStatus.Two_Earnings, 2, 0d)]
        [TestCase(PayrollFrequency.SemiMonthly, 1, FilingStatus.Two_Earnings, 2, 0d)]
        [TestCase(PayrollFrequency.SemiMonthly, 1250, FilingStatus.Two_Earnings, 2, 44d)]
        public void Checks_And_Balances(PayrollFrequency frequency, Decimal grossWages, FilingStatus status, int allowances, Decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.WV, year: 2017) as WestVirginia.TaxTable;

            var result = table.Calculate(grossWages, frequency, status, allowances);

            Assert.AreEqual(expected, result);
        }


        [Test]
        [TestCase(PayrollFrequency.SemiMonthly, -1, FilingStatus.Two_Earnings, 2)]
        public void NegativeValues_Checks_And_Balances(PayrollFrequency frequency, Decimal grossWages, FilingStatus status, int allowances)
        {
            var table = TaxTables.GetForState(StateOrProvince.WV, year: 2017) as WestVirginia.TaxTable;            

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, frequency, status, allowances));
        }
    }
}