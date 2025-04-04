using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nonogram.Views
{
    public partial class MenuControl : UserControl
    {
        public MenuControl()
        {
            InitializeComponent();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            Main.ChangeView("login", FindForm().Controls);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Main.ChangeView("game", FindForm().Controls);
        }
    }
}
