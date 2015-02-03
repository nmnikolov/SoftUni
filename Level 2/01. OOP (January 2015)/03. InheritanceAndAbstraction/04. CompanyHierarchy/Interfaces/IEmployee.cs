namespace Company.Interfaces
{
    using Models;

    public interface IEmployee
    {
        Department Department { get; set; }

        decimal Salary { get; set; }

        string ToString();
    }
}