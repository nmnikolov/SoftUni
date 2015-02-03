using System.Text;

namespace HumanStudentWorker.Models
{
    using System;

    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Fist name cannot be empty.");
                }

                this.firstName = value;
            }          
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name cannot be empty.");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Role: {0}\n", this.GetType().Name);
            result.AppendFormat("First name: {0}\n", this.FirstName);
            result.AppendFormat("Last name: {0}\n", this.LastName);

            return result.ToString();
        }
    }
}