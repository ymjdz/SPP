using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinglePointPositioning
{
    class Matrix
    {
        /// <summary>
        /// 矩阵加法
        /// </summary>
        /// <param name="Matrix_A">矩阵A</param>
        /// <param name="Matrix_B">矩阵B</param>
        /// <param name="row">行数</param>
        /// <param name="col">列数</param>
        /// <returns>相加后的矩阵</returns>
        public static double[,] Plus(double[,] Matrix_A, double[,] Matrix_B, int row, int col)
        {
            double[,] dMatrix_plus = new double[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    dMatrix_plus[i, j] = Matrix_A[i, j] + Matrix_B[i, j];
                }
            }
            return dMatrix_plus;
        }

        /// <summary>
        /// 矩阵乘法
        /// </summary>
        /// <param name="Matrix_A">矩阵A</param>
        /// <param name="Matrix_B">矩阵B</param>
        /// <param name="A_row">矩阵A的行数</param>
        /// <param name="common">矩阵A的列数和矩阵B的行数</param>
        /// <param name="B_col">矩阵B的列数</param>
        /// <returns>相乘后的矩阵</returns>

        //public static double[,] MatrixMultiply(double[,] a, double[,] b)
        //{
        //    int row1 = a.GetLength(0);
        //    int col1 = a.GetLength(1);
        //    int row2 = b.GetLength(0);
        //    int col2 = b.GetLength(1);
        //    double[,] c = new double[row1, col2];
        //    double result = 0;
        //    if (col1 != row2)
        //        MessageBox.Show("数据出错");
        //    else
        //        for (int i = 0; i < row1; i++)
        //        {
        //            for (int j = 0; j < col2; j++)
        //            {
        //                for (int k = 0; k < col1; k++)
        //                {
        //                    result = result + a[i, k] * b[k, j];
        //                }
        //                c.SetValue(result, i, j);
        //                result = 0;
        //            }
        //        }

        //    return c;
        //}
        public static double[,] Multiply(double[,] Matrix_A, double[,] Matrix_B, int A_row, int common, int B_col)
        {
            double[,] dMatrix_multiply = new double[A_row, B_col];
            for (int i = 0; i < A_row; i++)
            {
                for (int j = 0; j < B_col; j++)
                {
                    for (int k = 0; k < common; k++)
                    {
                        dMatrix_multiply[i, j] += Matrix_A[i, k] * Matrix_B[k, j];
                    }
                }
            }
            return dMatrix_multiply;
        }

        /// <summary>
        /// 矩阵转置
        /// </summary>
        /// <param name="Matrix_A">待转矩阵A</param>
        /// <param name="row">行数</param>
        /// <param name="col">列数</param>
        /// <returns>转置后的矩阵</returns>
        public static double[,] Transfer(double[,] Matrix_A, int row, int col)
        {
            double[,] dMatrix_transfer = new double[col, row];
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    dMatrix_transfer[i, j] = Matrix_A[j, i];
                }
            }
            return dMatrix_transfer;
        }

        /// <summary>
        /// 矩阵行列式
        /// </summary>
        /// <param name="MatrixList">输入矩阵</param>
        /// <param name="level">阶数</param>
        /// <returns>行列式的值</returns>
        public static double Value(double[,] MatrixList, int level)
        {
            double[,] dMatrix = new double[level, level];
            for (int i = 0; i < level; i++)
            {
                for (int j = 0; j < level; j++)
                {
                    dMatrix[i, j] = MatrixList[i, j];
                }
            }

            double c, x;
            int k = 1;
            for (int i = 0, j = 0; i < level && j < level; i++, j++)
            {
                if (dMatrix[i, j] == 0)
                {
                    int m = i;
                    for (; dMatrix[m, j] == 0; m++) ;
                    if (m == level)
                    {
                        return 0;
                    }
                    else
                    {
                        for (int n = j; n < level; n++)
                        {
                            c = dMatrix[i, n];
                            dMatrix[i, n] = dMatrix[m, n];
                            dMatrix[m, n] = c;
                        }
                        k *= (-1);
                    }
                }
                for (int s = level - 1; s > i; s--)
                {
                    x = dMatrix[s, j];
                    for (int t = j; t < level; t++)
                    {
                        dMatrix[s, t] -= dMatrix[i, t] * (x / dMatrix[i, j]);
                    }
                }
            }
            double sn = 1;
            for (int i = 0; i < level; i++)
            {
                if (dMatrix[i, i] != 0)
                {
                    sn *= dMatrix[i, i];
                }
                else
                {
                    return (0);
                }
            }
            return k * sn;
        }

        /// <summary>
        /// 矩阵求逆
        /// </summary>
        /// <param name="dMatrix">输入矩阵</param>
        /// <param name="Level">阶数</param>
        /// <returns>逆矩阵</returns>


        public static double[,] MatrixOpp(double[,] MatrixA)
        {

            int Level = MatrixA.GetLength(1);
            double[,] dReverseMatrix = new double[Level, 2 * Level];

            for (int i = 0; i < Level; i++)
            {
                for (int j = 0; j < 2 * Level; j++)
                {
                    if (j < Level)
                    {
                        dReverseMatrix[i, j] = MatrixA[i, j];
                    }
                    else
                    {
                        if (j - Level == i)
                        {
                            dReverseMatrix[i, j] = 1;
                        }
                        else
                        {
                            dReverseMatrix[i, j] = 0;
                        }
                    }
                }
            }
            for (int i = 0, j = 0; i < Level && j < Level; i++, j++)
            {
                if (dReverseMatrix[i, j] == 0)
                {
                    if (i == Level - 1)
                    {
                        return null;
                    }
                    int m = i + 1;
                    for (; MatrixA[m, j] == 0; m++)
                    {
                        if (m == Level - 1)
                        {
                            return null;
                        }
                    }
                    if (m == Level)
                    {
                        return null;
                    }
                    else
                    {

                        for (int n = j; n < 2 * Level; n++)
                        {
                            dReverseMatrix[i, n] += dReverseMatrix[m, n];
                        }
                    }
                }
                double temp = dReverseMatrix[i, j];
                if (temp != 1)
                {

                    for (int n = j; n < 2 * Level; n++)
                    {
                        if (dReverseMatrix[i, n] != 0)
                        {
                            dReverseMatrix[i, n] /= temp;
                        }
                    }
                }

                for (int s = Level - 1; s > i; s--)
                {
                    temp = dReverseMatrix[s, j];

                    for (int t = j; t < 2 * Level; t++)
                    {
                        dReverseMatrix[s, t] -= (dReverseMatrix[i, t] * temp);
                    }
                }
            }

            for (int i = Level - 2; i >= 0; i--)
            {
                for (int j = i + 1; j < Level; j++)
                {
                    if (dReverseMatrix[i, j] != 0)
                    {
                        double tmp = dReverseMatrix[i, j];

                        for (int n = j; n < 2 * Level; n++)
                        {
                            dReverseMatrix[i, n] -= (tmp * dReverseMatrix[j, n]);
                        }
                    }
                }
            }

            double[,] MatrixB = new double[Level, Level];
            for (int i = 0; i < Level; i++)
            {
                for (int j = 0; j < Level; j++)
                {
                    MatrixB[i, j] = dReverseMatrix[i, j + Level];
                }
            }
            return MatrixB;
        }





        //public static double[,] Reverse(double[,] dMatrix, int Level)
        //{
        //    double dMatrixValue = Value(dMatrix, Level);
        //    if (dMatrixValue == 0)
        //    {
        //        return null;
        //    }
        //    double[,] dReverseMatrix = new double[Level, 2 * Level];
        //    double x, c;
        //    for (int i = 0; i < Level; i++)
        //    {
        //        for (int j = 0; j < 2 * Level; j++)
        //        {
        //            if (j < Level)
        //            {
        //                dReverseMatrix[i, j] = dMatrix[i, j];
        //            }
        //            else
        //            {
        //                dReverseMatrix[i, j] = 0;
        //            }
        //        }
        //        dReverseMatrix[i, Level + i] = 1;
        //    }
        //    for (int i = 0, j = 0; i < Level && j < Level; i++, j++)
        //    {
        //        if (dReverseMatrix[i, j] == 0)
        //        {
        //            int m = i;
        //            for (; dMatrix[m, j] == 0; m++) ;
        //            if (m == Level)
        //            {
        //                return null;
        //            }
        //            else
        //            {
        //                for (int n = j; n < 2 * Level; n++)
        //                {
        //                    dReverseMatrix[i, n] += dReverseMatrix[m, n];
        //                }
        //            }
        //        }
        //        x = dReverseMatrix[i, j];
        //        if (x != 1)
        //        {
        //            for (int n = j; n < 2 * Level; n++)
        //            {
        //                if (dReverseMatrix[i, n] != 0)
        //                {
        //                    dReverseMatrix[i, n] /= x;
        //                }
        //            }
        //        }
        //        for (int s = Level - 1; s > i; s--)
        //        {
        //            x = dReverseMatrix[s, j];
        //            for (int t = j; t < 2 * Level; t++)
        //            {
        //                dReverseMatrix[s, t] -= (dReverseMatrix[i, t] * x);
        //            }
        //        }
        //    }
        //    for (int i = Level - 2; i >= 0; i--)
        //    {
        //        for (int j = i + 1; j < Level; j++)
        //        {
        //            if (dReverseMatrix[i, j] != 0)
        //            {
        //                c = dReverseMatrix[i, j];
        //                for (int n = j; n < 2 * Level; n++)
        //                {
        //                    dReverseMatrix[i, n] -= (c * dReverseMatrix[j, n]);
        //                }
        //            }
        //        }
        //    }
        //    double[,] dReturn = new double[Level, Level];
        //    for (int i = 0; i < Level; i++)
        //    {
        //        for (int j = 0; j < Level; j++)
        //        {
        //            dReturn[i, j] = dReverseMatrix[i, j + Level];
        //        }
        //    }
        //    return dReturn;
        //}






    }
}
