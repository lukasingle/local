using System;
using System.Drawing;
using System.Windows.Forms;

namespace Example7_2_2
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
             float a = panel1.Width / 3;
            DrawHouse dh = new DrawHouse(this, a);

            if (rbFront.Checked)
                dh.DrawFrontView(g);
            else if (rbSide.Checked)
                dh.DrawSideView(g);
            else if (rbTop.Checked)
                dh.DrawTopView(g);
            else if (rbIsometric.Checked)
                dh.DrawIsometricView(g);
            else if (rbDimetric.Checked)
                dh.DrawDimetricView(g);
            else if (rbTrimetric.Checked)
                dh.DrawTrimetricView(g);
            else if (rbAxonometric.Checked)
            {
                float alpha = Convert.ToSingle(tbAlpha.Text);
                if (alpha < 0)
                    alpha = -alpha;
                float beta = Convert.ToSingle(tbBeta.Text);
                if (beta > 0)
                    beta = -beta;
                dh.DrawAxonometricView(g, alpha, beta);
            }
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