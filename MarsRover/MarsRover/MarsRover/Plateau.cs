using Rover.Common;
namespace Rover.AtMars
{
    public class Plateau : IPlateau
    {
        private Coordinate _upperRight;
        private Coordinate _lowerLeft;
        private Plateau(Coordinate upperRight, Coordinate lowerLeft)
        {
            _upperRight = upperRight;
            _lowerLeft = lowerLeft;
        }
        public bool ValidCoordinate(Coordinate plateauCoordinate)
        {
            if (_lowerLeft.Xaxis <= plateauCoordinate.Xaxis && plateauCoordinate.Xaxis <= _upperRight.Xaxis && _lowerLeft.Yaxis <= plateauCoordinate.Yaxis && plateauCoordinate.Yaxis <= _upperRight.Yaxis)
            {
                return true;
            }
            return false;
        }

        public static Plateau CreateNew(Coordinate upperRight,Coordinate lowerLeft)
        {
            return new Plateau(upperRight, lowerLeft);
        }
    }
}
