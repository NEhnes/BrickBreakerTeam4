using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Ball
    {
        public int size;
        public int xSpeed, ySpeed, x, y;
        public bool belowPaddle;
        public bool madeContactLastTick;
        public Color colour;

        public static Random rand = new Random();
        public double speedMultiplier;

        public Ball(int _x, int _y, int _xSpeed, int _ySpeed, int _ballSize, double _speedMultiplier)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            speedMultiplier = _speedMultiplier;
            size = _ballSize;

        }

        public void Move()
        {
            x =  (int)(x + xSpeed * speedMultiplier);
            y = (int)(y + ySpeed * speedMultiplier);
        }

        public bool BlockCollision(Block b)
        {
            Rectangle blockRec = new Rectangle(b.x, b.y, b.width, b.height);
            Rectangle ballRec = new Rectangle(x, y, size, size);

            if (ballRec.IntersectsWith(blockRec))
            {
                Rectangle intersection = Rectangle.Intersect(ballRec, blockRec); // get the intersection rectangle

                if (intersection.Width > intersection.Height) // if the intersection is wider than it is tall
                {
                    // if left or right
                    ySpeed *= -1;
                }
                else // if the intersection is taller than it is wide
                {
                    // if top or bottom
                    xSpeed *= -1;
                }
            }

            return blockRec.IntersectsWith(ballRec);
        }

        public void PaddleCollision(Paddle p) // working with a few simple directions + a few bugs
        {
            //create rectangles for collision
            Rectangle ballRec = new Rectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);

            belowPaddle = (y + size - ySpeed > p.y); // true if below

            double measuredContactPoint; // ball x, relative to paddle x (0-100)

            if (ballRec.IntersectsWith(paddleRec)) //TODO: replace with intersect code from block
            {

                if (!belowPaddle) // is at top of paddle, bounce up
                {

                    measuredContactPoint = (x - p.x + size);
                    Console.Out.WriteLine("measured: " + measuredContactPoint);

                    // <20, 20-40, 40-50, 50-60, 60-80, 80-100
                    // 6 cases to determine ball deflection

                    if (measuredContactPoint < 20)
                    {
                        xSpeed = -7;
                        ySpeed = -4;
                    } 
                    else if (measuredContactPoint < 40)
                    {
                        xSpeed = -6;
                        ySpeed = -6;
                    } 
                    else if (measuredContactPoint < 50)
                    {
                        xSpeed = -4;
                        ySpeed = -7;
                    } 
                    else if (measuredContactPoint < 60)
                    {
                        xSpeed = 4;
                        ySpeed = -7;
                    } 
                    else if (measuredContactPoint < 80)
                    {
                        xSpeed = 6;
                        ySpeed = -6;
                    } 
                    else
                    {
                        xSpeed = 7;
                        ySpeed = -4;
                    }
                }
                else if (belowPaddle && !madeContactLastTick) // is below top of paddle and didnt contact paddle last tick
                {
                    xSpeed *= -1;
                }
                madeContactLastTick = true;
            }
            else
            {
                madeContactLastTick = false;
            }
        }

        public void WallCollision(UserControl UC) //good as far as can tell
        {
            // Collision with left wall
            if (x <= 0)
            {
                x = 0;
                xSpeed *= -1;
            }
            // Collision with right wall
            if (x >= (UC.Width - size))
            {
                x = UC.Width - size;
                xSpeed *= -1;
            }
            // Collision with top wall
            if (y <= 2)
            {
                y = 2;
                ySpeed *= -1;
            }
        }

        public bool BottomCollision(UserControl UC) // good as far as can tell
        {
            Boolean didCollide = false;

            if (y >= UC.Height)
            {
                didCollide = true;
            }

            return didCollide;
        }

        public static double Map (double value, double fromMin, double fromMax, double newMin, double newMax)
        {
            return (value - fromMin) * (newMax - newMin) / (fromMax - fromMin) + newMin;
        }


    }
}
