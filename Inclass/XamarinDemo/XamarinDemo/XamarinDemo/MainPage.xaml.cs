using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Console.WriteLine("clicked!");

            // 1. Get name
            string name = txtName.Text;
            // 2. Get age
            string age = txtAge.Text;

            // Calculate how old the person will be in 5 years
            if (Int32.TryParse(age, out int ageInt))
            {
                int updatedAge = ageInt + 5;

                Console.WriteLine($"Your name is {name}. In 5 years you will be {updatedAge} years old.");
                lblResult.Text = $"Your name is {name}. In 5 years you will be {updatedAge} years old.";
            }
            else
            {
                Console.WriteLine("Error converting string to int: age");
                lblResult.Text = "Error converting string to int: age";
            }

            // 5. Clear the text fields for new input
            txtName.Text = "";
            txtAge.Text = "";
        }

        void BtnCountUp_Clicked(System.Object sender, System.EventArgs e)
        {
            Console.WriteLine("Count up clicked");

            setCountLabel("add");
        }

        void BtnCountDown_Clicked(System.Object sender, System.EventArgs e)
        {
            Console.WriteLine("Count down clicked");

            setCountLabel("sub");
        }

        void BtnInitialVal_Clicked(System.Object sender, System.EventArgs e)
        {
            Console.WriteLine("Initial value clicked");

            if (Int32.TryParse(count.Text, out int tempVal))
            {
                setCountLabel("init");
            }
            else
            {
                lblErr.Text = "Please enter a number";
            }
        }

        void setCountLabel(string op)
        {
            lblErr.Text = "";
            if (Int32.TryParse(lblCount.Text, out int val))
            {
                if (op == "add")
                {
                    lblCount.Text = $"{val + 1}";
                }
                else if (op == "sub")
                {
                    lblCount.Text = $"{val - 1}";
                }
                else if (op == "init")
                {
                    lblCount.Text = count.Text;
                    count.Text = "";
                }
            }
            else
            {
                lblErr.Text = "Could not convert string to int";
            }
        }
    }
}
