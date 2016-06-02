using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCGA4.Kruskal
{
    public class Edge : IComparable<Edge>
    {
        public Point P1 { get; set; }
        public Point P2 { get; set; }

        public int Weight { get; set; }

        public Edge(Point p1, Point p2, int weight)
        {
            this.P1 = p1;
            this.P2 = p2;
            this.Weight = weight;
        }

        public int CompareTo (Edge other)
        {
            return this.Weight.CompareTo(other.Weight);
        }

        public override string ToString ()
        {
            return string.Format("{0} - {1} : {2}", P1.ToString(), P2.ToString(), Weight.ToString());
        }
    }
}
