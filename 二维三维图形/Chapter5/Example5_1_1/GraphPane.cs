using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.ComponentModel;

namespace Example5_1_1
{
	
	/// <summary>
	/// Class <see cref="GraphPane"/> encapsulates the graph pane, which is all display elements
	/// associated with an individual graph.
	/// </summary>
	/// 
	[Serializable]
	public class GraphPane : PaneBase, ICloneable, ISerializable
	{

	#region Events

		/// <summary>
		/// A delegate to provide notification through the <see cref="AxisChangeEvent" />
		/// when <see cref="AxisChange()" /> is called.
		/// </summary>
		/// <param name="pane">The <see cref="GraphPane" /> for which AxisChange() has
		/// been called.</param>
		/// <seealso cref="AxisChangeEvent" />
		public delegate void AxisChangeEventHandler( GraphPane pane );

		/// <summary>
		/// Subscribe to this event to be notified when <see cref="AxisChange()" /> is called.
		/// </summary>
		public event AxisChangeEventHandler AxisChangeEvent;

	#endregion

	#region Private Fields

		// Item subclasses ////////////////////////////////////////////////////////////////////

		/// <summary>Private field instance of the <see cref="XAxis"/> class.  Use the
		/// public property <see cref="GraphPane.XAxis"/> to access this class.</summary>
		private XAxis _xAxis;
		/// <summary>Private field instance of the <see cref="YAxisList"/> class.  Use the
		/// public property <see cref="GraphPane.YAxisList"/> to access this class.</summary>
		private YAxisList _yAxisList;
		/// <summary>Private field instance of the <see cref="CurveList"/> class.  Use the
		/// public property <see cref="GraphPane.CurveList"/> to access this class.</summary>
		private CurveList _curveList;
	
		// Chart Properties //////////////////////////////////////////////////////////////

		internal Chart _chart;

      	/// <summary>Private field that determines whether or not initial zero values will
		/// be included or excluded when determining the Y or Y2 axis scale range.
		/// Use the public property <see cref="IsIgnoreInitial"/> to access
		/// this value. </summary>
		private bool _isIgnoreInitial;
		/// <summary>Private field that determines whether or not initial
		/// <see cref="PointPairBase.Missing"/> values will cause the line segments of
		/// a curve to be discontinuous.  If this field is true, then the curves
		/// will be plotted as continuous lines as if the Missing values did not
		/// exist.
		/// Use the public property <see cref="IsIgnoreMissing"/> to access
		/// this value. </summary>
		private bool _isIgnoreMissing;
		/// <summary> private field that determines if the auto-scaled axis ranges will subset the
		/// data points based on any manually set scale range values.  Use the public property
		/// <see cref="IsBoundedRanges"/> to access this value.</summary>
		/// <remarks>The bounds provide a means to subset the data.  For example, if all the axes are set to
		/// autoscale, then the full range of data are used.  But, if the XAxis.Min and XAxis.Max values
		/// are manually set, then the Y data range will reflect the Y values within the bounds of
		/// XAxis.Min and XAxis.Max.</remarks>
		private bool _isBoundedRanges;

		/// <summary>
		/// private field that determines if Example should modify the scale ranges for the Y and Y2
		/// axes such that the number of steps, and therefore the grid lines, line up.  Use the
		/// public property <see cref="IsAlignGrids" /> to acccess this value.
		/// </summary>
		private bool _isAlignGrids;

	#endregion

	#region Defaults

		/// <summary>
		/// A simple struct that defines the
		/// default property values for the <see cref="GraphPane"/> class.
		/// </summary>
		public new struct Default
		{
			/// <summary>
			/// The default settings for the <see cref="Axis"/> scale ignore initial
			/// zero values option (<see cref="GraphPane.IsIgnoreInitial"/> property).
			/// true to have the auto-scale-range code ignore the initial data points
			/// until the first non-zero Y value, false otherwise.
			/// </summary>
			public static bool IsIgnoreInitial = false;
			/// <summary>
			/// The default settings for the <see cref="Axis"/> scale bounded ranges option
			/// (<see cref="GraphPane.IsBoundedRanges"/> property).
			/// true to have the auto-scale-range code subset the data according to any
			/// manually set scale values, false otherwise.
			/// </summary>
			public static bool IsBoundedRanges = false;
		}
	#endregion

