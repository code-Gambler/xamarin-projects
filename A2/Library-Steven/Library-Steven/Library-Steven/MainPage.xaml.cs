using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Library_Steven
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void clearValues()
        {
            username.Text = "";
            password.Text = "";
        }

        async private void LoginBtn_Clicked(object sender, EventArgs e)
        {
            string user = "";
            if (username.Text != null && password.Text != null && username.Text.Length > 0 && password.Text.Length > 0) 
            {
                switch (username.Text)
                {
                    case "peter":
                        if (password.Text == "1234") user = "peter";
                        break;
                    case "mary":
                        if (password.Text == "0000") user = "mary";
                        break;
                    default:
                        clearValues();
                        await DisplayAlert("Alert", "Wrong username or password", "OK");
                        break;
                }
                if (user.Length > 0)
                {
                    await Navigation.PushAsync(new Library(user));
                    clearValues();
                }
                else
                {
                    clearValues();
                    await DisplayAlert("Alert", "Wrong username or password", "OK");
                }
            }
            else
            {
                clearValues();
                await DisplayAlert("Alert", "Username or password cannot be empty", "OK");
            }
        }
    }
}
