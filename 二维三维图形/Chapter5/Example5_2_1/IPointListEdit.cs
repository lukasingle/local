using System;
using System.Text;

namespace Example5_2_1
{
	/// <summary>
	/// An interface to a collection class containing data
	/// that define the set of points to be displayed on the curve.
	/// </summary>
	/// <remarks>
	/// This interface is designed to allow customized data abstraction.  The default data
	/// collection class is <see cref="PointPairList" />, however, you can define your own
	/// data collection class using the <see cref="IPointList" /> interface.  This
	/// <see cref="IPointListEdit" /> interface adds the ability to remove and add points
	/// to the list, and so is used by the <see cref="CurveItem" /> class for the
	/// <see cref="CurveItem.AddPoint(double,double)" />, <see cref="CurveItem.RemovePoint" />, and
	/// <see cref="CurveItem.Clear" /> methods.
	/// </remarks>
	/// <seealso cref="PointPairList" />
	/// <seealso cref="BasicArrayPointList" />
	/// <seealso cref="IPointList" />
	/// 
	public interface IPointListEdit : IPointList
	{
		/// <summary>
		/// Indexer to access a data point by its ordinal position in the collection.
		/// </summary>
		/// <remarks>
		/// This is the standard interface that Example uses to access the data.  Although
		/// you must pass a <see cref="PointPair" /> here, your internal data storage format
		/// can be anything.
		/// </remarks>
		/// <param name="index">The ordinal position (zero-based) of the
		/// data point to be accessed.</param>
		/// <value>A <see cref="PointPair"/> object instance.</value>
		new PointPair this[int index] { get; set; }

		/// <summary>
		/// Appends a point to the end of the list.  The data are passed in as a <see cref="PointPair" />
		/// object.
		/// </summary>
		/// <param name="point">The <see cref="PointPair" /> object containing the data to be added.</param>
		void Add( PointPair point );

		/// <summary>
		/// Appends a point to the end of the list.  The data are passed in as two <see cref="Double" />
		/// types.
		/// </summary>
		/// <param name="x">The <see cref="Double" /> value containing the X data to be added.</param>
		/// <param name="y">The <see cref="Double" /> value containing the Y data to be added.</param>
		/// <returns>The ordinal position (zero-based), at which the new point was added.</returns>
		void Add( double x, double y );

		/// <summary>
		/// Removes a single data point from the list at the specified ordinal location
		/// (zero based).
		/// </summary>
		void RemoveAt( int index );

		/// <summary>
		/// Clears all data points from the list.  After calling this method,
		/// <see cref="IPointList.Count" /> will be zero.
		/// </summary>
		void Clear();

	}
}
