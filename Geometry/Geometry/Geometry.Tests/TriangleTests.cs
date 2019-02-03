using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry.Lib;
using System.Collections.Generic;

namespace Geometry.Tests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void TestValidity()
        {
            Triangle t = new Triangle(3, 5, 10);
            Assert.IsFalse(t.IsValid);

            Triangle ra = new Triangle(3, 4, 5);
            Assert.IsTrue(ra.IsRightAngled);
            Assert.IsTrue(ra.IsValid);
            CollectionAssert.Contains(3, ra.ThreeSides);
            CollectionAssert.Contains(4, ra.ThreeSides);
            CollectionAssert.Contains(5, ra.ThreeSides);

            Triangle eq = new Triangle(6, 6, 6);
            Assert.IsTrue(eq.IsRightAngled);
            Assert.IsFalse(eq.IsEquilateral);

            Triangle iso = new Triangle(6, 6, 8);
            Assert.IsTrue(iso.IsEquilateral);

        }
    }
}
