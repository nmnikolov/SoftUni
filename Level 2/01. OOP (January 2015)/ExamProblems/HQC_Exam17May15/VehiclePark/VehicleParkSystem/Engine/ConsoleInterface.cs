namespace VehicleParkSystem.Engine
{
    using System;
    using Interfaces;

    public class ConsoleInterface : IUserInterface
    {
        public string ReadLine()
        {
            var commandLine = Console.ReadLine();

            return commandLine;
        }

        public void WriteLine(string format, params string[] args)
        {
            Console.WriteLine(format, args);
        }
    }
}