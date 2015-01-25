using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SULS
{
    class SULSTest
    {
        public static void Main()
        {
            Person test1 = new Person("Test1", "Test", 20);
            Trainer test2 = new Trainer("Test2", "Test", 20);
            JuniorTrainer test3 = new JuniorTrainer("Test3", "Test", 20);
            SeniorTrainer test4 = new SeniorTrainer("Test4", "Test", 20);
            GraduateStudent test5 = new GraduateStudent("Test5", "Test", 20, "123", 5.23d);
            DropoutStudent test6 = new DropoutStudent("Test6", "Test", 20, "123", 4.23d, "Low average grade");
            CurrentStudent test7 = new CurrentStudent("Test7", "Test", 20, "123", 5.48d, "OOP");
            OnlineStudent test8 = new OnlineStudent("Test8", "Test", 20, "123", 5.48d, "OOP");
            OnsiteStudent test9 = new OnsiteStudent("Test9", "Test", 20, "123", 3.23d, "OOP", 2);

            test2.CreateCourse("OOP");
            test3.CreateCourse("OOP");
            test4.DeleteCourse("OOP");

            List<Person> persons = new List<Person>() { test1, test2, test3, test4, test5, test6, test7, test8, test9 };
          
            var currentStudents = persons
                            .Where(person => person is CurrentStudent) 
                            .OrderBy(person => ((Student)person).AverageGrade)
                            .Select(person => person);

            foreach (var student in currentStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}