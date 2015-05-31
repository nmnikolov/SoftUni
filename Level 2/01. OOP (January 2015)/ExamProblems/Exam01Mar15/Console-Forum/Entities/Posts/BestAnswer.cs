namespace ConsoleForum.Entities.Posts
{
    using System.Text;
    using Contracts;
    using Utility;

    public class BestAnswer : Answer    
    {
        private const char DelimiterSymbol = '*';

        public BestAnswer(int id, string body, IUser author) 
            : base(id, body, author)
        {
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(DelimiterUtility.GetDelimiter(DelimiterSymbol));
            output.AppendLine(base.ToString());
            output.AppendLine(DelimiterUtility.GetDelimiter(DelimiterSymbol));

            return output.ToString();
        }
    }
}