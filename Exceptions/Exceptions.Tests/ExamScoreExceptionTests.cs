using System;
using Exceptions.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exceptions.Tests
{
    [TestClass]
    public class ExamScoreExceptionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ExamScoreException))]
        public void TestConstructors()
        {
            var e = new ExamScore(-2, 100);
        }
    }
}
