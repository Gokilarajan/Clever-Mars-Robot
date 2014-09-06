using Rover.Common;
using System;
namespace Rover.AtMars
{
    public class MarsRover : IMarsRover
    {
        private IPosition _roverPosition;
        private IPlateau _roverPlateau;
        private RoverState _currentState;
        private char _currentNavigator;

        public MarsRover(IPosition roverPosition, IPlateau roverPlateau, RoverState currentState)
        {
            if (roverPlateau == null)
            {
                throw new ArgumentNullException("roverPlateau", "Rover Plateau is a required parameter and it cannot be null");
            }
            if (currentState == null)
            {
                throw new ArgumentNullException("currentState", "Current State is a required parameter and it cannot be null");
            }
            _roverPlateau = roverPlateau;
            if(!_roverPlateau.ValidCoordinate(Coordinate.CreateNew(roverPosition.Xaxis,roverPosition.Yaxis)))
            {
                throw new ArgumentOutOfRangeException("roverPosition", "Rover coordinates are out of the range");
            }
            if (roverPosition.Direction == Enum_Direction.Direction_Error)
            {
                throw new ArgumentException("roverPosition", "Rover is set to error direction");
            }
            _roverPosition = roverPosition;
            _currentState = currentState;
        }

        public char CurrentNavigator {  get { return _currentNavigator; } }

        public IPosition CurrentPosition { get { return _roverPosition; } }

        public void Navigate(char[] navigators)
        {
            foreach (var navigator in navigators)
            {
                _currentNavigator = navigator;
                _currentState.Handle(this);
            }
        }

        public void SetCurrentState(RoverState roverState)
        {
            _currentState = roverState;
        }

        public void UpdateDirection(Enum_Direction direction)
        {
            if (direction != Enum_Direction.Direction_Error)
                _roverPosition.UpdateDirection(direction);
        }

        public void UpdateCoordinate(int x, int y)
        {
            Coordinate coordinate = Coordinate.CreateNew(x, y);
            if (_roverPlateau.ValidCoordinate(coordinate))
            {
                _roverPosition.UpdateCoordinate(x, y);
            }
        }
    }
}