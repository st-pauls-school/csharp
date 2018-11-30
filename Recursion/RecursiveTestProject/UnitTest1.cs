using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Recursion;

namespace RecursiveTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFirstPositive()
        {
            CollectionAssert.AreEqual(new List<int> (), RecursiveFunctions.FirstNNaturalNumbers(0));
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5 }, RecursiveFunctions.FirstNNaturalNumbers(5));
        }

        [TestMethod]
        public void TestFirstNegative()
        {

            // Extend your function to count negatively if the input was negative.
            CollectionAssert.AreEqual(new List<int> { -1, -2, -3, -4, -5 }, RecursiveFunctions.FirstNNaturalNumbers(-5));
        }

        [TestMethod]
        public void TestSplit()
        {

            // Write a function to return a list of the individual digits of a given integer.
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5 }, RecursiveFunctions.Split(12345));
            CollectionAssert.AreEqual(new List<int> { 3, 7, 0, 9, 4 }, RecursiveFunctions.Split(37094));
        }

        [TestMethod]
        public void TestPrime()
        {

            // Write a function that returns a Boolean saying whether a given integer is prime or not using recursion.
            Assert.IsFalse(RecursiveFunctions.IsPrime(1));
            Assert.IsFalse(RecursiveFunctions.IsPrime(100));
            Assert.IsTrue(RecursiveFunctions.IsPrime(2));
            Assert.IsTrue(RecursiveFunctions.IsPrime(17));

            Assert.AreEqual(true, RecursiveFunctions.IsPrime(31));

        }
        [TestMethod]
        public void TestFib()
        {

            //Write a function to return a list of the first n Fibonacci numbers for a given integer.
            //Write it iteratively
            //Write it recursively
            CollectionAssert.AreEqual(new List<int> { 1, 1, 2, 3, 5, 8 }, RecursiveFunctions.Fibonacci(6));

        }
    }
}
