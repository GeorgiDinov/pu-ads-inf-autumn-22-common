using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShortestPath
{
    internal class Vertex
    {
        private string name;

        private bool isVisited;
        public bool IsVisited
        {
            get { return isVisited; }
            set { isVisited = value; }
        }

        private List<Vertex> adjacencyList;
        public List<Vertex> AdjacencyList
        {
            get { return adjacencyList; }
        }


        private List<Edge> edgeList;
        public List<Edge> EdgeList
        {
            get { return edgeList; }
            set { edgeList = value; }
        }


        //distance from the starting vertex(source)
        private double distance;
        public double Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        //the previous vertex on the shortest path
        private Vertex predecessor;
        public Vertex Predecessor
        {
            get { return predecessor; }
            set { predecessor = value; }
        }


        public Vertex(string name)
        {
            this.name = name;
            this.isVisited = false;
            this.adjacencyList = new List<Vertex>();
            this.edgeList = new List<Edge>();
            this.distance = double.PositiveInfinity; // double.MaxValue
            this.predecessor = null;
        }


        public void AddNeighbor(Vertex vertex)
        {
            adjacencyList.Add(vertex);
        }

        public void AddEdge(Edge edge)
        {
            edgeList.Add(edge);
        }

        public override string ToString()
        {
            return name;
        }
    }
}
