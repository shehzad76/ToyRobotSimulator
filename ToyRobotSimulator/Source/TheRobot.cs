namespace TheToyRobotSimulator
{
    using System;
    using TheToyRobotSimulator.Constants;

    public class TheRobot : ITheRobot
    {
        private int? _x;
        private int? _y;
        private RobotDirection? _f;
        private RobotPlacementValidator robotPlacementValidator = new RobotPlacementValidator(0, RobotTableBoard.Width);

        /// <summary>
        /// Sets _x, _y and _f values if request contains valid data and returns a bool to indicate success or failure 
        /// </summary>
        public bool Place(IPlacementRequest req)
        {
            var placed = false;

            if (req != null && robotPlacementValidator.IsValid(req.X.Value) && robotPlacementValidator.IsValid(req.Y.Value) && req.F != null)
            {
                  _x = req.X;
                  _y = req.Y;
                  _f = req.F;
                  placed = true;
            }

            return placed;
        }

        /// <summary>
        /// Moves robot one unit in direction faced
        /// </summary>
        public void Move()
        {
            switch (_f)
            {
                case RobotDirection.NORTH:
                    UtilityHelpers.ExecuteCommandIfTrue(() => _y++, robotPlacementValidator.IsValid(_y.Value + 1));
                    break;
                case RobotDirection.SOUTH:
                    UtilityHelpers.ExecuteCommandIfTrue(() => _y--, robotPlacementValidator.IsValid(_y.Value - 1));
                    break;
                case RobotDirection.EAST:
                    UtilityHelpers.ExecuteCommandIfTrue(() => _x++, robotPlacementValidator.IsValid(_x.Value + 1));
                    break;
                case RobotDirection.WEST:
                    UtilityHelpers.ExecuteCommandIfTrue(() => _x--, robotPlacementValidator.IsValid(_x.Value - 1));
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Calls Next with direction as increment of _f
        /// </summary>
        public void TurnLeft()
        {
            _f = DirectionUtilities.Next(_f.Value);
        }

        /// <summary>
        /// Calls Previous with direction as decrement of _f
        /// </summary>
        public void TurnRight()
        {
            _f = DirectionUtilities.Previous(_f.Value);
        }

        /// <summary>
        /// Outputs comma-separated string with _x,_y and _f values
        /// </summary>
        public void Report()
        {            
            Console.WriteLine($"\t\tOutput: {_x.Value}, {_y.Value},{_f.Value}");
        }
    }
}