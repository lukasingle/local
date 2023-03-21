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

namespace Example5_2_3
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

            Rectangle rect = new Rectangle(0, 0, this.Size.Width-10, this.Size.Height-30);
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
        public void CreateChartScatter()
        {
            GraphPane myPane = this.GraphPane;

            // Set the titles
            myPane.Title.Text = "Scatter Plot Demo";
            myPane.XAxis.Title.Text = "Pressure, Atm";
            myPane.YAxis.Title.Text = "Flow Rate, cc/hr";

            // Get a random number generator
            Random rand = new Random();

            // Populate a PointPairList with a log-based function and some random variability
            PointPairList list = new PointPairList();
            for (int i = 0; i < 200; i++)
            {
                double x = rand.NextDouble() * 20.0 + 1;
                double y = Math.Log(10.0 * (x - 1.0) + 1.0) * (rand.NextDouble() * 0.2 + 0.9);
                list.Add(x, y);
            }

            // Add the curve
            LineItem myCurve = myPane.AddCurve("Performance", list, Color.Black, SymbolType.Diamond);
            // Don't display the line (This makes a scatter plot)
            myCurve.Line.IsVisible = false;
            // Hide the symbol outline
            myCurve.Symbol.Border.IsVisible = false;
            // Fill the symbol interior with color
            myCurve.Symbol.Fill = new Fill(Color.Firebrick);

            // Fill the background of the chart rect and pane
            myPane.Chart.Fill = new Fill(Color.White, Color.LightBlue, 45.0f);
            myPane.Fill = new Fill(Color.White, Color.SlateGray, 45.0f);

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

            this.CreateChartScatter();
        }

    }
}