using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringLibrary;

namespace StringTests
{
    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void TestIncrease()
        {
            Assert.AreEqual("bcde", StringExercise.Increase("abcd", 1));
            Assert.AreEqual("yzab", StringExercise.Increase("abcd", -2));
        }
    }
}
