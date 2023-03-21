using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Example2_1_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            using (Pen bluePen = new Pen(Color.Blue, 1))
            {
                if (ClientRectangle.Height / 10 > 0)
                {
                    for (int y = 0; y < ClientRectangle.Height;
                       y += ClientRectangle.Height / 10)
                    {
                        g.DrawLine(bluePen, new Point(0, 0),
                           new Point(ClientRectangle.Width, y));
                    }
                }
            }
        }
    }
}