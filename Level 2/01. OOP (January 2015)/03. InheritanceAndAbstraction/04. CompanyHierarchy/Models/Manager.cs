namespace Company.Models
{
    using System.Collections.Generic;

    public class Manager : Employee
    {
        public Manager(string id, string firstName, string lastName, decimal salary, Department department, ISet<Employee> employees = null) 
            : base(id, firstName, lastName, salary, department)
        {
            this.Employees = employees ?? new HashSet<Employee>();
        }

        public ISet<Employee> Employees { get; set; }
    }
}