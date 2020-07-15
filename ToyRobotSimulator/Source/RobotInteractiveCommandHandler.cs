namespace TheToyRobotSimulator
{
    using System;
    using System.Linq;
    using TheToyRobotSimulator.Constants;
    using TheToyRobotSimulator.Source;

    public class RobotInteractiveCommandHandler : IRobotInteractiveCommandHandler
    {
        private ITheRobot _rob;
        private bool _placeCommandHasBeenExecuted = false;
        private const string _commandLineSwitchCaseInsensitive = "-nocase";
        private string[] _switches;
        public RobotInteractiveCommandHandler(string[] switches)
        {
            _rob = new TheRobot();
            _switches = switches;
            ShowWelcomeMessages();
        }

        public bool CanUseCaseInsensitiveRobotCommands()
        {
            var result = this._switches.FirstOrDefault(
                (s) =>
                {
                    return s == _commandLineSwitchCaseInsensitive;
                });

            return result != null;
        }

        /// <summary>
        /// Handles command. Requires valid placement to occur before executing any other command 
        /// </summary>
        /// <param name="command"></param>
        /// <returns>bool</returns>
        public bool ExecuteCommand(string[] command)
        {
            if (command == null || command.Length == 0)
            {
                throw new ArgumentNullException("Command is Null or Empty.");
            }
            
            if (CanUseCaseInsensitiveRobotCommands())
            {
                if (!string.IsNullOrEmpty(command[0]))
                {
                    command[0] = command[0].ToUpper();
                }
                
                if (command.Length == 4 && !string.IsNullOrEmpty(command[3]))
                {
                    command[3] = command[3].ToUpper();
                }                
            }

            switch (command[0])
            {
                case CommandNames.PlaceCommandName:
                    if (command.Length < 4)
                    {
                        throw new Exception(string.Format("Not enough parameters. Expected 4, received {0}", command.Length));
                    }

                    int x;
                    if (!int.TryParse(command[1], out x))
                    {
                        throw new Exception(string.Format("PLACE parameter 1 is not a proper integer: {0}", command[1]));
                    }

                    int y;
                    if (!int.TryParse(command[2], out y))
                    {
                        throw new Exception(string.Format("PLACE parameter 2 is not a proper integer: {0}", command[2]));
                    }

                    RobotDirection direction;
                    if (!DirectionUtilities.TryParse(command[3], out direction))
                    {
                        throw new Exception(string.Format("PLACE parameter 3 is not a proper direction: {0}", command[3]));
                    }

                    IPlacementRequest placementRequest = new PlacementRequest() { X = x, Y = y, F = direction };
                    _placeCommandHasBeenExecuted = _rob.Place(placementRequest);
                    break;

                case CommandNames.MoveCommandName:
                    if (_placeCommandHasBeenExecuted)
                    {
                        _rob.Move();
                    }
                    else
                    {
                        throw new Exception("Attempted to use the robot before it has been placed");
                    }
                    break;

                case CommandNames.LeftCommandName:
                    if (_placeCommandHasBeenExecuted)
                    {
                        _rob.TurnLeft();
                    }
                    else
                    {
                        throw new Exception("Attempted to use the robot before it has been placed");
                    }
                    break;

                case CommandNames.RightCommandName:
                    if (_placeCommandHasBeenExecuted)
                    {
                        _rob.TurnRight();
                    }
                    else
                    {
                        throw new Exception("Attempted to use the robot before it has been placed");
                    }
                    break;

                case CommandNames.ReportCommandName:
                    if (_placeCommandHasBeenExecuted)
                    {
                        Console.WriteLine("\t\t======================");
                        _rob.Report();
                        Console.WriteLine("\t\t======================");
                    }
                    else
                    {
                        throw new Exception("Attempted to use the robot before it has been placed");
                    }
                    break;
                case CommandNames.ExitCommandName:
                case CommandNames.QuitCommandName:
                    System.Environment.Exit(0);
                    break;
                default:
                    throw new Exception("Command not listed!");
            }

            return _placeCommandHasBeenExecuted;
        }

        #region Private Methods
        private void ShowWelcomeMessages()
        {
            var caseSensitive = !CanUseCaseInsensitiveRobotCommands() ? "Case Sensitive." : "NOT Case Sensitive.";

            Console.WriteLine("\n\n\t\t================================================================================================");
            Console.WriteLine("\t\t\t* W E L C O M E  T O  T O Y  R O B O T  I N T E R A C T I V E  S I M U L A T O R *");
            Console.WriteLine("\t\t================================================================================================");
            Console.WriteLine($"\t\tBoard size is: {RobotTableBoard.Width}x{RobotTableBoard.Height}");
            Console.WriteLine("\t\tValid Commands are : PLACE <x>,<y>,<DIRECTION>, MOVE, LEFT, RIGHT, REPORT");

            Console.WriteLine($"\t\tCommands are {caseSensitive}");
            Console.WriteLine("\t\tType <EXIT>,<QUIT> to Quit.. !");
            Console.WriteLine("\t\t================================================================================================\n\n");
        }
        #endregion
    }
}
