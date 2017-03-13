namespace CruelWorld
{
    public static class CreatureExtensions
    {
        public static Party AsParty(this Creature creature)
        {
            return new Party(new[] {creature});
        }
    }
}
