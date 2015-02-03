namespace School
{
    using System;
    using Models;

    class Test
    {
        public static void Main()
        {
            try
            {
                School softUni = new School("SoftUni");

                Student student1 = new Student("Test1", "a123", "some details");
                Student student2 = new Student("Test2", "a12");

                Discipline discipline = new Discipline("PHP", 10, "Enter details here");
                discipline.AddStudents(student1, student2);

                Teacher teacher = new Teacher("Angel", "Teacher details");
                teacher.AddDisciplines(discipline, discipline, discipline);
                
                Class classB1 = new Class("B1", "This is class details.");
                classB1.AddStudents(student1, student2);
                classB1.AddTeachers(teacher);

                softUni.AddClasses(classB1);

                Console.WriteLine(softUni);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}