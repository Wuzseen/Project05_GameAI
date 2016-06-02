using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCGA4.Kruskal
{
    public class Point // Point is also a tree/set with a pointer to its parent node.
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
            Error
        }

        public int X { get; set; }
        public int Y { get; set; }

        public Point Parent { get; set; }
        public int Rank { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
            Rank = 0;
            Parent = this;
        }

        public Point GetRoot()
        {
            if(this.Parent != this)
            {
                this.Parent = this.Parent.GetRoot();
            }
            return this.Parent;
        }

        public static void Union(Point p1, Point p2)
        {
            if(p2.Rank < p1.Rank) // If p1 has lass, make it the parent
            {
                p2.Parent = p1;
            }
            else // make p2 the parent instead
            {
                p1.Parent = p2;
                if(p1.Rank == p2.Rank) // if they had the same rank, give p2 a higher rank for future joins
                {
                    p2.Rank++;
                }
            }
        }

        public override string ToString ()
        {
            return string.Format("({0},{1})", X.ToString(), Y.ToString());
        }

        /// <summary>
        /// Return position of p1 compared to p2. Eg if p1 is left of p2, not p2 left of p1.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Direction GetDirection(Point p1, Point p2)
        {
            if(p1.X == p2.X - 1)
            {
                return Direction.Left;
            }
            if (p1.X == p2.X + 1)
            {
                return Direction.Right;
            }
            if (p1.Y == p2.Y - 1)
            {
                return Direction.Up;
            }
            if (p1.Y == p2.Y + 1)
            {
                return Direction.Down;
            }
            return Direction.Error;
        }
    }
}
