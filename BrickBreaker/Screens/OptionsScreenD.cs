using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker.Screens
{
    public partial class OptionsScreenD : UserControl
    {
        public OptionsScreenD()
        {
            InitializeComponent();

            lightCheck.Checked = false;
            darkCheck.Checked = true;
        }

        private void lightCheck_CheckedChanged(object sender, EventArgs e)
        {
            darkCheck.Checked = false;
            OptionsScreenL.light = true;

            Form f = this.FindForm();

            Screens.OptionsScreenL os = new Screens.OptionsScreenL();
            f.Controls.Add(os);

            os.Location = new Point((this.Width - os.Width) / 2, (this.Height - os.Height) / 2);
            os.Show();

            f.Controls.Remove(this);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();

            MenuScreenD md = new MenuScreenD();
           
            md.Location = new Point((f.Width - md.Width) / 2, (f.Height - md.Height)/ 2);
            md.Show();

            f.Controls.Add(md);
            f.Controls.Remove(this);
        }

        private void creditsLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            Credits cd = new Credits();

            cd.Show();

            f.Controls.Add(cd);
            f.Controls.Remove(this);
        }
    }
}
