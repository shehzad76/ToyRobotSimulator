namespace TheToyRobotSimulator.Source
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System;
    using TheToyRobotSimulator.Constants;

    public class RobotApplicationDomain : IRobotApplicationDomain
    {
        private const string _commandLineSwitchHelp = "-help";
        private string[] _switches;
        public RobotApplicationDomain(string[] switches)
        {
            this._switches = switches;
        }

        public void Execute()
        {
            try
            {
                if (CanDisplayHelp())
                {
                    DisplayHelp();
                }
                else
                {
                    Console.Clear();
                }
                ExecuteInteractiveToyRobotSimulator();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception captured in top level entry method of the \"Toy Robot Challange application\".  Exception message: {e.Message}");
                Console.ReadKey();
            }
        }

        public bool CanDisplayHelp()
        {
            var result = this._switches.FirstOrDefault(
                (s) =>
                {
                    return s == _commandLineSwitchHelp;
                });

            return result != null;
        }

        public void ExecuteInteractiveToyRobotSimulator()
        {
            var execute = true;
            int counter = 1;
            IRobotInteractiveCommandHandler robotInteractiveCommandhandler = new RobotInteractiveCommandHandler(_switches);

            while (execute)
            {
                try
                {
                    Console.Write("\t\t{0}> ", counter++);
                    var command = Console.ReadLine();               

                    robotInteractiveCommandhandler.ExecuteCommand(UtilityHelpers.ConvertStringToArray(command));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Command: {0} ", ex.Message);
                }
            }
        }        
        
        #region Private methods

        private void DisplayHelp()
        {
            Console.Clear();
            Console.WriteLine("\t\t**********************************************************************");
            Console.WriteLine("\t\tTheToyRobotSimulator.exe [-help] [-nocase]");
            Console.WriteLine("\n\t\t-help\t\t--> Displays this help.");

            Console.WriteLine("\t\t-nocase\t\t--> By default the Robot commands are case-sensitive,");
            Console.WriteLine("\t\tuse this switch to allow case insensitive commands in interactive mode");
            Console.WriteLine("\t\t***********************************************************************");
        }        
        #endregion
    }
}
