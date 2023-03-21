using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Example2_2_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // references to object we will use
            Graphics graphicsObject = e.Graphics;

            // ellipse rectangle and gradient brush
            Rectangle drawArea1 = new Rectangle(5, 35, 30, 100);
            LinearGradientBrush linearBrush =
                new LinearGradientBrush(drawArea1, Color.Blue,
                   Color.Yellow, LinearGradientMode.ForwardDiagonal);

            // draw ellipse filled with a blue-yellow gradient
            graphicsObject.FillEllipse(linearBrush, 5, 30, 65, 100);

            // pen and location for red outline rectangle
            Pen thickRedPen = new Pen(Color.Red, 10);
            Rectangle drawArea2 = new Rectangle(80, 30, 65, 100);

            // draw thick rectangle outline in red
            graphicsObject.DrawRectangle(thickRedPen, drawArea2);

            // bitmap texture
            Bitmap textureBitmap = new Bitmap(10, 10);

            // get bitmap graphics
            Graphics graphicsObject2 =
               Graphics.FromImage(textureBitmap);

            // brush and pen used throughout program
            SolidBrush solidColorBrush =
               new SolidBrush(Color.Red);
            Pen coloredPen = new Pen(solidColorBrush);

            // fill textureBitmap with yellow
            solidColorBrush.Color = Color.Yellow;
            graphicsObject2.FillRectangle(solidColorBrush, 0, 0, 10, 10);

            // draw small black rectangle in textureBitmap
            coloredPen.Color = Color.Black;
            graphicsObject2.DrawRectangle(coloredPen, 1, 1, 6, 6);

            // draw small blue rectangle in textureBitmap
            solidColorBrush.Color = Color.Blue;
            graphicsObject2.FillRectangle(solidColorBrush, 1, 1, 3, 3);

            // draw small red square in textureBitmap
            solidColorBrush.Color = Color.Red;
            graphicsObject2.FillRectangle(solidColorBrush, 4, 4, 3, 3);

            // create textured brush and
            // display textured rectangle
            TextureBrush texturedBrush =
               new TextureBrush(textureBitmap);
            graphicsObject.FillRectangle(texturedBrush, 155, 30, 75, 100);

            // draw pie-shaped arc in white
            coloredPen.Color = Color.White;
            coloredPen.Width = 6;
            graphicsObject.DrawPie(coloredPen, 240, 30, 75, 100, 0, 270);

            // draw lines in green and yellow
            coloredPen.Color = Color.Green;
            coloredPen.Width = 5;
            graphicsObject.DrawLine(coloredPen, 395, 30, 320, 150);

            // draw a rounded, dashed yellow line
            coloredPen.Color = Color.Yellow;
            coloredPen.DashCap = DashCap.Round;
            coloredPen.DashStyle = DashStyle.Dash;
            graphicsObject.DrawLine(coloredPen, 320, 30, 395, 150);

            //Draw an Arc
            coloredPen.Color = Color.Pink;
            coloredPen.Width = 2;
            graphicsObject.DrawArc(coloredPen, 330, 30, 200, 100, -60, 180);
        }
    }
}