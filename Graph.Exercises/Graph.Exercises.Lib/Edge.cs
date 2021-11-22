using System;

namespace Graph.Exercises.Lib
{
    class Edge<T> where T : IComparable<T> {
        readonly ValueTuple<Node<T>, Node<T>> _nodes;
        readonly double? _weight;


        internal bool Match(T value) {
            return _nodes.Item1.Value.Equals(value) || _nodes.Item2.Value.Equals(value);
        }

        internal Node<T> Other(T value) {
            if(_nodes.Item1.Value.Equals(value)) return _nodes.Item2;
            if(_nodes.Item2.Value.Equals(value)) return _nodes.Item1;
            return null;
        }

        internal Edge(Node<T> f, Node<T> t, double? weight = null) {
            _nodes = (f,t);
            _weight = weight;
        }

    }
}
