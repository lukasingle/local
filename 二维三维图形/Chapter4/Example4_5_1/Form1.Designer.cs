namespace Example4_5_1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtstring = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txttransx = new System.Windows.Forms.TextBox();
            this.txttransy = new System.Windows.Forms.TextBox();
            this.txtrotate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtscalex = new System.Windows.Forms.TextBox();
            this.txtscaley = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtshearx = new System.Windows.Forms.TextBox();
            this.txtsheary = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnresult = new System.Windows.Forms.Button();
            this.btnreset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnreset);
            this.groupBox1.Controls.Add(this.btnresult);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtsheary);
            this.groupBox1.Controls.Add(this.txtshearx);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtscaley);
            this.groupBox1.Controls.Add(this.txtscalex);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtrotate);
            this.groupBox1.Controls.Add(this.txttransy);
            this.groupBox1.Controls.Add(this.txttransx);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtstring);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 346);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(172, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 346);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "文字串";
            // 
            // txtstring
            // 
            this.txtstring.Location = new System.Drawing.Point(7, 26);
            this.txtstring.Name = "txtstring";
            this.txtstring.Size = new System.Drawing.Size(110, 20);
            this.txtstring.TabIndex = 1;
            this.txtstring.Text = "Hello World";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "平移";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "dx";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "dy";
            // 
            // txttransx
            // 
            this.txttransx.Location = new System.Drawing.Point(49, 64);
            this.txttransx.Name = "txttransx";
            this.txttransx.Size = new System.Drawing.Size(88, 20);
            this.txttransx.TabIndex = 5;
            this.txttransx.Text = "0";
            // 
            // txttransy
            // 
            this.txttransy.Location = new System.Drawing.Point(48, 90);
            this.txttransy.Name = "txttransy";
            this.txttransy.Size = new System.Drawing.Size(88, 20);
            this.txttransy.TabIndex = 6;
            this.txttransy.Text = "150";
            // 
            // txtrotate
            // 
            this.txtrotate.Location = new System.Drawing.Point(49, 131);
            this.txtrotate.Name = "txtrotate";
            this.txtrotate.Size = new System.Drawing.Size(88, 20);
            this.txtrotate.TabIndex = 7;
            this.txtrotate.Text = "45";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "旋转";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "角度";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "缩放";
            // 
            // txtscalex
            // 
            this.txtscalex.Location = new System.Drawing.Point(46, 168);
            this.txtscalex.Name = "txtscalex";
            this.txtscalex.Size = new System.Drawing.Size(88, 20);
            this.txtscalex.TabIndex = 11;
            this.txtscalex.Text = "2";
            // 
            // txtscaley
            // 
            this.txtscaley.Location = new System.Drawing.Point(47, 194);
            this.txtscaley.Name = "txtscaley";
            this.txtscaley.Size = new System.Drawing.Size(88, 20);
            this.txtscaley.TabIndex = 12;
            this.txtscaley.Text = "2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "sx";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "sy";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 218);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "切变";
            // 
            // txtshearx
            // 
            this.txtshearx.Location = new System.Drawing.Point(48, 230);
            this.txtshearx.Name = "txtshearx";
            this.txtshearx.Size = new System.Drawing.Size(88, 20);
            this.txtshearx.TabIndex = 16;
            this.txtshearx.Text = "1";
            // 
            // txtsheary
            // 
            this.txtsheary.Location = new System.Drawing.Point(48, 255);
            this.txtsheary.Name = "txtsheary";
            this.txtsheary.Size = new System.Drawing.Size(88, 20);
            this.txtsheary.TabIndex = 17;
            this.txtsheary.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 233);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(12, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "x";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(34, 258);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(12, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "y";
            // 
            // btnresult
            // 
            this.btnresult.Location = new System.Drawing.Point(38, 283);
            this.btnresult.Name = "btnresult";
            this.btnresult.Size = new System.Drawing.Size(96, 23);
            this.btnresult.TabIndex = 20;
            this.btnresult.Text = "显示结果";
            this.btnresult.UseVisualStyleBackColor = true;
            this.btnresult.Click += new System.EventHandler(this.btnresult_Click);
            // 
            // btnreset
            // 
            this.btnreset.Location = new System.Drawing.Point(38, 314);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(96, 23);
            this.btnreset.TabIndex = 21;
            this.btnreset.Text = "重置";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 351);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Example4_5_1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txttransy;
        private System.Windows.Forms.TextBox txttransx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtstring;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtsheary;
        private System.Windows.Forms.TextBox txtshearx;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtscaley;
        private System.Windows.Forms.TextBox txtscalex;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtrotate;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Button btnresult;
    }
}

