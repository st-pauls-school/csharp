using System;
using System.Collections.Generic;

namespace Graph.Exercises.Lib
{
    public class GraphFactory<T> : IGraphFactory<T>
        where T : IComparable<T>
    {

        readonly IList<Node<T>> _nodes;
        readonly IList<Edge<T>> _edges;
        readonly bool _directed;

        public GraphFactory() : this(false) { }
        public GraphFactory(bool directed)
        {
            _nodes = new List<Node<T>>();
            _edges = new List<Edge<T>>();
            _directed = directed;
        }

        public IGraphFactory<T> AddEdge(T value1, T value2, double? weight = null)
        {
            // todo: assumption of undirected - so we add the edges in value order 
            Edge<T> edge = _directed || (value1.CompareTo(value2) < 0) 
                ? new Edge<T>(Find(value1), Find(value2), weight)
                : new Edge<T>(Find(value2), Find(value1), weight);
            _edges.Add(edge);
            return this;
            
        }

        public IGraphFactory<T> AddNode(T value)
        {
            // todo : how to deal with duplicate values 
            _nodes.Add(new Node<T>(value));            
            return this;
        }

        public IGraph<T> Create()
        {
            return new Graph<T>(_directed, _nodes, _edges);
        }

        Node<T> Find(T value) {
            foreach(Node<T> n in _nodes)
                if(n.Value.Equals(value))
                    return n;
            Node<T> newOne = new Node<T>(value);
            _nodes.Add(newOne);
            return newOne;
        }

    }
}
