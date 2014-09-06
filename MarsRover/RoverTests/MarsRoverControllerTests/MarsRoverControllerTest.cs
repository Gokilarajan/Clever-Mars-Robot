using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rover.AtEarth;
using Rover.Common;
using Rover.AtMars;
using System;
namespace MarsRoverTests
{
    /// <summary>
    ///This is a test class for MarsRoverControllerTest and is intended
    ///to contain all MarsRoverControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MarsRoverControllerTest
    {
        private TestContext testContextInstance;
        private Coordinate _plateauUpperRightCoordinate, _plateauLowerLeftCoordinate;

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
            _plateauUpperRightCoordinate = Coordinate.CreateNew(5, 5);
            _plateauLowerLeftCoordinate = Coordinate.CreateNew(0, 0);
        }

        private MarsRoverController CreateTarget()
        {
            return new MarsRoverController(Plateau.CreateNew(_plateauUpperRightCoordinate, _plateauLowerLeftCoordinate));
        }

        /// <summary>
        ///A test for InitiallizeRover
        ///</summary>
        [TestMethod()]
        public void MarsRoverController_InitiallizeRover_PassRoverPosition_ExpectRoverInitiallized()
        {
            //Arrange
            IMarsRoverController target = CreateTarget();
            PrivateObject marsRoverController = new PrivateObject(target);
            IPosition roverPosition = new Position();
            //Act
            target.InitiallizeRover(roverPosition);
            //Assert
            Assert.IsNotNull(marsRoverController.GetField("_roverinAction").ToString());
        }

