using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Example7_2_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            // Subscribing to a paint eventhandler to drawingPanel: 
            panel1.Paint +=
                new PaintEventHandler(panel1Paint);
        }

        private void panel1Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float a = panel1.Height / 3;
            DrawSphere ds = new DrawSphere(this, a, 0, 0, -a / 2);
            ds.DrawIsometricView(g);
            ds = new DrawSphere(this, 2 * a / 3, -a/2, -a/2, a / 2);
            ds.DrawIsometricView(g);
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }
    }
}