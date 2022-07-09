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
            this.point_10 = new System.Windows.Forms.RadioButton();
            this.point_3 = new System.Windows.Forms.RadioButton();
            this.point_1 = new System.Windows.Forms.RadioButton();
            this.point_5 = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.InputImageLabel = new System.Windows.Forms.Label();
            this.SegmentImageLabel = new System.Windows.Forms.Label();
            this.InputImageListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).BeginInit();
            this.HoldsType.SuspendLayout();
            this.PaintSizeBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // InputImage
            // 
            this.InputImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputImage.Location = new System.Drawing.Point(150, 69);
            this.InputImage.Name = "InputImage";
            this.InputImage.Size = new System.Drawing.Size(437, 450);
            this.InputImage.TabIndex = 0;
            this.InputImage.TabStop = false;
            this.InputImage.UseWaitCursor = true;
            this.InputImage.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Holds
            // 
            this.Holds.AutoSize = true;
            this.Holds.Font = new System.Drawing.Font("Myrica M", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Holds.Location = new System.Drawing.Point(6, 28);
            this.Holds.Name = "Holds";
            this.Holds.Size = new System.Drawing.Size(65, 18);
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
            this.Volume.Size = new System.Drawing.Size(73, 18);
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
            this.HoldsType.Size = new System.Drawing.Size(118, 113);
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
            this.BackgrounButton.Size = new System.Drawing.Size(105, 18);
            this.BackgrounButton.TabIndex = 5;
            this.BackgrounButton.TabStop = true;
            this.BackgrounButton.Text = "Background";
            this.BackgrounButton.UseVisualStyleBackColor = true;
            this.BackgrounButton.CheckedChanged += new System.EventHandler(this.BackgrounButton_CheckedChanged);
            // 
            // FolderPath
            // 
            this.FolderPath.Location = new System.Drawing.Point(150, 13);
            this.FolderPath.Name = "FolderPath";
            this.FolderPath.Size = new System.Drawing.Size(356, 19);
            this.FolderPath.TabIndex = 7;
            this.FolderPath.TextChanged += new System.EventHandler(this.FolderPath_TextChanged);
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(512, 11);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(75, 23);
            this.open.TabIndex = 8;
            this.open.Text = "FolderOpen";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
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
            this.PaintSizeBox.Size = new System.Drawing.Size(118, 134);
            this.PaintSizeBox.TabIndex = 7;
            this.PaintSizeBox.TabStop = false;
            this.PaintSizeBox.Text = "PaintSize";
            // 
            // point_10
            // 
            this.point_10.AutoSize = true;
            this.point_10.Font = new System.Drawing.Font("Myrica M", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.point_10.Location = new System.Drawing.Point(6, 100);
            this.point_10.Name = "point_10";
            this.point_10.Size = new System.Drawing.Size(65, 18);
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
            this.point_3.Size = new System.Drawing.Size(57, 18);
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
            this.point_1.Size = new System.Drawing.Size(57, 18);
            this.point_1.TabIndex = 3;
            this.point_1.TabStop = true;
            this.point_1.Text = "1 pt";
            this.point_1.UseVisualStyleBackColor = true;
            // 
            // point_5
            // 
            this.point_5.AutoSize = true;
            this.point_5.Font = new System.Drawing.Font("Myrica M", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.point_5.Location = new System.Drawing.Point(6, 76);
            this.point_5.Name = "point_5";
            this.point_5.Size = new System.Drawing.Size(57, 18);
            this.point_5.TabIndex = 6;
            this.point_5.TabStop = true;
            this.point_5.Text = "5 pt";
            this.point_5.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(682, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(437, 450);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // InputImageLabel
            // 
            this.InputImageLabel.AutoSize = true;
            this.InputImageLabel.Font = new System.Drawing.Font("Myrica M", 11F);
            this.InputImageLabel.Location = new System.Drawing.Point(338, 522);
            this.InputImageLabel.Name = "InputImageLabel";
            this.InputImageLabel.Size = new System.Drawing.Size(95, 14);
            this.InputImageLabel.TabIndex = 10;
            this.InputImageLabel.Text = "Input Image";
            this.InputImageLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // SegmentImageLabel
            // 
            this.SegmentImageLabel.AutoSize = true;
            this.SegmentImageLabel.Font = new System.Drawing.Font("Myrica M", 11F);
            this.SegmentImageLabel.Location = new System.Drawing.Point(857, 522);
            this.SegmentImageLabel.Name = "SegmentImageLabel";
            this.SegmentImageLabel.Size = new System.Drawing.Size(127, 14);
            this.SegmentImageLabel.TabIndex = 11;
            this.SegmentImageLabel.Text = "Segmented Image";
            // 
            // InputImageListBox
            // 
            this.InputImageListBox.FormattingEnabled = true;
            this.InputImageListBox.ItemHeight = 12;
            this.InputImageListBox.Location = new System.Drawing.Point(1168, 69);
            this.InputImageListBox.Name = "InputImageListBox";
            this.InputImageListBox.Size = new System.Drawing.Size(222, 448);
            this.InputImageListBox.TabIndex = 12;
            this.InputImageListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // BoulderingSegmentImageGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1423, 621);
            this.Controls.Add(this.InputImageListBox);
            this.Controls.Add(this.SegmentImageLabel);
            this.Controls.Add(this.InputImageLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PaintSizeBox);
            this.Controls.Add(this.open);
            this.Controls.Add(this.FolderPath);
            this.Controls.Add(this.HoldsType);
            this.Controls.Add(this.InputImage);
            this.Font = new System.Drawing.Font("Myrica M", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "BoulderingSegmentImageGenerator";
            this.Text = "BoulderingSegmentImageGenerator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).EndInit();
            this.HoldsType.ResumeLayout(false);
            this.HoldsType.PerformLayout();
            this.PaintSizeBox.ResumeLayout(false);
            this.PaintSizeBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox InputImage;
        private System.Windows.Forms.RadioButton Holds;
        private System.Windows.Forms.RadioButton Volume;
        private System.Windows.Forms.GroupBox HoldsType;
        private Paint paint = new Paint();
        private System.Windows.Forms.RadioButton BackgrounButton;
        private System.Windows.Forms.TextBox FolderPath;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox PaintSizeBox;
        private System.Windows.Forms.RadioButton point_5;
        private System.Windows.Forms.RadioButton point_10;
        private System.Windows.Forms.RadioButton point_3;
        private System.Windows.Forms.RadioButton point_1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label InputImageLabel;
        private System.Windows.Forms.Label SegmentImageLabel;
        private System.Windows.Forms.ListBox InputImageListBox;
    }
}

