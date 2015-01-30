namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Student : Person, IDetailable
    {
        private static readonly List<string> uniqueNumbers = new List<string>();

        private string uniqueNumber ;

        public Student(string name, string uniqueNumber, string details = null)
        {
            this.Name = name;
            this.UniqueNumber = uniqueNumber;
            this.Details = details;
        }

        public string UniqueNumber
        {
            get { return this.uniqueNumber; }
            set
            {
                if (uniqueNumbers.Contains(value))
                {
                    throw new ArgumentException("Student with this unique number already exists.");
                }

                uniqueNumbers.Add(value);
                this.uniqueNumber = value;               
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.AppendFormat("Unique number: {0}\n", this.UniqueNumber);

            return result.ToString();
        }
    }
}