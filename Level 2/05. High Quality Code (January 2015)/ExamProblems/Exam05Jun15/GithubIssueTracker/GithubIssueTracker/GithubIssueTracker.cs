namespace GithubIssueTracker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;

    public class GithubIssueTracker : IIssueTracker
    {
        public GithubIssueTracker(IGithubIssueTrackerData data)
        {
            this.Data = data;
        }

        public GithubIssueTracker()
            : this(new GithubIssueTrackerData())
        {
        }

        private IGithubIssueTrackerData Data { get; set; }

        public string RegisterUser(string username, string password, string confirmPassword)
        {
            if (this.IsUserLogged())
            {
                return Messages.AlreadyLogged;
            }

            if (password != confirmPassword)
            {
                return Messages.NoNMatchingPasswords;
            }

            if (this.Data.Users.Any(u => u.Key == username))
            {
                return string.Format(Messages.DuplicateUsername, username);
            }

            var user = new User(username, password);
            this.Data.Users.Add(username, user);

            return string.Format(Messages.UserRegistered, username);
        }

        public string LoginUser(string username, string password)
        {
            if (this.IsUserLogged())
            {
                return Messages.AlreadyLogged;
            }

            if (this.Data.Users.All(u => u.Key != username))
            {
                return string.Format(Messages.NonExistingUser, username);
            }

            var user = this.Data.Users[username];

            if (user.Password != User.HashPassword(password))
            {
                return string.Format(Messages.InvalidPassword, username);
            }

            this.Data.LoggedUser = user;

            return string.Format(Messages.UserLoggedIn, username);
        }

        public string LogoutUser()
        {
            if (!this.IsUserLogged())
            {
                return Messages.NotLogged;
            }

            var username = this.Data.LoggedUser.Username;
            this.Data.LoggedUser = null;
            return string.Format(Messages.UserLoggedOut, username);
        }

        public string CreateIssue(string title, string description, IssuePriority priority, string[] strings)
        {
            if (this.Data.LoggedUser == null)
            {
                return Messages.NotLogged;
            }

            var issue = new Issue(this.Data.NextIssueId, title, description, priority, strings.Distinct().ToList());
            this.Data.AddIssue(issue);

            return string.Format(Messages.IssueCreated, issue.Id);
        }

        public string RemoveIssue(int issueId)
        {
            if (!this.IsUserLogged())
            {
                return Messages.NotLogged;
            }

            if (!this.Data.IssuesById.ContainsKey(issueId))
            {
                return string.Format(Messages.NonExistingIssue, issueId);
            }

            var issue = this.Data.IssuesById[issueId];

            if (!this.Data.IssuesByUsername[this.Data.LoggedUser.Username].Contains(issue))
            {
                return string.Format(Messages.NoPermissions, issueId, this.Data.LoggedUser.Username);
            }

            this.Data.RemoveIssue(issue);

            return string.Format(Messages.IssueRemoved, issueId);
        }

        public string AddComment(int issueId, string commentText)
        {
            if (!this.IsUserLogged())
            {
                return Messages.NotLogged;
            }

            if (!this.Data.IssuesById.ContainsKey(issueId))
            {
                return string.Format(Messages.NonExistingIssue, issueId);
            }

            var issue = this.Data.IssuesById[issueId];
            var comment = new Comment(this.Data.LoggedUser, commentText);
            issue.AddComment(comment);
            this.Data.CommentsByUser[this.Data.LoggedUser].Add(comment);

            return string.Format(Messages.CommendAdded, issue.Id);
        }

        public string GetMyIssues()
        {
            if (!this.IsUserLogged())
            {
                return Messages.NotLogged;
            }

            var issues = this.Data.IssuesByUsername[this.Data.LoggedUser.Username];

            if (!issues.Any())
            {
                // PERFORMANCE: Remove unnecessary code
                return Messages.NoIssues;
            }

            return string.Join(Environment.NewLine, issues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        }

        public string GetMyComments()
        {
            if (!this.IsUserLogged())
            {
                return Messages.NotLogged;
            }

            var comments = this.Data.CommentsByUser[this.Data.LoggedUser];

            if (!comments.Any())
            {
                return Messages.NoComments;
            }

            return string.Join(Environment.NewLine, comments);
        }

        public string SearchForIssues(string[] strings)
        {
            if (strings.Length == 0)
            {
                return Messages.NoTagsProvided;
            }

            var issues = new List<Issue>();

            foreach (var t in strings)
            {
                issues.AddRange(this.Data.IssuesByTag[t]);
            }

            issues = issues.Distinct().ToList();

            if (!issues.Any())
            {
                return Messages.NoMatchingIssues;
            }

            string searchResult = string.Join(Environment.NewLine, issues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));

            return searchResult;
        }
        
        private bool IsUserLogged()
        {
            return this.Data.LoggedUser != null;
        }
    }
}