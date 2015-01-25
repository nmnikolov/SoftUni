using System;

namespace _04.SULS
{
    public class Student : Person
    {
        private string studentNumber;

        private double averageGrade;

        public string StudentNumber
        {
            get { return this.studentNumber; }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Student number cannot be empty");
                }

                this.studentNumber = value;
            }
        }

        public double AverageGrade
        {
            get { return this.averageGrade; }

            set
            {
                if (value < 0d)
                {
                    throw new ArgumentOutOfRangeException("averageGrade", "Average grade cannot be negative.");
                }

                this.averageGrade = value;
            }
        }

        public Student(string firstName, string Lastname, int age, string studentNumber, double averageGrade)
            : base(firstName, Lastname, age)
        {
            this.StudentNumber = studentNumber;
            this.AverageGrade = averageGrade;
        }

        public override string ToString()
        {
            string result = base.ToString() + String.Format("Role: {0}\nStudent number: {1}\nAverage grade: {2}\n", this.GetType().Name, this.studentNumber, this.averageGrade);
            return result;
        }
    }
}
