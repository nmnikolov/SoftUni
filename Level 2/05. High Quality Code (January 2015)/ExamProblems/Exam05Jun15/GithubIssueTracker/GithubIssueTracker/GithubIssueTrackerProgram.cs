namespace GithubIssueTracker
{
    using System.Globalization;
    using System.Threading;
    using Core;

    public class GithubIssueTrackerProgram
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var engine = new GithubIssueTrackerEngine();
            engine.Run();
        }
    }
}