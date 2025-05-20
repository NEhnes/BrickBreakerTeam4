/*  Created by: 
 *  Project: Brick Breaker
 *  Date: 
 */ 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace BrickBreaker
{
    public partial class GameScreen : UserControl
    {
        #region global values
        bool piercingBall = false;
      

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, rightArrowDown;

        // Game values
        int lives;

        // Paddle and Ball objects
        Paddle paddle;
        Ball ball;
        

        // list of all blocks for current level
        List<Block> blocks = new List<Block>();

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);
        SolidBrush blockBrush = new SolidBrush(Color.Red);

        List<Powerup> powerups = new List<Powerup>();
        Random rand = new Random();

        #endregion

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }


        public void OnStart()
        {
            //set life counter
            lives = 3;

            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;

            // setup starting paddle values and create paddle object
            int paddleWidth = 80;
            int paddleHeight = 20;
            int paddleX = ((this.Width / 2) - (paddleWidth / 2));
            int paddleY = (this.Height - paddleHeight) - 60;
            int paddleSpeed = 8;
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);

            // setup starting ball values
            int ballX = this.Width / 2 - 10;
            int ballSize = 20;
            int ballY = this.Height - paddle.height - 80 - ballSize;

            // Creates a new ball
            int xSpeed = 6;
            int ySpeed = 6;
            double speedMultiplier = 1; // speed multiplier for ball speed -> still buggy for values > 1. 
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize, speedMultiplier); // added parameter

            #region Creates blocks for generic level. Need to replace with code that loads levels.
            
            //TODO - replace all the code in this region eventually with code that loads levels from xml files
            
            blocks.Clear();
            int x = 10;

            while (blocks.Count < 12)
            {
                x += 57;
                Block b1 = new Block(x, 10, 1, Color.White);
                blocks.Add(b1);
            }

            #endregion

            // start the game engine loop
            gameTimer.Enabled = true;
          


        }

        public void LFischStart()
        {
            //BackgroundImage = Properties.Resources.basicImage
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // Move the paddle
            if (leftArrowDown && paddle.x > 0)
            {
                paddle.Move("left");
            }
            if (rightArrowDown && paddle.x < (this.Width - paddle.width))
            {
                paddle.Move("right");
            }

            // Move ball
            ball.Move();

            // Check for collision with top and side walls
            ball.WallCollision(this);

            // Check for ball hitting bottom of screen
            if (ball.BottomCollision(this))
            {
                lives--;

                // Moves the ball back to origin
                ball.x = ((paddle.x - (ball.size / 2)) + (paddle.width / 2));
                ball.y = (this.Height - paddle.height) - 85;

                if (lives == 0)
                {
                    gameTimer.Enabled = false;
                    OnEnd();
                }
            }

            // Check for collision of ball with paddle, (incl. paddle movement)
            ball.PaddleCollision(paddle);

            // Check if ball has collided with any blocks
            foreach (Block b in blocks)
            {
                if (ball.BlockCollision(b))
                {
                    blocks.Remove(b);

                    if (blocks.Count == 0)
                    {
                        gameTimer.Enabled = false;
                        OnEnd();
                    }
                    // Block was hit — now spawn a powerup
                    if (rand.Next(0, 100) < 25) // 20% chance
                    {
                        string[] types = { "ExtraLife", "SpeedBoost", "SpeedReduction", "BigPaddle", "BulletBoost" };
                        string type = types[rand.Next(types.Length)];

                        Powerup newPowerup = new Powerup(b.x, b.y, type);
                        powerups.Add(newPowerup);
                    }


                    break;
                }
            }
            Rectangle ballRect = new Rectangle(ball.x, ball.y, ball.size, ball.size);
            for (int i = blocks.Count - 1; i >= 0; i--)
            {
                Block b = blocks[i];
                Rectangle blockRect = new Rectangle(b.x, b.y, b.width, b.height);

                if (ballRect.IntersectsWith(blockRect))
                {
                    blocks.RemoveAt(i);

                    if (!piercingBall)
                    {
                        // Reverse ball direction if not piercing
                        ball.speedMultiplier *= -1;
                        break; // Exit loop so only one block is hit
                    }
                    // If piercing, no bounce and continue checking next block
                }
            }

            foreach (Powerup p in powerups)
            {
                p.Move();
            }

            //redraw the screen
            Refresh();
        }

        public void OnEnd()
        {
            // Goes to the game over screen
            Form form = this.FindForm();
            MenuScreen ps = new MenuScreen();
            
            ps.Location = new Point((form.Width - ps.Width) / 2, (form.Height - ps.Height) / 2);

            form.Controls.Add(ps);
            form.Controls.Remove(this);
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // Draws paddle
            paddleBrush.Color = paddle.colour;
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);

            // Draws blocks
            foreach (Block b in blocks)
            {
                e.Graphics.FillRectangle(blockBrush, b.x, b.y, b.width, b.height);
            }

            // Draws ball
            e.Graphics.FillRectangle(ballBrush, ball.x, ball.y, ball.size, ball.size);

            foreach (Powerup p in powerups)
            {
                p.Draw(e.Graphics);
            }
        }
        private void ApplyPowerup(string type)
        {
            switch (type)
            {
                case "ExtraLife":
                    lives++; // Assuming you have a 'lives' variable
                    break;
                case "SpeedBoost":
                    ball.speedMultiplier += 2; // Assuming you have a 'ballSpeed' or similar
                    break;
                case "BigPaddle":
                    paddle.width += 40; // Temporarily increase paddle size
                    break;
                case "SpeedReduction":
                    ball.speedMultiplier = Math.Max(2, ball.speedMultiplier - 2); // Don't go below 2
                    break;
                case "BulletBoost":
                    piercingBall = true;

                    // Start a timer to turn it off after 5 seconds
                    piercingTimer.Interval = 5000;
                    piercingTimer.Tick += (s, e) =>
                    {
                        piercingBall = false;
                        piercingTimer.Stop();
                    };
                    piercingTimer.Start();
                    break;
            }
        }

    }
}
