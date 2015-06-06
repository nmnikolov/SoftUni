namespace Persons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Persons
    {
        public static void Main()
        {
            const string message = "1.Enter \"1\" to add person  2. Press \"Enter\" to Print";
            IList<Person> persons = new List<Person>();
             
            Console.WriteLine(message);
            string commandLine = Console.ReadLine();

            while (commandLine == "1")
            {
                try
                {
                    Console.Write("\nEnter name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Enter email: ");
                    string email = Console.ReadLine();

                    Person person = new Person(name, age, email != string.Empty ? email : null);
                    persons.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine(Environment.NewLine + message);
                commandLine = Console.ReadLine();
            }

            Console.WriteLine("Persons information:\n{0}", new String('*', 20));
            Console.Write(persons.Any() ? string.Join(new string('*', 20) + "\n", persons.OrderBy(p => p.Name)) : "No persons\n");
            Console.WriteLine(new String('*', 20));
        }
    }  
}