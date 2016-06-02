using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCGA4.Kruskal
{
    /// <summary>
    /// Was having issues with some of the required data structures in C#--especially for unions of trees, found this reference to help guide me:
    /// http://www.codeproject.com/Articles/163618/Kruskal-Algorithm
    /// </summary>
    public class KruskalSolver
    {
        public Graph Graph { get; set; }

        public List<Edge> MST { get; set; }

        public List<Point> OpenPoints // Get all points that are part of the tree. These are the points that need to be opened.
        {
            get
            {
                List<Point> ret = new List<Point>();
                foreach(Edge e in MST)
                {
                    if(ret.Contains(e.P1) == false)
                    {
                        ret.Add(e.P1);
                    }
                    if (ret.Contains(e.P2) == false)
                    {
                        ret.Add(e.P2);
                    }
                }

                return ret; 
            }
        }

        public KruskalSolver(Graph graph)
        {
            this.Graph = graph;
            Queue<Edge> edgeQueue = new Queue<Edge>(graph.Edges); // the front of this queue will always be the lowest weight edge;
            List<Edge> A = new List<Edge>(); // using A just for sanity sake with the algorithm

            int vCount = graph.Points.Count; // # of points in graph

            List<Subset> subsets = new List<Subset>();
            for(int i = 0; i < vCount; i++)
            {
                subsets.Add(new Subset(graph.Points[i]));
            }

            int index = 0;
            while(edgeQueue.Count > 0)
            {
                Edge e = edgeQueue.Dequeue();
                Point r1 = e.P1.GetRoot();
                Point r2 = e.P2.GetRoot();

                if(cycleMade(e) == false) // A cycle is already made with this edge
                {
                    Point.Union(r1, r2); // combine the trees/sets
                    A.Add(e);
                }
                index++;
            }

            this.MST = A;
        }

        bool cycleMade(Edge e)
        {
            Point r1 = e.P1.GetRoot();
            Point r2 = e.P2.GetRoot();
            return r1 == r2;
        }
    }
}
