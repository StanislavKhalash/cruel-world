using System;

namespace CruelWorld
{
    public abstract class Creature
    {
        protected Creature(uint maxHealth, uint basicDamage)
        {
            if (maxHealth == 0)
            {
                throw new ArgumentException(nameof(maxHealth));
            }

            CurrentHealth = MaxHealth = maxHealth;
            BasicDamage = basicDamage;
        }

        protected uint BasicDamage { get; }

        public uint MaxHealth { get; }

        public uint CurrentHealth { get; private set; }

        public bool IsAlive => CurrentHealth > 0;

        public virtual uint Damage => BasicDamage;

        public bool IsLarge { get; set; }

        public Party Allies { get; set; }

        public void Attack(Creature other)
        {
            if (Damage > other.CurrentHealth)
            {
                other.CurrentHealth = 0;
            }
            else
            {
                other.CurrentHealth -= Damage;
            }
        }
    }
}