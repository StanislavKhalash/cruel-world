namespace CruelWorld.Tests.Unit
{
    public class ShipFixture : CreatureFixture<Ship>
    {
        protected override Ship Create(uint maxHealth, uint basicDamage)
        {
            return new Ship(maxHealth, basicDamage);
        }
    }
}