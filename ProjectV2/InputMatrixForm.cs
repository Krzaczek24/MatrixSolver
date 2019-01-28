using System.Windows.Forms;
using System.Drawing;
using System;

namespace ProjectV2
{
    public partial class InputMatrixForm : Form
    {
        MainMdiForm parent;
        private int size;
        private bool mode;

        int borderWidth = 7;
        int marginTop = 80;
        int marginLeft = 20;
        int sizeDependedMarginLeft = 0;
        int cellSpace = 10;
        int cellWidth = 35;
        int cellHeight = 40;

        public InputMatrixForm(MainMdiForm parent, bool isLinearEquationsMode)
        {
            InitializeComponent();
            this.parent = parent;
            this.mode = isLinearEquationsMode;

            if (isLinearEquationsMode)
            {
                this.Text = "Układ równań liniowych";
                this.label.Text = "Niewiadomych:";
            }
            else
            {
                this.Text = "Własności macierzy";
                this.label.Text = "Wymiar macierzy:";
            }

            this.label.Font = new Font(parent.myFonts.Families[parent.myFontStyle], 22);
        }

        private void generateMatrix()
        {
            Size initialSize = new Size(360, 120);
            Size oldSize = this.Size;

            this.Controls.Clear();
            this.Controls.Add(this.sizeInput);
            this.Controls.Add(this.label);
            this.sizeInput.Focus();

            if (Int32.TryParse(this.sizeInput.Text, out size))
            {
                int modeDependedVariable = 6 + (mode ? 0 : 1);

                if (size > modeDependedVariable) this.Width = 2 * marginLeft + (size + (mode ? 1 : 0)) * (cellWidth + cellSpace) - cellSpace + 2 * borderWidth;
                else this.Width = initialSize.Width;

                sizeDependedMarginLeft = (this.Width - ((size + (mode ? 1 : 0)) * (cellWidth + cellSpace))) / 2;

                for (int r = 0; r < size; r++)
                {
                    for (int c = 0; c < size + (mode ? 1 : 0); c++)
                    {
                        TextBox textBox = new TextBox();
                        textBox.Name = "value_" + r.ToString() + "_" + c.ToString();
                        textBox.Size = new Size(cellWidth, cellHeight);
                        textBox.Location = new Point(c * (cellWidth + cellSpace) + sizeDependedMarginLeft - 3, r * (cellHeight + cellSpace) + marginTop);
                        textBox.Font = new Font(new FontFamily("Tempus Sans ITC"), 20);
                        textBox.TextAlign = HorizontalAlignment.Center;
                        this.Controls.Add(textBox);
                    }
                }

                if (size > 0)
                {
                    this.Height = initialSize.Height + (size + 1) * (cellHeight + cellSpace);
                    Button solve = new Button();
                    solve.Name = "solveButton";
                    solve.Location = new Point(marginLeft, marginTop + size * (cellHeight + cellSpace));
                    solve.Size = new Size(this.Width - 2 * marginLeft - 16, cellHeight);
                    solve.Text = mode ? "Oblicz niewiadome" : "Sprawdź właściwości";
                    solve.TextAlign = ContentAlignment.MiddleCenter;
                    solve.UseVisualStyleBackColor = false;
                    solve.BackColor = Color.DimGray;
                    solve.ForeColor = Color.White;
                    solve.Font = new Font(parent.myFonts.Families[1], 12, FontStyle.Regular);

                    solve.Click += new EventHandler(this.solve_Click);
                    this.Controls.Add(solve);
                }
                else this.Height = initialSize.Height;
            }
            else this.Width = initialSize.Width;

            this.sizeInput.Location = new Point(this.Width - 2 * borderWidth - marginLeft - this.sizeInput.Width, this.sizeInput.Location.Y);

            this.Location = new Point(this.Location.X - ((this.Size.Width - oldSize.Width) / 2), this.Location.Y - ((this.Size.Height - oldSize.Height) / 2));
        }

        private void solve_Click(object sender, EventArgs e)
        {
            this.parent.size = size;

            this.parent.mainMatrix = new int[size, size + (mode ? 1 : 0)];

            int r = 0;
            int c = 0;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    if (c > size - (mode ? 0 : 1))
                    {
                        c = 0;
                        r++;
                    }

                    if (!Int32.TryParse(((TextBox)ctrl).Text, out this.parent.mainMatrix[r, c])) this.parent.mainMatrix[r, c] = 0;

                    c++;
                }
            }

