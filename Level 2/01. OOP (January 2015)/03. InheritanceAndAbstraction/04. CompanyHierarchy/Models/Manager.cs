namespace Company.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    public class Manager : Employee, IManager
    {
        public Manager(string id, string firstName, string lastName, decimal salary, Department department, ISet<Employee> employees = null) 
            : base(id, firstName, lastName, salary, department)
        {
            this.Employees = employees ?? new HashSet<Employee>();
        }

        public ISet<Employee> Employees { get; set; }

        public void AddEmployees(ISet<Employee> employees)
        {
            foreach (var employee in employees)
            {
                this.Employees.Add(employee);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.AppendFormat("Employees to manage: {0}\n", this.Employees.Count);
            
            return result.ToString();
        }
    }
}