namespace TheToyRobotSimulator
{
    public interface ITheRobot
    {
        bool Place(IPlacementRequest req);

        void Move();

        void TurnLeft();

        void TurnRight();

        void Report();
    }
}