using System;

namespace Graph.Exercises.Lib
{
    public interface IGraphFactory<T> where T : IComparable<T> {
        IGraphFactory<T> AddNode(T value);
        IGraphFactory<T> AddEdge(T value1, T value2);
        IGraph<T> Create();        
    }
}
