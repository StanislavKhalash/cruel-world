using System;
using System.Collections.Generic;
using System.Linq;

namespace CruelWorld
{
    public class Party
    {
        public Party(IEnumerable<Creature> creatures)
        {
            if (creatures == null)
            {
                throw new ArgumentNullException(nameof(creatures));
            }

            Creatures = new List<Creature>(creatures);

            if (!Creatures.Any())
            {
                throw new ArgumentException(nameof(creatures));
            }
        }

        public List<Creature> Creatures { get; }

        public FightResult FightWith(Party other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            var liveAttackers = new Stack<Creature>(Creatures);
            var liveDefenders = new Stack<Creature>(other.Creatures);

            while (liveAttackers.Any() && liveDefenders.Any())
            {
                var attacker = liveAttackers.Pop();
                var defender = liveDefenders.Pop();

                FightUntilOneDies(attacker, defender);

                if (attacker.IsAlive)
                {
                    liveAttackers.Push(attacker);
                }
                else if (defender.IsAlive)
                {
                    liveDefenders.Push(defender);
                }
            }

            var defendersDefeated = !liveDefenders.Any();
            return new FightResult(defendersDefeated);
        }

        private void FightUntilOneDies(Creature attacker, Creature defender)
        {
            while (attacker.IsAlive && defender.IsAlive)
            {
                attacker.Attack(defender);
                defender.Attack(attacker);
            }
        }
    }
}