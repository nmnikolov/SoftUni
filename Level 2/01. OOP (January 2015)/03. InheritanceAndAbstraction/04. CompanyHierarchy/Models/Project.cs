namespace Company.Models
{
    using System;

    public class Project
    {
        private string name;

        private string details;

        public Project(string name, string details, DateTime startDate)
        {
            this.Name = name;
            this.Details = details;
            this.StartDate = startDate;
            this.State = ProjectState.Open;
        }

        public string Details { get; set; }

        public string Name {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Project name cannot be empty.");
                }

                this.name = value;
            }
        }

        public DateTime StartDate { get; set; }

        public ProjectState State { get; set; }

        public void Closeproject()
        {
            this.State = ProjectState.Closed;
        }
    }
}