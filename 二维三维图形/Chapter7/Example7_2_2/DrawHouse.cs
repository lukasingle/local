using System;
using System.Drawing;

namespace Example7_2_2
{
    public class DrawHouse
    {
        private Form1 form1;
        private float a = 10;

        public DrawHouse(Form1 fm1)
        {
            form1 = fm1;
        }

        public DrawHouse(Form1 fm1, float a1)
        {
            form1 = fm1;
            a = a1;
        }

        public Point3[] HouseCoordinates()
        {
            Point3[] pts = new Point3[10];
            pts[0] = new Point3(0, 0, 0, 1);
            pts[1] = new Point3(a, 0, 0, 1);
            pts[2] = new Point3(a, a, 0, 1);
            pts[3] = new Point3(a / 2, 5 * a / 4, 0, 1);
            pts[4] = new Point3(0, a, 0, 1);
            pts[5] = new Point3(0, a, a, 1);
            pts[6] = new Point3(a / 2, 5 * a / 4, a, 1);
            pts[7] = new Point3(a, a, a, 1);
            pts[8] = new Point3(a, 0, a, 1);
            pts[9] = new Point3(0, 0, a, 1);
            return pts;
        }

        public void DrawFrontView(Graphics g)
        {
            // Project points to front view:
            Point3[] pts = HouseCoordinates();
            Matrix3 m = Matrix3.FrontView();
            for (int i = 0; i < pts.Length; i++)
            {
                pts[i].Transform(m);
            }
            PointF[] pta = new PointF[5];
            pta[0] = Point2D(new PointF(pts[5].X, pts[5].Y));
            pta[1] = Point2D(new PointF(pts[6].X, pts[6].Y));
            pta[2] = Point2D(new PointF(pts[7].X, pts[7].Y));
            pta[3] = Point2D(new PointF(pts[8].X, pts[8].Y));
            pta[4] = Point2D(new PointF(pts[9].X, pts[9].Y));
            g.FillPolygon(Brushes.LightGray, pta);
            g.DrawPolygon(Pens.Black, pta);
        }

        public void DrawSideView(Graphics g)
        {
            // Project points to front view:
            Point3[] pts = HouseCoordinates();
            Matrix3 m = Matrix3.SideView();
            for (int i = 0; i < pts.Length; i++)
            {
                pts[i].Transform(m);
            }
            PointF[] pta = new PointF[6];
            pta[0] = Point2D(new PointF(pts[1].X, pts[1].Y));
            pta[1] = Point2D(new PointF(pts[2].X, pts[2].Y));
            pta[2] = Point2D(new PointF(pts[3].X, pts[3].Y));
            pta[3] = Point2D(new PointF(pts[6].X, pts[6].Y));
            pta[4] = Point2D(new PointF(pts[7].X, pts[7].Y));
            pta[5] = Point2D(new PointF(pts[8].X, pts[8].Y));
            g.FillPolygon(Brushes.LightGray, pta);
            g.DrawPolygon(Pens.Black, pta);
            g.DrawLine(Pens.Black, pta[1], pta[4]);
        }

        public void DrawTopView(Graphics g)
        {
            // Project points to front view:
            Point3[] pts = HouseCoordinates();
            Matrix3 m = Matrix3.TopView();
            for (int i = 0; i < pts.Length; i++)
            {
                pts[i].Transform(m);
            }
            PointF[] pta = new PointF[6];
            pta[0] = Point2D(new PointF(pts[2].X, pts[2].Y));
            pta[1] = Point2D(new PointF(pts[3].X, pts[3].Y));
            pta[2] = Point2D(new PointF(pts[4].X, pts[4].Y));
            pta[3] = Point2D(new PointF(pts[5].X, pts[5].Y));
            pta[4] = Point2D(new PointF(pts[6].X, pts[6].Y));
            pta[5] = Point2D(new PointF(pts[7].X, pts[7].Y));
            g.FillPolygon(Brushes.LightGray, pta);
            g.DrawPolygon(Pens.Black, pta);
            g.DrawLine(Pens.Black, pta[1], pta[4]);
        }

