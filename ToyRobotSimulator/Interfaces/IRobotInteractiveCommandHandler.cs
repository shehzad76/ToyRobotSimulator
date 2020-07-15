using TheToyRobotSimulator.Source;

namespace TheToyRobotSimulator
{
    public interface IRobotInteractiveCommandHandler
    {
        bool ExecuteCommand(string[] command);

        bool CanUseCaseInsensitiveRobotCommands();
    }
}