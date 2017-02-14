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
        public abstract IEnumerable<ExemptionValue> ExemptionValues { get; }

        public virtual Decimal Calculate(Decimal grossWages, PayrollFrequency frequency, WithholdingCode employeeCode, int exemptions = 1, decimal additionalWithholding = 0, decimal reducedWithholding = 0)
        {
            if (employeeCode == WithholdingCode.E)
                return 0;

            var annualizedSalary = frequency.CalculateAnnualized(grossWages);

            var taxableWages = annualizedSalary;

            taxableWages -= GetExemptionAmount(taxableWages, employeeCode, exemptions);
            if (taxableWages > 0)
            {
                var withHolding = GetTaxWithholding(employeeCode, taxableWages);

                taxableWages = withHolding.TaxBase + ((taxableWages - withHolding.StartingAmount) * withHolding.TaxRate);
                taxableWages += CheckAddBack(employeeCode, annualizedSalary);
                taxableWages += GetTaxRecapture(employeeCode, annualizedSalary);
                var taxWithheld = taxableWages * (1 - GetPersonalTaxCredits(employeeCode, annualizedSalary));

                taxWithheld = frequency.CalculateDeannualized(taxWithheld);
                taxWithheld += additionalWithholding;
                taxWithheld -= reducedWithholding;
                return Math.Max(taxWithheld, 0);
            }
            else
            {
                taxableWages += additionalWithholding;
                taxableWages -= reducedWithholding;
                return Math.Max(taxableWages, 0);
            }
        }

        internal virtual Decimal CheckAddBack(WithholdingCode EmployeeCode, decimal annualizedSalary)
        {
            return PhaseOutAddBackTaxes
                .Where(x => x.EmployeeCode == EmployeeCode)
                .First(x => x.FloorAmount <= annualizedSalary && x.CeilingAmount > annualizedSalary)
                .Amount;
        }

        internal virtual Decimal GetTaxRecapture(WithholdingCode EmployeeCode, decimal annualizedSalary)
        {
            return TaxRecaptureRates
                .Where(x => x.EmployeeCode == EmployeeCode)
                .First(x => x.FloorAmount <= annualizedSalary && x.CeilingAmount > annualizedSalary)
                .Amount;
        }

        internal virtual Decimal GetPersonalTaxCredits(WithholdingCode EmployeeCode, decimal annualizedSalary)
        {
            return PersonalTaxRate
                .Where(x => x.EmployeeCode == EmployeeCode)
                .First(x => x.FloorAmount <= annualizedSalary && x.CeilingAmount > annualizedSalary)
                .Amount;
        }

        internal virtual Decimal GetExemptionAmount(decimal taxableWages, WithholdingCode EmployeeCode, int exemptions)
        {
            return ExemptionValues
               .Where(x => x.EmployeeCode == EmployeeCode)
               .First(x => x.FloorAmount <= taxableWages && x.CeilingAmount > taxableWages)
               .Amount;
        }

        internal virtual TaxableWithholding GetTaxWithholding(WithholdingCode employeeCode, Decimal taxableWages)
        {
            return
                TaxableWithholdings
                .Where(d => d.EmployeeCode == employeeCode)
                .Where(d => d.StartingAmount <= taxableWages)
                .First(d => taxableWages < d.MaximumWage);
        }

        public class TaxableWithholding
        {
            public WithholdingCode EmployeeCode { get; set; }

            public Decimal TaxBase { get; set; }

            public Decimal StartingAmount { get; set; }

            public Decimal MaximumWage { get; set; }

            public Decimal TaxRate { get; set; }
        }

        public class EmployeeWithholdingCode
        {
            public WithholdingCode Code { get; set; }
            public decimal StartingAmount { get; set; }

            public decimal EndingAmount { get; set; }
        }

        public class AddBack
        {
            public decimal Amount { get; set; }
            public decimal CeilingAmount { get; set; }
            public decimal FloorAmount { get; set; }
            public WithholdingCode EmployeeCode { get; set; }
        }

        public class TaxRecapture : AddBack
        {
        }

        public class PersonalTaxCredit : AddBack
        {
        }

        public class ExemptionValue : AddBack
        {
        }
    }

    public enum WithholdingCode : byte
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