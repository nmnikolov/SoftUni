namespace Company.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface IManager
    {
        ISet<Employee> Employees { get; set; }

        void AddEmployees(ISet<Employee> employees);

        string ToString();
    }
}