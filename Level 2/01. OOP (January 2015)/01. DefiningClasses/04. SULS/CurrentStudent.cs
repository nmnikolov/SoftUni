using System;

namespace _04.SULS
{
    public class CurrentStudent : Student
    {
        private string currentCourse;

        public string CurrentCourse
        {
            get { return this.currentCourse; }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Current course cannot be empty");
                }

                this.currentCourse = value;
            }
        }

        public CurrentStudent(string firstName, string Lastname, int age, string studentNumber, double averageGrade, string currentCourse)
            : base(firstName, Lastname, age, studentNumber, averageGrade)
        {
            this.CurrentCourse = currentCourse;
        }

        public override string ToString()
        {
            string result = base.ToString() + String.Format("Current course: {0}\n", this.currentCourse);
            return result;
        }
    }
}