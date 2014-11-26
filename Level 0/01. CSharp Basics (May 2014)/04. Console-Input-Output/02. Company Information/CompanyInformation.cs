using System;

//A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number. 
//Write a program that reads the information about a company and its manager and prints it back on the console.
// | program             | user                 | 
// |---------------------|----------------------| 
// | Company name:	     | Software University  | 
// | Company address:    | 26 V. Kanchev, Sofia | 
// | Phone number:       | +359 899 55 55 92    | 
// | Fax number:         |          	        |     
// | Web site:           | http://softuni.bg    |      
// | Manager first name: | Svetlin              |     
// | Manager last name:  | Nakov                |     
// | Manager age:	     | 25                   |         
// | Manager phone:      | +359 2 981 981       |          
// 
// Output:
//  _______________________________________________________
// |                                                       |
// | Software University                                   |   
// | Address: 26 V. Kanchev, Sofia                         |     
// | Tel. +359 899 55 55 92                                |      
// | Fax: (no fax)                                         |  
// | Web site: http://softuni.bg                           |     
// | Manager: Svetlin Nakov (age: 25, tel. +359 2 981 981) |  
// |_______________________________________________________|

class CompanyInformation
{
    static void Main()
    {
        Console.Write("Company name: ");
        string companyName = Console.ReadLine();
        Console.Write("Company address: ");
        string companyAddress = Console.ReadLine();
        Console.Write("Phone number: ");
        string companyPhoneNumber = Console.ReadLine();
        Console.Write("Fax number: ");
        string companyFaxNumber = Console.ReadLine();
        Console.Write("Web site: ");
        string companyWebSite = Console.ReadLine();
        Console.Write("Manager first name: ");
        string managerFirstName = Console.ReadLine();
        Console.Write("Manager last name: ");
        string managerLastName = Console.ReadLine();
        Console.Write("Manager age: ");
        int managerAge = int.Parse(Console.ReadLine());
        Console.Write("Manager phone: ");
        string managerPhoneNumber = Console.ReadLine();

        Console.Clear();
        Console.WriteLine(companyName);
        Console.WriteLine("Address: {0}", companyAddress);
        Console.WriteLine("Tel. {0}", companyPhoneNumber);
        Console.WriteLine("Fax: {0}", String.IsNullOrEmpty(companyFaxNumber) ? "(no fax)" : companyFaxNumber);
        Console.WriteLine("Web site: {0}", companyWebSite);
        Console.Write("Manager: {0} {1}", managerFirstName, managerLastName);
        Console.Write(" (age: {0}, ", managerAge);
        Console.WriteLine("tel. {0})", managerPhoneNumber);      
    }
}