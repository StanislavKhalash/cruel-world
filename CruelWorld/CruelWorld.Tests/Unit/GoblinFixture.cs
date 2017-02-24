namespace CruelWorld.Tests.Unit
{
    public class GoblinFixture : CreatureFixture<Goblin>
    {
        protected override Goblin Create(uint maxHealth, uint basicDamage)
        {
            return new Goblin(maxHealth, basicDamage);
        }
    }
}