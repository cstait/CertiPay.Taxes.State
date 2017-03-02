﻿using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CertiPay.Taxes.State.Oregon
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.OR; } }

        protected abstract IEnumerable<FederalLimit> FederalLimits { get; }
        protected abstract decimal UpperBracket { get; }
        protected abstract IEnumerable<PersonalAllowance> PersonalAllowances { get; }
        protected abstract IEnumerable<StandardDeduction> StandardDeductions { get; }        

        protected abstract IEnumerable<TaxableWithholding> TaxableWithholdings { get; }

        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, decimal federalWithholding, FilingStatus filingStatus = FilingStatus.Single, int personalAllowances = 1, int dependentAllowances = 0)
        {
            var annualWages = frequency.CalculateAnnualized(grossWages);
            var taxableWages = annualWages;
            taxableWages -= Math.Max(GetFederalLimit(filingStatus, annualWages), federalWithholding);
            taxableWages -= GetStandardDeduction(filingStatus, personalAllowances, annualWages);
            var selected_row = GetTaxWithholding(filingStatus, personalAllowances, annualWages);
            taxableWages = selected_row.TaxBase + ((taxableWages - selected_row.MinWage) * selected_row.TaxRate);
            var taxWithheld = taxableWages - GetPersonalAllowance(filingStatus, personalAllowances, annualWages);

            return frequency.CalculateDeannualized(Math.Max(0, taxWithheld));

        }

        protected virtual Decimal GetStandardDeduction(FilingStatus filingStatus, int personalAllowances, decimal annualWage)
        {
            if (filingStatus == FilingStatus.Single)
                return StandardDeductions
                    .Where(d => d.FilingStatus == filingStatus)
                    .Where(d => d.MinAllowance <= personalAllowances && d.MaxAllowance > personalAllowances)
                    .Select(d => d.Amount)
                    .Single();
            else
                return
                    StandardDeductions
                    .Where(d => d.FilingStatus == FilingStatus.Married)
                    .Select(d => d.Amount)
                    .Single();

        }


        protected virtual Decimal GetPersonalAllowance(FilingStatus filingStatus, int personalAllowances, decimal annualWage)
        {
            return PersonalAllowances
                .Where(p => p.FilingStatus == filingStatus)
                .Where(p => p.MinWage <= annualWage && p.MaxWage > annualWage)
                .Select(x => x.Amount)
                .Single() * personalAllowances;
        }

        protected virtual Decimal GetFederalLimit(FilingStatus filingStatus, decimal annualWage)
        {            
                return FederalLimits
                    .Where(l => l.FilingStatus == filingStatus)
                    .Where(l => l.MinWage <= annualWage && l.MaxWage > annualWage)
                    .Select(l => l.Amount)
                    .Single();

        }

        protected virtual TaxableWithholding GetTaxWithholding(FilingStatus filingStatus, int personalAllowances, decimal annualWage)
        {
            if (annualWage < Decimal.Zero) return new TaxableWithholding { };

            //need to specifiy if it's upper bracket or not, as some of the tables overlap for seperate brackets...
            var upperBracket = (annualWage >= UpperBracket);

            if (filingStatus == FilingStatus.Single)
                return
                    TaxableWithholdings
                    .Where(d => d.UpperBracket == upperBracket)
                    .Where(d => d.FilingStatus == filingStatus)
                    .Where(d => d.MinAllowance <= personalAllowances && d.MaxAllowance > personalAllowances)
                    .Where(d => d.MinWage < annualWage && d.MaxWage > annualWage)
                    .Select(d => d)
                    .Single();
            else
                return
                TaxableWithholdings
                .Where(d => d.UpperBracket == upperBracket)
                .Where(d => d.FilingStatus == filingStatus)
                .Where(d => d.MinWage < annualWage && d.MaxWage > annualWage)
                .Select(d => d)
                .Single();
        }

      

        protected class StandardDeduction
        {
            public FilingStatus FilingStatus { get; set; }
            public Decimal Amount { get; set; }
            public int MinAllowance { get; set; }
            public int MaxAllowance { get; set; }

        }

        protected class FederalLimit : StandardDeduction
        {
            public Decimal MaxWage { get; set; }
            public Decimal MinWage { get; set; }
        }

        protected class TaxableWithholding : FederalLimit
        {
            public Decimal TaxBase { get; set; }
            public Decimal TaxRate { get; set; }
            public bool UpperBracket { get; set; }
        }

        protected class PersonalAllowance : FederalLimit
        {
        }


    }

   
}