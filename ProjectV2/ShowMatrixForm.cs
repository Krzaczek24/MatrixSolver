using System.Drawing;
using System.Windows.Forms;

namespace ProjectV2
{
    public partial class ShowMatrixForm : Form
    {
        public ShowMatrixForm(MainMdiForm parent, int[,] matrix)
        {
            InitializeComponent();
            parent.count = (++parent.count) % 2;

            if (matrix == null) determinantZero(parent);
            else
            {
                for (int r = 0; r < parent.size; r++)
                {
                    for (int c = 0; c < parent.size; c++)
                    {
                        Label label = new Label();
                        label.Text = matrix[r, c].ToString();
                        setLabel(parent, label, r, c);
                    }
                }
            }
        }

        public ShowMatrixForm(MainMdiForm parent, double[,] matrix)
        {
            InitializeComponent();
            parent.count = (++parent.count) % 2;

            if (matrix == null) determinantZero(parent);
            else
            {
                for (int r = 0; r < parent.size; r++)
                {
                    for (int c = 0; c < parent.size; c++)
                    {
                        Label label = new Label();
                        label.Text = (System.Math.Round(matrix[r, c], 2)).ToString();

                        setLabel(parent, label, r, c);
                    }
                }
            }
        }

        private void setLabel(MainMdiForm parent, Label label, int r, int c)
        {
            int[] fontSizes = { 120, 46, 30, 22, 18, 15, 13, 11, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int cellHeight = (this.Height + parent.size) / parent.size;
            int cellWidth = (this.Width + parent.size) / parent.size;

            label.BorderStyle = BorderStyle.Fixed3D;
            label.Name = "value_" + r.ToString() + "_" + c.ToString();
            label.UseCompatibleTextRendering = true;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BackColor = Color.Transparent;
            label.AutoSize = false;
            label.Size = new Size(cellWidth, cellHeight);
            label.Location = new Point(c * cellWidth, r * cellHeight);
            label.Font = new Font(parent.myFonts.Families[parent.myFontStyle], fontSizes[parent.size - 1]);
            label.ForeColor = ((r + c + parent.count) % 2 == 0 ? Color.Gold : Color.White);
            this.Controls.Add(label);
        }

        private void determinantZero(MainMdiForm parent)
        {
            Label label = new Label();
            label.Name = "noInvertedMatrix";
            label.BackColor = Color.Transparent;
            label.AutoSize = false;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Size = new Size(400, 320);
            label.Location = new Point(0, 0);
            label.Font = new Font(parent.myFonts.Families[3], 24);
            label.ForeColor = Color.Red;
            label.Text += "Wyznacznik równy 0, nie można wyznaczyć macierzy odwrotnej";
            this.Controls.Add(label);
        }
    }
}
