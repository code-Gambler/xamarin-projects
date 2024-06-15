using System;
using System.Collections.Generic;
using System.Data.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Library_Steven
{
    public partial class App : Application
    {
        // list of data
        private List<Book> bookList = new List<Book>() {     new Book("059035342X", "Harry Potter and the Philosopher's Stone", "J.K Rowling"),
                                                             new Book("0439023483", "The Hunger Games", "Suzanne Collins"),
                                                             new Book("9780385737951", "The Maze Runner", "James Dashner"),
                                                             new Book("055389787X", "A Storm of Swords", "George R. R. Martin")};
        // create an instance of the MyDatabase class
        // implement it as a singleton
        private static MyDatabase db;
        public static MyDatabase MyDb
        {
            get
            {
                if (db == null)
                {
                    db = new MyDatabase();
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        async protected override void OnStart()
        {
            List<Book> currentList = await MyDb.GetAllBooks();
            if (currentList.Count == 0)
            {
                foreach (var book in bookList)
                {
                    await MyDb.AddBook(book);
                }

            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
