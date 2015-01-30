namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Discipline : IDetailable
    {
        private string name;
        private int numberOfLectures;

        public Discipline(string name, int numberOfLectures, string details = null)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.Details = details;
            this.Students = new List<Student>();
        }

        public string Details { get; set; }

        public List<Student> Students { get; set; }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }

                this.name = value;
            }
        }

        public int NumberOfLectures
        {
            get { return this.numberOfLectures; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("numberOfLectures", "Number of lectures cannot be negative.");
                }

                this.numberOfLectures = value;
            }
        }

        public void AddStudents(params Student[] list)
        {
            foreach (Student student in list)
            {
                this.Students.Add(student);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Discipline name: {0}\n", this.Name);
            result.AppendFormat("Number of lectures: {0}\n", this.NumberOfLectures);
            result.AppendFormat("Number of students: {0}\n", this.Students.Count);
            if (this.Details != null)
            {
                result.AppendFormat("Details: {0}", this.Details);
            }

            return result.ToString();
        }
    }
}