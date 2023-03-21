using System;
using System.Windows.Forms;
using Excel;

namespace Example9_3_5
{
    public partial class Form1 : Form
    {
        private Excel.Application xla;

        public Form1()
        {
            InitializeComponent();
            xla = new Excel.Application();
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            xla.Visible = true;
            Workbook wb = xla.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)xla.ActiveSheet;

           // Now create the chart.
            ChartObjects chartObjs = (ChartObjects)ws.ChartObjects(Type.Missing);
            ChartObject chartObj = chartObjs.Add(100, 20, 300, 300);
            Chart xlChart = chartObj.Chart;

            int nRows = 25;
            int nColumns = 25;
            string upperLeftCell = "B3";
            int endRowNumber = System.Int32.Parse(upperLeftCell.Substring(1)) 
                + nRows - 1;
            char endColumnLetter = System.Convert.ToChar(
                Convert.ToInt32(upperLeftCell[0]) + nColumns - 1);
            string upperRightCell = System.String.Format("{0}{1}", 
                endColumnLetter, System.Int32.Parse(upperLeftCell.Substring(1)));
            string lowerRightCell = System.String.Format("{0}{1}", 
                endColumnLetter, endRowNumber);

            // Send single dimensional array to Excel:
            Range rg1 = ws.get_Range("B2", "Z2");
            double[] xarray = new double[nColumns];
            ws.Cells[1, 1] = "Data for surface chart";
            for (int i = 0; i < xarray.Length; i++)
            {
                xarray[i] = -3.0f + i * 0.25f;
                ws.Cells[i + 3, 1] = xarray[i];
                ws.Cells[2, 2 + i] = xarray[i];
            }

            Range rg = ws.get_Range(upperLeftCell, lowerRightCell);
            rg.Value2 = AddData(nRows,nColumns);

            Range chartRange = ws.get_Range("A2", lowerRightCell);
            xlChart.SetSourceData(chartRange, Type.Missing);
            xlChart.ChartType = XlChartType.xlSurface;

            // Customize axes:
            Axis xAxis = (Axis)xlChart.Axes(XlAxisType.xlCategory,
                XlAxisGroup.xlPrimary);
            xAxis.HasTitle = true;
            xAxis.AxisTitle.Text = "X Axis";

            Axis yAxis = (Axis)xlChart.Axes(XlAxisType.xlSeriesAxis,
                XlAxisGroup.xlPrimary);
            yAxis.HasTitle = true;
            yAxis.AxisTitle.Text = "Y Axis";

            Axis zAxis = (Axis)xlChart.Axes(XlAxisType.xlValue,
                XlAxisGroup.xlPrimary);
            zAxis.HasTitle = true;
            zAxis.AxisTitle.Text = "Z Axis";
            zAxis.MinimumScale = -8;
            zAxis.MaximumScale = 8;
            zAxis.MajorUnit = 1;

            xlChart.HasLegend = true;
            int[] cm = ColorMap.colorMap();
            int numberOfLegendEntries = Convert.ToInt16((zAxis.MaximumScale 
                - zAxis.MinimumScale) / zAxis.MajorUnit);
            for (int i = 1; i <= numberOfLegendEntries; i++)
            {
                LegendEntry legendEntry = (LegendEntry)xlChart.Legend.LegendEntries(i);
                legendEntry.LegendKey.Interior.ColorIndex = cm[i - 1];
            }
            xlChart.HasLegend = false;
            xlChart.PlotArea.Width = 300;
            xlChart.PlotArea.Height = 300;
        }

        private double[,] AddData(int nRows, int nColumns)
        {
            double[,] dataArray = new double[nRows, nColumns];
            double[] xarray = new double[nColumns];
            for (int i = 0; i < xarray.Length; i++)
            {
                xarray[i] = -3.0f + i * 0.25f;
            }
            double[] yarray = xarray;

            for (int i = 0; i < dataArray.GetLength(0); i++)
            {
                for (int j = 0; j < dataArray.GetLength(1); j++)
                {
                    dataArray[i, j] = 3 * Math.Pow((1 - xarray[i]), 2) 
                        * Math.Exp(-xarray[i] * xarray[i] -
                        (yarray[j] + 1) * (yarray[j] + 1)) - 
                        10 * (0.2 * xarray[i] - Math.Pow(xarray[i], 3) -
                        Math.Pow(yarray[j], 5)) * 
                        Math.Exp(-xarray[i] * xarray[i] - yarray[j] * yarray[j]) 
                        - 1 / 3 * Math.Exp(-(xarray[i] + 1) * (xarray[i] + 1) - 
                        yarray[j] * yarray[j]);
                }
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