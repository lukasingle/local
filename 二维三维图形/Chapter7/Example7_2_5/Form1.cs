using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Example7_2_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.White;

            // Subscribing to a paint eventhandler to drawingPanel: 
            panel1.Paint +=
                new PaintEventHandler(panel1Paint);
        }

        private void panel1Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float a = panel1.Height / 6;
            float elevation = Convert.ToSingle(tbElevation.Text);
            float azimuth = Convert.ToSingle(tbAzimuth.Text);
            float oneOverd = Convert.ToSingle(tbOneOverd.Text);
            DrawCube ds = new DrawCube(this, a, elevation, azimuth, oneOverd / (2 * a));
            ds.AddCube(g);
            
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }
    }
}