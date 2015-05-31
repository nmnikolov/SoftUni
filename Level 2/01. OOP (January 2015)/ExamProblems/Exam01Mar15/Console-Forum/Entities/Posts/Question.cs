namespace ConsoleForum.Entities.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Utility;

    public class Question : Post, IQuestion
    {
        private const char DelimiterSymbol = '=';

        public Question(int id, string body, IUser author, string title) 
            : base(id, body, author)
        {
            this.Title = title;
            this.Answers = new List<IAnswer>();
        }

        public string Title { get; set; }

        public IList<IAnswer> Answers { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("[ Question ID: {0} ]{1}", this.Id, Environment.NewLine);
            output.AppendFormat("Posted by: {0}{1}", this.Author.Username, Environment.NewLine);
            output.AppendFormat("Question Title: {0}{1}", this.Title, Environment.NewLine);
            output.AppendFormat("Question Body: {0}{1}", this.Body, Environment.NewLine);
            output.AppendLine(DelimiterUtility.GetDelimiter(DelimiterSymbol));
            if (this.Answers.Any())
            {
                output.AppendLine("Answers:");
                foreach (var bestAnswer in this.Answers.Where(answer => answer is BestAnswer))
                {
                    output.Append(bestAnswer);
                }

                foreach (var answer in this.Answers.Where(answer => !(answer is BestAnswer)))
                {
                    output.Append(answer + Environment.NewLine);
                }
            }
            else
            {
                output.AppendLine("No answers");
            }

            return output.ToString();
        }
    }
}