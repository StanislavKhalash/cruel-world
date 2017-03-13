using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CruelWorld.Tests.Scenarios
{
    [TestFixture]
    public class ScenarioTests
    {
        [Test]
        public void GoblinTriesToEatShip_Succeeds()
        {
            var goblin = new Goblin(200, 100);
            var sheep = new Sheep(10, 1);

            var success = goblin.TryToEat(sheep);

            Assert.IsTrue(success);
        }

        [Test]
        public void OgreTriesToEatGoblinWithParty_Fails()
        {
            var ogre = new Ogre(150, 50);
            var weakGoblins = new[] { new Goblin(75, 30), new Goblin(75, 30), new Goblin(75, 30) };
            var weakGoblinParty = new Party(weakGoblins);

            var success = ogre.TryToEat(weakGoblins.First());

            Assert.IsFalse(success);
        }

        [Test]
        public void OgreWithPartyTriesToEatGoblinWithParty_Succeeds()
        {
            var ogres = new[] {new Ogre(150, 50), new Ogre(150, 50)};
            var weakGoblins = new[] {new Goblin(75, 30), new Goblin(75, 30), new Goblin(75, 30)};
            var ogreParty = new Party(ogres);
            var weakGoblinParty = new Party(weakGoblins);

            var success = ogres.First().TryToEat(weakGoblins.First());

            Assert.IsTrue(success);
        }

        [Test]
        public void TwoGoblinsFightForShipAndWinnerTriesToEatTheShip_Succeeds()
        {
            var strongGoblin = new Goblin(200, 100);
            var weakGoblin = new Goblin(100, 10);
            var sheep = new Sheep(10, 1);

            var result = strongGoblin.AsParty().FightWith(weakGoblin.AsParty());

            Assert.True(result.DefenderDefeated);

            var success = strongGoblin.TryToEat(sheep);

            Assert.IsTrue(success);
        }

        [Test]
        public void OgreWithPartyTriesToEatGoblinWithMagicSword_Fails()
        {
            var ogres = new[] { new Ogre(150, 50), new Ogre(150, 50) };
            var mightyGoblin = new Goblin(120, 30) {Weapon = new Weapon("Magical Sword", 1000)};
            var ogreParty = new Party(ogres);

            var success = ogres.First().TryToEat(mightyGoblin);

            Assert.IsFalse(success);
        }

        [Test]
        public void SheepHerdAndGoblinGroupFightsWithOgreGroup_Succeeds()
        {
            var goblins = new[] { new Goblin(75, 30), new Goblin(75, 30), new Goblin(75, 30) };
            var sheeps = Enumerable.Range(0, 1000).Select(_ => new Sheep(50, 10));
            var ogres = new[] { new Ogre(1050, 50), new Ogre(1050, 50) };

            var attackerParty = new Party(goblins.Concat<Creature>(sheeps));
            var defenderParty = new Party(ogres);

            var result = attackerParty.FightWith(defenderParty);

            Assert.IsTrue(result.DefenderDefeated);
        }
    }
}