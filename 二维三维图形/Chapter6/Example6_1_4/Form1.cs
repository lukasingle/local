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

namespace Example6_1_4
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
        public void CreateChartOverlayBar()
        {
            GraphPane myPane = this.GraphPane;

            // Set the title and axis label
            myPane.Title.Text = "Overlay Bar Graph Demo";
            myPane.YAxis.Title.Text = "Value";

            // Enter some data values
            double[] y = { 100, 115, 75, -22, 98, 40, -10 };
            double[] y2 = { 90, 100, 95, -35, 80, 35, 35 };
            double[] y3 = { 80, 110, 65, -15, 54, 67, 18 };

            // Manually sum up the curves
            for (int i = 0; i < y.GetLength(0); i++)
                y2[i] += y[i];
            for (int i = 0; i < y2.GetLength(0); i++)
                y3[i] += y2[i];


            // Generate a red bar with "Curve 1" in the legend
            CurveItem myCurve = myPane.AddBar("Curve 1", null, y, Color.Red);

            // Generate a blue bar with "Curve 2" in the legend
            myCurve = myPane.AddBar("Curve 2", null, y2, Color.Blue);

            // Generate a green bar with "Curve 3" in the legend
            myCurve = myPane.AddBar("Curve 3", null, y3, Color.Green);

            // Draw the X tics between the labels instead of at the labels
            myPane.XAxis.MajorTic.IsBetweenLabels = true;

            // Set the XAxis to the ordinal type
            myPane.XAxis.Type = AxisType.Linear;

            //Add Labels to the curves

            // Shift the text items up by 5 user scale units above the bars
            const float shift = 5;

            for (int i = 0; i < y.Length; i++)
            {
                // format the label string to have 1 decimal place
                string lab = y3[i].ToString("F1");
                // create the text item (assumes the x axis is ordinal or text)
                // for negative bars, the label appears just above the zero value
                TextObj text = new TextObj(lab, (float)(i + 1), (float)(y3[i] < 0 ? 0.0 : y3[i]) + shift);
                // tell Zedgraph to use user scale units for locating the TextItem
                text.Location.CoordinateFrame = CoordType.AxisXYScale;
                // AlignH the left-center of the text to the specified point
                text.Location.AlignH = AlignH.Left;
                text.Location.AlignV = AlignV.Center;
                text.FontSpec.Border.IsVisible = false;
                text.FontSpec.Fill.IsVisible = false;
                // rotate the text 90 degrees
                text.FontSpec.Angle = 90;
                // add the TextItem to the list
                myPane.GraphObjList.Add(text);
            }

            // Indicate that the bars are overlay type, which are drawn on top of eachother
            myPane.BarSettings.Type = BarType.Overlay;

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0F);

            // Calculate the Axis Scale Ranges
            this.AxisChange();

            // Add one step to the max scale value to leave room for the labels
            myPane.YAxis.Scale.Max += myPane.YAxis.Scale.MajorStep;

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

            this.CreateChartOverlayBar();
        }

    }
}