namespace TheToyRobotSimulator
{
    using System;
    using System.Transactions;
    using TheToyRobotSimulator.Source;

    public static class Program
    {
        // Reads console input and executes command
        public static void Main(string [] args)
        {
            //var execute = true;
            //int counter = 1;
            //var robotCommandhandler = new RobotCommandHandler(new TheRobot());

            //Console.WriteLine("*** Welcome to Toy Robot Simulator ***");
            //Console.WriteLine("=========================================================================");
            //Console.WriteLine("Valid Commands are : PLACE <x>,<y>,<Direction>, MOVE, LEFT, RIGHT, REPORT");
            //Console.WriteLine("Type <EXIT>,<Q>,<QUIT> to Quit.. !");
            //Console.WriteLine("=========================================================================\n\n");

         //   var commandLineSwitches = new CommandLineSwitches(args);
            var robotApplicationDomain = new RobotApplicationDomain(args);

            robotApplicationDomain.Execute();

            //while (execute)
            //{
            //    try
            //    {
            //        Console.Write("{0}. ", counter++);
            //        robotCommandhandler.HandleCommand(UtilityHelpers.ConvertStringToArray(Console.ReadLine()));
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine("Invalid Command: {0} ", ex.Message);
            //    }
            //}
        }
    }
}
