using NUnit.Framework;

namespace CruelWorld.Tests.Unit
{
    public class GoblinFixture : CreatureFixture<Goblin>
    {
        protected override Goblin Create(uint maxHealth, uint basicDamage)
        {
            return new Goblin(maxHealth, basicDamage);
        }

        [Test]
        public void TryToEat_Ogre_Fails()
        {
            var goblin = new Goblin(200, 100);
            var ogre = new Ogre(200, 100);

            var success = goblin.TryToEat(ogre);
            Assert.IsFalse(success);
        }

        [Test]
        public void TryToEat_AnotherGoblin_Succeeds()
        {
            var goblin1 = new Goblin(200, 100);
            var goblin2 = new Goblin(200, 100);

            var success = goblin1.TryToEat(goblin2);
            Assert.IsTrue(success);
        }

        [Test]
        public void TryToEat_Sheep_Succeeds()
        {
            var goblin = new Goblin(200, 100);
            var sheep = new Sheep(10, 1);

            var success = goblin.TryToEat(sheep);
            Assert.IsTrue(success);
        }
    }
}