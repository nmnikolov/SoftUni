namespace ConsoleForum.Commands
{
    using System.Linq;
    using Contracts;

    public class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum) 
            : base(forum)
        {
        }

        public override void Execute()
        {
            var questions = this.Forum.Questions;
            var id = int.Parse(this.Data[1]);
            var question = questions.FirstOrDefault(q => q.Id == id);

            if (question == null)
            {
                throw new CommandException(Messages.NoQuestion);
            }

            this.Forum.CurrentQuestion = question;
            this.Forum.Output.Append(question.ToString());
        }
    }
}