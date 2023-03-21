using System;
using System.Drawing;
using System.Windows.Forms;

namespace Example7_2_4
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
            float a = panel1.Height / 4;
            DrawHouse dh = new DrawHouse(this, a);
            float d = Convert.ToSingle(tbDistance.Text);
            dh.DrawPerspectiveView(g, d * a);           
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