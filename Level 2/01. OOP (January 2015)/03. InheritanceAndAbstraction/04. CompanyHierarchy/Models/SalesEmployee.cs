namespace Company.Models
{
    using System.Collections.Generic;

    public class SalesEmployee : RegularEmployee
    {
        public SalesEmployee(string id, string firstName, string lastName, decimal salary, Department department, ISet<Sale> sales = null) 
            : base(id, firstName, lastName, salary, department)
        {
            this.Sales = sales ?? new HashSet<Sale>();
        }
        
        public ISet<Sale> Sales { get; set; }
    }
}