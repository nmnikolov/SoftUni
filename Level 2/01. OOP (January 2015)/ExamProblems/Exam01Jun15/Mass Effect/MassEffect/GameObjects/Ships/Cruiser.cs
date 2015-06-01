namespace MassEffect.GameObjects.Ships
{
    using System.Collections.Generic;
    using Enhancements;
    using Interfaces;
    using Locations;
    using Projectiles;

    public class Cruiser : Starship
    {
        private const int DefaultHealth = 100;
        private const int DefaultShields = 100;
        private const int DefaultDamage = 50;
        private const int DefaultFuel = 300;

        public Cruiser(string name, StarSystem location, IEnumerable<Enhancement> enhancements) 
            : base(name, DefaultHealth, DefaultShields, DefaultDamage, DefaultFuel, location, enhancements)
        {
        }

        public override IProjectile ProduceAttack()
        {
            var projectile = new PenetrationShell(this.Damage);
            this.IncreaseProjectilesFired();

            return projectile;
        }
    }
}