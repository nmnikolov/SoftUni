namespace Company.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Models;

    public interface IProject
    {
        string Name { get; set; }

        string Details { get; set; }

        DateTime StartDate { get; set; }

        ProjectState State { get; set; }

        void Closeproject();
    }
}