using System;
using System.Linq;

namespace RobotCleaner.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfCommands = int.Parse(Console.ReadLine());
            var startingPosition = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();

            var robot = new Robot(new MovementProvider());

            var cleanedSpaces = robot.Start(numberOfCommands, startingPosition[0], startingPosition[1]);

            Console.WriteLine($"=> Cleaned: {cleanedSpaces}");
        }
    }
}
