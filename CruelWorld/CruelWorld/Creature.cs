using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruelWorld
{
    public abstract class Creature
    {
        protected uint BasicDamage { get; private set; }

        public string Name { get; }

        public uint MaxHealth { get; }

        public uint CurrentHealth { get; private set; }

        public bool IsAlive => CurrentHealth > 0;

        public virtual uint Damage => BasicDamage;

        public Creature(string name, uint maxHealth, uint basicDamage)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(name));
            }

            if (maxHealth == 0)
            {
                throw new ArgumentException(nameof(maxHealth));
            }

            Name = name;
            CurrentHealth = MaxHealth = maxHealth;
            BasicDamage = basicDamage;
        }

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
