using System.Collections.Generic;
using System.Linq;
using BinarySortedTree.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySortedTree.Tests
{
    [TestClass]
    public class BinarySortedTreeTests
    {
        IBinarySortedTree<int> tree;

        [TestInitialize]
        public void Setup()
        {
            tree = new BinarySortedGenericTree<int>(15);
            foreach (int n in new List<int> { 8, 7, 23, 15, 5, 9, -1, 27, 18, 15, 14, 12, 14, 27, 10, 32, 18, 42, -4, 8, 12, 9, 2, 0 })
            {
                tree.Insert(n);
            }
        }

        [TestMethod]
        public void TestSum()
        {
            Assert.AreEqual(337, tree.Sum);
        }
        [TestMethod]
        public void TestPresent() 
        { 
            Assert.IsTrue(tree.Present(8));
            Assert.IsFalse(tree.Present(-26));

        }
        [TestMethod]
        public void TestOutput()
        {
            IList<int> sortedValues = new List<int> { 15, 8, 7, 23, 15, 5, 9, -1, 27, 18, 15, 14, 12, 14, 27, 10, 32, 18, 42, -4, 8, 12, 9, 2, 0 }.OrderBy(i => i).ToList();
            CollectionAssert.AreEquivalent(sortedValues.ToList(), tree.Output().ToList());
        }

        [TestMethod]
        public void TestDepth()
        {
            Assert.AreEqual(9, tree.Depth);

        }

        [TestMethod]
        public void TestLCA()
        {
            Assert.AreEqual(8, tree.LowestCommonAncestor(5, 9));
        }

        [TestMethod]
        public void TestDelete()
        {
            Assert.IsFalse(tree.Present(94));
            tree.Insert(94);
            Assert.IsTrue(tree.Present(94));
            tree.Delete(94);
            Assert.IsFalse(tree.Present(94));
        }
    }
}