        public void DrawIsometricView(Graphics g)
        {
            // Project points to front view:
            Point3[] pts = HouseCoordinates();
            Matrix3 m = Matrix3.Axonometric(35.26f,-45);
            for (int i = 0; i < pts.Length; i++)
            {
                pts[i].Transform(m);
            }
            PointF[] pta = new PointF[6];
            pta[0] = Point2D(new PointF(pts[2].X, pts[2].Y));
            pta[1] = Point2D(new PointF(pts[3].X, pts[3].Y));
            pta[2] = Point2D(new PointF(pts[4].X, pts[4].Y));
            pta[3] = Point2D(new PointF(pts[5].X, pts[5].Y));
            pta[4] = Point2D(new PointF(pts[6].X, pts[6].Y));
            pta[5] = Point2D(new PointF(pts[7].X, pts[7].Y));
            g.FillPolygon(Brushes.LightGray, pta);
            g.DrawPolygon(Pens.Black, pta);
            g.DrawLine(Pens.Black, pta[1], pta[4]);
            pta = new PointF[5];
            pta[0] = Point2D(new PointF(pts[5].X, pts[5].Y));
            pta[1] = Point2D(new PointF(pts[6].X, pts[6].Y));
            pta[2] = Point2D(new PointF(pts[7].X, pts[7].Y));
            pta[3] = Point2D(new PointF(pts[8].X, pts[8].Y));
            pta[4] = Point2D(new PointF(pts[9].X, pts[9].Y));
            g.FillPolygon(Brushes.LightGray, pta);
            g.DrawPolygon(Pens.Black, pta);
            pta = new PointF[4];
            pta[0] = Point2D(new PointF(pts[1].X, pts[1].Y));
            pta[1] = Point2D(new PointF(pts[2].X, pts[2].Y));
            pta[2] = Point2D(new PointF(pts[7].X, pts[7].Y));
            pta[3] = Point2D(new PointF(pts[8].X, pts[8].Y));
            g.FillPolygon(Brushes.LightGray, pta);
            g.DrawPolygon(Pens.Black, pta);
        }

        public void DrawDimetricView(Graphics g)
        {
            // Project points to front view:
            Point3[] pts = HouseCoordinates();
            Matrix3 m = Matrix3.Axonometric(19.47f, -20.7f);
            for (int i = 0; i < pts.Length; i++)
            {
                pts[i].Transform(m);
            }
            PointF[] pta = new PointF[6];
            pta[0] = Point2D(new PointF(pts[2].X, pts[2].Y));
            pta[1] = Point2D(new PointF(pts[3].X, pts[3].Y));
            pta[2] = Point2D(new PointF(pts[4].X, pts[4].Y));
            pta[3] = Point2D(new PointF(pts[5].X, pts[5].Y));
            pta[4] = Point2D(new PointF(pts[6].X, pts[6].Y));
            pta[5] = Point2D(new PointF(pts[7].X, pts[7].Y));
            g.FillPolygon(Brushes.LightGray, pta);
            g.DrawPolygon(Pens.Black, pta);
            g.DrawLine(Pens.Black, pta[1], pta[4]);
            pta = new PointF[5];
            pta[0] = Point2D(new PointF(pts[5].X, pts[5].Y));
            pta[1] = Point2D(new PointF(pts[6].X, pts[6].Y));
            pta[2] = Point2D(new PointF(pts[7].X, pts[7].Y));
            pta[3] = Point2D(new PointF(pts[8].X, pts[8].Y));
            pta[4] = Point2D(new PointF(pts[9].X, pts[9].Y));
            g.FillPolygon(Brushes.LightGray, pta);
            g.DrawPolygon(Pens.Black, pta);
            pta = new PointF[4];
            pta[0] = Point2D(new PointF(pts[1].X, pts[1].Y));
            pta[1] = Point2D(new PointF(pts[2].X, pts[2].Y));
            pta[2] = Point2D(new PointF(pts[7].X, pts[7].Y));
            pta[3] = Point2D(new PointF(pts[8].X, pts[8].Y));
            g.FillPolygon(Brushes.LightGray, pta);
            g.DrawPolygon(Pens.Black, pta);
        }

