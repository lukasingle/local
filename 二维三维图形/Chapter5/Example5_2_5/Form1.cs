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

namespace Example5_2_5
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
        public void CreateChartSub()
        {
            MasterPane myMaster = this.MasterPane;

            myMaster.PaneList.Clear();

            // Set the master pane title
            myMaster.Title.Text = "MasterPane Test";
            myMaster.Title.IsVisible = true;

            // Fill the pane background with a color gradient
            myMaster.Fill = new Fill(Color.White, Color.MediumSlateBlue, 45.0F);

            // Set the margins and the space between panes to 10 points
            myMaster.Margin.All = 10;
            myMaster.InnerPaneGap = 10;

            // Enable the master pane legend
            myMaster.Legend.IsVisible = true;
            myMaster.Legend.Position = LegendPos.TopCenter;

            // Add a confidential stamp
            TextObj text = new TextObj("Confidential", 0.80F, 0.12F);
            text.Location.CoordinateFrame = CoordType.PaneFraction;
            // angle the text at 15 degrees
            text.FontSpec.Angle = 15.0F;
            text.FontSpec.FontColor = Color.Red;
            text.FontSpec.IsBold = true;
            text.FontSpec.Size = 16;
            text.FontSpec.Border.IsVisible = false;
            text.FontSpec.Border.Color = Color.Red;
            text.FontSpec.Fill.IsVisible = false;
            text.Location.AlignH = AlignH.Left;
            text.Location.AlignV = AlignV.Bottom;
            myMaster.GraphObjList.Add(text);

            // Add a draft watermark
            text = new TextObj("DRAFT", 0.5F, 0.5F);
            text.Location.CoordinateFrame = CoordType.PaneFraction;
            // tilt the text at 30 degrees
            text.FontSpec.Angle = 30.0F;
            // Use the alpha value (70) to make the text semi-transparent (a watermark)
            text.FontSpec.FontColor = Color.FromArgb(70, 255, 100, 100);
            text.FontSpec.IsBold = true;
            text.FontSpec.Size = 100;
            text.FontSpec.Border.IsVisible = false;
            text.FontSpec.Fill.IsVisible = false;
            text.Location.AlignH = AlignH.Center;
            text.Location.AlignV = AlignV.Center;
            text.ZOrder = ZOrder.A_InFront;
            myMaster.GraphObjList.Add(text);

            for (int j = 0; j < 6; j++)
            {
                // Create a new GraphPane
                GraphPane myPane = new GraphPane();
                myPane.Title.Text = "My Test Graph #" + (j + 1).ToString();
                myPane.XAxis.Title.Text = "X Axis";
                myPane.YAxis.Title.Text = "Y Axis";

                // Fill the pane background with a color gradient
                myPane.Fill = new Fill(Color.White, Color.LightYellow, 45.0F);
                // Reduce the base dimension to 6 inches, since these panes tend to be smaller
                myPane.BaseDimension = 6.0F;

                // Make up some data arrays based on the Sine function
                PointPairList list = new PointPairList();
                for (int i = 0; i < 36; i++)
                {
                    double x = (double)i + 5;
                    double y = 3.0 * (1.5 + Math.Sin((double)i * 0.2 + (double)j));
                    list.Add(x, y);
                }

                // Generate a red curve with diamond symbols
                LineItem myCurve = myPane.AddCurve("label" + j.ToString(),
                   list, Color.Red, SymbolType.Diamond);

                // Add the new GraphPane to the MasterPane
                myMaster.Add(myPane);
            }

            // Tell Example to auto layout all the panes
            using (Graphics g = CreateGraphics())
            {
                myMaster.SetLayout(g, PaneLayout.SquareColPreferred);
                this.AxisChange();
            }
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
            //Draw base sin curve
            this.CreateChartSub();
        }

    }
}