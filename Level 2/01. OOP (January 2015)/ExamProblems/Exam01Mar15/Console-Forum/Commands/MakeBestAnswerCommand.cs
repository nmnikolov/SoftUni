namespace ConsoleForum.Commands
{
    using System.CodeDom;
    using System.Linq;
    using System.Runtime.InteropServices;
    using Contracts;
    using Entities.Posts;
    using Entities.Users;

    public class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            this.IsLoggedValidation();

            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            var currentQuestion = this.Forum.CurrentQuestion;
            int id = int.Parse(this.Data[1]);
            var answer = currentQuestion.Answers.FirstOrDefault(a => a.Id == id);

            if (answer == null)
            {
                throw new CommandException(Messages.NoAnswer);
            }

            if (currentQuestion.Author.Username != this.Forum.CurrentUser.Username && !(this.Forum.CurrentUser is IAdministrator))
            {
                throw new CommandException(Messages.NoPermission);
            }

            var bestAnswer = new BestAnswer(answer.Id, answer.Body, answer.Author);

            var oldBestAnswer = this.Forum.Questions
                .First(q => q.Id == this.Forum.CurrentQuestion.Id)
                .Answers.FirstOrDefault(a => a is BestAnswer);

            if (oldBestAnswer != null)
            {
                var newAnswer = new Answer(oldBestAnswer.Id, oldBestAnswer.Body, oldBestAnswer.Author);
                this.Forum.Questions.First(q => q.Id == currentQuestion.Id).Answers.Remove(oldBestAnswer);
                this.Forum.Questions.First(q => q.Id == currentQuestion.Id).Answers.Add(newAnswer);
            }

            this.Forum.Questions.First(q => q.Id == currentQuestion.Id).Answers.Remove(answer);
            this.Forum.Questions.First(q => q.Id == currentQuestion.Id).Answers.Add(bestAnswer);
            this.Forum.Output.AppendLine(string.Format(Messages.BestAnswerSuccess, bestAnswer.Id));
        }
    }
}