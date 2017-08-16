using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;

namespace CertiPay.Taxes.State.Tests.AZ
{
    [TestFixture]
    public class TaxTable2017Tests
    {       
         
        [Test]        
        [TestCase(0, Arizona.TaxRate.FivePointOnePercent, 0)]
        [TestCase(1, Arizona.TaxRate.FivePointOnePercent, 0.051)]
        [TestCase(1500, Arizona.TaxRate.FivePointOnePercent, 76.5)]      
        public void AZ_2017_Checks_And_Balances(decimal grossWages, Arizona.TaxRate rate, decimal expected)
        {
            var taxTable = TaxTables.GetForState(StateOrProvince.AZ, 2017) as Arizona.TaxTable;
            
            var result = taxTable.Calculate(grossWages, rate);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(-1, Arizona.TaxRate.FivePointOnePercent)]
        public void NegativeValues_AZ_2017_Checks_And_Balances(decimal grossWages, Arizona.TaxRate rate)
        {
            var taxTable = TaxTables.GetForState(StateOrProvince.AZ, 2017) as Arizona.TaxTable;

            Assert.Throws<ArgumentOutOfRangeException>(() => taxTable.Calculate(grossWages, rate));
        }

    }
}