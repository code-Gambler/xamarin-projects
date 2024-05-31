using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UtilityBillsSteven
{
    public partial class MainPage : ContentPage
    {
        List<string> provinces = new List<string>() { "AB", "BC", "ON", "NL" };
        public MainPage()
        {
            InitializeComponent();
            picProvince.ItemsSource = provinces;
        }

        private void CalculateBtn_Clicked(object sender, EventArgs e)
        {
            if (picProvince.SelectedItem == null || enDaytimeUsage.Text == string.Empty || enEveningUsage.Text == string.Empty || enDaytimeUsage.Text == null || enEveningUsage.Text == null)
            {
                btnError.IsVisible = true;
            }
            else
            {

                if (double.TryParse(enDaytimeUsage.Text, out double daytimeUsage) && double.TryParse(enEveningUsage.Text, out double eveningUsage))
                {
                    btnError.IsVisible = false;
                    UtilityBill currentBill = new UtilityBill(daytimeUsage, eveningUsage, picProvince.SelectedItem.ToString(), swUseRenewable.IsToggled);
                    lblCharges.IsVisible = true;
                    lblDaytimeCharges.IsVisible = true;
                    lblDaytimeCharges.Text = $"Daytime Usage Charges: ${currentBill.DaytimeCharge.ToString("0.00")}";
                    lblEveningCharges.IsVisible = true;
                    lblEveningCharges.Text = $"Evening Usage Charges: ${currentBill.EveningCharge.ToString("0.00")}";
                    lblTotalCharges.IsVisible = true;
                    lblTotalCharges.Text = $"Total Charges: ${(currentBill.DaytimeCharge + currentBill.EveningCharge).ToString("0.00")}";
                    lblSalesTax.IsVisible = true;
                    lblSalesTax.Text = $"Sales Tax ({UtilityBill.TaxRate[picProvince.SelectedItem.ToString()] * 100})%: ${currentBill.SalesTax.ToString("0.00")}";
                    if (currentBill.EnvRebate != 0)
                    {
                        lblEnvRebate.IsVisible = true;
                        lblEnvRebate.Text = $"Environmental Rebate: -${currentBill.EnvRebate.ToString("0.00")}";
                    }
                    btnGrandTotal.IsVisible = true;
                    btnGrandTotal.Text = $"You Must Pay: ${currentBill.TotalCharge.ToString("0.00")}";
                }

            }
        }

        private void ResetBtn_Clicked(object sender, EventArgs e)
        {
            picProvince.SelectedItem = null;
            enDaytimeUsage.Text = "";
            enEveningUsage.Text = "";
            btnError.IsVisible = false;
            swUseRenewable.IsToggled = false;
            lblCharges.IsVisible = false;
            lblDaytimeCharges.IsVisible = false;
            lblEveningCharges.IsVisible = false;
            lblTotalCharges.IsVisible = false;
            lblSalesTax.IsVisible = false;
            lblEnvRebate.IsVisible = false;
            btnGrandTotal.IsVisible = false;
        }

        private void picProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picProvince.SelectedItem != null)
            {
                if (picProvince.SelectedItem.ToString() == "BC")
                {
                    swUseRenewable.IsToggled = true;
                    swUseRenewable.IsEnabled = false;
                }
                else
                {
                    swUseRenewable.IsEnabled = true;
                }
            }
        }
    }
}
