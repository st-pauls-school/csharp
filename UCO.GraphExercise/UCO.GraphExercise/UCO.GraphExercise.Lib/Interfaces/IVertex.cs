using System;

namespace UCO.GraphExercise.Lib.Interfaces
{
    public interface IVertex<T> : IEquatable<IVertex<T>> where T : IEquatable<T>
    {
        T Value { get; }
    }

}
