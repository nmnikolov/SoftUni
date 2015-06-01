namespace MassEffect.GameObjects.Projectiles
{
    using Interfaces;

    public abstract class Projectile : IProjectile
    {
        protected Projectile(int damage)
        {
            this.Damage = damage;
        }

        public int Damage { get; set; }

        public void Hit(IStarship ship)
        {
            ship.RespondToAttack(this);
        }
    }
}