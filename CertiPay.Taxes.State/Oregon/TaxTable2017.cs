using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.Oregon
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 38400; } }

        protected override decimal UpperBracket
        {
            get
            {
                { return 50000.00m; }
            }
        }

        protected override IEnumerable<FederalLimit> FederalLimits
        {
            get
            {
                yield return new FederalLimit { FilingStatus = FilingStatus.Single, MinWage = 0.00m, MaxWage = 65000.00m, Amount = 6550 };                                                
                yield return new FederalLimit { FilingStatus = FilingStatus.Single, MinWage = 125000.00m, MaxWage = 130000.00m, Amount = 5200 };
                yield return new FederalLimit { FilingStatus = FilingStatus.Single, MinWage = 130000.00m, MaxWage = 135000.00m, Amount = 3900 };
                yield return new FederalLimit { FilingStatus = FilingStatus.Single, MinWage = 135000.00m, MaxWage = 140000.00m, Amount = 2600 };
                yield return new FederalLimit { FilingStatus = FilingStatus.Single, MinWage = 140000.00m, MaxWage = 145000.00m, Amount = 1300 };
                yield return new FederalLimit { FilingStatus = FilingStatus.Single, MinWage = 145000.00m, MaxWage = decimal.MaxValue, Amount = 0 };

                yield return new FederalLimit { FilingStatus = FilingStatus.Married, MinWage = 0.00m, MaxWage = 250000.00m, Amount = 6550 };
                yield return new FederalLimit { FilingStatus = FilingStatus.Married, MinWage = 250000.00m, MaxWage = 260000.00m, Amount = 5200 };
                yield return new FederalLimit { FilingStatus = FilingStatus.Married, MinWage = 260000.00m, MaxWage = 270000.00m, Amount = 3900 };
                yield return new FederalLimit { FilingStatus = FilingStatus.Married, MinWage = 270000.00m, MaxWage = 280000.00m, Amount = 2600 };
                yield return new FederalLimit { FilingStatus = FilingStatus.Married, MinWage = 280000.00m, MaxWage = 290000.00m, Amount = 1300 };
                yield return new FederalLimit { FilingStatus = FilingStatus.Married, MinWage = 290000.00m, MaxWage = decimal.MaxValue, Amount = 0 };

            }
        }
        protected override IEnumerable<TaxTable.StandardDeduction> StandardDeductions
        {
            get
            {
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Single, Amount = 2175.00m, MinAllowance = 0, MaxAllowance = 3};
                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Single, Amount = 4350.00m, MinAllowance = 3, MaxAllowance = int.MaxValue};                                

                yield return new TaxTable.StandardDeduction { FilingStatus = FilingStatus.Married, Amount = 4350.00m};                
                
            }
        }

        protected override IEnumerable<PersonalAllowance> PersonalAllowances
        {
            get
            {
                yield return new PersonalAllowance { FilingStatus = FilingStatus.Single, MinWage = 0.00m, MaxWage = 100000.00m, Amount = 197.00m };
                yield return new PersonalAllowance { FilingStatus = FilingStatus.Single, MinWage = 100000.00m, MaxWage = decimal.MaxValue, Amount = 0.00m };

                yield return new PersonalAllowance { FilingStatus = FilingStatus.Married, MinWage = 0.00m, MaxWage = 200000.00m, Amount = 197.00m };
                yield return new PersonalAllowance { FilingStatus = FilingStatus.Married, MinWage = 200000.00m, MaxWage = decimal.MaxValue, Amount = 0.00m };
            }
        }
        protected override IEnumerable<TaxableWithholding> TaxableWithholdings
        {
            get
            {
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, MinAllowance = 0, MaxAllowance = 3, MinWage = 0, MaxWage = 3400, TaxBase = 197, TaxRate = 0.05m, ExcessLimit = 0 };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, MinAllowance = 0, MaxAllowance = 3, MinWage = 3400, MaxWage = 8500, TaxBase = 367, TaxRate = 0.07m, ExcessLimit = 3400 };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, MinAllowance = 0, MaxAllowance = 3, MinWage = 8500, MaxWage = 50000, TaxBase = 724, TaxRate = 0.09m, ExcessLimit = 8500 };

                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, MinAllowance = 3, MaxAllowance = int.MaxValue, MinWage = 0, MaxWage = 6800, TaxBase = 197, TaxRate = 0.05m, ExcessLimit = 0 };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, MinAllowance = 3, MaxAllowance = int.MaxValue, MinWage = 6800, MaxWage = 17000, TaxBase = 537, TaxRate = 0.07m, ExcessLimit = 6800 };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, MinAllowance = 3, MaxAllowance = int.MaxValue, MinWage = 17000, MaxWage = 50000, TaxBase = 1251, TaxRate = 0.09m, ExcessLimit = 17000 };


                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, MinAllowance = 0, MaxAllowance = 3, MinWage = 41275, MaxWage = 125000, TaxBase = 527, TaxRate = 0.09m, UpperBracket = true, ExcessLimit = 8500.00m };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, MinAllowance = 0, MaxAllowance = 3, MinWage = 125000, MaxWage = decimal.MaxValue, TaxBase = 11012, TaxRate = 0.099m, UpperBracket = true, ExcessLimit = 125000.00m};


                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, MinAllowance = 3, MaxAllowance = int.MaxValue, MinWage = 39100, MaxWage = 250000, TaxBase = 1054, TaxRate = 0.09m, UpperBracket = true, ExcessLimit =  17000};
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Single, MinAllowance = 3, MaxAllowance = int.MaxValue, MinWage = 250000, MaxWage = decimal.MaxValue, TaxBase = 22024, TaxRate = 0.099m, UpperBracket = true, ExcessLimit = 250000 };




                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, MinWage = 0, MaxWage = 6800, TaxBase = 197, TaxRate = 0.05m, ExcessLimit = 0};
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, MinWage = 6800, MaxWage = 17000, TaxBase = 537, TaxRate = 0.07m, ExcessLimit = 6800 };
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, MinWage = 17000, MaxWage = 50000, TaxBase = 1251, TaxRate = 0.09m, ExcessLimit = 17000};

                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, MinWage = 39100, MaxWage = 250000, TaxBase = 1054, TaxRate = 0.09m, UpperBracket = true, ExcessLimit = 17000};
                yield return new TaxableWithholding { FilingStatus = FilingStatus.Married, MinWage = 250000, MaxWage = decimal.MaxValue, TaxBase = 22024, TaxRate = 0.099m, UpperBracket = true, ExcessLimit = 250000 };


            }
        }

    }
}
