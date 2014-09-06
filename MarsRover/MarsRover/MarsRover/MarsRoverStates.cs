using Rover.Common;
namespace Rover.AtMars
{
    public abstract class RoverState
    {
        private static RoverState _northPointing, _southPointing, _eastPointing, _westPointing;
        public abstract void Handle(IMarsRover marsRover);
        public RoverState NorthPointing
        {
            get
            {
                if (_northPointing == null)
                {
                    _northPointing = new NorthPointingState();
                }
                return _northPointing;
            }
        }
        public RoverState SouthPointing
        {
            get
            {
                if (_southPointing == null)
                {
                    _southPointing = new SouthPointingState();
                }
                return _southPointing;
            }
        }
        public RoverState WestPointing
        {
            get
            {
                if (_westPointing == null)
                {
                    _westPointing = new WestPointingState();
                }
                return _westPointing;
            }
        }
        public RoverState EastPointing
        {
            get
            {
                if (_eastPointing == null)
                {
                    _eastPointing = new EastPointingState();
                }
                return _eastPointing;
            }
        }
    }

    public class InitialState : RoverState
    {
        public override void Handle(IMarsRover marsRover)
        {
            RoverState currentState = null;
            if (marsRover.CurrentPosition.Direction == Enum_Direction.Direction_N)
            {
                currentState = NorthPointing;
            }
            else if (marsRover.CurrentPosition.Direction == Enum_Direction.Direction_S)
            {
                currentState = SouthPointing;
            }
            else if (marsRover.CurrentPosition.Direction == Enum_Direction.Direction_E)
            {
                currentState = EastPointing;
            }
            else if (marsRover.CurrentPosition.Direction == Enum_Direction.Direction_W)
            {
                currentState = WestPointing;
            }
            marsRover.SetCurrentState(currentState);
            currentState.Handle(marsRover);
        }
    }

    public class NorthPointingState : RoverState
    {
        public override void Handle(IMarsRover marsRover)
        {
            if (marsRover.CurrentNavigator.Equals('L'))
            {
                marsRover.UpdateDirection(Enum_Direction.Direction_W);
                marsRover.SetCurrentState(WestPointing);
            }
            else if (marsRover.CurrentNavigator.Equals('R'))
            {
                marsRover.UpdateDirection(Enum_Direction.Direction_E);
                marsRover.SetCurrentState(EastPointing);
            }
            else if (marsRover.CurrentNavigator.Equals('M'))
            {
                marsRover.UpdateCoordinate(marsRover.CurrentPosition.Xaxis, marsRover.CurrentPosition.Yaxis + 1);
            }
        }
    }

    public class WestPointingState : RoverState
    {
        public override void Handle(IMarsRover marsRover)
        {
            if (marsRover.CurrentNavigator.Equals('L'))
            {
                marsRover.UpdateDirection(Enum_Direction.Direction_S);
                marsRover.SetCurrentState(SouthPointing);
            }
            else if (marsRover.CurrentNavigator.Equals('R'))
            {
                marsRover.UpdateDirection(Enum_Direction.Direction_N);
                marsRover.SetCurrentState(NorthPointing);
            }
            else if (marsRover.CurrentNavigator.Equals('M'))
            {
                marsRover.UpdateCoordinate(marsRover.CurrentPosition.Xaxis - 1, marsRover.CurrentPosition.Yaxis);
            }
        }
    }

    public class EastPointingState : RoverState
    {
        public override void Handle(IMarsRover marsRover)
        {
            if (marsRover.CurrentNavigator.Equals('L'))
            {
                marsRover.UpdateDirection(Enum_Direction.Direction_N);
                marsRover.SetCurrentState(NorthPointing);
            }
            else if (marsRover.CurrentNavigator.Equals('R'))
            {
                marsRover.UpdateDirection(Enum_Direction.Direction_S);
                marsRover.SetCurrentState(SouthPointing);
            }
            else if (marsRover.CurrentNavigator.Equals('M'))
            {
                marsRover.UpdateCoordinate(marsRover.CurrentPosition.Xaxis + 1, marsRover.CurrentPosition.Yaxis);
            }
        }
    }

    public class SouthPointingState : RoverState
    {
        public override void Handle(IMarsRover marsRover)
        {
            if (marsRover.CurrentNavigator.Equals('L'))
            {
                marsRover.UpdateDirection(Enum_Direction.Direction_E);
                marsRover.SetCurrentState(EastPointing);
            }
            else if (marsRover.CurrentNavigator.Equals('R'))
            {
                marsRover.UpdateDirection(Enum_Direction.Direction_W);
                marsRover.SetCurrentState(WestPointing);
            }
            else if (marsRover.CurrentNavigator.Equals('M'))
            {
                marsRover.UpdateCoordinate(marsRover.CurrentPosition.Xaxis, marsRover.CurrentPosition.Yaxis - 1);
            }
        }
    }
}