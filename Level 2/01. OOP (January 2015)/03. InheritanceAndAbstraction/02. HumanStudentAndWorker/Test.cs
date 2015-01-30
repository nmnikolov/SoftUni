namespace HumanStudentWorker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Test
    {
        public static void Main()
        {
            try
            {
                Student student = new Student("Test", "Test1", "number1234");
                Worker worker = new Worker("Test", "Worker", 500.00m, 8);

                Console.WriteLine(student);
                Console.WriteLine(worker);
                Console.WriteLine("*************************************************************************");

                List<Student> students = new List<Student>
                {
                    new Student("Ivan", "Ivanov", "fn00000006"),
                    new Student("Nikola", "Nikolov", "fn00000002"),
                    new Student("Georgi", "Georgiev", "fn00000008"),
                    new Student("Stefan", "Stefanov", "fn00000010"),
                    new Student("Todor", "Todorov", "fn00000005"),
                    new Student("Pesho", "Peshev", "fn00000001"),
                    new Student("Marin", "Marinov", "fn00000007"),
                    new Student("Angel", "Angelov", "fn00000003"),
                    new Student("Borislav", "Borisov", "fn00000009"),
                    new Student("Savo", "Savov", "fn00000004")
                };

                students = students.OrderBy(c => c.FacultyNumber).ToList();

                foreach (var st in students)
                {
                    Console.WriteLine(st);
                }

                Console.WriteLine("*************************************************************************");
                List<Worker> workers = new List<Worker>
                {
                    new Worker("Ivan", "Angelov", 430.00m, 6),
                    new Worker("Nikola", "Nikolov", 236.23m, 4),
                    new Worker("Georgi", "Georgiev", 530.13m, 10),
                    new Worker("Stefan", "Stefanov", 140m, 4),
                    new Worker("Todor", "Todorov", 524m, 8),
                    new Worker("Pesho", "Peshev", 325.13m, 6),
                    new Worker("Marin", "Marinov", 1049m, 10),
                    new Worker("Angel", "Angelov", 670m, 5),
                    new Worker("Borislav", "Borisov", 831.4m, 6),
                    new Worker("Savo", "Savov", 314.23m, 5)
                };
                workers = workers.OrderByDescending(c => c.MoneyPerHour()).ToList();

                foreach (var wk in workers)
                {
                    Console.WriteLine(wk);
                }

                Console.WriteLine("*************************************************************************");
                List<Human> humans = new List<Human>();
                humans.AddRange(students);
                humans.AddRange(workers);
                humans = humans.OrderBy(c => c.FirstName).ThenBy(c => c.LastName).ToList();

                foreach (var human in humans)
                {
                    Console.WriteLine(human);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
    }
}