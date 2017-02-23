using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruelWorld
{
    public class Weapon
    {
        public string Name { get; }

        public uint Damage { get; }

        public Weapon(string name, uint damage)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(name));
            }

            Name = name;
            Damage = damage;
        }
    }
}
