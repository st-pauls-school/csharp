using System;
using UCO.GraphExercise.Lib.Interfaces;

namespace UCO.GraphExercise.Lib.Interfaces
{
    public interface IGraphFactory<T> where T : IEquatable<T>, IComparable<T>
    {
        IGraphFactory<T> SetDirected(bool directed);
        IGraphFactory<T> SetWeighted(bool weighted);
        IGraphFactory<T> AddEdge(T v1, T v2, int? weight=null);
        IGraph<T> Create();
    }
}
