using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimMST
{
    internal class Edge
    {
        private double edgeWeight;

        public double EdgeWeight
        {
            get { return edgeWeight; }
            set { edgeWeight = value; }
        }


        private Vertex startVertex;

        public Vertex StartVertex
        {
            get { return startVertex; }
            set { startVertex = value; }
        }


        private Vertex targetVertex;

        public Vertex TargetVertex
        {
            get { return targetVertex; }
            set { targetVertex = value; }
        }


        public Edge(double edgeWeight, Vertex startVertex, Vertex targetVertex)
        {
            this.edgeWeight = edgeWeight;
            this.startVertex = startVertex;
            this.targetVertex = targetVertex;
        }

        public override string ToString()
        {
            return startVertex + " - " + targetVertex;
        }
    }
}
