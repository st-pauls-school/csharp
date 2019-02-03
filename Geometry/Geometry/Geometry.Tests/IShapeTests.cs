using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry.Lib;

namespace Geometry.Tests
{
    [TestClass]
    public class IShapeTests
    {
        [TestInitialize]
        public void DoThisFirst()
        {

        }

        [TestCleanup]
        public void DoThisLast()
        {
        }

        [TestMethod]
        public void TestMethod1()
        {
            IShape triangle = new Triangle(3.0d, 4.0d, 5.0d);
            Assert.AreEqual(12.0d, triangle.Perimeter());
            Assert.AreEqual(6.0d, triangle.Area());
            Assert.AreEqual(3, triangle.Sides);
        }
    }
}
