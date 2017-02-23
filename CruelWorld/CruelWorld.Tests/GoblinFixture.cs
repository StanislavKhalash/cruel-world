using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruelWorld.Tests
{
    public class GoblinFixture : CreatureFixture<Goblin>
    {
        protected override Goblin Create(string name, uint maxHealth, uint basicDamage)
        {
            return new Goblin(name, maxHealth, basicDamage);
        }
    }
}
