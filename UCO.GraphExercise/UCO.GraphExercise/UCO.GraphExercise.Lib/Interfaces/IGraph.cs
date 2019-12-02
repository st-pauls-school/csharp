using System;
using System.Collections.Generic;
using UCO.GraphExercise.Lib.Enums;

namespace UCO.GraphExercise.Lib.Interfaces
{
    public interface IGraph<T> where T : IEquatable<T>
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

}
