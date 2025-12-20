using System;
using System.Globalization;
using System.Security.Cryptography;
using static Lab6.Blue;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Blue
    {
        public void Task1(ref int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (n == m)
            {
                int rowIndex = FindDiagonalMaxIndex(matrix);
                RemoveRow(ref matrix, rowIndex);
            }
            // end

        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int max = int.MinValue, rowIndex = 0;
            for (int i = 0; i < n; i++)
                if (matrix[i, i] > max)
                { max = matrix[i, i]; rowIndex = i; }
            return rowIndex;
        }

        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int n = matrix.GetLength(0);
            int[,] mas = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i < rowIndex)
                        mas[i, j] = matrix[i, j];
                    else if (i == rowIndex) continue;
                    else if (i > rowIndex)
                        mas[i - 1, j] = matrix[i, j];
                }
            }
            matrix = mas;
        }
        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

            // code here
            double[] mas = { GetAverageExceptEdges(A), GetAverageExceptEdges(B), GetAverageExceptEdges(C) };
            if (mas[0] < mas[1] && mas[1] < mas[2])
                answer = 1;
            else if (mas[0] > mas[1] && mas[1] > mas[2])
                answer = -1;
            else
                answer = 0;

            // end

            return answer;
        }
        public double GetAverageExceptEdges(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int max = int.MinValue, min = int.MaxValue;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    { max = matrix[i, j]; }
                    if (matrix[i, j] < min)
                    { min = matrix[i, j]; }
                }
            double sum = 0; int k = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] != max || matrix[i, j] != min)
                    { sum += matrix[i, j]; k++; }
            double sr = sum / k;
            return sr;
        }
        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int col = method(matrix);
            if (n != m || method == null) return;
            RemoveColumn(ref matrix, col);
            // end

        }
        public int FindUpperColIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1), max = int.MinValue, col = 0;
            for (int i = 0; i < n - 1; i++)
                for (int j = 1; j < m; j++)
                    if (i < j && matrix[i, j] > max)
                    { max = matrix[i, j]; col = j; }
            return col;
        }
        public int FindLowerColIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1), max = int.MinValue, col = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (i >= j && matrix[i, j] > max)
                    { max = matrix[i, j]; col = j; }
            return col;
        }
        public void RemoveColumn(ref int[,] matrix, int col)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (col < 0 || col >= m) return;
            int[,] mat = new int[n, m - 1];
            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (j < col)
                        mat[i, j] = matrix[i, j];
                    if (j == col)
                        continue;
                    if (j > col)
                        mat[i, j - 1] = matrix[i, j];
                }
            }
            matrix = mat;
        }

        public void Task4(ref int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int j = m - 1; j >= 0; j--)
                if (!CheckZerosInColumn(matrix, j))
                    RemoveColumn(ref matrix, j);
            // end

        }
        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            bool flag = false;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, col] == 0)
                    flag = true;
            }
            return flag;
        }
        public void Task5(ref int[,] matrix, Finder find)
        {

            // code here
            if (find == null) return;
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int row, col;
            int c = find(matrix, out row, out col);
            for (int i = 0; i < n; i++)
            {
                bool flag = false;
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] == c)
                        flag = true;
                if (flag)
                { RemoveRow(ref matrix, i); n--; }
            }
            // end

        }
        public delegate int Finder(int[,] matrix, out int row, out int col);
        public int FindMax(int[,] matrix)
        {
            int row, col;
            return FindMax(matrix, out row, out col);
        }
        public int FindMin(int[,] matrix)
        {
            int row, col;
            return FindMin(matrix, out row, out col);
        }
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int max = int.MinValue; row = 0; col = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] > max)
                    { max = matrix[i, j]; row = i; col = j; }
            return max;
        }
        public int FindMin(int[,] matrix, out int row, out int col)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int min = int.MaxValue; row = 0; col = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] < min)
                    { min = matrix[i, j]; row = i; col = j; }
            return min;
        }

        public void Task6(int[,] matrix, SortRowsStyle sort)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (sort == null) return;
            for (int i = 0; i < n; i++)
                if ((i) % 3 == 0)
                    sort(matrix, i);
            // end

        }
        public delegate void SortRowsStyle(int[,] matrix, int row);
        public void SortRowAscending(int[,] matrix, int row)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int k = 0; k < m; k++)
                for (int j = 0; j < m - k - 1; j++)
                    if (matrix[row, j] > matrix[row, j + 1])
                        (matrix[row, j], matrix[row, j + 1]) = (matrix[row, j + 1], matrix[row, j]);
        }
        public void SortRowDescending(int[,] matrix, int row)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int k = 0; k < m; k++)
                for (int j = 0; j < m - k - 1; j++)
                    if (matrix[row, j] < matrix[row, j + 1])
                        (matrix[row, j], matrix[row, j + 1]) = (matrix[row, j + 1], matrix[row, j]);
        }
        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1); int max;
            if (transform == null) return;
            for (int i = 0; i < n; i++)
            {
                max = FindMaxInRow(matrix, i);
                transform(matrix, i, max);
            }
            // end

        }
        public int FindMaxInRow(int[,] matrix, int row)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int maxValue = int.MinValue;
            for (int j = 0; j < m; j++)
                if (matrix[row, j] > maxValue)
                { maxValue = matrix[row, j]; }
            return maxValue;
        }
        public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);
        public void ReplaceByZero(int[,] matrix, int row, int maxValue)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int j = 0; j < m; j++)
                if (matrix[row, j] == maxValue)
                { matrix[row, j] = 0; }
        }
        public void MultiplyByColumn(int[,] matrix, int row, int maxValue)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int j = 0; j < m; j++)
                if (matrix[row, j] == maxValue)
                    matrix[row, j] = maxValue * (j + 1);
        }
        public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
        {
            double[,] answer = null;

            // code here
            return GetSumAndY(a, b, h, getSum, getY);
            // end

        }
        public double[,] GetSumAndY(double a, double b, double h, Func<double, double> sum, Func<double, double> y)
        {
            if (sum == null || y == null || a > b || h <= 0) return null;
            int k = 0;
            for (double i = a; i <= b + 1e-10; i += h)
                k++;
            double[,] mat = new double[k, 2];
            double x = a;
            for (int i = 0; i < k; i++)
            {
                mat[i, 0] = sum(x);
                mat[i, 1] = y(x);
                x += h;
            }
            return mat;
        }
        private static long Factorial(int k)
        {
            if (k <= 1) return 1;
            long r = 1;
            for (int i = 2; i <= k; i++)
                r *= i;
            return r;
        }
        public double SumA(double x)
        {
            double s = 1.0;
            int i = 1; double t;
            do
            {
                t = Math.Cos(i * x) / Factorial(i);
                s += t;
                i++;
            }
            while (Math.Abs(t) > 1e-10 && i <= 10);
            return s;

        }

        public double YA(double x)
        {
            double y = Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x));
            return y;
        }
        public double SumB(double x)
        {
            double s = -2.0 * Math.PI * Math.PI / 3.0, mn = -1, t = 1;
            for (int i = 1; Math.Abs(t) >= 0.000001; i++)
            {
                t = mn * (Math.Cos(i * x) / (i * i));
                mn *= -1;
                s += t;
            }
            return s;
        }

        public double YB(double x)
        {
            double y = (x * x / 4) - (Math.PI * Math.PI * 3) / 4;
            return y;
        }

        public int Task9(int[,] matrix, GetTriangle triangle)
        {
            int answer = 0;

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (n == m)
                answer = GetSum(triangle, matrix);
            // end

            return answer;
        }
        public delegate int[] GetTriangle(int[,] matrix);
        public int[] GetUpperTriangle(int[,] matrix)
        {
            int n=matrix.GetLength(0), m=matrix.GetLength(1);
            int k = 0;
            for (int i = 0; i < n; i++)
                for (int j = i; j < m; j++)
                    if (i <= j)
                        k++;
            int[] mas = new int[k]; k = 0;
            for (int i=0;i<n;i++)
                for (int j=i;j<m;j++)
                    if (i<=j)
                       mas[k++]=matrix[i,j];
            return mas;
        }
        public int[] GetLowerTriangle(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int k = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j <= i; j++)
                    if (i >= j)
                        k++;
            int[] mas = new int[k];  k = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j <=i; j++)
                    if (i>=j)
                        mas[k++] = matrix[i, j];
            return mas;
        }
        public int Sum(int[] array)
        {
            int s = 0;
            for (int i=0;i<array.Length;i++)
                s += (array[i]* array[i]);
            return s;
        }
        public int GetSum(GetTriangle transformer, int[,] matrix)
        {
            int[] triangle = transformer(matrix);
            int s = Sum(triangle);
            return s;
        }
        public bool Task10(int[][] array, Predicate<int[][]> func)
        {
            bool res = false;

            // code here
            res=func(array);
            // end

            return res;
        }
        public delegate bool Predicate(int[][] array);
        public bool CheckTransformAbility(int[][] array)
        {
            int n = array.Length, s = 0;
            for (int i = 0; i < n; i++)
                s += array[i].Length;
            if (s % n == 0)
                return true;
            return false;
        
        }
        public bool CheckSumOrder(int[][] array)
        {
            int n = array.Length;
            int[] mas= new int[n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < array[i].Length; j++)
                    mas[i] += array[i][j];
             int k = 0, m = 0;
            for (int i = 0; i < mas.Length - 1; i++)
            {
                if (mas[i] > mas[i + 1])
                    k++;
                if (mas[i] < mas[i + 1])
                    m++;
            }
            if (k == mas.Length - 1 || m == mas.Length - 1)
                return true;
            return false;

        }
        public bool CheckArraysOrder(int[][] array)
        {
            int n = array.Length;
            int k = 0, m = 0;
            for (int i = 0; i < n; i++)
            { k = 0; m = 0;
                for (int j = 0; j < array[i].Length - 1; j++)
                {
                    if (array[i][j] >= array[i][j + 1])
                        k++;
                    if (array[i][j] <= array[i][j + 1])
                        m++;
                }
                if (k == array[i].Length - 1 || m == array[i].Length - 1)
                    return true;
            }
            return false;
        }
    }
}
