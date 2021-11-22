using System;

namespace Graph.Exercises.Lib
{
    class Edge<T> where T : IComparable<T> {
        readonly ValueTuple<Node<T>, Node<T>> _nodes;

        internal Edge(Node<T> f, Node<T> t) {
            _nodes = (f,t);
        }

    }
}
