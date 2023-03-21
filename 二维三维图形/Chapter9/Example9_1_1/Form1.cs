using System;
using System.Windows.Forms;
using Excel;

namespace Example9_1_1
{
    public partial class Form1 : Form
    {
        Excel.Application xla;

        public Form1()
        {
            InitializeComponent();
            xla = new Excel.Application();
        }

        private void btnStartExcel_Click(object sender, EventArgs e)
        {
            xla.Visible = true;
            Workbook wb = xla.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)xla.ActiveSheet;
            Range rg = (Range)ws.Cells[1, 1];
            rg.Value2 = "Cell1A";
            rg = (Range)ws.Cells[1, 2];
            rg.Value2 = "Cell1B";
            rg = (Range)ws.Cells[1, 3];
            rg.Value2 = "Cell1C";        
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