namespace Battleships.ConsoleClient.Engine
{
    using System;
    using Execution;
    using Interfaces;
    using UserInterface;

    public class BattleshipsEngine : IEngine
    {
        private readonly CommandExecutor commandExecutor;
        private readonly IUserInterface userInterface;
        private readonly BattleshipsData data;

        public BattleshipsEngine(CommandExecutor commandExecutor, IUserInterface userInterface, BattleshipsData data)
        {
            this.commandExecutor = commandExecutor;
            this.userInterface = userInterface;
            this.data = data;
        }

        public BattleshipsEngine()
            : this(new CommandExecutor(), new ConsoleInterface(), new BattleshipsData())
        {
        }

        public void Run()
        {
            string commandLine = this.userInterface.ReadLine();

            while (commandLine != "exit")
            {
                commandLine = commandLine.Trim();
                if (!string.IsNullOrEmpty(commandLine))
                {
                    try
                    {
                        var command = new Command(commandLine);
                        string commandResult = this.commandExecutor.ExecuteCommand(command, this.data);
                        this.userInterface.WriteLine(commandResult);
                    }
                    catch (Exception ex)
                    {
                        this.userInterface.WriteLine(ex.Message);
                    }
                }

                commandLine = this.userInterface.ReadLine();
            }
        }
    }
}