using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
namespace Example8_1_1
{
    /// <summary>
    /// Class that handles the properties of the charting area 
    /// </summary>
    /// 
    [Serializable]
    public class ChartStyle : ICloneable, ISerializable
    {
        #region Variables

        private Form1 form1;
        private float _mxMax = 5f;
        private float _mxMin = -5f;
        private float _myMax = 3f;
        private float _myMin = -3f;
        private float _mzMax = 6f;
        private float _mzMin = -6f;
        private float _mxTick = 1f;
        private float _myTick = 1f;
        private float _mzTick = 3f;
        private Font _mtickFont = new Font("Arial Narrow",8, FontStyle.Regular);
        private Color _mtickColor = Color.Black;
        private string _mtitle = "My 3D Chart";
        private Font _mtitleFont = new Font("Arial Narrow", 14, FontStyle.Regular);
        private Color _mtitleColor = Color.Black;
        private string _mxLabel = "X Axis";
        private string _myLabel = "Y Axis";
        private string _mzLabel = "Z Axis";
        private Font _mlabelFont = new Font("Arial Narrow", 10, FontStyle.Regular);
        private Color _mlabelColor = Color.Black;
        private float _melevation = 30;
        private float _mazimuth = -37.5f;
        private bool _misXGrid = true;
        private bool _misYGrid = true;
        private bool _misZGrid = true;
        LineStyle _mgridStyle;
        LineStyle _maxisStyle;
        private bool _misColorBar = false;
        #endregion

        #region Constructors

        public ChartStyle(Form1 fm1)
        {
            form1 = fm1;
            _mgridStyle = new LineStyle();
            _maxisStyle = new LineStyle();
        }
        /// <summary>
		/// Copy constructor
		/// </summary>
        public ChartStyle(ChartStyle rhs)
        {
            _mxMax = rhs._mxMax;
            _mxMin = rhs._mxMin;
            _myMax = rhs._myMax;
            _myMin = rhs._myMin;
            _mzMax = rhs._mzMax;
            _mzMin = rhs._mzMin;
            _mxTick = rhs._mxTick;
            _myTick = rhs._myTick;
            _mzTick = rhs._mzTick;
            _mtickFont = rhs._mtickFont;
            _mtickColor = rhs._mtickColor;
            _mtitle = rhs._mtitle;
            _mtitleFont = rhs._mtitleFont;
            _mtitleColor = rhs._mtitleColor;
            _mxLabel = rhs._mxLabel;
            _myLabel = rhs._myLabel;
            _mzLabel = rhs._mzLabel;
            _mlabelFont = rhs._mlabelFont;
            _mlabelColor = rhs._mlabelColor;
            _melevation = rhs._melevation;
            _mazimuth = rhs._mazimuth;
            _misXGrid = rhs._misXGrid;
            _misYGrid = rhs._misYGrid;
            _misZGrid = rhs._misZGrid;
            _mgridStyle = rhs._mgridStyle;
            _maxisStyle = rhs._maxisStyle;
            _misColorBar = rhs._misColorBar;
        }

        /// <summary>
        /// Implement the <see cref="ICloneable" /> interface in a typesafe manner by just
        /// calling the typed version of <see cref="Clone" />
        /// </summary>
        /// <returns>A deep copy of this object</returns>
        object ICloneable.Clone()
        {
            return new ChartStyle(this);
        }
        #endregion

        #region Properties

        public bool IsColorBar
        {
            get { return _misColorBar; }
            set { _misColorBar = value; }
        }

        public LineStyle AxisStyle
        {
            get { return _maxisStyle; }
            set { _maxisStyle = value; }
        }

        public LineStyle GridStyle
        {
            get { return _mgridStyle; }
            set { _mgridStyle = value; }
        }

        public Font LabelFont
        {
            get { return _mlabelFont; }
            set { _mlabelFont = value; }
        }

        public Color LabelColor
        {
            get { return _mlabelColor; }
            set { _mlabelColor = value; }
        }

        public Font TileFont
        {
            get { return _mtitleFont; }
            set { _mtitleFont = value; }
        }

        public Color TitleColor
        {
            get { return _mtitleColor; }
            set { _mtitleColor = value; }
        }