	#region Class Instance Properties
		/// <summary>
		/// Gets or sets the list of <see cref="CurveItem"/> items for this <see cref="GraphPane"/>
		/// </summary>
		/// <value>A reference to a <see cref="CurveList"/> collection object</value>
		public CurveList CurveList
		{
			get { return _curveList; }
			set { _curveList = value; }
		}
		/// <summary>
		/// Accesses the <see cref="XAxis"/> for this graph
		/// </summary>
		/// <value>A reference to a <see cref="XAxis"/> object</value>
		public XAxis XAxis
		{
			get { return _xAxis; }
		}
        
		/// <summary>
		/// Accesses the primary <see cref="YAxis"/> for this graph
		/// </summary>
		/// <value>A reference to a <see cref="YAxis"/> object</value>
		/// <seealso cref="YAxisList" />
		/// <seealso cref="Y2AxisList" />
		public YAxis YAxis
		{
			get { return _yAxisList[0] as YAxis; }
		}
      
		/// <summary>
		/// Gets the collection of Y axes that belong to this <see cref="GraphPane" />.
		/// </summary>
		public YAxisList YAxisList
		{
			get { return _yAxisList; }
		}
       
		/// <summary>
		/// Gets the <see cref="Chart" /> instance for this <see cref="GraphPane" />.
		/// </summary>
		public Chart Chart
		{
			get { return _chart; }
		}

	#endregion

	#region General Properties

		/// <summary>
		/// Gets or sets a boolean value that affects the data range that is considered
		/// for the automatic scale ranging.
		/// </summary>
		/// <remarks>If true, then initial data points where the Y value
		/// is zero are not included when automatically determining the scale <see cref="Scale.Min"/>,
		/// <see cref="Scale.Max"/>, and <see cref="Scale.MajorStep"/> size.
		/// All data after the first non-zero Y value are included.
		/// </remarks>
		/// <seealso cref="Default.IsIgnoreInitial"/>
		public bool IsIgnoreInitial
		{
			get { return _isIgnoreInitial; }
			set { _isIgnoreInitial = value; }
		}
		/// <summary> Gets or sets a boolean value that determines if the auto-scaled axis ranges will
		/// subset the data points based on any manually set scale range values.</summary>
		/// <remarks>The bounds provide a means to subset the data.  For example, if all the axes are set to
		/// autoscale, then the full range of data are used.  But, if the XAxis.Min and XAxis.Max values
		/// are manually set, then the Y data range will reflect the Y values within the bounds of
		/// XAxis.Min and XAxis.Max.  Set to true to subset the data, or false to always include
		/// all data points when calculating scale ranges.</remarks>
		public bool IsBoundedRanges
		{
			get { return _isBoundedRanges; }
			set { _isBoundedRanges = value; }
		}
		/// <summary>Gets or sets a value that determines whether or not initial
		/// <see cref="PointPairBase.Missing"/> values will cause the line segments of
		/// a curve to be discontinuous.
		/// </summary>
		/// <remarks>If this field is true, then the curves
		/// will be plotted as continuous lines as if the Missing values did not exist.
		/// Use the public property <see cref="IsIgnoreMissing"/> to access
		/// this value. </remarks>
		public bool IsIgnoreMissing
		{
			get { return _isIgnoreMissing; }
			set { _isIgnoreMissing = value; }
		}
		
		/// <summary>
		/// Gets or sets a value that determines if Example should modify the scale ranges
		/// for the Y  axes such that the number of major steps, and therefore the
		/// major grid lines, line up.
		/// </summary>
		/// <remarks>
		/// This property affects the way that <see cref="AxisChange()" /> selects the scale
		/// ranges for the Y and Y2 axes.  It applies to the scale ranges of all Y and Y2 axes,
		/// but only if the <see cref="Scale.MaxAuto" /> is set to true.<br />
		/// </remarks>
		public bool IsAlignGrids
		{
			get { return _isAlignGrids; }
			set { _isAlignGrids = value; }
		}

	#endregion

	#region Constructors

