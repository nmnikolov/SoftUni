namespace GithubIssueTracker.Tests
{
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RegisterUserTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [TestMethod]
        public void Test_RegisterUser_CorrectParameters_ShouldRegisterUser()
        {
            var tracker = new GithubIssueTracker(new GithubIssueTrackerData());
            string message = tracker.RegisterUser("Ivan", "qwerty", "qwerty");

            Assert.AreEqual("User Ivan registered successfully", message);
        }

        [TestMethod]
        public void Test_RegisterUsers_CorrectParameters_ShouldRegisterUsers()
        {
            var tracker = new GithubIssueTracker(new GithubIssueTrackerData());
            string firstMessage = tracker.RegisterUser("Ivan", "qwerty", "qwerty");
            string secondMessage = tracker.RegisterUser("Stefan", "asd", "asd");

            Assert.AreEqual("User Ivan registered successfully", firstMessage);
            Assert.AreEqual("User Stefan registered successfully", secondMessage);
        }

        [TestMethod]
        public void Test_RegisterUser_NoMatcingPasswords_ShouldReturnErrorMessage()
        {
            var tracker = new GithubIssueTracker(new GithubIssueTrackerData());
            string message = tracker.RegisterUser("Ivan", "qwerty", "qwerty12");

            Assert.AreEqual("The provided passwords do not match", message);
        }

        [TestMethod]
        public void Test_RegisterUser_DuplicateUsername_ShouldReturnErrorMessage()
        {
            var tracker = new GithubIssueTracker(new GithubIssueTrackerData());
            tracker.RegisterUser("Ivan", "qwerty", "qwerty");
            string message = tracker.RegisterUser("Ivan", "asd", "asd");

            Assert.AreEqual("A user with username Ivan already exists", message);
        }

        [TestMethod]
        public void Test_RegisterUser_AlreadyLoggedUser_ShouldReturnErrorMessage()
        {
            var tracker = new GithubIssueTracker(new GithubIssueTrackerData());
            tracker.RegisterUser("Ivan", "qwerty", "qwerty");
            tracker.LoginUser("Ivan", "qwerty");
            string message = tracker.RegisterUser("Stefan", "asd", "asd");

            Assert.AreEqual("There is already a logged in user", message);
        }
    }
}