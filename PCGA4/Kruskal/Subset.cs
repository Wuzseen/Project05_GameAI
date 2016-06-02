using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCGA4.Kruskal
{
    public class Subset
    {
        public Point Parent { get; set; }
        public int Rank { get; set; }

        public Subset(Point parent)
        {
            Rank = 0;
            Parent = parent;
        }
    }
}
