using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCO.GraphExercise.Lib.Enums;
using UCO.GraphExercise.Lib.Interfaces;

namespace UCO.GraphExercise.Lib.Classes
{
    public class Graph<T> : IGraph<T> where T : IEquatable<T>, IComparable<T>
    {
        #region private member variables 
        readonly IList<IVertex<T>> _listOfVertices;
        readonly bool _directed;
        readonly bool _weighted;
        readonly IList<IList<int?>> _adjacencyMatrix; // rows are from, columns are to - in practice this means that each element of the outer list is the adjacency list for that vertex
        #endregion

        #region IGraph Properties 
        public bool Connected => throw new NotImplementedException();

        public bool Cyclic => throw new NotImplementedException();

        public bool Directed { get { return _directed; } }

        public bool Weighted { get { return _weighted; } }

        public int TotalWeight
        {
            get
            {
                return _adjacencyMatrix.Select(row => row.Select(i => i.HasValue ? i.Value : 0).Sum()).Sum() / (_directed ? 1 : 2);
            }
        }

        public int EdgeCount
        {
            get
            {
                return _adjacencyMatrix.Select(row => row.Select(i => i.HasValue && i.Value > 0 ? 1 : 0).Sum()).Sum() / (_directed ? 1 : 2);
            }
        }



        #endregion

        #region Constructors
        // todo: what if more than vertices have the same name? 
        internal Graph(IList<T> vertices, bool directed, bool weighted)
        {
            _directed = directed;
            _weighted = weighted;
            _listOfVertices = new List<IVertex<T>>();
            _adjacencyMatrix = new List<IList<int?>>();
            foreach (T v in vertices)
            {
                _listOfVertices.Add(new Vertex<T>(v));
                // todo: could the row of the adjacency matrix live in the vertex? 
                _adjacencyMatrix.Add(new List<int?>(new int?[vertices.Count]));
            }

        }
        internal Graph(IList<T> vertices, IList<Tuple<T,T>> edges, bool directed) : this(vertices, directed, false)
        {
            foreach (Tuple<T, T> e in edges)
                AddEdge(e.Item1, e.Item2, 1);
        }

        internal Graph(IList<T> vertices, IList<Tuple<T, T, int>> edges, bool directed) : this(vertices, directed, true)
        {
            foreach (Tuple<T, T, int> e in edges)
                AddEdge(e.Item1, e.Item2, e.Item3);
        }
        #endregion

        #region Private Methods 

        // todo: how to deal with non-existent vertices? 
        // todo: how to deal with multiple edges between the same pair of nodes 
        private void AddEdge(T v1, T v2, int? weight)
        {
            int i1 = _listOfVertices.IndexOf(v1);
            int i2 = _listOfVertices.IndexOf(v2);
            _adjacencyMatrix[i1][i2] = weight;
            if(_directed == false)
                _adjacencyMatrix[i2][i1] = weight;


        }

        #endregion

        #region IGraph methods 
        public IVertex<T> CentreOfTheGraph => throw new NotImplementedException();

        public IList<IVertex<T>> DeletionOrder => throw new NotImplementedException();

        public IGraph<T> MinimumSpanningTree(MinimalAlgorithms algm)
        {
            throw new NotImplementedException();
        }

        public int ShortestPath(T v1, T v2)
        {
            throw new NotImplementedException();
        }

        public IList<IVertex<T>> Traversal(TreeTraversalMethods direction, T root)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
