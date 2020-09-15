using System;
using System.Collections.Generic;
using UCO.GraphExercise.Lib.Enums;

namespace UCO.GraphExercise.Lib.Interfaces
{
    /// <summary>
    /// The graph class, stores a list of vertices 
    /// </summary>
    /// <typeparam name="T">This is the data that's identifying the vertex, needs to be IEquatable on <typeparamref name="T"/> so the list can be checked (possibly a dictionary?)</typeparam>
    public interface IGraph<T> where T : IEquatable<T>, IComparable<T>
    {
        bool Connected { get; }
        bool Cyclic { get; }
        bool Directed { get; }
        bool Weighted { get; }

        int EdgeCount { get; }
        int TotalWeight { get; }

        int ShortestPath(T v1, T v2);
        IVertex<T> CentreOfTheGraph { get; }
        IGraph<T> MinimumSpanningTree(MinimalAlgorithms algm);
        IList<IVertex<T>> Traversal(TreeTraversalMethods direction, T root);
        IList<IVertex<T>> DeletionOrder { get; }
    }

}
