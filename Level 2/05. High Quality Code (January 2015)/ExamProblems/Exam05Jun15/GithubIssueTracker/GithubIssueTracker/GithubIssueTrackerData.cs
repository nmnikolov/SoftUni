namespace GithubIssueTracker
{
    using System.Collections.Generic;
    using Interfaces;
    using Models;
    using Wintellect.PowerCollections;

    public class GithubIssueTrackerData : IGithubIssueTrackerData
    {
        public GithubIssueTrackerData()
        {
            this.NextIssueId = 1;
            this.Users = new Dictionary<string, User>();
            this.IssuesById = new OrderedDictionary<int, Issue>();
            this.IssuesByUsername = new MultiDictionary<string, Issue>(true);
            this.IssuesByTag = new MultiDictionary<string, Issue>(true);
            this.CommentsByUser = new MultiDictionary<User, Comment>(true);
        }

        public int NextIssueId { get; set; }

        public User LoggedUser { get; set; }
        
        public IDictionary<string, User> Users { get; set; }
        
        public OrderedDictionary<int, Issue> IssuesById { get; set; }

        public MultiDictionary<string, Issue> IssuesByUsername { get; set; }

        public MultiDictionary<string, Issue> IssuesByTag { get; set; }

        public MultiDictionary<User, Comment> CommentsByUser { get; set; }

        public void AddIssue(Issue issue)
        {
            this.IssuesById.Add(issue.Id, issue);
            this.NextIssueId++;
            this.IssuesByUsername[this.LoggedUser.Username].Add(issue);

            foreach (var tag in issue.Tags)
            {
                this.IssuesByTag[tag].Add(issue);
            }
        }

        public void RemoveIssue(Issue issue)
        {
            this.IssuesByUsername[this.LoggedUser.Username].Remove(issue);

            foreach (var tag in issue.Tags)
            {
                this.IssuesByTag[tag].Remove(issue);
            }

            this.IssuesById.Remove(issue.Id);
        }
    }
}