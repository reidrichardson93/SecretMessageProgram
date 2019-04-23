namespace EncodeImageForm
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
            this.bitmapBox = new System.Windows.Forms.PictureBox();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.encodeBtn = new System.Windows.Forms.Button();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.mainSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.encodedMapBox = new System.Windows.Forms.PictureBox();
            this.ppmCommentsBox = new System.Windows.Forms.TextBox();
            this.redRadioButton = new System.Windows.Forms.RadioButton();
            this.blueRadioButton = new System.Windows.Forms.RadioButton();
            this.messageStartLabel = new System.Windows.Forms.Label();
            this.messageStartBox = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonP6 = new System.Windows.Forms.RadioButton();
            this.radioButtonP3 = new System.Windows.Forms.RadioButton();
            this.groupBoxChannels = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.bitmapBox)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.encodedMapBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageStartBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxChannels.SuspendLayout();
            this.SuspendLayout();
            // 
            // bitmapBox
            // 
            this.bitmapBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bitmapBox.BackColor = System.Drawing.SystemColors.Window;
            this.bitmapBox.Location = new System.Drawing.Point(25, 67);
            this.bitmapBox.Name = "bitmapBox";
            this.bitmapBox.Size = new System.Drawing.Size(650, 550);
            this.bitmapBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bitmapBox.TabIndex = 0;
            this.bitmapBox.TabStop = false;
            // 
            // messageBox
            // 
            this.messageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.messageBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.messageBox.Location = new System.Drawing.Point(25, 632);
            this.messageBox.MaxLength = 255;
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(598, 185);
            this.messageBox.TabIndex = 1;
            this.messageBox.Tag = "";
            this.messageBox.Text = "Write your secret message here.";
            this.messageBox.TextChanged += new System.EventHandler(this.messageBox_TextChanged);
            // 
            // encodeBtn
            // 
            this.encodeBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.encodeBtn.Location = new System.Drawing.Point(629, 741);
            this.encodeBtn.Name = "encodeBtn";
            this.encodeBtn.Size = new System.Drawing.Size(117, 70);
            this.encodeBtn.TabIndex = 2;
            this.encodeBtn.Text = "Encode";
            this.encodeBtn.UseVisualStyleBackColor = true;
            this.encodeBtn.Click += new System.EventHandler(this.encodeBtn_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1374, 40);
            this.mainMenuStrip.TabIndex = 3;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(173, 38);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(173, 38);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(173, 38);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mainOpenFile
            // 
            this.mainOpenFile.FileOk += new System.ComponentModel.CancelEventHandler(this.mainOpenFile_FileOk);
            // 
            // mainSaveFile
            // 
            this.mainSaveFile.FileOk += new System.ComponentModel.CancelEventHandler(this.mainSaveFile_FileOk);
            // 
            // encodedMapBox
            // 
            this.encodedMapBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.encodedMapBox.BackColor = System.Drawing.SystemColors.Window;
            this.encodedMapBox.Location = new System.Drawing.Point(700, 67);
            this.encodedMapBox.Name = "encodedMapBox";
            this.encodedMapBox.Size = new System.Drawing.Size(650, 550);
            this.encodedMapBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.encodedMapBox.TabIndex = 4;
            this.encodedMapBox.TabStop = false;
            // 
            // ppmCommentsBox
            // 
            this.ppmCommentsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ppmCommentsBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.ppmCommentsBox.Location = new System.Drawing.Point(752, 736);
            this.ppmCommentsBox.MaxLength = 100;
            this.ppmCommentsBox.Multiline = true;
            this.ppmCommentsBox.Name = "ppmCommentsBox";
            this.ppmCommentsBox.Size = new System.Drawing.Size(598, 81);
            this.ppmCommentsBox.TabIndex = 5;
            this.ppmCommentsBox.Tag = "";
            this.ppmCommentsBox.Text = "Write a comment for the \'.ppm\' file here.";
            this.ppmCommentsBox.TextChanged += new System.EventHandler(this.ppmCommentsBox_TextChanged);
            // 
            // redRadioButton
            // 
            this.redRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.redRadioButton.AutoSize = true;
            this.redRadioButton.Location = new System.Drawing.Point(21, 65);
            this.redRadioButton.Name = "redRadioButton";
            this.redRadioButton.Size = new System.Drawing.Size(82, 29);
            this.redRadioButton.TabIndex = 6;
            this.redRadioButton.TabStop = true;
            this.redRadioButton.Text = "Red";
            this.redRadioButton.UseVisualStyleBackColor = true;
            // 
            // blueRadioButton
            // 
            this.blueRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.blueRadioButton.AutoSize = true;
            this.blueRadioButton.Checked = true;
            this.blueRadioButton.Location = new System.Drawing.Point(21, 30);
            this.blueRadioButton.Name = "blueRadioButton";
            this.blueRadioButton.Size = new System.Drawing.Size(86, 29);
            this.blueRadioButton.TabIndex = 7;
            this.blueRadioButton.TabStop = true;
            this.blueRadioButton.Text = "Blue";
            this.blueRadioButton.UseVisualStyleBackColor = true;
            // 
            // messageStartLabel
            // 
            this.messageStartLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.messageStartLabel.AutoSize = true;
            this.messageStartLabel.Location = new System.Drawing.Point(901, 657);
            this.messageStartLabel.Name = "messageStartLabel";
            this.messageStartLabel.Size = new System.Drawing.Size(204, 25);
            this.messageStartLabel.TabIndex = 9;
            this.messageStartLabel.Text = "Message Start Pixel";
            // 
            // messageStartBox
            // 
            this.messageStartBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.messageStartBox.Location = new System.Drawing.Point(906, 692);
            this.messageStartBox.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.messageStartBox.Name = "messageStartBox";
            this.messageStartBox.Size = new System.Drawing.Size(291, 31);
            this.messageStartBox.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButtonP6);
            this.groupBox1.Controls.Add(this.radioButtonP3);
            this.groupBox1.Location = new System.Drawing.Point(755, 623);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Type";
            // 
            // radioButtonP6
            // 
            this.radioButtonP6.AutoSize = true;
            this.radioButtonP6.Location = new System.Drawing.Point(25, 65);
            this.radioButtonP6.Name = "radioButtonP6";
            this.radioButtonP6.Size = new System.Drawing.Size(69, 29);
            this.radioButtonP6.TabIndex = 1;
            this.radioButtonP6.TabStop = true;
            this.radioButtonP6.Text = "P6";
            this.radioButtonP6.UseVisualStyleBackColor = true;
            // 
            // radioButtonP3
            // 
            this.radioButtonP3.AutoSize = true;
            this.radioButtonP3.Location = new System.Drawing.Point(25, 30);
            this.radioButtonP3.Name = "radioButtonP3";
            this.radioButtonP3.Size = new System.Drawing.Size(69, 29);
            this.radioButtonP3.TabIndex = 0;
            this.radioButtonP3.TabStop = true;
            this.radioButtonP3.Text = "P3";
            this.radioButtonP3.Checked = true;
            this.radioButtonP3.UseVisualStyleBackColor = true;
            // 
            // groupBoxChannels
            // 
            this.groupBoxChannels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxChannels.Controls.Add(this.blueRadioButton);
            this.groupBoxChannels.Controls.Add(this.redRadioButton);
            this.groupBoxChannels.Location = new System.Drawing.Point(1214, 623);
            this.groupBoxChannels.Name = "groupBoxChannels";
            this.groupBoxChannels.Size = new System.Drawing.Size(136, 100);
            this.groupBoxChannels.TabIndex = 13;
            this.groupBoxChannels.TabStop = false;
            this.groupBoxChannels.Text = "Channel";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 829);
            this.Controls.Add(this.groupBoxChannels);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.messageStartBox);
            this.Controls.Add(this.messageStartLabel);
            this.Controls.Add(this.ppmCommentsBox);
            this.Controls.Add(this.encodedMapBox);
            this.Controls.Add(this.encodeBtn);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.bitmapBox);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(1400, 900);
            this.Name = "Form1";
            this.Text = "Form1";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.bitmapBox)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.encodedMapBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageStartBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxChannels.ResumeLayout(false);
            this.groupBoxChannels.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox bitmapBox;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Button encodeBtn;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog mainOpenFile;
        private System.Windows.Forms.SaveFileDialog mainSaveFile;
        private System.Windows.Forms.PictureBox encodedMapBox;
        private System.Windows.Forms.TextBox ppmCommentsBox;
        private System.Windows.Forms.RadioButton redRadioButton;
        private System.Windows.Forms.RadioButton blueRadioButton;
        private System.Windows.Forms.Label messageStartLabel;
        internal System.Windows.Forms.NumericUpDown messageStartBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonP6;
        private System.Windows.Forms.RadioButton radioButtonP3;
        private System.Windows.Forms.GroupBox groupBoxChannels;
    }
}

