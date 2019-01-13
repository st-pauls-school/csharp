using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangman.Tests
{
    [TestClass]
    public class MonitorTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Monitor m = new Monitor("test");
            Assert.AreEqual(0, m.Score);
            Assert.IsFalse(m.Guess('a'));
            Assert.AreEqual(1, m.Score);
            Assert.IsTrue(m.Guess('e'));
            Assert.AreEqual("_ e _ _", m.Mask);
        }
    }
}
