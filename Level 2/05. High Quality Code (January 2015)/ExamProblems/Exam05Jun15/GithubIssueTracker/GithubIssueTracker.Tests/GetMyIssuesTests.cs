namespace GithubIssueTracker.Tests
{
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class GetMyIssuesTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [TestMethod]
        public void Test_GetMyIssues_SingleIssue_ShouldReturnIssues()
        {
            var tracker = new GithubIssueTracker(new GithubIssueTrackerData());
            tracker.RegisterUser("Ivan", "qwerty", "qwerty");
            tracker.LoginUser("Ivan", "qwerty");

            tracker.CreateIssue("New issue", "This is a new issue", IssuePriority.High, new[] { "issue" });
            string message = tracker.GetMyIssues();

            Assert.AreEqual(
                "New issue\r\n" +
                "Priority: ***\r\n" +
                "This is a new issue\r\n" +
                "Tags: issue",
                message);
        }

        [TestMethod]
        public void Test_GetMyIssues_SomeIssues_SortByPriorityDescending_ShouldReturnIssues()
        {
            var tracker = new GithubIssueTracker(new GithubIssueTrackerData());
            tracker.RegisterUser("Ivan", "qwerty", "qwerty");
            tracker.LoginUser("Ivan", "qwerty");

            tracker.CreateIssue("New issue2", "This is a new issue2", IssuePriority.Low, new[] { "issue2" });
            tracker.CreateIssue("New issue1", "This is a new issue1", IssuePriority.High, new[] { "issue1" });
            string message = tracker.GetMyIssues();

            Assert.AreEqual(
                "New issue1\r\n" +
                "Priority: ***\r\n" +
                "This is a new issue1\r\n" +
                "Tags: issue1\r\n" +
                "New issue2\r\n" +
                "Priority: *\r\n" +
                "This is a new issue2\r\n" +
                "Tags: issue2",
                message);
        }

        [TestMethod]
        public void Test_GetMyIssues_SomeIssues_SortByTitle_ShouldReturnIssues()
        {
            var tracker = new GithubIssueTracker(new GithubIssueTrackerData());
            tracker.RegisterUser("Ivan", "qwerty", "qwerty");
            tracker.LoginUser("Ivan", "qwerty");

            tracker.CreateIssue("New issue2", "This is a new issue2", IssuePriority.High, new[] { "issue2" });
            tracker.CreateIssue("New issue1", "This is a new issue1", IssuePriority.High, new[] { "issue1" });
            string message = tracker.GetMyIssues();

            Assert.AreEqual(
                "New issue1\r\n" +
                "Priority: ***\r\n" +
                "This is a new issue1\r\n" +
                "Tags: issue1\r\n" + 
                "New issue2\r\n" +
                "Priority: ***\r\n" +
                "This is a new issue2\r\n" +
                "Tags: issue2",
                message);
        }

        [TestMethod]
        public void Test_GetMyIssues_NotLogged_ShouldReturnErrorMessage()
        {
            var tracker = new GithubIssueTracker(new GithubIssueTrackerData());
            tracker.RegisterUser("Ivan", "qwerty", "qwerty");
            tracker.LoginUser("Ivan", "qwerty");

            tracker.CreateIssue("New issue2", "This is a new issue2", IssuePriority.High, new[] { "issue2" });
            tracker.CreateIssue("New issue1", "This is a new issue1", IssuePriority.High, new[] { "issue1" });
            tracker.LogoutUser();
            string message = tracker.GetMyIssues();

            Assert.AreEqual("There is no currently logged in user", message);
        }

        [TestMethod]
        public void Test_GetMyIssues_NoIssues_ShouldReturnNoIssuesMessage()
        {
            var tracker = new GithubIssueTracker(new GithubIssueTrackerData());
            tracker.RegisterUser("Ivan", "qwerty", "qwerty");
            tracker.LoginUser("Ivan", "qwerty");
            string message = tracker.GetMyIssues();

            Assert.AreEqual("No issues", message);
        }
    }
}