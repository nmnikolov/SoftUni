using System;

namespace _04.SULS
{
    public class OnsiteStudent : CurrentStudent
    {
        private int numberOfVisits;

        public int NumberOfVisits
        {
            get { return this.numberOfVisits; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("numberOfVisits", "Number of visits cannot be negative.");
                }

                this.numberOfVisits = value;
            }
        }

        public OnsiteStudent(string firstName, string Lastname, int age, string studentNumber, double averageGrade, string currentCourse, int numberOfVisits)
            : base(firstName, Lastname, age, studentNumber, averageGrade, currentCourse)
        {
            this.NumberOfVisits = numberOfVisits;
        }

        public override string ToString()
        {
            string result = base.ToString() + String.Format("Number of visits: {0}\n", this.numberOfVisits);
            return result;
        }
    }
}