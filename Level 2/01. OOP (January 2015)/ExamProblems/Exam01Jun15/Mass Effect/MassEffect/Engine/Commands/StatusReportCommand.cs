namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;
    using Interfaces;

    public class StatusReportCommand : Command
    {
        public StatusReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var starShip = this.GameEngine.Starships.First(s => s.Name == commandArgs[1]);

            Console.WriteLine(starShip);
        }
    }
}
