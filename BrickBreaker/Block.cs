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
        public int hp;
        public Color colour;

        string currentLevel = "Level01";
        private static List<Block> Blocks = new List<Block>();

        public static Random rand = new Random();

        public Block(int _x, int _y, int _hp, Color _colour)
        {
            x = _x;
            y = _y;
            hp = _hp;
            colour = _colour;
        }

        private void LoadBlocks()
        {
            string newX, newY, newHp, newColour;

            //Open the XML file and place it in reader 
            XmlReader reader = XmlReader.Create($"{currentLevel}.xml");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)

                {
                    newX = reader.ReadString();
                    int blockX = Convert.ToInt32(newX);

                    reader.ReadToNextSibling("y");
                    newY = reader.ReadString();
                    int blockY = Convert.ToInt32(newY);

                    reader.ReadToNextSibling("hp");
                    newHp = reader.ReadString();
                    int blockHp = Convert.ToInt32(hp);

                    reader.ReadToNextSibling("colour");
                    newColour = reader.ReadString();
                    Color blockColour = Color.FromName(newColour); // potential error source later on

                    Block b = new Block(blockX, blockY, blockHp, blockColour);
                    Blocks.Add(b);
                }
            }
        }
    }
}
