namespace Example2_3_4
{
    partial class Mapfrm
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
            this.btnRun = new System.Windows.Forms.Button();
            this.pcbDraw = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnline = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDraw)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(97, 345);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(90, 23);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "直接颜色映射";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // pcbDraw
            // 
            this.pcbDraw.Location = new System.Drawing.Point(9, 6);
            this.pcbDraw.Name = "pcbDraw";
            this.pcbDraw.Size = new System.Drawing.Size(301, 301);
            this.pcbDraw.TabIndex = 2;
            this.pcbDraw.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(331, 6);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(131, 303);
            this.listBox1.TabIndex = 3;
            // 
            // btnline
            // 
            this.btnline.Location = new System.Drawing.Point(309, 345);
            this.btnline.Name = "btnline";
            this.btnline.Size = new System.Drawing.Size(104, 23);
            this.btnline.TabIndex = 4;
            this.btnline.Text = "插值法颜色映射";
            this.btnline.UseVisualStyleBackColor = true;
            this.btnline.Click += new System.EventHandler(this.btnline_Click);
            // 
            // Mapfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 385);
            this.Controls.Add(this.btnline);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pcbDraw);
            this.Controls.Add(this.btnRun);
            this.Location = new System.Drawing.Point(752, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mapfrm";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mapfrm";
            this.Load += new System.EventHandler(this.Mapfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbDraw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.PictureBox pcbDraw;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnline;
    }
}