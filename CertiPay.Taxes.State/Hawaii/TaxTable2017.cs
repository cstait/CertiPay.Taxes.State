using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.Hawaii
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 44000; } }

        protected override decimal Allowance { get { return 1144; } }

        protected override IEnumerable<TaxRate> TaxRates
        {
            get
            {
                yield return new TaxRate { FilingStatus = FilingStatus.Single, Floor = 0.00m, Ceiling = 2400, Rate = 0.014m, TaxBase = 0 };
                yield return new TaxRate { FilingStatus = FilingStatus.Single, Floor = 2400, Ceiling = 4800, Rate = 0.032m, TaxBase = 34 };
                yield return new TaxRate { FilingStatus = FilingStatus.Single, Floor = 4800, Ceiling = 9600, Rate = 0.055m, TaxBase = 110 };
                yield return new TaxRate { FilingStatus = FilingStatus.Single, Floor = 9600, Ceiling = 14400, Rate = 0.064m, TaxBase = 374 };
                yield return new TaxRate { FilingStatus = FilingStatus.Single, Floor = 14400, Ceiling = 19200, Rate = 0.068m, TaxBase = 682 };
                yield return new TaxRate { FilingStatus = FilingStatus.Single, Floor = 19200, Ceiling = 24000, Rate = 0.072m, TaxBase = 1008 };
                yield return new TaxRate { FilingStatus = FilingStatus.Single, Floor = 24000, Ceiling = 36000, Rate = 0.076m, TaxBase = 1354 };
                yield return new TaxRate { FilingStatus = FilingStatus.Single, Floor = 36000, Ceiling = decimal.MaxValue, Rate = 0.079m, TaxBase = 2266 };


                yield return new TaxRate { FilingStatus = FilingStatus.Married, Floor = 0.00m, Ceiling = 4800, Rate = 0.014m, TaxBase = 0 };
                yield return new TaxRate { FilingStatus = FilingStatus.Married, Floor = 4800, Ceiling = 9600, Rate = 0.032m, TaxBase = 67 };
                yield return new TaxRate { FilingStatus = FilingStatus.Married, Floor = 9600, Ceiling = 19200,Rate = 0.055m, TaxBase = 221 };
                yield return new TaxRate { FilingStatus = FilingStatus.Married, Floor = 19200,Ceiling = 28800, Rate = 0.064m, TaxBase = 749 };
                yield return new TaxRate { FilingStatus = FilingStatus.Married, Floor = 28800, Ceiling = 38400, Rate = 0.068m, TaxBase = 1363 };
                yield return new TaxRate { FilingStatus = FilingStatus.Married, Floor = 38400, Ceiling = 48000, Rate = 0.072m, TaxBase = 2016 };
                yield return new TaxRate { FilingStatus = FilingStatus.Married, Floor = 48000, Ceiling = 72000, Rate = 0.076m, TaxBase = 2707 };
                yield return new TaxRate { FilingStatus = FilingStatus.Married, Floor = 72000, Ceiling = decimal.MaxValue, Rate = 0.079m, TaxBase = 4531 };

            }
        }
    }
    }    
