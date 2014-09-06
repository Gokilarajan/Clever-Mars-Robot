using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rover.AtMars;
using Rover.Common;

namespace MarsRoverTests
{
    /// <summary>
    ///This is a test class for MarsRoverTest and is intended
    ///to contain all MarsRoverTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MarsRoverTest
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

        [TestInitialize]
        public void TestInitiallize()
        {
            Coordinate upperRight = Coordinate.CreateNew(5, 5);
            Coordinate lowerLeft = Coordinate.CreateNew(0, 0);
            IPlateau _plateauInstance = Plateau.CreateNew(upperRight, lowerLeft);
            RoverState _initialState = new InitialState();
            IPosition _roverWestPosition = Position.CreateNew(1, 2, Enum_Direction.Direction_E);
            _roverInstance = new MarsRover(_roverWestPosition, _plateauInstance, _initialState);
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

        /// <summary>
        ///A test for UpdateRoverLocation
        ///</summary>
        [TestMethod()]
        public void MarsRover_UpdateRoverDirection_UpdateWest_ExpectWest()
        {
            //Arrange - From Test Initiallize

            //Act
            _roverInstance.UpdateDirection(Enum_Direction.Direction_W);
            //Assert
            Assert.AreEqual<Enum_Direction>(Enum_Direction.Direction_W, _roverInstance.CurrentPosition.Direction);
        }

        /// <summary>
        ///A test for UpdateRoverCoordinate
        ///</summary>
        [TestMethod()]
        public void MarsRover_UpdateRoverCoordinate_UpdateNewValue_ExpectSameNewValue()
        {
            //Arrange - From Test Initiallize

            //Act
            _roverInstance.UpdateCoordinate(4, 3);
            //Assert
            Assert.AreEqual<int>(_roverInstance.CurrentPosition.Xaxis, 4);
            Assert.AreEqual<int>(_roverInstance.CurrentPosition.Yaxis, 3);
        }

        /// <summary>
        ///A test for SetCurrentState
        ///</summary>
        [TestMethod()]
        public void MarsRover_SetCurrentState_UpdateNewState_ExpectSameNewState()
        {
            //Arrange
            RoverState roverState = new WestPointingState();
            PrivateObject marsRover = new PrivateObject(_roverInstance);
            //Act
            _roverInstance.SetCurrentState(roverState);
            //Assert
            Assert.AreEqual<RoverState>(roverState, (RoverState) marsRover.GetField("_currentState"));
        }
    }
}