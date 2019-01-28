namespace ProjectV2
{
    partial class InputMatrixForm
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
            this.label = new System.Windows.Forms.Label();
            this.sizeInput = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Font = new System.Drawing.Font("Tempus Sans ITC", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.Gold;
            this.label.Location = new System.Drawing.Point(12, 25);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(75, 42);
            this.label.TabIndex = 0;
            this.label.Text = "Napis";
            this.label.UseCompatibleTextRendering = true;
            // 
            // sizeInput
            // 
            this.sizeInput.Font = new System.Drawing.Font("Tempus Sans ITC", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeInput.Location = new System.Drawing.Point(278, 18);
            this.sizeInput.Mask = "0";
            this.sizeInput.Name = "sizeInput";
            this.sizeInput.Size = new System.Drawing.Size(54, 49);
            this.sizeInput.TabIndex = 1;
            this.sizeInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sizeInput.TextChanged += new System.EventHandler(this.sizeInput_ValueChanged);
            // 
            // InputMatrixForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(344, 86);
            this.ControlBox = false;
            this.Controls.Add(this.sizeInput);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InputMatrixForm";
            this.Opacity = 0.7D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tytuł okna";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.MaskedTextBox sizeInput;
    }
}