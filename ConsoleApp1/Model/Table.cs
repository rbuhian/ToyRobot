namespace ToyRobot.Model
{
    public class Table
    {
        private int _rowCount;
        private int _columnCount;

        public Table (int rowCount, int columnCount)
        {
            _rowCount = rowCount;
            _columnCount = columnCount;
        }

        public int RowCount { 
            get => _rowCount;
            set => _rowCount = value;
        }

        public int ColumnCount 
        { 
            get => _columnCount; 
            set => _columnCount = value; 
        }

        public bool IsPositionValid(int x, int y)
        {
            return (XValueIsValid(x) && YValueIsValid(y));
        }

        private bool XValueIsValid(int x)
        {
            return (x >= 0 && x < _columnCount);
        }

        private bool YValueIsValid (int y)
        {
            return (y >= 0 && y < _rowCount);
        }
    }
}
