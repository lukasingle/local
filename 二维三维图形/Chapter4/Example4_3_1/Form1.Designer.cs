namespace Example4_3_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.lblShearY = new System.Windows.Forms.Label();
            this.tShearY = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.lblShearX = new System.Windows.Forms.Label();
            this.tShearX = new System.Windows.Forms.TrackBar();
            this.cbShear = new System.Windows.Forms.CheckBox();
            this.cbRealtime = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.cbFlipY = new System.Windows.Forms.CheckBox();
            this.pictureBoxBase = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblStrY = new System.Windows.Forms.Label();
            this.tStrY = new System.Windows.Forms.TrackBar();
            this.cbStretch = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lblStrX = new System.Windows.Forms.Label();
            this.tStrX = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.lblRotY = new System.Windows.Forms.Label();
            this.tRotY = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.lblRotX = new System.Windows.Forms.Label();
            this.tRotX = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTransY = new System.Windows.Forms.Label();
            this.tTransY = new System.Windows.Forms.TrackBar();
            this.cbTranslation = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTransX = new System.Windows.Forms.Label();
            this.tTransX = new System.Windows.Forms.TrackBar();
            this.cbRotate = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblRotDeg = new System.Windows.Forms.Label();
            this.tRotDeg = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tShearY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tShearX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStrY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStrX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRotY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRotX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTransY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTransX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRotDeg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(460, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 24);
            this.label1.TabIndex = 82;
            this.label1.Text = "Y";
            // 
            // lblShearY
            // 
            this.lblShearY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblShearY.Location = new System.Drawing.Point(612, 367);
            this.lblShearY.Name = "lblShearY";
            this.lblShearY.Size = new System.Drawing.Size(32, 24);
            this.lblShearY.TabIndex = 81;
            // 
            // tShearY
            // 
            this.tShearY.AutoSize = false;
            this.tShearY.LargeChange = 1;
            this.tShearY.Location = new System.Drawing.Point(508, 367);
            this.tShearY.Maximum = 20;
            this.tShearY.Minimum = -20;
            this.tShearY.Name = "tShearY";
            this.tShearY.Size = new System.Drawing.Size(104, 24);
            this.tShearY.TabIndex = 80;
            this.tShearY.TickFrequency = 10;
            this.tShearY.ValueChanged += new System.EventHandler(this.tShearY_ValueChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(460, 335);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 24);
            this.label6.TabIndex = 79;
            this.label6.Text = "X";
            // 
            // lblShearX
            // 
            this.lblShearX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblShearX.Location = new System.Drawing.Point(612, 335);
            this.lblShearX.Name = "lblShearX";
            this.lblShearX.Size = new System.Drawing.Size(32, 24);
            this.lblShearX.TabIndex = 78;
            // 
            // tShearX
            // 
            this.tShearX.AutoSize = false;
            this.tShearX.LargeChange = 1;
            this.tShearX.Location = new System.Drawing.Point(508, 335);
            this.tShearX.Maximum = 20;
            this.tShearX.Minimum = -20;
            this.tShearX.Name = "tShearX";
            this.tShearX.Size = new System.Drawing.Size(104, 24);
            this.tShearX.TabIndex = 77;
            this.tShearX.TickFrequency = 10;
            this.tShearX.ValueChanged += new System.EventHandler(this.tShearX_ValueChanged);
            // 
            // cbShear
            // 
            this.cbShear.Location = new System.Drawing.Point(444, 303);
            this.cbShear.Name = "cbShear";
            this.cbShear.Size = new System.Drawing.Size(104, 24);
            this.cbShear.TabIndex = 76;
            this.cbShear.Text = "切变";
            this.cbShear.CheckedChanged += new System.EventHandler(this.cbShear_CheckedChanged);
            // 
            // cbRealtime
            // 
            this.cbRealtime.Location = new System.Drawing.Point(156, 423);
            this.cbRealtime.Name = "cbRealtime";
            this.cbRealtime.Size = new System.Drawing.Size(112, 16);
            this.cbRealtime.TabIndex = 75;
            this.cbRealtime.Text = "实时";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(276, 423);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(64, 24);
            this.btnReset.TabIndex = 74;
            this.btnReset.Text = "重置";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cbFlipY
            // 
            this.cbFlipY.Checked = true;
            this.cbFlipY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFlipY.Location = new System.Drawing.Point(28, 423);
            this.cbFlipY.Name = "cbFlipY";
            this.cbFlipY.Size = new System.Drawing.Size(112, 16);
            this.cbFlipY.TabIndex = 73;
            this.cbFlipY.Text = "翻转Y坐标";
            this.cbFlipY.CheckedChanged += new System.EventHandler(this.cbFlipY_CheckedChanged);
            // 
            // pictureBoxBase
            // 
            this.pictureBoxBase.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxBase.Image")));
            this.pictureBoxBase.Location = new System.Drawing.Point(68, 447);
            this.pictureBoxBase.Name = "pictureBoxBase";
            this.pictureBoxBase.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxBase.TabIndex = 72;
            this.pictureBoxBase.TabStop = false;
            this.pictureBoxBase.Visible = false;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(460, 271);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 24);
            this.label14.TabIndex = 71;
            this.label14.Text = "Y";
            // 
            // lblStrY
            // 
            this.lblStrY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStrY.Location = new System.Drawing.Point(612, 271);
            this.lblStrY.Name = "lblStrY";
            this.lblStrY.Size = new System.Drawing.Size(32, 24);
            this.lblStrY.TabIndex = 70;
            // 
            // tStrY
            // 
            this.tStrY.AutoSize = false;
            this.tStrY.LargeChange = 1;
            this.tStrY.Location = new System.Drawing.Point(508, 271);
            this.tStrY.Maximum = 20;
            this.tStrY.Minimum = 1;
            this.tStrY.Name = "tStrY";
            this.tStrY.Size = new System.Drawing.Size(104, 24);
            this.tStrY.TabIndex = 69;
            this.tStrY.Value = 10;
            this.tStrY.ValueChanged += new System.EventHandler(this.tStrY_ValueChanged);
            // 
            // cbStretch
            // 
            this.cbStretch.Location = new System.Drawing.Point(444, 215);
            this.cbStretch.Name = "cbStretch";
            this.cbStretch.Size = new System.Drawing.Size(80, 16);
            this.cbStretch.TabIndex = 68;
            this.cbStretch.Text = "缩放";
            this.cbStretch.CheckedChanged += new System.EventHandler(this.cbStretch_CheckedChanged);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(460, 239);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 24);
            this.label16.TabIndex = 67;
            this.label16.Text = "X";
            // 
            // lblStrX
            // 
            this.lblStrX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStrX.Location = new System.Drawing.Point(612, 239);
            this.lblStrX.Name = "lblStrX";
            this.lblStrX.Size = new System.Drawing.Size(32, 24);
            this.lblStrX.TabIndex = 66;
            // 
            // tStrX
            // 
            this.tStrX.AutoSize = false;
            this.tStrX.LargeChange = 1;
            this.tStrX.Location = new System.Drawing.Point(508, 239);
            this.tStrX.Maximum = 20;
            this.tStrX.Minimum = 1;
            this.tStrX.Name = "tStrX";
            this.tStrX.Size = new System.Drawing.Size(104, 24);
            this.tStrX.TabIndex = 65;
            this.tStrX.Value = 10;
            this.tStrX.ValueChanged += new System.EventHandler(this.tStrX_ValueChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(460, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 24);
            this.label9.TabIndex = 64;
            this.label9.Text = "Y";
            // 
            // lblRotY
            // 
            this.lblRotY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRotY.Location = new System.Drawing.Point(612, 95);
            this.lblRotY.Name = "lblRotY";
            this.lblRotY.Size = new System.Drawing.Size(32, 24);
            this.lblRotY.TabIndex = 63;
            // 
            // tRotY
            // 
            this.tRotY.AutoSize = false;
            this.tRotY.LargeChange = 1;
            this.tRotY.Location = new System.Drawing.Point(508, 95);
            this.tRotY.Maximum = 50;
            this.tRotY.Minimum = -50;
            this.tRotY.Name = "tRotY";
            this.tRotY.Size = new System.Drawing.Size(104, 24);
            this.tRotY.TabIndex = 62;
            this.tRotY.TickFrequency = 10;
            this.tRotY.ValueChanged += new System.EventHandler(this.tRotY_ValueChanged);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(460, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 24);
            this.label11.TabIndex = 61;
            this.label11.Text = "X";
            // 
            // lblRotX
            // 
            this.lblRotX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRotX.Location = new System.Drawing.Point(612, 63);
            this.lblRotX.Name = "lblRotX";
            this.lblRotX.Size = new System.Drawing.Size(32, 24);
            this.lblRotX.TabIndex = 60;
            // 
            // tRotX
            // 
            this.tRotX.AutoSize = false;
            this.tRotX.LargeChange = 1;
            this.tRotX.Location = new System.Drawing.Point(508, 63);
            this.tRotX.Maximum = 50;
            this.tRotX.Minimum = -50;
            this.tRotX.Name = "tRotX";
            this.tRotX.Size = new System.Drawing.Size(104, 24);
            this.tRotX.TabIndex = 59;
            this.tRotX.TickFrequency = 10;
            this.tRotX.ValueChanged += new System.EventHandler(this.tRotX_ValueChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(460, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 24);
            this.label5.TabIndex = 58;
            this.label5.Text = "Y";
            // 
            // lblTransY
            // 
            this.lblTransY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTransY.Location = new System.Drawing.Point(612, 183);
            this.lblTransY.Name = "lblTransY";
            this.lblTransY.Size = new System.Drawing.Size(32, 24);
            this.lblTransY.TabIndex = 57;
            // 
            // tTransY
            // 
            this.tTransY.AutoSize = false;
            this.tTransY.LargeChange = 1;
            this.tTransY.Location = new System.Drawing.Point(508, 183);
            this.tTransY.Maximum = 150;
            this.tTransY.Minimum = -150;
            this.tTransY.Name = "tTransY";
            this.tTransY.Size = new System.Drawing.Size(104, 24);
            this.tTransY.TabIndex = 56;
            this.tTransY.TickFrequency = 20;
            this.tTransY.ValueChanged += new System.EventHandler(this.tTransY_ValueChanged);
            // 
            // cbTranslation
            // 
            this.cbTranslation.Location = new System.Drawing.Point(444, 127);
            this.cbTranslation.Name = "cbTranslation";
            this.cbTranslation.Size = new System.Drawing.Size(88, 16);
            this.cbTranslation.TabIndex = 55;
            this.cbTranslation.Text = "平移";
            this.cbTranslation.CheckedChanged += new System.EventHandler(this.cbTranslation_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(460, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 24);
            this.label3.TabIndex = 54;
            this.label3.Text = "X";
            // 
            // lblTransX
            // 
            this.lblTransX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTransX.Location = new System.Drawing.Point(612, 151);
            this.lblTransX.Name = "lblTransX";
            this.lblTransX.Size = new System.Drawing.Size(32, 24);
            this.lblTransX.TabIndex = 53;
            // 
            // tTransX
            // 
            this.tTransX.AutoSize = false;
            this.tTransX.LargeChange = 1;
            this.tTransX.Location = new System.Drawing.Point(508, 151);
            this.tTransX.Maximum = 150;
            this.tTransX.Minimum = -150;
            this.tTransX.Name = "tTransX";
            this.tTransX.Size = new System.Drawing.Size(104, 24);
            this.tTransX.TabIndex = 52;
            this.tTransX.TickFrequency = 20;
            this.tTransX.ValueChanged += new System.EventHandler(this.tTransX_ValueChanged);
            // 
            // cbRotate
            // 
            this.cbRotate.Location = new System.Drawing.Point(436, 7);
            this.cbRotate.Name = "cbRotate";
            this.cbRotate.Size = new System.Drawing.Size(80, 16);
            this.cbRotate.TabIndex = 51;
            this.cbRotate.Text = "旋转";
            this.cbRotate.CheckedChanged += new System.EventHandler(this.cbRotate_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(460, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 24);
            this.label2.TabIndex = 50;
            this.label2.Text = "角度";
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(628, 407);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(16, 24);
            this.buttonUp.TabIndex = 49;
            this.buttonUp.Text = "+";
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(628, 447);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(16, 24);
            this.buttonDown.TabIndex = 48;
            this.buttonDown.Text = "-";
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(444, 407);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(176, 69);
            this.listBox1.TabIndex = 47;
            // 
            // lblRotDeg
            // 
            this.lblRotDeg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRotDeg.Location = new System.Drawing.Point(612, 31);
            this.lblRotDeg.Name = "lblRotDeg";
            this.lblRotDeg.Size = new System.Drawing.Size(32, 24);
            this.lblRotDeg.TabIndex = 46;
            // 
            // tRotDeg
            // 
            this.tRotDeg.AutoSize = false;
            this.tRotDeg.LargeChange = 1;
            this.tRotDeg.Location = new System.Drawing.Point(508, 31);
            this.tRotDeg.Maximum = 90;
            this.tRotDeg.Minimum = -90;
            this.tRotDeg.Name = "tRotDeg";
            this.tRotDeg.Size = new System.Drawing.Size(104, 24);
            this.tRotDeg.TabIndex = 45;
            this.tRotDeg.TickFrequency = 30;
            this.tRotDeg.ValueChanged += new System.EventHandler(this.tRotDeg_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(356, 423);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 24);
            this.button1.TabIndex = 44;
            this.button1.Text = "运行";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(20, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 408);
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 494);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblShearY);
            this.Controls.Add(this.tShearY);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblShearX);
            this.Controls.Add(this.tShearX);
            this.Controls.Add(this.cbShear);
            this.Controls.Add(this.cbRealtime);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.cbFlipY);
            this.Controls.Add(this.pictureBoxBase);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblStrY);
            this.Controls.Add(this.tStrY);
            this.Controls.Add(this.cbStretch);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblStrX);
            this.Controls.Add(this.tStrX);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblRotY);
            this.Controls.Add(this.tRotY);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblRotX);
            this.Controls.Add(this.tRotX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTransY);
            this.Controls.Add(this.tTransY);
            this.Controls.Add(this.cbTranslation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTransX);
            this.Controls.Add(this.tTransX);
            this.Controls.Add(this.cbRotate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblRotDeg);
            this.Controls.Add(this.tRotDeg);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tShearY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tShearX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStrY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStrX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRotY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRotX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTransY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTransX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRotDeg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblShearY;
        private System.Windows.Forms.TrackBar tShearY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblShearX;
        private System.Windows.Forms.TrackBar tShearX;
        private System.Windows.Forms.CheckBox cbShear;
        private System.Windows.Forms.CheckBox cbRealtime;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox cbFlipY;
        private System.Windows.Forms.PictureBox pictureBoxBase;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblStrY;
        private System.Windows.Forms.TrackBar tStrY;
        private System.Windows.Forms.CheckBox cbStretch;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblStrX;
        private System.Windows.Forms.TrackBar tStrX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblRotY;
        private System.Windows.Forms.TrackBar tRotY;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblRotX;
        private System.Windows.Forms.TrackBar tRotX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTransY;
        private System.Windows.Forms.TrackBar tTransY;
        private System.Windows.Forms.CheckBox cbTranslation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTransX;
        private System.Windows.Forms.TrackBar tTransX;
        private System.Windows.Forms.CheckBox cbRotate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblRotDeg;
        private System.Windows.Forms.TrackBar tRotDeg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

