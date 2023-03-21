using System;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Excel;

namespace Example9_3_3
{
    public partial class Form1 : Form
    {
        private Excel.Application xla;
        private object missing = Missing.Value;

        public Form1()
        {
            InitializeComponent();
            xla = new Excel.Application();
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            xla.Visible = true;

            string filePath = Directory.GetCurrentDirectory().ToString();
            string fileName = filePath + "\\Test.txt";
            //xla.Workbooks.OpenText(fileName, missing, 1, missing,
            //    XlTextQualifier.xlTextQualifierNone, true, missing, 
            //    missing, missing, missing, missing, missing, missing,
            //    missing, missing, missing, missing, missing);

            xla.Workbooks.OpenText(fileName, missing, 1, missing,
                XlTextQualifier.xlTextQualifierDoubleQuote, true, missing,
                missing, missing, missing, missing, missing, missing, missing,
                missing, missing);

           // Now create the stock chart.
            Worksheet ws = (Worksheet)xla.ActiveSheet;
            ChartObjects chartObjs = (ChartObjects)ws.ChartObjects(Type.Missing);
            ChartObject chartObj = chartObjs.Add(100, 20, 300, 300);
            Chart xlChart = chartObj.Chart;

            Range rg = ws.get_Range("A1", "E20");
            xlChart.SetSourceData(rg, XlRowCol.xlColumns);
            xlChart.ChartType = XlChartType.xlStockOHLC;


            // Customize axes:
            Axis xAxis = (Axis)xlChart.Axes(XlAxisType.xlCategory,
                XlAxisGroup.xlPrimary);
            xAxis.HasMajorGridlines = true;
            xAxis.HasTitle = true;
            xAxis.AxisTitle.Text = "Time";

            Axis yAxis = (Axis)xlChart.Axes(XlAxisType.xlValue, 
                XlAxisGroup.xlPrimary);
            yAxis.HasMajorGridlines = true;
            yAxis.CrossesAt = -1.5;
            yAxis.HasTitle = true;
            yAxis.AxisTitle.Text = "Stock Price ($)";

            // Add title:
            xlChart.HasTitle = true;
            xlChart.ChartTitle.Text = "XXXX Stock Price";

            // Change default background color of the plot area to white:
            xlChart.PlotArea.Interior.ColorIndex = 2;

            // Remove legend:
            xlChart.HasLegend = false;
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