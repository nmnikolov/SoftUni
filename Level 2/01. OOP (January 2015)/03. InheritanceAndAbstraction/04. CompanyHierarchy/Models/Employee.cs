namespace Company.Models
{
    using System;
    using System.Text;
    using Interfaces;

    public abstract class Employee : Person, IEmployee
    {
        private decimal salary;

        protected Employee(string id, string firstName, string lastName, decimal salary, Department department)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }
        
        public Department Department { get; set; }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }

            set
            {
                if (value < 0m)
                {
                    throw new ArgumentOutOfRangeException("salary", "Salary cannot be negative.");
                }

                this.salary = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.AppendFormat("Department: {0}\nSalary: {1}\n", this.Department, this.Salary);

            return result.ToString();
        }
    }
}