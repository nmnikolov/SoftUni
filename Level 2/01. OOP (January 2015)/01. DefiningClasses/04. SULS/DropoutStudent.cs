using System;

namespace _04.SULS
{
    public class DropoutStudent : Student
    {
        private string dropoutReason;

        public string DropoutReason
        {
            get { return this.dropoutReason; }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Dropout reasen cannot be empty.");
                }

                this.dropoutReason = value;
            }
        }

        public DropoutStudent(string firstName, string Lastname, int age, string studentNumber, double averageGrade, string dropoutReason)
            : base(firstName, Lastname, age, studentNumber, averageGrade)
        {
            this.dropoutReason = dropoutReason;
        }

        public void Reapply()
        {
            string result = base.ToString() + String.Format("Dropout reason: {0}\n", this.dropoutReason);
            Console.WriteLine(result);
        }
    }
}
