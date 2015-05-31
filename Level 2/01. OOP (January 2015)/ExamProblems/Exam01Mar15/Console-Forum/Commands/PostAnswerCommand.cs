namespace ConsoleForum.Commands
{
    using System;
    using Contracts;
    using Entities.Posts;

    public class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum) 
            : base(forum)
        {
        }

        public override void Execute()
        {
            this.IsLoggedValidation();

            string body = this.Data[1];
            IAnswer answer = new Answer(this.Forum.Answers.Count + 1, body, this.Forum.CurrentUser);
            this.Forum.Answers.Add(answer);
            this.Forum.CurrentQuestion.Answers.Add(answer);
            this.Forum.Output.AppendFormat(string.Format(Messages.PostAnswerSuccess, answer.Id) + Environment.NewLine);
        }
    }
}