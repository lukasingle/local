using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace Example8_2_1
{
    /// <summary>
    /// A class handler all methods for drawing cuver on the chart area
    /// </summary>
    /// 
    [Serializable]
    public class DrawChart
    {
        #region Variables

        private Form1 form1;
        #endregion

        #region Constructors

        public DrawChart(Form1 fm1)
        {
            form1 = fm1;
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
        protected DrawChart(SerializationInfo info, StreamingContext context)
        {
           
        }
        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> instance with the data needed to serialize the target object
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> instance that defines the serialized data</param>
        /// <param name="context">A <see cref="StreamingContext"/> instance that contains the serialized data</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
          

        }
        #endregion

        #region Methods

        public void AddLine(Graphics g, DataSeries ds, ChartStyle cs)
        {
            Pen aPen = new Pen(ds.LineStyle.LineColor, ds.LineStyle.Thickness);
            aPen.DashStyle = ds.LineStyle.Pattern;
            Matrix3 m = Matrix3.AzimuthElevation(cs.Elevation, cs.Azimuth);
            Point3[] pts = new Point3[ds.PointList.Count];

            for (int i = 0; i < pts.Length; i++)
            {
                pts[i] = (Point3)ds.PointList[i];
                pts[i].Transform(m, form1, cs);
            }

            // Draw line:
            if (ds.LineStyle.IsVisible == true)
            {
                for (int i = 1; i < pts.Length; i++)
                {
                    g.DrawLine(aPen, pts[i - 1].X, pts[i - 1].Y, pts[i].X, pts[i].Y);
                }
                aPen.Dispose();            
            }
        }
        #endregion
    }
}
