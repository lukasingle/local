using System;

namespace Example7_2_1
{
    public class Matrix3
    {
        public float[,] M = new float[4, 4];

        public Matrix3()
        {
            Identity3();
        }

        public Matrix3(float m00, float m01, float m02, float m03,
                       float m10, float m11, float m12, float m13,
                       float m20, float m21, float m22, float m23,
                       float m30, float m31, float m32, float m33)
        {
            M[0, 0] = m00;
            M[0, 1] = m01;
            M[0, 2] = m02;
            M[0, 3] = m03;
            M[1, 0] = m10;
            M[1, 1] = m11;
            M[1, 2] = m12;
            M[1, 3] = m13;
            M[2, 0] = m20;
            M[2, 1] = m21;
            M[2, 2] = m22;
            M[2, 3] = m23;
            M[3, 0] = m30;
            M[3, 1] = m31;
            M[3, 2] = m32;
            M[3, 3] = m33;
        }

        // Define a Identity matrix:
        public void Identity3()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == j)
                    {
                        M[i, j] = 1;
                    }
                    else
                    {
                        M[i, j] = 0;
                    }
                }
            }
        }

        // Multiply two matrices together:
        public static Matrix3 operator *(Matrix3 m1, Matrix3 m2)
        {
            Matrix3 result = new Matrix3();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    float element = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        element += m1.M[i, k] * m2.M[k, j];
                    }
                    result.M[i, j] = element;
                }
            }
            return result;
        }

        // Apply a transformation to a vector (point):
        public float[] VectorMultiply(float[] vector)
        {
            float[] result = new float[4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i] += M[i, j] * vector[j];
                }
            }
            return result;
        }      

        //// Create a scaling matrix:
        public static Matrix3 Scale3(float sx, float sy, float sz)
        {
            Matrix3 result = new Matrix3();
            result.M[0, 0] = sx;
            result.M[1, 1] = sy;
            result.M[2, 2] = sz;
            return result;
        }

        // Create a translation matrix
        public static Matrix3 Translate3(float dx, float dy, float dz)
        {
            Matrix3 result = new Matrix3();
            result.M[0, 3] = dx;
            result.M[1, 3] = dy;
            result.M[2, 3] = dz;
            return result;
        }

        // Create a rotation matrix around the x axis:
        public static Matrix3 Rotate3X(float theta)
        {
            theta = theta * (float)Math.PI / 180.0f;
            float sn = (float)Math.Sin(theta);
            float cn = (float)Math.Cos(theta);
            Matrix3 result = new Matrix3();
            result.M[1, 1] = cn;
            result.M[1, 2] = -sn;
            result.M[2, 1] = sn;
            result.M[2, 2] = cn;
            return result;
        }

        // Create a rotation matrix around the y axis:
        public static Matrix3 Rotate3Y(float theta)
        {
            theta = theta * (float)Math.PI / 180.0f;
            float sn = (float)Math.Sin(theta);
            float cn = (float)Math.Cos(theta);
            Matrix3 result = new Matrix3();
            result.M[0, 0] = cn;
            result.M[0, 2] = sn;
            result.M[2, 0] = -sn;
            result.M[2, 2] = cn;
            return result;
        }

        // Create a rotation matrix around the z axis:
        public static Matrix3 Rotate3Z(float theta)
        {
            theta = theta * (float)Math.PI / 180.0f;
            float sn = (float)Math.Sin(theta);
            float cn = (float)Math.Cos(theta);
            Matrix3 result = new Matrix3();
            result.M[0, 0] = cn;
            result.M[0, 1] = -sn;
            result.M[1, 0] = sn;
            result.M[1, 1] = cn;
            return result;
        }

        // Front view projection matrix:
        public static Matrix3 FrontView()
        {
            Matrix3 result = new Matrix3();
            result.M[2, 2] = 0;
            return result;
        }

        // Side view projection matrix:
        public static Matrix3 SideView()
        {
            Matrix3 result = new Matrix3();
            result.M[0, 0] = 0;
            result.M[2, 2] = 0;
            result.M[0, 2] = -1;
            return result;
        }

        // Top view projection matrix:
        public static Matrix3 TopView()
        {
            Matrix3 result = new Matrix3();
            result.M[1, 1] = 0;
            result.M[2, 2] = 0;
            result.M[1, 2] = -1;
            return result;
        }
    }
}
