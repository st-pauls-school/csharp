using System;
using System.Collections.Generic;
using UCO.GraphExercise.Lib.Interfaces;

namespace UCO.GraphExercise.Lib.Classes
{
    public class GraphFactory<T> : IGraphFactory<T> where T : IEquatable<T>, IComparable<T>
    {
        bool _weighted;
        bool _directed;
        IList<T> _vertices;
        IList<Tuple<T, T>> _unweightedEdges;
        IList<Tuple<T, T, int>> _weightedEdges;


        public GraphFactory(bool weighted = false, bool directed=false)
        {
            _weighted = weighted;
            _directed = directed;
            _vertices = new List<T>();
            _unweightedEdges = new List<Tuple<T, T>>();
            _weightedEdges = new List<Tuple<T, T, int>>();
        }

        public IGraphFactory<T> AddEdge(T v1, T v2, int? weight = null)
        {
            if (!_vertices.Contains(v1))
                _vertices.Add(v1);
            if (!_vertices.Contains(v2))
                _vertices.Add(v2);
            if (_weighted)
            {
                if (!weight.HasValue)
                    throw new ArgumentNullException(string.Format("expecting a value for the weight between {0} and {1}", v1, v2));
                else
                    _weightedEdges.Add(new Tuple<T, T, int>(v1, v2, weight.Value));
            }
            else
            {
                _unweightedEdges.Add(new Tuple<T, T>(v1, v2));
            }
            

            return this;
        }

        public IGraph<T> Create()
        {
            return _weighted 
                ? new Graph<T>(_vertices, _weightedEdges, _directed) 
                : new Graph<T>(_vertices, _unweightedEdges, _directed);
        }

        public IGraphFactory<T> SetDirected(bool directed)
        {
            _directed = directed;
            return this;
        }

        public IGraphFactory<T> SetWeighted(bool weighted)
        {
            _weighted = weighted;
            return this;
        }
    }
}
