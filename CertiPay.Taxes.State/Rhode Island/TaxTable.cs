using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CertiPay.Taxes.State.RhodeIsland
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.RI; } }

        public abstract Decimal ExemptionAmount { get; }   
        
        public abstract Decimal ExemptionExclusionAmount { get; }     
        
        public abstract IEnumerable<TaxableWithholding> TaxableWithholdings { get; }

        /// <summary>
        /// Returns Rhode Island State Withholding when given a non-negative values for Gross Wages and Personal Allowances.
        /// </summary>
        /// <param name="grossWages"></param>
        /// <param name="frequency"></param>
        /// <param name="personalAllowances"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Negative Values entered.</exception>
        /// <returns></returns>
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, int personalAllowances = 1)
        {
            if (grossWages < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(grossWages)} cannot be a negative number");
            if (personalAllowances < Decimal.Zero) throw new ArgumentOutOfRangeException($"{nameof(personalAllowances)} cannot be a negative number");
            
            var taxableWages = frequency.CalculateAnnualized(grossWages);
                     
            taxableWages -= GetPersonalAllowance(taxableWages, personalAllowances);

            if (taxableWages <= 0)
                return 0;

            var selected_row = GetTaxWithholding(taxableWages);

            var taxWithheld = selected_row.TaxBase + ((taxableWages - selected_row.StartingAmount) * selected_row.TaxRate);            

            return frequency.CalculateDeannualized(taxWithheld);
        }
    
        internal virtual Decimal GetPersonalAllowance(decimal taxableWages, int personalAllowances = 1)
        {                
            if (taxableWages < ExemptionExclusionAmount)
            {
                return ExemptionAmount * personalAllowances;
            }

            return 0;
        }
        

        internal virtual TaxableWithholding GetTaxWithholding(Decimal taxableWages)
        {
            if (taxableWages < Decimal.Zero) return new TaxableWithholding { };

            return
                TaxableWithholdings                
                .Where(d => d.StartingAmount <= taxableWages)
                .Where(d => taxableWages < d.MaximumWage)
                .Select(d => d)
                .Single();
        }
  

        public class TaxableWithholding
        {            
            public Decimal TaxBase { get; set; }

            public Decimal StartingAmount { get; set; }

            public Decimal MaximumWage { get; set; }

            public Decimal TaxRate { get; set; }
        }
    }
}