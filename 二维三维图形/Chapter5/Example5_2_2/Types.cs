using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace Example5_2_2
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
    /// Enumeration type that defines the possible legend locations
    /// </summary>
    /// <seealso cref="Legend.Position"/>
    public enum LegendPos
    {
        /// <summary>
        /// Locate the <see cref="Legend"/> above the <see cref="Chart.Rect"/>
        /// </summary>
        Top,
        /// <summary>
        /// Locate the <see cref="Legend"/> on the left side of the <see cref="Chart.Rect"/>
        /// </summary>
        Left,
        /// <summary>
        /// Locate the <see cref="Legend"/> on the right side of the <see cref="Chart.Rect"/>
        /// </summary>
        Right,
        /// <summary>
        /// Locate the <see cref="Legend"/> below the <see cref="Chart.Rect"/>
        /// </summary>
        Bottom,
        /// <summary>
        /// Locate the <see cref="Legend"/> inside the <see cref="Chart.Rect"/> in the
        /// top-left corner.  
        /// </summary>
        InsideTopLeft,
        /// <summary>
        /// Locate the <see cref="Legend"/> inside the <see cref="Chart.Rect"/> in the
        /// top-right corner. 
        /// </summary>
        InsideTopRight,
        /// <summary>
        /// Locate the <see cref="Legend"/> inside the <see cref="Chart.Rect"/> in the
        /// bottom-left corner.
        /// </summary>
        InsideBotLeft,
        /// <summary>
        /// Locate the <see cref="Legend"/> inside the <see cref="Chart.Rect"/> in the
        /// bottom-right corner. 
        /// </summary>
        InsideBotRight,
        /// <summary>
        /// Locate the <see cref="Legend"/> as a floating object above the graph at the
        /// location specified by <see cref="Legend.Location"/>.
        /// </summary>
        Float,
        /// <summary>
        /// Locate the <see cref="Legend"/> centered above the <see cref="Chart.Rect"/>
        /// </summary>
        TopCenter,
        /// <summary>
        /// Locate the <see cref="Legend"/> centered below the <see cref="Chart.Rect"/>
        /// </summary>
        BottomCenter,
        /// <summary>
        /// Locate the <see cref="Legend"/> above the <see cref="Chart.Rect"/>, but flush
        /// against the left margin of the <see cref="PaneBase.Rect" />.
        /// </summary>
        TopFlushLeft,
        /// <summary>
        /// Locate the <see cref="Legend"/> below the <see cref="Chart.Rect"/>, but flush
        /// against the left margin of the <see cref="PaneBase.Rect" />.
        /// </summary>
        BottomFlushLeft

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
    /// Enumeration type for the different proximal alignment options
    /// </summary>
    /// <seealso cref="FontSpec"/>
    /// <seealso cref="Scale.Align"/>
    public enum AlignP
    {
        /// <summary>
        /// Position the text so that its "inside" edge (the edge that is
        /// nearest to the alignment reference point or object) is aligned.
        /// Used by the <see cref="Scale.Align"/> method to align text
        /// to the axis.
        /// </summary>
        Inside,
        /// <summary>
        /// Position the text so that its center is aligned with the
        /// reference object or point.
        /// Used by the <see cref="Scale.Align"/> method to align text
        /// to the axis.
        /// </summary>
        Center,
        /// <summary>
        /// Position the text so that its right edge (the edge that is
        /// farthest from the alignment reference point or object) is aligned.
        /// Used by the <see cref="Scale.Align"/> method to align text
        /// to the axis.
        /// </summary>
        Outside
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
    /// Enumeration type that defines the available types of <see cref="LineItem"/> graphs.
    /// </summary>
    /// <seealso cref="GraphPane.LineType"/>
    public enum LineType
    {
        /// <summary>
        /// Draw the lines as normal.  Any fill area goes from each line down to the X Axis.
        /// </summary>
        Normal,
        /// <summary>
        /// Draw the lines stacked on top of each other, accumulating values to a total value.
        /// </summary>
        Stack
    }
    
    /// <summary>
    /// Enumeration type that defines which set of data points - X or Y - is used  
    /// <seealso cref="System.Collections.ArrayList.Sort()"/> to perform the sort.
    /// </summary>
    public enum SortType
    {
        /// <summary>
        /// Use the Y values to sort the list.
        /// </summary>
        YValues,
        /// <summary>
        /// Use the X values to sort the list.
        /// </summary>
        XValues
    };
    /// <summary>
    /// Enumeration that specifies a Z-Order position for <see cref="GraphObj"/>
    /// objects.
    /// </summary>
    /// <remarks>This enumeration allows you to set the layering of various graph
    /// features.  Except for the <see cref="GraphObj"/> objects, other feature types
    /// all have a fixed depth as follows (front to back):
    /// <list>
    /// <see cref="Legend"/> objects
    /// The border around <see cref="Chart.Rect"/>
    /// <see cref="CurveItem"/> objects
    /// The <see cref="Axis"/> features
    /// The background fill of the <see cref="Chart.Rect"/>
    /// The pane <see cref="PaneBase.Title"/>
    /// The background fill of the <see cref="PaneBase.Rect"/>
    /// </list>
    /// You cannot place anything behind the <see cref="PaneBase.Rect"/>
    /// background fill, but <see cref="GraphObj.ZOrder"/> allows you to
    /// explicitly control the depth of <see cref="GraphObj"/> objects
    /// between all other object types.  For items of equal <see cref="ZOrder"/>,
    /// such as multiple <see cref="CurveItem"/>'s or <see cref="GraphObj"/>'s
    /// having the same <see cref="ZOrder"/> value, the relative depth is
    /// controlled by the ordinal position in the list (either
    /// <see cref="CurveList"/> or <see cref="GraphObjList"/>).
    /// <see cref="GraphObj"/> objects
    /// can be placed in the <see cref="GraphObjList"/> of either a
    /// <see cref="GraphPane"/> or a <see cref="MasterPane"/>.  For a
    /// <see cref="GraphPane"/>-based <see cref="GraphObj"/>, all <see cref="ZOrder"/>
    /// values are applicable.  For a <see cref="MasterPane"/>-based
    /// <see cref="GraphObj"/>, any <see cref="ZOrder"/> value can be used, but there
    /// are really only three depths:
    /// <list><see cref="ZOrder.H_BehindAll"/> will place the item behind the pane title,
    /// <see cref="ZOrder.A_InFront"/> will place on top of all other graph features,
    /// any other value places the object above the pane title, but behind the <see cref="GraphPane"/>'s.
    /// </list>
    /// </remarks>
    public enum ZOrder
    {
        /// <summary>
        /// Specifies that the <see cref="GraphObj"/> will be behind all other
        /// objects (including the <see cref="PaneBase"/> <see cref="PaneBase.Title"/>).
        /// </summary>
        H_BehindAll,
        /// <summary>
        /// Specifies that the <see cref="GraphObj"/> will be behind the
        /// <see cref="Chart.Rect"/> background <see cref="Fill"/>
        /// (see <see cref="Chart.Fill"/>).
        /// </summary>
        G_BehindChartFill,
        /// <summary>
        /// Specifies that the <see cref="GraphObj"/> will be behind the grid lines.
        /// </summary>
        F_BehindGrid,
        /// <summary>
        /// Specifies that the <see cref="GraphObj"/> will be behind the
        /// <see cref="CurveItem"/> objects.
        /// </summary>
        E_BehindCurves,
        /// <summary>
        /// Specifies that the <see cref="GraphObj"/> will be behind the
        /// <see cref="Axis"/> objects.
        /// </summary>
        D_BehindAxis,
        /// <summary>
        /// Specifies that the <see cref="GraphObj"/> will be behind the
        /// <see cref="Chart"/> border.
        /// </summary>
        C_BehindChartBorder,
        /// <summary>
        /// Specifies that the <see cref="GraphObj"/> will be behind the
        /// <see cref="Legend"/> object.
        /// </summary>
        B_BehindLegend,
        /// <summary>
        /// Specifies that the <see cref="GraphObj"/> will be in front of
        /// all other objects, except for the other <see cref="GraphObj"/>
        /// objects that have the same <see cref="ZOrder"/> and are before
        /// this object in the <see cref="GraphObjList"/>.
        /// </summary>
        A_InFront
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
