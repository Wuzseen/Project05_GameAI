using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PCGA4.MapElements
{

    [XmlType("tile")]
    public class Tile
    {
        public static readonly int FLOOR = 57;
        public static readonly int EMPTY = -1;
        public static readonly int HALFWALL = 331;
        public static readonly int BOTTOMRIGHT = 311;
        public static readonly int BOTTOMLEFT = 271;
        public static readonly int VERTICALWALL = 241;
        public static readonly int VERTICALSPIKE = 242;
        public static readonly int HORIZONTALSPIKE = 332;
        public static readonly int TOPRIGHT = 302;
        public static readonly int TOPLEFT = 261;

        [XmlAttribute("gid")]
        public int GID;

        public Tile()
        {
            GID = FLOOR;
        }

        public Tile(int gid)
        {
            this.GID = gid;
        }
    }
}
