using CSharpDemo;

internal class Program
{
    static void staticTest()
    {
        // variables
        int x = 25;
        int y = 50;
        int sum = x + y;

        // output to the console
        Console.WriteLine("Hello world!");
        Console.WriteLine(x);
        Console.WriteLine(y);
        Console.WriteLine("My Name is Steven and " + y + " is my lucky number");
        Console.WriteLine($"My Name is Steven and {y} is my lucky number");
    }
    private static void Main(string[] args)
    {
        staticTest();

        // declaring doubles
        int radius = 10;
        double area = radius * radius * Math.PI;
        Console.WriteLine($"The area of a circle with the radius {radius} is {area}");


        // Formatting the output of decimals
        // format the string to specified decimal points
        Console.WriteLine("Area to 2 decimal points: " + area.ToString("0.00"));
        Console.WriteLine("Area to 3 decimal points: " + area.ToString("0.000"));
        Console.WriteLine("Area to 4 decimal points: " + area.ToString("0.0000"));

        // working with strings
        string name = "   Peter Smith   ";
        // print out the string
        Console.WriteLine(name);


        // Removing whitespace from strings

        // remove leading whitespace
        Console.WriteLine($"{name.TrimStart()}!!!!!");
        // remove trailing whitespace
        Console.WriteLine($"{name.TrimEnd()}!!!!!");
        // remove leading and trailing whitespace
        Console.WriteLine($"{name.Trim()}!!!!!");


        // Replacing text

        // replace text
        string updatedName = name.Replace("Smith", "Jones");
        Console.WriteLine(updatedName);

        // upper and lower case
        string city = "Montreal";
        Console.WriteLine(city.ToUpper());
        Console.WriteLine(city.ToLower());

        // search for a substring
        string phrase = "This is the way!";
        Console.WriteLine("Does the sentence contain the word apple? " + phrase.Contains("apple"));
        Console.WriteLine("Does the sentence contain the word 'way'? " + phrase.Contains("way"));

        // conditionals
        int grade = 50;

        if (grade < 50)
        {
            Console.WriteLine("You did not pass the test");
        }
        else
        {
            Console.WriteLine("You passed the test!");
        }

        double gpa = 4.0;
        if (gpa == 4.0)
        {
            Console.WriteLine("A");
        }
        else if (gpa > 2.8 && gpa <= 3.9)
        {
            Console.WriteLine("B");
        }
        else if (gpa == 1.0 || gpa < 2.5)
        {
            Console.WriteLine("C");
        }
        else
        {
            Console.WriteLine("Invalid gpa");
        }

        // loops
        // - while loop
        int count = 4;
        while (count >= 0)
        {
            Console.WriteLine($"Counting down from {count}");
            count = count - 1;
        }

        Console.WriteLine("-------");

        // for loop
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Counting up {i}");
        }

        Console.WriteLine("-------");
        
        // output only even numbers
        for (int i = 0; i < 10; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine($"Even number {i}");
            }
        }

        // working with a list
        List<string> fruits = new List<string> { "apple", "banana", "carrot" };


        // Get the number of items in the list
        // get number of items
        Console.WriteLine($"Number of fruits: {fruits.Count}");


        // Add items to the list
        // add items
        fruits.Add("donut");
        fruits.Add("eggplant");
        Console.WriteLine($"Number of fruits: {fruits.Count}");

        // get a specific item
        Console.WriteLine($"Item at position 0: {fruits[0]}");

        // loop through the list and output all the items
        // for
        for (int i = 0; i < fruits.Count; i++)
        {
            Console.WriteLine($"Fruit at pos {i} is {fruits[i]}");
        }
        Console.WriteLine("--------");

        // output all items in the list
        foreach (string item in fruits)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("--------");

        // programatically get the last item
        string lastItem = fruits[fruits.Count - 1];
        Console.WriteLine($"Last item in the list: {lastItem}");

        // updating the item
        fruits[0] = "avocado";
        Console.WriteLine($"Item at position 0: {fruits[0]}");

        // search for an item
        Console.WriteLine($"Where is carrot? {fruits.IndexOf("carrot")}");
        Console.WriteLine($"Where is orange? {fruits.IndexOf("orange")}");

        // reverse the list
        fruits.Reverse();
        // output all items in the list
        foreach (string item in fruits)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("--------");

        // loop through the list and output all the items
        // for
        for (int i = 0; i < fruits.Count; i++)
        {
            Console.WriteLine($"Fruit at pos {i} is {fruits[i]}");
        }

        // sort in alphabetical order
        fruits.Sort();
        foreach (string item in fruits)
        {
            Console.WriteLine(item);
        }

        // remove an item from the list
        Console.WriteLine("-------");

        fruits.RemoveAt(0);

        foreach (string item in fruits)
        {
            Console.WriteLine(item);
        }

        // remove everything in the list
        fruits.Clear();
        Console.WriteLine($"Number of items in the list: {fruits.Count}");

        Employee emp1 = new Employee("Alex");
        emp1.showEmployeeDetails();

        // update the values of emp1
        emp1.name = "Smith";
        emp1.showEmployeeDetails();
    }

}