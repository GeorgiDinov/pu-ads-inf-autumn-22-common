using System;
using System.Collections.Generic;
using DotNetty.Common.Utilities;

namespace PrimMST
{
    internal class PrimAlgorithm
    {
        private List<Vertex> unvisitedVertices;
        private List<Edge> spanningTree;
        private PriorityQueue<Edge> edgeHeap;
        private double mstFullCost;


        public PrimAlgorithm(List<Vertex> unvisitedVertices)
        {
            this.unvisitedVertices = unvisitedVertices;
            this.spanningTree = new List<Edge>();
            this.edgeHeap = new PriorityQueue<Edge>(new EdgeWeightComparable());
            this.mstFullCost = 0.0;
        }

        public void FindMST(Vertex startingVertex)
        {
            unvisitedVertices.Remove(startingVertex);
            while (unvisitedVertices.Count > 0)
            {
                foreach (Edge edge in startingVertex.EdgeList)
                {
                    if (unvisitedVertices.Contains(edge.TargetVertex))
                    {
                        edgeHeap.Enqueue(edge);
                    }
                }
                Edge minWeightEdge = edgeHeap.Dequeue();
                spanningTree.Add(minWeightEdge);
                mstFullCost += minWeightEdge.EdgeWeight;
                startingVertex = minWeightEdge.TargetVertex;
                unvisitedVertices.Remove(startingVertex);
            }

            ShowMST();
        }


        private void ShowMST()
        {
            Console.WriteLine("The minimum spanning tree costs = " + mstFullCost);
            foreach (Edge edge in spanningTree)
            {
                Console.WriteLine(edge);
            }
        }

    }
}
