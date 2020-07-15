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
        private IPlacementRequest placementRequest;
        public TheToyRobotSimulatorTests()
        {
            _theRobot = new TheRobot();
            _robotCommandHandler = new RobotInteractiveCommandHandler(new string[] {});
        }
        /// <summary>
        /// Invalid placement
        /// </summary>
        [TestMethod]
        public void InvalidPlacementShouldNotOccur()
        {
            placementRequest = new PlacementRequest
            {
                X = 10,
                Y = 10,
                F = RobotDirection.NORTH
            };
            var placed = _theRobot.Place(placementRequest);
            Assert.IsFalse(placed);
        }

        /// <summary>
        /// Valid placement  
        /// </summary>
        [TestMethod]
        public void ValidPlacementShouldOccur()
        {
            placementRequest = new PlacementRequest
            {
                X = 0,
                Y = 1,
                F = RobotDirection.NORTH
            };
            var placed = _theRobot.Place(placementRequest);
            Assert.IsTrue(placed);
        }

        /// <summary>
        /// Invalid move 
        /// </summary>
        [TestMethod]
        public void InvalidMoveShouldNotOccur()
        {
            placementRequest = new PlacementRequest
            {
                X = 4,
                Y = 4,
                F = RobotDirection.NORTH
            };

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                _theRobot.Place(placementRequest);
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
            placementRequest = new PlacementRequest
            {
                X = 4, 
                Y = 4, 
                F = RobotDirection.NORTH 
            };
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                _theRobot.Place(placementRequest);
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
            placementRequest = new PlacementRequest
            {
                X = x,
                Y = y,
                F = f
            };

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                _theRobot.Place(placementRequest);
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
            placementRequest = new PlacementRequest
            {
                X = x,
                Y = y,
                F = f
            };
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                _theRobot.Place(placementRequest);
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
            placementRequest = new PlacementRequest
            {
                X = 4,
                Y = 4,
                F = RobotDirection.NORTH
            };
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _theRobot.Place(placementRequest);
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
            placementRequest = new PlacementRequest
            {
                X = 4,
                Y = 4,
                F = RobotDirection.NORTH
            };
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                _theRobot.Place(placementRequest);
                _theRobot.Move();
                _theRobot.Report();
                var report = sw.ToString();
                Assert.IsFalse(string.IsNullOrEmpty(report));
            }
        }

        [TestMethod]
        public void HandleCommandShouldThrowNullExceptionIfCommandIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _robotCommandHandler.ExecuteCommand(null));
        }

    }
}
