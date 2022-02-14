using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ToyRobot.Helper
{
    public class RobotCommands
    {
        public RobotCommands(string input)
        {
            char[] delimiters = new[] { ',', ' ' };  // List of your delimiters
            var stringArray = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            _arguments = new List<string>();
            for (int i = 0; i < stringArray.Length; i++)
            {
                // The first element is always the command:
                if (i == 0)
                {
                    this.Name = stringArray[i];
                }
                else
                {
                    var inputArgument = stringArray[i];

                    // Assume that most of the time, the input argument is NOT quoted text:
                    string argument = inputArgument;

                    // Is the argument a quoted text string?
                    var regex = new Regex("\"(.*?)\"", RegexOptions.Singleline);
                    var match = regex.Match(inputArgument);

                    // If it iS quoted, there will be at least one capture:
                    if (match.Captures.Count > 0)
                    {
                        // Get the unquoted text from within the qoutes:
                        var captureQuotedText = new Regex("[^\"]*[^\"]");
                        var quoted = captureQuotedText.Match(match.Captures[0].Value);

                        // The argument should include all text from between the quotes as a single string:
                        argument = quoted.Captures[0].Value;
                    }
                    _arguments.Add(argument);
                }
            }
        }

        public string Name { get; set; }
        public string LibraryClassName { get; set; }

        private List<string> _arguments;
        public IEnumerable<string> Arguments
        {
            get
            {
                return _arguments;
            }
        }

    }
}
