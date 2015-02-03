namespace Company.Models
{
    public abstract class RegularEmployee : Employee
    {
        protected RegularEmployee(string id, string firstName, string lastName, decimal salary, Department department) 
            : base(id, firstName, lastName, salary, department)
        {
        }
    }
}