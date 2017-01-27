﻿using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CertiPay.Taxes.State.NewJersey
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.NJ; } }
        
        public abstract IEnumerable<StandardDeduction> PersonalAllowances { get; }
        
        public abstract IEnumerable<TaxableWithholding> TaxableWithholdings { get; }

        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, FilingStatus filingStatus = FilingStatus.Single, int personalAllowances = 1, int dependentAllowances = 0)
        {
            var taxableWages = frequency.CalculateAnnualized(grossWages);
          
            taxableWages -= GetPersonalAllowance(personalAllowances);            

            var selected_row = GetTaxWithholding(filingStatus, taxableWages);

            // Calculate the withholding from the percentages

            var taxWithheld = selected_row.TaxBase + ((taxableWages - selected_row.StartingAmount) * selected_row.TaxRate);

            //(5) If zero exemption is claimed, subtract the standard deduction only.

            return frequency.CalculateDeannualized(taxWithheld);
        }
        

        internal virtual Decimal GetPersonalAllowance(int personalAllowances)
        {          
            return 1000m * personalAllowances;
        }

        internal virtual TaxableWithholding GetTaxWithholding(FilingStatus filingStatus, Decimal taxableWages)
        {
            if (taxableWages < Decimal.Zero) return new TaxableWithholding { };

            return
                TaxableWithholdings
                .Where(d => d.FilingStatus == filingStatus)
                .Where(d => d.StartingAmount <= taxableWages)
                .Where(d => taxableWages < d.MaximumWage)
                .Select(d => d)
                .Single();
        }

        public class StandardDeduction : DependentAllowance
        {
            public FilingStatus FilingStatus { get; set; }
        }

        public class DependentAllowance
        {
            public Decimal Amount { get; set; }
        }

        public class TaxableWithholding
        {
            public FilingStatus FilingStatus { get; set; } = FilingStatus.Single;

            public Decimal TaxBase { get; set; }

            public Decimal StartingAmount { get; set; }

            public Decimal MaximumWage { get; set; }

            public Decimal TaxRate { get; set; }
        }
    }

    public enum FilingStatus : byte
    {
        // A) Single
        // B) Married - 2 incomes
        // C) Married - 1 income
        // D) Married filing separate
        // E) Head of Household

        [Display(Name = "A - Single")]
        Single = 0,

        [Display(Name = "B - Married Filing Jointly, Both Spouses Working")]
        MarriedWithTwoIncomes = 1,

        [Display(Name = "C - Married Filing Jointly, One Spouse Working")]
        MarriedWithOneIncome = 2,

        [Display(Name = "D - Married Filing Separately")]
        MarriedFilingSeparate = 3,

        [Display(Name = "E - Head of Household")]
        HeadOfHousehold = 4
    }
}