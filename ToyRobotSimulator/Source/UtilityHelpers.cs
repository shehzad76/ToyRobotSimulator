namespace TheToyRobotSimulator
{
    using System;
    public static class UtilityHelpers
    {
        public static int? ParseIntegerAsNullable(string text)
        {
            return int.TryParse(text, out int res) ? res : (int?)null;
        }

        public static RobotDirection ConvertStringtoDirection(string text)
        {
            Enum.TryParse(typeof(RobotDirection), text, out object direction);
            return (RobotDirection)direction;
        }

        public static string[] ConvertStringToArray(string text)
        {
            return text?.Split(new string[] { " ", "," }, StringSplitOptions.None);
        }

        public static void ExecuteCommandIfTrue(Action action, bool condition)
        {
            if (condition && action != null)
            {
                action.Invoke();
            }
        }
    }
}