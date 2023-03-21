using System;
using System.Drawing;
using System.Collections.Generic;

namespace Example5_2_4
{
	/// <summary>
	/// A collection class containing a list of <see cref="CurveItem"/> objects
	/// that define the set of curves to be displayed on the graph.
	/// </summary>
	/// 
	[Serializable]
	public class CurveList : List<CurveItem>, ICloneable
	{

	#region Properties
		// internal temporary value that keeps
		// the max number of points for any curve
		// associated with this curveList
		private int	maxPts;

		/// <summary>
		/// Read only value for the maximum number of points in any of the curves
		/// in the list.
		/// </summary>
		public int MaxPts
		{
			get { return maxPts; }
		}
	#endregion
	
	#region Constructors
	
		/// <summary>
		/// Default constructor for the collection class
		/// </summary>
		public CurveList()
		{
			maxPts = 1;
		}

		/// <summary>
		/// The Copy Constructor
		/// </summary>
		/// <param name="rhs">The XAxis object from which to copy</param>
		public CurveList( CurveList rhs )
		{
			this.maxPts = rhs.maxPts;

			foreach ( CurveItem item in rhs )
			{
				this.Add( (CurveItem) ((ICloneable)item).Clone() );
			}
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
		public CurveList Clone()
		{
			return new CurveList( this );
		}

		
	#endregion

	#region List Methods

		/// <summary>
		/// Indexer to access the specified <see cref="CurveItem"/> object by
		/// its <see cref="CurveItem.Label"/> string.
		/// </summary>
		/// <param name="label">The string label of the
		/// <see cref="CurveItem"/> object to be accessed.</param>
		/// <value>A <see cref="CurveItem"/> object reference.</value>
		public CurveItem this[ string label ]  
		{
			get
			{
				int index = IndexOf( label );
				if ( index >= 0 )
					return( this[index]  );
				else
					return null;
			}
		}

		/// <summary>
		/// Return the zero-based position index of the
		/// <see cref="CurveItem"/> with the specified <see cref="CurveItem.Label"/>.
		/// </summary>
		/// <param name="label">The <see cref="String"/> label that is in the
		/// <see cref="CurveItem.Label"/> attribute of the item to be found.
		/// </param>
		/// <returns>The zero-based index of the specified <see cref="CurveItem"/>,
		/// or -1 if the <see cref="CurveItem"/> is not in the list</returns>
		/// <seealso cref="IndexOfTag"/>
		public int IndexOf( string label )
		{
			int index = 0;
			foreach ( CurveItem p in this )
			{
				if ( String.Compare( p._label._text, label, true ) == 0 )
					return index;
				index++;
			}

			return -1;
		}

		/// <summary>
		/// Return the zero-based position index of the
		/// <see cref="CurveItem"/> with the specified <see cref="CurveItem.Tag"/>.
		/// </summary>
		/// <remarks>In order for this method to work, the <see cref="CurveItem.Tag"/>
		/// property must be of type <see cref="String"/>.</remarks>
		/// <param name="tag">The <see cref="String"/> tag that is in the
		/// <see cref="CurveItem.Tag"/> attribute of the item to be found.
		/// </param>
		/// <returns>The zero-based index of the specified <see cref="CurveItem"/>,
		/// or -1 if the <see cref="CurveItem"/> is not in the list</returns>
		public int IndexOfTag( string tag )
		{
			int index = 0;
			foreach ( CurveItem p in this )
			{
				if ( p.Tag is string &&
							String.Compare( (string) p.Tag, tag, true ) == 0 )
					return index;
				index++;
			}

			return -1;
		}

  
		/// <summary>
		/// Move the position of the object at the specified index
		/// to the new relative position in the list.</summary>
		/// <remarks>For Graphic type objects, this method controls the
		/// Z-Order of the items.  Objects at the beginning of the list
		/// appear in front of objects at the end of the list.</remarks>
		/// <param name="index">The zero-based index of the object
		/// to be moved.</param>
		/// <param name="relativePos">The relative number of positions to move
		/// the object.  A value of -1 will move the
		/// object one position earlier in the list, a value
		/// of 1 will move it one position later.  To move an item to the
		/// beginning of the list, use a large negative value (such as -999).
		/// To move it to the end of the list, use a large positive value.
		/// </param>
		/// <returns>The new position for the object, or -1 if the object
		/// was not found.</returns>
		public int Move( int index, int relativePos )
		{
			if ( index < 0 || index >= Count )
				return -1;

			CurveItem curve = this[index];
			this.RemoveAt( index );

			index += relativePos;
			if ( index < 0 )
				index = 0;
			if ( index > Count )
				index = Count;

			Insert( index, curve );
			return index;
		}



	#endregion

	#region Rendering Methods

		/// <summary>
		/// Go through each <see cref="CurveItem"/> object in the collection,
		/// calling the <see cref="CurveItem.GetRange"/> member to 
		/// determine the minimum and maximum values in the
		/// <see cref="CurveItem.Points"/> list of data value pairs.  If the curves include 
		/// a stack bar, handle within the current GetRange method. In the event that no
		/// data are available, a default range of min=0.0 and max=1.0 are returned.
		/// If the Y axis has a valid data range and the Y2 axis not, then the Y2
		/// range will be a duplicate of the Y range.  Vice-versa for the Y2 axis
		/// having valid data when the Y axis does not.
		/// If any <see cref="CurveItem"/> in the list has a missing
		/// <see cref="PointPairList"/>, a new empty one will be generated.
		/// </summary>
		/// <param name="bIgnoreInitial">ignoreInitial is a boolean value that
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
		public void GetRange( bool bIgnoreInitial, bool isBoundedRanges, GraphPane pane )
		{
			double	tXMinVal,
						tXMaxVal,
						tYMinVal,
						tYMaxVal;

			InitScale( pane.XAxis.Scale, isBoundedRanges );

			foreach ( YAxis axis in pane.YAxisList )
				InitScale( axis.Scale, isBoundedRanges );


			maxPts = 1;
			
			// Loop over each curve in the collection and examine the data ranges
			foreach ( CurveItem curve in this )
			{
				if ( curve.IsVisible )
				{
                   		// Call the GetRange() member function for the current
						// curve to get the min and max values
						curve.GetRange( out tXMinVal, out tXMaxVal,
										out tYMinVal, out tYMaxVal, bIgnoreInitial, true, pane );

					// isYOrd is true if the Y axis is an ordinal type
					Scale yScale = curve.GetYAxis( pane ).Scale;

					Scale xScale = curve.GetXAxis( pane ).Scale;
                 
					// If the min and/or max values from the current curve
					// are the absolute min and/or max, then save the values
					// Also, differentiate between Y and Y2 values

					if ( tYMinVal < yScale._rangeMin )
						yScale._rangeMin = tYMinVal;
					if ( tYMaxVal > yScale._rangeMax )
						yScale._rangeMax = tYMaxVal;


					if ( tXMinVal < xScale._rangeMin )
						xScale._rangeMin = tXMinVal;
					if ( tXMaxVal > xScale._rangeMax )
						xScale._rangeMax = tXMaxVal;
				}
			}

			pane.XAxis.Scale.SetRange( pane, pane.XAxis );

			foreach ( YAxis axis in pane.YAxisList )
				axis.Scale.SetRange( pane, axis );
		}

		private void InitScale( Scale scale, bool isBoundedRanges )
		{
			scale._rangeMin = double.MaxValue;
			scale._rangeMax = double.MinValue;
			scale._lBound = ( isBoundedRanges && !scale._minAuto ) ?
				scale._min : double.MinValue;
			scale._uBound = ( isBoundedRanges && !scale._maxAuto ) ?
				scale._max : double.MaxValue;
		}

		/// <summary>
		/// Render all the <see cref="CurveItem"/> objects in the list to the
		/// specified <see cref="Graphics"/>
		/// device by calling the <see cref="CurveItem.Draw"/> member function of
		/// each <see cref="CurveItem"/> object.
		/// </summary>
		/// <param name="g">
		/// A graphic device object to be drawn into.  This is normally e.Graphics from the
		/// PaintEventArgs argument to the Paint() method.
		/// </param>
		/// <param name="pane">
		/// A reference to the <see cref="GraphPane"/> object that is the parent or
		/// owner of this object.
		/// </param>
		/// <param name="scaleFactor">
		/// The scaling factor to be used for rendering objects.  This is calculated and
		/// passed down by the parent <see cref="GraphPane"/> object using the
		/// <see cref="PaneBase.CalcScaleFactor"/> method, and is used to proportionally adjust
		/// font sizes, etc. according to the actual size of the graph.
		/// </param>
		public void Draw( Graphics g, GraphPane pane, float scaleFactor )
		{
			
            int pos = 0;
         

			// Loop for each curve in reverse order to pick up the remaining curves
			// The reverse order is done so that curves that are later in the list are plotted behind
			// curves that are earlier in the list

			for ( int i = this.Count - 1; i >= 0; i-- )
			{
				CurveItem curve = this[i];
               
					curve.Draw( g, pane, pos, scaleFactor );
               
			}
		}

	#endregion

	}
}


