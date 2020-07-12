namespace TheToyRobotSimulator
{
    using System;
    using TheToyRobotSimulator.Constants;

    public static class DirectionUtilities
    {
        public static RobotDirection Next(RobotDirection direction)
        {
            return (RobotDirection)(((int)direction + 1) % RobotTableBoard.Width);
        }

        public static RobotDirection Previous(RobotDirection direction)
        {
            return (direction == RobotDirection.NORTH) ? RobotDirection.EAST : (RobotDirection)((int)direction - 1);
        }

        public static RobotDirection Parse(string text)
        {
            return Enum.Parse<RobotDirection>(text);
        }

        public static bool TryParse(string text, out RobotDirection direction)
        {
            return Enum.TryParse<RobotDirection>(text, out direction);
        }
    }
}