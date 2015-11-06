namespace SoftUni.Blog.Data.DAO
{
    using Models;

    public class UserModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Fullname { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        public Status Status { get; set; }

        public int Age { get; set; }

        public string ProfileImage { get; set; }
    }
}