namespace TheToyRobotSimulator.Source
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System;
    using TheToyRobotSimulator.Constants;

    public class RobotApplicationDomain
    {
        private const string _commandLineSwitchHelp = "-help";
        private const string _commandLineSwitchCaseInsensitive = "-nocase";
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
    
        public bool CanUseCaseInsensitiveRobotCommands()
        {
            var result = this._switches.FirstOrDefault(
                (s) =>
                {
                    return s == _commandLineSwitchCaseInsensitive;
                });

            return result != null;
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

        private void ExecuteInteractiveToyRobotSimulator()
        {
            var execute = true;
            int counter = 1;
            var robotInteractiveCommandhandler = new RobotInteractiveCommandHandler(new TheRobot());
            var caseSensitive = !CanUseCaseInsensitiveRobotCommands() ? "Case Sensitive." : "NOT Case Sensitive.";

            Console.WriteLine("\n\n\t\t===========================================================================");
            Console.WriteLine("\t\t\t* W E L C O M E  T O  T O Y  R O B O T  S I M U L A T O R *");
            Console.WriteLine("\t\t===========================================================================");
            Console.WriteLine($"\t\tBoard size is: {RobotTableBoard.Width}x{RobotTableBoard.Height}");
            Console.WriteLine("\t\tValid Commands are : PLACE <x>,<y>,<DIRECTION>, MOVE, LEFT, RIGHT, REPORT");
            
            Console.WriteLine($"\t\tCommands are {caseSensitive}");
            Console.WriteLine("\t\tType <EXIT>,<QUIT> to Quit.. !");
            Console.WriteLine("\t\t===========================================================================\n\n");

            while (execute)
            {
                try
                {
                    Console.Write("\t\t{0}> ", counter++);
                    var command = Console.ReadLine();
                    if (CanUseCaseInsensitiveRobotCommands())
                    {
                        command = command.ToUpper();
                    }

                    robotInteractiveCommandhandler.HandleCommand(UtilityHelpers.ConvertStringToArray(command));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Command: {0} ", ex.Message);
                }
            }


        }
        #endregion
    }
}
