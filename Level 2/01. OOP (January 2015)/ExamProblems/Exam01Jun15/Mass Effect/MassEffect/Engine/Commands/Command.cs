namespace MassEffect.Engine.Commands
{
    using System.Text;
    using Interfaces;

    public abstract class Command
    {
        protected Command(IGameEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }

        public IGameEngine GameEngine { get; set; }
        
        public abstract void Execute(string[] commandArgs);
    }
}