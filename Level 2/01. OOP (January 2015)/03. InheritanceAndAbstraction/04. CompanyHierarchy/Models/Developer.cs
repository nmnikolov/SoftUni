namespace Company.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;

    public class Developer : RegularEmployee, IDeveloper
    {
        public Developer(string id, string firstName, string lastName, decimal salary, Department department, ISet<Project> projects = null)
            : base(id, firstName, lastName, salary, department)
        {
            this.Projects = projects ?? new HashSet<Project>();
        }
        
        public ISet<Project> Projects { get; set; }

        public void AddProjects(ISet<Project> projects)
        {
            foreach (var project in projects)
            {
                this.Projects.Add(project);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.AppendFormat("Open projects: {0}\n", this.Projects.Count(c => c.State == ProjectState.Open));
            result.AppendFormat("Closed projects: {0}\n", this.Projects.Count(c => c.State == ProjectState.Closed));

            return result.ToString();
        }
    }
}