namespace GithubIssueTracker.Tests
{
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class SearchForIssuesTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [TestMethod]
        public void Test_SearchForIssues_SingleIssue_ShouldReturnIssue()
        {
            var tracker = new GithubIssueTracker(new GithubIssueTrackerData());
            tracker.RegisterUser("Ivan", "qwerty", "qwerty");
            tracker.LoginUser("Ivan", "qwerty");

            tracker.CreateIssue("New issue", "This is a new issue", IssuePriority.High, new[] { "issue" });
            string message = tracker.SearchForIssues(new[] { "issue" });

            Assert.AreEqual(
                "New issue\r\n" +
                "Priority: ***\r\n" +
                "This is a new issue\r\n" +
                "Tags: issue",
                message);
        }

        [TestMethod]
        public void Test_SearchForIssues_SomeIssues_SortByPriorityDescending_ShouldReturnIssues()
        {
            var tracker = new GithubIssueTracker();
            tracker.RegisterUser("Ivan", "qwerty", "qwerty");
            tracker.LoginUser("Ivan", "qwerty");

            tracker.CreateIssue("New issue", "This is a new issue", IssuePriority.Low, new[] { "issue" });
            tracker.CreateIssue("New issue error", "This is a new issue error", IssuePriority.High, new[] { "issue", "issue_error" });
            string message = tracker.SearchForIssues(new[] { "issue" });

            Assert.AreEqual(
                "New issue error\r\n" +
                "Priority: ***\r\n" +
                "This is a new issue error\r\n" +
                "Tags: issue,issue_error\r\n" + 
                "New issue\r\n" +
                "Priority: *\r\n" +
                "This is a new issue\r\n" +
                "Tags: issue",
                message);
        }

        [TestMethod]
        public void Test_SearchForIssues_SomeIssues_SortByTitle_ShouldReturnIssues()
        {
            var tracker = new GithubIssueTracker(new GithubIssueTrackerData());
            tracker.RegisterUser("Ivan", "qwerty", "qwerty");
            tracker.LoginUser("Ivan", "qwerty");

            tracker.CreateIssue("Some issue", "This is a new issue", IssuePriority.High, new[] { "issue" });
            tracker.CreateIssue("New issue error", "This is a new issue error", IssuePriority.High, new[] { "issue", "issue_error" });
            string message = tracker.SearchForIssues(new[] { "issue" });

            Assert.AreEqual(
                "New issue error\r\n" +
                "Priority: ***\r\n" +
                "This is a new issue error\r\n" +
                "Tags: issue,issue_error\r\n" +
                "Some issue\r\n" +
                "Priority: ***\r\n" +
                "This is a new issue\r\n" +
                "Tags: issue",
                message);
        }

        [TestMethod]
        public void Test_SearchForIssues_SomeIssues_ShouldReturnDistinctIssues()
        {
            var tracker = new GithubIssueTracker(new GithubIssueTrackerData());
            tracker.RegisterUser("Ivan", "qwerty", "qwerty");
            tracker.LoginUser("Ivan", "qwerty");

            tracker.CreateIssue("Some issue", "This is a new issue", IssuePriority.High, new[] { "issue" });
            tracker.CreateIssue("New issue error", "This is a new issue error", IssuePriority.High, new[] { "issue", "issue_error" });
            string message = tracker.SearchForIssues(new[] { "issue", "issue_error" });

            Assert.AreEqual(
                "New issue error\r\n" +
                "Priority: ***\r\n" +
                "This is a new issue error\r\n" +
                "Tags: issue,issue_error\r\n" +
                "Some issue\r\n" +
                "Priority: ***\r\n" +
                "This is a new issue\r\n" +
                "Tags: issue",
                message);
        }

        [TestMethod]
        public void Test_SearchForIssues_NoTagsProvided_ShouldReturnErrorMessage()
        {
            var tracker = new GithubIssueTracker(new GithubIssueTrackerData());
            tracker.RegisterUser("Ivan", "qwerty", "qwerty");
            tracker.LoginUser("Ivan", "qwerty");

            tracker.CreateIssue("Some issue", "This is a new issue", IssuePriority.High, new[] { "issue" });
            tracker.CreateIssue("New issue error", "This is a new issue error", IssuePriority.High, new[] { "issue", "issue_error" });
            string message = tracker.SearchForIssues(new string[] { });

            Assert.AreEqual("There are no tags provided", message);
        }

        [TestMethod]
        public void Test_SearchForIssues_NoMatchingTags_ShouldReturnNoIssues()
        {
            var tracker = new GithubIssueTracker(new GithubIssueTrackerData());
            tracker.RegisterUser("Ivan", "qwerty", "qwerty");
            tracker.LoginUser("Ivan", "qwerty");

            tracker.CreateIssue("Some issue", "This is a new issue", IssuePriority.High, new[] { "issue" });
            tracker.CreateIssue("New issue error", "This is a new issue error", IssuePriority.High, new[] { "issue", "issue_error" });
            string message = tracker.SearchForIssues(new[] { "comment_issue" });

            Assert.AreEqual("There are no issues matching the tags provided", message);
        }
    }
}