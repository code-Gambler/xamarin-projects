using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Library_Steven
{
    public partial class Library : ContentPage
    {
        public string currentUser { get; set; }
        public Library(string user)
        {
            InitializeComponent();
            currentUser = user;
            lblWelcome.Text = $"Welcome {user}!";
            loadLv();
        }

        async private void loadLv()
        {
            List<Book> polpulatedList = await App.MyDb.GetAllBooks();
            lvBooks.ItemsSource = polpulatedList;

        }

        private void lvBooks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var book = lvBooks.SelectedItem as Book;
            if (!book.BorrowingStatus)
            {
                btnStatusBar.Text = $"{book.Title} is available";
                btnStatusBar.IsVisible = true ;
            }
            else if (book.BorrowingStatus && book.Borrower == currentUser)
            {
                btnStatusBar.Text = $"You have this book checked out!";
                btnStatusBar.IsVisible = true;
            }
            else
            {
                btnStatusBar.Text = $"Sorry, {book.Title} is already checked out by {book.Borrower}";
                btnStatusBar.IsVisible = true;
            }
        }

        async private void Checkout_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            Book book = menuItem.CommandParameter as Book;
            if (!book.BorrowingStatus)
            {
                book.BorrowingStatus = true ;
                book.Borrower = currentUser;
                await App.MyDb.UpdateBook(book);
                btnStatusBar.IsVisible = false ;
                await DisplayAlert("Success", "Done!", "OK");
            }
            else
            {
                if (book.BorrowingStatus && book.Borrower == currentUser)
                {
                    await DisplayAlert("Alert", "You have already checked out this book", "OK");
                }
                else
                {
                    await DisplayAlert("Error", $"The book is already checked out by {book.Borrower}", "OK");
                }
            }

        }

        async private void Return_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            Book book = menuItem.CommandParameter as Book;
            if (book.BorrowingStatus && book.Borrower == currentUser)
            {
                book.BorrowingStatus = false;
                book.Borrower = "";
                await App.MyDb.UpdateBook(book);
                btnStatusBar.IsVisible = false;
                await DisplayAlert("Success", "Done!", "OK");
            }
            else
            {
                await DisplayAlert("Error", "This book cannot be returned", "OK");
            }
        }
    }
}