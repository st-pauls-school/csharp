using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace UnitTestShapes
{
    [TestClass]
    public class TestShapes
    {
        [TestMethod]
        public void TestSquare()
        {
            IShape  s = new Square(10);

            Assert.AreEqual(40, s.Perimeter());
            Assert.AreEqual(100, s.Area());
            Assert.AreEqual(4, s.Sides);
        }

        [TestMethod]
        public void TestCircle()
        {
            IShape s = new Circle(10);

            Assert.AreEqual(62.831, s.Perimeter(), 0.001);
            Assert.AreEqual(314.159, s.Area(), 0.001);
            Assert.AreEqual(1, s.Sides);
        }
    }
}
