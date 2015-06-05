namespace GithubIssueTracker.Core
{
    using System;
    using Execution;
    using Interfaces;
    using UserInterface;

    public class GithubIssueTrackerEngine
    {
        private readonly CommandExecutor commandExecutor;

        // DI: decouple the implementation of the input and output commands from the console using dependency. Added IUserInterface.
        private readonly IUserInterface userInterface;

        public GithubIssueTrackerEngine(CommandExecutor commandExecutor, IUserInterface userInterface)
        {
            this.commandExecutor = commandExecutor;
            this.userInterface = userInterface;
        }

        public GithubIssueTrackerEngine()
            : this(new CommandExecutor(), new ConsoleInterface())
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
                        var commandResult = this.commandExecutor.ExecuteCommand(command);
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