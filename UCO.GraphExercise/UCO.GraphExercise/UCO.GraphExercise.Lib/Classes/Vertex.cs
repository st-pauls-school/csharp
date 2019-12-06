using System;
using UCO.GraphExercise.Lib.Interfaces;

namespace UCO.GraphExercise.Lib.Classes
{
    public class Vertex<T> : IVertex<T> where T : IEquatable<T>
    {
        readonly T _value;

        public T Value {  get { return _value; } }
        public Vertex(T value)
        {
            _value = value;
        }

        public bool Equals(IVertex<T> other)
        {
            return Value.Equals(other.Value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
