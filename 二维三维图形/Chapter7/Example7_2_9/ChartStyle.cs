using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace Example7_2_9
{
    public class ChartStyle
    {
        #region Variables

        private Form1 form1;
        private Font tickFont = new Font("Arial Narrow", 8, FontStyle.Regular);
        private Color tickColor = Color.Black;
        private bool isColorBar = false;
        #endregion

        #region Constructors

        public ChartStyle(Form1 fm1)
        {
            form1 = fm1;
        }
        #endregion

        #region Properties

        public bool IsColorBar
        {
            get { return isColorBar; }
            set { isColorBar = value; }
        }
        public Font TickFont
        {
            get { return tickFont; }
            set { tickFont = value; }
        }
        public Color TickColor
        {
            get { return tickColor; }
            set { tickColor = value; }
        }
        #endregion

        #region Methods
        #endregion
    }
}
