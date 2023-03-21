using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.IO;
using System.Reflection;

using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Example3_2_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mnuBasic_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            graphics.Clear(Color.White);

            //load the picture
            Bitmap image = new Bitmap("ColorInput.bmp");
            //Bitmap image = new Bitmap("ASTROBOY.bmp");
            int width = image.Width;
            int height = image.Height;
            ImageAttributes imageAttributes = new ImageAttributes();

            //define the color transformation matrix
            float[][] colorMatrixElements =
		    {
			    new float[]{2.0f, 0.0f, 0.0f, 0.0f, 0.0f},
			    new float[] { 0.0f, 1.0f, 0.0f, 0.0f, 0.0f},
			    new float[] { 0.0f, 0.0f, 1.0f, 0.0f, 0.0f},
			    new float[]{0.0f, 0.0f, 0.0f, 1.0f, 0.0f},
			    new float[]{1.0f, 0.0f, 0.0f, 0.0f, 1.0f}
		    };
            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            //enable the color transformation matrix
            imageAttributes.SetColorMatrix(
                colorMatrix,
                ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);

            //first render the source image
            graphics.DrawImage(image, 50, 50);
            //render the target image using  the color transformation matrix defined above
            graphics.TranslateTransform(width + 50, 50);
            graphics.DrawImage(
                image,
                new Rectangle(0, 0, width, height),
                0, 0,
                width, height, GraphicsUnit.Pixel,
                imageAttributes);

        }
    }
}