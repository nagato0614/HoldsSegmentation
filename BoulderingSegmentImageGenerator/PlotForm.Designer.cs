namespace BoulderingSegmentImageGenerator
{
    partial class PlotForm
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
            this.fp = new ScottPlot.FormsPlot();
            this.SuspendLayout();
            // 
            // formsPlot1
            // 
            this.fp.Location = new System.Drawing.Point(56, 13);
            this.fp.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.fp.Name = "formsPlot1";
            this.fp.Size = new System.Drawing.Size(667, 415);
            this.fp.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fp);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private ScottPlot.FormsPlot fp;
    }
}