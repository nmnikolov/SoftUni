namespace ConsoleForum.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using Utility;

    public class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum) 
            : base(forum)
        {
        }

        public override void Execute()
        {
            var users = this.Forum.Users;
            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);

            if (this.Forum.IsLogged)
            {
                throw new CommandException(Messages.AlreadyLoggedIn);
            }

            if (!users.Any(u => u.Username == username && u.Password == password))
            {
                throw new CommandException(Messages.InvalidLoginDetails);   
            }

            this.Forum.CurrentUser = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            this.Forum.Output.AppendLine(
                string.Format(Messages.LoginSuccess, username));
        }
    }
}