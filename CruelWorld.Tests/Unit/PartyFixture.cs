﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CruelWorld.Tests.Unit
{
    [TestFixture]
    public class PartyFixture
    {
        [Test]
        public void Constructor_ListIsNull_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new Party(null));
        }

        [Test]
        public void Constructor_CreatureIsInAnotherParty_ThrowsException()
        {
            var goblin = new Goblin(100, 20);

            var party = new Party(new List<Creature> { goblin });

            Assert.Throws<InvalidOperationException>(() => new Party(new List<Creature> { goblin }));
        }

        [Test]
        public void Constructor_SetsAlliedParty()
        {
            var goblins = Enumerable.Range(0, 100).Select(_ => new Goblin(70, 15)).ToList();
            var party = new Party(goblins);

            var allGoblinsAreInAlliedParty = party.Creatures.All(creature => creature.Allies == party);
            Assert.IsTrue(allGoblinsAreInAlliedParty);
        }

        [Test]
        public void Constructor_ListIsEmpty_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Party(new List<Creature>()));
        }

        [Test]
        public void Constructor_ListHasNulls_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new Party(new List<Creature> {null}));
        }

        [Test]
        public void FightWith_DefeatedPartyIsAllDead()
        {
            var legendaryGoblin = new Goblin(uint.MaxValue, uint.MaxValue);
            var weakGoblinHorde = Enumerable.Range(0, 100).Select(_ => new Goblin(70, 15)).ToList();

            var attackingParty = legendaryGoblin.AsParty();
            var defendingParty = new Party(weakGoblinHorde);

            attackingParty.FightWith(defendingParty);

            Assert.IsFalse(defendingParty.Creatures.Any(creature => creature.IsAlive));
        }

        [Test]
        public void FightWith_DefenderPartyHasFewWeakCreaturesThatAreStrongerTogether_DefenderWins()
        {
            var strongGoblin = new Goblin(100, 20);
            var weakGoblin1 = new Goblin(70, 15);
            var weakGoblin2 = new Goblin(70, 15);

            var attackingParty = strongGoblin.AsParty();
            var defendingParty = new Party(new List<Creature> {weakGoblin1, weakGoblin2});

            var result = attackingParty.FightWith(defendingParty);

            Assert.IsFalse(result.DefenderDefeated);
        }

        [Test]
        public void FightWith_PartyIsNull_ThrowsException()
        {
            var party = new Party(new List<Creature> {new Goblin(100, 20)});
            Assert.Throws<ArgumentNullException>(() => party.FightWith(null));
        }

        [Test]
        public void FightWith_TwoCreaturesAndDefenderHasMoreDamage_DefenderWins()
        {
            var goblinAttacker = new Goblin(100, 20);
            var goblinDefender = new Goblin(100, 25);

            var result = goblinAttacker.AsParty().FightWith(goblinDefender.AsParty());

            Assert.IsFalse(result.DefenderDefeated);
        }

        [Test]
        public void FightWith_TwoCreaturesAndDefenderHasMoreHealth_DefenderWins()
        {
            var goblinAttacker = new Goblin(100, 20);
            var goblinDefender = new Goblin(110, 20);

            var result = goblinAttacker.AsParty().FightWith(goblinDefender.AsParty());

            Assert.IsFalse(result.DefenderDefeated);
        }

        [Test]
        public void FightWith_TwoEquallyStrongCharacters_AttackerWins()
        {
            var goblinAttacker = new Goblin(100, 20);
            var goblinDefender = new Goblin(100, 20);

            var result = goblinAttacker.AsParty().FightWith(goblinDefender.AsParty());

            Assert.IsTrue(result.DefenderDefeated);
        }
    }
}