        public Font TickFont
        {
            get { return _mtickFont; }
            set { _mtickFont = value; }
        }

        public Color TickColor
        {
            get { return _mtickColor; }
            set { _mtickColor = value; }
        }

        public bool IsXGrid
        {
            get { return _misXGrid; }
            set { _misXGrid = value; }
        }

        public bool IsYGrid
        {
            get { return _misYGrid; }
            set { _misYGrid = value; }
        }

        public bool IsZGrid
        {
            get { return _misZGrid; }
            set { _misZGrid = value; }
        }

        public string Title
        {
            get { return _mtitle; }
            set { _mtitle = value; }
        }

        public string XLabel
        {
            get { return _mxLabel; }
            set { _mxLabel = value; }
        }

        public string YLabel
        {
            get { return _myLabel; }
            set { _myLabel = value; }
        }

        public string ZLabel
        {
            get { return _mzLabel; }
            set { _mzLabel = value; }
        }

        public float Elevation
        {
            get { return _melevation; }
            set { _melevation = value; }
        }

        public float Azimuth
        {
            get { return _mazimuth; }
            set { _mazimuth = value; }
        }

        public float XMax
        {
            get { return _mxMax; }
            set { _mxMax = value; }
        } 

        public float XMin
        {
            get { return _mxMin; }
            set { _mxMin = value; }
        }

        public float YMax
        {
            get { return _myMax; }
            set { _myMax = value; }
        }

        public float YMin
        {
            get { return _myMin; }
            set { _myMin = value; }
        }

        public float ZMax
        {
            get { return _mzMax; }
            set { _mzMax = value; }
        }

        public float ZMin
        {
            get { return _mzMin; }
            set { _mzMin = value; }
        }

        public float XTick
        {
            get { return _mxTick; }
            set { _mxTick = value; }
        }

        public float YTick
        {
            get { return _myTick; }
            set { _myTick = value; }
        }

        public float ZTick
        {
            get { return _mzTick; }
            set { _mzTick = value; }
        }
        #endregion

        #region Serialization

        /// <summary>
        /// Constructor for deserializing objects
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> instance that defines the serialized data
        /// </param>
        /// <param name="context">A <see cref="StreamingContext"/> instance that contains the serialized data
        /// </param>
        /// 
        protected ChartStyle(SerializationInfo info, StreamingContext context)
        {
            _mxMax = info.GetSingle("Xmax");
            _mxMin = info.GetSingle("XMin");
            _myMax = info.GetSingle("YMax");
            _myMin = info.GetSingle("YMin");
            _mzMax = info.GetSingle("ZMax");
            _mzMin = info.GetSingle("ZMin");
            _mxTick = info.GetSingle("XTick");
            _myTick = info.GetSingle("YTick");
            _mzTick = info.GetSingle("ZTick");
            _mtickFont = (Font)info.GetValue("TickFont", typeof(Font));
            _mtickColor = (Color)info.GetValue("TickColor", typeof(Color));
            _mtitle = info.GetString("Title");
            _mtitleFont = (Font)info.GetValue("TickFont", typeof(Font));
            _mtitleColor = (Color)info.GetValue("TickColor", typeof(Color));
            _mxLabel = info.GetString("XLabel");
            _myLabel = info.GetString("YLabel");
            _mzLabel = info.GetString("ZLabel");
            _mlabelFont = (Font)info.GetValue("LabelFont", typeof(Font));
            _mlabelColor = (Color)info.GetValue("LabelColor", typeof(Color));
            _melevation = info.GetSingle("Elevation");
            _mazimuth = info.GetSingle("Azimuth");
            _misXGrid = info.GetBoolean("isXGrid");
            _misYGrid = info.GetBoolean("isYGrid");
            _misZGrid = info.GetBoolean("isZGrid");
            _mgridStyle = (LineStyle)info.GetValue("gridStyle", typeof(LineStyle));
            _maxisStyle = (LineStyle)info.GetValue("axisStyle", typeof(LineStyle));
            _misColorBar = info.GetBoolean("isColorBar");
        }
        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> instance with the data needed to serialize the target object
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> instance that defines the serialized data</param>
        /// <param name="context">A <see cref="StreamingContext"/> instance that contains the serialized data</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Xmax", _mxMax);
            info.AddValue("XMin", _mxMin);
            info.AddValue("YMax", _myMax);
            info.AddValue("YMin", _myMin);
            info.AddValue("ZMax", _mzMax);
            info.AddValue("ZMin", _mzMin);
            info.AddValue("XTick", _mxTick);
            info.AddValue("YTick", _myTick);
            info.AddValue("ZTick", _mzTick);
            info.AddValue("TickFont", _mtickFont);
            info.AddValue("TickColor", _mtickColor);
            info.AddValue("Title", _mtitle);
            info.AddValue("TickFont", _mtitleFont);
            info.AddValue("TickColor", _mtitleColor);
            info.AddValue("XLabel", _mxLabel);
            info.AddValue("YLabel", _myLabel);
            info.AddValue("ZLabel", _mzLabel);
            info.AddValue("LabelFont", _mlabelFont);
            info.AddValue("LabelColor", _mlabelColor);
            info.AddValue("Elevation", _melevation);
            info.AddValue("Azimuth", _mazimuth);
            info.AddValue("isXGrid", _misXGrid);
            info.AddValue("isYGrid", _misYGrid);
            info.AddValue("isZGrid", _misZGrid);
            info.AddValue("gridStyle", _mgridStyle);
            info.AddValue("axisStyle", _maxisStyle);
            info.AddValue("isColorBar", _misColorBar);
        }
        #endregion

