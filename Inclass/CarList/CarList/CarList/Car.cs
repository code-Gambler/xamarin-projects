using System;
using System.Collections.Generic;
using System.Text;

namespace CarList
{
    public class Car
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public Car(string model, int year) 
        {
            this.Model = model;
            this.Year = year;
        }

        public override string ToString()
        {
            return $"{this.Year} {this.Model}";
        }
    }
}
