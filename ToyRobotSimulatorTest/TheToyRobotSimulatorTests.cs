using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TheToyRobotSimulator;

namespace UnitTestProject1
{
    [TestClass]
    public class TheToyRobotSimulatorTests
    {
        private readonly ITheRobot _theRobot;
        private readonly IRobotInteractiveCommandHandler _robotCommandHandler;

        public TheToyRobotSimulatorTests()
        {
            _theRobot = new TheRobot();
            _robotCommandHandler = new RobotInteractiveCommandHandler(_theRobot);
        }
        /// <summary>
        /// Invalid placement
        /// </summary>
        [TestMethod]
        public void InvalidPlacementShouldNotOccur()
        {
            var placed = _theRobot.Place(new PlacementRequest { X = 10, Y = 10, F = RobotDirection.NORTH });
            Assert.IsFalse(placed);
        }

        /// <summary>
        /// Valid placement  
        /// </summary>
        [TestMethod]
        public void ValidPlacementShouldOccur()
        {
            var placed = _theRobot.Place(new PlacementRequest { X = 0, Y = 1, F = RobotDirection.NORTH });
            Assert.IsTrue(placed);
        }

        /// <summary>
        /// Invalid move 
        /// </summary>
        [TestMethod]
        public void InvalidMoveShouldNotOccur()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                _theRobot.Place(new PlacementRequest { X = 4, Y = 4, F = RobotDirection.NORTH });
                _theRobot.Move();
                _theRobot.Report();
                var report = sw.ToString();
                Assert.AreNotEqual(report, "5");
            }
        }
        /// <summary>
        /// Turn Left expected 
        /// </summary>
        [TestMethod]
        public void MoveLeftFromFacingNorthShouldBeWest()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                _theRobot.Place(new PlacementRequest { X = 4, Y = 4, F = RobotDirection.NORTH });
                _theRobot.TurnLeft();
                _theRobot.Report();
                var report = sw.ToString();
                Assert.AreEqual(RobotDirection.WEST.ToString(), report.Split(new string[] { ",", ":" }, StringSplitOptions.None)[3].Replace("\n", String.Empty).Replace("\r", string.Empty));
            }
        }

        [DataRow(1, 1, RobotDirection.EAST)]
        [DataTestMethod]
        public void MoveLeftManyTimesShouldNotBeInvalid(int x, int y, RobotDirection f)
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                _theRobot.Place(new PlacementRequest { X = x, Y = y, F = f });
                _theRobot.TurnLeft();
                _theRobot.TurnLeft();
                _theRobot.TurnLeft();
                _theRobot.TurnLeft();
                _theRobot.TurnLeft();
                _theRobot.Report();
                var report = sw.ToString();
                Assert.AreEqual(RobotDirection.NORTH.ToString(), report.Split(new string[] { ",", ":" }, StringSplitOptions.None)[3].Replace("\n", String.Empty).Replace("\r", String.Empty));
            }
        }

        [DataRow(1, 1, RobotDirection.EAST)]
        [DataTestMethod]
        public void MoveRighttManyTimesShouldNotBeInvalid(int x, int y, RobotDirection f)
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                _theRobot.Place(new PlacementRequest { X = x, Y = y, F = f });
                _theRobot.TurnRight();
                _theRobot.TurnRight();
                _theRobot.TurnRight();
                _theRobot.TurnRight();
                _theRobot.TurnRight();
                _theRobot.Report();
                var report = sw.ToString();
                Assert.AreEqual(RobotDirection.SOUTH.ToString(), report.Split(new string[] { ",", ":" }, StringSplitOptions.None)[3].Replace("\n", String.Empty).Replace("\r", String.Empty));
            }
        }

        /// <summary>
        /// Turn Right expected 
        /// </summary>
        [TestMethod]
        public void MoveRightFromFacingNorthShouldBeEast()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _theRobot.Place(new PlacementRequest { X = 4, Y = 4, F = RobotDirection.NORTH });
                _theRobot.TurnRight();
                _theRobot.Report();
                var report = sw.ToString();
                Assert.AreEqual(RobotDirection.EAST.ToString(), report.Split(new string[] { ",", ":" }, StringSplitOptions.None)[3].Replace("\n", String.Empty).Replace("\r", String.Empty));
            }
        }

        /// <summary>
        /// Report outputs values after valid place 
        /// </summary>
        [TestMethod]
        public void ReportShouldOutputIfPlacementOccurred()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                _theRobot.Place(new PlacementRequest { X = 4, Y = 4, F = RobotDirection.NORTH });
                _theRobot.Move();
                _theRobot.Report();
                var report = sw.ToString();
                Assert.IsFalse(string.IsNullOrEmpty(report));
            }
        }

        [TestMethod]
        public void HandleCommandShouldThrowNullExceptionIfCommandIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _robotCommandHandler.HandleCommand(null));
        }

    }
}
