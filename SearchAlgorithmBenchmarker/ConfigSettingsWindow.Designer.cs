namespace SearchAlgorithmBenchmarker
{
    partial class ConfigSettingsWindow
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
            this.txtOutputFile = new System.Windows.Forms.TextBox();
            this.lblOutputFile = new System.Windows.Forms.Label();
            this.lblFontSize = new System.Windows.Forms.Label();
            this.lblFontColour = new System.Windows.Forms.Label();
            this.numFontSize = new System.Windows.Forms.NumericUpDown();
            this.cbFontColour = new SearchAlgorithmBenchmarker.ColourChooser();
            this.dlgFontColour = new System.Windows.Forms.ColorDialog();
            this.cmdApply = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdBrowseOutput = new System.Windows.Forms.Button();
            this.dlgOutputDirectory = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOutputFile
            // 
            this.txtOutputFile.Location = new System.Drawing.Point(168, 75);
            this.txtOutputFile.Name = "txtOutputFile";
            this.txtOutputFile.ReadOnly = true;
            this.txtOutputFile.Size = new System.Drawing.Size(169, 20);
            this.txtOutputFile.TabIndex = 0;
            // 
            // lblOutputFile
            // 
            this.lblOutputFile.AutoSize = true;
            this.lblOutputFile.Location = new System.Drawing.Point(12, 75);
            this.lblOutputFile.Name = "lblOutputFile";
            this.lblOutputFile.Size = new System.Drawing.Size(150, 13);
            this.lblOutputFile.TabIndex = 1;
            this.lblOutputFile.Text = "Benchmark output file location";
            // 
            // lblFontSize
            // 
            this.lblFontSize.AutoSize = true;
            this.lblFontSize.Location = new System.Drawing.Point(12, 131);
            this.lblFontSize.Name = "lblFontSize";
            this.lblFontSize.Size = new System.Drawing.Size(83, 13);
            this.lblFontSize.TabIndex = 2;
            this.lblFontSize.Text = "Display font size";
            // 
            // lblFontColour
            // 
            this.lblFontColour.AutoSize = true;
            this.lblFontColour.Location = new System.Drawing.Point(12, 181);
            this.lblFontColour.Name = "lblFontColour";
            this.lblFontColour.Size = new System.Drawing.Size(94, 13);
            this.lblFontColour.TabIndex = 3;
            this.lblFontColour.Text = "Display font colour";
            // 
            // numFontSize
            // 
            this.numFontSize.Location = new System.Drawing.Point(168, 131);
            this.numFontSize.Name = "numFontSize";
            this.numFontSize.Size = new System.Drawing.Size(120, 20);
            this.numFontSize.TabIndex = 4;
            this.numFontSize.ValueChanged += new System.EventHandler(this.numFontSize_ValueChanged);
            // 
            // cbFontColour
            // 
            this.cbFontColour.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFontColour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFontColour.FormattingEnabled = true;
            this.cbFontColour.Location = new System.Drawing.Point(167, 181);
            this.cbFontColour.Name = "cbFontColour";
            this.cbFontColour.SelectedItem = null;
            this.cbFontColour.SelectedValue = System.Drawing.Color.White;
            this.cbFontColour.Size = new System.Drawing.Size(121, 21);
            this.cbFontColour.TabIndex = 5;
            this.cbFontColour.SelectedIndexChanged += new System.EventHandler(this.cbFontColour_SelectedIndexChanged);
            // 
            // cmdApply
            // 
            this.cmdApply.Location = new System.Drawing.Point(207, 415);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(99, 32);
            this.cmdApply.TabIndex = 6;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = true;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(312, 415);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(86, 32);
            this.cmdOK.TabIndex = 7;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdBrowseOutput
            // 
            this.cmdBrowseOutput.Location = new System.Drawing.Point(343, 75);
            this.cmdBrowseOutput.Name = "cmdBrowseOutput";
            this.cmdBrowseOutput.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseOutput.TabIndex = 8;
            this.cmdBrowseOutput.Text = "Browse...";
            this.cmdBrowseOutput.UseVisualStyleBackColor = true;
            this.cmdBrowseOutput.Click += new System.EventHandler(this.cmdBrowseOutput_Click);
            // 
            // ConfigSettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 450);
            this.Controls.Add(this.cmdBrowseOutput);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdApply);
            this.Controls.Add(this.cbFontColour);
            this.Controls.Add(this.numFontSize);
            this.Controls.Add(this.lblFontColour);
            this.Controls.Add(this.lblFontSize);
            this.Controls.Add(this.lblOutputFile);
            this.Controls.Add(this.txtOutputFile);
            this.Name = "ConfigSettingsWindow";
            this.Text = "Configuration Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutputFile;
        private System.Windows.Forms.Label lblOutputFile;
        private System.Windows.Forms.Label lblFontSize;
        private System.Windows.Forms.Label lblFontColour;
        private System.Windows.Forms.NumericUpDown numFontSize;
        // private System.Windows.Forms.ComboBox cbFontColour;
        private ColourChooser cbFontColour;
        private System.Windows.Forms.ColorDialog dlgFontColour;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdBrowseOutput;
        private System.Windows.Forms.FolderBrowserDialog dlgOutputDirectory;
    }
}