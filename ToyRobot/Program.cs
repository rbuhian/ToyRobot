using System;
using ToyRobot.Helper;
using ToyRobot.Model;

namespace ToyRobot
{
    class Program
    {
        const string _readPrompt = "iRobot> ";

        static void Main(string[] args)
        {
            Robot robot = new Robot();
            RobotCommands cmd = null;

            try
            {
                robot.InitTable(5, 5);
                
                do
                {
                    var consoleInput = ReadFromConsole();
                    if (string.IsNullOrWhiteSpace(consoleInput)) continue;

                    cmd = new RobotCommands(consoleInput);
                    string result = robot.Execute(cmd);

                    if (string.Equals(cmd.Name, "REPORT", StringComparison.OrdinalIgnoreCase))
                    WriteToConsole(result);

                } while (!String.Equals(cmd.Name, "Exit", StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                WriteToConsole(ex.Message);
            }
        }

        public static void WriteToConsole(string message = "")
        {
            if (message.Length > 0)
            {
                Console.WriteLine(message);
            }
        }

        public static string ReadFromConsole(string promptMessage = "")
        {
            Console.Write(_readPrompt + promptMessage);
            return Console.ReadLine();
        }
    }
}
