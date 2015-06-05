namespace GithubIssueTracker.Execution
{
    using System;
    using Interfaces;
    using Models;

    public class CommandExecutor
    {
        public CommandExecutor(IIssueTracker tracker)
        {
            this.Tracker = tracker;
        }

        public CommandExecutor()
            : this(new GithubIssueTracker())
        {
        }

        public IIssueTracker Tracker { get; private set; }

        public string ExecuteCommand(ICommand command)
        {
            string commandResult;

            switch (command.Name)
            {
                case "RegisterUser":
                    commandResult = this.ExecuteRegisterUserCommand(command);
                    break;
                case "LoginUser":
                    commandResult = this.ExecuteLoginUserCommand(command);
                    break;
                case "LogoutUser":
                    commandResult = this.ExecuteLogoutUserCommand(command);
                    break;
                case "CreateIssue":
                    commandResult = this.ExecuteCreateIssueCommand(command);
                    break;
                case "RemoveIssue":
                    commandResult = this.ExecuteRemoveIssueCommand(command);
                    break;
                case "AddComment":
                    commandResult = this.ExecuteAddCommentCommand(command);
                    break;
                case "MyIssues":
                    commandResult = this.ExecuteMyIssuesCommand();
                    break;
                case "MyComments":
                    commandResult = this.ExecuteMyCommentsCommand();
                    break;
                case "Search":
                    commandResult = this.ExecuteSearchCommand(command);
                    break;
                default:
                    throw new InvalidOperationException(string.Format("Invalid action: {0}", command.Name));
            }

            return commandResult;
        }

        private string ExecuteRegisterUserCommand(ICommand command)
        {
            string commandResult = this.Tracker.RegisterUser(
                command.Parameters["username"],
                command.Parameters["password"],
                command.Parameters["confirmPassword"]);

            return commandResult;
        }

        private string ExecuteLoginUserCommand(ICommand command)
        {
            string commandResult = this.Tracker.LoginUser(command.Parameters["username"], command.Parameters["password"]);

            return commandResult;
        }

        private string ExecuteLogoutUserCommand(ICommand command)
        {
            string commandResult = this.Tracker.LogoutUser();

            return commandResult;
        }

        private string ExecuteCreateIssueCommand(ICommand command)
        {
            string commandResult = this.Tracker.CreateIssue(
                command.Parameters["title"],
                command.Parameters["description"],
                (IssuePriority)Enum.Parse(typeof(IssuePriority), command.Parameters["priority"], true),
                command.Parameters["tags"].Split('|'));

            return commandResult;
        }

        private string ExecuteRemoveIssueCommand(ICommand command)
        {
            string commandResult = this.Tracker.RemoveIssue(int.Parse(command.Parameters["id"]));

            return commandResult;
        }

        private string ExecuteAddCommentCommand(ICommand command)
        {
            string commandResult = this.Tracker.AddComment(int.Parse(command.Parameters["id"]), command.Parameters["text"]);

            return commandResult;
        }

        private string ExecuteMyIssuesCommand()
        {
            string commandResult = this.Tracker.GetMyIssues();

            return commandResult;
        }

        private string ExecuteMyCommentsCommand()
        {
            string commandResult = this.Tracker.GetMyComments();

            return commandResult;
        }

        private string ExecuteSearchCommand(ICommand command)
        {
            string commandResult = this.Tracker.SearchForIssues(command.Parameters["tags"].Split('|'));

            return commandResult;
        }
    }
}