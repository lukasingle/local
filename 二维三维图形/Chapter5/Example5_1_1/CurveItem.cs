using System;
using System.Drawing;
using System.Collections;
using System.Runtime.Serialization;
using System.Security.Permissions;

using System.Collections.Generic;

namespace Example5_1_1
{
	
	/// <summary>
	/// This class contains the data and methods for an individual curve within
	/// a graph pane.  It carries the settings for the curve including the
	/// key and item names, colors, symbols and sizes, linetypes, etc.
	/// </summary>
	/// 
    [Serializable]
    abstract public class CurveItem : ISerializable, ICloneable
    {

        #region Variables

        /// <summary>
        /// protected field that stores a <see cref="Label" /> instance for this
        /// <see cref="CurveItem"/>, which is used for the <see cref="Legend" />
        /// label.  Use the public
        /// property <see cref="Label"/> to access this value.
        /// </summary>
        internal Label _label;
      
        /// <summary>
        /// protected field that stores the index number of the Y Axis to which this
        /// <see cref="CurveItem" /> belongs.  Use the public property <see cref="YAxisIndex" />
        /// to access this value.
        /// </summary>
        protected int _yAxisIndex;

        /// <summary>
        /// protected field that stores the boolean value that determines whether this
        /// <see cref="CurveItem"/> is visible on the graph.
        /// Use the public property <see cref="IsVisible"/> to access this value.
        /// Note that this value turns the curve display on or off, but it does not
        /// affect the display of the legend entry.  To hide the legend entry, you
        /// have to set <see cref="Label.IsVisible"/> to false.
        /// </summary>
        protected bool _isVisible;

        /// <summary>
        /// A tag object for use by the user.  This can be used to store additional
        /// information associated with the <see cref="CurveItem"/>.  Example does
        /// not use this value for any purpose.
        /// </summary>
        /// <remarks>
        /// Note that, if you are going to Serialize Example data, then any type
        /// that you store in <see cref="Tag"/> must be a serializable type (or
        /// it will cause an exception).
        /// </remarks>
        public object Tag;


        #endregion

        #region Constructors
        
        /// <summary>
        /// Internal initialization routine thats sets some initial values to defaults.
        /// </summary>
        /// <param name="label">A string label (legend entry) for this curve</param>
        private void Init(string label)
        {
            _label = new Label(label, null);
            _isVisible = true;
            this.Tag = null;
            _yAxisIndex = 0;
        }
       
        /// <summary>
        /// 
        /// </summary>
        public CurveItem()
        {
            Init(null);
        }
        /// <summary>
        /// The Copy Constructor
        /// </summary>
        /// <param name="rhs">The CurveItem object from which to copy</param>
        public CurveItem(CurveItem rhs)
        {
            _label = rhs._label.Clone();
            _isVisible = rhs.IsVisible;
            _yAxisIndex = rhs._yAxisIndex;

            if (rhs.Tag is ICloneable)
                this.Tag = ((ICloneable)rhs.Tag).Clone();
            else
                this.Tag = rhs.Tag;
        }

        /// <summary>
        /// Implement the <see cref="ICloneable" /> interface in a typesafe manner by just
        /// calling the typed version of Clone.
        /// </summary>
        /// <remarks>
        /// Note that this method must be called with an explicit cast to ICloneable, and
        /// that it is inherently virtual.  For example:
        /// <code>
        /// ParentClass foo = new ChildClass();
        /// ChildClass bar = (ChildClass) ((ICloneable)foo).Clone();
        /// </code>
        /// Assume that ChildClass is inherited from ParentClass.  Even though foo is declared with
        /// ParentClass, it is actually an instance of ChildClass.  Calling the ICloneable implementation
        /// of Clone() on foo actually calls ChildClass.Clone() as if it were a virtual function.
        /// </remarks>
        /// <returns>A deep copy of this object</returns>
        object ICloneable.Clone()
        {
            throw new NotImplementedException("Can't clone an abstract base type -- child types must implement ICloneable");
        }

        #endregion

        #region Serialization
        /// <summary>
        /// Current schema value that defines the version of the serialized file
        /// </summary>
        public const int schema = 11;

