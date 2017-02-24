using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CruelWorld.Tests.Unit
{
    [TestFixture]
    public class EaterFixture
    {
        [Test]
        public void Constructor_PredatorIsNull_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new Eater(null));
        }

        [Test]
        public void TryToEat_VictimIsNull_ThrowsException()
        {
            var predator = new Ogre(200, 100);
            var eater = new Eater(predator);
            Assert.Throws<ArgumentNullException>(() => eater.TryToEat(null));
        }

        [Test]
        public void TryToEat_StrongPredatorAndWeakVictimHaveNoParties_Suceeds()
        {
            var predator = new Ogre(200, 100);
            var victim = new Ogre(200, 100);

            var eater = new Eater(predator);
            bool success = eater.TryToEat(victim);

            Assert.IsTrue(success);
        }

        [Test]
        public void TryToEat_WeakPredatorAndStrongVictimHaveNoParties_Fails()
        {
            var predator = new Ogre(200, 100);
            var victim = new Goblin(2000, 100);

            var eater = new Eater(predator);
            bool success = eater.TryToEat(victim);

            Assert.IsFalse(success);
        }

        [Test]
        public void TryToEat_BothSidesHavePartiesAndAttackersAreStronger_Succeeds()
        {
            var strongAttackers = new Party(new List<Creature> { new Ogre(200, 100), new Ogre(200, 100) });
            var weakDefenders = new Party(new List<Creature> { new Goblin(100, 75), new Goblin(100, 75) });

            var predator = strongAttackers.Creatures.First();
            var victim = weakDefenders.Creatures.First();

            var eater = new Eater(predator);
            bool success = eater.TryToEat(victim);

            Assert.IsTrue(success);
        }

        [Test]
        public void TryToEat_BothSidesHavePartiesAndDefendersAreStronger_Fails()
        {
            var weakAttackers = new Party(new List<Creature> { new Goblin(50, 50), new Goblin(50, 50) });
            var strongDefenders = new Party(new List<Creature> { new Goblin(100, 75), new Goblin(100, 75) });

            var predator = weakAttackers.Creatures.First();
            var victim = strongDefenders.Creatures.First();

            var eater = new Eater(predator);
            bool success = eater.TryToEat(victim);

            Assert.IsFalse(success);
        }
    }
}