        #region Methods
        private Point3[] CoordinatesOfChartBox()
        {
            // Create coordinate of the axes:
            Point3[] pta = new Point3[8];
            pta[0] = new Point3(XMax, YMin, ZMin, 1);
            pta[1] = new Point3(XMin, YMin, ZMin, 1);
            pta[2] = new Point3(XMin, YMax, ZMin, 1);
            pta[3] = new Point3(XMin, YMax, ZMax, 1);
            pta[4] = new Point3(XMin, YMin, ZMax, 1);
            pta[5] = new Point3(XMax, YMin, ZMax, 1);
            pta[6] = new Point3(XMax, YMax, ZMax, 1);
            pta[7] = new Point3(XMax, YMax, ZMin, 1);

            Point3[] pts = new Point3[4];
            int[] npts = new int[4] { 0, 1, 2, 3 };
            if (_melevation >= 0)
            {
                if (_mazimuth >= -180 && _mazimuth < -90)
                {
                    npts = new int[4] { 1,2,7,6 };
                }
                else if (_mazimuth >= -90 && _mazimuth < 0)
                {
                    npts = new int[4] { 0, 1, 2, 3 };
                }
                else if (_mazimuth >= 0 && _mazimuth < 90)
                {
                    npts = new int[4] { 7, 0, 1, 4 };
                }
                else if (_mazimuth >= 90 && _mazimuth <= 180)
                {
                    npts = new int[4] { 2, 7, 0, 5 };
                }
            }
            else if (_melevation < 0)
            {
                if (_mazimuth >= -180 && _mazimuth < -90)
                {
                    npts = new int[4] { 1, 0, 7, 6 };
                }
                else if (_mazimuth >= -90 && _mazimuth < 0)
                {
                    npts = new int[4] { 0, 7, 2, 3 };
                }
                else if (_mazimuth >= 0 && _mazimuth < 90)
                {
                    npts = new int[4] { 7, 2, 1, 4 };
                }
                else if (_mazimuth >= 90 && _mazimuth <= 180)
                {
                    npts = new int[4] { 2, 1, 0, 5 };
                }

            }

            for (int i = 0; i < 4; i++)
            {
                pts[i] = pta[npts[i]];
            }
            return pts;
        }

        public void AddChartStyle(Graphics g)
        {
            AddTicks(g);
            AddGrids(g);
            AddAxes(g);
            AddLabels(g);
        }

        private void AddAxes(Graphics g)
        {
            Matrix3 m = Matrix3.AzimuthElevation(Elevation, Azimuth);
            Point3[] pts = CoordinatesOfChartBox();
            Pen aPen = new Pen(AxisStyle.LineColor, AxisStyle.Thickness);
            aPen.DashStyle = AxisStyle.Pattern;
            for (int i = 0; i < pts.Length; i++)
            {
                pts[i].Transform(m, form1, this);
            }
            g.DrawLine(aPen, pts[0].X, pts[0].Y, pts[1].X, pts[1].Y);
            g.DrawLine(aPen, pts[1].X, pts[1].Y, pts[2].X, pts[2].Y);
            g.DrawLine(aPen, pts[2].X, pts[2].Y, pts[3].X, pts[3].Y);
            aPen.Dispose();
        }

