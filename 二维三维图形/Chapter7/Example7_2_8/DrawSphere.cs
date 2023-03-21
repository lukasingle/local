using System;
using System.Drawing;
using System.Windows.Forms;

namespace Example7_2_8
{
    public class DrawSphere
    {
        #region Variables

        private Form1 form1;
        private float r = 10;
        private float xc = 0;
        private float yc = 0;
        private float zc = 0;
        private int[,] cmap;
        private bool isLineVisable = false;
        private bool isMesh = true;
        private bool isSurface = true;
        #endregion

        #region Constructors

        public DrawSphere(Form1 fm1)
        {
            form1 = fm1;
        }

        public DrawSphere(Form1 fm1, float r1, float xc1, float yc1, float zc1)
        {
            form1 = fm1;
            r = r1;
            xc = xc1;
            yc = yc1;
            zc = zc1;
        }

        #endregion

        #region Properties

        public int[,] CMap
        {
            get { return cmap; }
            set { cmap = value; }
        }
        public bool IsLineVisable
        {
            get { return isLineVisable; }
            set { isLineVisable = value; }
        }
        public bool IsMesh
        {
            get { return isMesh; }
            set { isMesh = value; }
        }
        public bool IsSurface
        {
            get { return isSurface; }
            set { isSurface = value; }
        }

        #endregion

        #region Methods

       private Color AddColor(float value, float zmin, float zmax)
        {
            int colorLength = CMap.GetLength(0);
            int cindex = (int)Math.Round((colorLength * (value - zmin) +
                        (zmax - value)) / (zmax - zmin));
            if (cindex < 1)
                cindex = 1;
            if (cindex > colorLength)
                cindex = colorLength;
            Color color = Color.FromArgb(CMap[cindex - 1, 0],
                CMap[cindex - 1, 1], CMap[cindex - 1, 2],
                CMap[cindex - 1, 3]);
            return color;
        }

        public void AddColorBar(Graphics g, ChartStyle cs, float zmin, float zmax)
        {
            if (cs.IsColorBar)
            {
                Pen apen = new Pen(Color.Black, 1);
                SolidBrush aBrush = new SolidBrush(cs.TickColor);
                StringFormat sFormat = new StringFormat();
                sFormat.Alignment = StringAlignment.Near;
                SizeF size = g.MeasureString("A", cs.TickFont);

                int x, y, width, height;
                Point3[] pts = new Point3[64];
                PointF[] pta = new PointF[4];

                float dz = (zmax - zmin) / 63;

                x = 5 * form1.panel1.Width / 6;
                y = form1.panel1.Height / 15;
                width = form1.panel1.Width / 25;
                height = 8 * form1.panel1.Height / 15;

                //Add color bar
                for (int i = 0; i < 64; i++)
                {
                    pts[i] = new Point3(x, y, zmin + i * dz, 1);
                }
                for (int i = 0; i < 63; i++)
                {
                    Color color = AddColor(pts[i].Z, zmin, zmax);
                    aBrush = new SolidBrush(color);
                    float y1 = y + height - (pts[i].Z - zmin) * height / (zmax - zmin);
                    float y2 = y + height - (pts[i + 1].Z - zmin) * height / (zmax - zmin);
                    pta[0] = new PointF(x, y2);
                    pta[1] = new PointF(x + width, y2);
                    pta[2] = new PointF(x + width, y1);
                    pta[3] = new PointF(x, y1);
                    g.FillPolygon(aBrush, pta);
                }
                g.DrawRectangle(apen, x, y, width, height);

                //Add ticks and labels to the color bar
                float ticklength = 0.1f * width;
                float izmin = float.Parse(Math.Round(zmin, 2).ToString());//Get 2 after point from zmin 
                float izmax = float.Parse(Math.Round(zmax, 2).ToString());//Get 2 after point from zmax

                for (float z = izmin; z <= izmax; z = z + (izmax - izmin) / 6)
                {
                    float yy = y + height - (z - zmin) * height / (zmax - zmin);
                    g.DrawLine(apen, x, yy, x + ticklength, yy);
                    g.DrawLine(apen, x + width, yy, x + width - ticklength, yy);
                    g.DrawString((Math.Round(z, 2)).ToString(), cs.TickFont, Brushes.Black,
                        new PointF(x + width + 5, yy - size.Height / 2), sFormat);
                }
            }
        }
        public Point3[,] SphereCoordinates(string[] axarray, string[] ayarray,string[] azarray,float scale)
        {
            Point3[,] pts = new Point3[26, 51];
            Matrix3 m = new Matrix3();
            Matrix3 mt = Matrix3.Translate3(xc, yc, zc);

            //MessageBox.Show(scale.ToString());

            for (int i = 0; i < pts.GetLength(0); i++)
            {
                for (int j = 0; j < pts.GetLength(1); j++)
                {
                    pts[i, j] = m.Spherical(float.Parse(azarray[i * 51 + j]) * scale, float.Parse(axarray[i]),
                       float.Parse(ayarray[j]));
                    pts[i, j].Transform(mt);
                }
            }
            return pts;
        }

