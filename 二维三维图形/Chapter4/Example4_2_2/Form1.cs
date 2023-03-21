using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Example4_2_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.Width = 300;
            this.Height = 500;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int offset = 20;

            //Scale
            Matrix m = new Matrix(1, 2, 3, 4, 0, 1);
            g.DrawString("Original Matrix:", this.Font, Brushes.Blue, 10, 10);
            DrawMatrix(m, g, 10, 10 + offset);
            g.DrawString("Scale - Prepend:", this.Font, Brushes.Blue, 10, 10 + 2 * offset);
            m.Scale(1, 0.5f, MatrixOrder.Prepend);
            DrawMatrix(m, g, 10, 10 + 3*offset);
            g.DrawString("Scale - Append:", this.Font, Brushes.Blue, 10, 10 + 4 * offset);
            //Reset m to original matrix
            m = new Matrix(1, 2, 3, 4, 0, 1);
            m.Scale(1, 0.5f, MatrixOrder.Append);
            DrawMatrix(m, g, 10, 10 + 5 * offset);

            //Translation
            m = new Matrix(1, 2, 3, 4, 0, 1);
            g.DrawString("Translation - Prepend:", this.Font, Brushes.Blue, 10, 10 + 6 * offset);
            m.Translate(1, 0.5f, MatrixOrder.Prepend);
            DrawMatrix(m, g, 10, 10 + 7 * offset);
            g.DrawString("Translation - Append:", this.Font, Brushes.Blue, 10, 10 + 8 * offset);
            //Reset m to original matrix
            m = new Matrix(1, 2, 3, 4, 0, 1);
            m.Translate(1, 0.5f, MatrixOrder.Append);
            DrawMatrix(m, g, 10, 10 + 9 * offset);

            //Rotation
            m = new Matrix(1, 2, 3, 4, 0, 1);
            g.DrawString("Rotation - Prepend:", this.Font, Brushes.Blue, 10, 10 + 10 * offset);
            m.Rotate(45, MatrixOrder.Prepend);
            DrawMatrix(m, g, 10, 10 + 11 * offset);
            g.DrawString("Rotation - Append:", this.Font, Brushes.Blue, 10, 10 + 12 * offset);
            //Reset m to original matrix
            m = new Matrix(1, 2, 3, 4, 0, 1);
            m.Rotate(45, MatrixOrder.Append);
            DrawMatrix(m, g, 10, 10 + 13 * offset);

            //Rotation at (x=1,y=2)
            m = new Matrix(1, 2, 3, 4, 0, 1);
            g.DrawString("Rotation at - Prepend:", this.Font, Brushes.Blue, 10, 10 + 14 * offset);
            m.RotateAt(45, new PointF(1, 2), MatrixOrder.Prepend);
            DrawMatrix(m, g, 10, 10 + 15 * offset);
            g.DrawString("Rotation at - Append:", this.Font, Brushes.Blue, 10, 10 + 16 * offset);
            //Reset m to original matrix
            m = new Matrix(1, 2, 3, 4, 0, 1);
            m.RotateAt(45, new PointF(1, 2), MatrixOrder.Append);
            DrawMatrix(m, g, 10, 10 + 17 * offset);

            //Shear
            m = new Matrix(1, 2, 3, 4, 0, 1);
            g.DrawString("Shear - Prepend:", this.Font, Brushes.Blue, 10, 10 + 18 * offset);
            m.Shear(1, 2, MatrixOrder.Prepend);
            DrawMatrix(m, g, 10, 10 + 19 * offset);
            g.DrawString("Shear - Append:", this.Font, Brushes.Blue, 10, 10 + 20 * offset);
            //Reset m to original matrix
            m = new Matrix(1, 2, 3, 4, 0, 1);
            m.Shear(1, 2, MatrixOrder.Append);
            DrawMatrix(m, g, 10, 10 + 21 * offset);

            
        }
        private void DrawMatrix(Matrix m,Graphics g,int x,int y)
        {
            string str = null;
            for (int i = 0; i < m.Elements.Length; i++)
            {
                double dd = Math.Round(m.Elements[i], 3);
                str += dd.ToString();
                str += ", ";
            }
            g.DrawString(str, this.Font, Brushes.Blue, x, y);
        }
    }
}