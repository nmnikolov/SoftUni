namespace MassEffect.GameObjects.Ships
{
    using System.Collections.Generic;
    using Enhancements;
    using Interfaces;
    using Locations;
    using Projectiles;

    public class Dreadnought : Starship
    {
        private const int ShieldBonus = 50;
        private const int DefaultHealth = 200;
        private const int DefaultShields = 300;
        private const int DefaultDamage = 150;
        private const int DefaultFuel = 700;

        public Dreadnought(string name, StarSystem location, IEnumerable<Enhancement> enhancements) 
            : base(name, DefaultHealth, DefaultShields, DefaultDamage, DefaultFuel, location, enhancements)
        {
        }

        public override IProjectile ProduceAttack()
        {
            var projectile = new Laser((this.Shields > 0 ? this.Shields / 2 : 0) + this.Damage);
            this.IncreaseProjectilesFired();

            return projectile;
        }

        public override void RespondToAttack(IProjectile projectile)
        {
            this.Shields += ShieldBonus;
            base.RespondToAttack(projectile);
            this.Shields = this.Shields - ShieldBonus > 0 ? this.Shields - ShieldBonus : 0;
        }
    }
}