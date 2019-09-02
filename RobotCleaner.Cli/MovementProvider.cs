using System;

namespace RobotCleaner.Cli
{
    public class MovementProvider : IMovementProvider
    {
        public (Direction direction, int steps) Next()
        {
            var command = Console.ReadLine().Split(" ");

            var directionString = command[0];
            var steps = int.Parse(command[1]);

            var direction = Enum.Parse<Direction>(directionString);
            return (direction, steps);
        }
    }
}
