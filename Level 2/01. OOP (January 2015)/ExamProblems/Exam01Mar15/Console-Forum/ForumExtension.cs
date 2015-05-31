namespace ConsoleForum
{
    using System;
    using System.Linq;
    using System.Text;
    using Entities.Posts;

    public class ForumExtension : Forum
    {
        private const int ActiveUserCriteria = 3;
        private const int DelimiterLength = 20;
        private const char DelimiterSymbol = '~';
        private readonly string delimiter = new string(DelimiterSymbol, DelimiterLength);

        protected override void ExecuteCommandLoop()
        {
            Console.Write(this.Createheader());

            base.ExecuteCommandLoop();
        }

        private string Createheader()
        {
            StringBuilder header = new StringBuilder();
            int hotQuestions = this.Questions.Count(q => q.Answers.Any(a => a is BestAnswer));
            int activeUsers = this.Users.Count(user => this.Answers.Count(a => a.Author.Username == user.Username) >= ActiveUserCriteria);

            header.AppendLine(this.delimiter);
            header.AppendLine(this.IsLogged
                ? string.Format(Messages.UserWelcomeMessage, this.CurrentUser.Username)
                : Messages.GuestWelcomeMessage);
            header.AppendLine(string.Format(Messages.GeneralHeaderMessage, hotQuestions, activeUsers));
            header.AppendLine(this.delimiter);

            return header.ToString();
        }
    }
}