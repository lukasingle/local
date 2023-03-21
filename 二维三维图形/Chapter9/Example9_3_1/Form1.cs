using System;
using System.Windows.Forms;
using Excel;

namespace Example9_3_1
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
            ChartObject chartObj = chartObjs.Add(100, 20, 300, 200);
            Chart xlChart = chartObj.Chart;

            //int nRows = 25;
            int nRows = 6;
            int nColumns = 3;
            string upperLeftCell = "A2";
            int endRowNumber = System.Int32.Parse(upperLeftCell.Substring(1)) 
                + nRows - 1;
            char endColumnLetter = System.Convert.ToChar(
                Convert.ToInt32(upperLeftCell[0]) + nColumns - 1);
            string upperRightCell = System.String.Format("{0}{1}", 
                endColumnLetter, System.Int32.Parse(upperLeftCell.Substring(1)));
            string lowerRightCell = System.String.Format("{0}{1}", 
                endColumnLetter, endRowNumber);
            Range rg = ws.get_Range(upperLeftCell,lowerRightCell);
            rg.Value2 = AddData(nRows,nColumns);

            ws.Cells[1, 1] = "Year";
            ws.Cells[1, 2] = "Revenue";
            ws.Cells[1, 3] = "Profit";
            Range rgn = ws.get_Range("A1", "C7");

            //xlChart.ChartType = XlChartType.xlColumnClustered;
            //xlChart.SetSourceData(rg, Type.Missing);
            xlChart.ChartWizard(rgn.CurrentRegion, Constants.xlColumn,
                Type.Missing, Type.Missing, 1, 1,
                true, "Revenue & Profit",
                Type.Missing, Type.Missing, Type.Missing);

            Axis xAxis = (Axis)xlChart.Axes(XlAxisType.xlCategory,
                XlAxisGroup.xlPrimary);
            xAxis.HasTitle = true;
            xAxis.AxisTitle.Text = "Year";
       
            Axis yAxis = (Axis)xlChart.Axes(XlAxisType.xlValue,
                XlAxisGroup.xlPrimary);
            yAxis.HasTitle = true;
            yAxis.AxisTitle.Text = "Dollars (M)";        
        }

        private double[,] AddData(int nRows, int nColumns)
        {
            double[,] dataArray = new double[nRows, nColumns];
            dataArray[0, 0] = 2001;
            dataArray[1, 0] = 2002;
            dataArray[2, 0] = 2003;
            dataArray[3, 0] = 2004;
            dataArray[4, 0] = 2005;
            dataArray[5, 0] = 2006;
            dataArray[0, 1] = 5;
            dataArray[1, 1] = 11;
            dataArray[2, 1] = 7;
            dataArray[3, 1] = 14;
            dataArray[4, 1] = 16;
            dataArray[5, 1] = 18;
            dataArray[0, 2] = 1.8;
            dataArray[1, 2] = 4.2;
            dataArray[2, 2] = 2.7;
            dataArray[3, 2] = 6.5;
            dataArray[4, 2] = 7.1;
            dataArray[5, 2] = 7.8;
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