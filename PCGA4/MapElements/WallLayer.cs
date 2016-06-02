using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using PCGA4.Kruskal;

namespace PCGA4.MapElements
{
    public class WallLayer : Layer
    {
        public static readonly int ROOMSIZE = 3; // This is why maps need to be a multiple of 3. All "rooms" are 3x3

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
            this.tiles = new Tile[TotalLength];
            Random rnd = A4MapGenerator.RNG;
            Graph g = new Graph(this.Width / ROOMSIZE, this.Height / ROOMSIZE); // 
            Console.WriteLine("Randomly generating walls...");
            KruskalSolver k = new KruskalSolver(g);
            for(int i = 0; i < k.MST.Count; i++)
            {
                Edge e = k.MST[i];
                Point r1Origin = e.P1;
                Point r2Origin = e.P2;
                Point.Direction dir = Point.GetDirection(r1Origin, r2Origin);
                int[] r1Indices = getRoomIndices(r1Origin);
                int[] r2Indices = getRoomIndices(r2Origin);
                for(int z = 0; z < 9; z++)
                {
                    int r1Index = r1Indices[z];
                    int r2Index = r2Indices[z];
                    if(this.tiles[r1Index] == null)
                    {
                        this.tiles[r1Indices[z]] = new Tile(Tile.NORMALWALL);
                    }
                    if(this.tiles[r2Index] == null)
                    {
                        this.tiles[r2Indices[z]] = new Tile(Tile.NORMALWALL);
                    }
                }
                this.tiles[r1Indices[CENTER]].GID = Tile.EMPTY;
                this.tiles[r2Indices[CENTER]].GID = Tile.EMPTY;
                if(dir == Point.Direction.Right)
                {
                    this.tiles[r1Indices[CENTLEFT]].GID = -1;
                    this.tiles[r2Indices[CENTRIGHT]].GID = -1;
                }
                else if(dir == Point.Direction.Left)
                {
                    this.tiles[r1Indices[CENTRIGHT]].GID = -1;
                    this.tiles[r2Indices[CENTLEFT]].GID = -1;
                }
                else if(dir == Point.Direction.Up)
                {
                    this.tiles[r1Indices[BOTCENT]].GID = -1;
                    this.tiles[r2Indices[TOPCENT]].GID = -1;
                }
                else if (dir == Point.Direction.Down)
                {
                    this.tiles[r1Indices[TOPCENT]].GID = -1;
                    this.tiles[r2Indices[BOTCENT]].GID = -1;
                }
            }
            this.tiles[TotalLength - Width - 2].GID = Tile.DOOR;
        }

        int[] getRoomIndices(Point p)
        {
            int tileMapX = (p.X * ROOMSIZE) + 1;
            int tileMapY = (p.Y * ROOMSIZE) + 1;
            int centerIndex = getIndex(tileMapX, tileMapY);
            int[] ret = new int[9];
            ret[TOPLEFT] = getIndex(tileMapX - 1, tileMapY - 1); // top left
            ret[TOPCENT] = getIndex(tileMapX, tileMapY - 1); // top middle
            ret[TOPRIGHT] = getIndex(tileMapX + 1, tileMapY - 1); // top right
            ret[CENTLEFT] = getIndex(tileMapX - 1, tileMapY); // center left
            ret[CENTER] = getIndex(tileMapX, tileMapY); // center
            ret[CENTRIGHT] = getIndex(tileMapX + 1, tileMapY); // center right
            ret[BOTLEFT] = getIndex(tileMapX - 1, tileMapY + 1); // bottom left
            ret[BOTCENT] = getIndex(tileMapX, tileMapY + 1); // bottom center
            ret[BOTRIGHT] = getIndex(tileMapX + 1, tileMapY + 1); // bottom right
            return ret;
        }

        int getIndex(int x, int y)
        {
            return x + y * Width;
        }

        private static int TOPLEFT = 0;
        private static int TOPCENT = 1;
        private static int TOPRIGHT = 2;
        private static int CENTLEFT = 3;
        private static int CENTER = 4;
        private static int CENTRIGHT = 5;
        private static int BOTLEFT = 6;
        private static int BOTCENT = 7;
        private static int BOTRIGHT = 8;

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
