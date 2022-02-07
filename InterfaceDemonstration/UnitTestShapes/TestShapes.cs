using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace UnitTestShapes
{
    [TestClass]
    public class TestShapes
    {
        

        [TestInitialize]
        public void Initialise()
        {

        }

        [TestMethod]
        public void TestSquare()
        {
            sq = new Square(10);

            Assert.AreEqual(40, sq.Perimeter());
            Assert.AreEqual(100, sq.Area());
            Assert.AreEqual(4, sq.Sides);

            Assert.AreEqual("A square of side length 10", sq.ToString());
        }

        [TestMethod]
        public void TestCircle()
        {
            ci = new Circle(10);

            Assert.AreEqual(62.831, ci.Perimeter(), 0.001);
            Assert.AreEqual(314.159, ci.Area(), 0.001);
            Assert.AreEqual(1, ci.Sides);

            Assert.AreEqual("A circle of radius 10", ci.ToString());
        }

        [TestMethod]
        public void TestCompare()
        {
            Assert.AreEqual(-1, sq.CompareTo(ci));
        }

    }
}
