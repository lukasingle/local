namespace Example7_2_9
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
            this.paneltoolbar = new System.Windows.Forms.Panel();
            this.btnpan = new System.Windows.Forms.Button();
            this.txtdy = new System.Windows.Forms.TextBox();
            this.txtdx = new System.Windows.Forms.TextBox();
            this.txtye = new System.Windows.Forms.TextBox();
            this.txtxe = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbcolortype = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnrotate = new System.Windows.Forms.Button();
            this.txtyc = new System.Windows.Forms.TextBox();
            this.txtxc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownBeta = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAlpha = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pcbplot = new System.Windows.Forms.PictureBox();
            this.paneltoolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbplot)).BeginInit();
            this.SuspendLayout();
            // 
            // paneltoolbar
            // 
            this.paneltoolbar.Controls.Add(this.btnpan);
            this.paneltoolbar.Controls.Add(this.txtdy);
            this.paneltoolbar.Controls.Add(this.txtdx);
            this.paneltoolbar.Controls.Add(this.txtye);
            this.paneltoolbar.Controls.Add(this.txtxe);
            this.paneltoolbar.Controls.Add(this.label11);
            this.paneltoolbar.Controls.Add(this.label10);
            this.paneltoolbar.Controls.Add(this.label9);
            this.paneltoolbar.Controls.Add(this.label8);
            this.paneltoolbar.Controls.Add(this.cmbcolortype);
            this.paneltoolbar.Controls.Add(this.label5);
            this.paneltoolbar.Controls.Add(this.btnrotate);
            this.paneltoolbar.Controls.Add(this.txtyc);
            this.paneltoolbar.Controls.Add(this.txtxc);
            this.paneltoolbar.Controls.Add(this.label4);
            this.paneltoolbar.Controls.Add(this.label3);
            this.paneltoolbar.Controls.Add(this.numericUpDownBeta);
            this.paneltoolbar.Controls.Add(this.numericUpDownAlpha);
            this.paneltoolbar.Controls.Add(this.label2);
            this.paneltoolbar.Controls.Add(this.label1);
            this.paneltoolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneltoolbar.Location = new System.Drawing.Point(0, 0);
            this.paneltoolbar.Name = "paneltoolbar";
            this.paneltoolbar.Size = new System.Drawing.Size(525, 68);
            this.paneltoolbar.TabIndex = 0;
            // 
            // btnpan
            // 
            this.btnpan.Location = new System.Drawing.Point(463, 38);
            this.btnpan.Name = "btnpan";
            this.btnpan.Size = new System.Drawing.Size(50, 23);
            this.btnpan.TabIndex = 28;
            this.btnpan.Text = "变换";
            this.btnpan.UseVisualStyleBackColor = true;
            this.btnpan.Click += new System.EventHandler(this.btnpan_Click);
            // 
            // txtdy
            // 
            this.txtdy.Location = new System.Drawing.Point(397, 44);
            this.txtdy.Name = "txtdy";
            this.txtdy.Size = new System.Drawing.Size(52, 20);
            this.txtdy.TabIndex = 27;
            // 
            // txtdx
            // 
            this.txtdx.Location = new System.Drawing.Point(292, 43);
            this.txtdx.Name = "txtdx";
            this.txtdx.Size = new System.Drawing.Size(52, 20);
            this.txtdx.TabIndex = 26;
            // 
            // txtye
            // 
            this.txtye.Location = new System.Drawing.Point(191, 42);
            this.txtye.Name = "txtye";
            this.txtye.Size = new System.Drawing.Size(52, 20);
            this.txtye.TabIndex = 25;
            // 
            // txtxe
            // 
            this.txtxe.Location = new System.Drawing.Point(96, 43);
            this.txtxe.Name = "txtxe";
            this.txtxe.Size = new System.Drawing.Size(52, 20);
            this.txtxe.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(377, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "dy";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(272, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "dx";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(172, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "ye";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(77, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "xe";
            // 
            // cmbcolortype
            // 
            this.cmbcolortype.FormattingEnabled = true;
            this.cmbcolortype.Items.AddRange(new object[] {
            "Autumn",
            "FallGrYl",
            "FallRdGr",
            "Cool",
            "Cool1",
            "Cool11",
            "Cool2",
            "Cool22",
            "DeltaRdGr",
            "DeltaRdBl",
            "DeltaGrBl",
            "DeltaGrRd",
            "Gray",
            "Hot",
            "Hot1",
            "Hot2",
            "Jet",
            "JetD1",
            "Mix1",
            "Mix2",
            "Mix3",
            "Mix4",
            "Rainbow",
            "Spring",
            "Summer",
            "Winter"});
            this.cmbcolortype.Location = new System.Drawing.Point(392, 8);
            this.cmbcolortype.Name = "cmbcolortype";
            this.cmbcolortype.Size = new System.Drawing.Size(63, 21);
            this.cmbcolortype.TabIndex = 15;
            this.cmbcolortype.SelectedIndexChanged += new System.EventHandler(this.cmbcolortype_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(337, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "颜色类型";
            // 
            // btnrotate
            // 
            this.btnrotate.Location = new System.Drawing.Point(464, 7);
            this.btnrotate.Name = "btnrotate";
            this.btnrotate.Size = new System.Drawing.Size(50, 23);
            this.btnrotate.TabIndex = 13;
            this.btnrotate.Text = "旋转";
            this.btnrotate.UseVisualStyleBackColor = true;
            this.btnrotate.Click += new System.EventHandler(this.btnrotate_Click);
            // 
            // txtyc
            // 
            this.txtyc.Location = new System.Drawing.Point(290, 8);
            this.txtyc.Name = "txtyc";
            this.txtyc.Size = new System.Drawing.Size(42, 20);
            this.txtyc.TabIndex = 12;
            this.txtyc.Text = "-10";
            this.txtyc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtyc_KeyUp);
            // 
            // txtxc
            // 
            this.txtxc.Location = new System.Drawing.Point(219, 8);
            this.txtxc.Name = "txtxc";
            this.txtxc.Size = new System.Drawing.Size(42, 20);
            this.txtxc.TabIndex = 11;
            this.txtxc.Text = "10";
            this.txtxc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtxc_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Yc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Xc";
            // 
            // numericUpDownBeta
            // 
            this.numericUpDownBeta.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownBeta.Location = new System.Drawing.Point(133, 7);
            this.numericUpDownBeta.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownBeta.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownBeta.Name = "numericUpDownBeta";
            this.numericUpDownBeta.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownBeta.TabIndex = 8;
            this.numericUpDownBeta.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.numericUpDownBeta.ValueChanged += new System.EventHandler(this.numericUpDownBeta_ValueChanged);
            // 
            // numericUpDownAlpha
            // 
            this.numericUpDownAlpha.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownAlpha.Location = new System.Drawing.Point(45, 6);
            this.numericUpDownAlpha.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownAlpha.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownAlpha.Name = "numericUpDownAlpha";
            this.numericUpDownAlpha.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownAlpha.TabIndex = 7;
            this.numericUpDownAlpha.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.numericUpDownAlpha.ValueChanged += new System.EventHandler(this.numericUpDownAlpha_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Beta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Alpha";
            // 
            // pcbplot
            // 
            this.pcbplot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbplot.Location = new System.Drawing.Point(0, 68);
            this.pcbplot.Name = "pcbplot";
            this.pcbplot.Size = new System.Drawing.Size(525, 343);
            this.pcbplot.TabIndex = 1;
            this.pcbplot.TabStop = false;
            this.pcbplot.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.pcbplot.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnLeftMouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 411);
            this.Controls.Add(this.pcbplot);
            this.Controls.Add(this.paneltoolbar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.paneltoolbar.ResumeLayout(false);
            this.paneltoolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbplot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel paneltoolbar;
        private System.Windows.Forms.TextBox txtyc;
        private System.Windows.Forms.TextBox txtxc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownBeta;
        private System.Windows.Forms.NumericUpDown numericUpDownAlpha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnrotate;
        public System.Windows.Forms.PictureBox pcbplot;
        private System.Windows.Forms.ComboBox cmbcolortype;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtdy;
        private System.Windows.Forms.TextBox txtdx;
        private System.Windows.Forms.TextBox txtye;
        private System.Windows.Forms.TextBox txtxe;
        private System.Windows.Forms.Button btnpan;
    }
}

