namespace GithubIssueTracker.Execution
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Interfaces;

    public class Command : ICommand
    {
        public Command(string commandLine)
        {
            this.ParseCommand(commandLine);
        }

        public string Name { get; set; }

        public IDictionary<string, string> Parameters { get; set; }

        private void ParseCommand(string commandLine)
        {
            int commandNameEnd = commandLine.IndexOf('?') != -1 ? commandLine.IndexOf('?') : commandLine.Length;
            string commandName = commandLine.Substring(0, commandNameEnd);
            string commandParametersAsString = commandName != commandLine ? commandLine.Substring(commandNameEnd + 1) : string.Empty;
            var commandParameters = commandParametersAsString != string.Empty
                    ? this.ParseCommandParameters(commandParametersAsString)
                    : null;

            this.Name = commandName;
            this.Parameters = commandParameters;
        }

        private IDictionary<string, string> ParseCommandParameters(string commandParametersAsString)
        {
            var pairs = commandParametersAsString
                    .Split('&')
                    .Select(x => x.Split('=')
                    .Select(WebUtility.UrlDecode).ToList());

            var parameters = pairs.ToDictionary(pair => pair[0], pair => pair[1]);

            return parameters;
        }
    }
}