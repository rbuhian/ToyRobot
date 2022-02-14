using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Helper;
using ToyRobot.Model;

namespace ToyRobotTests
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        public void TestPlaceRobotOnTableOk()
        {
            //Arrange
            Robot robot = new Robot();
            string input = "PLACE 0, 0, NORTH";
            var expected = string.Format(OutputFormatting.Indent(2) + "0, 0, NORTH");

            //Act
            robot.InitTable(5, 5);
            RobotCommands cmd = new RobotCommands(input);
            string result = robot.Execute(cmd);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPlaceRobotOnTableTableNotInitialized()
        {
            //Arrange
            Robot robot = new Robot();
            string input = "PLACE 0, 0, NORTH";
            var expected = string.Format(OutputFormatting.Indent(2) + "Table not yet initialized.");

            //Act
            RobotCommands cmd = new RobotCommands(input);
            string result = robot.Execute(cmd);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPlaceRobotOnTableInvalidArgumentCount()
        {
            //Arrange
            Robot robot = new Robot();
            string input = "PLACE 0, 0";
            var expected = string.Format(OutputFormatting.Indent(2) + "Invalid Argument");

            //Act
            robot.InitTable(5, 5);
            RobotCommands cmd = new RobotCommands(input);
            string result = robot.Execute(cmd);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPlaceRobotOnTableInvalidDirection()
        {
            //Arrange
            Robot robot = new Robot();
            string input = "PLACE 0, 0, LEFT";
            var expected = string.Format(OutputFormatting.Indent(2) + "Invalid direction");

            //Act
            robot.InitTable(5, 5);
            RobotCommands cmd = new RobotCommands(input);
            string result = robot.Execute(cmd);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMoveRobotOk()
        {
            //Arrange
            Robot robot = new Robot();
            string input = "PLACE 0, 0, NORTH";
            string input2 = "MOVE";
            var expected = string.Format(OutputFormatting.Indent(2) + "0, 1, NORTH");

            //Act
            robot.InitTable(5, 5);
            RobotCommands cmd = new RobotCommands(input);
            string result = robot.Execute(cmd);

            cmd = new RobotCommands(input2);
            result = robot.Execute(cmd);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMoveRobotIgnoreIfWillFallSouth()
        {
            //Arrange
            Robot robot = new Robot();
            string input = "PLACE 0, 0, SOUTH";
            string input2 = "MOVE";
            var expected = string.Format(OutputFormatting.Indent(2) + "0, 0, SOUTH");

            //Act
            robot.InitTable(5, 5);
            RobotCommands cmd = new RobotCommands(input);
            string result = robot.Execute(cmd);

            cmd = new RobotCommands(input2);
            result = robot.Execute(cmd);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestRobotRotateLeft()
        {
            //Arrange
            Robot robot = new Robot();
            string input = "PLACE 0, 0, NORTH";
            string input2 = "LEFT";
            var expected = string.Format(OutputFormatting.Indent(2) + "0, 0, WEST");

            //Act
            robot.InitTable(5, 5);
            RobotCommands cmd = new RobotCommands(input);
            string result = robot.Execute(cmd);
            cmd = new RobotCommands(input2);
            result = robot.Execute(cmd);

            //Assert
            Assert.AreEqual(expected, result);

            //Act
            cmd = new RobotCommands(input2);
            result = robot.Execute(cmd);

            //Assert 
            expected = string.Format(OutputFormatting.Indent(2) + "0, 0, SOUTH");
            Assert.AreEqual(expected, result);

            //Act
            cmd = new RobotCommands(input2);
            result = robot.Execute(cmd);

            //Assert 
            expected = string.Format(OutputFormatting.Indent(2) + "0, 0, EAST");
            Assert.AreEqual(expected, result);

            //Act
            cmd = new RobotCommands(input2);
            result = robot.Execute(cmd);

            //Assert 
            expected = string.Format(OutputFormatting.Indent(2) + "0, 0, NORTH");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestRobotRotateRight()
        {
            //Arrange
            Robot robot = new Robot();
            string input = "PLACE 0, 0, NORTH";
            string input2 = "RIGHT";
            var expected = string.Format(OutputFormatting.Indent(2) + "0, 0, EAST");

            //Act
            robot.InitTable(5, 5);
            RobotCommands cmd = new RobotCommands(input);
            string result = robot.Execute(cmd);
            cmd = new RobotCommands(input2);
            result = robot.Execute(cmd);

            //Assert
            Assert.AreEqual(expected, result);

            //Act
            cmd = new RobotCommands(input2);
            result = robot.Execute(cmd);

            //Assert 
            expected = string.Format(OutputFormatting.Indent(2) + "0, 0, SOUTH");
            Assert.AreEqual(expected, result);

            //Act
            cmd = new RobotCommands(input2);
            result = robot.Execute(cmd);

            //Assert 
            expected = string.Format(OutputFormatting.Indent(2) + "0, 0, WEST");
            Assert.AreEqual(expected, result);

            //Act
            cmd = new RobotCommands(input2);
            result = robot.Execute(cmd);

            //Assert 
            expected = string.Format(OutputFormatting.Indent(2) + "0, 0, NORTH");
            Assert.AreEqual(expected, result);
        }
    }
}
