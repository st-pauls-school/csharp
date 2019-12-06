using Microsoft.VisualStudio.TestTools.UnitTesting;
using UCO.GraphExercise.Lib.Classes;
using UCO.GraphExercise.Lib.Interfaces;

namespace UCO.GraphExercise.Tests
{
    [TestClass]
    public class UndirectedWeightedTests
    {
        // todo: create a sample undirected, weighted graph
        [TestMethod]
        public void TestMethod1()
        {
            IGraph<string> g =
                new GraphFactory<string>(true, false)
                    .AddEdge("A", "B", 1)
                    .AddEdge("A", "C", 1)
                    .AddEdge("A", "D", 1)
                    .AddEdge("A", "E", 1)
                    .AddEdge("B", "C", 4)
                    .AddEdge("D", "C", 5)
                    .AddEdge("D", "E", 4)
                    .AddEdge("B", "E", 3)
                    .Create();
            Assert.AreEqual(20, g.TotalWeight);
            Assert.AreEqual(8, g.EdgeCount);
            
//            Assert.AreEqual(2, g.ShortestPath("B", "D"));
//            Assert.AreEqual("A", g.CentreOfTheGraph.Value);
        }
    }
}