        private void AddTicks(Graphics g)
        {
            Matrix3 m = Matrix3.AzimuthElevation(Elevation, Azimuth);
            Point3[] pta = new Point3[2];
            Point3[] pts = CoordinatesOfChartBox();
            Pen aPen = new Pen(AxisStyle.LineColor, AxisStyle.Thickness);
            aPen.DashStyle = AxisStyle.Pattern;

            // Add x ticks:
            float offset = (YMax - YMin) / 30.0f;
            float ticklength = offset;
            for (float x = XMin; x <= XMax; x = x + XTick)
            {
                if (_melevation >= 0)
                {
                    if (_mazimuth >= -90 && _mazimuth < 90)
                        ticklength = -offset;
                }
                else if (_melevation < 0)
                {
                    if ((_mazimuth >= -180 && _mazimuth < -90) ||
                        _mazimuth >= 90 && _mazimuth <= 180)
                        ticklength = -(YMax - YMin) / 30;
                } 
                pta[0] = new Point3(x, pts[1].Y + ticklength, pts[1].Z, pts[1].W);
                pta[1] = new Point3(x, pts[1].Y, pts[1].Z, pts[1].W);
                for (int i = 0; i < pta.Length; i++)
                {
                    pta[i].Transform(m, form1, this);
                }
                g.DrawLine(aPen, pta[0].X, pta[0].Y, pta[1].X, pta[1].Y);
            }

            // Add y ticks:
            offset = (XMax - XMin) / 30.0f;
            ticklength = offset;
            for (float y = YMin; y <= YMax; y = y + YTick)
            {
                pts = CoordinatesOfChartBox();
                if (_melevation >= 0)
                {
                    if (_mazimuth >= -180 && _mazimuth < 0)
                        ticklength = -offset;
                }
                else if (_melevation < 0)
                {
                    if (_mazimuth >= 0 && _mazimuth < 180)
                        ticklength = -offset;
                }
                pta[0] = new Point3(pts[1].X + ticklength, y, pts[1].Z, pts[1].W);
                pta[1] = new Point3(pts[1].X, y, pts[1].Z, pts[1].W);
                for (int i = 0; i < pta.Length; i++)
                {
                    pta[i].Transform(m, form1, this);
                }
                g.DrawLine(aPen, pta[0].X, pta[0].Y, pta[1].X, pta[1].Y);
            }

            float xoffset = (XMax - XMin) / 45.0f;
            float yoffset = (YMax - YMin) / 20.0f;
            float xticklength = xoffset;
            float yticklength = yoffset;
            for (float z = ZMin; z <= ZMax; z = z + ZTick)
            {
                if (_melevation >= 0)
                {
                    if (_mazimuth >= -180 && _mazimuth < -90)
                    {
                        xticklength = 0;
                        yticklength = yoffset;
                    }
                    else if (_mazimuth >= -90 && _mazimuth < 0)
                    {
                        xticklength = xoffset;
                        yticklength = 0;
                    }
                    else if (_mazimuth >= 0 && _mazimuth < 90)
                    {
                        xticklength = 0;
                        yticklength = -yoffset;
                    }
                    else if (_mazimuth >= 90 && _mazimuth <= 180)
                    {
                        xticklength = -xoffset;
                        yticklength = 0;
                    }
                }
                else if (_melevation <0)
                {
                     if (_mazimuth >= -180 && _mazimuth < -90)
                    {
                        yticklength = 0;
                        xticklength = xoffset;
                    }
                    else if (_mazimuth >= -90 && _mazimuth < 0)
                    {
                        yticklength = -yoffset;
                        xticklength = 0;
                    }
                    else if (_mazimuth >= 0 && _mazimuth < 90)
                    {
                        yticklength = 0;
                        xticklength = -xoffset;
                    }
                    else if (_mazimuth >= 90 && _mazimuth <= 180)
                    {
                        yticklength = yoffset;
                        xticklength = 0;
                    }
                }
                pta[0] = new Point3(pts[2].X, pts[2].Y, z, pts[2].W);
                pta[1] = new Point3(pts[2].X + yticklength , 
                    pts[2].Y + xticklength, z, pts[2].W);
                for (int i = 0; i < pta.Length; i++)
                {
                    pta[i].Transform(m, form1, this);
                }
                g.DrawLine(aPen, pta[0].X, pta[0].Y, pta[1].X, pta[1].Y);
            }
            aPen.Dispose();
        }

