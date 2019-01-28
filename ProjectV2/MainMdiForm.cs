using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace ProjectV2
{
    public partial class MainMdiForm : Form
    {
        public PrivateFontCollection myFonts = new PrivateFontCollection();

        public int myStyle = 3; //0 - ładnie + szybko || 1 - brzydko + wolno || 2 - tragedia + b. wolno || 3 - czysto & szybko
        public int myFontStyle = 3; //0 - aron_grotesque_regular || 3 - Punktype

        public DateTime solveStart;
        public bool solving = false;

        public int count = 0;
        public int size { get; set; }
        public int[,] mainMatrix { get; set; }

        public MdiClient mdiClient;
        public MainMdiForm()
        {
            InitializeComponent();
            InitializeFonts();
            foreach (Control ctrl in this.Controls) if (ctrl is MdiClient) this.mdiClient = (MdiClient)ctrl;

            if (myStyle >= 2)
            {
                this.BackgroundImage = null;
                this.mdiClient.BackColor = Color.FromArgb(30, 30, 30);
            }
            else
            {
                this.BackgroundImage = Properties.Resources.project_wallpaper2;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
        public double[,] gaussianEliminationMatrix(int[,] matrix, int size)
        {
            double[,] gaussianEliminationMatrix = new double[size, size];
            Array.Copy(matrix, gaussianEliminationMatrix, size * size);

            for (int r = 0; r < size; r++)
            {
                for (int next = r + 1; next < size; next++)
                {
                    if (gaussianEliminationMatrix[r, r] < gaussianEliminationMatrix[next, r])
                    {
                        for (int c = 0; c < size; c++) //sortowanie w kolumnie całymi wierszami - najmniejsza wartośc na górę
                        {
                            double temp = gaussianEliminationMatrix[r, c];
                            gaussianEliminationMatrix[r, c] = gaussianEliminationMatrix[next, c];
                            gaussianEliminationMatrix[next, c] = temp;
                        }
                    }
                }
            }

            for (int r = 0; r < size - 1; r++)
            {
                for (int next = r + 1; next < size; next++) //latamy po dolnej trójkątnej
                {
                    double factor = gaussianEliminationMatrix[next, r] / gaussianEliminationMatrix[r, r];
                    for (int c = 0; c < size; c++)
                    {
                        gaussianEliminationMatrix[next, c] -= factor * gaussianEliminationMatrix[r, c];
                    }
                }
            }

            return gaussianEliminationMatrix;
        }

        public double[,] invertedMatrix(int[,] matrix, int size)
        {
            double[,] ivertedMatrix = new double[this.size, this.size];

            int determinant = this.determinant(this.mainMatrix, this.size);

            if (determinant == 0) return null;
            else if (size == 1) ivertedMatrix[0, 0] = 1.0 / matrix[0, 0];
            else
            {
                Array.Copy(transposedMatrix(algebraicComplementsMatrix(matrix, size), size), ivertedMatrix, this.size * this.size);

                for (int r = 0; r < size; r++)
                {
                    for (int c = 0; c < size; c++)
                    {
                        ivertedMatrix[r, c] /= determinant;
                    }
                }
            }

            return ivertedMatrix;
        }

        public int[,] algebraicComplementsMatrix(int[,] matrix, int size)
        {
            int[,] algebraicComplementsMatrix = new int[size, size];

            if (size == 1) algebraicComplementsMatrix[0, 0] = 1;
            else
            {
                for (int r = 0; r < size; r++)
                {
                    for (int c = 0; c < size; c++)
                    {
                        algebraicComplementsMatrix[r, c] = determinant(matrix, size, r, c) * Convert.ToInt32(Math.Pow(-1, r + c));
                    }
                }
            }

            return algebraicComplementsMatrix;
        }

        public int[,] transposedMatrix(int[,] matrix, int size)
        {
            int[,] transposedMatrix = new int[size, size];

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    transposedMatrix[c, r] = matrix[r, c];
                }
            }

            return transposedMatrix;
        }

        public int determinant(int[,] matrix, int size, int row, int column)
        {
            if (size == 1) return matrix[0, 0];

            int[,] minor = new int[size - 1, size - 1];

            for (int r = 0; r < size; r++)
            {
                if (r == row) continue;

                for (int c = 0; c < size; c++)
                {
                    if (c == column) continue;

                    minor[r > row ? r - 1 : r, c > column ? c - 1 : c] = matrix[r, c];
                }
            }

            return determinant(minor, size - 1);
        }

        public int determinant(int[,] matrix, int size)
        {
            long result = 0;

            if (size > 3)
            {
                for (int selectedColumn = 0; selectedColumn < size; selectedColumn++)
                {
                    int[,] minor = new int[size - 1, size - 1];

                    for (int r = 1; r < size; r++)
                    {
                        for (int c = 0; c < size; c++)
                        {
                            if (c == selectedColumn) continue;
                            else if (c > selectedColumn) minor[r - 1, c - 1] = matrix[r, c];
                            else minor[r - 1, c] = matrix[r, c];
                        }
                    }

                    result += matrix[0, selectedColumn] * (short)Math.Pow(-1, selectedColumn) * determinant(minor, size - 1);
                }
            }
            //else if (size >= 2) //ŁADNIEJSZE LECZ MNIEJ OPTYMALNE
            //{
            //    for (int i = 0; i < size; i++)
            //    {
            //        long multiplyPlus = 1;
            //        long multiplyMinus = 1;

            //        for (int j = 0; j < size; j++)
            //        {
            //            multiplyPlus *= matrix[mod(i + j, size), j];
            //            multiplyMinus *= matrix[j, mod(i - j, size)];
            //        }

            //        result += multiplyPlus - multiplyMinus;
            //    }
            //}
            else if (size == 3)
            {
                result = matrix[0, 0] * matrix[1, 1] * matrix[2, 2] + matrix[0, 1] * matrix[1, 2] * matrix[2, 0] + matrix[0, 2] * matrix[1, 0] * matrix[2, 1]
                    - matrix[0, 0] * matrix[1, 2] * matrix[2, 1] - matrix[0, 1] * matrix[1, 0] * matrix[2, 2] - matrix[0, 2] * matrix[1, 1] * matrix[2, 0];
            }
            else if (size == 2) result = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            else result = matrix[0, 0];

            return (int)result;
        }

        public int matrixRank(int[,] matrix, int size)
        {
            int rank = 0;

            double[,] gaussEliminationedMatrix = gaussianEliminationMatrix(matrix, size);

            for (int i = 0; i < size; i++)
            {
                if (gaussEliminationedMatrix[i, i] > 0 || gaussEliminationedMatrix[i, i] < 0) rank++;
            }

            return rank;
        }

        public int matrixSum(int[,] matrix, int size)
        {
            int sum = 0;

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    sum += matrix[r, c];
                }
            }

            return sum;
        }

        public int matrixTrace(int[,] matrix, int size)
        {
            int sum = 0;

            for (int i = 0; i < size; i++) sum += matrix[i, i];

            return sum;
        }

        public int[,] matrixSwapColumn(int[,] matrix, int size, int col)
        {
            int[,] modifiedMatrix = new int[size, size + 1];
            Array.Copy(matrix, modifiedMatrix, size * (size + 1));

            for (int r = 0; r < size; r++) modifiedMatrix[r, col] = matrix[r, size];

            return modifiedMatrix;
        }

        private int mod(int a, int b) //BO C# NIE UMIE ZROBIĆ MOD-A -.-
        {
            int result = a % b;
            if (result < 0) return result + b;
            else return result;
        }

        private void linearEquationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren) form.Close();

            InputMatrixForm inputMatrix = new InputMatrixForm(this, true);
            if (myStyle > 0) inputMatrix.MdiParent = this;
            if (myStyle > 1 && myStyle < 3) inputMatrix.BackgroundImage = Properties.Resources.project_wallpaper;
            inputMatrix.Show();
        }

        private void matrixPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren) form.Close();

            InputMatrixForm matrixProperties = new InputMatrixForm(this, false);
            if (myStyle > 0) matrixProperties.MdiParent = this;
            if (myStyle > 1 && myStyle < 3) matrixProperties.BackgroundImage = Properties.Resources.project_wallpaper;
            matrixProperties.Show();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form info = new InfoForm();
            if (myStyle > 1)
            {
                info.BackgroundImage = Properties.Resources.project_wallpaper_mini;
                info.BackgroundImageLayout = ImageLayout.Stretch;
                info.Opacity = 1.0D;
            }
            info.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form close = new CloseForm(this);
            if (myStyle > 1)
            {
                close.BackgroundImage = Properties.Resources.project_wallpaper_mini;
                close.BackgroundImageLayout = ImageLayout.Stretch;
                close.Opacity = 1.0D;
            }
            close.ShowDialog();
        }

        private void style0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.myStyle = 0;
            this.BackgroundImage = Properties.Resources.project_wallpaper2;
            this.Refresh();
        }

        private void style1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.myStyle = 1;
            this.BackgroundImage = Properties.Resources.project_wallpaper2;
            this.Refresh();
        }

        private void style2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.myStyle = 2;
            this.BackgroundImage = null;
            this.mdiClient.BackColor = Color.FromArgb(30, 30, 30);
            this.Refresh();
        }

        private void style3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.myStyle = 3;
            this.BackgroundImage = null;
            this.mdiClient.BackColor = Color.FromArgb(30, 30, 30);
            this.Refresh();
        }

        private void simpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.myFontStyle = 0;

            foreach (Form form in this.MdiChildren)
            {
                foreach (Control ctrl in form.Controls)
                {
                    if (ctrl is Label) ((Label)ctrl).Font = new Font(this.myFonts.Families[0], ctrl.Font.Size);
                }

                form.Refresh();
            }
        }

        private void niceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.myFontStyle = 3;

            foreach (Form form in this.MdiChildren)
            {
                foreach (Control ctrl in form.Controls)
                {
                    if (ctrl is Label) ((Label)ctrl).Font = new Font(this.myFonts.Families[3], ctrl.Font.Size);
                }

                form.Refresh();
            }
        }

        private void closeWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
        }

        private void InitializeFonts()
        {
            byte[][] fonts = {
                Properties.Resources.aron_grotesque_regular,
                Properties.Resources.Gothic_II___Noc_Kruka_V2,
                Properties.Resources.Mindmonkey,
                Properties.Resources.Punktype
            };

            foreach (byte[] font in fonts)
            {
                int fontLength = font.Length;
                byte[] fontdata = font;
                IntPtr data = Marshal.AllocCoTaskMem(fontLength);
                Marshal.Copy(fontdata, 0, data, fontLength);
                this.myFonts.AddMemoryFont(data, fontLength);
                Marshal.FreeCoTaskMem(data);
            }
        }

        private void MainMdiForm_ResizeEnd(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void screenshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int smallBorder = 10;
            int topBorder = 56;

            String filename = "";
            Bitmap screen = new Bitmap(this.Width - 2 * smallBorder, this.Height - topBorder - smallBorder);
            using (Graphics graphic = Graphics.FromImage(screen))
            {
                graphic.CopyFromScreen(this.Location.X + smallBorder, this.Location.Y + topBorder, 0, 0, screen.Size);
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"C:\\images";
            saveFileDialog.FileName = "KrzaqMatrixCalcScreenshot";
            saveFileDialog.DefaultExt = ".jpg";
            saveFileDialog.Filter = "JPEG Images (.jpg)|*.jpg|All files (*.*)|*.*";
            saveFileDialog.Title = "Save an Image file";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog.FileName;

                try { screen.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg); }
                catch (Exception c) { Console.WriteLine(c.ToString()); }
            }
        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren) form.Close();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\\images";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader streamReader = new StreamReader(openFileDialog.FileName))
                    {
                        String[] file = streamReader.ReadToEnd().Split(new Char[] { ' ', '\n' } );

                        int mode;
                        Int32.TryParse(file[0], out mode);
                        size = Int32.Parse(file[1]);

                        mainMatrix = new int[size, mode == 0 ? size + 1 : size];

                        for (int i = 2; i < file.Length; i++)
                        {
                            Int32.TryParse(file[i], out mainMatrix[(i - 2) / (mode == 0 ? size + 1 : size), (i - 2) % (mode == 0 ? size + 1 : size)]);
                        }

                        if (mode == 0)
                        {
                            LinearEquationsResultForm linearEquationsResult = new LinearEquationsResultForm(this);
                            if (this.myStyle > 0) linearEquationsResult.MdiParent = this;
                            linearEquationsResult.Show();
                        }
                        else
                        {
                            int space;
                            Point dimensions;
                            Point coordinate;

                            if (myStyle > 0)
                            {
                                space = 5;
                                dimensions = new Point((Size.Width - 40) / 3, (Size.Height - 80) / 2);
                                coordinate = new Point(space, space);
                            }
                            else
                            {
                                space = 100;
                                dimensions = new Point((Size.Width - 40) / 3, (Size.Height - 80) / 2);
                                coordinate = new Point(this.Location.X + space, this.Location.Y + space);
                            }

                            solveStart = DateTime.Now;
                            solving = true;
                            timer.Start();

                            ShowMatrixForm showEnteredMatrix = new ShowMatrixForm(this, this.mainMatrix);
                            showEnteredMatrix.StartPosition = FormStartPosition.Manual;
                            showEnteredMatrix.Size = new Size(dimensions);
                            showEnteredMatrix.Location = coordinate;
                            showEnteredMatrix.Text = "Macierz";
                            if (this.myStyle > 0) showEnteredMatrix.MdiParent = this;

                            coordinate.X += dimensions.X + space;

                            ShowMatrixForm showTransposedMatrix = new ShowMatrixForm(this, this.transposedMatrix(this.mainMatrix, size));
                            showTransposedMatrix.StartPosition = FormStartPosition.Manual;
                            showTransposedMatrix.Size = new Size(dimensions);
                            showTransposedMatrix.Location = coordinate;
                            showTransposedMatrix.Text = "Macierz transponowana";
                            if (this.myStyle > 0) showTransposedMatrix.MdiParent = this;

                            coordinate.X += dimensions.X + space;

                            ShowMatrixForm showAlgebraicComplementsMatrix = new ShowMatrixForm(this, this.algebraicComplementsMatrix(this.mainMatrix, size));
                            showAlgebraicComplementsMatrix.StartPosition = FormStartPosition.Manual;
                            showAlgebraicComplementsMatrix.Size = new Size(dimensions);
                            showAlgebraicComplementsMatrix.Location = coordinate;
                            showAlgebraicComplementsMatrix.Text = "Macierz dopełnień algebraicznych";
                            if (this.myStyle > 0) showAlgebraicComplementsMatrix.MdiParent = this;

                            coordinate.X = space;

                            coordinate.Y += space + dimensions.Y;

                            ShowMatrixForm showInvertedMatrix = new ShowMatrixForm(this, this.invertedMatrix(this.mainMatrix, size));
                            showInvertedMatrix.StartPosition = FormStartPosition.Manual;
                            showInvertedMatrix.Size = new Size(dimensions);
                            showInvertedMatrix.Location = coordinate;
                            showInvertedMatrix.Text = "Macierz odwrotna";
                            if (this.myStyle > 0) showInvertedMatrix.MdiParent = this;

                            coordinate.X += dimensions.X + space;

                            ShowMatrixForm showGaussianEliminationMatrix = new ShowMatrixForm(this, this.gaussianEliminationMatrix(this.mainMatrix, size));
                            showGaussianEliminationMatrix.StartPosition = FormStartPosition.Manual;
                            showGaussianEliminationMatrix.Size = new Size(dimensions);
                            showGaussianEliminationMatrix.Location = coordinate;
                            showGaussianEliminationMatrix.Text = "Macierz po eliminacji gaussa";
                            if (this.myStyle > 0) showGaussianEliminationMatrix.MdiParent = this;

                            coordinate.X += dimensions.X + space;

                            MatrixOtherDetailsForm showMatrixOtherDetails = new MatrixOtherDetailsForm(this);
                            showMatrixOtherDetails.StartPosition = FormStartPosition.Manual;
                            showMatrixOtherDetails.Size = new Size(dimensions);
                            showMatrixOtherDetails.Location = coordinate;
                            if (this.myStyle > 0) showMatrixOtherDetails.MdiParent = this;

                            showEnteredMatrix.Show();
                            showTransposedMatrix.Show();
                            showAlgebraicComplementsMatrix.Show();
                            showInvertedMatrix.Show();
                            showGaussianEliminationMatrix.Show();
                            showMatrixOtherDetails.Show();

                            timer.Stop();
                            solving = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd: Nie można odczytać pliku. Error: " + ex.Message);
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (solving) this.solveTime.Text = "Czas obliczeń: " + (DateTime.Now - this.solveStart).ToString();
        }
    }
}
