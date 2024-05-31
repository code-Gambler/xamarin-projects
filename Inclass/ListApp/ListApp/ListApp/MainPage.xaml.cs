using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListApp
{
    public partial class MainPage : ContentPage
    {
        // list of data
        private List<string> studentsList = new List<string>() { "Alex", "Barbara", "Carlos", "Danielle" };

        public MainPage()
        {
            InitializeComponent();

            // associate this list of data with the <listView> element in the ui
            lvStudents.ItemsSource = studentsList;
        }

        private void lvStudents_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Console.WriteLine("ITEM TAPPED :: A row of the listview was clicked");
            Console.WriteLine(e.Item.ToString());
        }

        private void lvStudents_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Console.WriteLine("ITEM Selected :: A row of the listview selection state changed");
            Console.WriteLine($"--Selected item pos: {e.SelectedItemIndex}");
            Console.WriteLine($"--Selected item: {e.SelectedItem.ToString()}");
        }

        private void Button_Clicked(object sender, EventArgs e)
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
                studentsList.Add(nameFromUI);

                // 3. reload the list view with its new data source
                lvStudents.ItemsSource = null;          // reset
                lvStudents.ItemsSource = studentsList;  // reset with the updated list

                // 4. clear the text box and prepare for new input
                txtName.Text = "";
            }
        }
    }
}