        private void AddGrids(Graphics g)
        {
            Matrix3 m = Matrix3.AzimuthElevation(Elevation, Azimuth);
            Point3[] pta = new Point3[3];
            Point3[] pts = CoordinatesOfChartBox();
            Pen aPen = new Pen(GridStyle.LineColor, GridStyle.Thickness);
            aPen.DashStyle = GridStyle.Pattern;

            // Draw x gridlines:
            if (IsXGrid)
            {
                for (float x = XMin; x <= XMax; x = x + XTick)
                {
                    pts = CoordinatesOfChartBox();
                    pta[0] = new Point3(x, pts[1].Y, pts[1].Z, pts[1].W);
                    if (_melevation >= 0)
                    {
                        if ((_mazimuth >= -180 && _mazimuth < -90) ||
                            (_mazimuth >= 0 && _mazimuth < 90))
                        {
                            pta[1] = new Point3(x, pts[0].Y, pts[1].Z, pts[1].W);
                            pta[2] = new Point3(x, pts[0].Y, pts[3].Z, pts[1].W);
                        }
                        else
                        {
                            pta[1] = new Point3(x, pts[2].Y, pts[1].Z, pts[1].W);
                            pta[2] = new Point3(x, pts[2].Y, pts[3].Z, pts[1].W);

                        }
                    } 
                    else if (_melevation < 0)
                    {
                        if ((_mazimuth >= -180 && _mazimuth < -90) ||
                            (_mazimuth >= 0 && _mazimuth < 90))
                        {
                            pta[1] = new Point3(x, pts[2].Y, pts[1].Z, pts[1].W);
                            pta[2] = new Point3(x, pts[2].Y, pts[3].Z, pts[1].W);

                        }
                        else
                        {
                            pta[1] = new Point3(x, pts[0].Y, pts[1].Z, pts[1].W);
                            pta[2] = new Point3(x, pts[0].Y, pts[3].Z, pts[1].W);
                        }
                    }
                    for (int i = 0; i < pta.Length; i++)
                    {
                        pta[i].Transform(m, form1, this);
                    }
                    g.DrawLine(aPen, pta[0].X,pta[0].Y,pta[1].X,pta[1].Y);
                    g.DrawLine(aPen, pta[1].X,pta[1].Y,pta[2].X,pta[2].Y);
                }

                // Draw y gridlines:
                if (IsYGrid)
                {
                    for (float y = YMin; y <= YMax; y = y + YTick)
                    {
                        pts = CoordinatesOfChartBox();
                        pta[0] = new Point3(pts[1].X, y, pts[1].Z, pts[1].W);
                        if (_melevation >= 0)
                        {
                            if ((_mazimuth >= -180 && _mazimuth < -90) ||
                                (_mazimuth >= 0 && _mazimuth < 90))
                            {
                                pta[1] = new Point3(pts[2].X, y, pts[1].Z, pts[1].W);
                                pta[2] = new Point3(pts[2].X, y, pts[3].Z, pts[1].W);
                            }
                            else
                            {
                                pta[1] = new Point3(pts[0].X, y, pts[1].Z, pts[1].W);
                                pta[2] = new Point3(pts[0].X, y, pts[3].Z, pts[1].W);
                            }
                        }
                        if (_melevation < 0)
                        {
                            if ((_mazimuth >= -180 && _mazimuth < -90) ||
                                (_mazimuth >= 0 && _mazimuth < 90))
                            {
                                pta[1] = new Point3(pts[0].X, y, pts[1].Z, pts[1].W);
                                pta[2] = new Point3(pts[0].X, y, pts[3].Z, pts[1].W);

                            }
                            else
                            {
                                pta[1] = new Point3(pts[2].X, y, pts[1].Z, pts[1].W);
                                pta[2] = new Point3(pts[2].X, y, pts[3].Z, pts[1].W);
                            }
                        }
                        for (int i = 0; i < pta.Length; i++)
                        {
                            pta[i].Transform(m, form1, this);
                        }
                        g.DrawLine(aPen, pta[0].X, pta[0].Y, pta[1].X, pta[1].Y);
                        g.DrawLine(aPen, pta[1].X, pta[1].Y, pta[2].X, pta[2].Y);
                    }
                }

                // Draw Z gridlines:
                if (IsZGrid)
                {
                    for (float z = ZMin; z <= ZMax; z = z + ZTick)
                    {
                        pts = CoordinatesOfChartBox();
                        pta[0] = new Point3(pts[2].X, pts[2].Y, z, pts[2].W);
                        if (_melevation >= 0)
                        {
                            if ((_mazimuth >= -180 && _mazimuth < -90) ||
                                (_mazimuth >= 0 && _mazimuth < 90))
                            {
                                pta[1] = new Point3(pts[2].X, pts[0].Y, z, pts[1].W);
                                pta[2] = new Point3(pts[0].X, pts[0].Y, z, pts[1].W);
                            }
                            else
                            {
                                pta[1] = new Point3(pts[0].X, pts[2].Y, z, pts[1].W);
                                pta[2] = new Point3(pts[0].X, pts[1].Y, z, pts[1].W);
                            }
                        }
                        if (_melevation < 0)
                        {
                            if ((_mazimuth >= -180 && _mazimuth < -90) ||
                                (_mazimuth >= 0 && _mazimuth < 90))
                            {
                                pta[1] = new Point3(pts[0].X, pts[2].Y, z, pts[1].W);
                                pta[2] = new Point3(pts[0].X, pts[0].Y, z, pts[1].W);

                            }
                            else
                            {
                                pta[1] = new Point3(pts[2].X, pts[0].Y, z, pts[1].W);
                                pta[2] = new Point3(pts[0].X, pts[0].Y, z, pts[1].W);
                            }
                        }
                        for (int i = 0; i < pta.Length; i++)
                        {
                            pta[i].Transform(m, form1, this);
                        }
                        g.DrawLine(aPen, pta[0].X, pta[0].Y, pta[1].X, pta[1].Y);
                        g.DrawLine(aPen, pta[1].X, pta[1].Y, pta[2].X, pta[2].Y);
                    }
                }
            }
        }

