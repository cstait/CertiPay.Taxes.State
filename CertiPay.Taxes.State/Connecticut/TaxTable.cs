﻿using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CertiPay.Taxes.State.Connecticut
{
    public abstract class TaxTable : TaxTableHeader
    {
        public override StateOrProvince State { get { return StateOrProvince.CT; } }        
        public abstract IEnumerable<TaxableWithholding> TaxableWithholdings { get; }
        public abstract IEnumerable<AddBack> PhaseOutAddBackTaxes { get; }
        public abstract IEnumerable<PersonalTaxCredit> PersonalTaxRate { get; }
        public abstract IEnumerable<TaxRecapture> TaxRecaptureRates { get; }

        public abstract decimal CodeACeiling { get; }
        public abstract decimal CodeBCeiling { get; }
        public abstract decimal CodeCCeiling { get; }
        public abstract decimal CodeDCeiling { get; }
        public abstract decimal CodeECeiling { get; }

        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, WitholdingCode EmployeeCode, int exemptions = 1)
        {
            var annualizedSalary = frequency.CalculateAnnualized(grossWages);

            var taxableWages = annualizedSalary;            

            taxableWages -= GetExemptionAmount(taxableWages, EmployeeCode, exemptions);

            var withHolding = GetTaxWithholding(EmployeeCode, taxableWages);

            taxableWages = withHolding.TaxBase + ((taxableWages - withHolding.StartingAmount) * withHolding.TaxRate);
            taxableWages += CheckAddBack(EmployeeCode, annualizedSalary);
            taxableWages += GetTaxRecapture(EmployeeCode, annualizedSalary);
            var taxWithheld = taxableWages * GetPersonalTaxCredits(EmployeeCode, annualizedSalary);

            return frequency.CalculateDeannualized(taxWithheld);
        }

        internal virtual Decimal CheckAddBack(WitholdingCode EmployeeCode, decimal annualizedSalary)
        {
            var addback = PhaseOutAddBackTaxes.Where(x => x.EmployeeCode == EmployeeCode).Select(x => x).Single();

            if (annualizedSalary >= addback.CeilingAmount)
                return (10 * addback.Amount);
            else if (annualizedSalary <= addback.FloorAmount)
                return 0;
            else
                return ((int)(((annualizedSalary - addback.CeilingAmount) / addback.intervalAmount) + 10) * addback.Amount);

        }
        internal virtual Decimal GetTaxRecapture(WitholdingCode EmployeeCode, decimal annualizedSalary)
        {
            return TaxRecaptureRates
                .Where(x => x.EmployeeCode == EmployeeCode && (annualizedSalary >= x.CeilingAmount && annualizedSalary <= x.FloorAmount))
                .Select(x => x.Amount).Single();
        }
        internal virtual Decimal GetPersonalTaxCredits(WitholdingCode EmployeeCode, decimal annualizedSalary)
        {
            return annualizedSalary * PersonalTaxRate
                .Where(x => x.EmployeeCode == EmployeeCode && (annualizedSalary >= x.CeilingAmount && annualizedSalary <= x.FloorAmount))
                .Select(x => x.Amount).Single();
        }
        internal virtual Decimal GetExemptionAmount(decimal taxableWages, WitholdingCode EmployeeCode, int exemptions)
        {
            switch (EmployeeCode)
            {
                case WitholdingCode.A:
                    return exemptions * Math.Abs(taxableWages - CodeACeiling);
                case WitholdingCode.B:
                    return exemptions * Math.Abs(taxableWages - CodeBCeiling);
                case WitholdingCode.C:
                    return exemptions * Math.Abs(taxableWages - CodeCCeiling);
                case WitholdingCode.D:
                    return 0;
                case WitholdingCode.F:
                    return exemptions * Math.Abs(taxableWages - CodeECeiling);
                default:
                    return 0.00m;
            }
        }



        internal virtual TaxableWithholding GetTaxWithholding(WitholdingCode employeeCode, Decimal taxableWages)
        {
            return
                TaxableWithholdings
                .Where(d => d.EmployeeCode == employeeCode)
                .Where(d => d.StartingAmount <= taxableWages)
                .Where(d => taxableWages < d.MaximumWage)
                .Select(d => d)
                .Single();
        }

   
        public class TaxableWithholding
        {
            public WitholdingCode EmployeeCode { get; set; }

            public Decimal TaxBase { get; set; }

            public Decimal StartingAmount { get; set; }

            public Decimal MaximumWage { get; set; }

            public Decimal TaxRate { get; set; }
        }


        public class EmployeeWitholdingCode
        {
            public WitholdingCode Code { get; set; }
            public decimal StartingAmount { get; set; }

            public decimal EndingAmount { get; set; }
        }

        public class AddBack
        {
            public decimal Amount { get; set; }
            public decimal CeilingAmount { get; set; }
            public decimal FloorAmount { get; set; }
            public int intervalAmount { get; set; }
            public WitholdingCode EmployeeCode { get; set; }
        }

        public class TaxRecapture : AddBack
        {

        }

        public class PersonalTaxCredit : AddBack
        {

        }

        public enum WitholdingCode : byte
        {
            [Display(Name = "A")]
            A = 0,

            [Display(Name = "B")]
            B = 1,

            [Display(Name = "C")]
            C = 2,

            [Display(Name = "D")]
            D = 3,

            [Display(Name = "E")]
            E = 4,

            [Display(Name = "F")]
            F = 5
        }
    }
}