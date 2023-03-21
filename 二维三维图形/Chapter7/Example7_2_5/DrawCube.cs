using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Example7_2_5
{
    public class DrawCube
    {
        private Form1 form1;
        private float side = 10;
        private float elevation = 30;
        private float azimuth = -37.5f;
        private float oneOverd = 0;

        public DrawCube(Form1 fm1)
        {
            form1 = fm1;
        }

        public DrawCube(Form1 fm1, float side1)
        {
            form1 = fm1;
            side = side1;
        }

        public DrawCube(Form1 fm1, float side1, float elevation1, 
            float azimuth1, float oneOverd1)
        {
            form1 = fm1;
            side = side1;
            elevation = elevation1;
            azimuth = azimuth1;
            oneOverd = oneOverd1;
        }

        public Point3[] CubeCoordinates()
        {
            Point3[] pts = new Point3[11];
            // Create the cube:
            pts[0] = new Point3(side, -side, -side, 1);
            pts[1] = new Point3(side, side, -side, 1);
            pts[2] = new Point3(-side, side, -side, 1);
            pts[3] = new Point3(-side, -side, -side, 1);
            pts[4] = new Point3(-side, -side, side, 1);
            pts[5] = new Point3(side, -side, side, 1);
            pts[6] = new Point3(side, side, side, 1);
            pts[7] = new Point3(-side, side, side, 1);
            // Create coordinate axes:
            pts[8] = new Point3(2*side, -side, -side, 1);
            pts[9] = new Point3(-side, 2*side, -side, 1);
            pts[10] = new Point3(-side, -side, 2*side, 1);
            return pts;
        }

        public void AddCube(Graphics g)
        {
            Matrix3 m = Matrix3.AzimuthElevation(elevation, azimuth, oneOverd);
            Point3[] pts = CubeCoordinates();
            PointF[] pta = new PointF[4];
            for (int i = 0; i < pts.Length; i++)
            {
                pts[i].TransformNormalize(m);
            }

            int[] i0, i1;
            i0 = new int[4] { 1, 2, 7, 6 };
            i1 = new int[4] { 2, 3, 4, 7 };
            if (elevation >= 0)
            {
                if (azimuth >= -180 && azimuth < -90)
                {
                    i0 = new int[4] { 1, 2, 7, 6 };
                    i1 = new int[4] { 2, 3, 4, 7 };
                }
                else if (azimuth >= -90 && azimuth < 0)
                {
                    i0 = new int[4] { 3, 4, 5, 0 };
                    i1 = new int[4] { 2, 3, 4, 7 };
                }
                else if (azimuth >= 0 && azimuth < 90)
                {
                    i0 = new int[4] { 3, 4, 5, 0 };
                    i1 = new int[4] { 0, 1, 6, 5 };
                }
                else if (azimuth >= 90 && azimuth <= 180)
                {
                    i0 = new int[4] { 1, 2, 7, 6 };
                    i1 = new int[4] { 0, 1, 6, 5 };
                }
            } 
            else if (elevation < 0)
            {
                if (azimuth >= -180 && azimuth < -90)
                {
                    i0 = new int[4] { 0, 1, 6, 5 };
                    i1 = new int[4] { 0, 3, 4, 5 };
                }
                else if (azimuth >= -90 && azimuth < 0)
                {
                    i0 = new int[4] { 1, 2, 7, 6 };
                    i1 = new int[4] { 0, 1, 6, 5 };
                }
                else if (azimuth >= 0 && azimuth < 90)
                {
                    i0 = new int[4] { 2, 3, 4, 7 };
                    i1 = new int[4] { 1, 2, 7, 6 };
                }
                else if (azimuth >= 90 && azimuth <= 180)
                {
                    i0 = new int[4] { 2, 3, 4, 7 };
                    i1 = new int[4] { 0, 3, 4, 5 };
                }

            }

            pta[0] = Point2D(new PointF(pts[i0[0]].X, pts[i0[0]].Y));
            pta[1] = Point2D(new PointF(pts[i0[1]].X, pts[i0[1]].Y));
            pta[2] = Point2D(new PointF(pts[i0[2]].X, pts[i0[2]].Y));
            pta[3] = Point2D(new PointF(pts[i0[3]].X, pts[i0[3]].Y));
            g.FillPolygon(Brushes.LightCoral, pta);
            g.DrawPolygon(Pens.Black, pta);
            pta[0] = Point2D(new PointF(pts[i1[0]].X, pts[i1[0]].Y));
            pta[1] = Point2D(new PointF(pts[i1[1]].X, pts[i1[1]].Y));
            pta[2] = Point2D(new PointF(pts[i1[2]].X, pts[i1[2]].Y));
            pta[3] = Point2D(new PointF(pts[i1[3]].X, pts[i1[3]].Y));
            g.FillPolygon(Brushes.LightGreen, pta);
            g.DrawPolygon(Pens.Black, pta);
            pta[0] = Point2D(new PointF(pts[4].X, pts[4].Y));
            pta[1] = Point2D(new PointF(pts[5].X, pts[5].Y));
            pta[2] = Point2D(new PointF(pts[6].X, pts[6].Y));
            pta[3] = Point2D(new PointF(pts[7].X, pts[7].Y));
            g.FillPolygon(Brushes.LightGray, pta);
            g.DrawPolygon(Pens.Black, pta);

            // Create coordinate axes:
            pta = new PointF[2];
            pta[0] = Point2D(new PointF(pts[3].X, pts[3].Y));
            pta[1] = Point2D(new PointF(pts[8].X, pts[8].Y));

            Pen pp = new Pen(Color.Red);
            pp.EndCap = LineCap.ArrowAnchor;
            g.DrawLine(pp, pta[0], pta[1]);
            //g.DrawLine(Pens.Red, pta[0], pta[1]);
            pp.Dispose();
            pta[1] = Point2D(new PointF(pts[9].X, pts[9].Y));
            pp = new Pen(Color.Green);
            pp.EndCap = LineCap.ArrowAnchor;
            g.DrawLine(pp, pta[0], pta[1]);

            //g.DrawLine(Pens.Green, pta[0], pta[1]);
            pp.Dispose();
            pta[1] = Point2D(new PointF(pts[10].X, pts[10].Y));
            pp = new Pen(Color.Black);
            pp.EndCap = LineCap.ArrowAnchor;
            g.DrawLine(pp, pta[0], pta[1]);
            //g.DrawLine(Pens.Blue, pta[0], pta[1]);

        }

        private PointF Point2D(PointF pt)
        {
            PointF aPoint = new PointF();
            aPoint.X = form1.panel1.Width / 2 + pt.X;
            aPoint.Y = form1.panel1.Height / 2 - pt.Y;
            return aPoint;
        }
    }
}