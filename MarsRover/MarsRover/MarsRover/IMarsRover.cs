using System;
using Rover.Common;
namespace Rover.AtMars
{
    public interface IMarsRover
    {
        char CurrentNavigator { get; }
        IPosition CurrentPosition { get; }
        void Navigate(char[] navigators);
        void SetCurrentState(RoverState roverState);
        void UpdateCoordinate(int x, int y);
        void UpdateDirection(Enum_Direction direction);
    }
}
