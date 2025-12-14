using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Xml;

namespace Lab6
{
    public class Blue
    {
        public void Task1(ref int[,] matrix)
        {

            // code here
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1)) return;
            int rowIndex = FindDiagonalMaxIndex(matrix);
            RemoveRow(ref matrix, rowIndex);
            // end

        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int d = Math.Min(n, m);

            int imax = 0;
            int maxel = int.MinValue;

            for (int i = 0; i < d; i++)
            {
                if (matrix[i, i] > maxel)
                {
                    maxel = matrix[i, i];
                    imax = i;
                }
            }
            return imax;
        }
        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (rowIndex < 0 || rowIndex >= n) return;
            if (n == 1)
            {
                matrix = new int[0, m];
                return;
            }

            int[,] result = new int[n - 1, m];

            for (int i = 0; i < rowIndex; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result[i, j] = matrix[i, j];
                }
            }
            for (int i = rowIndex + 1; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result[i - 1, j] = matrix[i, j];
                }
            }
            matrix = result;
        }
        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

            // code here
            double a1 = GetAverageExceptEdges(A);
            double a2 = GetAverageExceptEdges(B);
            double a3 = GetAverageExceptEdges(C);

            double[] array = { a1, a2, a3 };
            if (a1 < a2 && a2 < a3) answer = 1;
            else if (a1 > a2 && a2 > a3) answer = -1;
            // end

            return answer;
        }
        public double GetAverageExceptEdges(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int count = n * m;
            if (count <= 2) return 0.0;

            int maxel = FindMax(matrix);
            int minel = FindMin(matrix);

            int sumel = 0;
            bool flagmax = false;
            bool flagmin = false;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sumel += matrix[i, j];

                    if (matrix[i, j] == maxel && !flagmax)
                    {
                        sumel -= matrix[i, j];
                        flagmax = true;
                    }
                    else if (matrix[i, j] == minel && !flagmin)
                    {
                        sumel -= matrix[i, j];
                        flagmin = true;
                    }
                }
            }
            int del = count - 2;
            if (del == 0) return 0.0;
            return (double)sumel / del;
        }
        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            if (method == null) return;

            int col = method(matrix);
            RemoveColumn(ref matrix, col);
            // end

        }
        public int FindUpperColIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m) return 0;
            if (n == 1) return 0;

            int maxel = int.MinValue;
            int maxj = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (matrix[i, j] > maxel)
                    {
                        maxel = matrix[i, j];
                        maxj = j;
                    }
                }
            }

            return maxj;
        }
        public int FindLowerColIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m) return 0;

            int maxel = matrix[0, 0];
            int maxj = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (matrix[i, j] > maxel)
                    {
                        maxel = matrix[i, j];
                        maxj = j;
                    }
                }
            }

            return maxj;
        }
        public void RemoveColumn(ref int[,] matrix, int col)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (col < 0 || col >= cols) return;

            if (cols == 1)
            {
                matrix = new int[rows, 0];
                return;
            }

            int[,] res = new int[rows, cols - 1];

            for (int i = 0; i < rows; i++)
            {
                int nj = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j == col) continue;
                    res[i, nj++] = matrix[i, j];
                }
            }

            matrix = res;
        }
        public void Task4(ref int[,] matrix)
        {

            // code here
            int m = matrix.GetLength(1);

            bool flag = true;

            for (int j = m - 1; j >= 0; j--)
            {
                flag = CheckZerosInColumn(matrix, j);
                if (!flag)
                {
                    RemoveColumn(ref matrix, j);
                }
            }
            // end

        }
        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, col] == 0)
                {
                    return true;
                }
            }
            return false;
        }
        public void Task5(ref int[,] matrix, Finder find)
        {
            if (find == null) return;

            int r, c;
            int a = find(matrix, out r, out c);

            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                bool flag = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == a)
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    RemoveRow(ref matrix, i);
                }
            }
            // end
        }
        public delegate int Finder(int[,] matrix, out int row, out int col);
        public int FindMax(int[,] matrix)
        {
            int r, c;
            return FindMax(matrix, out r, out c);
        }
        public int FindMin(int[,] matrix)
        {
            int r, c;
            return FindMin(matrix, out r, out c);
        }
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int maxel = matrix[0, 0];
            row = 0;
            col = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > maxel)
                    {
                        maxel = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            return maxel;
        }

        public int FindMin(int[,] matrix, out int row, out int col)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int minel = matrix[0, 0];
            row = 0;
            col = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < minel)
                    {
                        minel = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            return minel;
        }
        public void Task6(int[,] matrix, SortRowsStyle sort)
        {

            // code here
            int n = matrix.GetLength(0);

            for (int i = 0; i < n; i += 3)
            {
                sort(matrix, i);
            }
            // end

        }
        public delegate void SortRowsStyle(int[,] matrix, int row);
        public void SortRowAscending(int[,] matrix, int row)
        {
            int m = matrix.GetLength(1);
            int[] array = new int[m];

            for (int j = 0; j < m; j++)
            {
                array[j] = matrix[row, j];
            }
            for (int i = 0; i < m - 1; i++)
            {
                for (int j = 0; j < m - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
            for (int j = 0; j < m; j++)
            {
                matrix[row, j] = array[j];
            }
        }
        public void SortRowDescending(int[,] matrix, int row)
        {
            int m = matrix.GetLength(1);
            int[] array = new int[m];

            for (int j = 0; j < m; j++)
            {
                array[j] = matrix[row, j];
            }
            for (int i = 0; i < m - 1; i++)
            {
                for (int j = 0; j < m - i - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
            for (int j = 0; j < m; j++)
            {
                matrix[row, j] = array[j];
            }
        }
        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {

            // code here
            int n = matrix.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                int m = FindMaxInRow(matrix, i);
                transform(matrix, i, m);
            }
            // end

        }
        public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);
        public int FindMaxInRow(int[,] matrix, int row)
        {
            int m = matrix.GetLength(1);
            int maxel = int.MinValue;

            for (int j = 0; j < m; j++)
            {
                if (matrix[row, j] > maxel)
                {
                    maxel = matrix[row, j];
                }
            }
            return maxel;
        }
        public void ReplaceByZero(int[,] matrix, int row, int maxValue)
        {
            int m = matrix.GetLength(1);

            for (int j = 0; j < m; j++)
            {
                if (matrix[row, j] == maxValue)
                {
                    matrix[row, j] = 0;
                }
            }
        }
        public void MultiplyByColumn(int[,] matrix, int row, int maxValue)
        {
            int m = matrix.GetLength(1);

            for (int j = 0; j < m; j++)
            {
                if (matrix[row, j] == maxValue)
                {
                    matrix[row, j] *= (j + 1);
                }
            }
        }
        public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
        {
            double[,] answer = null;

            // code here
            answer = GetSumAndY(a, b, h, getSum, getY);
            // end

            return answer;
        }
        public double[,] GetSumAndY(double a, double b, double h, Func<double, double> sum, Func<double, double> y)
        {
            if (sum == null || y == null) return null;
            if (h == 0) return null;

            if (a < b && h < 0) h = -h;
            if (a > b && h > 0) h = -h;

            double steps = (b - a) / h;
            int n = (int)Math.Round(steps) + 1;
            if (n <= 0) return null;

            double[,] res = new double[n, 2];

            for (int i = 0; i < n; i++)
            {
                double x = a + i * h;
                res[i, 0] = sum(x);
                res[i, 1] = y(x);
            }

            return res;

        }
        public double SumA(double x)
        {
            double sum = 1.0;
            double fact = 1.0;

            for (int i = 1; i <= 10; i++)
            {
                fact *= i;
                sum += Math.Cos(i * x) / fact;
            }
            return sum;
        }
        public double YA(double x)
        {
            return Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x));
        }
        public double SumB(double x)
        {
            double s = -2.0 * Math.PI * Math.PI / 3.0;

            for (double i = 1; ; i += 1.0)
            {
                double sign = (i % 2 == 0) ? 1.0 : -1.0;
                s += sign * Math.Cos(i * x) / (i * i);

                if (Math.Abs(sign * Math.Cos(i * x) / (i * i)) < 0.000001) break;
            }

            return s;
        }
        public double YB(double x)
        {
            return (x * x) / 4.0 - 3.0 * (Math.PI * Math.PI) / 4.0;
        }

        public int Task9(int[,] matrix, GetTriangle triangle)
        {
            int answer = 0;

            // code here
            if (matrix == null || triangle == null) return 0;
            answer = GetSum(triangle, matrix);
            // end

            return answer;
        }
        public delegate int[] GetTriangle(int[,] matrix);
        public int Sum(int[] array)
        {
            if (array == null) return 0;
            int n = array.Length;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += (array[i] * array[i]);
            }

            return sum;
        }
        public int GetSum(GetTriangle transformer, int[,] matrix)
        {
            if (transformer == null || matrix == null) return 0;

            int[] array = transformer(matrix);
            int sum = Sum(array);

            return sum;
        }
        public int[] GetUpperTriangle(int[,] matrix)
        {
            if (matrix == null) return null;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m) return null;

            int count = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    count++;
                }
            }

            int[] array = new int[count];
            int k = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    array[k] = matrix[i, j];
                    k++;
                }
            }

            return array;
        }
        public int[] GetLowerTriangle(int[,] matrix)
        {
            if (matrix == null) return null;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m) return null;

            int count = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    count++;
                }
            }

            int[] array = new int[count];
            int k = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    array[k] = matrix[i, j];
                    k++;
                }
            }

            return array;
        }
        public bool Task10(int[][] array, Predicate<int[][]> func)
        {
            bool res = false;

            // code here
            if (array == null || func == null) return false;
            res = func(array);
            // end

            return res;
        }
        public delegate int Predicate(int[][] array);
        public bool CheckTransformAbility(int[][] array)
        {
            if (array == null || array.Length == 0) return false;

            int n = array.GetLength(0);
            bool answer = false;

            int count = 0;

            for (int i = 0; i < n; i++)
            {
                if (array[i] == null) return false;
                count += array[i].Length;
            }

            if (count % n == 0) answer = true;

            return answer;
        }
        public bool CheckSumOrder(int[][] array)
        {
            if (array == null || array.Length == 0) return false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null) return false;
            }
                
            if (array.Length == 1) return true;

            int sum = 0;
            for (int j = 0; j < array[0].Length; j++)
            {
                sum += array[0][j];
            }

            bool f1 = true, f2 = true;

            for (int i = 1; i < array.Length; i++)
            {
                int s = 0;
                for (int j = 0; j < array[i].Length; j++) 
                {
                    s += array[i][j];
                }
                if (s <= sum) f1 = false;
                if (s >= sum) f2 = false;

                sum = s;
            }
            if (f1 || f2) return true;

            return false;
        }
        public bool CheckArraysOrder(int[][] array)
        {
            if (array == null || array.Length == 0) return false;

            for (int i = 0; i < array.Length; i++)
            {
                int[] r = array[i];
                if (r == null) return false;

                if (r.Length <= 1) return true;

                bool f1 = true, f2 = true;

                for (int j = 1; j < r.Length; j++)
                {
                    if (r[j] < r[j - 1]) f1 = false;
                    if (r[j] > r[j - 1]) f2 = false;
                }

                if (f1 || f2) return true;
            }

            return false;
        }
    }
}