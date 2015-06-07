namespace Customer
{
    using System;
    using System.Text.RegularExpressions;

    public static class Validation
    {
        private const string EmailPattern = @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$";

        private const string PhonePattern = @"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$";

        private const string Id = @"^\d{10}$";

        public static bool IsValidName(string name, string type)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(string.Format("{0} cannot be empty.", type));
            }

            return true;
        }

        public static bool IsValidPrice(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException("price", "Price cannot be negative.");
            }

            return true;
        }

        public static bool IsValidEmail(string email)
        {
            Regex regex = new Regex(EmailPattern);

            if (!regex.Match(email).Success)
            {
                throw new ArgumentException("Wrong email format.");
            }

            return true;
        }

        public static bool IsValidPhone(string phone)
        {
            Regex regex = new Regex(PhonePattern);

            if (!regex.Match(phone).Success)
            {
                throw new ArgumentException("Wrong phone format.");
            }

            return true;
        }

        public static bool IsValidId(string id)
        {
            Regex regex = new Regex(Id);

            if (!regex.Match(id).Success)
            {
                throw new ArgumentException("Id should containt exactly 10 digits.");
            }

            return true;
        }
    }
}