namespace CruelWorld
{
    public class Ogre : ArmedCreature, IPredator
    {
        public Ogre(uint maxHealth, uint basicDamage)
            : base(maxHealth, basicDamage)
        {
            IsLarge = true;
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