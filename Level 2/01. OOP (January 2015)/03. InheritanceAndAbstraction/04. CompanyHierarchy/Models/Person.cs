namespace Company.Models
{
    using System;
    using System.Text.RegularExpressions;

    public abstract class Person
    {
        private string id;

        private string firstName;

        private string lastName;

        protected Person(string id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.lastName = lastName;
        }

        public string Id
        {
            get { return this.id; }

            set
            {
                if (!Regex.IsMatch(value, @"^[a-zA-Z\d]{6}$"))
                {
                    throw new ArgumentOutOfRangeException("id", "Id should be 6 symbols long and contain only letters and digits.");
                }

                this.id = value;
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Firstname cannot be empty.");
                }

                this.firstName = value;
            }
        }
        
        public string LirstName
        {
            get { return this.lastName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Lastname cannot be empty.");
                }

                this.lastName = value;
            }
        }
    }
}