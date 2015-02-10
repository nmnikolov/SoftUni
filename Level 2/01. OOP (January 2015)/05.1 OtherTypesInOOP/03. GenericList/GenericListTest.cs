namespace GenericList
{
    using System;

    class GenericListTest
    {
        public static void Main()
        {
            GenericList<int> test = new GenericList<int>();
            
            Console.WriteLine("Adding an elements: ");
            test.Add(1);
            test.Add(2);
            test.Add(5);
            test.Add(15);
            Console.WriteLine(test);

            Console.WriteLine("Accessing element by index: 3");
            Console.WriteLine(test.ElementAt(3) + "\n");

            Console.WriteLine("Removing element by index: 2");
            test.RemoveAt(2);
            Console.WriteLine(test);

            Console.WriteLine("Inserting element at given position: 0");
            test.InsertAt(0, 100);
            Console.WriteLine(test);

            Console.WriteLine("Finding element index by given value: 2");
            var index = test.FindElementIndex(2);
            Console.WriteLine(index != null ? index.ToString() : "No such element.");
            Console.WriteLine();

            Console.WriteLine("Checking if the list contains values: 100 and 55");
            Console.WriteLine(test.Countains(100));
            Console.WriteLine(test.Countains(55) + "\n");

            Console.WriteLine("Max element:");
            Console.WriteLine(test.Max() + "\n");

            Console.WriteLine("Min element:");
            Console.WriteLine(test.Min() + "\n");

            Console.WriteLine("Clearing the list:");
            test.Clear();
            Console.WriteLine(test);
        }
    }
}