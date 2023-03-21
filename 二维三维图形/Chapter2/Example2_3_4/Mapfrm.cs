using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Example2_3_4
{
    public partial class Mapfrm : Form
    {

 
        public Graphics g;
        public Pen pen1 = new Pen(Color.Black, 1);
        private PointC[,] pts ;

        private int value;
        private double  dbvalue;

        private System.Random tt;
        private bool isline;
        private bool isbiline;

        public Mapfrm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            Create(pcbDraw, pen1, 10, 10);           
        }

        private void Mapfrm_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            pts= new PointC[31, 31];                                         
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            g = pcbDraw.CreateGraphics();
            g.Clear(pcbDraw.BackColor);
            Create(pcbDraw, pen1, 10, 10);
            DrawObjects(g);
            isline = true;
            isbiline = false;
        }

        //define function
        private void Create(PictureBox p, Pen pen, int xincm, int yincm)
        {
            Graphics g1 = p.CreateGraphics();
            for (int i = 0; i <= 301; i += xincm)
            {
                g1.DrawLine(pen, i, 0, i, 301);
            }
            for (int j = 0; j <= 301; j += yincm)
            {
                g1.DrawLine(pen, 0, j, 301, j);
            }

        }
        private void DrawObjects(Graphics g )
        {
            
            ColorMap cm1 = new ColorMap(64, 150);
            
            int[,] cmap = cm1.Jet();

            int width = 10;
            int height = 10;

            if ((isline == false) && (isbiline == false))
            {
                ////use SA get data (x,y,frequency) to define color value,for first point give it a random color value  

                dbvalue = 0.5;
                for (int y = 0; y < 31; y++)
                {
                    for (int x = 0; x < 31; x++)
                    {
                        value = getRndnum(0, 100);
                        System.Threading.Thread.Sleep(4);

                        dbvalue = getRndnumdouble(value);
                        float num = (float)(100f * dbvalue);
                        pts[x, y] = new PointC(new PointF(x * width, y * height), value);


                    }
                }
            }

            float cmin = 0;// -3;
            float cmax = 100;// 4;
            int colorLength = cmap.GetLength(0);

            //// Original color map:
            //// 31 by 31 matrix,so i=31,j=31 
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    int cindex = (int)Math.Round((colorLength * (pts[i, j].C - cmin) +
                        (cmax - pts[i, j].C)) / (cmax - cmin));
                    if (cindex < 1)
                        cindex = 1;
                    if (cindex > colorLength)
                        cindex = colorLength;
                    for (int k = 0; k < 4; k++)//k is length of ARGBArray,ARGBArray always is 4
                    {
                        pts[i, j].ARGBArray[k] = cmap[cindex - 1, k];
                    }
                }
            }


            for (int i = 0; i <30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    SolidBrush aBrush = new SolidBrush(Color.FromArgb(pts[i, j].ARGBArray[0],
                        pts[i, j].ARGBArray[1], pts[i, j].ARGBArray[2], pts[i, j].ARGBArray[3]));
                    PointF[] pta = new PointF[4]{pts[i,j].pointf, pts[i+1,j].pointf,
                        pts[i+1,j+1].pointf, pts[i,j+1].pointf};
                    g.FillPolygon(aBrush, pta);
                    aBrush.Dispose();
                }
            }
            // g.DrawString("Direct Color Map", this.Font, Brushes.Black, 50, 190);
        }

        private int getRndnum(int Low,int High)
        {
            System.Random random;
            tt = new Random();
            listBox1.Update();
            listBox1.Items.Add(tt.NextDouble());
            listBox1.Invalidate();

            random =new Random(tt.Next(Low,High));
              
            return random.Next(Low, High); 
            
            
        }
        private double getRndnumdouble(int lhvalue)
        {
            System.Random dbrandom = new Random(lhvalue); 

            return dbrandom.NextDouble(); 

        }
