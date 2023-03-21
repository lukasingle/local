using System;
using System.Drawing;
using System.Windows.Forms;

namespace Example7_2_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            label1.BackColor = Color.White;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create the original point Point3 :
            Point3 pt = new Point3();
            pt.X = 1;
            pt.Y = 2;
            pt.Z = 3;

            // Perform transformation:

            //ScaleTransform(pt);

            RotateTransform(pt);

            //ReflectTransform(pt);

            //TranslateTransform(pt);

            // Display result in label1 control:
            label1.Text = pt.X.ToString() + ",  " + pt.Y.ToString() + 
                          ",  " + pt.Z.ToString() + ",  " + pt.W.ToString();
        }

        private void ScaleTransform(Point3 pt)
        {

            //// Create a scaling matrix:
            //Matrix3 m1 = Matrix3.Scale3(0.5f, 0.5f, 1.5f);
            //// Perform scaling operation:
            //pt.Transform(m1);


            // Create a scaling matrix:
            Matrix3 m2 = Matrix3.Scale3(0.5f, 0.5f, 1.5f);
            // Create another scaling matrix:
            Matrix3 m3 = Matrix3.Scale3(1f, 0.5f, 0.3f);
            // Perform the scaling operation:
            pt.Transform(m2 * m3);
        }

        private void ReflectTransform(Point3 pt)
        {
            // Create the reflection matrix across the X-Y plane and 
            // perform reflection transformation:
            Matrix3 m = Matrix3.Scale3(1, 1, -1);
            pt.Transform(m);

            // Create the reflection matrix across the X-Z plane and 
            // perform reflection transformation:
            m = Matrix3.Scale3(1, -1, 1);
            pt.Transform(m);

            // Create the reflection matrix across the Y-Z plane and 
            // perform reflection transformation:
            m = Matrix3.Scale3(-1, 1, 1);
            pt.Transform(m);
        }

        private void TranslateTransform(Point3 pt)
        {
            // Create a translation matrix:
            Matrix3 m1 = Matrix3.Translate3(2, 2.5f, 3);
            // Perform the translation operation:
            pt.Transform(m1);

            //// Create a translation matrix:
            //Matrix3 m2 = Matrix3.Translate3(2, 2.5f, 3);
            //// Create another translation matrix:
            //Matrix3 m3 = Matrix3.Translate3(-3, -2, -1);
            //// Perform the translation operation:
            //pt.Transform(m2 * m3);
        }

        private void RotateTransform(Point3 pt)
        {
            //// Create a rotation matrix around the z axis by 45 degrees:
            //Matrix3 m1 = Matrix3.Rotate3Z(45);
            //// Perform the rotation operation:
            //pt.Transform(m1);

            // Create a rotation matrix around the z axis by 20 degrees:
            Matrix3 m2 = Matrix3.Rotate3Z(20);
            // Create another rotation matrix around the z axis by 25 degrees:
            Matrix3 m3 = Matrix3.Rotate3Z(25);

            // Perform the rotation operation:
            pt.Transform(m2 * m3);
        }

    }
}