using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.KS
{
    using FilingStatus = Kansas.FilingStatus;

    public class TaxTable2017Tests
    {
        [Test]        
        [TestCase(0, 2, FilingStatus.MarriedOrHoH, PayrollFrequency.SemiMonthly, 0)]
        [TestCase(1, 2, FilingStatus.MarriedOrHoH, PayrollFrequency.SemiMonthly, 0)]
        //example from documentation
        [TestCase(600, 2, FilingStatus.MarriedOrHoH, PayrollFrequency.SemiMonthly, 4.00)]
        //paycheck city verification
        [TestCase(1500, 2, FilingStatus.Single, PayrollFrequency.SemiMonthly, 43.00)]
        [TestCase(50000, 0, FilingStatus.Single, PayrollFrequency.Daily, 2298.00)]
        public void Kansas_2017_Checks_And_Balances(Decimal grossWages, int exemptions, FilingStatus filingStatus, PayrollFrequency payrollFrequency, Decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.KS, year: 2017) as Kansas.TaxTable2017;

            var result = table.Calculate(grossWages, payrollFrequency, filingStatus, exemptions);

            Assert.AreEqual(expected, result);
        }


        [Test]
        [TestCase(-1, 2, FilingStatus.MarriedOrHoH, PayrollFrequency.SemiMonthly)]
        public void NegativeValues_Kansas_2017_Checks_And_Balances(Decimal grossWages, int exemptions, FilingStatus filingStatus, PayrollFrequency payrollFrequency)
        {
            var table = TaxTables.GetForState(StateOrProvince.KS, year: 2017) as Kansas.TaxTable2017;            

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, payrollFrequency, filingStatus, exemptions));
        }
        
    }
}