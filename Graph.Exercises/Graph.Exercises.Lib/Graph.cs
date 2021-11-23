using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph.Exercises.Lib
{
    class Graph<T> 
        : IGraph<T>  
        where T : IComparable<T> {

        readonly IList<Node<T>> _nodes;
        readonly IList<Edge<T>> _edges;
        readonly bool _directed;

        internal Graph(IList<Node<T>> nodes, IList<Edge<T>> edges) : this(false, nodes, edges) { } 

        internal Graph(bool directed, IList<Node<T>> nodes, IList<Edge<T>> edges) {
            _nodes = nodes;
            _edges = edges;
            _directed = directed;
        }

        IEnumerable<Node<T>> FromHere(T value) {
            Node<T> here = _nodes.Where(n => n.Value.Equals(value)).First();
            // todo : what if the value doesn't exist? 
            foreach(Edge<T> e in _edges) {
                if(e.Match(value))
                    yield return e.Other(value);

            }
        }

        public bool IsConnected {
            get {
                IList<T> values = _nodes.Select(n => n.Value).ToList();
                Queue<Node<T>> fromHere = new Queue<Node<T>>();
                fromHere.Enqueue(_nodes[0]);
                values.Remove(_nodes[0].Value);
                
                // todo : directed vs undirected traversal 
                while(fromHere.Count > 0) {
                    Node<T> popped = fromHere.Dequeue();
                    foreach(Node<T> f in FromHere(popped.Value)) {
                        if(values.Contains(f.Value)) {
                            values.Remove(f.Value);
                            fromHere.Enqueue(f);
                        }
                    }
                    if(values.Count == 0)
                        return true;
                    
                }
                return false;

            }
        }
    }
}
