using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOut.Models
{
    public class TileIndex
    {
        public int x { get; set; }
        public int y { get; set; }

        public TileIndex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
