using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruelWorld.Tests
{
    public class ShipFixture : CreatureFixture<Ship>
    {
        protected override Ship Create(string name, uint maxHealth, uint basicDamage)
        {
            return new Ship(name, maxHealth, basicDamage);
        }
    }
}
