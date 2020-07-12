namespace TheToyRobotSimulator
{
    using System;
    using TheToyRobotSimulator.Source;

    public class RobotInteractiveCommandHandler : IRobotInteractiveCommandHandler
    {
        private ITheRobot _rob;
        private bool _placeCommandHasBeenExecuted = false;

        public RobotInteractiveCommandHandler(ITheRobot rob)
        {
            _rob = rob;
        }

        /// <summary>
        /// Handles command. Requires valid placement to occur before executing any other command 
        /// </summary>
        /// <param name="command"></param>
        /// <returns>bool</returns>
        public bool HandleCommand(string[] command)
        {
            if (command == null || command.Length == 0)
            {
                throw new ArgumentNullException("Command is Null or Empty.");
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
                        throw new Exception(string.Format("Place parameter 0 is not a proper integer: {0}", command[1]));
                    }

                    int y;
                    if (!int.TryParse(command[2], out y))
                    {
                        throw new Exception(string.Format("Place parameter 1 is not a proper integer: {0}", command[2]));
                    }

                    RobotDirection direction;
                    if (!DirectionUtilities.TryParse(command[3], out direction))
                    {
                        throw new Exception(string.Format("Place parameter 2 is not a proper direction: {0}", command[3]));
                    }

                    var placementRequest = new PlacementRequest() { X = x, Y = y, F = direction };
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
    }
}
