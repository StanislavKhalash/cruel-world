using System;
using System.Collections.Generic;

namespace CruelWorld
{
    public sealed class Eater
    {
        private readonly Creature _predator;

        public Eater(Creature predator)
        {
            if (predator == null)
            {
                throw new ArgumentNullException(nameof(predator));
            }

            _predator = predator;
        }

        public bool TryToEat(Creature victim)
        {
            if (victim == null)
            {
                throw new ArgumentNullException(nameof(victim));
            }

            var predatorAllies = _predator.Allies ?? new Party(new List<Creature> {_predator});
            var victimAllies = victim.Allies ?? new Party(new List<Creature> {victim});

            var fightResult = predatorAllies.FightWith(victimAllies);

            return fightResult.DefenderDefeated;
        }
    }
}