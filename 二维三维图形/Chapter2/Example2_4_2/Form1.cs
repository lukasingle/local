using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Example2_4_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics displayGraphics = e.Graphics;
            Random r = new Random();
            //define an image that the size is same as client's area size  
            Image i = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            //Get a graphics object from image
            Graphics g = Graphics.FromImage(i);

            g.FillRectangle(Brushes.White, ClientRectangle);
            for (int x = 0; x < ClientRectangle.Width; x++)
            {
                for (int y = 0; y < ClientRectangle.Height; y += 10)
                {
                    Color c = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
                    Pen p = new Pen(c, 1);
                    g.DrawLine(p, new Point(0, 0), new Point(x, y));
                    p.Dispose();
                }
            }
          
            //Draw chart on the screen 
            displayGraphics.DrawImage(i, ClientRectangle);
            i.Dispose();

        }
    }
}