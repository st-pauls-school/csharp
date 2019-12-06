using System;

namespace UCO.GraphExercise.Lib.Interfaces
{
    /// <summary>
    /// The Vertex interface
    /// </summary>
    /// <typeparam name="T">The value of the vertex, for identifying it, must be IEquatable on <typeparamref name="T"/>.</typeparam>
    public interface IVertex<T> : IEquatable<IVertex<T>> where T : IEquatable<T>
    {
        T Value { get; }
    }

}
