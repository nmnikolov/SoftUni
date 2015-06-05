namespace GithubIssueTracker.Tests
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class CreateIssueTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [TestMethod]
        public void Test_CreateIssue_CorrectParameters_ShouldCreateIssue()
        {
            var tracker = new GithubIssueTracker(new GithubIssueTrackerData());
            tracker.RegisterUser("Ivan", "qwerty", "qwerty");
            tracker.LoginUser("Ivan", "qwerty");

            string message = tracker.CreateIssue("Not working comments", "Comments functionnality does not work", IssuePriority.High, new[] { "comments" });

            Assert.AreEqual("Issue 1 created successfully", message);
        }

        [TestMethod]
        public void Test_CreateIssues_CorrectParameters_ShouldCreateIssues()
        {
            var tracker = new GithubIssueTracker(new GithubIssueTrackerData());
            tracker.RegisterUser("Ivan", "qwerty", "qwerty");
            tracker.LoginUser("Ivan", "qwerty");

            string firstMessage = tracker.CreateIssue("Not working comments", "Comments functionnality does not work", IssuePriority.High, new[] { "comment" });

            string secondMessage = tracker.CreateIssue("Not working issues", "Issues functionnality does not work", IssuePriority.High, new[] { "issue" });

            Assert.AreEqual("Issue 1 created successfully", firstMessage);
            Assert.AreEqual("Issue 2 created successfully", secondMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_CreateIssue_InvalidTitle_ShouldReturnException()
        {
            var tracker = new GithubIssueTracker(new GithubIssueTrackerData());
            tracker.RegisterUser("Ivan", "qwerty", "qwerty");
            tracker.LoginUser("Ivan", "qwerty");

            tracker.CreateIssue("aa", "Comments functionnality does not work", IssuePriority.High, new[] { "comment" });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_CreateIssue_InvalidDescription_ShouldReturnException()
        {
            var tracker = new GithubIssueTracker(new GithubIssueTrackerData());
            tracker.RegisterUser("Ivan", "qwerty", "qwerty");
            tracker.LoginUser("Ivan", "qwerty");

            tracker.CreateIssue("Not working comments", "aaaa", IssuePriority.High, new[] { "comment" });
        }

        [TestMethod]
        public void Test_CreateIssue_NotLoggedUser_ShouldReturnErrorMessage()
        {
            var tracker = new GithubIssueTracker(new GithubIssueTrackerData());
            string message = tracker.CreateIssue("Not working comments", "Comments functionnality does not work", IssuePriority.High, new[] { "comments" });

            Assert.AreEqual("There is no currently logged in user", message);
        }
    }
}