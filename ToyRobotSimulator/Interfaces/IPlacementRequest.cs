using System;
using System.Collections.Generic;
using System.Text;

namespace TheToyRobotSimulator
{
    public interface IPlacementRequest
    {
        int? X { get; set; }

        int? Y { get; set; }

        RobotDirection? F { get; set; }
    }
}
