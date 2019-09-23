using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountVonLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IterationLibrary;

namespace IterationTests
{
    [TestClass]
    public class IterationUtilitiesTests
    {
        [TestMethod]
        public void TestTriangular()
        {
            Assert.AreEqual(6, IterationUtilities.Triangular(3));
            Assert.AreEqual(78, IterationUtilities.Triangular(12));
        }

        [TestMethod]
        public void TestCountDown()
        {
            int n = 10;
            List<string> result = QuietFunctions.CountDown(n);
            Assert.AreEqual(string.Format("{0}!", n), result[0]);
            Assert.AreEqual("Blast-Off!", result[n]);
        }
    }
}
