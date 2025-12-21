using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int a = 0;
            int m = -1000000;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > m)
                {
                    a = i;
                    m = matrix[i, i];
                }
            }
            return a;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            int n = matrix.GetLength(0);
            int e = 0;
            for (int i = 0; i < n; i++)
            {
                e = matrix[rowIndex, i];
                matrix[rowIndex, i] = B[i, columnIndex];
                B[i, columnIndex] = e;
            }
        }
        public void Task1(int[,] A, int[,] B)
        {
            int a0 = A.GetLength(0);
            int a1 = A.GetLength(1);
            int b0 = B.GetLength(0);
            int b1 = B.GetLength(1);
            if (a0!=b0 ||  a1!=b1 || a0!=a1 || a0==0 || b0==0)
            {
                return;
            }
            int rowIndex = FindDiagonalMaxIndex(A);
            int columnIndex = FindDiagonalMaxIndex(B);
            SwapRowColumn(A, rowIndex, B, columnIndex);

        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int k = 0;
            int n = matrix.GetLength(1);
            if (n== 0 || matrix.GetLength(0) == 0)
            {
                return 0;
            }
            for (int i = 0; i < n; i++)
            { 
                if (matrix[row,i]>0)
                {
                    k++;
                }
            }
            return k;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int k = 0;
            int n = matrix.GetLength(0);
            if (n == 0 || matrix.GetLength(1) == 0)
            {
                return 0;
            }
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, col] > 0)
                {
                    k++;
                }
            }
            return k;
        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int a0 = A.GetLength(0);
            int b0 = B.GetLength(0);
            int a1 = A.GetLength(1);
            int b1 = B.GetLength(1);

            int[,] m = new int[a0 + 1, a1];
            for (int i = 0;i < a0+1;i++)
            {
                for (int j = 0;j < a1;j++)
                {
                    if (i> rowIndex+1)
                    {
                        m[i, j] = A[i-1, j];
                    }
                    else if (i == rowIndex+1)
                    {
                        m[i,j]= B[j,columnIndex];
                    }
                    else
                    {
                        m[i, j] = A[i, j];
                    }
                }
            }
            A = m;
        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            int a0 = A.GetLength(0);
            int b0 = B.GetLength(0);
            int a1 = A.GetLength(1);
            int b1 = B.GetLength(1);
            if (a1 != b0)
            {
                return;
            }
            int r1 = 0;
            int r2 = 0;
            int c1 = 0;
            int c2 = 0;

            for (int i = 0; i < b0;i++)
            {
                int c = CountPositiveElementsInColumn(B, i);
                if (c>c2)
                {
                    c1 = i;
                    c2 = c;
                }
            }
            for (int i = 0;i < a1;i++)
            {
                int c = CountPositiveElementsInColumn(A, i);
                if (c>r2)
                {
                    r1 = i;
                    r2 = c;
                }
            }
            if (c2 == 0)
            {
                return; 
            }
            InsertColumn(ref A, r1, c1, B);
            // end

        }
        public void ChangeMatrixValues(int[,] matrix)
        {
            int a0 = matrix.GetLength(0);
            int a1 = matrix.GetLength(1);

            
            int k = 0;
            if (a0*a1<5)
            {
                for (int i = 0; i < a0; i++)
                {
                    for (int j = 0; j < a1; j++)
                    {
                        matrix[i, j] *= 2;
                    }
                }
                return;
            }

            int[,] sss = new int[a0, a1];
            for (int i = 0; i < a0; i++)
            {
                for (int j = 0; j < a1; j++)
                {
                    sss[i, j] = matrix[i, j];
                }
            }
            int[,] mmm = new int[5,2];

            while (k<5)
            {
                int m = -100000;
                for (int i = 0;i<a0;i++)
                {
                    for (int j = 0;j<a1; j++)
                    {
                        if (sss[i,j] > m)
                        {
                            m = sss[i,j];
                            mmm[k, 0] = i;
                            mmm[k,1] = j;
                        }
                    }
                }
               
                sss[mmm[k, 0], mmm[k, 1]] = -10000000;
                k++;

            }
            k = 0;
            while (k < 5)
            {
                matrix[mmm[k, 0], mmm[k, 1]] *= 4;
                k++;
            }
            for (int i = 0; i < a0; i++)
            {
                for (int j = 0; j < a1; j++)
                {
                    matrix[i, j] /= 2;
                }
            }


        }
        public void Task3(int[,] matrix)
        {

            // code here
            ChangeMatrixValues(matrix);
            // end

        }
        
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                int k = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i,j]<0)
                    {
                        k++;
                    }
                }
                a[i] = k;
            }
            return a;
        }
        public int FindMaxIndex(int[] array)
        {
            int n = array.Length;
            int k = 0;
           
            for (int i = 0; i < n; i++)
            {
                if (array[i] > array[k])
                {
                    k = i;
                    
                }
            }
            return k;
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            int a0 = A.GetLength(0);
            int b0 = B.GetLength(0);
            int a1 = A.GetLength(1);
            int b1 = B.GetLength(1);
            if (a1!= b1)
            {
                return;
            }

            int[] a = CountNegativesPerRow(A);
            int[] b = CountNegativesPerRow(B);

            int sa = FindMaxIndex(a);
            int sb = FindMaxIndex(b);

            if (a[sa]<= 0)
            {
                return;
            }
            if (b[sb] <= 0)
            {
                return;
            }
                
            for (int i = 0; i<a1; i++)
            {
                (A[sa, i], B[sb, i]) = (B[sb, i], A[sa, i]);
            }
            // end

        }
        public void SortNegativeAscending(int[] matrix)
        {
            int k = 0;
            for (int i = 0; i<matrix.Length;i++)
            {
                if (matrix[i]<0)
                {
                    k++;
                }
            }
            int[] a = new int[k];
            k = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    a[k] = matrix[i];
                    k++;
                }
            }
            Array.Sort(a);
            k = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = a[k];
                    k++;
                }
            }
        }
        public void SortNegativeDescending(int[] matrix)
        {
            int k = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    k++;
                }
            }
            int[] a = new int[k];
            k = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    a[k] = matrix[i];
                    k++;
                }
            }
            Array.Sort(a);
            
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    k--;
                    matrix[i] = a[k];
                    
                }
            }
        }
        public delegate void Sorting(int[] matrix);
        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public void ss(int a1, int a2, ref int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                (matrix[a1, i], matrix[a2, i]) = (matrix[a2, i], matrix[a1, i]);
            }
        }
        public int GetRowMax(int[,] matrix, int row)
        {
            int m = matrix[row, 0];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] > m)
                {
                    m = matrix[row, i];
                }
            }
            return m;
        }
        public delegate void SortRowsByMax(int[,] matrix);
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int[] a = new int[matrix.GetLength(0)];
            for (int i = 0; i< matrix.GetLength(0);i++)
            {
                a[i] = GetRowMax(matrix, i);
            }
            
            int x = 1;
            while (x< matrix.GetLength(0))
            {
                if (x == 0 || a[x]>= a[x-1])
                {
                    x++;
                }
                else
                {
                    (a[x], a[x - 1]) = (a[x - 1], a[x]);
                    ss(x, x - 1, ref matrix);
                    x--;
                }
            }
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int[] a = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                a[i] = GetRowMax(matrix, i);
            }
            
            int x = 1;
            while (x < matrix.GetLength(0))
            {
                if (x == 0 || a[x] <= a[x - 1])
                {
                    x++;
                }
                else
                {
                    (a[x], a[x - 1]) = (a[x - 1], a[x]);
                    ss(x, x - 1, ref matrix);
                    x--;
                }
            }
        }

        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public delegate int[] FindNegatives(int[,] matrix);
        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int[] a = new int[matrix.GetLength(0)];
            int k = 0;
            for (int i = 0; i<matrix.GetLength(0);i++)
            {
                k = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j]<0)
                    {
                        k++;
                    }
                }
                a[i] = k;
            }
            return a;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int[] a = new int[matrix.GetLength(1)];
            int k = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                k = -100000;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0 && matrix[i,j]>k)
                    {
                        k=matrix[i,j];
                    }
                }
                a[j] = k;
                if (a[j] == -100000)
                {
                    a[j] = 0;
                }
            }
            
            return a;
        }
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            // code here
            negatives = find(matrix);
            // end

            return negatives;
        }
        public delegate int[,] MathInfo(int[,] matrix);
        public int[,] DefineSeq(int[,] matrix)
        {
            bool a1 = false;
            bool a2 = false;
            for (int i = 1; i < matrix.GetLength(1) && (a1 == false || a2 == false); i++)
            {
                if (matrix[1, i - 1] <= matrix[1, i])
                {
                    a1 = true;
                }
                if (matrix[1, i - 1] >= matrix[1, i])
                {
                    a2 = true;
                }
            }
            if (a1 == a2 && a1 == true)
            {
                return new int[,] { { 0 } };
            }
            if (a1 == a2 && a1 == false)
            {
                return new int[0, 0];
            }
            if (a1 == true)
            {
                return new int[,] { { 1 } };
            }
            return new int[,] { { -1 } };
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            int n = matrix.GetLength(1);
            if (n < 2)
            {
                return new int[0, 0];
            }
            bool allEqual = true;
            for (int i = 0; i < n - 1; i++)
            {
                if (matrix[1, i] != matrix[1, i + 1])
                {
                    allEqual = false;
                    break;
                }
            }
            if (allEqual)
            {
                return new int[0, 0];
            }
            int c = 0;
            int h = 0;
            for (int j = 0; j < n - 1; j++)
            {
                int dy = matrix[1, j + 1] - matrix[1, j];
                if (dy == 0) continue;

                int hj = dy > 0 ? 1 : -1;

                if (h == 0)
                {
                    h = hj;
                    c = 1;
                }
                else if (hj != h)
                {
                    c++;
                    h = hj;
                }
            }

            int[,] a = new int[c, 2];

            int idx = 0;
            int s = 0;
            h = 0;

            for (int j = 0; j < n - 1; j++)
            {
                int dy = matrix[1, j + 1] - matrix[1, j];
                if (dy == 0) continue;

                int hj = dy > 0 ? 1 : -1;

                if (h == 0)
                {
                    h = hj;
                }
                else if (hj != h)
                {
                    a[idx, 0] = matrix[0, s];
                    a[idx, 1] = matrix[0, j];
                    idx++;

                    s = j;
                    h = hj;
                }
            }

            a[idx, 0] = matrix[0, s];
            a[idx, 1] = matrix[0, n - 1];

            return a;
        }
        public int[,] FindLongestSeq(int[,] matrix)
        {
            if (matrix.GetLength(1) <= 1) return new int[,] { };
            int[,] v = FindAllSeq(matrix);
            int[,] a = new int[1, 2] { { 0, -1 } };
            for (int i = 0; i < v.GetLength(0); i++)
            {
                if (v[i, 1] - v[i, 0] > a[0, 1] - a[0, 0])
                {
                    a[0, 0] = v[i, 0];
                    a[0, 1] = v[i, 1];
                }
            }
            return a;
        }
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here
            answer = info(matrix);
            // end

            return answer;
        }
        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            int k = 0;
            int t = Math.Sign(func(a));
            if (t == 0)
            {
                t = 1;
            }
            for (double x = a+h; x<b+0.00001;x+=h)
            {
                int z = Math.Sign(func(x));
                if (z == 0)
                {
                    z = 1;
                }
                if (z != t && t!= 0)
                {
                    k++;
                }
                t = z;
            }
            
            return k;
        }
        public delegate double Func(double x);
        public double FuncA(double x)
        {
            return x * x - Math.Sin(x);
        }
        public double FuncB(double x)
        {
            return Math.Pow(Math.E, x) - 1;
        }
        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            // code here
            answer = CountSignFlips(a, b, h, func);
            // end

            return answer;
        }
        public delegate void Action(int[][] array);
        public void SortInCheckersOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i%2 == 0)
                {
                    Array.Sort(array[i]);
                }
                else
                {
                    Array.Sort(array[i]);
                    Array.Reverse(array[i]);
                }
            }
        }
        public void SortBySumDesc(int[][] array)
        {
            int[] s = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    s[i] += array[i][j];
                }
            }
            int k = 1;
            while (k<array.Length)
            {
                if (k == 0 || -s[k]>= -s[k-1])
                {
                    k++;
                }
                else
                {
                    (array[k], array[k - 1]) = (array[k - 1], array[k]);
                    (s[k], s[k - 1]) = (s[k - 1], s[k]);
                    k--;
                }
            }
        }
        public void TotalReverse(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Array.Reverse(array[i]);
            }
            Array.Reverse(array);
        }
        public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here
            func(array);
            // end

        }
    }
}
