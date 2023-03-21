using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Example2_2_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e) 
    {
      Graphics G  = e.Graphics;

      Pen P1 = new Pen(Color.Blue, 10);

      G.DrawLine(P1, 20, 20, 330, 20);

      Pen P2 = new Pen(Color.Blue, 10);
      float[] Pts = { 3, 1, 2, 5 };
      P2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
      P2.DashPattern = Pts;
      P2.DashCap = System.Drawing.Drawing2D.DashCap.Triangle;
      P2.StartCap = System.Drawing.Drawing2D.LineCap.Round;
      P2.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

      G.DrawLine(P2, 20, 50, 330, 50);

      ////pentype
      //G.Clear(Color.Khaki);
      Pen P3 = new Pen(Color.Blue, 10);
      Single[] lines = { 0.0f, 0.1f, 0.9f, 1.0f };
      P3 = new Pen(Color.Blue, 20);
      P3.CompoundArray = lines;
      G.DrawLine(P3, 20, 80, 330, 80);

      ////pens class
      P3.Dispose();
      ////G.Clear(Color.Khaki);
      P3 = new Pen(Color.Blue, 10);
      P3.DashStyle = DashStyle.Dot;
      G.DrawLine(P3, 20, 110, 330, 110);

      P3.Dispose();
      P3 = new Pen(Color.Blue, 10);
      P3.DashStyle = DashStyle.DashDotDot;
      P3.StartCap = LineCap.ArrowAnchor;
      P3.EndCap = LineCap.ArrowAnchor;
      G.DrawLine(P3, 20, 140, 330, 140);

      P3.Dispose();
      P3 = new Pen(Color.Blue, 10);
      P3.DashStyle = DashStyle.Solid;
      P3.EndCap = LineCap.ArrowAnchor;
      G.DrawLine(P3, 20, 170, 330, 170);

            //Draw Curver
      P3.Dispose();
      P3 = new Pen(Color.Blue, 3);
      Point[] point = new Point[]
            {
                new Point(10,220),
                new Point(200,200),
                new Point(330,230),
                new Point(110,250),
            };
      G.DrawCurve(P3, point);



      if (P1 != null)
          P1.Dispose();
      if (P2 != null)
          P2.Dispose();
      if (P3 != null)
          P3.Dispose();
    }

    }
    
}