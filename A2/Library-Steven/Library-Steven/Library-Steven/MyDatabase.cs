using SQLite;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library_Steven
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
            string databasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "Library.db");
            Console.WriteLine($"++++++ Database path: {databasePath}");

            // - specify "where" on the device the file will be saved
            dbConnection = new SQLiteAsyncConnection(databasePath);

            // Create the table (based on the TodoItem)
            dbConnection.CreateTableAsync<Book>().Wait();

            // Done!
            Console.WriteLine($"++++++ Database table created!");
        }

        // CRUD operations
        public async Task<int> AddBook(Book bookToAdd)
        {
            int numRowsAdded = await dbConnection.InsertAsync(bookToAdd);
            return numRowsAdded;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            List<Book> resultsList = await dbConnection.Table<Book>().ToListAsync();
            return resultsList;
        }

        public async Task<int> UpdateBook(Book book)
        {
            int result = await dbConnection.UpdateAsync(book);
            return result;
        }

        public async Task<Book> GetBookById(int id)
        {
            Book result =   await dbConnection.GetAsync<Book>(id);
            return result;
        }

        public async Task<int> DeleteAll()
        {
            return await dbConnection.DeleteAllAsync<Book>();
        }
    }
}
