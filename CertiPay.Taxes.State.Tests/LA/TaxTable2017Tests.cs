using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.LA
{
    [TestFixture]
    public class TaxTable2017Tests
    {
        [Test]
        //two examples from documentation        
        [TestCase(0, PayrollFrequency.Weekly, FilingStatus.Single, 1, 2, 0)]
        [TestCase(1, PayrollFrequency.Weekly, FilingStatus.Single, 1, 2, 0)]
        [TestCase(700, PayrollFrequency.Weekly, FilingStatus.Single, 1, 2, 19.43)]
        [TestCase(4600, PayrollFrequency.BiWeekly, FilingStatus.Married, 2, 3, 157.12)]
        //pcc verification
        [TestCase(4600, PayrollFrequency.BiWeekly, FilingStatus.Single, 1, 3, 192.59)]
        public void Lousiana_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, FilingStatus filingStatus, int personalExemptions, int dependents, decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.LA, year: 2017) as Louisiana.TaxTable;

            var result = table.Calculate(grossWages, freq, filingStatus, personalExemptions, dependents);

            Assert.AreEqual(expected, result);
        }


        [Test]
        [TestCase(-1, PayrollFrequency.Weekly, FilingStatus.Single, 1, 2)]
        public void NegativeValues_Lousiana_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, FilingStatus filingStatus, int personalExemptions, int dependents)
        {
            var table = TaxTables.GetForState(StateOrProvince.LA, year: 2017) as Louisiana.TaxTable;            

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, freq, filingStatus, personalExemptions, dependents));
        }
       
    }
}