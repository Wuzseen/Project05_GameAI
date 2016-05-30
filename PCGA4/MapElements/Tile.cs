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
        [XmlAttribute("gid")]
        public string GID;

        public Tile()
        {
            GID = "57";
        }

        public Tile(string gid)
        {
            this.GID = gid;
        }

        public Tile(int gid)
        {
            this.GID = gid.ToString();
        }
    }
}
