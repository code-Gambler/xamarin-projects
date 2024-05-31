using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace UtilityBillsSteven
{
    public class UtilityBill
    {
        private static readonly Dictionary<String, double> RatePerKwh = new Dictionary<String, double>() { { "Daytime", 0.314 },{ "Evening", 0.186 }};
        public static readonly Dictionary<String, double> TaxRate = new Dictionary<String, double>() { { "AB", 0 },{ "BC", 0.12 },{ "ON", 0.13 },{ "NL", 0.15 } };
        public double DaytimeCharge { get; set; }
        public double EveningCharge { get; set; }
        public double SalesTax { get; set; }
        public double EnvRebate { get; set; }
        public double TotalCharge { get; set; }

        public UtilityBill(double daytimeUsage, double eveningUsage, string province, bool usedRenewable)
        {
            this.DaytimeCharge = daytimeUsage * RatePerKwh["Daytime"];
            this.EveningCharge = eveningUsage * RatePerKwh["Evening"];
            this.SalesTax = (this.DaytimeCharge + this.EveningCharge) * TaxRate[province];

            if (usedRenewable)
            {
                this.EnvRebate = (this.DaytimeCharge + this.EveningCharge) * 0.095;
            }
            else
            {
                this.EnvRebate = 0;
            }

            this.TotalCharge = this.DaytimeCharge + this.EveningCharge + this.SalesTax - this.EnvRebate;
        }
    }
}
