using System;
using System.Text;
using System.Drawing;

namespace Example5_2_1
{
	/// <summary>
	/// A class designed to simplify the process of getting the actual value for
	/// the various stacked and regular curve types
	/// </summary>
	/// 
	public class ValueHandler
	{
		private GraphPane _pane;

		/// <summary>
		/// Basic constructor that saves a reference to the parent
		/// <see cref="GraphPane"/> object.
		/// </summary>
		/// <param name="pane">The parent <see cref="GraphPane"/> object.</param>
		/// <param name="initialize">A <see cref="bool"/> flag to indicate whether or
		/// not the drawing variables should be initialized.  Initialization is not
		/// required if this is part of a Example internal draw operation (i.e., its in
		/// the middle of a call to <see cref="GraphPane.Draw"/>).  Otherwise, you should
		/// initialize to make sure the drawing variables are configured.  true to do
		/// an initialization, false otherwise.</param>
		public ValueHandler( GraphPane pane, bool initialize )
		{
			_pane = pane;
		}

		/// <summary>
		/// Get the user scale values associate with a particular point of a
		/// particular curve.</summary>
		/// <remarks>The main purpose of this method is to handle
		/// stacked bars, in which case the stacked values are returned rather
		/// than the individual data values.
		/// </remarks>
		/// <param name="curve">A <see cref="CurveItem"/> object of interest.</param>
		/// <param name="iPt">The zero-based point index for the point of interest.</param>
		/// <param name="baseVal">A <see cref="Double"/> value representing the value
		/// for the independent axis.</param>
		/// <param name="lowVal">A <see cref="Double"/> value representing the lower
		/// value for the dependent axis.</param>
		/// <param name="hiVal">A <see cref="Double"/> value representing the upper
		/// value for the dependent axis.</param>
		/// <returns>true if the data point is value, false for
		/// <see cref="PointPairBase.Missing"/>, invalid, etc. data.</returns>
		public bool GetValues( CurveItem curve, int iPt, out double baseVal,
							out double lowVal, out double hiVal )
		{
			return GetValues( _pane, curve, iPt, out baseVal,
									out lowVal, out hiVal );
		}

		/// <summary>
		/// Get the user scale values associate with a particular point of a
		/// particular curve.</summary>
		/// <remarks>The main purpose of this method is to handle
		/// stacked bars and lines, in which case the stacked values are returned rather
		/// than the individual data values.  However, this method works generically for any
		/// curve type.
		/// </remarks>
		/// <param name="pane">The parent <see cref="GraphPane"/> object.</param>
		/// <param name="curve">A <see cref="CurveItem"/> object of interest.</param>
		/// <param name="iPt">The zero-based point index for the point of interest.</param>
		/// <param name="baseVal">A <see cref="Double"/> value representing the value
		/// for the independent axis.</param>
		/// <param name="lowVal">A <see cref="Double"/> value representing the lower
		/// value for the dependent axis.</param>
		/// <param name="hiVal">A <see cref="Double"/> value representing the upper
		/// value for the dependent axis.</param>
		/// <returns>true if the data point is value, false for
		/// <see cref="PointPairBase.Missing"/>, invalid, etc. data.</returns>
		public static bool GetValues( GraphPane pane, CurveItem curve, int iPt,
							out double baseVal, out double lowVal, out double hiVal )
		{
			hiVal = PointPair.Missing;
			lowVal = PointPair.Missing;
			baseVal = PointPair.Missing;

			if ( curve == null || curve.Points.Count <= iPt || !curve.IsVisible )
				return false;

			Axis baseAxis = curve.BaseAxis( pane );
			Axis valueAxis = curve.ValueAxis( pane );

            //if ( baseAxis is XAxis || baseAxis is X2Axis )
            if ( baseAxis is XAxis)
				baseVal = curve.Points[iPt].X;
			else
				baseVal = curve.Points[iPt].Y;


            if (curve is LineItem && pane.LineType == LineType.Stack)
			{
				double stack = 0;
				double curVal;

				// loop through all the curves, summing up the values to get a total (only
				// for the current ordinal position iPt)
				foreach ( CurveItem tmpCurve in pane.CurveList )
				{
					// make sure the curve is a Line type
					if ( tmpCurve is LineItem && tmpCurve.IsVisible )
					{
						curVal = PointPair.Missing;
						// For non-ordinal curves, find a matching base value (must match exactly)
						if ( curve.IsOverrideOrdinal || !baseAxis._scale.IsAnyOrdinal )
						{
							IPointList points = tmpCurve.Points;

							for ( int i = 0; i < points.Count; i++ )
							{
								if ( points[i].X == baseVal )
								{
									curVal = points[i].Y;
									break;
								}
							}
						}
						// otherwise, it's an ordinal type so use the value at the same ordinal position
						else if ( iPt < tmpCurve.Points.Count )
						{
							// For line types, the Y axis is always the value axis
							curVal = tmpCurve.Points[iPt].Y;
						}

						// if the current value is missing, then the rest of the stack is missing
						if ( curVal == PointPair.Missing )
							stack = PointPair.Missing;

						// if the current curve is the target curve, save the values
						if ( tmpCurve == curve )
						{
							lowVal = stack;
								hiVal = ( curVal == PointPair.Missing || stack == PointPair.Missing ) ?
									PointPair.Missing : stack + curVal;
						}

						// sum all the curves to a single total.  This includes both positive and
						// negative values (unlike the bar stack type).
						stack = ( curVal == PointPair.Missing || stack == PointPair.Missing ) ?
								PointPair.Missing : stack + curVal;
					}
				}
				
				if ( baseVal == PointPair.Missing || lowVal == PointPair.Missing ||
					hiVal == PointPair.Missing )
					return false;
				else
					return true;
			}
			// otherwise, the curve is not a stacked type (not a stacked bar or stacked line)
			else
			{
                
					lowVal = curve.Points[iPt].LowValue;

                if ( baseAxis is XAxis)
					hiVal = curve.Points[iPt].Y;
				else
					hiVal = curve.Points[iPt].X;
			}

           
            if (baseVal == PointPair.Missing || hiVal == PointPair.Missing || lowVal == PointPair.Missing)
                return false;
			else
				return true;
		}
       
	}
}
