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

        [Test]
        public void TryToEat_AnotherOgre_Fails()
        {
            var ogre1 = new Ogre(200, 100);
            var ogre2 = new Ogre(200, 100);

            var success = ogre1.TryToEat(ogre2);
            Assert.IsFalse(success);
        }

        [Test]
        public void TryToEat_Goblin_Succeeds()
        {
            var ogre = new Ogre(200, 100);
            var goblin = new Goblin(100, 10);

            var success = ogre.TryToEat(goblin);
            Assert.IsTrue(success);
        }

        [Test]
        public void TryToEat_Sheep_Succeeds()
        {
            var ogre = new Ogre(200, 100);
            var sheep = new Sheep(10, 1);

            var success = ogre.TryToEat(sheep);
            Assert.IsTrue(success);
        }
    }
}