namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;
    using Interfaces;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var newLocationStr = commandArgs[2];
            var starShip = this.GameEngine.Starships.First(s => s.Name == commandArgs[1]);

            if (starShip.Health == 0)
            {
                Console.WriteLine(Messages.ShipAlreadyDestroyed);
                return;
            }

            if (starShip.Location.Name == newLocationStr)
            {
                Console.WriteLine(Messages.ShipAlreadyInStarSystem, newLocationStr);
                return;
            }

            var oldLocationStr = starShip.Location.Name;
            var newLocation = this.GameEngine.Galaxy.GetStarSystemByName(newLocationStr);
            this.GameEngine.Galaxy.TravelTo(starShip, newLocation);
            Console.WriteLine(Messages.ShipTraveled, starShip.Name, oldLocationStr, newLocationStr);
        }
    }
}