		/// <summary>
		/// Default Constructor.  Sets the <see cref="PaneBase.Rect"/> to (0, 0, 500, 375), and
		/// sets the <see cref="PaneBase.Title"/> and <see cref="Axis.Title"/> values to empty
		/// strings.
		/// </summary>
		public GraphPane()
			: this( new RectangleF( 0, 0, 500, 375 ), "", "", "" )
		{
		}

		/// <summary>
		/// Constructor for the <see cref="GraphPane"/> object.  This routine will
		/// initialize all member variables and classes, setting appropriate default
		/// values as defined in the <see cref="Default"/> class.
		/// </summary>
		/// <param name="rect"> A rectangular screen area where the graph is to be displayed.
		/// This area can be any size, and can be resize at any time using the
		/// <see cref="PaneBase.Rect"/> property.
		/// </param>
		/// <param name="title">The <see cref="PaneBase.Title"/> for this <see cref="GraphPane"/></param>
		/// <param name="xTitle">The <see cref="Axis.Title"/> for the <see cref="XAxis"/></param>
		/// <param name="yTitle">The <see cref="Axis.Title"/> for the <see cref="YAxis"/></param>
		public GraphPane( RectangleF rect, string title,
			string xTitle, string yTitle )
			: base( title, rect )
		{
			_xAxis = new XAxis( xTitle );

			_yAxisList = new YAxisList();

			_yAxisList.Add( new YAxis( yTitle ) );

			_curveList = new CurveList();

			_isIgnoreInitial = Default.IsIgnoreInitial;
			_isBoundedRanges = Default.IsBoundedRanges;
			_isAlignGrids = false;

			_chart = new Chart();
		}

		/// <summary>
		/// The Copy Constructor
		/// </summary>
		/// <param name="rhs">The GraphPane object from which to copy</param>
		public GraphPane( GraphPane rhs )
			: base( rhs )
		{
			// copy values for all the value types
			_isIgnoreInitial = rhs.IsIgnoreInitial;
			_isBoundedRanges = rhs._isBoundedRanges;
			_isAlignGrids = rhs._isAlignGrids;

			_chart = rhs._chart.Clone();

			// copy all the reference types with deep copies
			_xAxis = new XAxis( rhs.XAxis );

			_yAxisList = new YAxisList( rhs._yAxisList );

			_curveList = new CurveList( rhs.CurveList );

		}

		/// <summary>
		/// Implement the <see cref="ICloneable" /> interface in a typesafe manner by just
		/// calling the typed version of <see cref="Clone" />
		/// </summary>
		/// <returns>A deep copy of this object</returns>
		object ICloneable.Clone()
		{
			return this.Clone();
		}

		/// <summary>
		/// Typesafe, deep-copy clone method.
		/// </summary>
		/// <returns>A new, independent copy of this class</returns>
		public GraphPane Clone()
		{
			return new GraphPane( this );
		}

	#endregion

	#region Serialization

		/// <summary>
		/// Current schema value that defines the version of the serialized file
		/// </summary>
		public const int schema2 = 11;

