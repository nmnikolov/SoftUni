namespace VehicleParkSystem.Engine
{
    using System;
    using Interfaces;

    public class VehicleParkSystemEngine : IEngine
    {
        private readonly CommandManager commandManager;

        private readonly IUserInterface userInterface;

        public VehicleParkSystemEngine(CommandManager commandManager, IUserInterface userInterface)
        {
            this.commandManager = commandManager;
            this.userInterface = userInterface;
        }

        public VehicleParkSystemEngine()
            : this(new CommandManager(), new ConsoleInterface())
        {
        }

        public void Run()
        {
            while (true)
            {
                var commandLine = this.userInterface.ReadLine();
                if (commandLine == null)
                {
                    break;
                }

                commandLine = commandLine.Trim();
                if (!string.IsNullOrEmpty(commandLine))
                {
                    try
                    {
                        var command = new Command(commandLine);
                        var commandResult = this.commandManager.Execute(command);
                        this.userInterface.WriteLine(commandResult);
                    }
                    catch (Exception ex)
                    {
                        this.userInterface.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}