namespace GithubIssueTracker.Interfaces
{
    using Models;

    /// <summary>
    /// Provides the basic operations required to run a GithubIssueTracker.
    /// </summary>
    public interface IIssueTracker
    {
        /// <summary>
        /// Register a new user in the GithubIssueTracker
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="password">The password of the user</param>
        /// <param name="confirmPassword">Password confirmation</param>
        /// <returns>
        /// Returns a success message if the user has been registered successfully. Returns an error message when there is already logged user, passwords do not match or the username is already taken.
        /// </returns>
        string RegisterUser(string username, string password, string confirmPassword);

        /// <summary>
        /// Login user in the GithubIssueTracker
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="password">The password of the user</param>
        /// <returns>
        /// Returns a success message if the user has been logged in successfully. Returns an error message when the is already logged user, the username does not exist or the password is invalid.
        /// </returns>
        string LoginUser(string username, string password);
        
        /// <summary>
        /// Log out current user from the GithubIssueTracker
        /// </summary>
        /// <returns>
        /// Returns a success message if the user has been logged out successfully. Returns an error message when there is no logged user.
        /// </returns>
        string LogoutUser(); 

        /// <summary>
        /// Create and add issue in the GithubIssueTracker
        /// </summary>
        /// <param name="title">The title of the issue</param>
        /// <param name="description">The description of the issue</param>
        /// <param name="priority">The priority of the issue. Used as a sort criteria when displaying issues.</param>
        /// <param name="tags">The tags of the issue. Used in the searching functionality.</param>
        /// <returns>
        /// Returns a success message if the issue has been created successfilly. Returns an error message when there is no logged user.
        /// </returns>
        string CreateIssue(string title, string description, IssuePriority priority, string[] tags);

        /// <summary>
        /// Remove issue from the GithubIssueTracker
        /// </summary>
        /// <param name="issueId">The id of the issue to be removed. Used for searching the issue in the dictionaries</param>
        /// <returns>
        /// Returns a success message if the issue has been removed successfilly. Returns an error message when the is no logged user, there is no issue with the provided issueId or when the user has no permissions to remove the issue.
        /// </returns>
        string RemoveIssue(int issueId);

        /// <summary>
        /// Add comment for a specific issue in the GithubIssueTracker
        /// </summary>
        /// <param name="issueId">The id of the issue. Used for searching specific issue to add the comment</param>
        /// <param name="commentText"></param>
        /// <returns>
        /// Returns a success message if the comment has been added successfilly. Returns an error message when there is no logged user or when there is no issue with the provided issueId.
        /// </returns>
        string AddComment(int issueId, string commentText);

        /// <summary>
        /// Returns all issues in the GithubIssueTracker created by the logged user
        /// </summary>
        /// <returns>
        /// Returns all issues created by the logged user or "No issues" when the user has no issues created. Returns an error message when there is no logged user
        /// </returns>
        string GetMyIssues();

        /// <summary>
        /// Returns all comments in the GithubIssueTracker created by the logged user
        /// </summary>
        /// <returns>
        ///  Returns all comments created by the logged user or "No comments" when the user has no comments created. Returns an error message when there is no logged user
        /// </returns>
        string GetMyComments();

        /// <summary>
        /// Returns all issues in the GithubIssueTracker containing any of provided tags
        /// </summary>
        /// <param name="tags">The tags used for searching in the issues' database.</param>
        /// <returns>
        /// Returns found issued by the searching criteria or "There are no issues matching the tags provided" message when there is no matching issues. Returns an error message when the is no tags provided for searching.</returns>
        string SearchForIssues(string[] tags);
    }
}
