namespace Example7_2_2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbBeta = new System.Windows.Forms.TextBox();
            this.tbAlpha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbAxonometric = new System.Windows.Forms.RadioButton();
            this.rbTrimetric = new System.Windows.Forms.RadioButton();
            this.rbDimetric = new System.Windows.Forms.RadioButton();
            this.rbIsometric = new System.Windows.Forms.RadioButton();
            this.rbTop = new System.Windows.Forms.RadioButton();
            this.rbSide = new System.Windows.Forms.RadioButton();
            this.rbFront = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.rbAxonometric);
            this.groupBox1.Controls.Add(this.rbTrimetric);
            this.groupBox1.Controls.Add(this.rbDimetric);
            this.groupBox1.Controls.Add(this.rbIsometric);
            this.groupBox1.Controls.Add(this.rbTop);
            this.groupBox1.Controls.Add(this.rbSide);
            this.groupBox1.Controls.Add(this.rbFront);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 290);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(8, 256);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(104, 24);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "运行";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbBeta);
            this.groupBox2.Controls.Add(this.tbAlpha);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(16, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(96, 72);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // tbBeta
            // 
            this.tbBeta.Location = new System.Drawing.Point(40, 44);
            this.tbBeta.Name = "tbBeta";
            this.tbBeta.Size = new System.Drawing.Size(48, 20);
            this.tbBeta.TabIndex = 3;
            this.tbBeta.Text = "-45";
            this.tbBeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbAlpha
            // 
            this.tbAlpha.Location = new System.Drawing.Point(40, 12);
            this.tbAlpha.Name = "tbAlpha";
            this.tbAlpha.Size = new System.Drawing.Size(48, 20);
            this.tbAlpha.TabIndex = 2;
            this.tbAlpha.Text = "35";
            this.tbAlpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "beta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "alpha";
            // 
            // rbAxonometric
            // 
            this.rbAxonometric.AutoSize = true;
            this.rbAxonometric.Location = new System.Drawing.Point(8, 160);
            this.rbAxonometric.Name = "rbAxonometric";
            this.rbAxonometric.Size = new System.Drawing.Size(61, 17);
            this.rbAxonometric.TabIndex = 6;
            this.rbAxonometric.Text = "正投影";
            this.rbAxonometric.UseVisualStyleBackColor = true;
            // 
            // rbTrimetric
            // 
            this.rbTrimetric.AutoSize = true;
            this.rbTrimetric.Location = new System.Drawing.Point(8, 136);
            this.rbTrimetric.Name = "rbTrimetric";
            this.rbTrimetric.Size = new System.Drawing.Size(73, 17);
            this.rbTrimetric.TabIndex = 5;
            this.rbTrimetric.Text = "正三轴测";
            this.rbTrimetric.UseVisualStyleBackColor = true;
            // 
            // rbDimetric
            // 
            this.rbDimetric.AutoSize = true;
            this.rbDimetric.Location = new System.Drawing.Point(8, 112);
            this.rbDimetric.Name = "rbDimetric";
            this.rbDimetric.Size = new System.Drawing.Size(73, 17);
            this.rbDimetric.TabIndex = 4;
            this.rbDimetric.Text = "整二轴测";
            this.rbDimetric.UseVisualStyleBackColor = true;
            // 
            // rbIsometric
            // 
            this.rbIsometric.AutoSize = true;
            this.rbIsometric.Checked = true;
            this.rbIsometric.Location = new System.Drawing.Point(8, 88);
            this.rbIsometric.Name = "rbIsometric";
            this.rbIsometric.Size = new System.Drawing.Size(73, 17);
            this.rbIsometric.TabIndex = 3;
            this.rbIsometric.TabStop = true;
            this.rbIsometric.Text = "正等轴测";
            this.rbIsometric.UseVisualStyleBackColor = true;
            // 
            // rbTop
            // 
            this.rbTop.AutoSize = true;
            this.rbTop.Location = new System.Drawing.Point(8, 64);
            this.rbTop.Name = "rbTop";
            this.rbTop.Size = new System.Drawing.Size(61, 17);
            this.rbTop.TabIndex = 2;
            this.rbTop.Text = "俯视图";
            this.rbTop.UseVisualStyleBackColor = true;
            // 
            // rbSide
            // 
            this.rbSide.AutoSize = true;
            this.rbSide.Location = new System.Drawing.Point(8, 40);
            this.rbSide.Name = "rbSide";
            this.rbSide.Size = new System.Drawing.Size(61, 17);
            this.rbSide.TabIndex = 1;
            this.rbSide.Text = "侧视图";
            this.rbSide.UseVisualStyleBackColor = true;
            // 
            // rbFront
            // 
            this.rbFront.AutoSize = true;
            this.rbFront.Location = new System.Drawing.Point(8, 16);
            this.rbFront.Name = "rbFront";
            this.rbFront.Size = new System.Drawing.Size(61, 17);
            this.rbFront.TabIndex = 0;
            this.rbFront.Text = "前视图";
            this.rbFront.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(136, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 280);
            this.panel1.TabIndex = 1;
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 300);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbIsometric;
        private System.Windows.Forms.RadioButton rbTop;
        private System.Windows.Forms.RadioButton rbSide;
        private System.Windows.Forms.RadioButton rbFront;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbAxonometric;
        private System.Windows.Forms.RadioButton rbTrimetric;
        private System.Windows.Forms.RadioButton rbDimetric;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox tbBeta;
        private System.Windows.Forms.TextBox tbAlpha;
    }
}

