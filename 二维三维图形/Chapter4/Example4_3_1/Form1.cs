using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace Example4_3_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawAxes(Graphics g, bool flipY)
        {

            //Hold the old transform of g
            Matrix mm = g.Transform;

            //Clear the transform of g
            g.Transform = new Matrix();
            //Create a red pen
            Pen p = new Pen(Brushes.Red, 1);

            Matrix m = new Matrix();

            //move the origin to 200,200
            m.Translate(200, 200);
            //apply the transformation
            g.Transform = m;

            //draw the axes
            g.DrawLine(p, -200, 0, 200, 0); //horizontal
            g.DrawLine(p, 0, -200, 0, 200); //vetical	


            for (int i = -150; i <= 150; i += 50)
            {
                //calibrate the vertical axis with horizontal text
                if (flipY)
                    g.DrawString(i.ToString(), this.Font, Brushes.Red, 5, -i);
                else
                    g.DrawString(i.ToString(), this.Font, Brushes.Red, 5, i);

                //tick the vertical axis with horizontal ticks
                g.DrawLine(p, -5, i, 5, i);
                //tick the horizontal axis with vertical ticks
                g.DrawLine(p, i, -5, i, 5);

            }

            //prepend the 90 deg clockwise rotation
            //so now m would be a matix for a 90 deg clockwise rotation 
            //followed by translation by 200,200
            m.Rotate(90, MatrixOrder.Prepend);

            //override with the new transformation
            g.Transform = m;

            for (int i = -150; i <= 150; i += 50)
            {
                //calibrate the horizontal axis with vertical text
                //|
                //|
                //|100
                //|
                //|
                //after the rotation would be
                //
                //_____________
                //    _
                //    O
                //    O
                //
                g.DrawString(i.ToString(), this.Font, Brushes.Red, 5, -i);
            }

            //Restore the old transform of g
            g.Transform = mm;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //allocate image for persistence
            Image img = new Bitmap(400, 400);

            //assigned to pictureBox 1
            pictureBox1.Image = img;
            Graphics g = Graphics.FromImage(pictureBox1.Image);

            //Draw the graphical axes
            DrawAxes(g, (cbFlipY.CheckState == CheckState.Checked));

            //Create a new metrix
            Matrix mm = new Matrix();

            //Flip Y axis
            if (cbFlipY.CheckState == CheckState.Checked)
                mm = new Matrix(1, 0, 0, -1, 0, 0);
            //Bring Center to 200,200
            mm.Translate(200, 200, MatrixOrder.Append);
            //Apply world transformation on picture box 
            g.Transform = mm;

            //Create a new matrix for custom transformations
            Matrix mm1 = new Matrix();

            //append the transformation as ordered by the lsitbox
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                //somehow when the y axis is flip
                //the direction of the rotation also changed
                //thus when the y axis is flip, we
                //multiply the angle by a -1
                if (listBox1.Items[i].ToString() == "Rotate")
                    mm1.RotateAt(
                        (cbFlipY.CheckState == CheckState.Checked ? -1 : 1) * int.Parse(lblRotDeg.Text),
                        new Point(int.Parse(lblRotX.Text),
                        int.Parse(lblRotY.Text)),
                        MatrixOrder.Append);


                if (listBox1.Items[i].ToString() == "Translation")
                    mm1.Translate(int.Parse(lblTransX.Text), int.Parse(lblTransY.Text), MatrixOrder.Append);

                if (listBox1.Items[i].ToString() == "Scale")
                    mm1.Scale(float.Parse(lblStrX.Text), float.Parse(lblStrY.Text), MatrixOrder.Append);
                if (listBox1.Items[i].ToString() == "Shear")
                    mm1.Shear(float.Parse(lblShearX.Text), float.Parse(lblShearY.Text), MatrixOrder.Append);

            }


            GraphicsPath gp = new GraphicsPath();

            Image imgpic = (Image)pictureBoxBase.Image.Clone();

            //the coordinate of the polygon must be
            //point 1 = left top corner
            //point 2 = right top corner
            //point 3 = right bottom corner
            if (cbFlipY.CheckState == CheckState.Checked)
                gp.AddPolygon(new Point[] { new Point(0, imgpic.Height), new Point(imgpic.Width, imgpic.Height), new Point(0, 0) });
            else
                gp.AddPolygon(new Point[] { new Point(0, 0), new Point(imgpic.Width, 0), new Point(0, imgpic.Height) });

            //apply the transformation matrix on the graphical path
            gp.Transform(mm1);
            //get the resulting path points
            PointF[] pts = gp.PathPoints;


            //draw on the picturebox content of imgpic using the local transformation 
            //using the resulting parralleogram described by pts
            g.DrawImage(imgpic, pts);

            pictureBox1.Refresh();

        }

        private void tRotDeg_ValueChanged(object sender, EventArgs e)
        {
            lblRotDeg.Text = tRotDeg.Value.ToString();
            cbRotate.CheckState = CheckState.Checked;
            if (cbRealtime.CheckState == CheckState.Checked)
            {
                button1_Click(sender, null);
            }
        }

        private void tRotX_ValueChanged(object sender, EventArgs e)
        {
            lblRotX.Text = tRotX.Value.ToString();
            cbRotate.CheckState = CheckState.Checked;
            if (cbRealtime.CheckState == CheckState.Checked)
            {
                button1_Click(sender, null);
            }
        }

        private void tRotY_ValueChanged(object sender, EventArgs e)
        {
            lblRotY.Text = tRotY.Value.ToString();
            cbRotate.CheckState = CheckState.Checked;
            if (cbRealtime.CheckState == CheckState.Checked)
            {
                button1_Click(sender, null);
            }
        }

        private void tTransX_ValueChanged(object sender, EventArgs e)
        {
            lblTransX.Text = tTransX.Value.ToString();
            cbTranslation.CheckState = CheckState.Checked;
            if (cbRealtime.CheckState == CheckState.Checked)
            {
                button1_Click(sender, null);
            }
        }

        private void tTransY_ValueChanged(object sender, EventArgs e)
        {
            lblTransY.Text = tTransY.Value.ToString();
            cbTranslation.CheckState = CheckState.Checked;
            if (cbRealtime.CheckState == CheckState.Checked)
            {
                button1_Click(sender, null);
            }
        }

        private void tStrX_ValueChanged(object sender, EventArgs e)
        {
            lblStrX.Text = String.Format("{0:0.0}", (tStrX.Value / 10.0));
            cbStretch.CheckState = CheckState.Checked;
            if (cbRealtime.CheckState == CheckState.Checked)
            {
                button1_Click(sender, null);
            }
        }

        private void tStrY_ValueChanged(object sender, EventArgs e)
        {
            lblStrY.Text = String.Format("{0:0.0}", (tStrY.Value / 10.0));
            cbStretch.CheckState = CheckState.Checked;
            if (cbRealtime.CheckState == CheckState.Checked)
            {
                button1_Click(sender, null);
            }
        }

        private void tShearX_ValueChanged(object sender, EventArgs e)
        {
            lblShearX.Text = String.Format("{0:0.0}", (tShearX.Value / 10.0));
            cbShear.CheckState = CheckState.Checked;
            if (cbRealtime.CheckState == CheckState.Checked)
            {
                button1_Click(sender, null);
            }
        }

        private void tShearY_ValueChanged(object sender, EventArgs e)
        {
            lblShearY.Text = String.Format("{0:0.0}", (tShearY.Value / 10.0));
            cbShear.CheckState = CheckState.Checked;
            if (cbRealtime.CheckState == CheckState.Checked)
            {
                button1_Click(sender, null);
            }
        }

        private void cbRotate_CheckedChanged(object sender, EventArgs e)
        {
            UpdateListBox((CheckBox)sender, "Rotate");
        }

        private void cbTranslation_CheckedChanged(object sender, EventArgs e)
        {
            UpdateListBox((CheckBox)sender, "Translation");
        }

        private void cbStretch_CheckedChanged(object sender, EventArgs e)
        {
            UpdateListBox((CheckBox)sender, "Scale");
        }

        private void cbShear_CheckedChanged(object sender, EventArgs e)
        {
            UpdateListBox((CheckBox)sender, "Shear");
        }

        private void cbFlipY_CheckedChanged(object sender, EventArgs e)
        {
            button1_Click(sender, null);
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if ((index) <= 0) return;
            string s = (string)listBox1.Items[index];
            listBox1.Items.RemoveAt(index);
            listBox1.Items.Insert(index - 1, s);
            listBox1.SelectedIndex = index - 1;
            if (cbRealtime.CheckState == CheckState.Checked)
            {
                button1_Click(sender, null);
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index >= listBox1.Items.Count - 1) return;
            if ((index) <= -1) return;
            string s = (string)listBox1.Items[index];
            listBox1.Items.RemoveAt(index);
            listBox1.Items.Insert(index + 1, s);
            listBox1.SelectedIndex = index + 1;
            if (cbRealtime.CheckState == CheckState.Checked)
            {
                button1_Click(sender, null);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tRotDeg.Value=0;
			tRotX.Value=0;
			tRotY.Value=0;

			lblRotDeg.Text=tRotDeg.Value.ToString();
			lblRotX.Text=tRotX.Value.ToString();
			lblRotY.Text=tRotY.Value.ToString();

			tTransX.Value =0;
			tTransY.Value=0;

			lblTransX.Text=tTransX.Value.ToString();
			lblTransY.Text=tTransY.Value.ToString();

			tStrX.Value =10;
			tStrY.Value =10;

			lblStrX.Text=String.Format("{0:0.0}",(tStrX.Value /10.0));
			lblStrY.Text=String.Format("{0:0.0}",(tStrY.Value/10.0));

			tShearX.Value =0;
			tShearY.Value=0;

			lblShearX.Text=String.Format("{0:0.0}",(tShearX.Value/10.0));
			lblShearY.Text=String.Format("{0:0.0}",(tShearY.Value/10.0));

			cbFlipY.CheckState=CheckState.Checked;
			cbRotate.CheckState=CheckState.Unchecked;
			cbTranslation.CheckState=CheckState.Unchecked;
			cbStretch.CheckState =CheckState.Unchecked;
			cbShear.CheckState=CheckState.Unchecked;

			button1_Click(this,null);

		}
        private void UpdateListBox(CheckBox cb, String s)
        {
            if (cb.CheckState == CheckState.Checked)
            {
                bool found = false;
                for (int i = 0; i < listBox1.Items.Count; i++)
                    if (listBox1.Items[i].ToString() == s)
                    {
                        found = true;
                        break;
                    }

                if (!found)
                {
                    listBox1.Items.Add(s);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }

            }
            else
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (listBox1.Items[i].ToString() == s)
                    {
                        listBox1.Items.RemoveAt(i);

                        if (i > 0) listBox1.SelectedIndex = i - 1;
                        if (i == 0)
                            if (listBox1.Items.Count >= 1)
                                listBox1.SelectedIndex = 0;

                        break;
                    }
                }
            }
        }

     }
}