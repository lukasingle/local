using System;
using System.Windows.Forms;
using System.Reflection;
using interop = System.Runtime.InteropServices;
using Excel;

namespace Example9_3_2
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

            // Now create the chart.
            ChartObjects chartObjs = (ChartObjects)ws.ChartObjects(Type.Missing);
            ChartObject chartObj = chartObjs.Add(100, 20, 300, 200);
            Chart xlChart = chartObj.Chart;

            ////Create Pie chart
            //ws.Cells[1, 1] = "Soc. Sec. Tax";
            //ws.Cells[2, 1] = "Income Tax";
            //ws.Cells[3, 1] = "Brorrowing";
            //ws.Cells[4, 1] = "Corp. Tax";
            //ws.Cells[5, 1] = "Misc.";
            //ws.Cells[1, 2] = 30;
            //ws.Cells[2, 2] = 36;
            //ws.Cells[3, 2] = 19;
            //ws.Cells[4, 2] = 5;
            //ws.Cells[5, 2] = 10;

            //Range rg = ws.get_Range("A1", "B5");

            //xlChart.ChartType = XlChartType.xlPie;


            ws.Cells[1, 1] = 2;
            ws.Cells[2, 1] = 4;
            ws.Cells[3, 1] = 2.3;
            ws.Cells[4, 1] = 5;
            ws.Cells[5, 1] = 6.5;
            ws.Cells[6, 1] = 3.5;
            ws.Cells[1, 2] = 1;
            ws.Cells[2, 2] = 3;
            ws.Cells[3, 2] = 1.3;
            ws.Cells[4, 2] = 4;
            ws.Cells[5, 2] = 5.5;
            ws.Cells[6, 2] = 2.5;

            Range rg = ws.get_Range("A1", "B6");

            ////Create Area chart
            //xlChart.ChartType = XlChartType.xlArea;

            ////Create Doughnut Chart
            //xlChart.ChartType = XlChartType.xlDoughnut;

            xlChart.SetSourceData(rg, Type.Missing);


            //Create Radar chart
            xlChart.ChartType = XlChartType.xlRadarFilled;
            xlChart.PlotArea.Interior.ColorIndex = 2;
            xlChart.PlotArea.Border.ColorIndex = 2;
          
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