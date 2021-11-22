using System;
using System.Collections.Generic;

namespace Graph.Exercises.Lib
{
    class Graph<T> : IGraph<T>  
        where T : IComparable<T> {
        readonly IList<Node<T>> _nodes;
        readonly IList<Edge<T>> _edges;

        internal Graph(IList<Node<T>> nodes, IList<Edge<T>> edges) {
            _nodes = nodes;
            _edges = edges;
        }
    }
}
