namespace BoulderingSegmentImageGenerator
{
    partial class BoulderingSegmentImageGenerator
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.InputImage = new System.Windows.Forms.PictureBox();
            this.Holds = new System.Windows.Forms.RadioButton();
            this.Volume = new System.Windows.Forms.RadioButton();
            this.HoldsType = new System.Windows.Forms.GroupBox();
            this.BackgrounButton = new System.Windows.Forms.RadioButton();
            this.FolderPath = new System.Windows.Forms.TextBox();
            this.open = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.PaintSizeBox = new System.Windows.Forms.GroupBox();
            this.paintSizeBar = new System.Windows.Forms.TrackBar();
            this.InputImageListBox = new System.Windows.Forms.ListBox();
            this.LoadButton = new System.Windows.Forms.Button();
            this.AlphaBar = new System.Windows.Forms.TrackBar();
            this.InputImageGroup = new System.Windows.Forms.GroupBox();
            this.rotateBox = new System.Windows.Forms.GroupBox();
            this.RightRotateButton = new System.Windows.Forms.Button();
            this.LeftRotateButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.PrevButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).BeginInit();
            this.HoldsType.SuspendLayout();
            this.PaintSizeBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paintSizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaBar)).BeginInit();
            this.InputImageGroup.SuspendLayout();
            this.rotateBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputImage
            // 
            this.InputImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.InputImage.Location = new System.Drawing.Point(227, 69);
            this.InputImage.Name = "InputImage";
            this.InputImage.Size = new System.Drawing.Size(1449, 1248);
            this.InputImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.InputImage.TabIndex = 0;
            this.InputImage.TabStop = false;
            this.InputImage.Paint += new System.Windows.Forms.PaintEventHandler(this.InputImage_Paint);
            this.InputImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InputImage_MouseDown);
            this.InputImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.InputImage_MouseMove);
            this.InputImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.InputImage_MouseUp);
            this.InputImage.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.InputImage_MouseWheel);
            // 
            // Holds
            // 
            this.Holds.AutoSize = true;
            this.Holds.Checked = true;
            this.Holds.Font = new System.Drawing.Font("Myrica M", 11F);
            this.Holds.Location = new System.Drawing.Point(6, 28);
            this.Holds.Name = "Holds";
            this.Holds.Size = new System.Drawing.Size(90, 26);
            this.Holds.TabIndex = 3;
            this.Holds.TabStop = true;
            this.Holds.Text = "Holds";
            this.Holds.UseVisualStyleBackColor = true;
            this.Holds.CheckedChanged += new System.EventHandler(this.Holds_CheckedChanged);
            // 
            // Volume
            // 
            this.Volume.AutoSize = true;
            this.Volume.Font = new System.Drawing.Font("Myrica M", 11F);
            this.Volume.Location = new System.Drawing.Point(6, 52);
            this.Volume.Name = "Volume";
            this.Volume.Size = new System.Drawing.Size(101, 26);
            this.Volume.TabIndex = 4;
            this.Volume.TabStop = true;
            this.Volume.Text = "Volume";
            this.Volume.UseVisualStyleBackColor = true;
            this.Volume.CheckedChanged += new System.EventHandler(this.Volume_CheckedChanged);
            // 
            // HoldsType
            // 
            this.HoldsType.Controls.Add(this.BackgrounButton);
            this.HoldsType.Controls.Add(this.Volume);
            this.HoldsType.Controls.Add(this.Holds);
            this.HoldsType.Font = new System.Drawing.Font("Myrica M", 11F);
            this.HoldsType.Location = new System.Drawing.Point(12, 69);
            this.HoldsType.Name = "HoldsType";
            this.HoldsType.Size = new System.Drawing.Size(195, 113);
            this.HoldsType.TabIndex = 6;
            this.HoldsType.TabStop = false;
            this.HoldsType.Text = "HoldsType";
            // 
            // BackgrounButton
            // 
            this.BackgrounButton.AutoSize = true;
            this.BackgrounButton.Font = new System.Drawing.Font("Myrica M", 11F);
            this.BackgrounButton.Location = new System.Drawing.Point(6, 76);
            this.BackgrounButton.Name = "BackgrounButton";
            this.BackgrounButton.Size = new System.Drawing.Size(145, 26);
            this.BackgrounButton.TabIndex = 5;
            this.BackgrounButton.TabStop = true;
            this.BackgrounButton.Text = "Background";
            this.BackgrounButton.UseVisualStyleBackColor = true;
            this.BackgrounButton.CheckedChanged += new System.EventHandler(this.BackgrounButton_CheckedChanged);
            // 
            // FolderPath
            // 
            this.FolderPath.Location = new System.Drawing.Point(18, 26);
            this.FolderPath.Name = "FolderPath";
            this.FolderPath.Size = new System.Drawing.Size(356, 25);
            this.FolderPath.TabIndex = 7;
            this.FolderPath.TextChanged += new System.EventHandler(this.FolderPath_TextChanged);
            // 
            // open
            // 
            this.open.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.open.Location = new System.Drawing.Point(402, 26);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(75, 25);
            this.open.TabIndex = 8;
            this.open.Text = "open";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // PaintSizeBox
            // 
            this.PaintSizeBox.Controls.Add(this.paintSizeBar);
            this.PaintSizeBox.Font = new System.Drawing.Font("Myrica M", 11F);
            this.PaintSizeBox.Location = new System.Drawing.Point(12, 188);
            this.PaintSizeBox.Name = "PaintSizeBox";
            this.PaintSizeBox.Size = new System.Drawing.Size(195, 106);
            this.PaintSizeBox.TabIndex = 7;
            this.PaintSizeBox.TabStop = false;
            this.PaintSizeBox.Text = "PaintSize";
            // 
            // paintSizeBar
            // 
            this.paintSizeBar.Location = new System.Drawing.Point(6, 28);
            this.paintSizeBar.Minimum = 1;
            this.paintSizeBar.Name = "paintSizeBar";
            this.paintSizeBar.Size = new System.Drawing.Size(183, 69);
            this.paintSizeBar.TabIndex = 0;
            this.paintSizeBar.Value = 1;
            this.paintSizeBar.Scroll += new System.EventHandler(this.paintSizeBar_Scroll);
            // 
            // InputImageListBox
            // 
            this.InputImageListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputImageListBox.FormattingEnabled = true;
            this.InputImageListBox.ItemHeight = 18;
            this.InputImageListBox.Location = new System.Drawing.Point(1706, 69);
            this.InputImageListBox.Name = "InputImageListBox";
            this.InputImageListBox.Size = new System.Drawing.Size(222, 1246);
            this.InputImageListBox.TabIndex = 12;
            // 
            // LoadButton
            // 
            this.LoadButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LoadButton.Location = new System.Drawing.Point(498, 26);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 25);
            this.LoadButton.TabIndex = 15;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // AlphaBar
            // 
            this.AlphaBar.Location = new System.Drawing.Point(6, 25);
            this.AlphaBar.Maximum = 99;
            this.AlphaBar.Name = "AlphaBar";
            this.AlphaBar.Size = new System.Drawing.Size(183, 69);
            this.AlphaBar.TabIndex = 17;
            this.AlphaBar.Value = 50;
            this.AlphaBar.ValueChanged += new System.EventHandler(this.AlphaBar_ValueChanged);
            // 
            // InputImageGroup
            // 
            this.InputImageGroup.Controls.Add(this.AlphaBar);
            this.InputImageGroup.Font = new System.Drawing.Font("Myrica M", 11F);
            this.InputImageGroup.Location = new System.Drawing.Point(12, 310);
            this.InputImageGroup.Name = "InputImageGroup";
            this.InputImageGroup.Size = new System.Drawing.Size(195, 100);
            this.InputImageGroup.TabIndex = 19;
            this.InputImageGroup.TabStop = false;
            this.InputImageGroup.Text = "Input α";
            // 
            // rotateBox
            // 
            this.rotateBox.Controls.Add(this.RightRotateButton);
            this.rotateBox.Controls.Add(this.LeftRotateButton);
            this.rotateBox.Font = new System.Drawing.Font("Myrica M", 11F);
            this.rotateBox.Location = new System.Drawing.Point(12, 425);
            this.rotateBox.Name = "rotateBox";
            this.rotateBox.Size = new System.Drawing.Size(195, 128);
            this.rotateBox.TabIndex = 20;
            this.rotateBox.TabStop = false;
            this.rotateBox.Text = "RotateBox";
            // 
            // RightRotateButton
            // 
            this.RightRotateButton.Font = new System.Drawing.Font("Myrica M", 11F);
            this.RightRotateButton.Location = new System.Drawing.Point(6, 80);
            this.RightRotateButton.Name = "RightRotateButton";
            this.RightRotateButton.Size = new System.Drawing.Size(132, 33);
            this.RightRotateButton.TabIndex = 22;
            this.RightRotateButton.Text = "Right";
            this.RightRotateButton.UseVisualStyleBackColor = true;
            this.RightRotateButton.Click += new System.EventHandler(this.RightRotateButton_Click);
            // 
            // LeftRotateButton
            // 
            this.LeftRotateButton.Font = new System.Drawing.Font("Myrica M", 11F);
            this.LeftRotateButton.Location = new System.Drawing.Point(6, 41);
            this.LeftRotateButton.Name = "LeftRotateButton";
            this.LeftRotateButton.Size = new System.Drawing.Size(132, 33);
            this.LeftRotateButton.TabIndex = 21;
            this.LeftRotateButton.Text = "Left";
            this.LeftRotateButton.UseVisualStyleBackColor = true;
            this.LeftRotateButton.Click += new System.EventHandler(this.LeftRotateButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Myrica M", 11F);
            this.SaveButton.Location = new System.Drawing.Point(18, 741);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(132, 36);
            this.SaveButton.TabIndex = 21;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Font = new System.Drawing.Font("Myrica M", 11F);
            this.NextButton.Location = new System.Drawing.Point(18, 661);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(132, 34);
            this.NextButton.TabIndex = 22;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // PrevButton
            // 
            this.PrevButton.Font = new System.Drawing.Font("Myrica M", 11F);
            this.PrevButton.Location = new System.Drawing.Point(18, 701);
            this.PrevButton.Name = "PrevButton";
            this.PrevButton.Size = new System.Drawing.Size(132, 34);
            this.PrevButton.TabIndex = 23;
            this.PrevButton.Text = "Prev";
            this.PrevButton.UseVisualStyleBackColor = true;
            this.PrevButton.Click += new System.EventHandler(this.PrevButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Font = new System.Drawing.Font("Myrica M", 11F);
            this.ResetButton.Location = new System.Drawing.Point(18, 568);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(132, 34);
            this.ResetButton.TabIndex = 24;
            this.ResetButton.Text = "ResetImage";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // BoulderingSegmentImageGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1958, 1344);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.PrevButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.rotateBox);
            this.Controls.Add(this.InputImageGroup);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.InputImageListBox);
            this.Controls.Add(this.PaintSizeBox);
            this.Controls.Add(this.open);
            this.Controls.Add(this.FolderPath);
            this.Controls.Add(this.HoldsType);
            this.Controls.Add(this.InputImage);
            this.Font = new System.Drawing.Font("Myrica M", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1980, 1400);
            this.MinimumSize = new System.Drawing.Size(1980, 1400);
            this.Name = "BoulderingSegmentImageGenerator";
            this.Text = "BoulderingSegmentImageGenerator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).EndInit();
            this.HoldsType.ResumeLayout(false);
            this.HoldsType.PerformLayout();
            this.PaintSizeBox.ResumeLayout(false);
            this.PaintSizeBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paintSizeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaBar)).EndInit();
            this.InputImageGroup.ResumeLayout(false);
            this.InputImageGroup.PerformLayout();
            this.rotateBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox InputImage;
        private System.Windows.Forms.RadioButton Holds;
        private System.Windows.Forms.RadioButton Volume;
        private System.Windows.Forms.GroupBox HoldsType;
        private System.Windows.Forms.RadioButton BackgrounButton;
        private System.Windows.Forms.TextBox FolderPath;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox PaintSizeBox;
        private System.Windows.Forms.ListBox InputImageListBox;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.TrackBar AlphaBar;
        private System.Windows.Forms.GroupBox InputImageGroup;
        private System.Windows.Forms.GroupBox rotateBox;
        private System.Windows.Forms.Button RightRotateButton;
        private System.Windows.Forms.Button LeftRotateButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button PrevButton;
        private System.Windows.Forms.TrackBar paintSizeBar;
        private System.Windows.Forms.Button ResetButton;
    }
}

