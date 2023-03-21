using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Example2_3_1
{
    public partial class Form1 : Form
    {
        private ColorDialog cdl = new ColorDialog();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] colorNames=Enum.GetNames(typeof(KnownColor));
            listBox1.Items.AddRange(colorNames);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            KnownColor selectedColor = (KnownColor)Enum.Parse(typeof(KnownColor), listBox1.Text);
            panel1.BackColor = Color.FromKnownColor(selectedColor);
            ColorInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cdl.ShowDialog();
            panel1.BackColor = cdl.Color;
            ColorInfo();
        }
        private void ColorInfo()
        {
            //Show color information
            //Brightness,Hue,Saturation info and ARGB value

            lblBrightness.Text = "Brightness = " + panel1.BackColor.GetBrightness().ToString();
            lblHue.Text = "Hue = " + panel1.BackColor.GetHue().ToString();
            lblSaturation.Text = "Saturation = " + panel1.BackColor.GetSaturation().ToString();

            string strHexRGB = string.Format("0x{0:x8}", panel1.BackColor.ToArgb());
            strHexRGB = "RGB = #" + strHexRGB.Substring(strHexRGB.Length - 6, 6);
            lblRGB.Text = strHexRGB;

            string strArgb = "ARGB = [" +
                panel1.BackColor.A.ToString() + "," +
                panel1.BackColor.R.ToString() + "," +
                panel1.BackColor.G.ToString() + "," +
                panel1.BackColor.B.ToString() + "]";
            lblRGBValue.Text = strArgb;
        }
    }
}