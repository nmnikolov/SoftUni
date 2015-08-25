namespace Battleships.ConsoleClient.Utilities
{
    public class Messages
    {
        private const string A = "=> ";

        public const string RegisteredMessage = A + "User with email {0} successfully registered.";
        public const string LogedInMessage = A + "User {0} successfully logged in.";
        public const string LogedOutMessage = A + "Successfully logged out.";
        public const string CreatedGameMessage = A + "Successfully created game with id {0}.";
        public const string JoinedGameMessage = A + "Successfully joined the game.";
        public const string PositionBombedMessage = A + "Position {0} {1} successfully bombed.";



        public const string RegistrationFailedError = A + "Registration failed.";
        public const string CreateGameFailedError = A + "Create game failed.";
        public const string InvalidCommandError = A + "Invalid command.";
        public const string NotLoggedError = A + "There is no user logged.";
        public const string AlreadyLoggedError = A + "There is already logged user.";
        public const string NonExistingGameError = A + "There is no game with id {0}.";
        public const string RegistrationWhileLoggedError = A + "Can't register while logged in.";

    }
}