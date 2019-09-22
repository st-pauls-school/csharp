using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectLibrary;

namespace PersonTests
{
    [TestClass]
    public class UtilitiesTests
    {
        [TestMethod]
        public void TestChineseSignLogic()
        {
            Assert.AreEqual(new DateTime(2008, 10, 1).ToChineseSign(), ChineseSign.Rat);
            Assert.AreEqual(new DateTime(2012, 10, 1).ToChineseSign(), ChineseSign.Dragon);
            Assert.AreEqual(new DateTime(2018, 1, 1).ToChineseSign(), ChineseSign.Rooster, "before Chinese New Year");
        }
    }
}
