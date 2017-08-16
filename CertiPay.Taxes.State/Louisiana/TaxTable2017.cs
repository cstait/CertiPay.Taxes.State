using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.State.Louisiana
{
    public class TaxTable2017 : TaxTable
    {
        public override int Year { get { return 2017; } }

        public override Decimal SUI_Wage_Base { get { return 7700; } }

        public override decimal DependentExemption { get { return 1000; } }

        public override decimal PersonalExemption { get { return 4500; } }

        public override IEnumerable<Rate> Rates
        {
            get
            {
                yield return new Rate { Exemptions = 0, FilingStatus = FilingStatus.Single, ExemptionCap = 12500, LowerCeiling = 12500, HigherCeiling = 50000, LowRate = 0.0135m, MiddleRate = 0.0160m, HighRate = 0.021m };
                yield return new Rate { Exemptions = 1, FilingStatus = FilingStatus.Single, ExemptionCap = 12500, LowerCeiling = 12500, HigherCeiling = 50000, LowRate = 0.0135m, MiddleRate = 0.0160m, HighRate = 0.021m };
                yield return new Rate { Exemptions = 0, FilingStatus = FilingStatus.Married, ExemptionCap = 12500, LowerCeiling = 12500, HigherCeiling = 50000, LowRate = 0.0135m, MiddleRate = 0.0160m, HighRate = 0.021m };
                yield return new Rate { Exemptions = 1, FilingStatus = FilingStatus.Married, ExemptionCap = 12500, LowerCeiling = 12500, HigherCeiling = 50000, LowRate = 0.0135m, MiddleRate = 0.0160m, HighRate = 0.021m };
                yield return new Rate { Exemptions = 2, FilingStatus = FilingStatus.Married, ExemptionCap = 25000, LowerCeiling = 25000, HigherCeiling = 100000, LowRate = 0.0135m, MiddleRate = 0.0165m, HighRate = 0.021m };
                yield return new Rate { Exemptions = 2, FilingStatus = FilingStatus.Single, ExemptionCap = 25000, LowerCeiling = 25000, HigherCeiling = 100000, LowRate = 0.0135m, MiddleRate = 0.0165m, HighRate = 0.021m };
            }
        }
    }
}