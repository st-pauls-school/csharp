using System.Collections.Generic;

namespace UCO.GraphExercise.Lib
{
    public interface IGraph<T> 
    {
        bool Connected { get; }
        bool Cyclic { get; }
        bool Directed { get; }
        bool Weighted { get; }

        int ShortestPath(IVertex<T> v1, IVertex<T> v2);
        IVertex<T> CentreOfTheGraph { get; }
        IGraph<T> MinimumSpanningTree(MinimalAlgorithms algm);
        IList<IVertex<T>> Traversal(TreeTraversalMethods direction);
        IList<IVertex<T>> DeletionOrder { get; }
    }
    public interface IVertex<T>
    {

    }

    public enum TreeTraversalMethods
    {
        BreadthFirst, DepthFirst
    }

    public enum MinimalAlgorithms
    {
        Prim, Kruskal
    }

}
