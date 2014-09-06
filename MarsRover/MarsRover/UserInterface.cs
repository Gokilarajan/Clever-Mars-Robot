using Rover.AtEarth;
using Rover.AtMars;
using Rover.Common;
using System;
namespace Rover.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var upperRightCoordinateInput = Console.ReadLine().Split(' ');
            Coordinate upperRightCoordinate = Coordinate.CreateNew(int.Parse(upperRightCoordinateInput[0]), int.Parse(upperRightCoordinateInput[1]));
            Coordinate lowerLeftCoordinate = Coordinate.CreateNew(0, 0);

            IMarsRoverController roverController = new MarsRoverController(Plateau.CreateNew(upperRightCoordinate,lowerLeftCoordinate));
            
            string navigatorsInput;
            IPosition roverPosition;
            var roverInitialPositionInput = Console.ReadLine().Split(' ');
            while (roverInitialPositionInput.Length > 0 && !string.IsNullOrEmpty(roverInitialPositionInput[0]))
            {
                roverPosition = Position.CreateNew(int.Parse(roverInitialPositionInput[0]), int.Parse(roverInitialPositionInput[1]), GetEnumDirection(roverInitialPositionInput[2]));
                roverController.InitiallizeRover(roverPosition);

                navigatorsInput = Console.ReadLine();
                roverController.NavigateRover(navigatorsInput);

                Console.WriteLine(roverController.CurrentRoverPosition.ToString());

                roverInitialPositionInput = Console.ReadLine().Split(' ');
            }
        }

        private static Enum_Direction GetEnumDirection(string value)
        {
            if (value.Equals("N"))
                return Enum_Direction.Direction_N;
            else if (value.Equals("S"))
                return Enum_Direction.Direction_S;
            else if (value.Equals("E"))
                return Enum_Direction.Direction_E;
            else if (value.Equals("W"))
                return Enum_Direction.Direction_W;
            else
                return Enum_Direction.Direction_Error;
        }
    }
}