namespace School
{
    using System;
    using System.Text;

    public abstract class Person
    {
        private string name;

        public string Details { get; set; }

        public string Name
        {
            get { return this.name; }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Name cannot be empty;");
                }

                this.name = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Role: {0}\nName: {1}\n", GetType().Name, this.Name);
            if (this.Details != null)
            {
                result.AppendFormat("Details: {0}\n", this.Details);
            }
            return result.ToString();

        }
    }
}