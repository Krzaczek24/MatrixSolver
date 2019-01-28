using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectV2
{
    public partial class LinearEquationsResultForm : Form
    {
        private int state = 0;
        private int labelHeight = 30;
        private int labelWidth = 615;
        private int labelLeftMargin = 15;
        private int labelTopMargin = 15;
        private int oldCount = 0;
        private int countLabels = 0;
        private Color basicColor = Color.White;
        private Color secondColor = Color.Yellow;
        private Color faultColor = Color.Red;
        private Color successColor = Color.Chartreuse;

        private int mainDeterminant;
        private ArrayList determinants = new ArrayList();
        public LinearEquationsResultForm(MainMdiForm parent)
        {
            InitializeComponent();

            for (int r = 0; r < parent.size; r++)
            {
                Label label = new Label();
                label.Name = "value_" + r.ToString();

                for (int c = 0; c < parent.size; c++)
                {
                    label.Text += Math.Abs(parent.mainMatrix[r, c]).ToString() + (char)(97 + c);
                    if (c < parent.size - 1)
                    {
                        if(parent.mainMatrix[r, c + 1] < 0) label.Text += " - ";
                        else label.Text += " + ";
                    }
                    else label.Text += " = ";
                }

                label.Text += parent.mainMatrix[r, parent.size];

                setLabel(parent, label, basicColor);
            }

            int determinant = Convert.ToInt32(parent.determinant(parent.mainMatrix, parent.size));
            if ((this.mainDeterminant = determinant) == 0) state = 1;

            Label label1 = new Label();
            label1.Name = "det";
            label1.Text += "Det(macierz) = " + determinant;
            setLabel(parent, label1, secondColor);

            Label label2 = new Label();
            label2.Name = "state0";
            if (state == 0)
            {
                label2.Text += "Układ oznaczony  [dokładnie jedno rozwiązanie]";
                setLabel(parent, label2, successColor);
            }
            else
            {
                label2.Text += "Układ nie jest oznaczony  [nieoznaczony lub sprzeczny]";
                setLabel(parent, label2, faultColor);
            }

            for (int i = 0; i < parent.size; i++)
            {
                if ((determinant = Convert.ToInt32(parent.determinant(parent.matrixSwapColumn(parent.mainMatrix, parent.size, i), parent.size))) != 0 && state != 0) state = 2;
                else determinants.Add(determinant);

                Label label = new Label();
                label.Name = "det_" + (char)(65 + i);
                label.Text += "Det" + (char)(65 + i) + "(macierz) = " + determinant;
                setLabel(parent, label, secondColor);
            }

            if (state != 0)
            {
                Label label3 = new Label();
                label3.Name = "state1";
                if (state == 2) label3.Text += "Układ sprzeczny  [nie posiada rozwiazań]";
                else label3.Text += "Układ nieoznaczony  [nieskończenie wiele rozwiazań]";
                setLabel(parent, label3, faultColor);
            }
            else
            {
                countLabels -= parent.size;

                for (int i = 0; i < parent.size; i++)
                {
                    Label label3 = new Label();
                    label3.Name = "result_" + (char)(65 + i);
                    label3.Text += (char)(97 + i) + " = " + Convert.ToDouble(determinants[i])/mainDeterminant;
                    setLabel(parent, label3, basicColor);
                }
            }

            this.Width = 2 * labelLeftMargin + labelWidth;
            this.Height = (countLabels + 1) * labelHeight + 2 * labelTopMargin;
        }

        private void setLabel(MainMdiForm parent, Label label, Color color)
        {
            label.Size = new Size(countLabels < parent.size + 2 || state != 0 ? labelWidth : labelWidth / 2, labelHeight - 5);
            label.Location = new Point(labelLeftMargin + (countLabels < oldCount ? labelWidth / 2 + labelLeftMargin : 0), countLabels++ * labelHeight + labelTopMargin);
            label.UseCompatibleTextRendering = true;
            label.Font = new Font(parent.myFonts.Families[parent.myFontStyle], 16);
            label.ForeColor = color;
            label.BackColor = Color.Transparent;
            this.Controls.Add(label);

            if (countLabels >= oldCount) oldCount = countLabels;
        }
    }
}