        public Point3[,] CalcuData(string[] axarray, string[] ayarray, string[] azarray, float scale)
        {
            Point3[,] pts = SphereCoordinates(axarray, ayarray, azarray, scale);
            return pts;
        }

        public void DrawIsometricView(Graphics g,Point3[,] pts, string[] azarray,float alpha,float beta,
                     float zmin,float zmax)  
                    
        {
            Pen aPen = new Pen(Color.Black);
            SolidBrush aBrush = new SolidBrush(Color.White);
            //Matrix3 m = Matrix3.Axonometric(35.26f, -45);
            Matrix3 m = Matrix3.Axonometric(alpha, beta);

            PointF[,] pta = new PointF[pts.GetLength(0), pts.GetLength(1)];


            for (int i = 0; i < pts.GetLength(0); i++)
            {
                for (int j = 0; j < pts.GetLength(1); j++)
                {
                    pts[i, j].Transform(m);
                    pta[i, j] = Point2D(new PointF(pts[i, j].X, pts[i, j].Y));
                }
            }

            PointF[] ptf = new PointF[4];
            for (int i = 1; i < pts.GetLength(0); i++)
            {
                for (int j = 1; j < pts.GetLength(1); j++)
                {
                    ptf[0] = pta[i - 1, j - 1];
                    ptf[1] = pta[i, j - 1];
                    ptf[2] = pta[i, j];
                    ptf[3] = pta[i - 1, j];

                    Color color = AddColor(float.Parse(azarray[i * 51 + j]), zmin, zmax);
                    //aPen = new Pen(color);
                    aBrush = new SolidBrush(color);
                    if (isSurface)
                    {
                        g.FillPolygon(aBrush, ptf);
                        if (isLineVisable)
                        {
                            g.DrawPolygon(aPen, ptf);
                        }
                    }
                    else
                    {
                        if (isMesh)
                        {
                            aPen = new Pen(color);
                            g.DrawPolygon(aPen, ptf);
                        }
                    }
                }
            }
        }

        private PointF Point2D(PointF pt)
        {
            PointF aPoint = new PointF();
            aPoint.X = form1.panel1.Width / 2 + pt.X;
            aPoint.Y = form1.panel1.Height / 2 - pt.Y;
            return aPoint;
        }
        //Get z max value and z min value
        private float ZDataMax(Point3[,] PointArray)
        {
            float zmax = 0;
            for (int i = 0; i < PointArray.GetLength(0); i++)
            {
                for (int j = 0; j < PointArray.GetLength(1); j++)
                {
                    zmax = Math.Max(zmax, PointArray[i, j].Z);
                }
            }
            return zmax;
        }
        private float ZDataMin(Point3[,] PointArray)
        {
            float zmin = 0;
            for (int i = 0; i < PointArray.GetLength(0); i++)
            {
                for (int j = 0; j < PointArray.GetLength(1); j++)
                {
                    zmin = Math.Min(zmin, PointArray[i, j].Z);
                }
            }
            return zmin;
        }
        #endregion
    }
}
