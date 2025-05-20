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
        public bool lastHitPaddle;
        public Color colour;

        public static Random rand = new Random();
        public double speedMultiplier;
        private Color[] colorCycle = {Color.DeepPink, Color.Black, Color.White};
        private int moveCounter = 0;
        private int colorIndex = 0;

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
            x = (int)(x + xSpeed * GameScreen.speedMultiplier);
            y = (int)(y + ySpeed * GameScreen.speedMultiplier);

            moveCounter++;
            if (moveCounter > 100) moveCounter = 0;
        }

        public bool BlockCollision(Block b) // fixed :)
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
                lastHitPaddle = false;
            }

            return blockRec.IntersectsWith(ballRec);
        }

        public void PaddleCollision(Paddle p) // fixed :)
        {
            //create rectangles for collision
            Rectangle ballRec = new Rectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);

            belowPaddle = (y + size - ySpeed > p.y); // true if below

            double measuredContactPoint; // ball x, relative to paddle x (0-100)

            if (ballRec.IntersectsWith(paddleRec) && !lastHitPaddle)
            {

                Rectangle intersection = Rectangle.Intersect(ballRec, paddleRec);

                if (intersection.Width > intersection.Height) // top contact
                {

                    measuredContactPoint = (x - p.x + size);
                    Console.Out.WriteLine("measured: " + measuredContactPoint);

                    // 6 cases to determine ball deflection
                    int maxWidth = p.width + size; // added for compatability with various paddle sizes

                    y = p.y - size; // move ball to top of paddle

                    if (measuredContactPoint < 0.2 * maxWidth)
                    {
                        xSpeed = -7;
                        ySpeed = -4;
                    }
                    else if (measuredContactPoint < 0.4 * maxWidth)
                    {
                        xSpeed = -6;
                        ySpeed = -6;
                    }
                    else if (measuredContactPoint < 0.5 * maxWidth)
                    {
                        xSpeed = -4;
                        ySpeed = -7;
                    }
                    else if (measuredContactPoint < 0.6 * maxWidth)
                    {
                        xSpeed = 4;
                        ySpeed = -7;
                    }
                    else if (measuredContactPoint < 0.8 * maxWidth)
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
                else // side contact
                {
                    y = p.y + size; //move ball to bottom of paddle

                    xSpeed *= -1; // bounce off side
                }
                lastHitPaddle = true;
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
            lastHitPaddle = false;
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

        public void LaunchBall(int _launchangle)
        {

        }

        public void CycleBallColor()
        {
            GameScreen.ballColor = colorCycle[colorIndex];
            colorIndex++;
            if (colorIndex == colorCycle.Length) { colorIndex = 0; };
        }
    }
}
