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

namespace Example6_1_3
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
        public void CreateChartFillBar()
        {
            GraphPane myPane = this.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = "Image Fill Example";
            myPane.XAxis.Title.Text = "Region";
            myPane.YAxis.Title.Text = "Astronomy Sector Sales";

            // Make up some random data points
            double[] y = { 80, 70, 65, 78, 40 };
            double[] y2 = { 70, 50, 85, 54, 63 };
            string[] str = { "North", "South", "West", "East", "Central" };

            // Add a bar to the graph
            BarItem myCurve = myPane.AddBar("Curve 1", null, y, Color.White);
            // Access an image from a file (use your own filename here)
            Image image = Bitmap.FromFile(System.AppDomain.CurrentDomain.BaseDirectory + "images\\Leaves.jpg");
            // create a brush with the image
            TextureBrush brush = new TextureBrush(image);
            // use the image for the bar fill
            myCurve.Bar.Fill = new Fill(brush);
            // turn off the bar border
            myCurve.Bar.Border.IsVisible = false;

            // Add a second bar to the graph
            myCurve = myPane.AddBar("Curve 2", null, y2, Color.White);
            // Access an image from a file (use your own filename here)
            Image image2 = Bitmap.FromFile(System.AppDomain.CurrentDomain.BaseDirectory + "images\\Tree.jpg");
            // create a brush with the image
            TextureBrush brush2 = new TextureBrush(image2);
            // use the image for the bar fill
            myCurve.Bar.Fill = new Fill(brush2);
            // turn off the bar border
            myCurve.Bar.Border.IsVisible = false;

            // Draw the X tics between the labels instead of at the labels
            myPane.XAxis.MajorTic.IsBetweenLabels = true;

            // Set the XAxis labels
            myPane.XAxis.Scale.TextLabels = str;

            // Set the XAxis to Text type
            myPane.XAxis.Type = AxisType.Text;

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.SteelBlue, 45.0f);

            // disable the legend
            myPane.Legend.IsVisible = false;

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

            this.CreateChartFillBar();
        }

    }
}