using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Example7_2_9
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

        private float xc = 0;
        private float yc = 0;
        private float zc = 0;
        private ColorMap cm;
        private ChartStyle cs;
        private DrawSphere ds;
        private int[,] colortype;

        //Define a graphic variable to graphic
        private Graphics gB;
        private Bitmap bitmap, bm;

        private bool isLeftDrag = false;
        private Point tempXY;
        private Point mouseStartDrag;
        private Point mouseEndDrag;

        private int Th = 45;
        private decimal cmin = 0, cmax = 100;       
        #endregion

        #region Contructors

        public Form1()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.SetStyle(ControlStyles.UserPaint, true);//When this flag is set to true,
            //the control paints itself and is not painted by the system operation

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            this.SetStyle(ControlStyles.DoubleBuffer, true);//when set Control.DoubleBuffered to true, 
            //it will set the ControlStyles.AllPaintingInWmPaint and ControlStyles.OptimizedDoubleBuffer to true           
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            //Define bitmap
            InitialBitmap();
            Color bckColor = this.pcbplot.BackColor;
            gB.Clear(bckColor);

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
            //colortype = cm.Jet();
            cmbcolortype.SelectedIndex = 4;
            RefreshBackground();
        }

        private void btnrotate_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //Cursor mycursor = new Cursor("rotate.cur");
            //Cursor = mycursor;
            btnpan.Enabled = false;
            int i;
            for (i = 0; i <= 360; i += 5)
            {
                Thread.Sleep(50);
                beta = (float)i;
                numericUpDownBeta.Value = i;
                numericUpDownBeta.Refresh();
                //alpha = (float)i;
                //RefreshBackground();
                pcbplot.Refresh();
            }
            Cursor = Cursors.Default;
            btnpan.Enabled = true;
        }

        private void numericUpDownAlpha_ValueChanged(object sender, EventArgs e)
        {
            if (isLeftDrag == false)
            {
                alpha = (float)numericUpDownAlpha.Value;
                RefreshBackground();
            }
        }

        private void numericUpDownBeta_ValueChanged(object sender, EventArgs e)
        {
            if (isLeftDrag == false)
            {
                beta = (float)numericUpDownBeta.Value;
                RefreshBackground();
            }
        }

        private void txtxc_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtxc.Text == "-")
            {
            }
            else
            {
                xc = float.Parse(txtxc.Text);
                RefreshBackground();
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
                RefreshBackground();
            }
        }

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
        private void DrawPlot(int[,] colortype)
        {
            gB.SmoothingMode = SmoothingMode.AntiAlias;
            float a = pcbplot.Height;
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
            ds.DrawIsometricView(gB, pts, azArray, alpha, beta, MinData, MaxData);
            ds.AddColorBar(gB, cs, BarMinData, BarMaxData);
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
        private void InitialBitmap()
        {
            //Define bitmap
            Size size = new Size(pcbplot.Width, pcbplot.Height);
            bitmap = new Bitmap(size.Width, size.Height);
            gB = Graphics.FromImage(bitmap);
        }
       
        private void OnLeftMouseUp(object sender, MouseEventArgs e)
        {
            //isLeftDrag = false;

            numericUpDownAlpha.Value = (int)alpha;
            numericUpDownBeta.Value = (int)beta;
            txtdx.Text = (mouseEndDrag.X - mouseStartDrag.X).ToString();
            txtdy.Text = (mouseEndDrag.Y - mouseStartDrag.Y).ToString();

            if (e.Button == MouseButtons.Right)
            {
                isLeftDrag = !isLeftDrag;
                btnrotate.Enabled = !btnrotate.Enabled;
            }
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            tempXY = new Point(e.X, e.Y);
            mouseEndDrag = tempXY;

            if (isLeftDrag)
            {
                Cursor mycursor = new Cursor("Rotate.cur");
                this.pcbplot.Cursor = mycursor;
                txtxe.Text = tempXY.X.ToString();
                txtye.Text = tempXY.Y.ToString();
                //Get Alpha and beta,redraw plot
                MaptoSphere(mouseStartDrag, mouseEndDrag);

                numericUpDownAlpha.Value = (int)alpha;
                numericUpDownBeta.Value = (int)beta;

                txtdx.Text = (mouseEndDrag.X - mouseStartDrag.X).ToString();
                txtdy.Text = (mouseEndDrag.Y - mouseStartDrag.Y).ToString();

                RefreshBackground();
                //mouseStartDrag = mouseEndDrag;

            }
            else
            {
                this.pcbplot.Cursor = Cursors.Default;
            }
        }
        private void MaptoSphere(Point startpoint,Point endpoint)
        {
            //beta = beta + (endpoint.X - startpoint.X) * 0.1f;
            //beta = (endpoint.X - startpoint.X) * 0.25f;
            float widthrate = 1 / (pcbplot.Width / 360.0f);
            float hightrate = 1 / (pcbplot.Height / 180.0f);
            beta = (endpoint.X - startpoint.X) * widthrate;

            if (beta < 0)
            {
                beta = beta + 360;
            }
            if (beta > 360.0f)
            {
                beta = beta - 360.0f;
            }
            //alpha = alpha + (endpoint.Y - startpoint.Y) * 0.1f;
            //alpha = (endpoint.Y - startpoint.Y) * 0.225f;
            alpha = (endpoint.Y - startpoint.Y) * hightrate;

            if (alpha < 0)
            {
                alpha = alpha + 360;
            }
            if (alpha > 360.0f)
            {
                alpha = alpha - 360.0f;
            }
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
        private void RefreshBackground()
        {
            gB.Clear(this.pcbplot.BackColor);
            DrawPlot(colortype);

            Size sz = this.pcbplot.Size;
            Rectangle rt = new Rectangle(0, 0, sz.Width, sz.Height);
            bm = bitmap.Clone(rt, bitmap.PixelFormat);
            pcbplot.BackgroundImage = bm;
        }
        #endregion

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            InitialBitmap();
            RefreshBackground();
        }

        private void cmbcolortype_SelectedIndexChanged(object sender, EventArgs e)
        {
            string color = cmbcolortype.Text;

            switch (color)
            {
                case "Autumn":
                    colortype = cm.Autumn();
                    break;
                case "Cool":
                    colortype = cm.Cool();
                    break;
                case "Gray":
                    colortype = cm.Gray();
                    break;
                case "Hot":
                    colortype = cm.Hot();
                    break;
                case "Jet":
                    colortype = cm.Jet();
                    break;
                case "Spring":
                    colortype = cm.Spring();
                    break;
                case "Summer":
                    colortype = cm.Summer();
                    break;
                case "Winter":
                    colortype = cm.Winter();
                    break;
                case "Mix1":
                    colortype = cm.Mix1();
                    break;
                case "Mix2":
                    colortype = cm.Mix2();
                    break;
                case "Mix3":
                    colortype = cm.Mix3();
                    break;
                case "Mix4":
                    colortype = cm.Mix4();
                    break;
                case "Rainbow":
                    colortype = cm.Rainbow(Th);
                    break;
                case "FallGrYl":
                    colortype = cm.FallGrYl();
                    break;
                case "FallRdGr":
                    colortype = cm.FallRdGr();
                    break;
                case "Cool1":
                    colortype = cm.Cool1(255);
                    break;
                case "Cool11":
                    colortype = cm.Cool11(255);
                    break;
                case "Cool2":
                    colortype = cm.Cool2(255);
                    break;
                case "Cool22":
                    colortype = cm.Cool22(255);
                    break;
                case "DeltaRdGr":
                    colortype = cm.DeltaRdGr(cmax, cmin);
                    break;
                case "DeltaRdBl":
                    colortype = cm.DeltaRdBl(cmax, cmin);
                    break;
                case "DeltaGrBl":
                    colortype = cm.DeltaGrBl(cmax, cmin);
                    break;
                case "DeltaGrRd":
                    colortype = cm.DeltaGrRd(cmax, cmin);
                    break;
                case "Hot1":
                    colortype = cm.Hot1();
                    break;
                case "Hot2":
                    colortype = cm.Hot2();
                    break;
                default:
                    break;
            }

            RefreshBackground();
        }

        private void btnpan_Click(object sender, EventArgs e)
        {
            isLeftDrag = !isLeftDrag;
            if (isLeftDrag)
            {
                btnrotate.Enabled = false;
            }
            else
            {
                btnrotate.Enabled = true;
            }
        }

        
    }
}