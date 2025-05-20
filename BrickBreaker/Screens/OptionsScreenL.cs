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
    public partial class OptionsScreenL : UserControl
    {
        public OptionsScreenL()
        {
            InitializeComponent();

            lightCheck.Checked = true;
            darkCheck.Checked = false;
        }
        public static bool light = true;

        private void darkCheck_CheckedChanged(object sender, EventArgs e)
        {
            lightCheck.Checked = false;
            light = false;

            Form f = this.FindForm();

            Screens.OptionsScreenD osd = new Screens.OptionsScreenD();
            f.Controls.Add(osd);
            osd.Location = new Point((this.Width - osd.Width) / 2, (this.Height - osd.Height) / 2);
            osd.Show();

            f.Controls.Remove(this);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();

            MenuScreen ms = new MenuScreen();
            ms.Location = new Point((f.Width - ms.Width) / 2, (f.Height - ms.Height)/2);
            ms.Show();

            f.Controls.Add(ms);
            f.Controls.Remove(this);
        }

        public void creditsLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            Credits cd = new Credits();

            cd.Show();

            f.Controls.Add(cd);
            f.Controls.Remove(this);
        }
    }
}