        /// <summary>
        /// Constructor for deserializing objects
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> instance that defines the serialized data
        /// </param>
        /// <param name="context">A <see cref="StreamingContext"/> instance that contains the serialized data
        /// </param>
        protected CurveItem(SerializationInfo info, StreamingContext context)
        {
            // The schema value is just a file version parameter.  You can use it to make future versions
            // backwards compatible as new member variables are added to classes
            int sch = info.GetInt32("schema");

            _label = (Label)info.GetValue("label", typeof(Label));
            

            _isVisible = info.GetBoolean("isVisible");

           

            Tag = info.GetValue("Tag", typeof(object));

            _yAxisIndex = info.GetInt32("yAxisIndex");


        }
        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> instance with the data needed to serialize the target object
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> instance that defines the serialized data</param>
        /// <param name="context">A <see cref="StreamingContext"/> instance that contains the serialized data</param>
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", schema);
            info.AddValue("label", _label);
            info.AddValue("isVisible", _isVisible);

            info.AddValue("Tag", Tag);
            info.AddValue("yAxisIndex", _yAxisIndex);

        }
        #endregion

        #region Properties
        /// <summary>
        /// A <see cref="Label" /> instance that represents the <see cref="Legend"/>
        /// entry for the this <see cref="CurveItem"/> object
        /// </summary>
        public Label Label
        {
            get { return _label; }
            set { _label = value; }
        }


