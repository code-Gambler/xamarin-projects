using System;
using SQLite;
using System.IO;
using System.Threading.Tasks;

namespace SQLiteDemo
{
    public class MyDatabase
    {

        // 1. Define a property that represents the connection to the database
        // - C# property modifier
        // - only the constructor can modify the value of this property
        // (no other methods in the class can modify it)
        readonly SQLiteAsyncConnection dbConnection;

        public MyDatabase()
        {
            // Configure the connection

            // - specifying the name of the database file
            string databasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "TodoDatabase.db");
            Console.WriteLine($"++++++ Database path: {databasePath}");

            // - specify "where" on the device the file will be saved
            dbConnection = new SQLiteAsyncConnection(databasePath);

            // Create the table (based on the TodoItem)
            dbConnection.CreateTableAsync<ToDoItem>().Wait();

            // Done!
            Console.WriteLine($"++++++ Database table created!");
        }

        // CRUD operations
        public async Task<int> AddItem(ToDoItem itemToAdd)
        {
            // INSERT INTO TodoItems (...,...,..,)
            int numRowsAdded = await dbConnection.InsertAsync(itemToAdd);
            return numRowsAdded;
        }
    }
}