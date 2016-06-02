using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCGA4.Kruskal
{
    public class Graph
    {
        public int Width
        {
            get;
            private set;
        }

        public int Height
        {
            get;
            private set;
        }

        public List<Point> Points { get; set; }
        public List<Edge> Edges { get; set; }

        public Graph(int x, int y)
        {
            this.Width = x;
            this.Height = y;
            this.Points = new List<Point>();
            this.Edges = new List<Edge>();
            int maxWeight = Height * Width * Height * Width; // arbitrary
            for(int yCoord = 0; yCoord < Width; yCoord++) // generate all the points
            {
                for(int xCoord = 0; xCoord < Height; xCoord++)
                {
                    Point p = new Point(xCoord, yCoord);
                    Points.Add(p);
                }
            }

            for(int yCoord = 0; yCoord < Width; yCoord++)  // create all horiz edges--the graph is rectangular...
            {
                for (int xCoord = 0; xCoord < Height - 1; xCoord++)
                {
                    int index = xCoord + yCoord * Width;
                    int nextIndex = (xCoord + 1) + yCoord * Width;
                    Point p1 = Points[index];
                    Point p2 = Points[nextIndex];
                    Edge e = new Edge(p1, p2, A4MapGenerator.RNG.Next(maxWeight));
                    Edges.Add(e);
                }
            }

            for (int xCoord = 0; xCoord < Height; xCoord++)  // create all vert edges--the graph is rectangular...
            {
                for (int yCoord = 0; yCoord < Width - 1; yCoord++)
                {
                    int index = xCoord + yCoord * Width;
                    int nextIndex = xCoord + (yCoord + 1) * Width;
                    Point p1 = Points[index];
                    Point p2 = Points[nextIndex];
                    Edge e = new Edge(p1, p2, A4MapGenerator.RNG.Next(maxWeight));
                    Edges.Add(e);
                }
            }

            Edges.Sort();
        }
    }
}
