using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.CT
{
    [TestFixture]
    public class TaxTable2017Tests
    {
        //verified with PCC unless noted otherwise
        [Test]        
        [TestCase(0, PayrollFrequency.Monthly, Connecticut.WithholdingCode.A, 1, 0)]
        [TestCase(1, PayrollFrequency.Monthly, Connecticut.WithholdingCode.A, 1, 0)]
        //verified by hand
        [TestCase(1500, PayrollFrequency.Monthly, Connecticut.WithholdingCode.A, 1, 9.00)]
        [TestCase(1500, PayrollFrequency.Monthly, Connecticut.WithholdingCode.B, 1, 0.00)]
        [TestCase(1500, PayrollFrequency.Monthly, Connecticut.WithholdingCode.C, 1, 0.00)]
        [TestCase(1500, PayrollFrequency.Monthly, Connecticut.WithholdingCode.D, 1, 58.33)]
        [TestCase(1500, PayrollFrequency.Monthly, Connecticut.WithholdingCode.F, 1, 1.88)]
        [TestCase(8000, PayrollFrequency.Monthly, Connecticut.WithholdingCode.A, 1, 419.17)]
        [TestCase(8000, PayrollFrequency.Monthly, Connecticut.WithholdingCode.B, 1, 393.33)]
        //verified by hand
        [TestCase(8000, PayrollFrequency.Monthly, Connecticut.WithholdingCode.C, 1, 333.67)]
        [TestCase(8000, PayrollFrequency.Monthly, Connecticut.WithholdingCode.D, 1, 419.17)]
        [TestCase(8000, PayrollFrequency.Monthly, Connecticut.WithholdingCode.F, 1, 415.83)]
        public void CT_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, Connecticut.WithholdingCode employeeCode, int personalAllowances, decimal expected)
        {
            var table = TaxTables.GetForState(StateOrProvince.CT, year: 2017) as Connecticut.TaxTable;

            var result = table.Calculate(grossWages, freq, employeeCode, personalAllowances);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(-1, PayrollFrequency.Monthly, Connecticut.WithholdingCode.A, 1)]
        public void NegativeValues_CT_2017_Checks_And_Balances(decimal grossWages, PayrollFrequency freq, Connecticut.WithholdingCode employeeCode, int personalAllowances)
        {
            var table = TaxTables.GetForState(StateOrProvince.CT, year: 2017) as Connecticut.TaxTable;            

            Assert.Throws<ArgumentOutOfRangeException>(() => table.Calculate(grossWages, freq, employeeCode, personalAllowances));
        }

        
    }
}