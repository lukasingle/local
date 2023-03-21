using System;
using System.Collections;
using System.Drawing;
using System.Runtime.Serialization;
namespace Example8_2_1
{
    /// <summary>
    /// Class that handle to save data that be draw on chart aera 
    /// </summary>
    /// 
    [Serializable]
    public class DataSeries : ICloneable, ISerializable
    {
        #region Variables

        private ArrayList _mpointList;
        private LineStyle _mlineStyle;
        #endregion

        #region Constructors
        public DataSeries()
        {
            _mlineStyle = new LineStyle();
            _mpointList = new ArrayList();
        }
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// 
        public DataSeries(DataSeries rhs)
        {
            _mpointList = rhs._mpointList;
            _mlineStyle = rhs._mlineStyle;
        }
        /// <summary>
        /// Implement the <see cref="ICloneable" /> interface in a typesafe manner by just
        /// calling the typed version of <see cref="Clone" />
        /// </summary>
        /// <returns>A deep copy of this object</returns>
        object ICloneable.Clone()
        {
            return new DataSeries(this);
        }
        #endregion

        #region Properties
        public LineStyle LineStyle
        {
            get { return _mlineStyle; }
            set { _mlineStyle = value; }
        }

        public ArrayList PointList
        {
            get { return _mpointList; }
            set { _mpointList = value; }
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
        protected DataSeries(SerializationInfo info, StreamingContext context)
        {
            _mlineStyle = (LineStyle)info.GetValue("lineStyle", typeof(LineStyle));
        }
        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> instance with the data needed to serialize the target object
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> instance that defines the serialized data</param>
        /// <param name="context">A <see cref="StreamingContext"/> instance that contains the serialized data</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("lineStyle", _mlineStyle);
        }
        #endregion

        #region Methods
        public void AddPoint(Point3 pt)
        {
            PointList.Add(pt);
        }
        #endregion
    }
}

