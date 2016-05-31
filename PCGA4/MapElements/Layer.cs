using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PCGA4.MapElements
{
    [XmlType("layer")]
    public class Layer
    {
        [XmlAttribute("name")]
        public string Name;
        [XmlAttribute("width")]
        public int Width;
        [XmlAttribute("height")]
        public int Height;

        [XmlArray("data")]
        public Tile[] tiles;

        public int TotalLength
        {
            get
            {
                return this.Width * this.Height;
            }
        }

        protected virtual void DefaultTiles()
        {
            this.tiles = new Tile[TotalLength];
            for(int i = 0; i < TotalLength; i++)
            {
                tiles[i] = new Tile();
            }
        }

        public Layer()
        {
            this.Name = "Tile Layer";
            this.Width = 16;
            this.Height = 16;
            DefaultTiles();
        }

        public Layer (string name)
        {
            this.Name = name;
            this.Width = 16;
            this.Height = 16;
            DefaultTiles();
        }

        public Layer (string name, int width, int height)
        {
            this.Name = name;
            this.Width = width;
            this.Height = height;
            DefaultTiles();
        }
    }
}
