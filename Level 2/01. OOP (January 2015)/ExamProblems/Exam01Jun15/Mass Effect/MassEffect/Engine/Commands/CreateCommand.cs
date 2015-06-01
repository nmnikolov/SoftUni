namespace MassEffect.Engine.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Factories;
    using GameObjects.Enhancements;
    using GameObjects.Locations;
    using GameObjects.Ships;
    using MassEffect.Interfaces;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            if (this.GameEngine.Starships.Any(s => s.Name == commandArgs[2]))
            {
                Console.WriteLine(Messages.DuplicateShipName);
                return;
            }

            var shipType = (StarshipType)Enum.Parse(typeof(StarshipType), commandArgs[1], true);
            var location = this.GameEngine.Galaxy.GetStarSystemByName(commandArgs[3]);
            var starship = this.GameEngine.ShipFactory.CreateShip(shipType, commandArgs[2], location, new List<Enhancement>());

            if (commandArgs.Length > 4)
            {
                for (var i = 4; i < commandArgs.Length; i++)
                {
                    var enhancementType = (EnhancementType)Enum.Parse(typeof(EnhancementType), commandArgs[i], true);
                    var enhancement = this.GameEngine.EnhancementFactory.Create(enhancementType);
                    starship.AddEnhancement(enhancement);
                }
            }

            this.GameEngine.Starships.Add(starship);
            Console.WriteLine(Messages.CreatedShip, shipType, starship.Name);
        }
    }
}