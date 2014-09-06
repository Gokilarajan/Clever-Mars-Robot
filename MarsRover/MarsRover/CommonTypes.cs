namespace Rover.Common
{
    public enum Enum_Direction
    {
        Direction_N,
        Direction_S,
        Direction_E,
        Direction_W,
        Direction_Error
    }
    
    public struct Coordinate
    {
        private int _x, _y;
        private Coordinate(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public int Xaxis
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Yaxis
        {
            get { return _y; }
            set { _y = value; }
        }
        public static Coordinate CreateNew(int x, int y)
        {
            return new Coordinate(x, y);
        }
    }

    public interface IPosition
    {
        Enum_Direction Direction { get; }
        string ToString();
        void UpdateCoordinate(int x, int y);
        void UpdateDirection(Enum_Direction direction);
        int Xaxis { get; }
        int Yaxis { get; }
    }

    public struct Position : IPosition
    {
        private Coordinate _coordinate;
        private Enum_Direction _direction;

        private Position(int x, int y, Enum_Direction direction)
        {
            _coordinate = Coordinate.CreateNew(x, y);
            _direction = direction;
        }

        public void UpdateCoordinate(int x, int y)
        {
            _coordinate.Xaxis = x;
            _coordinate.Yaxis = y;
        }

        public void UpdateDirection(Enum_Direction direction)
        {
            _direction = direction;
        }

        public int Xaxis
        {
            get { return _coordinate.Xaxis; }
        }

        public int Yaxis
        {
            get { return _coordinate.Yaxis; }
        }

        public Enum_Direction Direction
        {
            get { return _direction; }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", _coordinate.Xaxis, _coordinate.Yaxis, _direction.ToString().Split('_')[1]);
        }
        
        public static IPosition CreateNew(int x, int y, Enum_Direction direction)
        {
            return new Position(x,y, direction);
        }
    }
}