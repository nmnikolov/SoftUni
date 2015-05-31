namespace Company.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    public class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        public SalesEmployee(string id, string firstName, string lastName, decimal salary, Department department, ISet<Sale> sales = null) 
            : base(id, firstName, lastName, salary, department)
        {
            this.Sales = sales ?? new HashSet<Sale>();
        }
        
        public ISet<Sale> Sales { get; set; }

        public void AddSales(ISet<Sale> sales)
        {
            foreach (var sale in sales)
            {
                this.Sales.Add(sale);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.AppendFormat("Number of sales: {0}\n", this.Sales.Count);

            return result.ToString();
        }
    }
}