		/// <summary>
		/// Constructor for deserializing objects
		/// </summary>
		/// <param name="info">A <see cref="SerializationInfo"/> instance that defines the serialized data
		/// </param>
		/// <param name="context">A <see cref="StreamingContext"/> instance that contains the serialized data
		/// </param>
		protected GraphPane( SerializationInfo info, StreamingContext context )
			: base( info, context )
		{
			// The schema value is just a file version parameter.  You can use it to make future versions
			// backwards compatible as new member variables are added to classes
			int sch = info.GetInt32( "schema2" );

			_xAxis = (XAxis)info.GetValue( "xAxis", typeof( XAxis ) );

			_yAxisList = (YAxisList)info.GetValue( "yAxisList", typeof( YAxisList ) );

			_curveList = (CurveList)info.GetValue( "curveList", typeof( CurveList ) );

			_chart = (Chart) info.GetValue( "chart", typeof( Chart ) );


			_isIgnoreInitial = info.GetBoolean( "isIgnoreInitial" );
			_isBoundedRanges = info.GetBoolean( "isBoundedRanges" );
			_isIgnoreMissing = info.GetBoolean( "isIgnoreMissing" );
			_isAlignGrids = info.GetBoolean( "isAlignGrids" );

		}
		/// <summary>
		/// Populates a <see cref="SerializationInfo"/> instance with the data needed to serialize the target object
		/// </summary>
		/// <param name="info">A <see cref="SerializationInfo"/> instance that defines the serialized data</param>
		/// <param name="context">A <see cref="StreamingContext"/> instance that contains the serialized data</param>
		[SecurityPermissionAttribute( SecurityAction.Demand, SerializationFormatter = true )]
		public override void GetObjectData( SerializationInfo info, StreamingContext context )
		{
			base.GetObjectData( info, context );

			info.AddValue( "schema2", schema2 );

			info.AddValue( "xAxis", _xAxis );
			info.AddValue( "yAxisList", _yAxisList );
			info.AddValue( "curveList", _curveList );

			info.AddValue( "chart", _chart );


			info.AddValue( "isIgnoreInitial", _isIgnoreInitial );
			info.AddValue( "isBoundedRanges", _isBoundedRanges );
			info.AddValue( "isIgnoreMissing", _isIgnoreMissing );
			info.AddValue( "isAlignGrids", _isAlignGrids );

		}

	#endregion

	#region Rendering Methods

		/// <summary>
		/// AxisChange causes the axes scale ranges to be recalculated based on the current data range.
		/// </summary>
		/// <remarks>
		/// There is no obligation to call AxisChange() for manually scaled axes.  AxisChange() is only
		/// intended to handle auto scaling operations.  Call this function anytime you change, add, or
		/// remove curve data to insure that the scale range of the axes are appropriate for the data range.
		/// This method calculates
		/// a scale minimum, maximum, and step size for each axis based on the current curve data.
		/// Only the axis attributes (min, max, step) that are set to auto-range
		/// (<see cref="Scale.MinAuto"/>, <see cref="Scale.MaxAuto"/>, <see cref="Scale.MajorStepAuto"/>)
		/// will be modified.  You must call <see cref="Control.Invalidate()"/> after calling
		/// AxisChange to make sure the display gets updated.<br />
		/// This overload of AxisChange just uses the default Graphics instance for the screen.
		/// If you have a Graphics instance available from your Windows Form, you should use
		/// the <see cref="AxisChange(Graphics)" /> overload instead.
		/// </remarks>
		public void AxisChange()
		{
			using ( Graphics g = Graphics.FromHwnd( IntPtr.Zero ) )
				AxisChange( g );
		}

		/// <summary>
		/// AxisChange causes the axes scale ranges to be recalculated based on the current data range.
		/// </summary>
		/// <remarks>
		/// There is no obligation to call AxisChange() for manually scaled axes.  AxisChange() is only
		/// intended to handle auto scaling operations.  Call this function anytime you change, add, or
		/// remove curve data to insure that the scale range of the axes are appropriate for the data range.
		/// This method calculates
		/// a scale minimum, maximum, and step size for each axis based on the current curve data.
		/// Only the axis attributes (min, max, step) that are set to auto-range
		/// (<see cref="Scale.MinAuto"/>, <see cref="Scale.MaxAuto"/>, <see cref="Scale.MajorStepAuto"/>)
		/// will be modified.  You must call
		/// <see cref="Control.Invalidate()"/> after calling AxisChange to make sure the display gets updated.
		/// </remarks>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		public void AxisChange( Graphics g )
		{

			// Get the scale range of the data (all curves)
			_curveList.GetRange( _isIgnoreInitial, _isBoundedRanges, this );

			// Determine the scale factor
			float scaleFactor = this.CalcScaleFactor();

         	// if the ChartRect is not yet determined, then pick a scale based on a default ChartRect
			// size (using 75% of Rect -- code is in Axis.CalcMaxLabels() )
			// With the scale picked, call CalcChartRect() so calculate a real ChartRect
			// then let the scales re-calculate to make sure that the assumption was ok
			if ( _chart._isRectAuto )
			{
				PickScale( g, scaleFactor );

				_chart._rect = CalcChartRect( g );
			}

			// Pick new scales based on the range
			PickScale( g, scaleFactor );

        	// Trigger the AxisChangeEvent
			if ( this.AxisChangeEvent != null )
				this.AxisChangeEvent( this );

		}

