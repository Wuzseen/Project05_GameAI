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
                this.tiles[i] = new Tile();
            }
        }

        public void RandomlyGenerate()
        {
            Random rnd = A4MapGenerator.RNG;
            Console.WriteLine("Randomly generating map.");
            for(int i = 0; i < TotalLength; i++)
            {
                BorderType bt = checkBorder(i);
                if (bt != BorderType.None)
                {
                    tiles[i] = new Tile(BTToTile[bt]);
                }
                else
                {
                    tiles[i] = new Tile(Tile.EMPTY);
                }
            }
        }

        enum BorderType
        {
            None,
            V,
            H,
            TL,
            TR,
            BR,
            BL
        }

        private static readonly Dictionary<BorderType, int> BTToTile = new Dictionary<BorderType, int>
        {
            {BorderType.BL, Tile.BOTTOMLEFT},
            {BorderType.BR, Tile.BOTTOMRIGHT},
            {BorderType.TR, Tile.TOPRIGHT},
            {BorderType.TL, Tile.TOPLEFT},
            {BorderType.H, Tile.HORIZONTALWALL},
            {BorderType.V, Tile.VERTICALWALL},
        };

        BorderType checkBorder(int tileIndex)
        {
            int y = (int)(tileIndex / this.Width);
            int x = tileIndex - (y * this.Width);
            int right = this.Width - 1;
            int bottom = this.Height - 1;

            if(x == 0 && y == 0)
            {
                return BorderType.TL;
            }
            else if(x == right && y == 0)
            {
                return BorderType.TR;
            }
            else if(x == right && y == bottom)
            {
                return BorderType.BR;
            }
            else if(x == 0 && y == bottom)
            {
                return BorderType.BL;
            }
            else if(x == 0 || x == right)
            {
                return BorderType.V;
            }
            else if(y == 0 || y == bottom)
            {
                return BorderType.H;
            }
            else
            {
                return BorderType.None;
            }
        }

        public WallLayer() : base() { }

        public WallLayer(string name) : base(name) { }

        public WallLayer(string name, int width, int height) : base(name, width, height) { }
    }
}
