namespace HumanStudentWorker.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;
    using System.Text.RegularExpressions;
    using Interfaces;

    public class Student : Human, INamable
    {
        private static List<string> facultyNumbers = new List<string>(); 

        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }

            set
            {
                if (!Regex.IsMatch(value, @"^[a-zA-Z\d]{5,10}$"))
                {
                    throw new ArgumentException("Faulty number should contain only letters and numbers and length in the range [5...10].");
                }

                if (facultyNumbers.Contains(value))
                {
                    throw new DuplicateNameException("Student with this faculty number already exists.");
                }

                facultyNumbers.Add(value);
                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.AppendFormat("Faculty number: {0}\n", this.FacultyNumber);

            return result.ToString();
        }
    }
}