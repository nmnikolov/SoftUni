using System;

namespace _01.Persons

{
    class Person
    {
        private String name;

        private int age;

        private String email;

        public String Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException("Cannot create Person.");
                }

                this.name = value;
            }
        }

        public int Age {
            get { return this.age; }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Cannot create Person.");
                }

                this.age = value;
            }
        }

        public String Email {
            get { return this.email; }
            set
            {
                if (value != null && !Validate.IsEmail(value))
                {
                    throw new ArgumentException("Cannot create Person.");
                }

                this.email = value;
            }
        }

        public Person( String name, int age, String email )
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public Person(String name, int age) : this( name, age, null )
        {           
        }

        public override string ToString()
        {
            String result = String.Format( "Name: {0}\nAge: {1}\nEmail: ", this.name, this.age );

            if (!String.IsNullOrEmpty(this.email))
            {
                result += this.email + "\n";
            }
            else
            {
                result += "not provided\n";
            }

            return result;
        }
    }
}
