using System;
using System.Text.RegularExpressions;

namespace _01.Persons
{
    public static class Validate
    {
        public static bool IsEmail(String email)
        {
            string emailPattern = @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$";
            Regex r = new Regex(emailPattern);

            return r.Match(email).Success;
        }
    }
}
