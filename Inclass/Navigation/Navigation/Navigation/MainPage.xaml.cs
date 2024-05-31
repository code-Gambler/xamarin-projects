using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Navigation
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            string nameFromUI = name.Text;
            int ageFromUI = int.Parse(age.Text);
            bool canVoteFromUI = canVote.IsToggled;

            Person p = new Person(nameFromUI, ageFromUI, canVoteFromUI);

            await Navigation.PushAsync(new SecondScreen(p));
        }
    }
}