		private void PickScale( Graphics g, float scaleFactor )
		{
			int maxTics = 0;

			_xAxis._scale.PickScale( this, g, scaleFactor );

			foreach ( Axis axis in _yAxisList )
			{
				axis._scale.PickScale( this, g, scaleFactor );
				if ( axis._scale.MaxAuto )
				{
					int nTics = axis._scale.CalcNumTics();
					maxTics = nTics > maxTics ? nTics : maxTics;
				}
			}
            

			if ( _isAlignGrids )
			{
				foreach ( Axis axis in _yAxisList )
					ForceNumTics( axis, maxTics );
			}

		}

		private void ForceNumTics( Axis axis, int numTics )
		{
			if ( axis._scale.MaxAuto )
			{
				int nTics = axis._scale.CalcNumTics();
				if ( nTics < numTics )
					axis._scale._maxLinearized += axis._scale._majorStep * ( numTics - nTics );
			}
		}

		/// <summary>
		/// Draw all elements in the <see cref="GraphPane"/> to the specified graphics device.
		/// </summary>
		/// <remarks>This method
		/// should be part of the Paint() update process.  Calling this routine will redraw all
		/// features of the graph.  No preparation is required other than an instantiated
		/// <see cref="GraphPane"/> object.
		/// </remarks>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		public override void Draw( Graphics g )
		{
			
			base.Draw( g );

			if ( _rect.Width <= 1 || _rect.Height <= 1 )
				return;

			// Clip everything to the rect
			g.SetClip( _rect );

			// calculate scaleFactor on "normal" pane size (BaseDimension)
			float scaleFactor = this.CalcScaleFactor();


			// if the size of the ChartRect is determined automatically, then do so
			// otherwise, calculate the legendrect, scalefactor, hstack, and legendwidth parameters
			// but leave the ChartRect alone
			if ( _chart._isRectAuto )
			{
				_chart._rect = CalcChartRect( g, scaleFactor );
			}
			else
				CalcChartRect( g, scaleFactor );

			// do a sanity check on the ChartRect
			if ( _chart._rect.Width < 1 || _chart._rect.Height < 1 )
				return;

			// Draw the graph features only if there is at least one curve with data
			// if ( _curveList.HasData() &&
			// Go ahead and draw the graph, even without data.  This makes the control
			// version still look like a graph before it is fully set up
			bool showGraf = AxisRangesValid();

			// Setup the axes for graphing - This setup must be done before
			// the GraphObj's are drawn so that the Transform functions are
			// ready.  Also, this should be done before CalcChartRect so that the
			// Axis.Cross - shift parameter can be calculated.
			_xAxis.Scale.SetupScaleData( this, _xAxis );
			foreach ( Axis axis in _yAxisList )
				axis.Scale.SetupScaleData( this, axis );
          

			if ( showGraf )
			{
				DrawGrid( g, scaleFactor );

				// Clip the points to the actual plot area
				g.SetClip( _chart._rect );
				_curveList.Draw( g, this, scaleFactor );
				g.SetClip( _rect );

			}

			if ( showGraf )
			{
				// Draw the Axes
				_xAxis.Draw( g, this, scaleFactor, 0.0f );

				float yPos = 0;
				foreach ( Axis axis in _yAxisList )
				{
					axis.Draw( g, this, scaleFactor, yPos );
					yPos += axis._tmpSpace;
				}

			}

			// Border the axis itself
			_chart.Border.Draw( g, this, scaleFactor, _chart._rect );
			// Reset the clipping
			g.ResetClip();

		}

		internal void DrawGrid( Graphics g, float scaleFactor )
		{
			_xAxis.DrawGrid( g, this, scaleFactor, 0.0f );

			float shiftPos = 0.0f;
			foreach ( YAxis yAxis in _yAxisList )
			{
				yAxis.DrawGrid( g, this, scaleFactor, shiftPos );
				shiftPos += yAxis._tmpSpace;
			}
         
		}

		private bool AxisRangesValid()
		{
            bool showGraf = _xAxis._scale._min < _xAxis._scale._max;
			foreach ( Axis axis in _yAxisList )
				if ( axis._scale._min >= axis._scale._max )
					showGraf = false;

			return showGraf;
		}

