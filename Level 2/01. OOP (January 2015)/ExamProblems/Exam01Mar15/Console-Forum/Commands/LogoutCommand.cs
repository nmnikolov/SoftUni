namespace ConsoleForum.Commands
{
    using System.Linq;
    using Contracts;
    using Utility;

    public class LogoutCommand : AbstractCommand
    {
        public LogoutCommand(IForum forum) 
            : base(forum)
        {
        }

        public override void Execute()
        {
            this.IsLoggedValidation();

            this.Forum.CurrentUser = null;
            this.Forum.CurrentQuestion = null;

            this.Forum.Output.AppendLine(string.Format(Messages.LogoutSuccess));
        }
    }
}