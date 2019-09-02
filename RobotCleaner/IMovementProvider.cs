namespace RobotCleaner
{
    public interface IMovementProvider
    {
        (Direction direction, int steps) Next();
    }
}