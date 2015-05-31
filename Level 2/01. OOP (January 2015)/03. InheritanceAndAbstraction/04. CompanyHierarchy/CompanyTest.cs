namespace Company
{
    using System;
    using System.Collections.Generic;
    using Models;

    public class CompanyTest
    {
        public static void Main()
        {
            Manager manager1 = new Manager("000001", "Manager1", "Manager1 Last name", 123m, Department.Marketing);
            Manager manager2 = new Manager("000002", "Manager2", "Manager2 Last name", 351.23m, Department.Production);
            Manager manager3 = new Manager("000003", "Manager2", "Manager2 Last name", 421.53m, Department.Accounting);

            SalesEmployee salesEmployee1 = new SalesEmployee("000004", "SalesEmployee1", "SalesEmployee1 Last name", 212m, Department.Marketing);
            SalesEmployee salesEmployee2 = new SalesEmployee("000005", "SalesEmployee2", "SalesEmployee2 Last name", 163m, Department.Sales);
            SalesEmployee salesEmployee3 = new SalesEmployee("000006", "SalesEmployee3", "SalesEmployee3 Last name", 212m, Department.Production);

            Developer developer1 = new Developer("000007", "Developer1", "Developer1 Last name", 2232m, Department.Marketing);
            Developer developer2 = new Developer("000008", "Developer2", "Developer2 Last name", 93.1m, Department.Production);
            Developer developer3 = new Developer("000009", "Developer3", "Developer3 Last name", 104.23m, Department.Accounting);
            
            Sale sale = new Sale("graphic card", DateTime.Now, 140m);
            Project project = new Project("Php", "Php course", DateTime.Now);

            manager1.AddEmployees(new HashSet<Employee> { salesEmployee1, developer3 });
            salesEmployee1.AddSales(new HashSet<Sale> { sale });
            developer1.AddProjects(new HashSet<Project> { project });

            IList<Employee> employees = new List<Employee>
            {
                manager1,
                manager2,
                manager3,
                salesEmployee1,
                salesEmployee2,
                salesEmployee3,
                developer1,
                developer2,
                developer3
            };

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}