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
            this.point_5 = new System.Windows.Forms.RadioButton();
            this.point_10 = new System.Windows.Forms.RadioButton();
            this.point_3 = new System.Windows.Forms.RadioButton();
            this.point_1 = new System.Windows.Forms.RadioButton();
            this.InputImageListBox = new System.Windows.Forms.ListBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.PrevButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.AlphaBar = new System.Windows.Forms.TrackBar();
            this.InputImageGroup = new System.Windows.Forms.GroupBox();
            this.rotateBox = new System.Windows.Forms.GroupBox();
            this.RightRotateButton = new System.Windows.Forms.Button();
            this.LeftRotateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).BeginInit();
            this.HoldsType.SuspendLayout();
            this.PaintSizeBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
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
            this.InputImage.Click += new System.EventHandler(this.InputImage_Click);
            this.InputImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InputImage_MouseDown);
            this.InputImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.InputImage_MouseUp);
            this.InputImage.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.InputImage_MouseWheel);
            this.InputImage.Paint += new System.Windows.Forms.PaintEventHandler(this.InputImage_Paint);
            // 
            // Holds
            // 
            this.Holds.AutoSize = true;
            this.Holds.Font = new System.Drawing.Font("Myrica M", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Holds.Location = new System.Drawing.Point(6, 28);
            this.Holds.Name = "Holds";
            this.Holds.Size = new System.Drawing.Size(95, 27);
            this.Holds.TabIndex = 3;
            this.Holds.TabStop = true;
            this.Holds.Text = "Holds";
            this.Holds.UseVisualStyleBackColor = true;
            this.Holds.CheckedChanged += new System.EventHandler(this.Holds_CheckedChanged);
            // 
            // Volume
            // 
            this.Volume.AutoSize = true;
            this.Volume.Font = new System.Drawing.Font("Myrica M", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Volume.Location = new System.Drawing.Point(6, 52);
            this.Volume.Name = "Volume";
            this.Volume.Size = new System.Drawing.Size(107, 27);
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
            this.HoldsType.Font = new System.Drawing.Font("Myrica M", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.BackgrounButton.Font = new System.Drawing.Font("Myrica M", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BackgrounButton.Location = new System.Drawing.Point(6, 76);
            this.BackgrounButton.Name = "BackgrounButton";
            this.BackgrounButton.Size = new System.Drawing.Size(155, 27);
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
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.HelpRequest += new System.EventHandler(this.folderBrowserDialog_HelpRequest);
            // 
            // PaintSizeBox
            // 
            this.PaintSizeBox.Controls.Add(this.point_5);
            this.PaintSizeBox.Controls.Add(this.point_10);
            this.PaintSizeBox.Controls.Add(this.point_3);
            this.PaintSizeBox.Controls.Add(this.point_1);
            this.PaintSizeBox.Font = new System.Drawing.Font("Myrica M", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PaintSizeBox.Location = new System.Drawing.Point(12, 188);
            this.PaintSizeBox.Name = "PaintSizeBox";
            this.PaintSizeBox.Size = new System.Drawing.Size(195, 134);
            this.PaintSizeBox.TabIndex = 7;
            this.PaintSizeBox.TabStop = false;
            this.PaintSizeBox.Text = "PaintSize";
            // 
            // point_5
            // 
            this.point_5.AutoSize = true;
            this.point_5.Font = new System.Drawing.Font("Myrica M", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.point_5.Location = new System.Drawing.Point(6, 76);
            this.point_5.Name = "point_5";
            this.point_5.Size = new System.Drawing.Size(83, 27);
            this.point_5.TabIndex = 6;
            this.point_5.TabStop = true;
            this.point_5.Text = "5 pt";
            this.point_5.UseVisualStyleBackColor = true;
            // 
            // point_10
            // 
            this.point_10.AutoSize = true;
            this.point_10.Font = new System.Drawing.Font("Myrica M", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.point_10.Location = new System.Drawing.Point(6, 100);
            this.point_10.Name = "point_10";
            this.point_10.Size = new System.Drawing.Size(95, 27);
            this.point_10.TabIndex = 5;
            this.point_10.TabStop = true;
            this.point_10.Text = "10 pt";
            this.point_10.UseVisualStyleBackColor = true;
            // 
            // point_3
            // 
            this.point_3.AutoSize = true;
            this.point_3.Font = new System.Drawing.Font("Myrica M", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.point_3.Location = new System.Drawing.Point(6, 52);
            this.point_3.Name = "point_3";
            this.point_3.Size = new System.Drawing.Size(83, 27);
            this.point_3.TabIndex = 4;
            this.point_3.TabStop = true;
            this.point_3.Text = "3 pt";
            this.point_3.UseVisualStyleBackColor = true;
            // 
            // point_1
            // 
            this.point_1.AutoSize = true;
            this.point_1.Font = new System.Drawing.Font("Myrica M", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.point_1.Location = new System.Drawing.Point(6, 28);
            this.point_1.Name = "point_1";
            this.point_1.Size = new System.Drawing.Size(83, 27);
            this.point_1.TabIndex = 3;
            this.point_1.TabStop = true;
            this.point_1.Text = "1 pt";
            this.point_1.UseVisualStyleBackColor = true;
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
            this.InputImageListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // NextButton
            // 
            this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NextButton.Location = new System.Drawing.Point(18, -200);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 13;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            // 
            // PrevButton
            // 
            this.PrevButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PrevButton.Location = new System.Drawing.Point(18, -171);
            this.PrevButton.Name = "PrevButton";
            this.PrevButton.Size = new System.Drawing.Size(75, 23);
            this.PrevButton.TabIndex = 14;
            this.PrevButton.Text = "Prev";
            this.PrevButton.UseVisualStyleBackColor = true;
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
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(156, 829);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(8, 69);
            this.trackBar1.TabIndex = 16;
            // 
            // AlphaBar
            // 
            this.AlphaBar.Location = new System.Drawing.Point(6, 25);
            this.AlphaBar.Maximum = 99;
            this.AlphaBar.Name = "AlphaBar";
            this.AlphaBar.Size = new System.Drawing.Size(183, 69);
            this.AlphaBar.TabIndex = 17;
            this.AlphaBar.Value = 50;
            this.AlphaBar.Scroll += new System.EventHandler(this.AlphaBar_Scroll);
            // 
            // InputImageGroup
            // 
            this.InputImageGroup.Controls.Add(this.AlphaBar);
            this.InputImageGroup.Font = new System.Drawing.Font("Myrica M", 11.25F);
            this.InputImageGroup.Location = new System.Drawing.Point(12, 348);
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
            this.rotateBox.Font = new System.Drawing.Font("Myrica M", 11.25F);
            this.rotateBox.Location = new System.Drawing.Point(12, 463);
            this.rotateBox.Name = "rotateBox";
            this.rotateBox.Size = new System.Drawing.Size(195, 128);
            this.rotateBox.TabIndex = 20;
            this.rotateBox.TabStop = false;
            this.rotateBox.Text = "RotateBox";
            // 
            // RightRotateButton
            // 
            this.RightRotateButton.Location = new System.Drawing.Point(6, 80);
            this.RightRotateButton.Name = "RightRotateButton";
            this.RightRotateButton.Size = new System.Drawing.Size(97, 33);
            this.RightRotateButton.TabIndex = 22;
            this.RightRotateButton.Text = "Right";
            this.RightRotateButton.UseVisualStyleBackColor = true;
            this.RightRotateButton.Click += new System.EventHandler(this.RightRotateButton_Click);
            // 
            // LeftRotateButton
            // 
            this.LeftRotateButton.Location = new System.Drawing.Point(6, 41);
            this.LeftRotateButton.Name = "LeftRotateButton";
            this.LeftRotateButton.Size = new System.Drawing.Size(97, 33);
            this.LeftRotateButton.TabIndex = 21;
            this.LeftRotateButton.Text = "Left";
            this.LeftRotateButton.UseVisualStyleBackColor = true;
            this.LeftRotateButton.Click += new System.EventHandler(this.LeftRotateButton_Click);
            // 
            // BoulderingSegmentImageGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1958, 1344);
            this.Controls.Add(this.rotateBox);
            this.Controls.Add(this.InputImageGroup);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.PrevButton);
            this.Controls.Add(this.NextButton);
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
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).EndInit();
            this.HoldsType.ResumeLayout(false);
            this.HoldsType.PerformLayout();
            this.PaintSizeBox.ResumeLayout(false);
            this.PaintSizeBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
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
        private System.Windows.Forms.RadioButton point_5;
        private System.Windows.Forms.RadioButton point_10;
        private System.Windows.Forms.RadioButton point_3;
        private System.Windows.Forms.RadioButton point_1;
        private System.Windows.Forms.ListBox InputImageListBox;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button PrevButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar AlphaBar;
        private System.Windows.Forms.GroupBox InputImageGroup;
        private System.Windows.Forms.GroupBox rotateBox;
        private System.Windows.Forms.Button RightRotateButton;
        private System.Windows.Forms.Button LeftRotateButton;
    }
}

