using System.Collections.Generic;

namespace RobotCleaner
{
    public class Robot
    {
        private IMovementProvider _directionProvider;

        private HashSet<string> _cleanedSpaces;
        private (int currentX, int currentY) _currentPosition; 

        public Robot(IMovementProvider directionProvider)
        {
            _directionProvider = directionProvider;
        }

        public int Start(int numberOfCommands, int startingPositionX, int startingPositionY)
        {
            _currentPosition = (startingPositionX, startingPositionY);
            _cleanedSpaces = new HashSet<string>();

            CleanPosition();

            for (int i = 0; i < numberOfCommands; i++)
            {
                var command = _directionProvider.Next();
                MoveRobot(command);
            }

            return _cleanedSpaces.Count;
        }
        private void MoveRobot((Direction direction, int steps) command)
        {
            for (int i = 0; i < command.steps; i++)
            {
                switch (command.direction)
                {
                    case Direction.N:
                        _currentPosition.currentX++;
                        break;
                    case Direction.E:
                        _currentPosition.currentY++;
                        break;
                    case Direction.S:
                        _currentPosition.currentX--;
                        break;
                    case Direction.W:
                        _currentPosition.currentY--;
                        break;
                }

                CleanPosition();
            }
        }

        private void CleanPosition()
        {
            var isClean = _cleanedSpaces.Contains($"{_currentPosition.currentX},{_currentPosition.currentY}");

            if (!isClean)
            {
                _cleanedSpaces.Add($"{_currentPosition.currentX},{_currentPosition.currentY}");
            }
        }
    }
}
