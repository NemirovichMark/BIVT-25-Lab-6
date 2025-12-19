using System;
using System.Data;
using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return 0;
            }
            int imx = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[imx, imx] < matrix[i, i])
                {
                    imx = i;
                }
            }
            return imx;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            if (matrix.GetLength(0)!=B.GetLength(0) || matrix.GetLength(1) != B.GetLength(1))
            {
                return;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                (matrix[rowIndex, i], B[i, columnIndex]) = (B[i, columnIndex], matrix[rowIndex, i]);
            }
        }
        public void Task1(int[,] A, int[,] B)
        {

            // code here
            int firstindex = FindDiagonalMaxIndex(A);
            int lastindex = FindDiagonalMaxIndex(B);
            SwapRowColumn(A, firstindex, B, lastindex);
            // end

        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if ((matrix[row,i] > 0))
                {
                    count++;
                }
                
            }
            return count;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > 0)
                {
                    count++;
                }
            }
            return count;
        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int[,] a = new int [A.GetLength(0)+1,A.GetLength(1)];
            for (int i = 0;i < A.GetLength(0)+1; i++)
            {
                for (int j = 0;j < A.GetLength(1);j++)
                {
                    if (i < rowIndex)
                    {
                        a[i, j] = A[i, j];
                    }
                    else if(i==rowIndex)
                    {
                        a[i, j] = B[j,columnIndex];
                    }
                    else
                    {
                        a[i, j] = A[i - 1, j];
                    }
                }
            }

        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(1) != B.GetLength(0))
            {
                return;
            }
            int bmax = 0;
            int ib = 0;
            for (int i = 0; i < B.GetLength(0); i++)
            {
                int oaoa= CountPositiveElementsInColumn(B, i);
                if (oaoa > bmax)
                {
                    bmax= oaoa;
                    ib = i;
                }
            }
            int amax = 0; int ia = 0;
            for (int i = 0;i<A.GetLength(1); i++)
            {
                int baobab = CountPositiveElementsInRow(A, i);
                if (baobab > amax)
                {
                    amax= baobab;
                    ia = i;
                }
            }
            if (bmax == 0)
            {
                return;
            }
            InsertColumn(ref A, ia, ib, B);
            // end

        }
        public void
        ChangeMatrixValues(int[,] matrix)
        {
            int[] suk = new int[matrix.GetLength(0)*matrix.GetLength(1)];
            int n = 0;
            for (int i = 0;i<matrix.GetLength(0);i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    suk[n]= matrix[i,j];
                    n++;
                }
            }
            n = 0;
            for(int i = 0; i < suk.Length; i++)
            {
                for (int j = 1;j < suk.Length; j++)
                {
                    if (suk[j - 1] < suk[j])
                    {
                        (suk[j - 1], suk[j]) = (suk[j], suk[j - 1]);
                    }
                }
            }
            int iz = 0; int elemcnt = 0; int povt = 0;
            int nch = suk[suk.Length - 1];
            for (int i = suk.Length - 1; i >= 0; i--)
            {
                
                if (iz == 5)
                {
                    break;
                }
                elemcnt++;
                if ( suk[i] < nch)
                {
                    nch = suk[i];
                    iz++;
                }
                if ( suk[i] == nch)
                {
                    povt++;
                }
            }
            
        }
        public void Task3(int[,] matrix)
        {

            // code here

            // end

        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int[] arr = new int[matrix.GetLength(0)];
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((matrix[i, j] < 0))
                    {
                        count++;
                        cnt++;
                    }
                }
                arr[i] = count;
            }
            
            return arr;
        }
        public int FindMaxIndex(int[] array)
        {
            int imax = 0; int max = int.MinValue;
            for (int i = 0;i< array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i]; imax = i;
                }
            }
            return imax;
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(1) != B.GetLength(1))
            {
                return;
            }
            int iA = FindMaxIndex(CountNegativesPerRow(A));
            int iB = FindMaxIndex(CountNegativesPerRow(B));
            for (int i = 0; i < A.GetLength(0); i++)
            {
                (A[iA, i], B[iB, i]) = (B[iB, i], A[iA, i]);
            }
            // end

        }
        public void SortNegativeAscending(int[] matrix)
        {
            int n = 0;
            for (int i = 0; i<matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    n++;
                }
            }
            int[] neg = new int[n];
            n = 0;
            for (int i=0;i<matrix.Length; i++)
            {
                if (matrix[i] < 0) 
                {
                    neg[n++] = matrix[i];
                }
            }
            Array.Sort(neg);
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = neg[n--];
            }
        }
        public delegate void Sorting(int[] matrix);
        public void Task5(int[] matrix, Sorting sort)
        {

            // code here

            // end

        }
        public delegate void SortRowsByMax(int[] matrix);
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here

            // end

        }
        public delegate void FindNegatives(int[] matrix);
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            // code here

            // end

            return negatives;
        }
        public delegate void MathInfo(int[] matrix);
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here

            // end

            return answer;
        }
        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            // code here

            // end

            return answer;
        }
        public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here

            // end

        }
    }
}