        public void DrawTrimetricView(Graphics g)
        {
            // Project points to front view:
            Point3[] pts = HouseCoordinates();
            Matrix3 m = Matrix3.Axonometric(33.21f, -67.79f);
            for (int i = 0; i < pts.Length; i++)
            {
                pts[i].Transform(m);
            }
            PointF[] pta = new PointF[6];
            pta[0] = Point2D(new PointF(pts[2].X, pts[2].Y));
            pta[1] = Point2D(new PointF(pts[3].X, pts[3].Y));
            pta[2] = Point2D(new PointF(pts[4].X, pts[4].Y));
            pta[3] = Point2D(new PointF(pts[5].X, pts[5].Y));
            pta[4] = Point2D(new PointF(pts[6].X, pts[6].Y));
            pta[5] = Point2D(new PointF(pts[7].X, pts[7].Y));
            g.FillPolygon(Brushes.LightGray, pta);
            g.DrawPolygon(Pens.Black, pta);
            g.DrawLine(Pens.Black, pta[1], pta[4]);
            pta = new PointF[5];
            pta[0] = Point2D(new PointF(pts[5].X, pts[5].Y));
            pta[1] = Point2D(new PointF(pts[6].X, pts[6].Y));
            pta[2] = Point2D(new PointF(pts[7].X, pts[7].Y));
            pta[3] = Point2D(new PointF(pts[8].X, pts[8].Y));
            pta[4] = Point2D(new PointF(pts[9].X, pts[9].Y));
            g.FillPolygon(Brushes.LightGray, pta);
            g.DrawPolygon(Pens.Black, pta);
            pta = new PointF[4];
            pta[0] = Point2D(new PointF(pts[1].X, pts[1].Y));
            pta[1] = Point2D(new PointF(pts[2].X, pts[2].Y));
            pta[2] = Point2D(new PointF(pts[7].X, pts[7].Y));
            pta[3] = Point2D(new PointF(pts[8].X, pts[8].Y));
            g.FillPolygon(Brushes.LightGray, pta);
            g.DrawPolygon(Pens.Black, pta);
        }

        public void DrawAxonometricView(Graphics g, float alpha, float beta)
        {
            // Project points to front view:
            Point3[] pts = HouseCoordinates();
            Matrix3 m = Matrix3.Axonometric(alpha, beta);
            for (int i = 0; i < pts.Length; i++)
            {
                pts[i].Transform(m);
            }
            PointF[] pta = new PointF[4];
            pta[0] = Point2D(new PointF(pts[3].X, pts[3].Y));
            pta[1] = Point2D(new PointF(pts[4].X, pts[4].Y));
            pta[2] = Point2D(new PointF(pts[5].X, pts[5].Y));
            pta[3] = Point2D(new PointF(pts[6].X, pts[6].Y));
            g.FillPolygon(Brushes.LightGray, pta);
            g.DrawPolygon(Pens.Black, pta);
            pta = new PointF[4];
            pta[0] = Point2D(new PointF(pts[2].X, pts[2].Y));
            pta[1] = Point2D(new PointF(pts[3].X, pts[3].Y));
            pta[2] = Point2D(new PointF(pts[6].X, pts[6].Y));
            pta[3] = Point2D(new PointF(pts[7].X, pts[7].Y));
            g.FillPolygon(Brushes.LightGray, pta);
            g.DrawPolygon(Pens.Black, pta);
            pta = new PointF[5];
            pta[0] = Point2D(new PointF(pts[5].X, pts[5].Y));
            pta[1] = Point2D(new PointF(pts[6].X, pts[6].Y));
            pta[2] = Point2D(new PointF(pts[7].X, pts[7].Y));
            pta[3] = Point2D(new PointF(pts[8].X, pts[8].Y));
            pta[4] = Point2D(new PointF(pts[9].X, pts[9].Y));
            g.FillPolygon(Brushes.LightGray, pta);
            g.DrawPolygon(Pens.Black, pta);
            pta = new PointF[4];
            pta[0] = Point2D(new PointF(pts[1].X, pts[1].Y));
            pta[1] = Point2D(new PointF(pts[2].X, pts[2].Y));
            pta[2] = Point2D(new PointF(pts[7].X, pts[7].Y));
            pta[3] = Point2D(new PointF(pts[8].X, pts[8].Y));
            g.FillPolygon(Brushes.LightGray, pta);
            g.DrawPolygon(Pens.Black, pta);
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
