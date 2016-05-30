using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PCGA4.MapElements
{
    [XmlType("tileset")]
    public class Tileset
    {
        [XmlAttribute("firstgid")]
        public string FirstGID = "1";
        [XmlAttribute("graphics")]
        public string Graphics = "graphics";
        [XmlAttribute("tilewidth")]
        public string TileWidth = "32";
        [XmlAttribute("tileheight")]
        public string TileHeight = "32";

        [XmlElement("image")]
        public Image image;

        public Tileset ()
        {
            image = new Image();
        }
    }
}
