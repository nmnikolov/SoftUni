namespace _04.SULS
{
    using System;

    public class DropoutStudent : Student
    {
        private string dropoutReason;

        public DropoutStudent(string firstName, string lastName, int age, string studentNumber, double averageGrade, string dropoutReason)
            : base(firstName, lastName, age, studentNumber, averageGrade)
        {
            this.dropoutReason = dropoutReason;
        }

        public string DropoutReason
        {
            get
            {
                return this.dropoutReason;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Dropout reasen cannot be empty.");
                }

                this.dropoutReason = value;
            }
        }
        
        public void Reapply()
        {
            string result = this + string.Format("Dropout reason: {0}\n", this.dropoutReason);
            Console.WriteLine(result);
        }
    }
}