		/// <summary>
		/// Calculate the <see cref="Chart.Rect"/> based on the <see cref="PaneBase.Rect"/>.
		/// </summary>
		/// <remarks>The ChartRect
		/// is the plot area bounded by the axes, and the rect is the total area as
		/// specified by the client application.
		/// </remarks>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// <returns>The calculated chart rect, in pixel coordinates.</returns>
		public RectangleF CalcChartRect( Graphics g )
		{
			return CalcChartRect( g, CalcScaleFactor() );
		}

		/// <summary>
		/// Calculate the <see cref="Chart.Rect"/> based on the <see cref="PaneBase.Rect"/>.
		/// </summary>
		/// <remarks>The ChartRect
		/// is the plot area bounded by the axes, and the rect is the total area as
		/// specified by the client application.
		/// </remarks>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// <param name="scaleFactor">
		/// The scaling factor for the features of the graph based on the <see cref="PaneBase.BaseDimension"/>.  This
		/// scaling factor is calculated by the <see cref="PaneBase.CalcScaleFactor"/> method.  The scale factor
		/// represents a linear multiple to be applied to font sizes, symbol sizes, etc.
		/// </param>
		/// <returns>The calculated chart rect, in pixel coordinates.</returns>

		public RectangleF CalcChartRect( Graphics g, float scaleFactor )
		{
			// chart rect starts out at the full pane rect less the margins
			//   and less space for the Pane title
			RectangleF clientRect = this.CalcClientRect( g, scaleFactor );

			float totSpaceY = 0;

			// actual minimum axis space for the left side of the chart rect
			float minSpaceL = 0;
			// actual minimum axis space for the right side of the chart rect
			float minSpaceR = 0;
			// actual minimum axis space for the bottom side of the chart rect
			float minSpaceB = 0;
			// actual minimum axis space for the top side of the chart rect
			float minSpaceT = 0;

			_xAxis.CalcSpace( g, this, scaleFactor, out minSpaceB );

			foreach ( Axis axis in _yAxisList )
			{
				float fixedSpace;
				float tmp = axis.CalcSpace( g, this, scaleFactor, out fixedSpace );
				if ( axis.IsCrossShifted( this ) )
					totSpaceY += tmp;

				minSpaceL += fixedSpace;
			}

			float spaceB = 0, spaceT = 0, spaceL = 0, spaceR = 0;

			SetSpace( _xAxis, clientRect.Height - _xAxis._tmpSpace, ref spaceB, ref spaceT );
			_xAxis._tmpSpace = spaceB;

			float totSpaceL = 0;
			float totSpaceR = 0;

			foreach ( Axis axis in _yAxisList )
			{
				SetSpace( axis, clientRect.Width - totSpaceY, ref spaceL, ref spaceR );
				minSpaceR = Math.Max( minSpaceR, spaceR );
				totSpaceL += spaceL;
				axis._tmpSpace = spaceL;
			}
           

			RectangleF tmpRect = clientRect;

			totSpaceL = Math.Max( totSpaceL, minSpaceL );
			totSpaceR = Math.Max( totSpaceR, minSpaceR );
			spaceB = Math.Max( spaceB, minSpaceB );
			spaceT = Math.Max( spaceT, minSpaceT );

			tmpRect.X += totSpaceL;
			tmpRect.Width -= totSpaceL + totSpaceR;
			tmpRect.Height -= spaceT + spaceB;
			tmpRect.Y += spaceT;


			return tmpRect;
		}

		private void SetSpace( Axis axis, float clientSize, ref float spaceNorm, ref float spaceAlt )
		{
			float crossFrac = axis.CalcCrossFraction( this );
			float crossPix = crossFrac * ( 1 + crossFrac ) * ( 1 + crossFrac * crossFrac ) * clientSize;

			if ( !axis.IsPrimary( this ) && axis.IsCrossShifted( this ) )
				axis._tmpSpace = 0;

			if ( axis._tmpSpace < crossPix )
				axis._tmpSpace = 0;
			else if ( crossPix > 0 )
				axis._tmpSpace -= crossPix;

			if ( axis._scale._isLabelsInside && ( axis.IsPrimary( this ) || ( crossFrac != 0.0 && crossFrac != 1.0 ) ) )
				spaceAlt = axis._tmpSpace;
			else
				spaceNorm = axis._tmpSpace;
		}

