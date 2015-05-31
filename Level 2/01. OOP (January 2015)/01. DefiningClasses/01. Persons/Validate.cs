namespace _01.Persons
{
    using System.Text.RegularExpressions;

    public static class Validate
    {
        private const string EmailPattern = @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$";

        public static bool IsEmail(string email)
        {
            Regex r = new Regex(EmailPattern);
            return r.Match(email).Success;
        }
    }
}
