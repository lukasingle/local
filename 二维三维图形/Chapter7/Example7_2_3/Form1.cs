using System;
using System.Drawing;
using System.Windows.Forms;

namespace Example7_2_3
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
            float theta = Convert.ToSingle(tbTheta.Text);

            if (rbCavalier.Checked)
            {
                dh.DrawCavalierView(g, theta);
            }
            else if (rbCabinet.Checked)
            {
                dh.DrawCabinetView(g, theta);
            }
            else if (rbOblique.Checked)
            {
                float alpha = Convert.ToSingle(tbAlpha.Text);
                dh.DrawObliqueView(g, alpha, theta);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void rbCavalier_CheckedChanged(object sender, EventArgs e)
        {
            tbAlpha.Enabled = false;
        }

        private void rbCabinet_CheckedChanged(object sender, EventArgs e)
        {
            tbAlpha.Enabled = false;
        }

        private void rbOblique_CheckedChanged(object sender, EventArgs e)
        {
            tbAlpha.Enabled = true;
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }
    }
}