namespace ConsoleForum.Utility
{
    public static class DelimiterUtility
    {
        private const int DelimiterLength = 20;

        public static string GetDelimiter(char delimiterSymbol)
        {
            return new string(delimiterSymbol, DelimiterLength);
        }
    }
}