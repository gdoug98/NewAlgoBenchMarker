namespace SearchAlgorithmBenchmarker
{
    partial class Form1
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
            //this.components = new System.ComponentModel.Container();
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(800, 450);
            //this.Text = "Form1";
            this.pnlButtonContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.cmdSort = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.pnlApp = new System.Windows.Forms.Panel();
            this.lblWarning = new System.Windows.Forms.Label();
            this.pnlInput2 = new System.Windows.Forms.Panel();
            this.txtInput2 = new System.Windows.Forms.TextBox();
            this.lblInput2 = new System.Windows.Forms.Label();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.cmdReset = new System.Windows.Forms.Button();
            this.tbBenchmarkSelector = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblSeachTab = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblSortTab = new System.Windows.Forms.Label();
            this.pnlSortTab = new System.Windows.Forms.Panel();
            this.lblWarning2 = new System.Windows.Forms.Label();
            this.pnlButtonHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.cmdGenerate2 = new System.Windows.Forms.Button();
            this.cmdBenchmark = new System.Windows.Forms.Button();
            this.cmdClear2 = new System.Windows.Forms.Button();
            this.pnlInputHolder = new System.Windows.Forms.Panel();
            this.lblInfo3 = new System.Windows.Forms.Label();
            this.lblInput3 = new System.Windows.Forms.Label();
            this.txtInput3 = new System.Windows.Forms.TextBox();
            this.txtOutput2 = new System.Windows.Forms.RichTextBox();
            this.pbTaskProgress = new System.Windows.Forms.ProgressBar();
            this.cbAdditiveArray = new System.Windows.Forms.CheckBox();
            this.pnlButtonContainer.SuspendLayout();
            this.pnlApp.SuspendLayout();
            this.pnlInput2.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.tbBenchmarkSelector.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pnlSortTab.SuspendLayout();
            this.pnlButtonHolder.SuspendLayout();
            this.pnlInputHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtonContainer
            // 
            this.pnlButtonContainer.Controls.Add(this.cmdGenerate);
            this.pnlButtonContainer.Controls.Add(this.cmdSort);
            this.pnlButtonContainer.Controls.Add(this.cmdClear);
            this.pnlButtonContainer.Location = new System.Drawing.Point(6, 336);
            this.pnlButtonContainer.Name = "pnlButtonContainer";
            this.pnlButtonContainer.Size = new System.Drawing.Size(396, 88);
            this.pnlButtonContainer.TabIndex = 0;
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Location = new System.Drawing.Point(3, 3);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(109, 38);
            this.cmdGenerate.TabIndex = 0;
            this.cmdGenerate.Text = "Generate Numbers";
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // cmdSort
            // 
            this.cmdSort.Location = new System.Drawing.Point(118, 3);
            this.cmdSort.Name = "cmdSort";
            this.cmdSort.Size = new System.Drawing.Size(109, 38);
            this.cmdSort.TabIndex = 1;
            this.cmdSort.Text = "Run Benchmark";
            this.cmdSort.UseVisualStyleBackColor = true;
            this.cmdSort.Click += new System.EventHandler(this.cmdSort_Click);
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(3, 47);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(224, 29);
            this.cmdClear.TabIndex = 2;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // pnlApp
            // 
            this.pnlApp.Controls.Add(this.lblWarning);
            this.pnlApp.Controls.Add(this.pnlInput2);
            this.pnlApp.Controls.Add(this.pnlInput);
            this.pnlApp.Controls.Add(this.txtOutput);
            this.pnlApp.Controls.Add(this.pnlButtonContainer);
            this.pnlApp.Location = new System.Drawing.Point(11, 20);
            this.pnlApp.Name = "pnlApp";
            this.pnlApp.Size = new System.Drawing.Size(402, 427);
            this.pnlApp.TabIndex = 1;
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Font = new System.Drawing.Font("Lucida Sans Unicode", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(3, 296);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(47, 17);
            this.lblWarning.TabIndex = 7;
            this.lblWarning.Text = "Hello!";
            // 
            // pnlInput2
            // 
            this.pnlInput2.Controls.Add(this.txtInput2);
            this.pnlInput2.Controls.Add(this.lblInput2);
            this.pnlInput2.Controls.Add(this.lblInfo2);
            this.pnlInput2.Location = new System.Drawing.Point(24, 251);
            this.pnlInput2.Name = "pnlInput2";
            this.pnlInput2.Size = new System.Drawing.Size(349, 42);
            this.pnlInput2.TabIndex = 6;
            // 
            // txtInput2
            // 
            this.txtInput2.Enabled = false;
            this.txtInput2.Location = new System.Drawing.Point(174, 3);
            this.txtInput2.Name = "txtInput2";
            this.txtInput2.Size = new System.Drawing.Size(174, 20);
            this.txtInput2.TabIndex = 1;
            // 
            // lblInput2
            // 
            this.lblInput2.AutoSize = true;
            this.lblInput2.Location = new System.Drawing.Point(-4, 6);
            this.lblInput2.Name = "lblInput2";
            this.lblInput2.Size = new System.Drawing.Size(142, 13);
            this.lblInput2.TabIndex = 2;
            this.lblInput2.Text = "Enter number to find in array:";
            // 
            // lblInfo2
            // 
            this.lblInfo2.AutoSize = true;
            this.lblInfo2.Location = new System.Drawing.Point(-4, 19);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(126, 13);
            this.lblInfo2.TabIndex = 3;
            this.lblInfo2.Text = "(1,000 - 10,000 inclusive)";
            // 
            // pnlInput
            // 
            this.pnlInput.Controls.Add(this.txtInput);
            this.pnlInput.Controls.Add(this.lblInput);
            this.pnlInput.Controls.Add(this.lblInfo);
            this.pnlInput.Location = new System.Drawing.Point(25, 207);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(348, 51);
            this.pnlInput.TabIndex = 5;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(208, 3);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(140, 20);
            this.txtInput.TabIndex = 1;
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(-4, 6);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(206, 13);
            this.lblInput.TabIndex = 2;
            this.lblInput.Text = "Enter amount of numbers to be generated:";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(-4, 19);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(153, 13);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "(10,000 - 10,000,000 inclusive)";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(0, 3);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(402, 198);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.Text = "";
            // 
            // cmdReset
            // 
            this.cmdReset.Location = new System.Drawing.Point(230, 549);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(118, 39);
            this.cmdReset.TabIndex = 3;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // tbBenchmarkSelector
            // 
            this.tbBenchmarkSelector.Controls.Add(this.tabPage1);
            this.tbBenchmarkSelector.Controls.Add(this.tabPage2);
            this.tbBenchmarkSelector.Location = new System.Drawing.Point(93, 0);
            this.tbBenchmarkSelector.Name = "tbBenchmarkSelector";
            this.tbBenchmarkSelector.SelectedIndex = 0;
            this.tbBenchmarkSelector.Size = new System.Drawing.Size(434, 482);
            this.tbBenchmarkSelector.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblSeachTab);
            this.tabPage1.Controls.Add(this.pnlApp);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(426, 456);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Searching";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // lblSeachTab
            // 
            this.lblSeachTab.AutoSize = true;
            this.lblSeachTab.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeachTab.Location = new System.Drawing.Point(78, 3);
            this.lblSeachTab.Name = "lblSeachTab";
            this.lblSeachTab.Size = new System.Drawing.Size(239, 14);
            this.lblSeachTab.TabIndex = 2;
            this.lblSeachTab.Text = "Search Algorithm Benchmarking";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblSortTab);
            this.tabPage2.Controls.Add(this.pnlSortTab);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(426, 456);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sorting";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblSortTab
            // 
            this.lblSortTab.AutoSize = true;
            this.lblSortTab.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSortTab.Location = new System.Drawing.Point(81, 7);
            this.lblSortTab.Name = "lblSortTab";
            this.lblSortTab.Size = new System.Drawing.Size(247, 13);
            this.lblSortTab.TabIndex = 1;
            this.lblSortTab.Text = "Sorting Algorithm Benchmarking";
            // 
            // pnlSortTab
            // 
            this.pnlSortTab.Controls.Add(this.lblWarning2);
            this.pnlSortTab.Controls.Add(this.pnlButtonHolder);
            this.pnlSortTab.Controls.Add(this.pnlInputHolder);
            this.pnlSortTab.Controls.Add(this.txtOutput2);
            this.pnlSortTab.Location = new System.Drawing.Point(6, 23);
            this.pnlSortTab.Name = "pnlSortTab";
            this.pnlSortTab.Size = new System.Drawing.Size(407, 395);
            this.pnlSortTab.TabIndex = 0;
            // 
            // lblWarning2
            // 
            this.lblWarning2.AutoSize = true;
            this.lblWarning2.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning2.ForeColor = System.Drawing.Color.Red;
            this.lblWarning2.Location = new System.Drawing.Point(3, 279);
            this.lblWarning2.Name = "lblWarning2";
            this.lblWarning2.Size = new System.Drawing.Size(55, 13);
            this.lblWarning2.TabIndex = 3;
            this.lblWarning2.Text = "Hello!";
            // 
            // pnlButtonHolder
            // 
            this.pnlButtonHolder.Controls.Add(this.cmdGenerate2);
            this.pnlButtonHolder.Controls.Add(this.cmdBenchmark);
            this.pnlButtonHolder.Controls.Add(this.cmdClear2);
            this.pnlButtonHolder.Location = new System.Drawing.Point(92, 301);
            this.pnlButtonHolder.Name = "pnlButtonHolder";
            this.pnlButtonHolder.Size = new System.Drawing.Size(230, 78);
            this.pnlButtonHolder.TabIndex = 2;
            // 
            // cmdGenerate2
            // 
            this.cmdGenerate2.Location = new System.Drawing.Point(3, 3);
            this.cmdGenerate2.Name = "cmdGenerate2";
            this.cmdGenerate2.Size = new System.Drawing.Size(108, 38);
            this.cmdGenerate2.TabIndex = 0;
            this.cmdGenerate2.Text = "Generate Values";
            this.cmdGenerate2.UseVisualStyleBackColor = true;
            this.cmdGenerate2.Click += new System.EventHandler(this.cmdGenerate2_Click);
            // 
            // cmdBenchmark
            // 
            this.cmdBenchmark.Location = new System.Drawing.Point(117, 3);
            this.cmdBenchmark.Name = "cmdBenchmark";
            this.cmdBenchmark.Size = new System.Drawing.Size(108, 38);
            this.cmdBenchmark.TabIndex = 1;
            this.cmdBenchmark.Text = "Run Benchmarking";
            this.cmdBenchmark.UseVisualStyleBackColor = true;
            this.cmdBenchmark.Click += new System.EventHandler(this.cmdBenchmark_Click);
            // 
            // cmdClear2
            // 
            this.cmdClear2.Location = new System.Drawing.Point(3, 47);
            this.cmdClear2.Name = "cmdClear2";
            this.cmdClear2.Size = new System.Drawing.Size(63, 29);
            this.cmdClear2.TabIndex = 2;
            this.cmdClear2.Text = "Clear";
            this.cmdClear2.UseVisualStyleBackColor = true;
            this.cmdClear2.Click += new System.EventHandler(this.cmdClear2_Click);
            // 
            // pnlInputHolder
            // 
            this.pnlInputHolder.Controls.Add(this.lblInfo3);
            this.pnlInputHolder.Controls.Add(this.lblInput3);
            this.pnlInputHolder.Controls.Add(this.txtInput3);
            this.pnlInputHolder.Location = new System.Drawing.Point(38, 214);
            this.pnlInputHolder.Name = "pnlInputHolder";
            this.pnlInputHolder.Size = new System.Drawing.Size(329, 53);
            this.pnlInputHolder.TabIndex = 1;
            // 
            // lblInfo3
            // 
            this.lblInfo3.AutoSize = true;
            this.lblInfo3.Location = new System.Drawing.Point(3, 27);
            this.lblInfo3.Name = "lblInfo3";
            this.lblInfo3.Size = new System.Drawing.Size(123, 13);
            this.lblInfo3.TabIndex = 2;
            this.lblInfo3.Text = "(1000 - 12,500 inclusive)";
            // 
            // lblInput3
            // 
            this.lblInput3.AutoSize = true;
            this.lblInput3.Location = new System.Drawing.Point(3, 14);
            this.lblInput3.Name = "lblInput3";
            this.lblInput3.Size = new System.Drawing.Size(197, 13);
            this.lblInput3.TabIndex = 1;
            this.lblInput3.Text = "Enter number of values to be generated:";
            // 
            // txtInput3
            // 
            this.txtInput3.Location = new System.Drawing.Point(206, 14);
            this.txtInput3.Name = "txtInput3";
            this.txtInput3.Size = new System.Drawing.Size(123, 20);
            this.txtInput3.TabIndex = 0;
            // 
            // txtOutput2
            // 
            this.txtOutput2.Location = new System.Drawing.Point(3, 3);
            this.txtOutput2.Name = "txtOutput2";
            this.txtOutput2.ReadOnly = true;
            this.txtOutput2.Size = new System.Drawing.Size(401, 205);
            this.txtOutput2.TabIndex = 0;
            this.txtOutput2.Text = "";
            // 
            // pbTaskProgress
            // 
            this.pbTaskProgress.Location = new System.Drawing.Point(193, 507);
            this.pbTaskProgress.Maximum = 10000;
            this.pbTaskProgress.Name = "pbTaskProgress";
            this.pbTaskProgress.Size = new System.Drawing.Size(221, 23);
            this.pbTaskProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbTaskProgress.TabIndex = 9;
            // 
            // cbAdditiveArray
            // 
            this.cbAdditiveArray.AutoSize = true;
            this.cbAdditiveArray.Location = new System.Drawing.Point(374, 484);
            this.cbAdditiveArray.Name = "cbAdditiveArray";
            this.cbAdditiveArray.Size = new System.Drawing.Size(149, 17);
            this.cbAdditiveArray.TabIndex = 5;
            this.cbAdditiveArray.Text = "Numbers for additive array";
            this.cbAdditiveArray.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 587);
            this.Controls.Add(this.pbTaskProgress);
            this.Controls.Add(this.tbBenchmarkSelector);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.cbAdditiveArray);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlButtonContainer.ResumeLayout(false);
            this.pnlApp.ResumeLayout(false);
            this.pnlApp.PerformLayout();
            this.pnlInput2.ResumeLayout(false);
            this.pnlInput2.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.tbBenchmarkSelector.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.pnlSortTab.ResumeLayout(false);
            this.pnlSortTab.PerformLayout();
            this.pnlButtonHolder.ResumeLayout(false);
            this.pnlInputHolder.ResumeLayout(false);
            this.pnlInputHolder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlButtonContainer;
        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.Button cmdSort;
        private System.Windows.Forms.Panel pnlApp;

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.Panel pnlInput2;
        private System.Windows.Forms.TextBox txtInput2;
        private System.Windows.Forms.Label lblInput2;
        private System.Windows.Forms.Label lblInfo2;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.TabControl tbBenchmarkSelector;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblSortTab;
        private System.Windows.Forms.Panel pnlSortTab;
        private System.Windows.Forms.FlowLayoutPanel pnlButtonHolder;
        private System.Windows.Forms.Button cmdGenerate2;
        private System.Windows.Forms.Button cmdBenchmark;
        private System.Windows.Forms.Panel pnlInputHolder;
        private System.Windows.Forms.Label lblInfo3;
        private System.Windows.Forms.Label lblInput3;
        private System.Windows.Forms.TextBox txtInput3;
        private System.Windows.Forms.RichTextBox txtOutput2;
        private System.Windows.Forms.Label lblSeachTab;
        private System.Windows.Forms.Label lblWarning2;
        private System.Windows.Forms.Button cmdClear2;
        private System.Windows.Forms.ProgressBar pbTaskProgress;
        private System.Windows.Forms.CheckBox cbAdditiveArray;
    }
}

