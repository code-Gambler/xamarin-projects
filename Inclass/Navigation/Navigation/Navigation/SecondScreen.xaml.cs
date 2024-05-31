using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondScreen : ContentPage
    {
        public SecondScreen(Person p)
        {
            InitializeComponent();
            lblName.Text = $"Hello {p.Name}! You are {p.Age} years old and your voting status is: {p.CanVote}";
        }
    }
}