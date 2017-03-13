using System;

namespace CruelWorld
{
    public class Goblin : ArmedCreature, IPredator
    {
        public Goblin(uint maxHealth, uint basicDamage)
            : base(maxHealth, basicDamage)
        {
        }

        public bool TryToEat(Creature other)
        {
            var eater = new Eater(this);
            return IsCapableOfEating(other) && eater.TryToEat(other);
        }

        private bool IsCapableOfEating(Creature other)
        {
            return !other.IsLarge;
        }
    }
}