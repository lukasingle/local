namespace Example8_8_1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbcolortype = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnrotate = new System.Windows.Forms.Button();
            this.numericUpDownBeta = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAlpha = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PlotPanel = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlotPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbcolortype);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnrotate);
            this.panel1.Controls.Add(this.numericUpDownBeta);
            this.panel1.Controls.Add(this.numericUpDownAlpha);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 47);
            this.panel1.TabIndex = 0;
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
            this.cmbcolortype.Location = new System.Drawing.Point(388, 14);
            this.cmbcolortype.Name = "cmbcolortype";
            this.cmbcolortype.Size = new System.Drawing.Size(79, 21);
            this.cmbcolortype.TabIndex = 22;
            this.cmbcolortype.SelectedIndexChanged += new System.EventHandler(this.cmbcolortype_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(325, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "颜色类型 ";
            // 
            // btnrotate
            // 
            this.btnrotate.Location = new System.Drawing.Point(476, 13);
            this.btnrotate.Name = "btnrotate";
            this.btnrotate.Size = new System.Drawing.Size(50, 23);
            this.btnrotate.TabIndex = 20;
            this.btnrotate.Text = "旋转";
            this.btnrotate.UseVisualStyleBackColor = true;
            this.btnrotate.Click += new System.EventHandler(this.btnrotate_Click);
            // 
            // numericUpDownBeta
            // 
            this.numericUpDownBeta.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownBeta.Location = new System.Drawing.Point(182, 16);
            this.numericUpDownBeta.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDownBeta.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericUpDownBeta.Name = "numericUpDownBeta";
            this.numericUpDownBeta.ReadOnly = true;
            this.numericUpDownBeta.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownBeta.TabIndex = 19;
            this.numericUpDownBeta.Value = new decimal(new int[] {
            37,
            0,
            0,
            -2147483648});
            this.numericUpDownBeta.ValueChanged += new System.EventHandler(this.numericUpDownBeta_ValueChanged);
            // 
            // numericUpDownAlpha
            // 
            this.numericUpDownAlpha.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownAlpha.Location = new System.Drawing.Point(57, 15);
            this.numericUpDownAlpha.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDownAlpha.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.numericUpDownAlpha.Name = "numericUpDownAlpha";
            this.numericUpDownAlpha.ReadOnly = true;
            this.numericUpDownAlpha.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownAlpha.TabIndex = 18;
            this.numericUpDownAlpha.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownAlpha.ValueChanged += new System.EventHandler(this.numericUpDownAlpha_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "方位角";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "视角";
            // 
            // PlotPanel
            // 
            this.PlotPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlotPanel.Location = new System.Drawing.Point(0, 47);
            this.PlotPanel.Name = "PlotPanel";
            this.PlotPanel.Size = new System.Drawing.Size(618, 431);
            this.PlotPanel.TabIndex = 1;
            this.PlotPanel.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 478);
            this.Controls.Add(this.PlotPanel);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlotPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox PlotPanel;
        private System.Windows.Forms.ComboBox cmbcolortype;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnrotate;
        private System.Windows.Forms.NumericUpDown numericUpDownBeta;
        private System.Windows.Forms.NumericUpDown numericUpDownAlpha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

