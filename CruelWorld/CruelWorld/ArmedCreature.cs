namespace CruelWorld
{
    public abstract class ArmedCreature : Creature
    {
        protected ArmedCreature(uint maxHealth, uint basicDamage)
            : base(maxHealth, basicDamage)
        {
        }

        public Weapon Weapon { get; set; }

        public override uint Damage
        {
            get
            {
                var weaponDamage = Weapon?.Damage ?? 0;
                return base.Damage + weaponDamage;
            }
        }
    }
}