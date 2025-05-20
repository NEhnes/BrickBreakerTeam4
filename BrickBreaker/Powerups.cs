using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Drawing;

namespace BrickBreaker
{
    internal class Powerup
    {
        public int x, y, size;
        public string type;
        public SolidBrush brush;

        public Powerup(int x, int y, string type)
        {
            this.x = x;
            this.y = y;
            this.size = 15;
            this.type = type;

            // Set color based on type
            if (type == "ExtraLife") brush = new SolidBrush(Color.Green);
            else if (type == "SpeedBoost") brush = new SolidBrush(Color.Blue);
            else if (type == "BigPaddle") brush = new SolidBrush(Color.Orange);
            else if (type == "SpeedReduction") brush = new SolidBrush(Color.Red);
            else if (type == "BulletBoost") brush = new SolidBrush(Color.Yellow);
            else brush = new SolidBrush(Color.Gray); // default
        }

        public void Move()
        {
            y += 2;
        }
        public void Draw(Graphics g)
        {
            g.FillEllipse(brush, x, y, size, size);
        }
    }
}

