using System;
using System.Collections.Generic;
using System.Linq;
using ToyRobot.Helper;

namespace ToyRobot.Model
{
    public class Robot
    {
        private Table _table;
        private Location _location;
        private int _direction;
        private Dictionary<string, Func<string[], string>> commandMap;
        public Robot()
        {
            commandMap = 
                new Dictionary<string, Func<string[], string>>(StringComparer.InvariantCultureIgnoreCase)
            {
                [nameof(Place)] = Place,
                [nameof(Move)] = Move,
                [nameof(Left)] = Left,
                [nameof(Right)] = Right,
                [nameof(Report)] = Report,
                [nameof(Exit)] = Exit
            };
        }

        public Table CurrentTable
        {
            get => _table;
        }

        public void InitTable(int columnCount, int rowCount)
        {
            if (columnCount < 0 || rowCount < 0) throw new Exception("Invalid table size.");
            _table = new Table(columnCount-1 , rowCount-1);
            _location = null;
        }

        private bool IsTableInitialized()
        {
            return (_table != null);
        }

        public string Execute(RobotCommands command)
        {
            if (!commandMap.ContainsKey(command.Name))
                return string.Format(OutputFormatting.Indent(2) + "Invalid command.");

            return commandMap[command.Name](command.Arguments.ToArray());
        }
        private string Place(string[] args)
        {
            string returnMessage = string.Empty;

            try
            {
                if (!IsTableInitialized())
                    return string.Format(OutputFormatting.Indent(2) + "Table not yet initialized.");

                if (args.Length != 3)
                    return string.Format(OutputFormatting.Indent(2) + "Invalid Argument");

                if (!Int32.TryParse(args[0], out int xPosition))
                    return string.Format(OutputFormatting.Indent(2) + "Invalid column position argument");

                if (!Int32.TryParse(args[1], out int yPosition))
                    return string.Format(OutputFormatting.Indent(2) + "Invalid row position argument");

                if (!Enum.GetNames(typeof(Direction)).Any(x => x.ToLower() == args[2].ToLower()))
                    return string.Format(OutputFormatting.Indent(2) + "Invalid direction");

                if (!_table.IsPositionValid(xPosition, yPosition))
                    return string.Format(OutputFormatting.Indent(2) + "Invalid location");

                _location = new Location(xPosition, yPosition);
                _direction = GetDiretionValue(args[2]);
            }
            catch (Exception)
            {
                string message = string.Format("Invalid Argument");
                throw new ArgumentException(message);
            }

            return ShowRobotLocationAndDirection();
        }

        private string ShowRobotLocationAndDirection()
        {
            return string.Format(OutputFormatting.Indent(2) +
                "{0}, {1}, {2}", 
                _location.XCoordinate, _location.YCoordinate, 
                Enum.GetName(typeof(Direction), _direction));
        }

        private static int GetDiretionValue(string direction)
        {
            return (int)Enum.Parse(typeof(Direction), direction, true);
        }

        private string Move(string[] args)
        {
            if (!IsTableInitialized())
                return string.Format(OutputFormatting.Indent(2) + "Table not yet initialized.");

            if (_location == null)
                return string.Format(OutputFormatting.Indent(2) + "Robot is not yet on the table.");

            switch (_direction)
            {
                case (int)Direction.NORTH:
                    MoveNorth();
                    break;
                case (int)Direction.EAST:
                    MoveEast();
                    break;
                case (int)Direction.SOUTH:
                    MoveSouth();
                    break;
                case (int)Direction.WEST:
                    MoveWest();
                    break;
            }
            return ShowRobotLocationAndDirection();
        }

        private void MoveWest()
        {
            if (_location.XCoordinate > 0)
                _location.XCoordinate--;
        }

        private void MoveSouth()
        {
            if (_location.YCoordinate > 0)
                _location.YCoordinate--;
        }

        private void MoveEast()
        {
            if (_location.XCoordinate != _table.ColumnCount)
                _location.XCoordinate++;
        }

        private void MoveNorth()
        {
            if (_location.YCoordinate != _table.RowCount)
                _location.YCoordinate++;
        }

        private string Left(string[] args)
        {
            if (!IsTableInitialized())
                return string.Format(OutputFormatting.Indent(2) + "Table not yet initialized.");

            if (_location == null)
                return string.Format(OutputFormatting.Indent(2) + "Robot is not yet on the table.");

            _direction = (_direction == (int)Direction.NORTH ? (int)Direction.WEST : _direction - 1);

            return ShowRobotLocationAndDirection();
        }
        private string Right(string[] args)
        {
            if (!IsTableInitialized())
                return string.Format(OutputFormatting.Indent(2) + "Table not yet initialized.");

            if (_location == null)
                return string.Format(OutputFormatting.Indent(2) + "Robot is not yet on the table.");

            _direction = (_direction == (int)Direction.WEST ? (int)Direction.NORTH : _direction + 1);

            return ShowRobotLocationAndDirection();
        }
        private string Report(string[] args)
        {
            return ShowRobotLocationAndDirection();
        }
        private string Exit(string[] args)
        {
            return "Exit";
        }
    }
}
