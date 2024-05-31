using System;
using System.Collections.Generic;
using System.Text;

namespace Navigation
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool CanVote { get; set; }

        public Person(string name, int age, bool canVote)
        {
            this.Name = name;
            this.Age = age;
            this.CanVote = canVote;
        }
    }
}
