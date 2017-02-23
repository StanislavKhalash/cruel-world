using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruelWorld
{
    public abstract class ArmedCreature : Creature
    {
        public Weapon Weapon { get; set; }

        public override uint Damage
        {
            get
            {
                uint weaponDamage = Weapon != null ? Weapon.Damage : 0;
                return base.Damage + weaponDamage;
            }
        }

        public ArmedCreature(string name, uint maxHealth, uint basicDamage)
            : base(name, maxHealth, basicDamage)
        {
        }
    }
}
