namespace TheToyRobotSimulator
{
    public class RobotPlacementValidator
    {
        public int Min { get; private set; }
        public int Max { get; private set; }
        public RobotPlacementValidator(int min, int max)
        {
            this.Min = min;
            this.Max = max;
        }

        public bool IsValid (int position)
        {
            return (position >= Min) && (position <= Max);
        }
    }
}