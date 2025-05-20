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
    public partial class MenuScreenD : UserControl
    {
        public MenuScreenD()
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
            playButton.BackColor = Color.FromArgb(160, 48, 59, 207);
            exitButton.BackColor = Color.FromArgb(160, 11, 26, 155);
            optionsButton.BackColor = Color.FromArgb(0, 40, 84);

        }

        private void exitButton_Enter(object sender, EventArgs e)
        {
            playButton.BackColor = Color.FromArgb(160, 11, 26, 155);
            exitButton.BackColor = Color.FromArgb(160, 48, 59, 207);
            optionsButton.BackColor = Color.FromArgb(0, 40, 84);
        }

        private void optionsButton_Enter(object sender, EventArgs e)
        {
            optionsButton.BackColor = Color.FromArgb(160, 11, 26, 155);
            playButton.BackColor = Color.FromArgb(160, 11, 26, 155);
            exitButton.BackColor = Color.FromArgb(160, 11, 26, 155);
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();

            Screens.OptionsScreenD osd = new Screens.OptionsScreenD();
            f.Controls.Add(osd);
            osd.Location = new Point((this.Width - osd.Width) / 2, (this.Height - osd.Height) / 2);
            osd.Show();

            f.Controls.Remove(this);
        }
    }
}
