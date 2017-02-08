﻿using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CertiPay.Taxes.State.Vermont
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.VT; } }
        public abstract decimal AllowanceValue { get; }
        public abstract IEnumerable<TaxableWithholding> TaxableWithholdings { get; }
        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, FilingStatus filingStatus = FilingStatus.Single, int withholdingAllowances = 1)
        {
            var taxableWages = frequency.CalculateAnnualized(grossWages);            

            taxableWages -= GetWitholdingAllowance(withholdingAllowances);
                                    
            var selected_row = GetTaxWithholding(filingStatus, taxableWages);            

            var taxWithheld = selected_row.TaxBase + ((taxableWages - selected_row.StartingAmount) * selected_row.TaxRate);            

            return frequency.CalculateDeannualized(taxWithheld);
        }

        public decimal GetWitholdingAllowance(int withholdingAllowance)
        {
            return withholdingAllowance * AllowanceValue;
        }

        internal virtual TaxableWithholding GetTaxWithholding(FilingStatus filingStatus, Decimal taxableWages)
        {            
            return
                TaxableWithholdings
                .Where(d => d.FilingStatus == filingStatus)
                .Where(d => d.StartingAmount <= taxableWages)
                .Where(d => taxableWages < d.MaximumWage)
                .Select(d => d)
                .Single();
        }

        public class TaxableWithholding
        {
            public FilingStatus FilingStatus { get; set; } = FilingStatus.Single;

            public Decimal TaxBase { get; set; }

            public Decimal StartingAmount { get; set; }

            public Decimal MaximumWage { get; set; }

            public Decimal TaxRate { get; set; }
        }

        public enum FilingStatus : Byte
        {
            [Display(Name = "Single")]
            Single = 0,

            [Display(Name = "Married")]
            Married = 1
        }
    }

}
