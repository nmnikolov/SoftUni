namespace GithubIssueTracker
{
    public static class Messages
    {
        public const string UserRegistered = "User {0} registered successfully";
        public const string UserLoggedIn = "User {0} logged in successfully";
        public const string UserLoggedOut = "User {0} logged out successfully";
        public const string IssueCreated = "Issue {0} created successfully";
        public const string IssueRemoved = "Issue {0} removed";
        public const string CommendAdded = "Comment added successfully to issue {0}";

        public const string AlreadyLogged = "There is already a logged in user";
        public const string NotLogged = "There is no currently logged in user";
        public const string NoNMatchingPasswords = "The provided passwords do not match";
        public const string DuplicateUsername = "A user with username {0} already exists";
        public const string NonExistingUser = "A user with username {0} does not exist";
        public const string NonExistingIssue = "There is no issue with ID {0}";
        public const string NoIssues = "No issues";
        public const string NoComments = "No comments";
        public const string NoTagsProvided = "There are no tags provided";
        public const string NoMatchingIssues = "There are no issues matching the tags provided";
        public const string InvalidPassword = "The password is invalid for user {0}";
        public const string NoPermissions = "The issue with ID {0} does not belong to user {1}";
    }
}