namespace CruelWorld
{
    public interface IPredator
    {
        bool TryToEat(Creature other);
    }
}