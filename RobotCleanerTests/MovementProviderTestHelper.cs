using RobotCleaner;
using System.Collections.Generic;

namespace RobotCleanerTests
{
    internal class MovementProviderTestHelper : IMovementProvider
    {
        private Queue<(Direction, int)> _directions = new Queue<(Direction, int)>(); 

        public void AddDirection(Direction direction, int step)
        {
            _directions.Enqueue((direction, step));
        }

        public (Direction direction, int steps) Next()
        {
            return _directions.Dequeue();
        }
    }
}
