using Rover.AtMars;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rover.Common;
 
namespace MarsRoverTests
{
    /// <summary>
    ///This is a test class for PlateauTest and is intended
    ///to contain all PlateauTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PlateauTest
    {
        private TestContext testContextInstance;

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


        /// <summary>
        ///A positive test for ValidCoordinate
        ///</summary>
        [TestMethod()]
        public void Plateau_ValidCoordinate_InRangeCoordinate_ExpectTrue()
        {
            //Arrange
            Coordinate upperRight = Coordinate.CreateNew(5, 5);
            Coordinate lowerLeft =Coordinate.CreateNew(0,0);
            IPlateau target = Plateau.CreateNew(upperRight, lowerLeft);
            Coordinate plateauCoordinate =Coordinate.CreateNew(3,3);
            bool expected = true;
            bool actual;
            //Act
            actual = target.ValidCoordinate(plateauCoordinate);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A negative test for ValidCoordinate
        ///</summary>
        [TestMethod()]
        public void Plateau_ValidCoordinate_OutofRangeCoordinate_ExpectFalse()
        {
            //Arrange
            Coordinate upperRight = Coordinate.CreateNew(5, 5);
            Coordinate lowerLeft = Coordinate.CreateNew(0, 0);
            IPlateau target = Plateau.CreateNew(upperRight, lowerLeft);
            Coordinate plateauCoordinate = Coordinate.CreateNew(6, 3);
            bool expected = false;
            bool actual;
            //Act
            actual = target.ValidCoordinate(plateauCoordinate);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A positive test for Plateau Constructor
        ///</summary>
        [TestMethod()]
        public void Plateau_Constructor_ProperInput_ExpectPropertyInitiallization()
        {
            //Arrange
            Coordinate upperRight = Coordinate.CreateNew(3,4);
            Coordinate lowerLeft = Coordinate.CreateNew(0,0);
            //Act
            IPlateau target = Plateau.CreateNew(upperRight, lowerLeft);
            //Assert
            Assert.AreEqual<int>(upperRight.Xaxis, 3);
            Assert.AreEqual<int>(upperRight.Yaxis, 4);
            Assert.AreEqual<int>(lowerLeft.Xaxis, 0);
            Assert.AreEqual<int>(lowerLeft.Yaxis, 0);
        }
    }
}