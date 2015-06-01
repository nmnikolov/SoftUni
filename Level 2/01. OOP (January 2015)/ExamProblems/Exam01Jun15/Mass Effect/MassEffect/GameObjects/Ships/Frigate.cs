namespace MassEffect.GameObjects.Ships
{
    using System.Collections.Generic;
    using System.Text;
    using Enhancements;
    using Interfaces;
    using Locations;
    using Projectiles;

    public class Frigate : Starship
    {
        private const int DefaultHealth = 60;
        private const int DefaultShields = 50;
        private const int DefaultDamage = 30;
        private const int DefaultFuel = 220;

        public Frigate(string name, StarSystem location, IEnumerable<Enhancement> enhancements) 
            : base(name, DefaultHealth, DefaultShields, DefaultDamage, DefaultFuel, location, enhancements)
        {
        }

        public override IProjectile ProduceAttack()
        {
            var projectile = new ShieldReaver(this.Damage);
            this.IncreaseProjectilesFired();

            return projectile;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            if (this.Health > 0)
            {
                output.AppendLine().Append(string.Format("-Projectiles fired: {0}", this.ProjectilesFired));
            }

            return output.ToString();
        }
    }
}