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
            IRobotApplicationDomain robotApplicationDomain = new RobotApplicationDomain(args);
            robotApplicationDomain.Execute();
        }
    }
}
