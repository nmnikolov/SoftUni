namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;
    using Interfaces;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var attacker = this.GameEngine.Starships.FirstOrDefault(s => s.Name == commandArgs[1]);
            var target = this.GameEngine.Starships.FirstOrDefault(s => s.Name == commandArgs[2]);

            if (attacker.Health == 0 || target.Health == 0)
            {
                Console.WriteLine(Messages.ShipAlreadyDestroyed);
                return;
            }

            if (attacker.Location.Name != target.Location.Name)
            {
                Console.WriteLine(Messages.NoSuchShipInStarSystem);
                return;
            }

            var projectile = attacker.ProduceAttack();
            target.RespondToAttack(projectile);
            Console.WriteLine(Messages.ShipAttacked, attacker.Name, target.Name);

            if (target.Health == 0)
            {
                Console.WriteLine(Messages.ShipDestroyed, target.Name);
            }
        }
    }
}