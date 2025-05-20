/*  Created by: Liam, Sean, Nathan, Aaron
 *  Project: Brick Breaker
 *  Date: May '25
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
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Runtime.CompilerServices;

namespace BrickBreaker
{
    public partial class GameScreen : UserControl
    {
        #region global values

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, rightArrowDown, spacebar;

        // Game values
        int lives;

        // Paddle and Ball objects
        Paddle paddle;
        Ball ball;

        // Ball Colour
        public static Color ballColor = Color.White;

        // list of all blocks for current level
        List<Block> blocks = new List<Block>();
        string currentLevel = "Level1";

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(ballColor);


        List<Powerup> powerups = new List<Powerup>();
        Random rand = new Random();

        SoundPlayer popPlayer = new SoundPlayer(Properties.Resources.popSound);
        System.Windows.Media.MediaPlayer gameSound = new System.Windows.Media.MediaPlayer();

        #endregion

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
            LoadBlocks();

            gameSound.Open(new Uri(Application.StartupPath + "/Resources/backMusic.wav"));
            gameSound.MediaEnded += new EventHandler(gameSound_MediaEnded);
        }


        public void OnStart()
        {

            //set life counter
            lives = 3;

            // run opening UI and UX code
            LFischStart();
            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;

            // setup starting paddle values and create paddle object
            int paddleWidth = 80;
            int paddleHeight = 20;
            int paddleX = ((this.Width / 2) - (paddleWidth / 2));
            int paddleY = (this.Height - paddleHeight) - 60;
            int paddleSpeed = 15;
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);

            // setup starting ball values
            int ballSize = 20;
            int ballX = paddle.x + paddleWidth / 2 - ballSize / 2;
            int ballY = paddle.y - ballSize - 2;

            // Creates a new ball
            int xSpeed = 6;
            int ySpeed = 6;
            double speedMultiplier = 0.8; // speed multiplier for ball speed -> still buggy for values > 1. 
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize, speedMultiplier); // added parameter
        }

        public void LFischStart()
        {
            gameSound.Play();

            lifeLabel.Text = $"{lives}";
            string fontFilePath;
            PrivateFontCollection font = new PrivateFontCollection();
            byte[] fontData = Properties.Resources.DynaPuff_VariableFont_wdth_wght;
            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            font.AddMemoryFont(fontPtr, fontData.Length);

            Random randBG = new Random();

            int backImg = randBG.Next(1, 11);

            if (backImg <= 8)
            {
                BackgroundImage = Properties.Resources.BasicImage;
            }
            else if (backImg == 9)
            {
                BackgroundImage = Properties.Resources.SpecImage1;
            }
            else
            {
                BackgroundImage = Properties.Resources.SpecImage2;
            }
        }

        private void gameSound_MediaEnded(object sender, EventArgs e)
        {
            gameSound.Stop();
            gameSound.Play();
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
                case Keys.Space:
                    spacebar = true;
                    gameTimer.Enabled = true; // start the game timer
                        break;
                case Keys.Escape:
                    OnEnd();
                    break;
                case Keys.Tab:
                    gameTimer.Enabled = !gameTimer.Enabled;
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
                case Keys.Space:
                    spacebar = false;
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

                gameTimer.Enabled = false;

                if (lives == 0)
                {
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

                    popPlayer.Play();

                    if (blocks.Count == 0)
                    {
                        gameTimer.Enabled = false;
                        OnEnd();
                    }
                    // Block was hit — now spawn a powerup
                    if (rand.Next(0, 100) < 25) // 20% chance
                    {
                        string[] types = { "ExtraLife", "SpeedBoost", "BigPaddle" };
                        string type = types[rand.Next(types.Length)];

                        Powerup newPowerup = new Powerup(b.x, b.y, type);
                        powerups.Add(newPowerup);
                    }


                    break;
                }
            }

            // Update ball color
            ballBrush = new SolidBrush(ballColor);


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
                Rectangle recNumber = new Rectangle(b.x, b.y, b.width, b.height);

                if (b.colour == Color.Red)
                {
                    e.Graphics.DrawImage(Properties.Resources.redCoral, recNumber);
                }
                else if (b.colour == Color.Blue)
                {
                    e.Graphics.DrawImage(Properties.Resources.blueCoral, recNumber);
                }
                else if (b.colour == Color.Pink)
                {
                    e.Graphics.DrawImage(Properties.Resources.pinkCoral, recNumber);
                }
                else if (b.colour == Color.Yellow)
                {
                    e.Graphics.DrawImage(Properties.Resources.yellowCoral, recNumber);
                }
                else if (b.colour == Color.Gray)
                {
                    e.Graphics.DrawImage(Properties.Resources.grayCoral, recNumber);
                }
            }

            // Draws ball
            e.Graphics.FillRectangle(ballBrush, ball.x, ball.y, ball.size, ball.size);

            foreach (Powerup p in powerups)
            {
                p.Draw(e.Graphics);
            }
        }

        private void LoadBlocks()
        {
            
            string newX, newY, newColour;

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

                    reader.ReadToNextSibling("colour");
                    newColour = reader.ReadString();
                    Color blockColour = Color.FromName(newColour); // potential error source later on

                    Block b = new Block(blockX, blockY, blockColour);
                    blocks.Add(b);
                }
            }
        }
    }
}