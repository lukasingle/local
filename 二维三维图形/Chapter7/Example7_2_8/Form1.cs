using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;
using System.Threading;
namespace Example7_2_8
{
    public partial class Form1 : Form
    {
        #region Variables
        private StreamReader myStreamReader;

        private string[] axArray = new string[2];
        private string[] ayArray = new string[2];
        private string[] azArray = new string[2];
        private string readString, showRead;
        private float BarMaxData, BarMinData;
        private float MaxData, MinData;
        private float alpha = 35;
        private float beta = 45;

        private float xc = -10;
        private float yc = -20;
        private float zc = 0;
        private ColorMap cm;
        private ChartStyle cs;
        private DrawSphere ds;
        private Graphics g = null;
        private Graphics gc = null;
        private int[,] colortype;

        private int Th = 45;
        private decimal cmin = 0, cmax = 100;       
        #endregion

        #region Constructors
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
                       
        }
        #endregion

        #region Methods
        private void ChangeAz()
        {
            for (int i = 0; i < azArray.Length; i++)
            {
                if (azArray[i] != "")
                {
                    float temp = float.Parse(azArray[i]);
                    temp = temp - MinData;
                    azArray[i] = temp.ToString();
                }
            }
        }

        private float GetMaxdatafrom(string[] azarray)
        {
            float temp = -1000.0f;
            for (int i = 0; i < azarray.Length; i++)
            {
                if (azarray[i] != "")
                {
                    float max = float.Parse(azarray[i]);
                    if (max > temp)
                    {
                        temp = max;
                    }

                }
            }
            return temp;
        }
        private float GetMindatafrom(string[] azarray)
        {
            float temp = 1000.0f;
            for (int i = 0; i < azarray.Length; i++)
            {
                if (azarray[i] != "")
                {
                    float min = float.Parse(azarray[i]);
                    if (min < temp)
                    {
                        temp = min;
                    }
                }
            }
            return temp;
        }
        private void DrawPlot(int[,] colortype)
        {
            g = panel1.CreateGraphics();
            g.Clear(panel1.BackColor);
            
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float a = panel1.Height;
            float scale = (a - 150.0f) / MaxData;
            if (scale > 7.0f)
            {
                scale = 7.0f;
            }

            ds = new DrawSphere(this, MaxData, xc, yc, zc);

            ds.CMap = colortype;
            ds.IsLineVisable = false;
            ds.IsSurface = true;
            Point3[,] pts = ds.CalcuData(axArray, ayArray, azArray, scale);
            ds.DrawIsometricView(g, pts, azArray, alpha, beta, MinData, MaxData);
        }
        private void DrawColorBar()
        {
            gc = panel1.CreateGraphics();
            ds = new DrawSphere(this, MaxData, xc, yc, zc);
            ds.CMap = colortype;// cm.Rainbow(Th);
            ds.AddColorBar(gc, cs, BarMinData, BarMaxData);
        }
        private void panel1Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float a = panel1.Height;
            float scale = (a - 150.0f) / MaxData;
            if (scale > 7.0f)
            {
                scale = 7.0f;
            }

            cs = new ChartStyle(this);
            cs.IsColorBar = true;
            DrawSphere ds = new DrawSphere(this, MaxData, xc, yc, zc);

            ds.CMap = cm.Rainbow(Th);
            ds.IsLineVisable = false;
            ds.IsSurface = true;
            Point3[,] pts = ds.CalcuData(axArray, ayArray, azArray, scale);
            ds.DrawIsometricView(g, pts, azArray, alpha, beta, MinData, MaxData);
            ds.AddColorBar(g, cs, BarMinData, BarMaxData);
        }

        private void ReadFile(string filename, ref string[] valuearray)
        {
            readString = "";
            showRead = "";
            try
            {
                myStreamReader = File.OpenText(filename);
                do
                {
                    readString = myStreamReader.ReadLine();
                    showRead += readString + "\t";
                } while (readString != null);
                //add value to string array
                valuearray = showRead.Split("\t".ToCharArray());
            }
            catch (Exception exc)
            {
                MessageBox.Show("File can not open or no exist. " + exc.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                if (myStreamReader != null)
                {
                    myStreamReader.Close();
                }

            }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            //Read txt file and get array
            ReadFile("theta.txt", ref axArray);
            ReadFile("phi.txt", ref ayArray);
            ReadFile("pds.txt", ref azArray);

            //Get max and min value of azarray
            BarMaxData = GetMaxdatafrom(azArray);
            BarMinData = GetMindatafrom(azArray);


            MaxData = GetMaxdatafrom(azArray);
            MinData = GetMindatafrom(azArray);

            ChangeAz();
            MaxData = GetMaxdatafrom(azArray);
            MinData = GetMindatafrom(azArray);

            cm = new ColorMap();
            cs = new ChartStyle(this);
            cs.IsColorBar = true;
            colortype = cm.Rainbow(Th);
            g = panel1.CreateGraphics();
            panel1.Paint +=
                new PaintEventHandler(panel1Paint);
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            DrawPlot(colortype);
            DrawColorBar();
        }

        private void numericUpDownAlpha_ValueChanged(object sender, EventArgs e)
        {
            alpha =(float) numericUpDownAlpha.Value;
            DrawPlot(colortype);
            DrawColorBar();
        }

        private void numericUpDownBeta_ValueChanged(object sender, EventArgs e)
        {
            beta = (float)numericUpDownBeta.Value;
            DrawPlot(colortype);
            DrawColorBar();
        }

        private void txtxc_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtxc.Text == "-")
            {
            }
            else
            {
                xc = float.Parse(txtxc.Text);
                DrawPlot(colortype);
                DrawColorBar();
            }

        }

        private void txtyc_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtyc.Text == "-")
            {
            }
            else
            {
                yc = float.Parse(txtyc.Text);
                DrawPlot(colortype);
                DrawColorBar();
            }
        }

        private void btnrotate_Click(object sender, EventArgs e)
        {
            int i;
            

            for (i = 0; i < 360; i+=5)
            {

                beta = (float)i;
                DrawPlot(colortype);
                DrawColorBar();
            }
            //DrawColorBar();

        }

        

    }
}