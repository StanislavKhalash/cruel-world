using System;
using NUnit.Framework;

namespace CruelWorld.Tests.Unit
{
    public abstract class CreatureFixture<TCreature> where TCreature : Creature
    {
        [Test]
        public void Constructor_MaxHealthIsZero_ThrowsException()
        {
            uint maxHealth = 0;
            Assert.Throws<ArgumentException>(() => Create(maxHealth, 50));
        }

        [Test]
        public void Constructor_HasFullHealth()
        {
            var creature = Create(100, 0);
            Assert.AreEqual(creature.MaxHealth, creature.CurrentHealth);
        }

        [Test]
        public void Constructor_HasBasicDamage()
        {
            uint basicDamage = 50;
            var creature = Create(100, basicDamage);
            Assert.AreEqual(basicDamage, creature.Damage);
        }

        [Test]
        public void Constructor_IsAlive()
        {
            var creature = Create(100, 0);
            Assert.IsTrue(creature.IsAlive);
        }

        [Test]
        public void Attack_DamageIsLessThanCurrentHealth_StaysAlive()
        {
            uint attackerDamage = 50;
            uint defenderMaxHealth = 100;

            var attacker = Create(100, attackerDamage);
            var defender = Create(defenderMaxHealth, 0);
            attacker.Attack(defender);

            Assert.IsTrue(defender.IsAlive);
        }

        [Test]
        public void Attack_DamageIsLessThanCurrentHealth_DecreasesHealth()
        {
            uint attackerDamage = 50;
            uint defenderMaxHealth = 100;

            var attacker = Create(100, attackerDamage);
            var defender = Create(defenderMaxHealth, 0);
            attacker.Attack(defender);

            Assert.AreEqual(50, defender.CurrentHealth);
        }

        [Test]
        public void Attack_DamageIsGreaterThanCurrentHealth_Kills()
        {
            uint attackerDamage = 150;
            uint defenderMaxHealth = 100;

            var attacker = Create(100, attackerDamage);
            var defender = Create(defenderMaxHealth, 0);
            attacker.Attack(defender);

            Assert.IsFalse(defender.IsAlive);
        }

        [Test]
        public void Attack_DamageIsLessThanCurrentHealth_HealthDropsToZero()
        {
            uint attackerDamage = 150;
            uint defenderMaxHealth = 100;

            var attacker = Create(100, attackerDamage);
            var defender = Create(defenderMaxHealth, 0);
            attacker.Attack(defender);

            Assert.AreEqual(0, defender.CurrentHealth);
        }

        protected abstract TCreature Create(uint maxHealth, uint basicDamage);
    }
}