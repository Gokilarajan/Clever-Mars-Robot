using System;
using Rover.Common;
namespace Rover.AtEarth
{
    public interface IMarsRoverController
    {
        IPosition CurrentRoverPosition { get; }
        void InitiallizeRover(IPosition roverPosition);
        void NavigateRover(string navigators);
    }
}
