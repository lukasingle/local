using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Example3_1_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.AutoScaleDimensions = new Size(5, 13);
            this.ClientSize = new Size(392, 373);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; 
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //Convert origin from(0,0) to (50,40)
            //This time the point(50,40) be became as origin point in page coordinates   
            g.TranslateTransform(50, 40);

            Font vertFont = new Font("Verdana", 10, FontStyle.Regular);
            Font horzFont = new Font("Verdana", 10, FontStyle.Regular);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            Pen blackPen = new Pen(Color.Black, 1);
            Pen bluePen = new Pen(Color.Blue, 1);

            //Page Coordinate
            //X axis drawing

            g.DrawString("200", horzFont, blackBrush, 200, 5);
            g.DrawString("100", horzFont, blackBrush, 100, 5);
            g.DrawString("X", horzFont, blackBrush, 250, 0);

            //Drawing vertical string
            StringFormat vertStrFormat= new StringFormat();
            vertStrFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            //Y axis drawing
            g.DrawString("100", vertFont, blackBrush, 0, 100);
            g.DrawString("200", vertFont, blackBrush, 0, 200);
            g.DrawString("Y", vertFont, blackBrush, 0, 250);
            //Draw a vertical and a horizontal line
            g.DrawLine(blackPen, 0, 0, 0, 250);
            g.DrawLine(blackPen, 0, 0, 250, 0);

            Point A = new Point(0, 0);
            Point B = new Point(120, 80);
            g.DrawLine(bluePen, A, B);
        }
    }

}