            if (mode)
            {
                LinearEquationsResultForm linearEquationsResult = new LinearEquationsResultForm(this.parent);
                if (this.parent.myStyle > 0) linearEquationsResult.MdiParent = this.parent;
                linearEquationsResult.Closed += (s, args) => this.Close();
                this.Hide();
                linearEquationsResult.Show();
            }
            else
            {
                int space;
                Point dimensions;
                Point coordinate;

                if (parent.myStyle > 0)
                {
                    space = 5;
                    dimensions = new Point((parent.Size.Width - 40) / 3, (parent.Size.Height - 80) / 2);
                    coordinate = new Point(space, space);
                }
                else
                {
                    space = 100;
                    dimensions = new Point((parent.Size.Width - 40) / 3, (parent.Size.Height - 80) / 2);
                    coordinate = new Point(this.parent.Location.X + space, this.parent.Location.Y + space);
                }
                 


                ShowMatrixForm showEnteredMatrix = new ShowMatrixForm(this.parent, this.parent.mainMatrix);
                showEnteredMatrix.StartPosition = FormStartPosition.Manual;
                showEnteredMatrix.Size = new Size(dimensions);
                showEnteredMatrix.Location = coordinate;
                showEnteredMatrix.Text = "Macierz";
                if (this.parent.myStyle > 0) showEnteredMatrix.MdiParent = this.parent;
                showEnteredMatrix.Closed += (s, args) => this.Close();

                coordinate.X += dimensions.X + space;

                ShowMatrixForm showTransposedMatrix = new ShowMatrixForm(this.parent, this.parent.transposedMatrix(this.parent.mainMatrix, size));
                showTransposedMatrix.StartPosition = FormStartPosition.Manual;
                showTransposedMatrix.Size = new Size(dimensions);
                showTransposedMatrix.Location = coordinate;
                showTransposedMatrix.Text = "Macierz transponowana";
                if (this.parent.myStyle > 0) showTransposedMatrix.MdiParent = this.parent;
                showTransposedMatrix.Closed += (s, args) => this.Close();

                coordinate.X += dimensions.X + space;

                ShowMatrixForm showAlgebraicComplementsMatrix = new ShowMatrixForm(this.parent, this.parent.algebraicComplementsMatrix(this.parent.mainMatrix, size));
                showAlgebraicComplementsMatrix.StartPosition = FormStartPosition.Manual;
                showAlgebraicComplementsMatrix.Size = new Size(dimensions);
                showAlgebraicComplementsMatrix.Location = coordinate;
                showAlgebraicComplementsMatrix.Text = "Macierz dopełnień algebraicznych";
                if (this.parent.myStyle > 0) showAlgebraicComplementsMatrix.MdiParent = this.parent;
                showAlgebraicComplementsMatrix.Closed += (s, args) => this.Close();

                coordinate.X = space;

                coordinate.Y += space + dimensions.Y;

                ShowMatrixForm showInvertedMatrix = new ShowMatrixForm(this.parent, this.parent.invertedMatrix(this.parent.mainMatrix, size));
                showInvertedMatrix.StartPosition = FormStartPosition.Manual;
                showInvertedMatrix.Size = new Size(dimensions);
                showInvertedMatrix.Location = coordinate;
                showInvertedMatrix.Text = "Macierz odwrotna";
                if (this.parent.myStyle > 0) showInvertedMatrix.MdiParent = this.parent;
                showInvertedMatrix.Closed += (s, args) => this.Close();

                coordinate.X += dimensions.X + space;

                ShowMatrixForm showGaussianEliminationMatrix = new ShowMatrixForm(this.parent, this.parent.gaussianEliminationMatrix(this.parent.mainMatrix, size));
                showGaussianEliminationMatrix.StartPosition = FormStartPosition.Manual;
                showGaussianEliminationMatrix.Size = new Size(dimensions);
                showGaussianEliminationMatrix.Location = coordinate;
                showGaussianEliminationMatrix.Text = "Macierz po eliminacji gaussa";
                if (this.parent.myStyle > 0) showGaussianEliminationMatrix.MdiParent = this.parent;
                showGaussianEliminationMatrix.Closed += (s, args) => this.Close();

                coordinate.X += dimensions.X + space;

                MatrixOtherDetailsForm showMatrixOtherDetails = new MatrixOtherDetailsForm(this.parent);
                showMatrixOtherDetails.StartPosition = FormStartPosition.Manual;
                showMatrixOtherDetails.Size = new Size(dimensions);
                showMatrixOtherDetails.Location = coordinate;
                if (this.parent.myStyle > 0) showMatrixOtherDetails.MdiParent = this.parent;
                showMatrixOtherDetails.Closed += (s, args) => this.Close();

                this.Hide();
                showEnteredMatrix.Show();
                showTransposedMatrix.Show();
                showAlgebraicComplementsMatrix.Show();
                showInvertedMatrix.Show();
                showGaussianEliminationMatrix.Show();
                showMatrixOtherDetails.Show();
            }
        }

        private void sizeInput_ValueChanged(object sender, EventArgs e)
        {
            generateMatrix();
        }
    }
}
