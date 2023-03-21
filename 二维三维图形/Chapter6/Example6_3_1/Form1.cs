using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Example6_3_1
{
    
    public partial class Form1 : Form
    {
        
        #region Variables

        private MasterPane _masterPane;
        #endregion

        #region Properties

        public GraphPane GraphPane
        {
            get
            {
                //Just return the first GraphPane in the list
                lock (this)
                {
                    if (_masterPane != null && _masterPane.PaneList.Count > 0)
                        return _masterPane[0];
                    else
                        return null;
                }
            }
            set
            {
                lock (this)
                {
                    //Clear the list, and replace it with the specified Graphpane
                    if (_masterPane != null)
                    {
                        _masterPane.PaneList.Clear();
                        _masterPane.Add(value);
                    }
                }
            }
        }
        public MasterPane MasterPane
        {
            get { lock (this) return _masterPane; }
            set { lock (this) _masterPane = value; }
        }
        #endregion

        #region Constructors

        public Form1()
        {
            InitializeComponent();

            this.Resize += new System.EventHandler(this.formResize);
            //Use double-buffering for flicker-free updating:
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
                 | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            Rectangle rect = new Rectangle(0, 0, this.Size.Width-15, this.Size.Height-30);
            _masterPane = new MasterPane("", rect);
            _masterPane.Margin.All = 0;
            _masterPane.Title.IsVisible = false;

            string titleStr = "Title";
            string xStr = "X Axis";
            string yStr = "Y Axis";

            GraphPane graphPane = new GraphPane(rect, titleStr, xStr, yStr);
            using (Graphics g = this.CreateGraphics())
            {
                graphPane.AxisChange(g);
            }
            _masterPane.Add(graphPane);

        }
        #endregion

        #region Methods

        // Call this method from the Form_Load method
        public void CreateChartErrorBar()
        {
            GraphPane myPane = this.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = "Error Bar Demo Chart";
            myPane.XAxis.Title.Text = "Label";
            myPane.YAxis.Title.Text = "My Y Axis";

            // Make up some data points based on the Sine function
            PointPairList list = new PointPairList();
            for (int i = 0; i < 44; i++)
            {
                double x = i / 44.0;
                double y = Math.Sin((double)i * Math.PI / 15.0);
                double yBase = y - 0.4;
                list.Add(x, y, yBase);
            }

            // Generate a red bar with "Curve 1" in the legend
            ErrorBarItem myCurve = myPane.AddErrorBar("Curve 1", list, Color.Red);
            // Make the X axis the base for this curve (this is the default)
            myPane.BarSettings.Base = BarBase.X;
            myCurve.Bar.PenWidth = 1f;
            // Use the HDash symbol so that the error bars look like I-beams
            myCurve.Bar.Symbol.Type = SymbolType.HDash;
            myCurve.Bar.Symbol.Border.Width = .1f;
            myCurve.Bar.Symbol.IsVisible = true;
            myCurve.Bar.Symbol.Size = 4;

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White,
               Color.LightGoldenrodYellow, 45.0F);

            // Calculate the Axis Scale Ranges
            this.AxisChange();
        }
        // Call this method from the Form_Load method
        public void CreateChartHLC()
        {
            GraphPane myPane = this.GraphPane;

            // Set the title and axis labels
            myPane.Title.Text = "Testing\nHi-Low-Close Daily Stock Chart";
            myPane.XAxis.Title.Text = "";
            myPane.YAxis.Title.Text = "Trading Price, $US";

            // Set the title font characteristics
            myPane.Title.FontSpec.Family = "Arial";
            myPane.Title.FontSpec.IsItalic = true;
            myPane.Title.FontSpec.Size = 18;


            // Generate some random stock price data
            PointPairList hList = new PointPairList();
            PointPairList cList = new PointPairList();
            Random rand = new Random();
            // initialize the starting close price
            double close = 45;

            for (int i = 45; i < 65; i++)
            {
                double x = (double)new XDate(2009, 12, i - 30);
                close = close + 2.0 * rand.NextDouble() - 0.5;
                double hi = close + 2.0 * rand.NextDouble();
                double low = close - 2.0 * rand.NextDouble();
                hList.Add(x, hi, low);
                cList.Add(x, close);
            }


            // Make a new curve with a "Closing Price" label
            LineItem curve = myPane.AddCurve("Closing Price", cList, Color.Black,
               SymbolType.Diamond);
            // Turn off the line display, symbols only
            curve.Line.IsVisible = false;
            // Fill the symbols with solid red color
            curve.Symbol.Fill = new Fill(Color.Red);
            curve.Symbol.Size = 7;

            // Add a blue error bar to the graph
            ErrorBarItem myCurve = myPane.AddErrorBar("Price Range", hList,
               Color.Blue);
            myCurve.Bar.PenWidth = 3;
            myCurve.Bar.Symbol.IsVisible = false;

            // Set the XAxis to date type
            myPane.XAxis.Type = AxisType.Date;
            // X axis step size is 1 day
            myPane.XAxis.Scale.MajorStep = 1;
            myPane.XAxis.Scale.MajorUnit = DateUnit.Day;
            // tilt the x axis labels to an angle of 65 degrees
            myPane.XAxis.Scale.FontSpec.Angle = 65;
            myPane.XAxis.Scale.FontSpec.IsBold = true;
            myPane.XAxis.Scale.FontSpec.Size = 12;
            myPane.XAxis.Scale.Format = "d MMM";
            // make the x axis scale minimum 1 step less than the minimum data value
            myPane.XAxis.Scale.Min = hList[0].X - 1;

            // Display the Y axis grid
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.Scale.MinorStep = 0.5;

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White,
               Color.FromArgb(255, 255, 166), 90F);

            // Calculate the Axis Scale Ranges
            this.AxisChange();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            lock (this)
            {
                if (_masterPane == null)
                    return;
                base.OnPaint(e);

                try { _masterPane.Draw(e.Graphics); }
                catch { }
            }
        }
        protected void formResize(object sender, EventArgs e)
        {
            lock (this)
            {
                if (_masterPane == null)
                    return;
                Size newSize = this.Size;

                using (Graphics g = this.CreateGraphics())
                {
                    _masterPane.ReSize(g, new RectangleF(0, 0, newSize.Width-10, newSize.Height-30));
                }
                this.Invalidate();
            }
        }
        public virtual void AxisChange()
        {
            lock (this)
            {
                if (_masterPane == null)
                    return;
                using (Graphics g = this.CreateGraphics())
                {
                    _masterPane.AxisChange(g);
                }
              
            }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

            //this.CreateChartErrorBar();
            this.CreateChartHLC();////High-Low-Close Price
        }

    }
}