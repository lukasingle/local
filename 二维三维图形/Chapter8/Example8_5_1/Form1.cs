using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Example8_5_1
{
    public partial class Form1 : Form
    {
        #region Variables

        private ChartStyle cs;
        private ChartStyle2D cs2d;
        private DataSeries ds;
        private DrawChart dc;
        private ChartFunctions cf;
        private ColorMap cm;
        #endregion

        #region Constructors

        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.UserPaint | 
                ControlStyles.DoubleBuffer,true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.White;

            // Subscribing to a paint eventhandler to drawingPanel: 
            PlotPanel.Paint +=
                new PaintEventHandler(PlotPanelPaint);
            cs = new ChartStyle(this);
            cs2d = new ChartStyle2D(this);
            ds = new DataSeries();
            dc = new DrawChart(this);
            cf = new ChartFunctions();
            cm = new ColorMap();

            cs.GridStyle.LineColor = Color.LightGray;
            cs.GridStyle.Pattern = DashStyle.Dash;
            cs.Title = "No Title";
            cs.IsColorBar = true;

            cs2d.ChartBackColor = Color.White;
            cs2d.ChartBorderColor = Color.Black;

            //ds.LineStyle.IsVisible = false;
            ds.LineStyle.IsVisible = true;

            dc.ChartType = DrawChart.ChartTypeEnum.XYColor;
            //dc.ChartType = DrawChart.ChartTypeEnum.Contour;
            //dc.ChartType = DrawChart.ChartTypeEnum.FillContour;

            //dc.IsColorMap = true;
            //dc.IsColorMap = false;
            dc.IsHiddenLine = false;
            //dc.IsHiddenLine = true;

            //dc.IsInterp = true;
            //dc.NumberInterp = 5;

            //dc.NumberContours = 15;
            dc.CMap = cm.Mix4();
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            if (dc.ChartType == DrawChart.ChartTypeEnum.XYColor||
                dc.ChartType == DrawChart.ChartTypeEnum.Contour ||
                dc.ChartType == DrawChart.ChartTypeEnum.FillContour)
            {
                Rectangle rect = this.ClientRectangle;
                //cs2d.ChartArea = new Rectangle(rect.X, rect.Y,
                //    rect.Width, 19 * rect.Height / 30);

                cs2d.ChartArea = new Rectangle(rect.X, rect.Y,
                    rect.Width, rect.Height);

                //cf.Peak3D(ds, cs);
                //cf.Exp4D(ds, cs);
                cf.ReadDataFromFile(ds, cs);
                cs2d.SetPlotArea(g, cs);
                dc.AddColorBar(g, ds, cs, cs2d);

            }
        }

        private void PlotPanelPaint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (dc.ChartType == DrawChart.ChartTypeEnum.XYColor||
                dc.ChartType == DrawChart.ChartTypeEnum.Contour||
                dc.ChartType == DrawChart.ChartTypeEnum.FillContour)
            {
                cs2d.AddChartStyle2D(g, cs);
                dc.AddChart(g, ds, cs, cs2d);

            }

        }


        private void PlotPanel_Resize(object sender, EventArgs e)
        {
            PlotPanel.Invalidate();
        }
    }
}