namespace _01.Persons
{
    using System;

    public class Persons
    {
        public static void Main()
        {
            try
            {
                Person test1 = new Person("Test1", 20);
                Person test2 = new Person("Test2", -20, "test@gmail.com");

                // Person test3 = new Person("Test2", 20, "testgmail.com");
                Console.WriteLine(test1);
                Console.WriteLine(test2);

                // Console.WriteLine(test3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }          
        }
    }  
}