using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCGA4.MapElements;
using System.Xml;
using System.Xml.Serialization;

namespace PCGA4.MapElements
{
    [XmlRoot("map")]
    public class Map
    {
        [XmlAttribute("version")]
        public string Version = "A4";
        [XmlAttribute("orientation")]
        public string Orientation = "orthogonal";
        [XmlAttribute("width")]
        public string Width = "16";
        [XmlAttribute("height")]
        public string Height = "16";
        [XmlAttribute("tilewidth")]
        public string TileWidth = "32";
        [XmlAttribute("tileheight")]
        public string TileHeight = "32";

        [XmlIgnore]
        public string Name { get; set; }

        [XmlArray(ElementName = "properties", Order = 0)]
        public MapProperty[] properties { get; set; }

        [XmlElement(ElementName = "tileset", Order = 1)]
        public Tileset Tileset;

        [XmlElement(ElementName = "layer", Order = 2)]
        public Layer Floor;
        [XmlElement(ElementName = "layer", Order = 3)]
        public WallLayer Walls;

        public Map()
        {
            Tileset = new Tileset();
            this.Name = "DefaultName";
            properties = new MapProperty[1];
            properties[0] = new MapProperty("name", this.Name);
            Floor = new Layer("Tile Layer 1");
            Walls = new WallLayer("Tile Layer 2");
            Walls.RandomlyGenerate();
        }

        public Map(string mapName)
        {
            Tileset = new Tileset();
            this.Name = mapName;
            properties = new MapProperty[1];
            properties[0] = new MapProperty("name", this.Name);
            Floor = new Layer("Tile Layer 1");
            Walls = new WallLayer("Tile Layer 2");
            Walls.RandomlyGenerate();
        }
    }
}
