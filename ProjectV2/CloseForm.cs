using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectV2
{
    public partial class CloseForm : Form
    {
        public CloseForm(MainMdiForm parent)
        {
            InitializeComponent();
            this.label1.Font = new Font(parent.myFonts.Families[1], 20, FontStyle.Regular);
            this.yesButton.Font = new Font(parent.myFonts.Families[1], 16, FontStyle.Regular);
            this.noButton.Font = new Font(parent.myFonts.Families[1], 16, FontStyle.Regular);
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
