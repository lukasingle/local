using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Example4_4_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.White;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawAxes(g);
            ApplyTransformation(g);
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
            for (int i = -160; i <= 160; i+=tick)
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

        private void DrawHouse(Graphics g, HatchBrush hb, Pen aPen)
        {
            Point[] pta = new Point[5];
            pta[0] = new Point(-40, 40);
            pta[1] = new Point(40, 40);
            pta[2] = new Point(40, -40);
            pta[3] = new Point(0, -80);
            pta[4] = new Point(-40, -40);
            g.FillPolygon(hb, pta);
            g.DrawPolygon(aPen, pta);
        }

        private void ApplyTransformation(Graphics g)
        {
            //Define a pen and a HatchBrush objects used to draw house object
            Pen aPen;
            HatchBrush hb;

            //Transformation on a red horizontal-brick house
            if (cbRBrickHouse.Checked)
            {
                //Create a new transform matrix
                Matrix m = new Matrix();
                //Bring origin to the center
                m.Translate(panel1.Width / 2, panel1.Height / 2);

                //Translation
                int dx = Convert.ToInt16(tbRTransX.Text);
                int dy = Convert.ToInt16(tbRTransY.Text);
                m.Translate(dx, dy, MatrixOrder.Append);

                //Rotation
                float angle = Convert.ToSingle(tbRRotate.Text);
                m.RotateAt(angle, new PointF(panel1.Width / 2, panel1.Height / 2),
                          MatrixOrder.Append);
                g.Transform = m;

                //Define red pen and horizontal brick brush
                hb = new HatchBrush(HatchStyle.Horizontal, Color.Red, Color.White);
                aPen = new Pen(Color.Red, 2);

                //Draw house object by calling DrawHouse method
                DrawHouse(g,hb,aPen);
            }
            //Transformation on a blue diagonal-brick house
            if (cbBBrickHouse.Checked)
            {
                //Create a new transform matrix
                Matrix m1 = new Matrix();
                //Bring origin point to panel's center
                m1.Translate(panel1.Width / 2, panel1.Height / 2);

                //Rotation
                float angle = Convert.ToSingle(tbBRotate.Text);
                m1.RotateAt(angle, new PointF(panel1.Width / 2, panel1.Height / 2),
                           MatrixOrder.Append);

                //Translation
                int dx = Convert.ToInt16(tbBTransX.Text);
                int dy = Convert.ToInt16(tbBTransY.Text);
                m1.Translate(dx, dy, MatrixOrder.Append);
                g.Transform = m1;

                //Define blue pen and diagonal brick brush
                hb = new HatchBrush(HatchStyle.DiagonalBrick, Color.Blue, Color.White);
                aPen = new Pen(Color.Blue, 2);
                //Draw house
                DrawHouse(g, hb, aPen);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbRBrickHouse.Checked = true;
            tbRTransX.Text = "100";
            tbRTransY.Text = "0";
            tbRRotate.Text = "90";

            cbBBrickHouse.Checked = true;
            tbBTransX.Text = "100";
            tbBTransY.Text = "0";
            tbBRotate.Text = "90";

            panel1.Invalidate();

        }


    }
}