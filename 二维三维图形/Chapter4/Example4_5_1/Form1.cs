using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Example4_5_1
{
    public partial class Form1 : Form
    {
        #region Constructor

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Gray;
        }
        #endregion

        #region Methods

        private void ApplyTransformation(Graphics g)
        {
            // Text Transformation
            // Create a new transform matrix
            Matrix m = new Matrix();
            // Bring origin to the center
            m.Translate(panel1.Width / 2, panel1.Height / 2);

            //Translation
            int dx = Convert.ToInt16(txttransx.Text);
            int dy = -Convert.ToInt16(txttransy.Text);
            m.Translate(dx, dy, MatrixOrder.Append);

            //Rotation
            float angle = Convert.ToSingle(txtrotate.Text);
            m.RotateAt(angle, new PointF(panel1.Width / 2, panel1.Height / 2),
                          MatrixOrder.Append);

            //Scaling
            float sx = Convert.ToSingle(txtscalex.Text);
            float sy = Convert.ToSingle(txtscaley.Text);
            m.Scale(sx, sy);

            //Shearing
            float shearx = Convert.ToSingle(txtshearx.Text);
            float sheary = Convert.ToSingle(txtsheary.Text);
            m.Shear(shearx, sheary);

            //Apply transformation matrix m to graphics object
            g.Transform = m;
            DrawText(g, Color.Red);

        }

        private void DrawAxes(Graphics g)
        {
            Matrix m = new Matrix();
            //Move the origin point to center of panel1
            m.Translate(panel1.Width / 2, panel1.Height / 2);
            //Apply the transformation
            g.Transform = m;

            //Draw x and y axes
            g.DrawLine(Pens.Black, -panel1.Width / 2, 0, panel1.Width / 2, 0);
            g.DrawLine(Pens.Black, 0, -panel1.Height / 2, 0, panel1.Height / 2);
            g.DrawString("X", this.Font, Brushes.Black, panel1.Width / 2 - 20, -20);
            g.DrawString("Y", this.Font, Brushes.Black, 5, -panel1.Height / 2 + 5);

            //Draw Ticks
            int tick = 40;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Far;
            for (int i = -160; i <= 160; i += tick)
            {
                g.DrawLine(Pens.Black, i, -3, i, 3);
                g.DrawLine(Pens.Black, -3, i, 3, i);

                SizeF sizeXTick = g.MeasureString(i.ToString(), this.Font);
                if (i != 0)
                {
                    g.DrawString(i.ToString(), this.Font, Brushes.Black, i + sizeXTick.Width / 2, 4f,
                       sf);
                    g.DrawString((-i).ToString(), this.Font, Brushes.Black, -3f, i - sizeXTick.Height / 2,
                       sf);
                }
                else
                {
                    g.DrawString("0", this.Font, Brushes.Black, new PointF(i - sizeXTick.Width / 3, 4f),
                       sf);
                }
            }
        }

        private void DrawText(Graphics g, Color color)
        {
            string str = txtstring.Text;
            Font aFont = new Font("Arial", 12, FontStyle.Bold);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            SolidBrush aBrush = new SolidBrush(color);
            g.DrawString(str, aFont, aBrush, new PointF(0, 0), sf);
            aFont.Dispose();
            aBrush.Dispose();
        }

        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            this.DrawAxes(g);
            this.ApplyTransformation(g);
        }

        private void btnresult_Click(object sender, EventArgs e)
        {
            this.panel1.Invalidate();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtstring.Text = "Hello World";
            txttransx.Text = "0";
            txttransy.Text = "150";
            txtrotate.Text = "45";

            txtscalex.Text = "2";
            txtscaley.Text = "2";
            txtshearx.Text = "1";
            txtsheary.Text = "0";

            panel1.Invalidate();
        }
    }
}