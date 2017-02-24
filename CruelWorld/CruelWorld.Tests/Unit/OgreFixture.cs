using NUnit.Framework;

namespace CruelWorld.Tests.Unit
{
    [TestFixture]
    public class OgreFixture : ArmedCreatureFixture<Ogre>
    {
        protected override Ogre Create(uint maxHealth, uint basicDamage)
        {
            return new Ogre(maxHealth, basicDamage);
        }
    }
}