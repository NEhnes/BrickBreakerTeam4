using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml;

namespace BrickBreaker
{
    public class Block
    {
        public int width = 32;
        public int height = 32;

        public int x;
        public int y;
        public Color colour;


        public Block(int _x, int _y, Color _colour)
        {
            x = _x;
            y = _y;
            colour = _colour;
        }
    }
}
