using System;

namespace Graph.Exercises.Lib
{
    class Node<T> where T : IComparable<T> {
        readonly T _value;

        internal T Value => _value;

        internal Node(T value) {
            _value = value;
        }

    }
}
