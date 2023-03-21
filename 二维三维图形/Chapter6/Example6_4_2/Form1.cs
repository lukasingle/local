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

namespace Example6_4_2
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
        public void CreateChartOHLC()
        {
            GraphPane myPane = this.GraphPane;

            // Set the title and axis labels   
            myPane.Title.Text = "OHLC Chart Demo";
            myPane.XAxis.Title.Text = "Date";
            myPane.YAxis.Title.Text = "Price";

            // Load a StockPointList with random data...
            StockPointList spl = new StockPointList();
            Random rand = new Random();

            // First day is jan 1st
            XDate xDate = new XDate(2009, 1, 1);
            double open = 50.0;
            double prevClose = 0;

            // Loop to make 50 days of data
            for (int i = 0; i < 50; i++)
            {
                double x = xDate.XLDate;
                double close = open + rand.NextDouble() * 10.0 - 5.0;
                double hi = Math.Max(open, close) + rand.NextDouble() * 5.0;
                double low = Math.Min(open, close) - rand.NextDouble() * 5.0;

                // Create a StockPt instead of a PointPair so we can carry 6 properties
                StockPt pt = new StockPt(x, hi, low, open, close, 100000);

                //if price is increasing color=black, else color=red
                pt.ColorValue = close > prevClose ? 2 : 1;
                spl.Add(pt);

                prevClose = close;
                open = close;
                // Advance one day
                xDate.AddDays(1.0);
                // but skip the weekends
                if (XDate.XLDateToDayOfWeek(xDate.XLDate) == 6)
                    xDate.AddDays(2.0);
            }

            // Setup the gradient fill...
            // Use Red for negative days and black for positive days
            Color[] colors = { Color.Red, Color.Black };
            Fill myFill = new Fill(colors);
            myFill.Type = FillType.GradientByColorValue;
            myFill.SecondaryValueGradientColor = Color.Empty;
            myFill.RangeMin = 1;
            myFill.RangeMax = 2;

            //Create the OHLC and assign it a Fill
            OHLCBarItem myCurve = myPane.AddOHLCBar("Price", spl, Color.Empty);
            myCurve.Bar.GradientFill = myFill;
            myCurve.Bar.IsAutoSize = true;

            // Use DateAsOrdinal to skip weekend gaps
            myPane.XAxis.Type = AxisType.DateAsOrdinal;

            // pretty it up a little
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45.0f);
            myPane.Title.FontSpec.Size = 20.0f;
            myPane.XAxis.Title.FontSpec.Size = 18.0f;
            myPane.XAxis.Scale.FontSpec.Size = 16.0f;
            myPane.YAxis.Title.FontSpec.Size = 18.0f;
            myPane.YAxis.Scale.FontSpec.Size = 16.0f;
            myPane.Legend.IsVisible = true;

            // Tell Example to calculate the axis ranges
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

            this.CreateChartOHLC();
        }

    }
}