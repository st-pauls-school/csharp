using FactoryPattern.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryPattern.Tests
{
    // todo: needs more comments 
    [TestClass]
    public class IThingTests
    {
        [TestMethod]
        public void TestIThingFactory()
        {
            IThingFactory itf = ThingFactory.GiveMeAFactory();
            IThing thing =
                itf
                    .AddInteger(94)
                    .AddString("hello, world")
                    .Create();
            Assert.AreEqual(94, thing.SomeIntegerFunction(8));
            Assert.AreEqual("goodbye", thing.SaySomething("g'day"));
        }
    }
}
