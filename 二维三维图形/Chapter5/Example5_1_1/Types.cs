using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace Example5_1_1
{
    /// <summary>
    /// Enumeration type for the various axis types that are available
    /// </summary>
    /// <seealso cref="Axis.Type"/>
    public enum AxisType
    {
        /// <summary> An ordinary, cartesian axis </summary>
        Linear,
       
    }
      /// <summary>
    /// Enumeration type for the different horizontal text alignment options
    /// </summary>
    /// <seealso cref="FontSpec"/>
    public enum AlignH
    {
        /// <summary>
        /// Position the text so that its left edge is aligned with the
        /// specified X,Y location.  Used by the
        /// <see cref="FontSpec.Draw(Graphics,PaneBase,string,float,float,AlignH,AlignV,float)"/> method.
        /// </summary>
        Left,
        /// <summary>
        /// Position the text so that its center is aligned (horizontally) with the
        /// specified X,Y location.  Used by the
        /// <see cref="FontSpec.Draw(Graphics,PaneBase,string,float,float,AlignH,AlignV,float)"/> method.
        /// </summary>
        Center,
        /// <summary>
        /// Position the text so that its right edge is aligned with the
        /// specified X,Y location.  Used by the
        /// <see cref="FontSpec.Draw(Graphics,PaneBase,string,float,float,AlignH,AlignV,float)"/> method.
        /// </summary>
        Right
    }
    /// <summary>
    /// Enumeration type for the different vertical text alignment options
    /// </summary>
    /// specified X,Y location.  Used by the
    /// <see cref="FontSpec.Draw(Graphics,PaneBase,string,float,float,AlignH,AlignV,float)"/> method.
    public enum AlignV
    {
        /// <summary>
        /// Position the text so that its top edge is aligned with the
        /// specified X,Y location.  Used by the
        /// <see cref="FontSpec.Draw(Graphics,PaneBase,string,float,float,AlignH,AlignV,float)"/> method.
        /// </summary>
        Top,
        /// <summary>
        /// Position the text so that its center is aligned (vertically) with the
        /// specified X,Y location.  Used by the
        /// <see cref="FontSpec.Draw(Graphics,PaneBase,string,float,float,AlignH,AlignV,float)"/> method.
        /// </summary>
        Center,
        /// <summary>
        /// Position the text so that its bottom edge is aligned with the
        /// specified X,Y location.  Used by the
        /// <see cref="FontSpec.Draw(Graphics,PaneBase,string,float,float,AlignH,AlignV,float)"/> method.
        /// </summary>
        Bottom
    }
    /// <summary>
    /// Enumeration type for the user-defined coordinate types available.
    /// These coordinate types are used the <see cref="ArrowObj"/> objects
    /// and <see cref="TextObj"/> objects only.
    /// </summary>
    /// <seealso cref="Location.CoordinateFrame"/>
    public enum CoordType
    {
        /// <summary>
        /// Coordinates are specified as a fraction of the
        /// <see cref="Chart.Rect"/>.  That is, for the X coordinate, 0.0
        /// is at the left edge of the ChartRect and 1.0
        /// is at the right edge of the ChartRect. A value less
        /// than zero is left of the ChartRect and a value
        /// greater than 1.0 is right of the ChartRect.  For the Y coordinate, 0.0
        /// is the top and 1.0 is the bottom.
        /// </summary>
        ChartFraction,
        /// <summary>
        /// Coordinates are specified as a fraction of the
        /// <see cref="PaneBase.Rect"/>.  That is, for the X coordinate, 0.0
        /// is at the left edge of the Rect and 1.0
        /// is at the right edge of the Rect. A value less
        /// than zero is left of the Rect and a value
        /// greater than 1.0 is right of the Rect.  For the Y coordinate, 0.0
        /// is the top and 1.0 is the bottom.  Note that
        /// any value less than zero or greater than 1.0 will be outside
        /// the Rect, and therefore clipped.
        /// </summary>
        PaneFraction,
        /// <summary>
        /// Coordinates are specified according to the user axis scales
        /// for the <see cref="GraphPane.XAxis"/> and <see cref="GraphPane.YAxis"/>.
        /// </summary>
        AxisXYScale,
        /// <summary>
        /// The X coordinate is specified as a fraction of the <see cref="Chart.Rect"/>,
        /// and the Y coordinate is specified as a fraction of the <see cref="PaneBase.Rect" />.
        /// </summary>
        /// <remarks>
        /// For the X coordinate, 0.0
        /// is at the left edge of the ChartRect and 1.0
        /// is at the right edge of the ChartRect. A value less
        /// than zero is left of the ChartRect and a value
        /// greater than 1.0 is right of the ChartRect.  For the Y coordinate, a value of zero is at
        /// the left side of the pane, and a value of 1.0 is at the right side of the pane.
        /// </remarks>
        XChartFractionYPaneFraction,
        /// <summary>
        /// The X coordinate is specified as a fraction of the <see cref="PaneBase.Rect"/>,
        /// and the Y coordinate is specified as a fraction of the <see cref="Chart.Rect" />.
        /// </summary>
        /// <remarks>
        /// For the X coordinate, a value of zero is at
        /// the left side of the pane, and a value of 1.0 is at the right side of the pane.
        /// For the Y coordinate, 0.0
        /// is at the top edge of the ChartRect and 1.0
        /// is at the bottom edge of the ChartRect. A value less
        /// than zero is above the ChartRect and a value
        /// greater than 1.0 is below the ChartRect.
        /// </remarks>
        XPaneFractionYChartFraction,
        /// <summary>
        /// The X coordinate is specified as an X Scale value, and the Y coordinate
        /// is specified as a fraction of the <see cref="Chart.Rect"/>.
        /// </summary>
        /// <remarks>
        /// For the X coordinate, the value just corresponds to the values of the X scale.
        /// Values outside the scale range will be
        /// outside the <see cref="Chart.Rect" />.  For the Y coordinate, 0.0
        /// is at the top edge of the ChartRect and 1.0
        /// is at the bottom edge of the ChartRect. A value less
        /// than zero is above the ChartRect and a value
        /// greater than 1.0 is below the ChartRect.
        /// </remarks>
        XScaleYChartFraction,
        /// <summary>
        /// The X coordinate is specified as a fraction of the
        /// <see cref="Chart.Rect"/> and the Y coordinate is specified as
        /// a Y scale value.
        /// </summary>
        /// <remarks>
        /// For the X coordinate, 0.0
        /// is at the left edge of the ChartRect and 1.0
        /// is at the right edge of the ChartRect. A value less
        /// than zero is left of the ChartRect and a value
        /// greater than 1.0 is right of the ChartRect.  For the Y coordinate, the value just
        /// corresponds to the values of the Y scale.  Values outside the scale range will be
        /// outside the <see cref="Chart.Rect" />.
        /// </remarks>
        XChartFractionYScale,
    }
    /// <summary>
    /// Define the auto layout options for the
    /// <see cref="MasterPane.SetLayout(Graphics,PaneLayout)"/> method.
    /// </summary>
    public enum PaneLayout
    {
        /// <summary>
        /// Layout the <see cref="GraphPane"/>'s so they are in a square grid (always 2x2, 3x3, 4x4),
        /// leaving blank spaces as required.
        /// </summary>
        /// <remarks>For example, a single pane would generate a 1x1 grid, between 2 and 4 panes would generate
        /// a 2x2 grid, 5 to 9 panes would generate a 3x3 grid.</remarks>
        ForceSquare,
        /// <summary>
        /// Layout the <see cref="GraphPane"/>'s so they are in a general square (2x2, 3x3, etc.), but use extra
        /// columns when necessary (row x column = 1x2, 2x3, 3x4, etc.) depending on the total number
        /// of panes required.
        /// </summary>
        /// <remarks>For example, a 2x2 grid has four panes and a 3x3 grid has 9 panes.  If there are
        /// 6 panes required, then this option will eliminate a row (column preferred) to make a
        /// 2 row x 3 column grid.  With 7 panes, it will make a 3x3 grid with 2 empty spaces.</remarks>
        SquareColPreferred,
        /// <summary>
        /// Layout the <see cref="GraphPane"/>'s so they are in a general square (2x2, 3x3, etc.), but use extra
        /// rows when necessary (2x1, 3x2, 4x3, etc.) depending on the total number of panes required.
        /// </summary>
        /// <remarks>For example, a 2x2 grid has four panes and a 3x3 grid has 9 panes.  If there are
        /// 6 panes required, then this option will eliminate a column (row preferred) to make a
        /// 3 row x 2 column grid.  With 7 panes, it will make a 3x3 grid with 2 empty spaces.</remarks>
        SquareRowPreferred,
        /// <summary>
        /// Layout the <see cref="GraphPane"/>'s in a single row
        /// </summary>
        SingleRow,
        /// <summary>
        /// Layout the <see cref="GraphPane"/>'s in a single column
        /// </summary>
        SingleColumn,
        /// <summary>
        /// Layout the <see cref="GraphPane"/>'s with an explicit number of columns: The first row has
        /// 1 column and the second row has 2 columns for a total of 3 panes.
        /// </summary>
        ExplicitCol12,
        /// <summary>
        /// Layout the <see cref="GraphPane"/>'s with an explicit number of columns: The first row has
        /// 2 columns and the second row has 1 column for a total of 3 panes.
        /// </summary>
        ExplicitCol21,
        /// <summary>
        /// Layout the <see cref="GraphPane"/>'s with an explicit number of columns: The first row has
        /// 2 columns and the second row has 3 columns for a total of 5 panes.
        /// </summary>
        ExplicitCol23,
        /// <summary>
        /// Layout the <see cref="GraphPane"/>'s with an explicit number of columns: The first row has
        /// 3 columns and the second row has 2 columns for a total of 5 panes.
        /// </summary>
        ExplicitCol32,
        /// <summary>
        /// Layout the <see cref="GraphPane"/>'s with an explicit number of rows: The first column has
        /// 1 row and the second column has 2 rows for a total of 3 panes.
        /// </summary>
        ExplicitRow12,
        /// <summary>
        /// Layout the <see cref="GraphPane"/>'s with an explicit number of rows: The first column has
        /// 2 rows and the second column has 1 row for a total of 3 panes.
        /// </summary>
        ExplicitRow21,
        /// <summary>
        /// Layout the <see cref="GraphPane"/>'s with an explicit number of rows: The first column has
        /// 2 rows and the second column has 3 rows for a total of 5 panes.
        /// </summary>
        ExplicitRow23,
        /// <summary>
        /// Layout the <see cref="GraphPane"/>'s with an explicit number of rows: The first column has
        /// 3 rows and the second column has 2 rows for a total of 5 panes.
        /// </summary>
        ExplicitRow32
    }

}
