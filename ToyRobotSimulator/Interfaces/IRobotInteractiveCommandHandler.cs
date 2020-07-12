using TheToyRobotSimulator.Source;

namespace TheToyRobotSimulator
{
    public interface IRobotInteractiveCommandHandler
    {
        bool HandleCommand(string[] command);
    }
}