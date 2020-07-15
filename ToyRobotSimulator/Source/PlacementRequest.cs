namespace TheToyRobotSimulator
{
    public class PlacementRequest : IPlacementRequest
    {
        public int? X { get; set; }

        public int? Y { get; set; }

        public RobotDirection? F { get; set; }
    }
}