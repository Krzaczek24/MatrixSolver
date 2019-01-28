using System.Drawing;
using System.Windows.Forms;

namespace ProjectV2
{
    public partial class MatrixOtherDetailsForm : Form
    {
        public MatrixOtherDetailsForm(MainMdiForm parent)
        {
            InitializeComponent();

            foreach (Label label in this.Controls)
            {
                label.Font = new Font(parent.myFonts.Families[parent.myFontStyle], label.Font.Size);
            }

            this.rank.Text = parent.matrixRank(parent.mainMatrix, parent.size).ToString();
            this.trace.Text = parent.matrixTrace(parent.mainMatrix, parent.size).ToString();
            this.sum.Text = parent.matrixSum(parent.mainMatrix, parent.size).ToString();
            this.determinant.Text = parent.determinant(parent.mainMatrix, parent.size).ToString();
        }
    }
}