using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimMST
{
    internal class EdgeWeightComparable : IComparer<Edge>
    {
        public int Compare(Edge e1, Edge e2)
        {
           return e1.EdgeWeight.CompareTo(e2.EdgeWeight);
        }
    }
}
