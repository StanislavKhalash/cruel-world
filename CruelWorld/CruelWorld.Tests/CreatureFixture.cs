using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CruelWorld;
using NUnit.Framework;

namespace CruelWorld.Tests
{
    public abstract class CreatureFixture<TCreature> where TCreature : Creature
    {
        [TestCase(null)]
        [TestCase("")]
        public void Constructor_NameIsNullOrEmpty_ThrowsException(string name)
        {
            Assert.Throws<ArgumentException>(() => Create(name, 100, 50));
        }

        [Test]
        public void Constructor_MaxHealthIsZero_ThrowsException()
        {
            uint maxHealth = 0;
            Assert.Throws<ArgumentException>(() => Create("Creature", maxHealth, 50));
        }

        [Test]
        public void Constructor_HasFullHealth()
        {
            var creature = Create("Creature", 100, 0);
            Assert.AreEqual(creature.MaxHealth, creature.CurrentHealth);
        }

        [Test]
        public void Constructor_HasBasicDamage()
        {
            uint basicDamage = 50;
            var creature = Create("Creature", 100, basicDamage);
            Assert.AreEqual(basicDamage, creature.Damage);
        }

        protected abstract TCreature Create(string name, uint maxHealth, uint basicDamage);
    }
}
