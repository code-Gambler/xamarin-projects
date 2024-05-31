using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarList
{
    public partial class MainPage : ContentPage
    {
        // list of data
        private List<Car> carsList = new List<Car>();

        public MainPage()
        {
            InitializeComponent();
            carsList.Add(new Car("Telsa Model X", 2022));
            carsList.Add(new Car("Nissan Leaf", 2020));
            carsList.Add(new Car("Honda Civic Hatch", 2010));
            carsList.Add(new Car("BMW Z Series", 2023));
            carsList.Add(new Car("Mercedes S Class", 2020));
            // associate this list of data with the <listView> element in the ui
            lvStudents.ItemsSource = carsList;
        }

        void lvStudents_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Console.WriteLine("ITEM TAPPED :: A row of the listview was clicked");
            Console.WriteLine(e.Item.ToString());
        }

        void lvStudents_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Console.WriteLine("ITEM Selected :: A row of the listview selection state changed");
            Console.WriteLine($"--Selected item pos: {e.SelectedItemIndex}");
            Console.WriteLine($"--Selected item: {e.SelectedItem.ToString()}");
        }

        void BtnAdd_Clicked(System.Object sender, System.EventArgs e)
        {
            Console.WriteLine($"Add button pressed, value is: {txtName.Text}");

            // 1. get the value from the text box
            string nameFromUI = txtName.Text;

            if (string.IsNullOrEmpty(nameFromUI))
            {
                Console.WriteLine("Please enter a name");
            }
            else
            {
                // 2. add that value to the data source for the list view (studentNamesList)
                carsList.Add(new Car(nameFromUI, 2023));

                // 3. reload the list view with its new data source
                lvStudents.ItemsSource = null;          // reset
                lvStudents.ItemsSource = carsList;  // reset with the updated list

                // 4. clear the text box and prepare for new input
                txtName.Text = "";
            }

        }
    }
}
