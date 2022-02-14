namespace ToyRobot.Model
{
    public class Location
    {
        private int _xCoordinate;
        private int _yCoordinate;

        public Location(int x, int y)
        {
            _xCoordinate = x;
            _yCoordinate = y;
        }

        public int XCoordinate { 
            get => _xCoordinate; 
            set => _xCoordinate = value; 
        }
        public int YCoordinate { 
            get => _yCoordinate; 
            set => _yCoordinate = value; 
        }
    }
}
