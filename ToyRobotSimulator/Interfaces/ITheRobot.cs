namespace TheToyRobotSimulator
{
    public interface ITheRobot
    {
        bool Place(PlacementRequest req);

        void Move();

        void TurnLeft();

        void TurnRight();

        void Report();
    }
}