        /// <summary>
        ///A test for CurrentRoverPostion
        ///</summary>
        [TestMethod()]
        public void MarsRoverController_CurrentRoverPostion_PassRoverPosition_ExpectSameAsCurrentPosition()
        {
            //Arrange
            IMarsRoverController target = CreateTarget();
            IPosition expected = Position.CreateNew(3,3,Enum_Direction.Direction_W);
            target.InitiallizeRover(expected);
            //Act
            IPosition actual = target.CurrentRoverPosition;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The below tests confirms the program is solving the problem stated
        /// The Plateau Upper Right Coordinate is set as 5,5
        /// The Plateay Lower Left Coordinate is set as 0,0
        /// </summary>
        [TestMethod()]
        public void MarsRoverController_NavigateRover_Pass12N_LMLMLMLMM_Expect13N()
        {
            //Arrange
            IMarsRoverController target = CreateTarget();
            IPosition roverPosition = Position.CreateNew(1, 2, Enum_Direction.Direction_N);
            target.InitiallizeRover(roverPosition);
            //Act
            target.NavigateRover("LMLMLMLMM");
            //Assert
            Assert.AreEqual<string>("1 3 N", target.CurrentRoverPosition.ToString());
        }

        /// <summary>
        /// The below tests confirms the program is solving the problem stated
        /// The Plateau Upper Right Coordinate is set as 5,5
        /// The Plateay Lower Left Coordinate is set as 0,0
        /// </summary>
        [TestMethod()]
        public void MarsRoverController_NavigateRover_Pass33E_MMRMMRMRRM_Expect51E()
        {
            //Arrange
            IMarsRoverController target = CreateTarget();
            IPosition roverPosition = Position.CreateNew(3, 3, Enum_Direction.Direction_E);
            target.InitiallizeRover(roverPosition);
            //Act
            target.NavigateRover("MMRMMRMRRM");
            //Assert
            Assert.AreEqual<string>("5 1 E", target.CurrentRoverPosition.ToString());
        }

        /// <summary>
        /// The below tests confirms the program is solving the problem stated
        /// The Plateau Upper Right Coordinate is set as 5,5
        /// The Plateay Lower Left Coordinate is set as 0,0
        /// </summary>
        [TestMethod()]
        public void MarsRoverController_NavigateRover_Pass55S_LLLMRMRMLLLRRR_Expect55E()
        {
            //Arrange
            IMarsRoverController target = CreateTarget();
            IPosition roverPosition = Position.CreateNew(5, 5, Enum_Direction.Direction_S);
            target.InitiallizeRover(roverPosition);
            //Act
            target.NavigateRover("LLLMRMRMLLLRRR");
            //Assert
            Assert.AreEqual<string>("5 5 E", target.CurrentRoverPosition.ToString());
        }

        /// <summary>
        /// The below tests confirms the program is solving the problem stated
        /// The Plateau Upper Right Coordinate is set as 5,5
        /// The Plateay Lower Left Coordinate is set as 0,0
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MarsRoverController_NavigateRover_Pass66S_LRM_ExpectException()
        {
            //Arrange
            IMarsRoverController target = CreateTarget();
            IPosition roverPosition = Position.CreateNew(6,6, Enum_Direction.Direction_S);
            target.InitiallizeRover(roverPosition);
            //Act
            target.NavigateRover("LRM");
            //Assert - Expected Exception
        }

        /// <summary>
        /// The below tests confirms the program is solving the problem stated
        /// The Plateau Upper Right Coordinate is set as 5,5
        /// The Plateay Lower Left Coordinate is set as 0,0
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MarsRoverController_NavigateRover_PassMinus11N_LRM_ExpectException()
        {
            //Arrange
            IMarsRoverController target = CreateTarget();
            IPosition roverPosition = Position.CreateNew(-1, -1, Enum_Direction.Direction_N);
            target.InitiallizeRover(roverPosition);
            //Act
            target.NavigateRover("LRM");
            //Assert - Expected Exception
        }

        /// <summary>
        /// The below tests confirms the program is solving the problem stated
        /// The Plateau Upper Right Coordinate is set as 5,5
        /// The Plateay Lower Left Coordinate is set as 0,0
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void MarsRoverController_NavigateRover_Pass55Error_LRM_ExpectException()
        {
            //Arrange
            IMarsRoverController target = CreateTarget();
            IPosition roverPosition = Position.CreateNew(5, 5, Enum_Direction.Direction_Error);
            target.InitiallizeRover(roverPosition);
            //Act
            target.NavigateRover("LRM");
            //Assert - Expected Exception
        }

        /// <summary>
        /// The below tests confirms the program is solving the problem stated
        /// The Plateau Upper Right Coordinate is set as 5,5
        /// The Plateay Lower Left Coordinate is set as 0,0
        /// </summary>
        [TestMethod()]
        public void MarsRoverController_NavigateRover_Pass30W_RMLLMRR_Expect30N()
        {
            //Arrange
            IMarsRoverController target = CreateTarget();
            IPosition roverPosition = Position.CreateNew(3, 0, Enum_Direction.Direction_W);
            target.InitiallizeRover(roverPosition);
            //Act
            target.NavigateRover("RMLLMRR");
            //Assert
            Assert.AreEqual<string>("3 0 N", target.CurrentRoverPosition.ToString());
        }

        /// <summary>
        /// The below tests confirms the program is solving the problem stated
        /// The Plateau Upper Right Coordinate is set as 5,5
        /// The Plateay Lower Left Coordinate is set as 0,0
        /// </summary>
        [TestMethod()]
        public void MarsRoverController_NavigateRover_Pass00S_MMMMMLMMM_Expect30E()
        {
            //Arrange
            IMarsRoverController target = CreateTarget();
            IPosition roverPosition = Position.CreateNew(0, 0, Enum_Direction.Direction_S);
            target.InitiallizeRover(roverPosition);
            //Act
            target.NavigateRover("MMMMMLMMM");
            //Assert
            Assert.AreEqual<string>("3 0 E", target.CurrentRoverPosition.ToString());
        }

        /// <summary>
        /// The below tests confirms the program is solving the problem stated
        /// The Plateau Upper Right Coordinate is set as 5,5
        /// The Plateay Lower Left Coordinate is set as 0,0
        /// </summary>
        [TestMethod()]
        public void MarsRoverController_NavigateRover_Pass50E_MMMMMLMMM_Expect53N()
        {
            //Arrange
            IMarsRoverController target = CreateTarget();
            IPosition roverPosition = Position.CreateNew(5, 0, Enum_Direction.Direction_E);
            target.InitiallizeRover(roverPosition);
            //Act
            target.NavigateRover("MMMMMLMMM");
            //Assert
            Assert.AreEqual<string>("5 3 N", target.CurrentRoverPosition.ToString());
        }

        /// <summary>
        /// The below tests confirms the program is solving the problem stated
        /// The Plateau Upper Right Coordinate is set as 5,5
        /// The Plateay Lower Left Coordinate is set as 0,0
        /// </summary>
        [TestMethod()]
        public void MarsRoverController_NavigateRover_Pass50E_MMMMMLMMMMMMRMMMMMLLM_Expect45W()
        {
            //Arrange
            IMarsRoverController target = CreateTarget();
            IPosition roverPosition = Position.CreateNew(5, 0, Enum_Direction.Direction_E);
            target.InitiallizeRover(roverPosition);
            //Act
            target.NavigateRover("MMMMMLMMMMMMRMMMMMLLM");
            //Assert
            Assert.AreEqual<string>("4 5 W", target.CurrentRoverPosition.ToString());
        }
    }
}