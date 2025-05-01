using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            // Goes to the game screen
            GameScreen gs = new GameScreen();
            Form form = this.FindForm();

            form.Controls.Add(gs);
            form.Controls.Remove(this);

            gs.Location = new Point((form.Width - gs.Width) / 2, (form.Height - gs.Height) / 2);
        }

        private void playButton_Enter(object sender, EventArgs e)
        {
            playButton.BackColor = Color.FromArgb(160, 49, 206, 170);
            exitButton.BackColor = Color.FromArgb(160, 0, 135, 153);
            optionsButton.BackColor = Color.FromArgb(141, 0, 74, 153);

        }

        private void exitButton_Enter(object sender, EventArgs e)
        {
            exitButton.BackColor = Color.FromArgb(160, 49, 206, 170);
            playButton.BackColor = Color.FromArgb(160, 0, 135, 153);
            optionsButton.BackColor = Color.FromArgb(141, 0, 74, 153);
        }

        private void optionsButton_Enter(object sender, EventArgs e)
        {
            optionsButton.BackColor = Color.FromArgb(160, 0, 135, 153);
            playButton.BackColor = Color.FromArgb(160, 0, 135, 153);
            exitButton.BackColor = Color.FromArgb(160, 0, 135, 153);
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            Screens.OptionsScreenL os = new Screens.OptionsScreenL();
        }
    }
}
