using NUnit.Framework;

namespace LookSay.Tests
{
    public class SequenceTests
    {
        private Sequence _sequence;
        
        [SetUp]
        public void Setup()
        {
            _sequence = new Sequence(1);    
        }

        [Test]
        [TestCase(1, "11")]
        [TestCase(3, "1211")]
        [TestCase(4, "111221")]
        public void TestIndex(int i, string v)
        {
            Assert.AreEqual(v, _sequence.Generate(i));
        }
        
        [Test]
        public void TestList()
        {
            var results = _sequence.GenerateList(4);
            Assert.AreEqual("11", results[1]);
            Assert.AreEqual("21", results[2]);
            Assert.AreEqual("1211", results[3]);
        }
    }
}