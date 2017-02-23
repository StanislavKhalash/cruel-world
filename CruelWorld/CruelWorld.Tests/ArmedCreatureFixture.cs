using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace CruelWorld.Tests
{
    public abstract class ArmedCreatureFixture<TArmedCreature>
        : CreatureFixture<TArmedCreature> where TArmedCreature : ArmedCreature
    {
        [Test]
        public void SetWeapon_NoWeapon_DamageIsEqualToBasicDamage()
        {
            uint basicDamage = 50;
            uint swordDamage = 100;
            var sword = new Weapon("Mighty Sword", swordDamage);

            var creature = Create("Armed Creature", 50, basicDamage);
            creature.Weapon = sword;
            creature.Weapon = null;

            Assert.AreEqual(basicDamage, creature.Damage);
        }

        public void SetWeapon_SomeWeapon_DamageIsAmplifiedByWeaponDamage()
        {
            uint basicDamage = 50;
            uint swordDamage = 100;
            var sword = new Weapon("Mighty Sword", swordDamage);

            var creature = Create("Armed Creature", 50, basicDamage);
            creature.Weapon = sword;

            Assert.AreEqual(150, creature.Damage);
        }
    }
}
