using System;

namespace _01.Persons
{
    class Test
    {
        public static void Main()
        {
            try
            {
                Person test1 = new Person("Test1", 20);
                Person test2 = new Person("Test2", 20, "test@gmail.com");
                Console.WriteLine(test1.ToString());
                Console.WriteLine(test2.ToString());
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong input data.");
            }          
        }
    }  
}