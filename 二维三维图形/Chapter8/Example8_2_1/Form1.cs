using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Example8_2_1
{
    public partial class Form1 : Form
    {
        #region Variables

        private ChartStyle cs;
        private DataSeries ds;
        private DrawChart dc;

        //Define a graphic variable to graphic
        private Graphics gB;
        private Bitmap bitmap, bm;

        #endregion

        #region Constructors

        public Form1()
        {
            InitializeComponent();
            
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.SetStyle(ControlStyles.UserPaint, true);//When this flag is set to true,
            //the control paints itself and is not painted by the system operation

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            this.SetStyle(ControlStyles.DoubleBuffer, true);//when set Control.DoubleBuffered to true, 
            //it will set the ControlStyles.AllPaintingInWmPaint and ControlStyles.OptimizedDoubleBuffer to true           

            this.InitialBitmap();

            this.BackColor = Color.White;

            //// Subscribing to a paint eventhandler to drawingPanel: 
            //PlotPanel.Paint +=
            //    new PaintEventHandler(PlotPanelPaint);

            cs = new ChartStyle(this);
            ds = new DataSeries();
            dc = new DrawChart(this);
            cs.GridStyle.LineColor = Color.LightGray;
            cs.GridStyle.Pattern = DashStyle.Dash;
            cs.XMin = -1f;
            cs.XMax = 1f;
            cs.YMin = -1f;
            cs.YMax = 1f;
            cs.ZMin = 0;
            cs.ZMax = 30;
            cs.XTick = 0.5f;
            cs.YTick = 0.5f;
            cs.ZTick = 5;
            cs.Title = "No Title";
        }
        #endregion

        #region Methods

        private void AddData()
        {
            ds.PointList.Clear();
            ds.LineStyle.LineColor = Color.Red;
            for (int i = 0; i < 300; i++)
            {
                float t = 0.1f * i;
                float x = (float)Math.Exp(-t / 30) * (float)Math.Cos(t);
                float y = (float)Math.Exp(-t / 30) * (float)Math.Sin(t);
                float z = t;
                ds.AddPoint(new Point3(x, y, z, 1));
            }
        }
        private void DrawPlot(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            cs.Elevation = trkElevation.Value;
            cs.Azimuth = trkAzimuth.Value;
            cs.AddChartStyle(g);
            AddData();
            dc.AddLine(g, ds, cs);
        }
        private void InitialBitmap()
        {
            //Define bitmap
            Size size = new Size(PlotPanel.Width, PlotPanel.Height);
            bitmap = new Bitmap(size.Width, size.Height);
            gB = Graphics.FromImage(bitmap);
        }
        private void RefreshBackground()
        {
            gB.Clear(this.PlotPanel.BackColor);
            DrawPlot(gB);

            Size sz = this.PlotPanel.Size;
            Rectangle rt = new Rectangle(0, 0, sz.Width, sz.Height);
            bm = bitmap.Clone(rt, bitmap.PixelFormat);
            PlotPanel.BackgroundImage = bm;
        }
        #endregion 

        private void PlotPanelPaint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            //g.SmoothingMode = SmoothingMode.AntiAlias;
            //cs.Elevation = trkElevation.Value;
            //cs.Azimuth = trkAzimuth.Value;
            //cs.AddChartStyle(g);
            //AddData();
            //dc.AddLine(g, ds, cs);
        }

        private void trkElevation_Scroll(object sender, EventArgs e)
        {
            tbElevation.Text = trkElevation.Value.ToString();
            //PlotPanel.Invalidate();
            this.RefreshBackground();
        }

        private void trkAzimuth_Scroll(object sender, EventArgs e)
        {
            tbAzimuth.Text = trkAzimuth.Value.ToString();
            //PlotPanel.Invalidate();
            this.RefreshBackground();

        }

        private void tbElevation_KeyUp(object sender, KeyEventArgs e)
        {
            int value;
            bool result = Int32.TryParse(tbElevation.Text, out value);
            if (result)
            {
                if (value <= -90)
                    value = -90;
                else if (value >= 90)
                    value = 90;
                trkElevation.Value = value;
            }
            //PlotPanel.Invalidate();
            this.RefreshBackground();

        }

        private void tbAzimuth_KeyUp(object sender, KeyEventArgs e)
        {
            int value;
            bool result = Int32.TryParse(tbAzimuth.Text, out value);
            if (result)
            {
                if (value <= -180)
                    value = -180;
                else if (value >= 180)
                    value = 180;
                trkAzimuth.Value = value;
            }
            //PlotPanel.Invalidate();
            this.RefreshBackground();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.RefreshBackground();
        }
    }
}