using System;
using System.Drawing;
using System.Windows.Forms;

namespace Example7_2_7
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
            float a = panel1.Height / 4;
            DrawCylinder dc = new DrawCylinder(this, a, 2 * a);
            dc.DrawIsometricView(g);
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }
    }
}