		/// <summary>
		/// This method will set the <see cref="Axis.MinSpace"/> property for all three axes;
		/// <see cref="XAxis"/>, <see cref="YAxis"/>, and <see cref="Y2Axis"/>.
		/// </summary>
		/// <remarks>The <see cref="Axis.MinSpace"/>
		/// is calculated using the currently required space multiplied by a fraction
		/// (<paramref>bufferFraction</paramref>).
		/// The currently required space is calculated using <see cref="Axis.CalcSpace"/>, and is
		/// based on current data ranges, font sizes, etc.  The "space" is actually the amount of space
		/// required to fit the tic marks, scale labels, and axis title.
		/// The calculation is done by calling the <see cref="Axis.SetMinSpaceBuffer"/> method for
		/// each <see cref="Axis"/>.
		/// </remarks>
		/// <param name="g">A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.</param>
		/// <param name="bufferFraction">The amount of space to allocate for the axis, expressed
		/// as a fraction of the currently required space.  For example, a value of 1.2 would
		/// allow for 20% extra above the currently required space.</param>
		/// <param name="isGrowOnly">If true, then this method will only modify the <see cref="Axis.MinSpace"/>
		/// property if the calculated result is more than the current value.</param>
		public void SetMinSpaceBuffer( Graphics g, float bufferFraction, bool isGrowOnly )
		{
			_xAxis.SetMinSpaceBuffer( g, this, bufferFraction, isGrowOnly );
			foreach ( Axis axis in _yAxisList )
				axis.SetMinSpaceBuffer( g, this, bufferFraction, isGrowOnly );
		}

	#endregion

	#region General Utility Methods
		/// <summary>
		/// Transform a data point from the specified coordinate type
		/// (<see cref="CoordType"/>) to screen coordinates (pixels).
		/// </summary>
		/// <remarks>This method implicitly assumes that <see cref="Chart.Rect"/>
		/// has already been calculated via <see cref="AxisChange()"/> or
		/// <see cref="Draw"/> methods, or the <see cref="Chart.Rect"/> is
		/// set manually (see <see cref="Chart.IsRectAuto"/>).</remarks>
		/// <param name="ptF">The X,Y pair that defines the point in user
		/// coordinates.</param>
		/// <param name="coord">A <see cref="CoordType"/> type that defines the
		/// coordinate system in which the X,Y pair is defined.</param>
		/// <returns>A point in screen coordinates that corresponds to the
		/// specified user point.</returns>
		public PointF GeneralTransform( PointF ptF, CoordType coord )
		{
			// Setup the scaling data based on the chart rect
			_xAxis.Scale.SetupScaleData( this, _xAxis );
			foreach ( Axis axis in _yAxisList )
				axis.Scale.SetupScaleData( this, axis );

			return this.TransformCoord( ptF.X, ptF.Y, coord );
		}

		/// <summary>
		/// Transform a data point from the specified coordinate type
		/// (<see cref="CoordType"/>) to screen coordinates (pixels).
		/// </summary>
		/// <remarks>This method implicitly assumes that <see cref="Chart.Rect"/>
		/// has already been calculated via <see cref="AxisChange()"/> or
		/// <see cref="Draw"/> methods, or the <see cref="Chart.Rect"/> is
		/// set manually (see <see cref="Chart.IsRectAuto"/>).
		/// Note that this method is more accurate than the <see cref="GeneralTransform(PointF,CoordType)" />
		/// overload, since it uses double types.  This would typically only be significant for
		/// <see cref="AxisType.Date" /> coordinates.
		/// </remarks>
		/// <param name="x">The x coordinate that defines the location in user space</param>
		/// <param name="y">The y coordinate that defines the location in user space</param>
		/// <param name="coord">A <see cref="CoordType"/> type that defines the
		/// coordinate system in which the X,Y pair is defined.</param>
		/// <returns>A point in screen coordinates that corresponds to the
		/// specified user point.</returns>
		public PointF GeneralTransform( double x, double y, CoordType coord )
		{
			// Setup the scaling data based on the chart rect
			_xAxis.Scale.SetupScaleData( this, _xAxis );
			foreach ( Axis axis in _yAxisList )
				axis.Scale.SetupScaleData( this, axis );

			return this.TransformCoord( x, y, coord );
		}

