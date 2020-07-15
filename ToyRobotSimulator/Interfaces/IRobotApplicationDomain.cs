using System;
using System.Collections.Generic;
using System.Text;

namespace TheToyRobotSimulator
{
    public interface IRobotApplicationDomain
    {
        void Execute();        
        bool CanDisplayHelp();
        void ExecuteInteractiveToyRobotSimulator();

        // void ExecuteFileInputToyRobotSimulator();
    }
}
