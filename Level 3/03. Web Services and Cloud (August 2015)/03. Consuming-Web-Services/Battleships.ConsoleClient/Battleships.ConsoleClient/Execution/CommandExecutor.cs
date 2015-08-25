namespace Battleships.ConsoleClient.Execution
{
    using System;
    using Interfaces;
    using Utilities;

    public class CommandExecutor
    {
        public string ExecuteCommand(ICommand command, BattleshipsData data)
        {
            string commandResult;

            switch (command.Name)
            {
                case "register":
                    commandResult = this.ExecuteRegisterCommand(command, data);
                    break;
                case "login":
                    commandResult = this.ExecuteLoginCommand(command, data);
                    break;
                case "logout":
                    commandResult = this.ExecuteLogOutCommand(command, data);
                    break;
                case "create-game":
                    commandResult = this.ExecuteCreateGameCommand(command, data);
                    break;
                case "join-game":
                    commandResult = this.ExecuteJoinGameCommand(command, data);
                    break;
                case "play":
                    commandResult = this.ExecutePlayCommand(command, data);
                    break;
                default:
                    throw new InvalidOperationException(Messages.InvalidCommandError);
            }

            return commandResult;
        }
        
        private string ExecuteRegisterCommand(ICommand command, BattleshipsData data)
        {
            this.ValidateParametersLength(command, 3);
            this.ValidateUser(false, data, Messages.RegistrationWhileLoggedError);
            
            var restQueriesExecutor = new RestQueriesExecutor();
            var result = restQueriesExecutor.RegisterAsync(command);

            return result.Result;
        }

        private string ExecuteLoginCommand(ICommand command, BattleshipsData data)
        {
            this.ValidateParametersLength(command, 2);
            this.ValidateUser(false, data, Messages.AlreadyLoggedError);

            var restQueriesExecutor = new RestQueriesExecutor();
            var result = restQueriesExecutor.LoginAsync(command, data);

            return result.Result;
        }

        private string ExecuteLogOutCommand(ICommand command, BattleshipsData data)
        {
            this.ValidateParametersLength(command, 0);
            this.ValidateUser(true, data, Messages.NotLoggedError);

            data.LogOutUser();
            var result = Messages.LogedOutMessage;

            return result;
        }

        private string ExecuteCreateGameCommand(ICommand command, BattleshipsData data)
        {
            this.ValidateParametersLength(command, 0);
            this.ValidateUser(true, data, Messages.NotLoggedError);

            var restQueriesExecutor = new RestQueriesExecutor();
            var result = restQueriesExecutor.CreateGameAsync(data.LoggedUserAccessToken);

            return result.Result;
        }

        private string ExecuteJoinGameCommand(ICommand command, BattleshipsData data)
        {
            this.ValidateParametersLength(command, 1);
            this.ValidateUser(true, data, Messages.NotLoggedError);

            var restQueriesExecutor = new RestQueriesExecutor();
            var result = restQueriesExecutor.JoinGameAsync(command, data.LoggedUserAccessToken);

            return result.Result;
        }

        private string ExecutePlayCommand(ICommand command, BattleshipsData data)
        {
            this.ValidateParametersLength(command, 3);
            this.ValidateUser(true, data, Messages.NotLoggedError);

            var restQueriesExecutor = new RestQueriesExecutor();
            var result = restQueriesExecutor.PlayAsync(command, data.LoggedUserAccessToken);

            return result.Result;
        }

        private void ValidateParametersLength(ICommand command, int expectedCount)
        {
            if (command.Parameters.Count != expectedCount)
            {
                throw new InvalidOperationException(Messages.InvalidCommandError);
            }
        }

        private void ValidateUser(bool isLoggedCheck, BattleshipsData data, string errorMessage)
        {
            if (data.IsLogged != isLoggedCheck)
            {
                throw new InvalidOperationException(errorMessage);
            }
        }
    }
}