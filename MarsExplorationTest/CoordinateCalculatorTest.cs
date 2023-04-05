using Codecool.MarsExploration.Calculators.Model;
using Codecool.MarsExploration.Calculators.Service;

namespace MarsExplorationTest
{
    public class CoordinateCalculatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAdjacentCoordinatesShouldReturnCorrectCoordinates()
        {
            var uot = new CoordinateCalculator();
            var actual = uot.GetAdjacentCoordinates(new Coordinate(2, 2), 4);
            var expected = new List<Coordinate>
                { new Coordinate(1, 1), new Coordinate(1, 2), new Coordinate(1, 3), new Coordinate(2,1), new Coordinate(2, 3),new Coordinate(3, 1),new Coordinate( 3,2), new Coordinate(3, 3) };
            Assert.AreEqual(expected.Count, actual.Count());

            for (var i = 0; i < actual.Count(); i++)
            {
                Assert.AreEqual(expected.ToList()[i], actual.ToList()[i]);
            }
            
        }

        [Test]
        public void GetAdjacentCoordinatesShouldReturnCorrectCoordinatesWhenInputIsMargin()
        {
            var uot = new CoordinateCalculator();
            var actual = uot.GetAdjacentCoordinates(new Coordinate(0, 0), 4);
            var expected = new List<Coordinate>
                { new Coordinate(0, 1), new Coordinate(1, 0), new Coordinate(1, 1) };
            Assert.AreEqual(expected.Count, actual.Count());

            for (var i = 0; i < actual.Count(); i++)
            {
                Assert.AreEqual(expected.ToList()[i], actual.ToList()[i]);
            }

        }
    }
}