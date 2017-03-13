namespace CruelWorld.Tests.Unit
{
    public class SheepFixture : CreatureFixture<Sheep>
    {
        protected override Sheep Create(uint maxHealth, uint basicDamage)
        {
            return new Sheep(maxHealth, basicDamage);
        }
    }
}