        /// <summary>
        /// Determines whether this <see cref="CurveItem"/> is visible on the graph.
        /// Note that this value turns the curve display on or off, but it does not
        /// affect the display of the legend entry.  To hide the legend entry, you
        /// have to set <see cref="Label.IsVisible"/> to false.
        /// </summary>
        public bool IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; }
        }

       
 

        /// <summary>
        /// Gets or sets the index number of the Y Axis to which this
        /// <see cref="CurveItem" /> belongs.
        /// </summary>
        /// <remarks>
        /// This value is essentially an index number into the <see cref="GraphPane.YAxisList" />
        /// or <see cref="GraphPane.Y2AxisList" />, depending on the setting of
        /// <see cref="IsY2Axis" />.
        /// </remarks>
        public int YAxisIndex
        {
            get { return _yAxisIndex; }
            set { _yAxisIndex = value; }
        }

        /// <summary>
        /// Gets a flag indicating if the Z data range should be included in the axis scaling calculations.
        /// </summary>
        /// <param name="pane">The parent <see cref="GraphPane" /> of this <see cref="CurveItem" />.
        /// </param>
        /// <value>true if the Z data are included, false otherwise</value>
        abstract internal bool IsZIncluded(GraphPane pane);

        /// <summary>
        /// Gets a flag indicating if the X axis is the independent axis for this <see cref="CurveItem" />
        /// </summary>
        /// <param name="pane">The parent <see cref="GraphPane" /> of this <see cref="CurveItem" />.
        /// </param>
        /// <value>true if the X axis is independent, false otherwise</value>
        abstract internal bool IsXIndependent(GraphPane pane);

        #endregion

        #region Rendering Methods
        /// <summary>
        /// Do all rendering associated with this <see cref="CurveItem"/> to the specified
        /// <see cref="Graphics"/> device.  This method is normally only
        /// called by the Draw method of the parent <see cref="CurveList"/>
        /// collection object.
        /// </summary>
        /// <param name="g">
        /// A graphic device object to be drawn into.  This is normally e.Graphics from the
        /// PaintEventArgs argument to the Paint() method.
        /// </param>
        /// <param name="pane">
        /// A reference to the <see cref="GraphPane"/> object that is the parent or
        /// owner of this object.
        /// </param>
        /// <param name="pos">The ordinal position of the current <see cref="Bar"/>
        /// curve.</param>
        /// <param name="scaleFactor">
        /// The scaling factor to be used for rendering objects.  This is calculated and
        /// passed down by the parent <see cref="GraphPane"/> object using the
        /// <see cref="PaneBase.CalcScaleFactor"/> method, and is used to proportionally adjust
        /// font sizes, etc. according to the actual size of the graph.
        /// </param>
        abstract public void Draw(Graphics g, GraphPane pane, int pos, float scaleFactor);

        /// <summary>
        /// Draw a legend key entry for this <see cref="CurveItem"/> at the specified location.
        /// This abstract base method passes through to <see cref="BarItem.DrawLegendKey"/> or
        /// <see cref="LineItem.DrawLegendKey"/> to do the rendering.
        /// </summary>
        /// <param name="g">
        /// A graphic device object to be drawn into.  This is normally e.Graphics from the
        /// PaintEventArgs argument to the Paint() method.
        /// </param>
        /// <param name="pane">
        /// A reference to the <see cref="GraphPane"/> object that is the parent or
        /// owner of this object.
        /// </param>
        /// <param name="rect">The <see cref="RectangleF"/> struct that specifies the
        /// location for the legend key</param>
        /// <param name="scaleFactor">
        /// The scaling factor to be used for rendering objects.  This is calculated and
        /// passed down by the parent <see cref="GraphPane"/> object using the
        /// <see cref="PaneBase.CalcScaleFactor"/> method, and is used to proportionally adjust
        /// font sizes, etc. according to the actual size of the graph.
        /// </param>
        abstract public void DrawLegendKey(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor);

        #endregion

        #region Utility Methods

        /// <summary>
        /// Get the X Axis instance (either <see cref="XAxis" /> or <see cref="X2Axis" />) to
        /// which this <see cref="CurveItem" /> belongs.
        /// </summary>
        /// <param name="pane">The <see cref="GraphPane" /> object to which this curve belongs.</param>
        /// <returns>Either a <see cref="XAxis" /> or <see cref="X2Axis" /> to which this
        /// <see cref="CurveItem" /> belongs.
        /// </returns>
        public Axis GetXAxis(GraphPane pane)
        {
                return pane.XAxis;
        }

        /// <summary>
        /// Get the Y Axis instance (either <see cref="YAxis" /> or <see cref="Y2Axis" />) to
        /// which this <see cref="CurveItem" /> belongs.
        /// </summary>
        /// <remarks>
        /// This method safely retrieves a Y Axis instance from either the <see cref="GraphPane.YAxisList" />
        /// or the <see cref="GraphPane.Y2AxisList" /> using the values of <see cref="YAxisIndex" /> and
        /// <see cref="IsY2Axis" />.  If the value of <see cref="YAxisIndex" /> is out of bounds, the
        /// default <see cref="YAxis" /> or <see cref="Y2Axis" /> is used.
        /// </remarks>
        /// <param name="pane">The <see cref="GraphPane" /> object to which this curve belongs.</param>
        /// <returns>Either a <see cref="YAxis" /> or <see cref="Y2Axis" /> to which this
        /// <see cref="CurveItem" /> belongs.
        /// </returns>
        public Axis GetYAxis(GraphPane pane)
        {
               if (_yAxisIndex < pane.YAxisList.Count)
                    return pane.YAxisList[_yAxisIndex];
                else
                    return pane.YAxisList[0];
        }

        /// <summary>
        /// Get the index of the Y Axis in the <see cref="YAxis" /> or <see cref="Y2Axis" /> list to
        /// which this <see cref="CurveItem" /> belongs.
        /// </summary>
        /// <remarks>
        /// This method safely retrieves a Y Axis index into either the <see cref="GraphPane.YAxisList" />
        /// or the <see cref="GraphPane.Y2AxisList" /> using the values of <see cref="YAxisIndex" /> and
        /// <see cref="IsY2Axis" />.  If the value of <see cref="YAxisIndex" /> is out of bounds, the
        /// default <see cref="YAxis" /> or <see cref="Y2Axis" /> is used, which is index zero.
        /// </remarks>
        /// <param name="pane">The <see cref="GraphPane" /> object to which this curve belongs.</param>
        /// <returns>An integer value indicating which index position in the list applies to this
        /// <see cref="CurveItem" />
        /// </returns>
        public int GetYAxisIndex(GraphPane pane)
        {
            if (_yAxisIndex >= 0 )
                return _yAxisIndex;
            else
                return 0;
        }
    
        /// <summary>
        /// Go through the list of <see cref="PointPair"/> data values for this <see cref="CurveItem"/>
        /// and determine the minimum and maximum values in the data.
        /// </summary>
        /// <param name="xMin">The minimum X value in the range of data</param>
        /// <param name="xMax">The maximum X value in the range of data</param>
        /// <param name="yMin">The minimum Y value in the range of data</param>
        /// <param name="yMax">The maximum Y value in the range of data</param>
        /// <param name="ignoreInitial">ignoreInitial is a boolean value that
        /// affects the data range that is considered for the automatic scale
        /// ranging (see <see cref="GraphPane.IsIgnoreInitial"/>).  If true, then initial
        /// data points where the Y value is zero are not included when
        /// automatically determining the scale <see cref="Scale.Min"/>,
        /// <see cref="Scale.Max"/>, and <see cref="Scale.MajorStep"/> size.  All data after
        /// the first non-zero Y value are included.
        /// </param>
        /// <param name="isBoundedRanges">
        /// Determines if the auto-scaled axis ranges will subset the
        /// data points based on any manually set scale range values.
        /// </param>
        /// <param name="pane">
        /// A reference to the <see cref="GraphPane"/> object that is the parent or
        /// owner of this object.
        /// </param>
        /// <seealso cref="GraphPane.IsBoundedRanges"/>
        virtual public void GetRange(out double xMin, out double xMax,
                                        out double yMin, out double yMax,
                                        bool ignoreInitial,
                                        bool isBoundedRanges,
                                        GraphPane pane)
        {
            // The lower and upper bounds of allowable data for the X values.  These
            // values allow you to subset the data values.  If the X range is bounded, then
            // the resulting range for Y will reflect the Y values for the points within the X
            // bounds.
            double xLBound = double.MinValue;
            double xUBound = double.MaxValue;
            double yLBound = double.MinValue;
            double yUBound = double.MaxValue;

            // initialize the values to outrageous ones to start
            xMin = yMin = Double.MaxValue;
            xMax = yMax = Double.MinValue;

            Axis yAxis = this.GetYAxis(pane);
            Axis xAxis = this.GetXAxis(pane);
            if (yAxis == null || xAxis == null)
                return;

            if (isBoundedRanges)
            {
                xLBound = xAxis._scale._lBound;
                xUBound = xAxis._scale._uBound;
                yLBound = yAxis._scale._lBound;
                yUBound = yAxis._scale._uBound;
            }

        }

        /// <summary>Returns a reference to the <see cref="Axis"/> object that is the "base"
        /// (independent axis) from which the values are drawn. </summary>
        /// <remarks>
        /// This property is determined by the value of <see cref="BarSettings.Base"/> for
        /// <see cref="BarItem"/>, <see cref="ErrorBarItem"/>, and <see cref="HiLowBarItem"/>
        /// types.  It is always the X axis for regular <see cref="LineItem"/> types.
        /// Note that the <see cref="BarSettings.Base" /> setting can override the
        /// <see cref="IsY2Axis" /> and <see cref="YAxisIndex" /> settings for bar types
        /// (this is because all the bars that are clustered together must share the
        /// same base axis).
        /// </remarks>
        /// <seealso cref="BarBase"/>
        /// <seealso cref="ValueAxis"/>
        public virtual Axis BaseAxis(GraphPane pane)
        {
            return pane.YAxis;

        }
        /// <summary>Returns a reference to the <see cref="Axis"/> object that is the "value"
        /// (dependent axis) from which the points are drawn. </summary>
        /// <remarks>
        /// This property is determined by the value of <see cref="BarSettings.Base"/> for
        /// <see cref="BarItem"/>, <see cref="ErrorBarItem"/>, and <see cref="HiLowBarItem"/>
        /// types.  It is always the Y axis for regular <see cref="LineItem"/> types.
        /// </remarks>
        /// <seealso cref="BarBase"/>
        /// <seealso cref="BaseAxis"/>
        public virtual Axis ValueAxis(GraphPane pane)
        {
               return GetXAxis(pane);
        }

        /// <summary>
        /// Determine the coords for the rectangle associated with a specified point for 
        /// this <see cref="CurveItem" />
        /// </summary>
        /// <param name="pane">The <see cref="GraphPane" /> to which this curve belongs</param>
        /// <param name="i">The index of the point of interest</param>
        /// <param name="coords">A list of coordinates that represents the "rect" for
        /// this point (used in an html AREA tag)</param>
        /// <returns>true if it's a valid point, false otherwise</returns>
        abstract public bool GetCoords(GraphPane pane, int i, out string coords);

        #endregion
        

    }
}



