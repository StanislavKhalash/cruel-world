using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace CruelWorld.Tests
{
    [TestFixture]
    public class OgreFixture : ArmedCreatureFixture<Ogre>
    {
        protected override Ogre Create(string name, uint maxHealth, uint basicDamage)
        {
            return new Ogre(name, maxHealth, basicDamage);
        }
    }
}
