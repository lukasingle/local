namespace Example7_2_3
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
            this.tbTheta = new System.Windows.Forms.TextBox();
            this.tbAlpha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbOblique = new System.Windows.Forms.RadioButton();
            this.rbCabinet = new System.Windows.Forms.RadioButton();
            this.rbCavalier = new System.Windows.Forms.RadioButton();
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
            this.groupBox1.Controls.Add(this.rbOblique);
            this.groupBox1.Controls.Add(this.rbCabinet);
            this.groupBox1.Controls.Add(this.rbCavalier);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 290);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(8, 224);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(104, 24);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "运行";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbTheta);
            this.groupBox2.Controls.Add(this.tbAlpha);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(8, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(104, 72);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // tbTheta
            // 
            this.tbTheta.Location = new System.Drawing.Point(48, 44);
            this.tbTheta.Name = "tbTheta";
            this.tbTheta.Size = new System.Drawing.Size(48, 20);
            this.tbTheta.TabIndex = 3;
            this.tbTheta.Text = "45";
            this.tbTheta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbAlpha
            // 
            this.tbAlpha.Enabled = false;
            this.tbAlpha.Location = new System.Drawing.Point(48, 12);
            this.tbAlpha.Name = "tbAlpha";
            this.tbAlpha.Size = new System.Drawing.Size(48, 20);
            this.tbAlpha.TabIndex = 2;
            this.tbAlpha.Text = "45";
            this.tbAlpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Theta";
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
            // rbOblique
            // 
            this.rbOblique.AutoSize = true;
            this.rbOblique.Location = new System.Drawing.Point(8, 96);
            this.rbOblique.Name = "rbOblique";
            this.rbOblique.Size = new System.Drawing.Size(61, 17);
            this.rbOblique.TabIndex = 2;
            this.rbOblique.Text = "斜投影";
            this.rbOblique.UseVisualStyleBackColor = true;
            this.rbOblique.CheckedChanged += new System.EventHandler(this.rbOblique_CheckedChanged);
            // 
            // rbCabinet
            // 
            this.rbCabinet.AutoSize = true;
            this.rbCabinet.Location = new System.Drawing.Point(8, 56);
            this.rbCabinet.Name = "rbCabinet";
            this.rbCabinet.Size = new System.Drawing.Size(85, 17);
            this.rbCabinet.TabIndex = 1;
            this.rbCabinet.Text = "斜二测投影";
            this.rbCabinet.UseVisualStyleBackColor = true;
            this.rbCabinet.CheckedChanged += new System.EventHandler(this.rbCabinet_CheckedChanged);
            // 
            // rbCavalier
            // 
            this.rbCavalier.AutoSize = true;
            this.rbCavalier.Checked = true;
            this.rbCavalier.Location = new System.Drawing.Point(8, 16);
            this.rbCavalier.Name = "rbCavalier";
            this.rbCavalier.Size = new System.Drawing.Size(85, 17);
            this.rbCavalier.TabIndex = 0;
            this.rbCavalier.TabStop = true;
            this.rbCavalier.Text = "斜等测投影";
            this.rbCavalier.UseVisualStyleBackColor = true;
            this.rbCavalier.CheckedChanged += new System.EventHandler(this.rbCavalier_CheckedChanged);
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
        private System.Windows.Forms.RadioButton rbOblique;
        private System.Windows.Forms.RadioButton rbCabinet;
        private System.Windows.Forms.RadioButton rbCavalier;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox tbTheta;
        private System.Windows.Forms.TextBox tbAlpha;
    }
}

