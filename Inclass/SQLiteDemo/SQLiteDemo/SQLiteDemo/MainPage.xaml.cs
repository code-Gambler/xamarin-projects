using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLiteDemo {
    public partial class MainPage: ContentPage {
        public MainPage() {
            InitializeComponent();
            Console.WriteLine("+++++++ MainPage Constructor called");
        }

        async void AddItem_Clicked(System.Object sender, System.EventArgs e) {

            // 1. get item information from UI
            string title = txtItemName.Text;
            bool isHighPriority = swPriority.IsToggled;
            // 2. Build the todo list item
            ToDoItem itemToAdd = new ToDoItem(title, isHighPriority);

            // 3. Add it to the database
            int results = await App.MyDb.AddItem(itemToAdd);
            if (results == 0)
            {
                Console.WriteLine("++++ ERROR: Item could not be created");
            }
            else
            {
                Console.WriteLine("++++ Item added!");
            }
            txtItemName.Text = "";
            swPriority.IsToggled = false;

        }

        void Update_Clicked(System.Object sender, System.EventArgs e) {
            // 1. get item information from UI
            string idFromUI = txtItemId.Text;

            // attempt to convert to a number

            // 2. if we get to this point, then the user must have entered a numeric id

            // - find the item


            // 3. if we get to this point, then we must have the object that should be updated

            // - get the updated values from the UI

            // 4. set the item's new values

            // 5. save the changes


            // 6. Clear form fields and prepare for new input
            txtItemName.Text = "";
            swPriority.IsToggled = false;
        }

        void Delete_Clicked(System.Object sender, System.EventArgs e) {
            // 1. get item information from UI
            string idFromUI = txtItemId.Text;

            // attempt to convert to a number


            // if you reach this point, then you have a numeric id number

            // 2. delete from database

            // 3. Clear form fields and prepare for new input
            txtItemId.Text = "";

        }

        void GetItemById_Clicked(System.Object sender, System.EventArgs e) {
            // 1. get item information from UI
            string idFromUI = txtItemId.Text;

            // attempt to convert to a number

            // if you reach this point, then you have a numeric id number

            // 3. Retrieve the data from the database

            // 4. Clear all text fields and prepare for new input
            txtItemId.Text = "";
        }

        void GetAll_Clicked(System.Object sender, System.EventArgs e) {
            // get items from database

        }

        void GetItemsByPriority_Clicked(System.Object sender, System.EventArgs e) {
            // get toggle
            bool isHighPriority = swPriority.IsToggled;

            // get items from database


            // reset form fields
            swPriority.IsToggled = false;
        }
    }
}

