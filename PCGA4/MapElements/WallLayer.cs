using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PCGA4.MapElements
{
    public class WallLayer : Layer
    {
        protected override void DefaultTiles ()
        {
            this.tiles = new Tile[TotalLength];
            for(int i = 0; i < TotalLength; i++)
            {
                this.tiles[i] = new Tile(302);
            }
        }

        public WallLayer() : base() { }

        public WallLayer(string name) : base(name) { }

        public WallLayer(string name, int width, int height) : base(name, width, height) { }
    }
}
