namespace GithubIssueTracker.UserInterface
{
    using System;
    using Interfaces;

    public class ConsoleInterface : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string format)
        {
            Console.WriteLine(format);
        }
    }
}