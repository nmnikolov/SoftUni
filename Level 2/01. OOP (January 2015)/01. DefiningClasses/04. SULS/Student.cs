namespace _04.SULS
{
    using System;

    public class Student : Person
    {
        private string studentNumber;

        private double averageGrade;

        public Student(string firstName, string lastName, int age, string studentNumber, double averageGrade)
            : base(firstName, lastName, age)
        {
            this.StudentNumber = studentNumber;
            this.AverageGrade = averageGrade;
        }

        public string StudentNumber
        {
            get
            {
                return this.studentNumber;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Student number cannot be empty");
                }

                this.studentNumber = value;
            }
        }

        public double AverageGrade
        {
            get
            {
                return this.averageGrade;
            }

            set
            {
                if (value < 0d)
                {
                    throw new ArgumentOutOfRangeException("averageGrade", "Average grade cannot be negative.");
                }

                this.averageGrade = value;
            }
        }
        
        public override string ToString()
        {
            string result = base.ToString() + string.Format("Role: {0}\nStudent number: {1}\nAverage grade: {2}\n", this.GetType().Name, this.studentNumber, this.averageGrade);
            return result;
        }
    }
}
