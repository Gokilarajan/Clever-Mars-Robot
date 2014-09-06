using Rover.AtMars;
using Rover.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MarsRoverTests
{
    /// <summary>
    ///This is a test class for SouthPointingStateTest and is intended
    ///to contain all SouthPointingStateTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SouthPointingStateTest
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
            Coordinate upperRight = Coordinate.CreateNew(5, 5);
            Coordinate lowerLeft = Coordinate.CreateNew(0, 0);
            IPlateau _plateauInstance = Plateau.CreateNew(upperRight, lowerLeft);
            RoverState _initialState = new InitialState();
            IPosition _roverWestPosition = Position.CreateNew(1, 2, Enum_Direction.Direction_S);
            _roverInstance = new MarsRover(_roverWestPosition, _plateauInstance, _initialState);
        }

        private RoverState CreateTarget()
        {
            return new SouthPointingState();
        }

        /// <summary>
        ///A test for Handle method to do Left Navigation
        ///</summary>
        [TestMethod()]
        public void SouthPointingState_Handle_NavigationLeft_ExpectEast()
        {
            //Arrange
            PrivateObject _marsRover = new PrivateObject(_roverInstance);
            _marsRover.SetField("_currentNavigator", 'L');
            RoverState target = CreateTarget();
            //Act
            target.Handle(_roverInstance);
            //Assert
            Assert.AreEqual<Enum_Direction>(Enum_Direction.Direction_E, _roverInstance.CurrentPosition.Direction);
        }

        /// <summary>
        ///A test for Handle method to do Right Navigation
        ///</summary>
        [TestMethod()]
        public void SouthPointingState_Handle_NavigationRight_ExpectWest()
        {
            //Arrange
            PrivateObject _marsRover = new PrivateObject(_roverInstance);
            _marsRover.SetField("_currentNavigator", 'R');
            RoverState target = CreateTarget();
            //Act
            target.Handle(_roverInstance);
            //Assert
            Assert.AreEqual<Enum_Direction>(Enum_Direction.Direction_W, _roverInstance.CurrentPosition.Direction);
        }

        /// <summary>
        ///A test for Handle method for Move Navigation
        ///</summary>
        [TestMethod()]
        public void SouthPointingState_Handle_NavigationMove_ExpectDecrementinYaxis()
        {
            //Arrange
            PrivateObject _marsRover = new PrivateObject(_roverInstance);
            _marsRover.SetField("_currentNavigator", 'M');
            RoverState target = CreateTarget();
            //Act
            target.Handle(_roverInstance);
            //Assert
            Assert.AreEqual<int>(1, _roverInstance.CurrentPosition.Xaxis);
        }
    }
}