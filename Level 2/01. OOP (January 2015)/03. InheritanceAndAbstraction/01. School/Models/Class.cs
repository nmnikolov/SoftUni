namespace School.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using Interfaces;

    public class Class : IDetailable
    {
        private static readonly List<string> ClassesNames = new List<string>();

        private string className;

        public Class(string className, string details = null)
        {
            this.ClassName = className;
            this.Details = details;
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
        }

        public string Details { get; set; }

        public List<Student> Students { get; set; }

        public List<Teacher> Teachers { get; set; }

        public string ClassName
        {
            get
            {
                return this.className;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }

                if (ClassesNames.Contains(value))
                {
                    throw new DuplicateNameException("Class with this name already exists.");
                }

                ClassesNames.Add(value);
                this.className = value;
            }
        }

        public void AddStudents(params Student[] list)
        {
            foreach (Student student in list)
            {
                this.Students.Add(student);
            }
        }

        public void AddTeachers(params Teacher[] list)
        {
            foreach (Teacher teacher in list)
            {
                this.Teachers.Add(teacher);
            }
        }

        public override string ToString()
        {
            var teachers = this.Teachers
                .Select(r => r.Name.ToString())
                .ToArray();

            var students = this.Students
                .Select(r => r.Name.ToString())
                .ToArray();
            
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Class name: {0}\n", this.ClassName);

            if (teachers.Length > 0)
            {
                result.AppendFormat("Teachers: {0}\n", string.Join(", ", teachers));
            }

            if (students.Length > 0)
            {
                result.AppendFormat("Students: {0}\n", string.Join(", ", students));
            }

            return result.ToString();
        }
    }
}