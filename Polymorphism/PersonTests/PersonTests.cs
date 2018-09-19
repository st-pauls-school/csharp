using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectLibrary;

namespace PersonTests
{
    [TestClass]
    public class PersonTests
    {
        IList<Person> _people;

        [TestInitialize]
        public void Setup()
        {
            _people = new List<Person>
            {
                new Person("Amy", "Future-Baby", new DateTime(2020, 12, 25)),
                new Person("John", "Smith", new DateTime(1990, 12, 25)),
                new Teacher("Joe", "Teacher", "jt@sps", new DateTime(1981, 8, 11)),
                new Student("Jeff", "Student", "js@sps", new DateTime(2001, 9, 11), "U8")
            };

        }
        
        [TestMethod]
        public void TestValidAges()
        {
            Assert.IsFalse(_people[0].IsValidAge);
            Assert.IsTrue(_people[1].IsValidAge);
            Assert.IsTrue(_people[2].IsValidAge);
            Assert.IsTrue(_people[3].IsValidAge);
        }

        [TestMethod]
        public void TestIsAdult()
        {
            Assert.IsFalse(_people[0].IsAdult);
            Assert.IsTrue(_people[1].IsAdult);
            Assert.IsTrue(_people[2].IsAdult);
            Assert.IsFalse(_people[3].IsAdult);
        }

        [TestMethod]
        public void TestScreenNames()
        {
            Assert.AreEqual("AmyFuture-Baby1225", _people[0].ScreenName);
            Assert.AreEqual("JohnSmith1225", _people[1].ScreenName);
            Assert.AreEqual("JoeTeacherStaff", _people[2].ScreenName);
            Assert.AreEqual("JeffStudentU8", _people[3].ScreenName);
        }

        [TestMethod]
        public void TestChineseSignLogic()
        {
            Assert.AreEqual(new DateTime(2008, 10, 1).ToChineseSign(), ChineseSign.Rat);
            Assert.AreEqual(new DateTime(2012, 10, 1).ToChineseSign(), ChineseSign.Dragon);
            Assert.AreEqual(new DateTime(2018, 1, 1).ToChineseSign(), ChineseSign.Rooster, "before Chinese New Year");
        }
    }
}
