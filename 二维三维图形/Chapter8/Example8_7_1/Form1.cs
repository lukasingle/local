using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Example8_7_1
{
    public partial class Form1 : Form
    {
        #region Variables

        //Define a graphic variable to graphic
        private Graphics gB;
        private Bitmap bitmap, bm;
        //Define instances of class
        private ChartStyle cs;
        private ChartStyle2D cs2d;
        private DataSeries ds;
        private DrawChart dc;
        private ChartFunctions cf;
        private ColorMap cm;

        private int[,] colortype;
        private float azimuth = -37;
        private float elevation = 30;

        private int Th = 45;
        private decimal cmin = 0, cmax = 100;   
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

            cs.Elevation = elevation;
            cs.Azimuth = azimuth;

            cs2d.ChartBackColor = Color.White;
            cs2d.ChartBorderColor = Color.Black;


            ds.LineStyle.IsVisible = false;
            //ds.LineStyle.IsVisible = true;
           
            //dc.ChartType = DrawChart.ChartTypeEnum.Mesh;
            //dc.ChartType = DrawChart.ChartTypeEnum.MeshZ;
            //dc.ChartType = DrawChart.ChartTypeEnum.Waterfall;
            //dc.ChartType = DrawChart.ChartTypeEnum.Surface;

            //dc.ChartType = DrawChart.ChartTypeEnum.MeshContour;
            //dc.ChartType = DrawChart.ChartTypeEnum.SurfaceContour;
            dc.ChartType = DrawChart.ChartTypeEnum.SurfaceFillContour;

            //dc.IsColorMap = false;
            dc.IsColorMap = true;
            dc.IsHiddenLine = true;
            //dc.IsHiddenLine = false;

            dc.IsInterp = true;
            dc.NumberInterp = 6;
            dc.CMap = cm.Rainbow(Th);
                    
        }
        #endregion

        #region Methods

        private void DrawPlot(int[,] colortype)
        {
            if (dc == null)
                return;
            gB.SmoothingMode = SmoothingMode.AntiAlias;
            dc.CMap = colortype;

            //cf.Peak3D(ds, cs);
            //cf.SinROverR3D(ds, cs);
            cf.ReadDataFromFile(ds, cs);
            cs.AddChartStyle(gB);
            dc.AddChart(gB, ds, cs, cs2d);
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
            DrawPlot(colortype);

            Size sz = this.PlotPanel.Size;
            Rectangle rt = new Rectangle(0, 0, sz.Width, sz.Height);
            bm = bitmap.Clone(rt, bitmap.PixelFormat);
            PlotPanel.BackgroundImage = bm;
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            //Define bitmap
            InitialBitmap();
            Color bckColor = this.PlotPanel.BackColor;
            gB.Clear(bckColor);
            cmbcolortype.SelectedIndex = 2;
            RefreshBackground();
        }

        private void cmbcolortype_SelectedIndexChanged(object sender, EventArgs e)
        {
            string color = cmbcolortype.Text;

            switch (color)
            {
                case "Autumn":
                    colortype = cm.Autumn();
                    break;
                case "Cool":
                    colortype = cm.Cool();
                    break;
                case "Gray":
                    colortype = cm.Gray();
                    break;
                case "Hot":
                    colortype = cm.Hot();
                    break;
                case "Jet":
                    colortype = cm.Jet();
                    break;
                case "Spring":
                    colortype = cm.Spring();
                    break;
                case "Summer":
                    colortype = cm.Summer();
                    break;
                case "Winter":
                    colortype = cm.Winter();
                    break;
                case "Mix1":
                    colortype = cm.Mix1();
                    break;
                case "Mix2":
                    colortype = cm.Mix2();
                    break;
                case "Mix3":
                    colortype = cm.Mix3();
                    break;
                case "Mix4":
                    colortype = cm.Mix4();
                    break;
                case "Rainbow":
                    colortype = cm.Rainbow(Th);
                    break;
                case "FallGrYl":
                    colortype = cm.FallGrYl();
                    break;
                case "FallRdGr":
                    colortype = cm.FallRdGr();
                    break;
                case "Cool1":
                    colortype = cm.Cool1(255);
                    break;
                case "Cool11":
                    colortype = cm.Cool11(255);
                    break;
                case "Cool2":
                    colortype = cm.Cool2(255);
                    break;
                case "Cool22":
                    colortype = cm.Cool22(255);
                    break;
                case "DeltaRdGr":
                    colortype = cm.DeltaRdGr(cmax, cmin);
                    break;
                case "DeltaRdBl":
                    colortype = cm.DeltaRdBl(cmax, cmin);
                    break;
                case "DeltaGrBl":
                    colortype = cm.DeltaGrBl(cmax, cmin);
                    break;
                case "DeltaGrRd":
                    colortype = cm.DeltaGrRd(cmax, cmin);
                    break;
                case "Hot1":
                    colortype = cm.Hot1();
                    break;
                case "Hot2":
                    colortype = cm.Hot2();
                    break;
                default:
                    break;
            }

            RefreshBackground();

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            InitialBitmap();
            RefreshBackground();
        }

        private void numericUpDownBeta_ValueChanged(object sender, EventArgs e)
        {
            azimuth = (float)numericUpDownBeta.Value;
            cs.Azimuth = azimuth;
            RefreshBackground();
        }

        private void numericUpDownAlpha_ValueChanged(object sender, EventArgs e)
        {
            elevation = (float)numericUpDownAlpha.Value;
            cs.Elevation = elevation;
            RefreshBackground();
        }

        private void btnrotate_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            int i;
            for (i = -180; i <= 180; i += 2)
            {
                Thread.Sleep(50);
                azimuth = (float)i;
                numericUpDownBeta.Value = i;
                numericUpDownBeta.Refresh();

                PlotPanel.Refresh();
            }

            Cursor = Cursors.Default;
        }
    }
}