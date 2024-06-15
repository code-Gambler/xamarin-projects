using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteDemo
{
    public class ToDoItem
    {

        // properties
        // define a primary key
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }
        public bool IsHighPriority { get; set; }

        public ToDoItem()
        {
        }
        
        // this is the constructor that will be used to
        // create new items
        public ToDoItem(string title, bool isHighPriority)
        {
            this.Title = title;
            this.IsHighPriority = isHighPriority;
        }

        public override string ToString()
        {
            return $"Id: {this.Id}, Title: {this.Title}, High Priority: {this.IsHighPriority}";
        }
    }
}
