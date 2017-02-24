using System;

namespace CruelWorld
{
    public class Weapon
    {
        public Weapon(string name, uint damage)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(name));
            }

            Name = name;
            Damage = damage;
        }

        public string Name { get; }

        public uint Damage { get; }
    }
}