namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;
    using Interfaces;

    public class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var systemName = commandArgs[1];
            var intactShips = 
                this.GameEngine.Starships
                .Where(s => s.Health > 0 && s.Location.Name == systemName)
                .OrderByDescending(s => s.Health)
                .ThenByDescending(s => s.Shields);

            var destroyedShips = 
                this.GameEngine.Starships
                .Where(s => s.Health == 0 && s.Location.Name == systemName)
                .OrderBy(s => s.Name);

            Console.WriteLine("Intact ships:");
            Console.WriteLine(intactShips.Any() ? string.Join(Environment.NewLine, intactShips) : "N/A");
            Console.WriteLine("Destroyed ships:");
            Console.WriteLine(destroyedShips.Any() ? string.Join(Environment.NewLine, destroyedShips) : "N/A");
        }
    }
}