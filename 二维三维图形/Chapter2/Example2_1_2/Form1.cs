using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Example2_1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush brSolid = new SolidBrush(Color.Blue);
            Brush brHatch = new HatchBrush(HatchStyle.HorizontalBrick,
              Color.Red, Color.Yellow);
            Brush brGradient = new LinearGradientBrush(new Rectangle(0, 0, 200, 200), Color.Black, Color.LightGray, 45, false);
            g.FillRectangle(brGradient, 10, 10, 200, 200);
            g.FillEllipse(brHatch, 200, 200, 150, 190);
            g.FillPie(brSolid, 0, 0, 300, 300, 285, 75);
        }
    }
}