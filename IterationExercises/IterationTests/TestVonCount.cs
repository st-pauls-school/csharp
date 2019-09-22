using CountVonLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IterationTests
{
    [TestClass]
    public class TestVonCount
    {
        CountVonCount _withoutCommasOrAnds;
        CountVonCount _withCommasAndAnds;
        CountVonCount _withEverything;

        [TestInitialize]
        public void Setup()
        {
            _withoutCommasOrAnds = new CountVonCount(false, false, false);
            _withCommasAndAnds = new CountVonCount(true, true, false);
            _withEverything = new CountVonCount(true, true, true);
        }

        [TestMethod]
        public void BasicWithEverything()
        {
            Assert.AreEqual("one!", _withCommasAndAnds.Generate(1));
            Assert.AreEqual("eleven!", _withCommasAndAnds.Generate(11));
            Assert.AreEqual("twenty!", _withCommasAndAnds.Generate(20));
            Assert.AreEqual("forty-one!", _withCommasAndAnds.Generate(41));
            Assert.AreEqual("two hundred and forty!", _withCommasAndAnds.Generate(240));
            Assert.AreEqual("three thousand, one hundred and forty-two!", _withCommasAndAnds.Generate(3142));
            Assert.AreEqual("forty-three thousand, two hundred and one!", _withCommasAndAnds.Generate(43201));
            Assert.AreEqual("three hundred and seventy-three million, three hundred and seventy-three thousand, two hundred and one!", _withCommasAndAnds.Generate(373373201));
        }

        [TestMethod]
        public void WithEverythingGap()
        {
            Assert.AreEqual("one thousand and one!", _withCommasAndAnds.Generate(1001));
            Assert.AreEqual("one million and one!", _withCommasAndAnds.Generate(1000001));
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
            Assert.AreEqual("two hundred and one!", _withCommasAndAnds.Generate(201));
        }

        [TestMethod]
        public void Listing()
        {
            var li = _withCommasAndAnds.NumbersOfIncreasingLength(1, 10);
            Assert.AreEqual(2, li.Count);
        }
    }
}
