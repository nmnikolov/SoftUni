namespace Persons
{
    using System;
    using System.Text;

    public class Person
    {
        private string name;

        private int age;

        private string email;

        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public Person(string name, int age)
            : this(name, age, null)
        {
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty or null.");
                }

                this.name = value;
            }
        }

        public int Age 
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException("Age must be in the range [1..100].");
                }

                this.age = value;
            }
        }

        public string Email 
        {
            get
            {
                return this.email;
            }

            set
            {
                if (!string.IsNullOrEmpty(value) && !Validate.IsEmail(value))
                {
                    throw new ArgumentException("Invalid Email.");
                }

                this.email = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Name: {0}", this.Name)
                .AppendLine()
                .AppendFormat("Age: {0}", this.Age)
                .AppendLine()
                .AppendFormat("Email: {0}", this.Email ?? "not provided")
                .AppendLine();

            return result.ToString();
        }
    }
}
