namespace MassEffect.Engine.Commands
{
    using Interfaces;

    public class OverCommand : Command
    {
        public OverCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            if (commandArgs[0].ToLower() == "over")
            {
                this.GameEngine.IsRunning = false;
            }
        }
    }
}
