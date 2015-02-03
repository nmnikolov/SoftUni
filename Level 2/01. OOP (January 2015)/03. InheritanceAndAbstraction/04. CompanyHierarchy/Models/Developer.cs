namespace Company.Models
{
    using System.Collections.Generic;

    public class Developer : RegularEmployee
    {
        public Developer(string id, string firstName, string lastName, decimal salary, Department department, ISet<Project> projects = null)
            : base(id, firstName, lastName, salary, department)
        {
            this.Projects = projects ?? new HashSet<Project>();
        }
        
        public ISet<Project> Projects { get; set; }
    }
}