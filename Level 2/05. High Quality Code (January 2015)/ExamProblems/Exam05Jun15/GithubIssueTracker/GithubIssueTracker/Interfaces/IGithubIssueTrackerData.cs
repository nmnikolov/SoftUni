namespace GithubIssueTracker.Interfaces
{
    using System.Collections.Generic;
    using Models;
    using Wintellect.PowerCollections;

    public interface IGithubIssueTrackerData
    {
        int NextIssueId { get; set; }

        User LoggedUser { get; set; }

        IDictionary<string, User> Users { get; }

        OrderedDictionary<int, Issue> IssuesById { get; }

        MultiDictionary<string, Issue> IssuesByUsername { get; }

        MultiDictionary<string, Issue> IssuesByTag { get; }

        MultiDictionary<User, Comment> CommentsByUser { get; }

        void AddIssue(Issue issue);

        void RemoveIssue(Issue issue); 
    }
}