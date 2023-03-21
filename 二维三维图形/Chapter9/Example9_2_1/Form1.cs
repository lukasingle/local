using System;
using System.Windows.Forms;
using System.Reflection;
using interop = System.Runtime.InteropServices;
using Excel;

namespace Example9_2_1
{
    public partial class Form1 : Form
    {
        private Excel.Application xla;

        public Form1()
        {
            InitializeComponent();
            xla = new Excel.Application();
        }

        private object missing = Missing.Value;

        private void btnPlot_Click(object sender, EventArgs e)
        {
            xla.Visible = true;
            Workbook wb = xla.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)xla.ActiveSheet;

            // Create a stand-alone Excel chart:
            Chart xlChart = (Chart)wb.Charts.Add(Type.Missing, ws,
                Type.Missing, Type.Missing);

            int nRows = 25;
            int nColumns = 3;
            string upperLeftCell = "A1";
            int endRowNumber = System.Int32.Parse(upperLeftCell.Substring(1))
                + nRows - 1;
            char endColumnLetter = System.Convert.ToChar(
                Convert.ToInt32(upperLeftCell[0]) + nColumns - 1);
            string upperRightCell = System.String.Format("{0}{1}",
                endColumnLetter, System.Int32.Parse(upperLeftCell.Substring(1)));
            string lowerRightCell = System.String.Format("{0}{1}",
                endColumnLetter, endRowNumber);
            Range rg = ws.get_Range(upperLeftCell, lowerRightCell);
            rg.Value2 = AddData(nRows, nColumns);
            xlChart.ChartType = XlChartType.xlXYScatterLines;
            xlChart.SetSourceData(rg, XlRowCol.xlColumns);

            //Customize axes
            Axis xAxis = (Axis)xlChart.Axes(XlAxisType.xlCategory,
                XlAxisGroup.xlPrimary);
            xAxis.HasMajorGridlines = true;
            xAxis.MaximumScale = 8;
            xAxis.HasTitle = true;
            xAxis.AxisTitle.Text = "X Axis";

            Axis yAxis = (Axis)xlChart.Axes(XlAxisType.xlValue, XlAxisGroup.xlPrimary);
            yAxis.HasMajorGridlines = true;
            yAxis.CrossesAt = -1.5;
            yAxis.HasTitle = true;
            yAxis.AxisTitle.Text = "Y Axis";

            //Add title
            xlChart.HasTitle = true;
            xlChart.ChartTitle.Text = "Sin(X) and Cos(X) vs X";
            //Customize legend
            xlChart.HasLegend = true;
            xlChart.Legend.Position = XlLegendPosition.xlLegendPositionCorner;
            xlChart.Legend.Shadow = true;
            xlChart.Legend.Interior.ColorIndex = 20;
        }

        private double[,] AddData(int nRows, int nColumns)
        {
            double[,] dataArray = new double[nRows, nColumns];
            for (int i = 0; i < nRows; i++)
            {
                double x = i / 3.0;
                dataArray[i, 0] = x;
                dataArray[i, 1] = Math.Sin(x);
                dataArray[i, 2] = Math.Cos(x);
            }
            return dataArray;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            xla.DisplayAlerts = false;
            if (xla != null)
            {
                xla.Quit();
                xla = null;
            }
            this.Close();
        }
    }
}