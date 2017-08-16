using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.NewYork
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 10900; } }

        public override IEnumerable<TaxTable.DeductionAllowance> DeductionAllowances
        {
            get
            {
                yield return new TaxTable.DeductionAllowance { FilingStatus = FilingStatus.Single, Amount = 7400, Region = Region.NewYorkState };
                yield return new TaxTable.DeductionAllowance { FilingStatus = FilingStatus.Married, Amount = 7950, Region = Region.NewYorkState };
                yield return new TaxTable.DeductionAllowance { FilingStatus = FilingStatus.Single, Amount = 5000, Region = Region.NewYorkCity };
                yield return new TaxTable.DeductionAllowance { FilingStatus = FilingStatus.Married, Amount = 5500, Region = Region.NewYorkCity };
                yield return new TaxTable.DeductionAllowance { FilingStatus = FilingStatus.Single, Amount = 7400, Region = Region.Yonkers };
                yield return new TaxTable.DeductionAllowance { FilingStatus = FilingStatus.Married, Amount = 7950, Region = Region.Yonkers };
            }
        }

        public override decimal ExemptionAllowance
        {
            get
            {
                return 1000m;
            }
        }
        
        public override IEnumerable<TaxableWithholding> TaxableWithholdings
        {
            get
            {
                // Percentage method for computing tax on wages subject to withholding

                // Single Individual
                //NYS
                yield return new TaxTable.TaxableWithholding {Region = Region.NewYorkState, FilingStatus = FilingStatus.Single, TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 8500.00m, TaxRate = .0400m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Single, TaxBase = 340.00m, StartingAmount = 8500.00m, MaximumWage = 11700.00m, TaxRate = .0450m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Single, TaxBase = 484.00m, StartingAmount = 11700.00m, MaximumWage = 13900.00m, TaxRate = .0525m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Single, TaxBase = 600.00m, StartingAmount = 13900.00m, MaximumWage = 21400.00m, TaxRate = .0590m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Single, TaxBase = 1042.00m, StartingAmount = 21400.00m, MaximumWage = 80650.00m, TaxRate = .0645m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Single, TaxBase = 4864.00m, StartingAmount = 80650.00m, MaximumWage = 96800.00m, TaxRate = .0665m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Single, TaxBase = 5938.00m, StartingAmount = 96800.00m, MaximumWage = 107650.00m, TaxRate = .0758m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Single, TaxBase = 6760.00m, StartingAmount = 107650.00m, MaximumWage = 161550.00m, TaxRate = .0808m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Single, TaxBase = 11115.00m, StartingAmount = 161550.00m, MaximumWage = 215400.00m, TaxRate = .0715m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Single, TaxBase = 14965.00m, StartingAmount = 215400.00m, MaximumWage = 269300.00m, TaxRate = .0815m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Single, TaxBase = 19358.00m, StartingAmount = 269300.00m, MaximumWage = 1077550.00m, TaxRate = .0735m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Single, TaxBase = 78765.00m, StartingAmount = 1077550.00m, MaximumWage = 1131500.00m, TaxRate = .4902m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Single, TaxBase = 105211.00m, StartingAmount = 1131500.00m, MaximumWage = decimal.MaxValue, TaxRate = .0962m };

                //NYC
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkCity, FilingStatus = FilingStatus.Single, TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 8000.00m, TaxRate = .0190m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkCity, FilingStatus = FilingStatus.Single, TaxBase = 152.00m, StartingAmount = 8000.00m, MaximumWage = 8700.00m, TaxRate = .0265m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkCity, FilingStatus = FilingStatus.Single, TaxBase = 171.00m, StartingAmount = 8700.00m, MaximumWage = 15000.00m, TaxRate = .0310m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkCity, FilingStatus = FilingStatus.Single, TaxBase = 366.00m, StartingAmount = 15000.00m, MaximumWage = 25000.00m, TaxRate = .0370m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkCity, FilingStatus = FilingStatus.Single, TaxBase = 736.00m, StartingAmount = 25000.00m, MaximumWage = 60000.00m, TaxRate = .0390m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkCity, FilingStatus = FilingStatus.Single, TaxBase = 2101.00m, StartingAmount = 60000.00m, MaximumWage = 500000.00m, TaxRate = .0400m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkCity, FilingStatus = FilingStatus.Single, TaxBase = 20834.16m, StartingAmount = 500000.00m, MaximumWage = decimal.MaxValue, TaxRate = .0425m };

                //Yonkers
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Single, TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 8500.00m, TaxRate = .0400m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Single, TaxBase = 340.00m, StartingAmount = 8500.00m, MaximumWage = 11700.00m, TaxRate = .0450m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Single, TaxBase = 484.00m, StartingAmount = 11700.00m, MaximumWage = 13900.00m, TaxRate = .0525m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Single, TaxBase = 600.00m, StartingAmount = 13900.00m, MaximumWage = 21400.00m, TaxRate = .0590m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Single, TaxBase = 1042.00m, StartingAmount = 21400.00m, MaximumWage =  80650.00m, TaxRate = .0645m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Single, TaxBase = 4864.00m, StartingAmount = 80650.00m, MaximumWage = 96800.00m, TaxRate = .0665m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Single, TaxBase = 5938.00m, StartingAmount = 96800.00m, MaximumWage = 107650.00m, TaxRate = .0758m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Single, TaxBase = 6760.00m, StartingAmount = 107650.00m, MaximumWage = 161550.00m, TaxRate = .0808m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Single, TaxBase = 11115.00m, StartingAmount = 161550.00m, MaximumWage =  215400.00m, TaxRate = .0715m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Single, TaxBase = 14965.00m, StartingAmount = 215400.00m, MaximumWage = 269300.00m,  TaxRate = .0815m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Single, TaxBase = 39358.00m, StartingAmount = 269300.00m, MaximumWage = 1077550.00m, TaxRate = .0735m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Single, TaxBase = 78765.00m, StartingAmount = 1077550.00m, MaximumWage = 1131500.00m, TaxRate = .4902m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Single, TaxBase = 105211.00m, StartingAmount = 1131500.00m, MaximumWage = Decimal.MaxValue, TaxRate = .0962m };



                // Married 
                //NYS
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Married, TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 8500.00m, TaxRate = .0400m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Married, TaxBase = 340.00m, StartingAmount = 8500.00m, MaximumWage = 11700.00m, TaxRate = .0450m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Married, TaxBase = 484.00m, StartingAmount = 11700.00m, MaximumWage = 13900.00m, TaxRate = .0525m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Married, TaxBase = 600.00m, StartingAmount = 13900.00m, MaximumWage = 21400.00m, TaxRate = .0590m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Married, TaxBase = 1042.00m, StartingAmount = 21400.00m, MaximumWage = 80650.00m, TaxRate = .0645m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Married, TaxBase = 4864.00m, StartingAmount = 80650.00m, MaximumWage = 96800.00m, TaxRate = .0665m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Married, TaxBase = 5938.00m, StartingAmount = 96800.00m, MaximumWage = 107650.00m, TaxRate = .0728m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Married, TaxBase = 6727.00m, StartingAmount = 107650.00m, MaximumWage = 161550.00m, TaxRate = .0778m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Married, TaxBase = 10921.00m, StartingAmount = 161550.00m, MaximumWage = 215400.00m, TaxRate = .0808m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Married, TaxBase = 15272.00m, StartingAmount = 215400.00m, MaximumWage = 323200.00m, TaxRate = .0715m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Married, TaxBase = 22980.00m, StartingAmount = 323200.00m, MaximumWage = 377100.00m, TaxRate = .0815m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Married, TaxBase = 27373.00m, StartingAmount = 377100.00m, MaximumWage = 1077550.00m, TaxRate = .0735m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Married, TaxBase = 78856.00m, StartingAmount = 1077550.00m, MaximumWage = 2155350.00m, TaxRate = .0765m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Married, TaxBase = 161307.00m, StartingAmount = 2155350.00m, MaximumWage = 2209300.00m, TaxRate = .8842m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkState, FilingStatus = FilingStatus.Married, TaxBase = 209010.00m, StartingAmount = 2209300.00m, MaximumWage = decimal.MaxValue, TaxRate = .0962m };

                //NYC
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkCity, FilingStatus = FilingStatus.Married, TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 8000.00m, TaxRate = .0190m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkCity, FilingStatus = FilingStatus.Married, TaxBase = 152.00m, StartingAmount = 8000.00m, MaximumWage = 8700.00m, TaxRate = .0265m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkCity, FilingStatus = FilingStatus.Married, TaxBase = 171.00m, StartingAmount = 8700.00m, MaximumWage = 15000.00m, TaxRate = .0310m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkCity, FilingStatus = FilingStatus.Married, TaxBase = 366.00m, StartingAmount = 15000.00m, MaximumWage = 25000.00m, TaxRate = .0370m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkCity, FilingStatus = FilingStatus.Married, TaxBase = 736.00m, StartingAmount = 25000.00m, MaximumWage = 60000.00m, TaxRate = .0390m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkCity, FilingStatus = FilingStatus.Married, TaxBase = 2101.00m, StartingAmount = 60000.00m, MaximumWage = 500000.00m, TaxRate = .0400m };
                yield return new TaxTable.TaxableWithholding { Region = Region.NewYorkCity, FilingStatus = FilingStatus.Married, TaxBase = 20828.46m, StartingAmount = 500000.00m, MaximumWage = decimal.MaxValue, TaxRate = .0425m };

                //Yonkers
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Married, TaxBase = 0.00m, StartingAmount = 0.00m, MaximumWage = 8500.00m, TaxRate = .0400m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Married, TaxBase = 340.00m, StartingAmount = 8500.00m, MaximumWage = 11700.00m, TaxRate = .0450m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Married, TaxBase = 484.00m, StartingAmount = 11700.00m, MaximumWage = 13900.00m, TaxRate = .0525m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Married, TaxBase = 600.00m, StartingAmount = 13900.00m, MaximumWage = 21400.00m, TaxRate = .0590m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Married, TaxBase = 1042.00m, StartingAmount = 21400.00m, MaximumWage = 80650.00m, TaxRate = .0645m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Married, TaxBase = 4864.00m, StartingAmount = 80650.00m, MaximumWage = 96800.00m, TaxRate = .0665m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Married, TaxBase = 5938.00m, StartingAmount = 96800.00m, MaximumWage = 107650.00m, TaxRate = .0728m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Married, TaxBase = 6727.00m, StartingAmount = 107650.00m, MaximumWage = 161550.00m, TaxRate = .0778m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Married, TaxBase = 10921.00m, StartingAmount = 161550.00m, MaximumWage = 215400.00m, TaxRate = .0808m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Married, TaxBase = 15272.00m, StartingAmount = 215400.00m, MaximumWage = 323200.00m, TaxRate = .0715m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Married, TaxBase = 22980.00m, StartingAmount = 323200.00m, MaximumWage = 377100.00m, TaxRate = .0815m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Married, TaxBase = 27373.00m, StartingAmount = 377100.00m, MaximumWage = 1077559.00m, TaxRate = .0735m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Married, TaxBase = 78856.00m, StartingAmount = 1077559.00m, MaximumWage = 2155350.00m, TaxRate = .0765m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Married, TaxBase = 161307.00m, StartingAmount = 2155350.00m, MaximumWage = 2209300.00m, TaxRate = .8842m };
                yield return new TaxTable.TaxableWithholding { Region = Region.Yonkers, FilingStatus = FilingStatus.Married, TaxBase = 209010.00m, StartingAmount = 2209300.00m, MaximumWage = Decimal.MaxValue, TaxRate = .0962m };
            }
        }
    }
}