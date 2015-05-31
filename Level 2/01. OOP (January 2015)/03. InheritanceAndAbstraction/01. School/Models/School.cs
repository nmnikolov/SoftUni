namespace School.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class School
    {
        private string name;
        
        public School(string name)
        {
            this.Name = name;
            this.Classes = new List<Class>();
        }

        public List<Class> Classes { get; set; }

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
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public void AddClasses(params Class[] list)
        {
            foreach (Class className in list)
            {
                this.Classes.Add(className);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (Class className in this.Classes)
            {
                result.Append(className);
            }

            return result.ToString();
        }
    }
}