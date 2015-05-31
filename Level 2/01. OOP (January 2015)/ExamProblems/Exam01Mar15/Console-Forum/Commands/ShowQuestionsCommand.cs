namespace ConsoleForum.Commands
{
    using System.Linq;
    using Contracts;

    public class ShowQuestionsCommand : AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            var questions = this.Forum.Questions.OrderBy(q => q.Id);

            if (!questions.Any())
            {
                this.Forum.Output.AppendLine(Messages.NoQuestions);
            }
            else
            {
                foreach (var question in questions)
                {
                    this.Forum.Output.Append(question);
                }
            }
        }
    }
}