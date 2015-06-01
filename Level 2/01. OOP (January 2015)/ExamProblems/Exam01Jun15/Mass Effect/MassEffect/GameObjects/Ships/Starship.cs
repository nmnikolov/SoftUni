namespace MassEffect.GameObjects.Ships
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using Enhancements;
    using Interfaces;
    using Locations;

    public abstract class Starship : IStarship
    {
        private const int InitialProjectilesFired = 0;

        protected Starship(string name, int health, int shields, int damage, double fuel, StarSystem location, IEnumerable<Enhancement> enhancements)
        {
            this.Enhancements = enhancements;
            this.Name = name;
            this.Shields = shields;
            this.Health = health;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
            this.ProjectilesFired = InitialProjectilesFired;
        }

        public IEnumerable<Enhancement> Enhancements { get; private set; }
        
        public string Name { get; set; }

        public int Health { get; set; }

        public int Shields { get; set; }

        public double Fuel { get; set; }

        public int Damage { get; set; }

        public int ProjectilesFired { get; set; }

        public StarSystem Location { get; set; }

        public abstract IProjectile ProduceAttack();

        public void AddEnhancement(Enhancement enhancement)
        {
            var newEnhancementsList = this.Enhancements.ToList();
            newEnhancementsList.Add(enhancement);

            this.Enhancements = newEnhancementsList;
            this.Damage += enhancement.DamageBonus;
            this.Shields += enhancement.ShieldBonus;
            this.Fuel += enhancement.FuelBonus;
        }

        public virtual void RespondToAttack(IProjectile projectile)
        {
            switch (projectile.GetType().Name)
            {
                case "PenetrationShell":
                    this.Health = this.Health - projectile.Damage > 0 ? this.Health - projectile.Damage : 0;
                    break;
                case "ShieldReaver":
                    this.Health = this.Health - projectile.Damage > 0 ? this.Health - projectile.Damage : 0;
                    this.Shields = this.Shields - (projectile.Damage * 2) > 0 ? this.Shields - (projectile.Damage * 2) : 0;
                    break;
                case "Laser":
                    var projectileDamage = projectile.Damage;

                    if (projectileDamage > this.Shields)
                    {
                        projectileDamage -= this.Shields;
                        this.Shields = 0;
                        this.Health = this.Health - projectileDamage > 0 ? this.Health - projectileDamage : 0;
                    }
                    else
                    {
                        this.Shields -= projectileDamage;
                    }

                    break;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("--{0} - {1}", this.Name, this.GetType().Name));

            if (this.Health > 0)
            {
                output.AppendLine(string.Format("-Location: {0}", this.Location.Name));
                output.AppendLine(string.Format("-Health: {0}", this.Health));
                output.AppendLine(string.Format("-Shields: {0}", this.Shields));
                output.AppendLine(string.Format("-Damage: {0}", this.Damage));
                output.AppendLine(string.Format("-Fuel: {0:F1}", this.Fuel));
                output.Append(
                    string.Format(
                    "-Enhancements: {0}",
                    this.Enhancements.Any() ? string.Join(", ", this.Enhancements.Select(s => s.Name).ToList()) : "N/A"));
            }
            else
            {
                output.Append("(Destroyed)");
            }

            return output.ToString();
        }

        protected void IncreaseProjectilesFired()
        {
            this.ProjectilesFired++;
        }
    }
}