        private void AddLabels(Graphics g)
        {
            Matrix3 m = Matrix3.AzimuthElevation(Elevation, Azimuth);
            Point3 pt = new Point3();
            Point3[] pts = CoordinatesOfChartBox();
            SolidBrush aBrush = new SolidBrush(LabelColor);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            // Add x tick labels:
            float offset = (YMax - YMin) / 20;
            float labelSpace = offset;
            for (float x = XMin + XTick; x < XMax; x = x + XTick)
            {
                if (_melevation >= 0)
                {
                    if (_mazimuth >= -90 && _mazimuth < 90)
                        labelSpace = -offset;
                }
                else if (_melevation < 0)
                {
                    if ((_mazimuth >= -180 && _mazimuth < -90) ||
                        _mazimuth >= 90 && _mazimuth <= 180)
                        labelSpace = -offset;
                }
                pt = new Point3(x, pts[1].Y + labelSpace, pts[1].Z, pts[1].W);
                pt.Transform(m, form1, this);
                g.DrawString(x.ToString(), TickFont, aBrush,
                    new PointF(pt.X, pt.Y), sf);
            }

            // Add y tick labels:
            offset = (XMax - XMin) / 20;
            labelSpace = offset;
            for (float y = YMin + _myTick; y < YMax; y = y + YTick)
            {
                pts = CoordinatesOfChartBox();
                if (_melevation >= 0)
                {
                    if (_mazimuth >= -180 && _mazimuth < 0)
                        labelSpace = -offset;
                }
                else if (_melevation < 0)
                {
                    if (_mazimuth >= 0 && _mazimuth < 180)
                        labelSpace = -offset;
                }
                pt = new Point3(pts[1].X + labelSpace, y, pts[1].Z, pts[1].W);
                pt.Transform(m, form1, this);
                g.DrawString(y.ToString(), TickFont, aBrush,
                    new PointF(pt.X, pt.Y), sf);

            }

            // Add z tick labels:
            float xoffset = (XMax - XMin) / 30.0f;
            float yoffset = (YMax - YMin) / 15.0f;
            float xlabelSpace = xoffset;
            float ylabelSpace = yoffset;
            SizeF s = g.MeasureString("A", TickFont);
            for (float z = ZMin; z <= ZMax; z = z + ZTick)
            {
                sf.Alignment = StringAlignment.Far;
                pts = CoordinatesOfChartBox();
                if (_melevation >= 0)
                {
                    if (_mazimuth >= -180 && _mazimuth < -90)
                    {
                        xlabelSpace = 0;
                        ylabelSpace = yoffset;
                    }
                    else if (_mazimuth >= -90 && _mazimuth < 0)
                    {
                        xlabelSpace = xoffset;
                        ylabelSpace = 0;
                    }
                    else if (_mazimuth >= 0 && _mazimuth < 90)
                    {
                        xlabelSpace = 0;
                        ylabelSpace = -yoffset;
                    }
                    else if (_mazimuth >= 90 && _mazimuth <= 180)
                    {
                        xlabelSpace = -xoffset;
                        ylabelSpace = 0;
                    }
                }
                else if (_melevation < 0)
                {
                    if (_mazimuth >= -180 && _mazimuth < -90)
                    {
                        ylabelSpace = 0;
                        xlabelSpace = xoffset;
                    }
                    else if (_mazimuth >= -90 && _mazimuth < 0)
                    {
                        ylabelSpace = -yoffset;
                        xlabelSpace = 0;
                    }
                    else if (_mazimuth >= 0 && _mazimuth < 90)
                    {
                        ylabelSpace = 0;
                        xlabelSpace = -xoffset;
                    }
                    else if (_mazimuth >= 90 && _mazimuth <= 180)
                    {
                        ylabelSpace = yoffset;
                        xlabelSpace = 0;
                    }
                }

                pt = new Point3(pts[2].X + ylabelSpace,
                    pts[2].Y + xlabelSpace, z, pts[2].W);
                pt.Transform(m, form1, this);
                g.DrawString(z.ToString(), TickFont, aBrush,
                    new PointF(pt.X - labelSpace, pt.Y - s.Height / 2), sf);
            }

            // Add Title:
            sf.Alignment = StringAlignment.Center;
            aBrush = new SolidBrush(TitleColor);
            g.DrawString(Title, _mtitleFont, aBrush,
                new PointF(form1.PlotPanel.Width / 2, form1.Height / 30), sf);
            aBrush.Dispose();

            // Add x axis label:
            offset = (YMax - YMin) / 3;
            labelSpace = offset;
            sf.Alignment = StringAlignment.Center;
            aBrush = new SolidBrush(LabelColor);
            float offset1 = (XMax - XMin) / 10;
            float xc = offset1;
            if (_melevation >= 0)
            {
                if (_mazimuth >= -90 && _mazimuth < 90)
                    labelSpace = -offset;
                if (_mazimuth >= 0 && _mazimuth <= 180)
                    xc = -offset1;
            }
            else if (_melevation < 0)
            {
                if ((_mazimuth >= -180 && _mazimuth < -90) ||
                    _mazimuth >= 90 && _mazimuth <= 180)
                    labelSpace = -offset;
                if (Azimuth >= -180 && _mazimuth <= 0)
                    xc = -offset1;
            }
            Point3[] pta = new Point3[2];
            pta[0] = new Point3(XMin, pts[1].Y + labelSpace, pts[1].Z, pts[1].W);
            pta[1] = new Point3((XMin + XMax) / 2 - xc, pts[1].Y + labelSpace,
                pts[1].Z, pts[1].W);
            pta[0].Transform(m, form1, this);
            pta[1].Transform(m, form1, this);
            float theta = (float)Math.Atan((pta[1].Y - pta[0].Y) / (pta[1].X - pta[0].X));
            theta = theta * 180 / (float)Math.PI;
            GraphicsState gs = g.Save();
            g.TranslateTransform(pta[1].X, pta[1].Y);
            g.RotateTransform(theta);
            g.DrawString(XLabel, LabelFont, aBrush,
                new PointF(0, 0), sf);
            g.Restore(gs);

            // Add y axis label:
            offset = (XMax - XMin) / 3;
            offset1 = (YMax - YMin) / 5;
            labelSpace = offset;
            float yc = YTick;
            if (_melevation >= 0)
            {
                if (_mazimuth >= -180 && _mazimuth < 0)
                    labelSpace = -offset;
                if (_mazimuth >= -90 && _mazimuth <= 90)
                    yc = -offset1;
            }
            else if (_melevation < 0)
            {
                yc = -offset1;
                if (_mazimuth >= 0 && _mazimuth < 180)
                    labelSpace = -offset;
                if (_mazimuth >= -90 && _mazimuth <= 90)
                    yc = offset1;
            }
            pta[0] = new Point3(pts[1].X + labelSpace, YMin, pts[1].Z, pts[1].W);
            pta[1] = new Point3(pts[1].X + labelSpace, (YMin + YMax)/2 + yc, pts[1].Z, pts[1].W);
            pta[0].Transform(m, form1, this);
            pta[1].Transform(m, form1, this);
            theta = (float)Math.Atan((pta[1].Y - pta[0].Y) / (pta[1].X - pta[0].X));
            theta = theta * 180 / (float)Math.PI;
            gs = g.Save();
            g.TranslateTransform(pta[1].X, pta[1].Y);
            g.RotateTransform(theta);
            g.DrawString(YLabel, LabelFont, aBrush,
                new PointF(0, 0), sf);
            g.Restore(gs);

            // Add z axis labels:
            float zticklength = 10;
            labelSpace = -1.3f * offset;
            offset1 = (ZMax - ZMin) / 8;
            float zc = -offset1;
            for (float z = ZMin; z < ZMax; z = z + ZTick)
            {
                SizeF size = g.MeasureString(z.ToString(), TickFont);
                if (zticklength < size.Width)
                    zticklength = size.Width;
            }
            float zlength = -zticklength;
            if (_melevation >= 0)
            {
                if (_mazimuth >= -180 && _mazimuth < -90)
                {
                    zlength = -zticklength;
                    labelSpace = -1.3f * offset;
                    zc = -offset1;
                }
                else if (_mazimuth >= -90 && _mazimuth < 0)
                {
                    zlength = zticklength;
                    labelSpace = 2 * offset / 3;
                    zc = offset1;
                }
                else if (_mazimuth >= 0 && _mazimuth < 90)
                {
                    zlength = zticklength;
                    labelSpace = 2 * offset / 3;
                    zc = -offset1;
                }
                else if (_mazimuth >= 90 && _mazimuth <= 180)
                {
                    zlength = -zticklength;
                    labelSpace = -1.3f * offset;
                    zc = offset1;
                }
            }
            else if (_melevation < 0)
            {
                if (_mazimuth >= -180 && _mazimuth < -90)
                {
                    zlength = -zticklength;
                    labelSpace = -1.3f * offset;
                    zc = offset1;
                }
                else if (_mazimuth >= -90 && _mazimuth < 0)
                {
                    zlength = zticklength;
                    labelSpace = 2 * offset / 3;
                    zc = -offset1;
                }
                else if (_mazimuth >= 0 && _mazimuth < 90)
                {
                    zlength = zticklength;
                    labelSpace = 2 * offset / 3;
                    zc = offset1;
                }
                else if (_mazimuth >= 90 && _mazimuth <= 180)
                {
                    zlength = -zticklength;
                    labelSpace = -1.3f * offset;
                    zc = -offset1;
                }
            }

            pta[0] = new Point3(pts[2].X - labelSpace, pts[2].Y,
                (ZMin + ZMax) / 2 + zc, pts[2].W);
            pta[0].Transform(m, form1, this);
            gs = g.Save();
            g.TranslateTransform(pta[0].X - zlength, pta[0].Y);
            g.RotateTransform(270);
            g.DrawString(ZLabel, LabelFont, aBrush,
                new PointF(0, 0), sf);
            g.Restore(gs);
        }
        #endregion
    }
}