//////////////////Create Biline color mapping//////////////////////
        private void btnline_Click(object sender, EventArgs e)
        {
            g = pcbDraw.CreateGraphics();
            g.Clear(pcbDraw.BackColor);
            Create(pcbDraw, pen1, 10, 10);
            DrawBiObjects(g);
            isbiline = true;
            isline = false;

        }

        private void DrawBiObjects(Graphics g)
        {

           
            ColorMap cm1 = new ColorMap(64, 150);
           
            int[,] cmap = cm1.Jet();
            
            int width = 10;// 85;
            int height = 10;// 85;
           

            //PointC[,] pts = new PointC[31, 31];//define 31 by 31 matrix,to noiseken use scanarea to define x & y: PointC[,] pts = new PointC[x, y]

            ////use SA get data (x,y,frequency) to define color value,for first point give it a random color value  


            if ((isline == false) && (isbiline == false))
            {

                for (int y = 0; y < 31; y++)
                {
                    for (int x = 0; x < 31; x++)
                    {
                        value = getRndnum(0, 100);
                        System.Threading.Thread.Sleep(1);

                        dbvalue = getRndnumdouble(value);
                        float num = (float)(100f * dbvalue);
                        pts[x, y] = new PointC(new PointF(x * width, y * height), value);

                    }
                }
            }


            float cmin = 0;// -3;
            float cmax = 100;// 4;
            int colorLength = cmap.GetLength(0);

            // Biline color map:
            // 31 by 31 matrix,so i=31,j=31 
            for (int i = 0; i < 31; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    int cindex = (int)Math.Round((colorLength * (pts[i, j].C - cmin) +
                        (cmax - pts[i, j].C)) / (cmax - cmin));
                    if (cindex < 1)
                        cindex = 1;
                    if (cindex > colorLength)
                        cindex = colorLength;
                    for (int k = 0; k < 4; k++)//k is length of ARGBArray,ARGBArray always is 4
                    {
                        pts[i, j].ARGBArray[k] = cmap[cindex - 1, k];
                    }
                }
            }


            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    PointF[] pta = new PointF[4]{pts[i,j].pointf, pts[i+1,j].pointf,
                        pts[i+1,j+1].pointf, pts[i,j+1].pointf};
                    float[] cdata = new float[4]{pts[i,j].C,pts[i+1,j].C,
                        pts[i+1,j+1].C,pts[i,j+1].C};
                    Interp(g, pta, cdata, 50);
                }
            }
        }


        private void Interp(Graphics g, PointF[] pta, float[] cData, int npoints)
        {
            PointC[,] pts = new PointC[npoints + 1, npoints + 1];
            float x0 = pta[0].X;
            float x1 = pta[1].X;
            float y0 = pta[0].Y;
            float y1 = pta[2].Y;
            float dx = (x1 - x0) / npoints;
            float dy = (y1 - y0) / npoints;
            float C00 = cData[0];
            float C10 = cData[1];
            float C11 = cData[2];
            float C01 = cData[3];

            for (int i = 0; i <= npoints; i++)
            {
                float x = x0 + i * dx;
                for (int j = 0; j <= npoints; j++)
                {
                    float y = y0 + j * dy;
                    float C = (y1 - y) * ((x1 - x) * C00 +
                                     (x - x0) * C10) / (x1 - x0) / (y1 - y0) +
                                     (y - y0) * ((x1 - x) * C01 +
                                     (x - x0) * C11) / (x1 - x0) / (y1 - y0);
                    pts[j, i] = new PointC(new PointF(x, y), C);
                }
            }

            ColorMap cm = new ColorMap();
            //ColorMap cm1 = new ColorMap(64, 150);
            int[,] cmap = cm.Jet();
            float cmin = 0;// -3;
            float cmax = 100;// 4;
            int colorLength = cmap.GetLength(0);
            for (int i = 0; i <= npoints; i++)
            {
                for (int j = 0; j <= npoints; j++)
                {
                    int cindex = (int)Math.Round((colorLength * (pts[i, j].C - cmin) +
                        (cmax - pts[i, j].C)) / (cmax - cmin));
                    if (cindex < 1)
                        cindex = 1;
                    if (cindex > colorLength)
                        cindex = colorLength;
                    for (int k = 0; k < 4; k++)
                    {
                        pts[j, i].ARGBArray[k] = cmap[cindex - 1, k];
                    }
                }
            }

            for (int i = 0; i < npoints; i++)
            {
                for (int j = 0; j < npoints; j++)
                {
                    SolidBrush aBrush = new SolidBrush(Color.FromArgb(pts[i, j].ARGBArray[0],
                        pts[i, j].ARGBArray[1], pts[i, j].ARGBArray[2], pts[i, j].ARGBArray[3]));
                    PointF[] points = new PointF[4]{pts[i,j].pointf, pts[i+1,j].pointf,
                        pts[i+1,j+1].pointf, pts[i,j+1].pointf};
                    g.FillPolygon(aBrush, points);
                    aBrush.Dispose();
                }
            }
        }

    }
}