namespace Persons
{
    using System;

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
            string result = string.Format("Name: {0}\nAge: {1}\nEmail: {2}\n", this.name, this.age, this.email ?? "not provided");

            return result;
        }
    }
}
