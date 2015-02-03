namespace Company.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface IDeveloper
    {
        ISet<Project> Projects { get; set; }

        void AddProjects(ISet<Project> projects);

        string ToString();
    }
}