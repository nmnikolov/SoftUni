namespace ConsoleForum.Commands
{
    using System;
    using Contracts;
    using Entities.Posts;

    public class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum) 
            : base(forum)
        {
        }

        public override void Execute()
        {
            this.IsLoggedValidation();

            string title = this.Data[1];
            string body = this.Data[2];
            IQuestion question = new Question(this.Forum.Questions.Count + 1, body, this.Forum.CurrentUser, title);
            this.Forum.Questions.Add(question);
            this.Forum.Output.AppendLine(string.Format(Messages.PostQuestionSuccess, question.Id));
        }
    }
}