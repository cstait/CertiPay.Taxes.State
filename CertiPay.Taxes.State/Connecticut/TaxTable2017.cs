using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.Connecticut
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 9500; } }

        public override IEnumerable<ExemptionValue> ExemptionValues
        {
            get
            {
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.A, FloorAmount = 0.00m, CeilingAmount = 24000.00m, Amount = 12000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.A, FloorAmount = 24000.00m, CeilingAmount = 25000.00m, Amount = 11000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.A, FloorAmount = 25000.00m, CeilingAmount = 26000.00m, Amount = 10000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.A, FloorAmount = 26000.00m, CeilingAmount = 27000.00m, Amount = 90000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.A, FloorAmount = 27000.00m, CeilingAmount = 28000.00m, Amount = 80000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.A, FloorAmount = 28000.00m, CeilingAmount = 29000.00m, Amount = 70000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.A, FloorAmount = 29000.00m, CeilingAmount = 30000.00m, Amount = 60000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.A, FloorAmount = 30000.00m, CeilingAmount = 31000.00m, Amount = 50000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.A, FloorAmount = 31000.00m, CeilingAmount = 32000.00m, Amount = 40000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.A, FloorAmount = 32000.00m, CeilingAmount = 33000.00m, Amount = 30000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.A, FloorAmount = 33000.00m, CeilingAmount = 34000.00m, Amount = 20000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.A, FloorAmount = 34000.00m, CeilingAmount = 35000.00m, Amount = 10000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.A, FloorAmount = 35000.00m, CeilingAmount = decimal.MaxValue, Amount = 0.00m };

                yield return new ExemptionValue { EmployeeCode = WithholdingCode.B, FloorAmount = 0.00m, CeilingAmount = 38000.00m, Amount = 19000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.B, FloorAmount = 38000.00m, CeilingAmount = 39000.00m, Amount = 18000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.B, FloorAmount = 39000.00m, CeilingAmount = 40000.00m, Amount = 17000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.B, FloorAmount = 40000.00m, CeilingAmount = 41000.00m, Amount = 16000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.B, FloorAmount = 41000.00m, CeilingAmount = 42000.00m, Amount = 15000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.B, FloorAmount = 42000.00m, CeilingAmount = 43000.00m, Amount = 14000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.B, FloorAmount = 43000.00m, CeilingAmount = 44000.00m, Amount = 13000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.B, FloorAmount = 44000.00m, CeilingAmount = 45000.00m, Amount = 12000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.B, FloorAmount = 45000.00m, CeilingAmount = 46000.00m, Amount = 11000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.B, FloorAmount = 46000.00m, CeilingAmount = 47000.00m, Amount = 10000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.B, FloorAmount = 47000.00m, CeilingAmount = 48000.00m, Amount =  9000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.B, FloorAmount = 48000.00m, CeilingAmount = 49000.00m, Amount =  8000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.B, FloorAmount = 49000.00m, CeilingAmount = 50000.00m, Amount =  7000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.B, FloorAmount = 50000.00m, CeilingAmount = 51000.00m, Amount =  6000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.B, FloorAmount = 51000.00m, CeilingAmount = 52000.00m, Amount =  5000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.B, FloorAmount = 52000.00m, CeilingAmount = 53000.00m, Amount =  4000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.B, FloorAmount = 53000.00m, CeilingAmount = 54000.00m, Amount =  3000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.B, FloorAmount = 54000.00m, CeilingAmount = 55000.00m, Amount =  2000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.B, FloorAmount = 55000.00m, CeilingAmount = 56000.00m, Amount =  1000.00m };                
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.B, FloorAmount = 56000.00m, CeilingAmount = decimal.MaxValue, Amount = 0.00m };

                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 0.00m, CeilingAmount = 48000.00m, Amount = 24000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 48000.00m, CeilingAmount = 49000.00m, Amount = 23000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 49000.00m, CeilingAmount = 50000.00m, Amount = 22000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 50000.00m, CeilingAmount = 51000.00m, Amount = 21000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 51000.00m, CeilingAmount = 52000.00m, Amount = 20000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 52000.00m, CeilingAmount = 53000.00m, Amount = 19000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 53000.00m, CeilingAmount = 54000.00m, Amount = 18000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 54000.00m, CeilingAmount = 55000.00m, Amount = 17000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 55000.00m, CeilingAmount = 56000.00m, Amount = 16000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 56000.00m, CeilingAmount = 57000.00m, Amount = 15000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 57000.00m, CeilingAmount = 58000.00m, Amount = 14000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 58000.00m, CeilingAmount = 59000.00m, Amount = 13000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 59000.00m, CeilingAmount = 60000.00m, Amount = 12000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 60000.00m, CeilingAmount = 61000.00m, Amount = 11000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 61000.00m, CeilingAmount = 62000.00m, Amount = 10000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 62000.00m, CeilingAmount = 63000.00m, Amount = 9000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 63000.00m, CeilingAmount = 64000.00m, Amount = 8000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 64000.00m, CeilingAmount = 65000.00m, Amount = 7000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 65000.00m, CeilingAmount = 66000.00m, Amount = 6000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 66000.00m, CeilingAmount = 67000.00m, Amount = 5000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 67000.00m, CeilingAmount = 68000.00m, Amount = 4000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 68000.00m, CeilingAmount = 69000.00m, Amount = 3000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 69000.00m, CeilingAmount = 70000.00m, Amount = 2000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 70000.00m, CeilingAmount = 71000.00m, Amount = 1000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.C, FloorAmount = 71000.00m, CeilingAmount = decimal.MaxValue, Amount = 0.00m };

                yield return new ExemptionValue { EmployeeCode = WithholdingCode.F, FloorAmount = 0.00m, CeilingAmount = 30000.00m, Amount = 15000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.F, FloorAmount = 30000.00m, CeilingAmount = 31000.00m, Amount = 14000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.F, FloorAmount = 31000.00m, CeilingAmount = 32000.00m, Amount = 13000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.F, FloorAmount = 32000.00m, CeilingAmount = 33000.00m, Amount = 12000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.F, FloorAmount = 33000.00m, CeilingAmount = 34000.00m, Amount = 11000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.F, FloorAmount = 34000.00m, CeilingAmount = 35000.00m, Amount = 10000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.F, FloorAmount = 35000.00m, CeilingAmount = 36000.00m, Amount =  9000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.F, FloorAmount = 36000.00m, CeilingAmount = 37000.00m, Amount =  8000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.F, FloorAmount = 37000.00m, CeilingAmount = 38000.00m, Amount =  7000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.F, FloorAmount = 38000.00m, CeilingAmount = 39000.00m, Amount =  6000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.F, FloorAmount = 39000.00m, CeilingAmount = 40000.00m, Amount =  5000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.F, FloorAmount = 40000.00m, CeilingAmount = 41000.00m, Amount =  4000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.F, FloorAmount = 41000.00m, CeilingAmount = 42000.00m, Amount =  3000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.F, FloorAmount = 42000.00m, CeilingAmount = 43000.00m, Amount =  2000.00m };
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.F, FloorAmount = 43000.00m, CeilingAmount = 44000.00m, Amount =  1000.00m };                
                yield return new ExemptionValue { EmployeeCode = WithholdingCode.F, FloorAmount = 44000.00m, CeilingAmount = decimal.MaxValue, Amount = 0.00m };

                yield return new ExemptionValue { EmployeeCode = WithholdingCode.D, FloorAmount = 0.00m, CeilingAmount = decimal.MaxValue, Amount = 0.00m };
            }
        }

        public override IEnumerable<AddBack> PhaseOutAddBackTaxes
        {
            get
            {
                yield return new AddBack { EmployeeCode = WithholdingCode.A, FloorAmount = 0.00m, CeilingAmount = 50250.00m, Amount = 0.00m};
                yield return new AddBack { EmployeeCode = WithholdingCode.A, FloorAmount = 50250.00m, CeilingAmount = 52750.00m, Amount = 20.00m};
                yield return new AddBack { EmployeeCode = WithholdingCode.A, FloorAmount = 50250.00m, CeilingAmount = 55250.00m, Amount = 40.00m};
                yield return new AddBack { EmployeeCode = WithholdingCode.A, FloorAmount = 50250.00m, CeilingAmount = 57750.00m, Amount = 60.00m};
                yield return new AddBack { EmployeeCode = WithholdingCode.A, FloorAmount = 50250.00m, CeilingAmount = 60250.00m, Amount = 80.00m};
                yield return new AddBack { EmployeeCode = WithholdingCode.A, FloorAmount = 50250.00m, CeilingAmount = 62750.00m, Amount = 100.00m};
                yield return new AddBack { EmployeeCode = WithholdingCode.A, FloorAmount = 50250.00m, CeilingAmount = 65250.00m, Amount = 120.00m};
                yield return new AddBack { EmployeeCode = WithholdingCode.A, FloorAmount = 50250.00m, CeilingAmount = 67750.00m, Amount = 140.00m};
                yield return new AddBack { EmployeeCode = WithholdingCode.A, FloorAmount = 50250.00m, CeilingAmount = 70250.00m, Amount = 160.00m};
                yield return new AddBack { EmployeeCode = WithholdingCode.A, FloorAmount = 50250.00m, CeilingAmount = 72750.00m, Amount = 180.00m};
                yield return new AddBack { EmployeeCode = WithholdingCode.A, FloorAmount = 50250.00m, CeilingAmount = decimal.MaxValue, Amount = 200.00m};

                yield return new AddBack { EmployeeCode = WithholdingCode.D, FloorAmount = 0.00m, CeilingAmount = 50250.00m, Amount = 0.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.D, FloorAmount = 50250.00m, CeilingAmount = 52750.00m, Amount = 20.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.D, FloorAmount = 50250.00m, CeilingAmount = 55250.00m, Amount = 40.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.D, FloorAmount = 50250.00m, CeilingAmount = 57750.00m, Amount = 60.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.D, FloorAmount = 50250.00m, CeilingAmount = 60250.00m, Amount = 80.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.D, FloorAmount = 50250.00m, CeilingAmount = 62750.00m, Amount = 100.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.D, FloorAmount = 50250.00m, CeilingAmount = 65250.00m, Amount = 120.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.D, FloorAmount = 50250.00m, CeilingAmount = 67750.00m, Amount = 140.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.D, FloorAmount = 50250.00m, CeilingAmount = 70250.00m, Amount = 160.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.D, FloorAmount = 50250.00m, CeilingAmount = 72750.00m, Amount = 180.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.D, FloorAmount = 50250.00m, CeilingAmount = decimal.MaxValue, Amount = 200.00m };

                yield return new AddBack { EmployeeCode = WithholdingCode.B, FloorAmount = 0.00m, CeilingAmount = 78500.00m, Amount = 0.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.B, FloorAmount = 78500.00m, CeilingAmount = 82500.00m, Amount = 32.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.B, FloorAmount = 82500.00m, CeilingAmount = 86500.00m, Amount = 64.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.B, FloorAmount = 86500.00m, CeilingAmount = 90500.00m, Amount = 96.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.B, FloorAmount = 90500.00m, CeilingAmount = 94500.00m, Amount = 128.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.B, FloorAmount = 94500.00m, CeilingAmount = 98500.00m, Amount = 160.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.B, FloorAmount = 98500.00m, CeilingAmount = 102500.00m, Amount = 192.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.B, FloorAmount = 102500.00m, CeilingAmount = 106500.00m, Amount = 224.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.B, FloorAmount = 106500.00m, CeilingAmount = 110500.00m, Amount = 256.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.B, FloorAmount = 110500.00m, CeilingAmount = 114500.00m, Amount = 288.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.B, FloorAmount = 114500.00m, CeilingAmount = decimal.MaxValue, Amount = 320.00m };

                yield return new AddBack { EmployeeCode = WithholdingCode.C, FloorAmount = 0.00m, CeilingAmount = 100500.00m, Amount = 0.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.C, FloorAmount = 100500.00m, CeilingAmount = 105500.00m, Amount = 40.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.C, FloorAmount = 105500.00m, CeilingAmount = 110500.00m, Amount = 80.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.C, FloorAmount = 110500.00m, CeilingAmount = 115500.00m, Amount = 120.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.C, FloorAmount = 115500.00m, CeilingAmount = 120500.00m, Amount = 160.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.C, FloorAmount = 120500.00m, CeilingAmount = 125500.00m,Amount = 200.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.C, FloorAmount = 125500.00m, CeilingAmount = 130500.00m, Amount = 240.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.C, FloorAmount = 130500.00m, CeilingAmount = 135500.00m, Amount = 280.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.C, FloorAmount = 135500.00m, CeilingAmount = 140500.00m, Amount = 320.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.C, FloorAmount = 140500.00m, CeilingAmount = 145000.00m, Amount = 360.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.C, FloorAmount = 145500.00m, CeilingAmount = decimal.MaxValue, Amount = 400.00m };

                yield return new AddBack { EmployeeCode = WithholdingCode.F, FloorAmount = 0.00m, CeilingAmount =  56500.00m, Amount = 0.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.F, FloorAmount = 56500.00m, CeilingAmount = 61500.00m, Amount = 20.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.F, FloorAmount = 61500.00m, CeilingAmount = 66500.00m, Amount = 40.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.F, FloorAmount = 65500.00m, CeilingAmount = 71500.00m, Amount = 60.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.F, FloorAmount = 71500.00m, CeilingAmount = 76500.00m, Amount = 80.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.F, FloorAmount = 76500.00m, CeilingAmount = 81500.00m, Amount = 100.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.F, FloorAmount = 81500.00m, CeilingAmount = 86500.00m, Amount = 120.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.F, FloorAmount = 86500.00m, CeilingAmount = 91500.00m, Amount = 140.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.F, FloorAmount = 91500.00m, CeilingAmount = 96500.00m, Amount = 160.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.F, FloorAmount = 96500.00m, CeilingAmount = 101500.00m, Amount = 180.00m };
                yield return new AddBack { EmployeeCode = WithholdingCode.F, FloorAmount = 101500.00m, CeilingAmount = decimal.MaxValue, Amount = 200.00m };
            }
        }

        public override IEnumerable<TaxableWithholding> TaxableWithholdings
        {
            get
            {
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.A, StartingAmount = 0.00m, MaximumWage = 10000.00m, TaxBase = 0.00m, TaxRate = .03m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.A, StartingAmount = 10000.00m, MaximumWage = 50000.00m, TaxBase = 300.00m, TaxRate = .05m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.A, StartingAmount = 50000.00m, MaximumWage = 100000.00m, TaxBase = 2300.00m, TaxRate = .055m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.A, StartingAmount = 100000.00m, MaximumWage = 200000.00m, TaxBase = 5050.00m, TaxRate = .06m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.A, StartingAmount = 200000.00m, MaximumWage = 250000.00m, TaxBase = 11050.00m, TaxRate = .065m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.A, StartingAmount = 250000.00m, MaximumWage = 500000.00m, TaxBase = 14300.00m, TaxRate = .069m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.A, StartingAmount = 500000.00m, MaximumWage = decimal.MaxValue, TaxBase = 31550.00m, TaxRate = .0699m };

                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.B, StartingAmount = 0.00m, MaximumWage = 16000.00m, TaxBase = 0.00m, TaxRate = .03m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.B, StartingAmount = 16000.00m, MaximumWage = 80000.00m, TaxBase = 480.00m, TaxRate = .05m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.B, StartingAmount = 80000.00m, MaximumWage = 160000.00m, TaxBase = 3680.00m, TaxRate = .055m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.B, StartingAmount = 160000.00m, MaximumWage = 320000.00m, TaxBase = 8080.00m, TaxRate = .06m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.B, StartingAmount = 320000.00m, MaximumWage = 400000.00m, TaxBase = 17680.00m, TaxRate = .065m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.B, StartingAmount = 400000.00m, MaximumWage = 800000.00m, TaxBase = 22880.00m, TaxRate = .069m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.B, StartingAmount = 800000.00m, MaximumWage = decimal.MaxValue, TaxBase = 50480.00m, TaxRate = .0699m };

                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.C, StartingAmount = 0.00m, MaximumWage = 20000.00m, TaxBase = 0.00m, TaxRate = .03m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.C, StartingAmount = 20000.00m, MaximumWage = 100000.00m, TaxBase = 600.00m, TaxRate = .05m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.C, StartingAmount = 100000.00m, MaximumWage = 200000.00m, TaxBase = 4600.00m, TaxRate = .055m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.C, StartingAmount = 200000.00m, MaximumWage = 400000.00m, TaxBase = 10100.00m, TaxRate = .06m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.C, StartingAmount = 400000.00m, MaximumWage = 500000.00m, TaxBase = 22100.00m, TaxRate = .065m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.C, StartingAmount = 500000.00m, MaximumWage = 1000000.00m, TaxBase = 28600.00m, TaxRate = .069m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.C, StartingAmount = 1000000.00m, MaximumWage = decimal.MaxValue, TaxBase = 63100.00m, TaxRate = .0699m };

                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.D, StartingAmount = 0.00m, MaximumWage = 10000.00m, TaxBase = 0.00m, TaxRate = .03m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.D, StartingAmount = 10000.00m, MaximumWage = 50000.00m, TaxBase = 300.00m, TaxRate = .05m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.D, StartingAmount = 50000.00m, MaximumWage = 100000.00m, TaxBase = 2300.00m, TaxRate = .055m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.D, StartingAmount = 100000.00m, MaximumWage = 200000.00m, TaxBase = 5050.00m, TaxRate = .06m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.D, StartingAmount = 200000.00m, MaximumWage = 250000.00m, TaxBase = 11050.00m, TaxRate = .065m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.D, StartingAmount = 250000.00m, MaximumWage = 500000.00m, TaxBase = 14300.00m, TaxRate = .069m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.D, StartingAmount = 500000.00m, MaximumWage = decimal.MaxValue, TaxBase = 31550.00m, TaxRate = .0699m };

                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.F, StartingAmount = 0.00m, MaximumWage = 10000.00m, TaxBase = 0.00m, TaxRate = .03m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.F, StartingAmount = 10000.00m, MaximumWage = 50000.00m, TaxBase = 300.00m, TaxRate = .05m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.F, StartingAmount = 50000.00m, MaximumWage = 100000.00m, TaxBase = 2300.00m, TaxRate = .055m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.F, StartingAmount = 100000.00m, MaximumWage = 200000.00m, TaxBase = 5050.00m, TaxRate = .06m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.F, StartingAmount = 200000.00m, MaximumWage = 250000.00m, TaxBase = 11050.00m, TaxRate = .065m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.F, StartingAmount = 250000.00m, MaximumWage = 500000.00m, TaxBase = 14300.00m, TaxRate = .069m };
                yield return new TaxableWithholding { EmployeeCode = WithholdingCode.F, StartingAmount = 500000.00m, MaximumWage = decimal.MaxValue, TaxBase = 31550.00m, TaxRate = .0699m };
            }            
        }

        public override IEnumerable<PersonalTaxCredit> PersonalTaxRate
        {
            get
            {
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.D, FloorAmount = 0, CeilingAmount = decimal.MaxValue, Amount = 0 };

                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 0, CeilingAmount = 12000.00m, Amount = .75m };
                yield return new PersonalTaxCredit {EmployeeCode = WithholdingCode.A, FloorAmount = 12000, CeilingAmount = 15000.00m, Amount = .75m};
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 15000, CeilingAmount = 15500.00m, Amount = .70m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 15500, CeilingAmount = 16000.00m, Amount = .65m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 16000, CeilingAmount = 16500.00m, Amount = .60m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 16500, CeilingAmount = 17000.00m, Amount = .55m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 17000, CeilingAmount = 17500.00m, Amount = .50m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 17500, CeilingAmount = 18000.00m, Amount = .45m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 18000, CeilingAmount = 18500.00m, Amount = .40m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 18500, CeilingAmount = 20000.00m, Amount = .35m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 20000, CeilingAmount = 20500.00m, Amount = .30m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 20500, CeilingAmount = 21000.00m, Amount = .25m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 21000, CeilingAmount = 21500.00m, Amount = .20m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 21500, CeilingAmount = 25000.00m, Amount = .15m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 25000, CeilingAmount = 25500.00m, Amount = .14m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 25500, CeilingAmount = 26000.00m, Amount = .13m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 26000, CeilingAmount = 26500.00m, Amount = .12m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 26500, CeilingAmount = 27000.00m, Amount = .11m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 27000, CeilingAmount = 48000.00m, Amount = .10m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 48000, CeilingAmount = 48500.00m, Amount = .09m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 48500, CeilingAmount = 49000.00m, Amount = .08m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 49000, CeilingAmount = 49500.00m, Amount = .07m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 49500, CeilingAmount = 50000.00m, Amount = .06m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 50000, CeilingAmount = 50500.00m, Amount = .05m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 50500, CeilingAmount = 51000.00m, Amount = .04m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 51000, CeilingAmount = 51500.00m, Amount = .03m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 51500, CeilingAmount = 52000.00m, Amount = .02m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 52000, CeilingAmount = 52500.00m, Amount = .01m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.A, FloorAmount = 52500, CeilingAmount = decimal.MaxValue, Amount = .00m };

                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 0, CeilingAmount = 19000.00m, Amount = .75m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 19000, CeilingAmount = 24000.00m, Amount = .75m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 24000, CeilingAmount = 24500.00m, Amount = .70m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 24500, CeilingAmount = 25000.00m, Amount = .65m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 25000, CeilingAmount = 25500.00m, Amount = .60m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 25500, CeilingAmount = 26000.00m, Amount = .55m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 26000, CeilingAmount = 26500.00m, Amount = .50m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 26500, CeilingAmount = 27000.00m, Amount = .45m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 27000, CeilingAmount = 27500.00m, Amount = .40m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 27500, CeilingAmount = 34000.00m, Amount = .35m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 34000, CeilingAmount = 34500.00m, Amount = .30m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 34500, CeilingAmount = 35000.00m, Amount = .25m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 35000, CeilingAmount = 35500.00m, Amount = .20m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 35500, CeilingAmount = 44000.00m, Amount = .15m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 44000, CeilingAmount = 44500.00m, Amount = .14m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 44500, CeilingAmount = 45000.00m, Amount = .13m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 45000, CeilingAmount = 45500.00m, Amount = .12m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 45500, CeilingAmount = 46000.00m, Amount = .11m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 46000, CeilingAmount = 74000.00m, Amount = .10m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 74000, CeilingAmount = 74500.00m, Amount = .09m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 74500, CeilingAmount = 75000.00m, Amount = .08m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 75000, CeilingAmount = 75500.00m, Amount = .07m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 75500, CeilingAmount = 76000.00m, Amount = .06m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 76000, CeilingAmount = 76500.00m, Amount = .05m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 76500, CeilingAmount = 77000.00m, Amount = .04m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 77000, CeilingAmount = 77500.00m, Amount = .03m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 77500, CeilingAmount = 78000.00m, Amount = .02m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 78000, CeilingAmount = 78500.00m, Amount = .01m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.B, FloorAmount = 78500, CeilingAmount = Decimal.MaxValue, Amount = .00m };

                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 0, CeilingAmount = 24000.00m, Amount = .75m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 24000, CeilingAmount = 30000.00m, Amount = .75m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 30000, CeilingAmount = 30500.00m, Amount = .70m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 30500, CeilingAmount = 31000.00m, Amount = .65m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 31000, CeilingAmount = 31500.00m, Amount = .60m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 31500, CeilingAmount = 32000.00m, Amount = .55m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 32000, CeilingAmount = 32500.00m, Amount = .50m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 32500, CeilingAmount = 33000.00m, Amount = .45m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 33000, CeilingAmount = 33500.00m, Amount = .40m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 33500, CeilingAmount = 40000.00m, Amount = .35m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 40000, CeilingAmount = 40500.00m, Amount = .30m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 40500, CeilingAmount = 41000.00m, Amount = .25m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 41000, CeilingAmount = 41500.00m, Amount = .20m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 41500, CeilingAmount = 50000.00m, Amount = .15m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 50000, CeilingAmount = 50500.00m, Amount = .14m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 50500, CeilingAmount = 51000.00m, Amount = .13m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 51000, CeilingAmount = 51500.00m, Amount = .12m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 51500, CeilingAmount = 52000.00m, Amount = .11m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 52000, CeilingAmount = 96000.00m, Amount = .10m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 96000, CeilingAmount = 96500.00m, Amount = .09m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 96500, CeilingAmount = 97000.00m, Amount = .08m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 97000, CeilingAmount = 97500.00m, Amount = .07m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 97500, CeilingAmount = 98000.00m, Amount = .06m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 98000, CeilingAmount = 98500.00m, Amount = .05m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 98500, CeilingAmount = 99000.00m, Amount = .04m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 99000, CeilingAmount = 99500.00m, Amount = .03m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 99500, CeilingAmount = 100000.00m, Amount = .02m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 100000, CeilingAmount = 100500.00m, Amount = .01m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.C, FloorAmount = 100500, CeilingAmount = decimal.MaxValue, Amount = .00m };

                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 0, CeilingAmount = 12000.00m, Amount = .75m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 12000, CeilingAmount = 18800.00m, Amount = .75m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 18800, CeilingAmount = 19300.00m, Amount = .70m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 19300, CeilingAmount = 19800.00m, Amount = .65m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 19800, CeilingAmount = 20300.00m, Amount = .60m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 20300, CeilingAmount = 20800.00m, Amount = .55m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 20800, CeilingAmount = 21300.00m, Amount = .50m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 21300, CeilingAmount = 21800.00m, Amount = .45m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 21800, CeilingAmount = 22300.00m, Amount = .40m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 22300, CeilingAmount = 25000.00m, Amount = .35m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 25000, CeilingAmount = 25500.00m, Amount = .30m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 25500, CeilingAmount = 26000.00m, Amount = .25m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 26000, CeilingAmount = 26500.00m, Amount = .20m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 26500, CeilingAmount = 31300.00m, Amount = .15m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 31300, CeilingAmount = 31800.00m, Amount = .14m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 31800, CeilingAmount = 32300.00m, Amount = .13m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 32300, CeilingAmount = 32800.00m, Amount = .12m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 32800, CeilingAmount = 33300.00m, Amount = .11m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 33300, CeilingAmount = 60000.00m, Amount = .10m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 60000, CeilingAmount = 60500.00m, Amount = .09m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 60500, CeilingAmount = 61000.00m, Amount = .08m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 61000, CeilingAmount = 61500.00m, Amount = .07m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 61500, CeilingAmount = 62000.00m, Amount = .06m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 62000, CeilingAmount = 62500.00m, Amount = .05m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 62500, CeilingAmount = 63000.00m, Amount = .04m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 63000, CeilingAmount = 63500.00m, Amount = .03m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 63500, CeilingAmount = 64000.00m, Amount = .02m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 64000, CeilingAmount = 64500.00m, Amount = .01m };
                yield return new PersonalTaxCredit { EmployeeCode = WithholdingCode.F, FloorAmount = 64500, CeilingAmount = decimal.MaxValue, Amount = .00m };
            }
        }

        public override IEnumerable<TaxRecapture> TaxRecaptureRates
        {
            get
            {
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 0, CeilingAmount = 200000.00m, Amount = 0.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 200000.00m, CeilingAmount = 205000.00m, Amount = 90.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 205000.00m, CeilingAmount = 210000.00m, Amount = 180.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 210000.00m, CeilingAmount = 215000.00m, Amount = 270.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 215000.00m, CeilingAmount = 220000.00m, Amount = 360.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 220000.00m, CeilingAmount = 225000.00m, Amount = 450.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 225000.00m, CeilingAmount = 230000.00m, Amount = 540.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 230000.00m, CeilingAmount = 235000.00m, Amount = 630.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 235000.00m, CeilingAmount = 240000.00m, Amount = 720.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 240000.00m, CeilingAmount = 245000.00m, Amount = 810.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 245000.00m, CeilingAmount = 250000.00m, Amount = 900.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 250000.00m, CeilingAmount = 255000.00m, Amount = 990.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 255000.00m, CeilingAmount = 260000.00m, Amount = 1080.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 260000.00m, CeilingAmount = 265000.00m, Amount = 1170.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 265000.00m, CeilingAmount = 270000.00m, Amount = 1260.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 270000.00m, CeilingAmount = 275000.00m, Amount = 1350.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 275000.00m, CeilingAmount = 280000.00m, Amount = 1440.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 280000.00m, CeilingAmount = 285000.00m, Amount = 1530.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 285000.00m, CeilingAmount = 290000.00m, Amount = 1620.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 290000.00m, CeilingAmount = 295000.00m, Amount = 1710.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 295000.00m, CeilingAmount = 300000.00m, Amount = 1800.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 300000.00m, CeilingAmount = 305000.00m, Amount = 1890.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 305000.00m, CeilingAmount = 310000.00m, Amount = 1980.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 310000.00m, CeilingAmount = 315000.00m, Amount = 2070.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 315000.00m, CeilingAmount = 320000.00m, Amount = 2160.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 320000.00m, CeilingAmount = 325000.00m, Amount = 2250.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 325000.00m, CeilingAmount = 330000.00m, Amount = 2340.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 330000.00m, CeilingAmount = 335000.00m, Amount = 2430.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 335000.00m, CeilingAmount = 340000.00m, Amount = 2520.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 340000.00m, CeilingAmount = 345000.00m, Amount = 2610.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 345000.00m, CeilingAmount = 500000.00m, Amount = 2700.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 500000.00m, CeilingAmount = 505000.00m, Amount = 2750.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 505000.00m, CeilingAmount = 510000.00m, Amount = 2800.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 510000.00m, CeilingAmount = 515000.00m, Amount = 2850.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 515000.00m, CeilingAmount = 520000.00m, Amount = 2900.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 520000.00m, CeilingAmount = 525000.00m, Amount = 2950.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 525000.00m, CeilingAmount = 530000.00m, Amount = 3000.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 530000.00m, CeilingAmount = 535000.00m, Amount = 3050.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 535000.00m, CeilingAmount = 540000.00m, Amount = 3100.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.A, FloorAmount = 540000.00m, CeilingAmount = decimal.MaxValue, Amount = 3150.00m };

                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 0, CeilingAmount = 200000.00m, Amount = 0.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 200000.00m, CeilingAmount = 205000.00m, Amount = 90.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 205000.00m, CeilingAmount = 210000.00m, Amount = 180.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 210000.00m, CeilingAmount = 215000.00m, Amount = 270.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 215000.00m, CeilingAmount = 220000.00m, Amount = 360.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 220000.00m, CeilingAmount = 225000.00m, Amount = 450.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 225000.00m, CeilingAmount = 230000.00m, Amount = 540.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 230000.00m, CeilingAmount = 235000.00m, Amount = 630.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 235000.00m, CeilingAmount = 240000.00m, Amount = 720.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 240000.00m, CeilingAmount = 245000.00m, Amount = 810.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 245000.00m, CeilingAmount = 250000.00m, Amount = 900.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 250000.00m, CeilingAmount = 255000.00m, Amount = 990.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 255000.00m, CeilingAmount = 260000.00m, Amount = 1080.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 260000.00m, CeilingAmount = 265000.00m, Amount = 1170.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 265000.00m, CeilingAmount = 270000.00m, Amount = 1260.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 270000.00m, CeilingAmount = 275000.00m, Amount = 1350.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 275000.00m, CeilingAmount = 280000.00m, Amount = 1440.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 280000.00m, CeilingAmount = 285000.00m, Amount = 1530.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 285000.00m, CeilingAmount = 290000.00m, Amount = 1620.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 290000.00m, CeilingAmount = 295000.00m, Amount = 1710.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 295000.00m, CeilingAmount = 300000.00m, Amount = 1800.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 300000.00m, CeilingAmount = 305000.00m, Amount = 1890.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 305000.00m, CeilingAmount = 310000.00m, Amount = 1980.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 310000.00m, CeilingAmount = 315000.00m, Amount = 2070.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 315000.00m, CeilingAmount = 320000.00m, Amount = 2160.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 320000.00m, CeilingAmount = 325000.00m, Amount = 2250.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 325000.00m, CeilingAmount = 330000.00m, Amount = 2340.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 330000.00m, CeilingAmount = 335000.00m, Amount = 2430.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 335000.00m, CeilingAmount = 340000.00m, Amount = 2520.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 340000.00m, CeilingAmount = 345000.00m, Amount = 2610.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 345000.00m, CeilingAmount = 500000.00m, Amount = 2700.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 500000.00m, CeilingAmount = 505000.00m, Amount = 2750.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 505000.00m, CeilingAmount = 510000.00m, Amount = 2800.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 510000.00m, CeilingAmount = 515000.00m, Amount = 2850.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 515000.00m, CeilingAmount = 520000.00m, Amount = 2900.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 520000.00m, CeilingAmount = 525000.00m, Amount = 2950.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 525000.00m, CeilingAmount = 530000.00m, Amount = 3000.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 530000.00m, CeilingAmount = 535000.00m, Amount = 3050.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 535000.00m, CeilingAmount = 540000.00m, Amount = 3100.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.F, FloorAmount = 540000.00m, CeilingAmount = decimal.MaxValue, Amount = 3150.00m };

                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 0, CeilingAmount = 200000.00m, Amount = 0.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 200000.00m, CeilingAmount = 205000.00m, Amount = 90.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 205000.00m, CeilingAmount = 210000.00m, Amount = 180.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 210000.00m, CeilingAmount = 215000.00m, Amount = 270.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 215000.00m, CeilingAmount = 220000.00m, Amount = 360.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 220000.00m, CeilingAmount = 225000.00m, Amount = 450.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 225000.00m, CeilingAmount = 230000.00m, Amount = 540.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 230000.00m, CeilingAmount = 235000.00m, Amount = 630.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 235000.00m, CeilingAmount = 240000.00m, Amount = 720.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 240000.00m, CeilingAmount = 245000.00m, Amount = 810.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 245000.00m, CeilingAmount = 250000.00m, Amount = 900.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 250000.00m, CeilingAmount = 255000.00m, Amount = 990.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 255000.00m, CeilingAmount = 260000.00m, Amount = 1080.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 260000.00m, CeilingAmount = 265000.00m, Amount = 1170.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 265000.00m, CeilingAmount = 270000.00m, Amount = 1260.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 270000.00m, CeilingAmount = 275000.00m, Amount = 1350.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 275000.00m, CeilingAmount = 280000.00m, Amount = 1440.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 280000.00m, CeilingAmount = 285000.00m, Amount = 1530.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 285000.00m, CeilingAmount = 290000.00m, Amount = 1620.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 290000.00m, CeilingAmount = 295000.00m, Amount = 1710.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 295000.00m, CeilingAmount = 300000.00m, Amount = 1800.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 300000.00m, CeilingAmount = 305000.00m, Amount = 1890.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 305000.00m, CeilingAmount = 310000.00m, Amount = 1980.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 310000.00m, CeilingAmount = 315000.00m, Amount = 2070.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 315000.00m, CeilingAmount = 320000.00m, Amount = 2160.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 320000.00m, CeilingAmount = 325000.00m, Amount = 2250.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 325000.00m, CeilingAmount = 330000.00m, Amount = 2340.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 330000.00m, CeilingAmount = 335000.00m, Amount = 2430.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 335000.00m, CeilingAmount = 340000.00m, Amount = 2520.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 340000.00m, CeilingAmount = 345000.00m, Amount = 2610.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 345000.00m, CeilingAmount = 500000.00m, Amount = 2700.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 500000.00m, CeilingAmount = 505000.00m, Amount = 2750.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 505000.00m, CeilingAmount = 510000.00m, Amount = 2800.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 510000.00m, CeilingAmount = 515000.00m, Amount = 2850.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 515000.00m, CeilingAmount = 520000.00m, Amount = 2900.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 520000.00m, CeilingAmount = 525000.00m, Amount = 2950.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 525000.00m, CeilingAmount = 530000.00m, Amount = 3000.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 530000.00m, CeilingAmount = 535000.00m, Amount = 3050.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 535000.00m, CeilingAmount = 540000.00m, Amount = 3100.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.D, FloorAmount = 540000.00m, CeilingAmount = decimal.MaxValue, Amount = 3150.00m };

                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 0, CeilingAmount = 320000.00m, Amount = 0.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 320000.00m, CeilingAmount = 328000.00m, Amount = 140.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 328000.00m, CeilingAmount = 336000.00m, Amount = 280.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 336000.00m, CeilingAmount = 344000.00m, Amount = 420.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 344000.00m, CeilingAmount = 352000.00m, Amount = 560.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 352000.00m, CeilingAmount = 360000.00m, Amount = 700.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 360000.00m, CeilingAmount = 368000.00m, Amount = 840.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 368000.00m, CeilingAmount = 376000.00m, Amount = 980.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 376000.00m, CeilingAmount = 384000.00m, Amount = 1120.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 384000.00m, CeilingAmount = 392000.00m, Amount = 1260.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 392000.00m, CeilingAmount = 400000.00m, Amount = 1400.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 400000.00m, CeilingAmount = 408000.00m, Amount = 1540.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 408000.00m, CeilingAmount = 416000.00m, Amount = 1680.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 416000.00m, CeilingAmount = 424000.00m, Amount = 1820.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 424000.00m, CeilingAmount = 432000.00m, Amount = 1960.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 432000.00m, CeilingAmount = 440000.00m, Amount = 2100.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 440000.00m, CeilingAmount = 448000.00m, Amount = 2240.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 448000.00m, CeilingAmount = 456000.00m, Amount = 2380.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 456000.00m, CeilingAmount = 464000.00m, Amount = 2520.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 464000.00m, CeilingAmount = 472000.00m, Amount = 2660.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 472000.00m, CeilingAmount = 480000.00m, Amount = 2800.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 480000.00m, CeilingAmount = 488000.00m, Amount = 2940.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 488000.00m, CeilingAmount = 496000.00m, Amount = 3080.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 496000.00m, CeilingAmount = 504000.00m, Amount = 3220.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 504000.00m, CeilingAmount = 512000.00m, Amount = 3360.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 512000.00m, CeilingAmount = 520000.00m, Amount = 3500.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 520000.00m, CeilingAmount = 528000.00m, Amount = 3640.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 528000.00m, CeilingAmount = 536000.00m, Amount = 3780.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 536000.00m, CeilingAmount = 544000.00m, Amount = 3920.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 544000.00m, CeilingAmount = 552000.00m, Amount = 4060.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 522000.00m, CeilingAmount = 800000.00m, Amount = 4200.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 800000.00m, CeilingAmount = 808000.00m, Amount = 4280.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 808000.00m, CeilingAmount = 816000.00m, Amount = 4360.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 816000.00m, CeilingAmount = 824000.00m, Amount = 4440.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 824000.00m, CeilingAmount = 832000.00m, Amount = 4520.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 832000.00m, CeilingAmount = 840000.00m, Amount = 4600.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 840000.00m, CeilingAmount = 848000.00m, Amount = 4680.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 848000.00m, CeilingAmount = 856000.00m, Amount = 4760.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 856000.00m, CeilingAmount = 864000.00m, Amount = 4840.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.B, FloorAmount = 864000.00m, CeilingAmount = decimal.MaxValue, Amount = 4920.00m };

                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 0, CeilingAmount = 400000.00m, Amount = 0.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 400000.00m, CeilingAmount = 410000.00m, Amount = 180.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 410000.00m, CeilingAmount = 420000.00m, Amount = 360.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 420000.00m, CeilingAmount = 430000.00m, Amount = 540.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 430000.00m, CeilingAmount = 440000.00m, Amount = 720.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 440000.00m, CeilingAmount = 450000.00m, Amount = 900.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 450000.00m, CeilingAmount = 460000.00m, Amount = 1080.00m};
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 460000.00m, CeilingAmount = 470000.00m, Amount = 1260.00m};
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 470000.00m, CeilingAmount = 480000.00m, Amount = 1440.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 480000.00m, CeilingAmount = 490000.00m, Amount = 1620.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 490000.00m, CeilingAmount = 500000.00m, Amount = 1800.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 500000.00m, CeilingAmount = 510000.00m, Amount = 1980.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 510000.00m, CeilingAmount = 520000.00m, Amount = 2160.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 520000.00m, CeilingAmount = 530000.00m, Amount = 2340.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 530000.00m, CeilingAmount = 540000.00m, Amount = 2520.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 540000.00m, CeilingAmount = 550000.00m, Amount = 2700.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 550000.00m, CeilingAmount = 560000.00m, Amount = 2880.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 560000.00m, CeilingAmount = 570000.00m, Amount = 3060.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 570000.00m, CeilingAmount = 580000.00m, Amount = 3240.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 580000.00m, CeilingAmount = 590000.00m, Amount = 3420.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 590000.00m, CeilingAmount = 600000.00m, Amount = 3600.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 600000.00m, CeilingAmount = 610000.00m, Amount = 3780.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 610000.00m, CeilingAmount = 620000.00m, Amount = 3960.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 620000.00m, CeilingAmount = 630000.00m, Amount = 4140.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 630000.00m, CeilingAmount = 640000.00m, Amount = 4320.00m};
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 640000.00m, CeilingAmount = 650000.00m, Amount = 4500.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 650000.00m, CeilingAmount = 660000.00m, Amount = 4680.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 660000.00m, CeilingAmount = 670000.00m, Amount = 4860.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 670000.00m, CeilingAmount = 680000.00m, Amount = 5040.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 680000.00m, CeilingAmount = 690000.00m, Amount = 5220.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 690000.00m, CeilingAmount = 1000000.00m,Amount = 5400.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 1000000.00m, CeilingAmount = 1010000.00m,Amount = 5500.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 1010000.00m, CeilingAmount = 1020000.00m,Amount = 5600.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 1020000.00m, CeilingAmount = 1030000.00m,Amount = 5700.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 1030000.00m, CeilingAmount = 1040000.00m,Amount = 5800.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 1040000.00m, CeilingAmount = 1050000.00m, Amount = 5900.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 1050000.00m, CeilingAmount = 1060000.00m, Amount = 6000.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 1060000.00m, CeilingAmount = 1070000.00m, Amount = 6100.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 1070000.00m, CeilingAmount = 1080000.00m, Amount = 6200.00m };
                yield return new TaxRecapture { EmployeeCode = WithholdingCode.C, FloorAmount = 1080000.00m, CeilingAmount = decimal.MaxValue, Amount = 6300.00m };
            }
        }

    }
}