		/// <summary>
		/// Return the user scale values that correspond to the specified screen
		/// coordinate position (pixels).  This overload assumes the default
		/// <see cref="XAxis" /> and <see cref="YAxis" />.
		/// </summary>
		/// <remarks>This method implicitly assumes that <see cref="Chart.Rect"/>
		/// has already been calculated via <see cref="AxisChange()"/> or
		/// <see cref="Draw"/> methods, or the <see cref="Chart.Rect"/> is
		/// set manually (see <see cref="Chart.IsRectAuto"/>).</remarks>
		/// <param name="ptF">The X,Y pair that defines the screen coordinate
		/// point of interest</param>
		/// <param name="x">The resultant value in user coordinates from the
		/// <see cref="XAxis"/></param>
		/// <param name="y">The resultant value in user coordinates from the
		/// primary <see cref="YAxis"/></param>
		public void ReverseTransform( PointF ptF, out double x, out double y )
		{
			// Setup the scaling data based on the chart rect
			_xAxis.Scale.SetupScaleData( this, _xAxis );
			this.YAxis.Scale.SetupScaleData( this, this.YAxis );

			x = this.XAxis.Scale.ReverseTransform( ptF.X );
			y = this.YAxis.Scale.ReverseTransform( ptF.Y );
		}
 
		/// <summary>
		/// Return the user scale values that correspond to the specified screen
		/// coordinate position (pixels) for all y axes.
		/// </summary>
		/// <remarks>This method implicitly assumes that <see cref="Chart.Rect"/>
		/// has already been calculated via <see cref="AxisChange()"/> or
		/// <see cref="Draw"/> methods, or the <see cref="Chart.Rect"/> is
		/// set manually (see <see cref="Chart.IsRectAuto"/>).</remarks>
		/// <param name="ptF">The X,Y pair that defines the screen coordinate
		/// point of interest</param>
		/// <param name="x">The resultant value in user coordinates from the
		/// <see cref="XAxis"/></param>
		/// <param name="y">An array of resultant values in user coordinates from the
		/// list of <see cref="YAxis"/> instances.  This method allocates the
		/// array for you, according to the number of <see cref="YAxis" /> objects
		/// in the list.</param>
		public void ReverseTransform(PointF ptF, out double x, out double[] y)
		{
			// Setup the scaling data based on the chart rect
			_xAxis.Scale.SetupScaleData( this, _xAxis );
			x = this.XAxis.Scale.ReverseTransform( ptF.X );

			y = new double[_yAxisList.Count];

			for ( int i = 0; i < _yAxisList.Count; i++ )
			{
				Axis axis = _yAxisList[i];
				axis.Scale.SetupScaleData( this, axis );
				y[i] = axis.Scale.ReverseTransform( ptF.Y );
			}
		}

		/// <summary>
		/// Add a secondary <see cref="YAxis" /> (left side) to the list of axes
		/// in the Graph.
		/// </summary>
		/// <remarks>
		/// Note that the primary <see cref="YAxis" /> is always included by default.
		/// This method turns off the <see cref="MajorTic" /> and <see cref="MinorTic" />
		/// <see cref="MinorTic.IsOpposite" /> and <see cref="MinorTic.IsInside" />
		/// properties by default.
		/// </remarks>
		/// <param name="title">The title for the <see cref="YAxis" />.</param>
		/// <returns>the ordinal position (index) in the <see cref="YAxisList" />.</returns>
		public int AddYAxis( string title )
		{
			YAxis axis = new YAxis( title );
			axis.MajorTic.IsOpposite = false;
			axis.MinorTic.IsOpposite = false;
			axis.MajorTic.IsInside = false;
			axis.MinorTic.IsInside = false;
			_yAxisList.Add( axis );
			return _yAxisList.Count - 1;
		}
	#endregion

	}
}

