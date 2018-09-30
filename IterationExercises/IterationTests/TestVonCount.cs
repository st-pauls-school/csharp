using System;
using IterationClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IterationTests
{
    [TestClass]
    public class TestVonCount
    {
        CountVonCount _withoutCommasOrAnds;
        CountVonCount _withEverything;
        CountVonCount _everythingAndHas;

        [TestInitialize]
        public void Setup()
        {
            _withoutCommasOrAnds = new CountVonCount(false, false, false);
            _withEverything = new CountVonCount(true, true, false);
            _everythingAndHas = new CountVonCount(true, true, true);
        }

        [TestMethod]
        public void BasicWithEverything()
        {
            Assert.AreEqual("one!", _withEverything.Generate(1));
            Assert.AreEqual("eleven!", _withEverything.Generate(11));
            Assert.AreEqual("twenty!", _withEverything.Generate(20));
            Assert.AreEqual("forty-one!", _withEverything.Generate(41));
            Assert.AreEqual("two hundred and forty!", _withEverything.Generate(240));
            Assert.AreEqual("three thousand, one hundred and forty-two!", _withEverything.Generate(3142));
            Assert.AreEqual("forty-three thousand, two hundred and one!", _withEverything.Generate(43201));
            Assert.AreEqual("three hundred and seventy-three million, three hundred and seventy-three thousand, two hundred and one!", _withEverything.Generate(373373201));
        }

        [TestMethod]
        public void WithEverythingGap()
        {
            Assert.AreEqual("one thousand and one!", _withEverything.Generate(1001));
            Assert.AreEqual("one million and one!", _withEverything.Generate(1000001));
        }

        [TestMethod]
        public void BasicWithWithout()
        {
            Assert.AreEqual("one!", _withoutCommasOrAnds.Generate(1));
            Assert.AreEqual("eleven!", _withoutCommasOrAnds.Generate(11));
            Assert.AreEqual("twenty-one!", _withoutCommasOrAnds.Generate(21));
            Assert.AreEqual("three thousand one hundred forty-two!", _withoutCommasOrAnds.Generate(3142));
            Assert.AreEqual("forty-three thousand two hundred one!", _withoutCommasOrAnds.Generate(43201));
            Assert.AreEqual("two hundred one!", _withoutCommasOrAnds.Generate(201));
        }


        [TestMethod]
        public void Spaces()
        {
            Assert.AreEqual("one million one!", _withoutCommasOrAnds.Generate(1000001));
            Assert.AreEqual("two hundred and one!", _withEverything.Generate(201));
        }

        [TestMethod]
        public void Listing()
        {
            var li = _withEverything.NumbersOfIncreasingLength(1, 10);
            Assert.AreEqual(2, li.Count);
        }
    }
}
