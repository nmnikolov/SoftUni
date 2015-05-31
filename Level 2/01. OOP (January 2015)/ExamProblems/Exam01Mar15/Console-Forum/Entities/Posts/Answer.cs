namespace ConsoleForum.Entities.Posts
{
    using System;
    using System.Text;
    using Contracts;
    using Utility;

    public class Answer : Post, IAnswer
    {
        private const char DelimiterSymbol = '-';

        public Answer(int id, string body, IUser author) 
            : base(id, body, author)
        {
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat("[ Answer ID: {0} ]{1}", this.Id, Environment.NewLine);
            output.AppendFormat("Posted by: {0}{1}", this.Author.Username, Environment.NewLine);
            output.AppendFormat("Answer Body: {0}{1}", this.Body, Environment.NewLine);
            output.Append(DelimiterUtility.GetDelimiter(DelimiterSymbol));

            return output.ToString();
        }
    }
}