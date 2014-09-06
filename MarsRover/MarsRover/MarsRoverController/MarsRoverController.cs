using Rover.AtMars;
using Rover.Common;
using System;
namespace Rover.AtEarth
{
    public class MarsRoverController : IMarsRoverController
    {
        private IMarsRover _roverinAction;
        private IPlateau _plateau;
        public MarsRoverController(IPlateau plateau)
        {
            if (plateau == null)
                throw new ArgumentNullException("plateau", "Plateau is a required parameter and it cannot be null");
            _plateau = plateau;
        }
        public void InitiallizeRover(IPosition roverPosition)
        {
            _roverinAction = new MarsRover(roverPosition, _plateau,new InitialState());
        }
        public void NavigateRover(string navigators)
        {
            if (_roverinAction != null && !string.IsNullOrEmpty(navigators))
                _roverinAction.Navigate(navigators.ToCharArray());
        }
        public IPosition CurrentRoverPosition
        {
            get { return _roverinAction.CurrentPosition; }
        }
    }
}