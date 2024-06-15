using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteDemo
{
    public partial class App : Application
    {
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
        public App ()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

