using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Example8_1_1
{
    public partial class Form1 : Form
    {
        #region Variables

        private ChartStyle cs;

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
            this.BackColor = Color.White;

            //Define bitmap
            this.InitialBitmap();

            // Subscribing to a paint eventhandler to drawingPanel: 
            //PlotPanel.Paint +=
            //    new PaintEventHandler(PlotPanelPaint);

            cs = new ChartStyle(this);
            cs.GridStyle.LineColor = Color.LightGray;
            cs.GridStyle.Pattern = DashStyle.Dash;
            //cs.AxisStyle.LineColor = Color.Blue;
            //cs.AxisStyle.Thickness = 2;
            //cs.YTick = 1f;
        }
        #endregion

        #region Methods

        private void DrawPlot(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            cs.Elevation = trkElevation.Value;
            cs.Azimuth = trkAzimuth.Value;
            cs.AddChartStyle(g);
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

            //this.RefreshBackground();
            
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
            Color bckColor = this.PlotPanel.BackColor;
            gB.Clear(bckColor);
            this.RefreshBackground();
        }
    }
}