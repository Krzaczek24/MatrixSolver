namespace ProjectV2
{
    partial class MainMdiForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMdiForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setStyleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.style0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.style1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.style2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.style3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.niceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearEquationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrixPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screenshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solveTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.computeToolStripMenuItem,
            this.infoToolStripMenuItem,
            this.screenshotToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuBar";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem,
            this.setStyleToolStripMenuItem,
            this.setFontToolStripMenuItem,
            this.closeWindowsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.settingsToolStripMenuItem.Text = "&Opcje";
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.loadFileToolStripMenuItem.Text = "&Wczytaj z pliku";
            this.loadFileToolStripMenuItem.Click += new System.EventHandler(this.loadFileToolStripMenuItem_Click);
            // 
            // setStyleToolStripMenuItem
            // 
            this.setStyleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.style0ToolStripMenuItem,
            this.style1ToolStripMenuItem,
            this.style2ToolStripMenuItem,
            this.style3ToolStripMenuItem});
            this.setStyleToolStripMenuItem.Name = "setStyleToolStripMenuItem";
            this.setStyleToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.setStyleToolStripMenuItem.Text = "Zmień &styl";
            // 
            // style0ToolStripMenuItem
            // 
            this.style0ToolStripMenuItem.Name = "style0ToolStripMenuItem";
            this.style0ToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.style0ToolStripMenuItem.Text = "&Ładny";
            this.style0ToolStripMenuItem.Click += new System.EventHandler(this.style0ToolStripMenuItem_Click);
            // 
            // style1ToolStripMenuItem
            // 
            this.style1ToolStripMenuItem.Name = "style1ToolStripMenuItem";
            this.style1ToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.style1ToolStripMenuItem.Text = "&Wolny";
            this.style1ToolStripMenuItem.Click += new System.EventHandler(this.style1ToolStripMenuItem_Click);
            // 
            // style2ToolStripMenuItem
            // 
            this.style2ToolStripMenuItem.Name = "style2ToolStripMenuItem";
            this.style2ToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.style2ToolStripMenuItem.Text = "&B. wolny";
            this.style2ToolStripMenuItem.Click += new System.EventHandler(this.style2ToolStripMenuItem_Click);
            // 
            // style3ToolStripMenuItem
            // 
            this.style3ToolStripMenuItem.Name = "style3ToolStripMenuItem";
            this.style3ToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.style3ToolStripMenuItem.Text = "&Prosty";
            this.style3ToolStripMenuItem.Click += new System.EventHandler(this.style3ToolStripMenuItem_Click);
            // 
            // setFontToolStripMenuItem
            // 
            this.setFontToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.niceToolStripMenuItem,
            this.simpleToolStripMenuItem});
            this.setFontToolStripMenuItem.Name = "setFontToolStripMenuItem";
            this.setFontToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.setFontToolStripMenuItem.Text = "Zmień &czcionkę";
            // 
            // niceToolStripMenuItem
            // 
            this.niceToolStripMenuItem.Name = "niceToolStripMenuItem";
            this.niceToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.niceToolStripMenuItem.Text = "&Ładna";
            this.niceToolStripMenuItem.Click += new System.EventHandler(this.niceToolStripMenuItem_Click);
            // 
            // simpleToolStripMenuItem
            // 
            this.simpleToolStripMenuItem.Name = "simpleToolStripMenuItem";
            this.simpleToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.simpleToolStripMenuItem.Text = "&Prosta";
            this.simpleToolStripMenuItem.Click += new System.EventHandler(this.simpleToolStripMenuItem_Click);
            // 
            // closeWindowsToolStripMenuItem
            // 
            this.closeWindowsToolStripMenuItem.Name = "closeWindowsToolStripMenuItem";
            this.closeWindowsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.closeWindowsToolStripMenuItem.Text = "Zamknij wszystkie &okna";
            this.closeWindowsToolStripMenuItem.Click += new System.EventHandler(this.closeWindowsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.exitToolStripMenuItem.Text = "&Zakończ";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // computeToolStripMenuItem
            // 
            this.computeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linearEquationToolStripMenuItem,
            this.matrixPropertiesToolStripMenuItem});
            this.computeToolStripMenuItem.Name = "computeToolStripMenuItem";
            this.computeToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.computeToolStripMenuItem.Text = "&Nowe działanie";
            // 
            // linearEquationToolStripMenuItem
            // 
            this.linearEquationToolStripMenuItem.Name = "linearEquationToolStripMenuItem";
            this.linearEquationToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.linearEquationToolStripMenuItem.Text = "&Rozwiąż równanie liniowe";
            this.linearEquationToolStripMenuItem.Click += new System.EventHandler(this.linearEquationsToolStripMenuItem_Click);
            // 
            // matrixPropertiesToolStripMenuItem
            // 
            this.matrixPropertiesToolStripMenuItem.Name = "matrixPropertiesToolStripMenuItem";
            this.matrixPropertiesToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.matrixPropertiesToolStripMenuItem.Text = "&Sprawdź właściwości macierzy";
            this.matrixPropertiesToolStripMenuItem.Click += new System.EventHandler(this.matrixPropertiesToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.infoToolStripMenuItem.Text = "&Informacje";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // screenshotToolStripMenuItem
            // 
            this.screenshotToolStripMenuItem.Name = "screenshotToolStripMenuItem";
            this.screenshotToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.screenshotToolStripMenuItem.Text = "&Zapisz zdjęcie";
            this.screenshotToolStripMenuItem.Click += new System.EventHandler(this.screenshotToolStripMenuItem_Click);
            // 
            // solveTime
            // 
            this.solveTime.BackColor = System.Drawing.Color.WhiteSmoke;
            this.solveTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.solveTime.Location = new System.Drawing.Point(1034, 0);
            this.solveTime.Name = "solveTime";
            this.solveTime.Size = new System.Drawing.Size(230, 23);
            this.solveTime.TabIndex = 3;
            this.solveTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainMdiForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::ProjectV2.Properties.Resources.project_wallpaper2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 762);
            this.Controls.Add(this.solveTime);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainMdiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MatrixCalc by Krzaczek";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.ResizeEnd += new System.EventHandler(this.MainMdiForm_ResizeEnd);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linearEquationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrixPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setStyleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem style0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem style1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem style2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem style3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem niceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem screenshotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.Label solveTime;
        public System.Windows.Forms.Timer timer;
    }
}

