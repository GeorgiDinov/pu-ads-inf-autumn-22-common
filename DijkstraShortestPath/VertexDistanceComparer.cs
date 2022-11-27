using System.Collections.Generic;

namespace DijkstraShortestPath
{
    internal class VertexDistanceComparer : IComparer<Vertex>
    {
        // needed for the correct workings of the priority queue
        public int Compare(Vertex v1, Vertex v2)
        {
            return v1.Distance.CompareTo(v2.Distance);
        }

    }
}