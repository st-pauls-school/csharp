using System.Diagnostics;
using Graph.Exercises.Lib;

namespace Graph.Exercises.App
{
    class Program
    {
        // todo: export to explicit Unit Tests 
        static void Main(string[] args)
        {
            IGraph<char> g1 = 
                new GraphFactory<char>()
                    .AddEdge('A','B')
                    .AddEdge('B','C')
                    .Create();
            Debug.Assert(g1.IsConnected);
            IGraph<char> g2 = 
                new GraphFactory<char>()
                    .AddEdge('A','B')
                    .AddEdge('B','C')
                    .AddNode('D')
                    .Create();
            Debug.Assert(!g2.IsConnected);
            IGraph<char> g3 =
                new GraphFactory<char>()
                    .AddEdge('B', 'A')
                    .AddEdge('B', 'C')
                    .AddEdge('D', 'C')
                    .Create();
            Debug.Assert(g3.IsConnected);
        }
    }    
}
