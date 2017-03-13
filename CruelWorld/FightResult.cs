namespace CruelWorld
{
    public class FightResult
    {
        public FightResult(bool defenderDefeated)
        {
            DefenderDefeated = defenderDefeated;
        }

        public bool DefenderDefeated { get; }
    }
}