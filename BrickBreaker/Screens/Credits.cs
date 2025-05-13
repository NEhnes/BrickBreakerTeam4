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
    public partial class Credits : UserControl
    {
        public Credits()
        {
            InitializeComponent();
        }

        private void backButtonC_Click(object sender, EventArgs e)
        {
            if (OptionsScreenL.light == true)
            {
                Form f = this.FindForm();

                Screens.OptionsScreenL os = new Screens.OptionsScreenL();
                f.Controls.Add(os);

                os.Location = new Point((this.Width - os.Width) / 2, (this.Height - os.Height) / 2);
                os.Show();

                f.Controls.Remove(this);
            }
            else
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
}
