﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rover.AtMars;
using Rover.Common; 
namespace MarsRoverTests
{
    /// <summary>
    ///This is a test class for WestPointingStateTest and is intended
    ///to contain all WestPointingStateTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WestPointingStateTest
    {
        private TestContext testContextInstance;
        private MarsRover _roverInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestInitialize]
        public void TestInitiallize()
        {
            Coordinate upperRight = Coordinate.CreateNew(5,5);
            Coordinate lowerLeft = Coordinate.CreateNew(0,0);
            IPlateau _plateauInstance = Plateau.CreateNew(upperRight, lowerLeft);
            RoverState _initialState = new InitialState();
            IPosition _roverWestPosition = Position.CreateNew(1, 2, Enum_Direction.Direction_W);
            _roverInstance = new MarsRover(_roverWestPosition, _plateauInstance, _initialState);
        }

        private RoverState CreateTarget()
        {
            return new WestPointingState();
        }

        /// <summary>
        ///A test for Handle method to do Left Navigation
        ///</summary>
        [TestMethod()]
        public void WestPointingState_Handle_NavigationLeft_ExpectSouth()
        {
            //Arrange
            PrivateObject _marsRover = new PrivateObject(_roverInstance);
            _marsRover.SetField("_currentNavigator", 'L');
            RoverState target = CreateTarget();
            //Act
            target.Handle(_roverInstance);
            //Assert
            Assert.AreEqual<Enum_Direction>(Enum_Direction.Direction_S, _roverInstance.CurrentPosition.Direction);
        }

        /// <summary>
        ///A test for Handle method to do Right Navigation
        ///</summary>
        [TestMethod()]
        public void WestPointingState_Handle_NavigationRight_ExpectNorth()
        {
            //Arrange
            PrivateObject _marsRover = new PrivateObject(_roverInstance);
            _marsRover.SetField("_currentNavigator", 'R');
            RoverState target = CreateTarget();
            //Act
            target.Handle(_roverInstance);
            //Assert
            Assert.AreEqual<Enum_Direction>(Enum_Direction.Direction_N, _roverInstance.CurrentPosition.Direction);
        }

        /// <summary>
        ///A test for Handle method to do Move Navigation
        ///</summary>
        [TestMethod()]
        public void WestPointingState_Handle_NavigationMove_ExpectDecrementinXaxis()
        {
            //Arrange
            PrivateObject _marsRover = new PrivateObject(_roverInstance);
            _marsRover.SetField("_currentNavigator", 'M');
            RoverState target = CreateTarget();
            //Act
            target.Handle(_roverInstance);
            //Assert
            Assert.AreEqual<int>(0, _roverInstance.CurrentPosition.Xaxis);
        }
    }
}