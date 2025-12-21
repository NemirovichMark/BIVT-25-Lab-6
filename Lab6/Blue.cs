using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Lab6
{
    public class Blue
    {
        public delegate int Finder(int[,] matrix, out int row, out int col);
        public delegate int Func(int[,] matrix);
        public delegate void SortRowsStyle(int[,] matrix, int row);
        public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);
        public delegate int[] GetTriangle(int[,] matrix);

        public void Task1(ref int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(0) != matrix.GetLength(1)) return;
            RemoveRow(ref matrix, FindDiagonalMaxIndex(matrix));
        }

        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            double[] avgs = { GetAverageExceptEdges(A), GetAverageExceptEdges(B), GetAverageExceptEdges(C) };
            if (avgs[0] < avgs[1] && avgs[1] < avgs[2]) return 1;
            if (avgs[0] > avgs[1] && avgs[1] > avgs[2]) return -1;
            return 0;
        }

        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) return;
            int col = method(matrix);
            if (col >= 0) RemoveColumn(ref matrix, col);
        }

        public void Task4(ref int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0) return;
            for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                if (!CheckZerosInColumn(matrix, j))
                    RemoveColumn(ref matrix, j);
        }

        public void Task5(ref int[,] matrix, Finder find)
        {
            if (matrix == null || matrix.GetLength(0) == 0) return;
            int target = find(matrix, out _, out _);
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                bool contains = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] == target) { contains = true; break; }
                if (contains) RemoveRow(ref matrix, i);
            }
        }

        public void Task6(int[,] matrix, SortRowsStyle sort)
        {
            if (matrix == null) return;
            for (int i = 0; i < matrix.GetLength(0); i += 3)
                sort(matrix, i);
        }

        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {
            if (matrix == null) return;
            for (int i = 0; i < matrix.GetLength(0); i++)
                transform(matrix, i, FindMaxInRow(matrix, i));
        }

        public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
        {
            int count = (int)Math.Round((b - a) / h) + 1;
            double[,] res = new double[count, 2];
            for (int i = 0; i < count; i++)
            {
                double x = a + i * h;
                res[i, 0] = getSum(x);
                res[i, 1] = getY(x);
            }
            return res;
        }

        public int Task9(int[,] matrix, GetTriangle triangle)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(0) != matrix.GetLength(1)) return 0;
            return Sum(triangle(matrix));
        }

        public bool Task10(int[][] array, Predicate<int[][]> func) => func != null && array != null && func(array);

        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int max = matrix[0, 0], idx = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
                if (matrix[i, i] > max) { max = matrix[i, i]; idx = i; }
            return idx;
        }

        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            if (rowIndex < 0 || rowIndex >= rows) return;
            int[,] res = new int[rows - 1, cols];
            for (int i = 0, r = 0; i < rows; i++)
            {
                if (i == rowIndex) continue;
                for (int j = 0; j < cols; j++) res[r, j] = matrix[i, j];
                r++;
            }
            matrix = res;
        }

        public double GetAverageExceptEdges(int[,] matrix)
        {
            if (matrix == null || matrix.Length <= 2) return 0;
            int max = matrix[0, 0], min = matrix[0, 0];
            double sum = 0;
            foreach (int x in matrix)
            {
                if (x > max) max = x;
                if (x < min) min = x;
                sum += x;
            }
            return (sum - max - min) / (matrix.Length - 2);
        }

        public int FindUpperColIndex(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) return -1;
            int n = matrix.GetLength(0);
            int max = int.MinValue, resCol = -1;
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (matrix[i, j] > max) { max = matrix[i, j]; resCol = j; }
            return resCol;
        }

        public int FindLowerColIndex(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) return -1;
            int n = matrix.GetLength(0);
            int max = int.MinValue, resCol = -1;
            for (int i = 0; i < n; i++)
                for (int j = 0; j <= i; j++)
                    if (matrix[i, j] > max) { max = matrix[i, j]; resCol = j; }
            return resCol;
        }

        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                if (matrix[i, col] == 0) return true;
            return false;
        }

        public void RemoveColumn(ref int[,] matrix, int col)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            if (col < 0 || col >= cols) return;
            int[,] res = new int[rows, cols - 1];
            for (int i = 0; i < rows; i++)
                for (int j = 0, c = 0; j < cols; j++)
                {
                    if (j == col) continue;
                    res[i, c++] = matrix[i, j];
                }
            matrix = res;
        }

        public int FindMax(int[,] matrix, out int row, out int col)
        {
            int max = matrix[0, 0]; row = 0; col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > max) { max = matrix[i, j]; row = i; col = j; }
            return max;
        }

        public int FindMin(int[,] matrix, out int row, out int col)
        {
            int min = matrix[0, 0]; row = 0; col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] < min) { min = matrix[i, j]; row = i; col = j; }
            return min;
        }

        public void SortRowAscending(int[,] matrix, int row)
        {
            int n = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n - 1; j++)
                    if (matrix[row, j] > matrix[row, j + 1])
                        (matrix[row, j], matrix[row, j + 1]) = (matrix[row, j + 1], matrix[row, j]);
        }

        public void SortRowDescending(int[,] matrix, int row)
        {
            int n = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n - 1; j++)
                    if (matrix[row, j] < matrix[row, j + 1])
                        (matrix[row, j], matrix[row, j + 1]) = (matrix[row, j + 1], matrix[row, j]);
        }

        public int FindMaxInRow(int[,] matrix, int row)
        {
            int max = matrix[row, 0];
            for (int j = 1; j < matrix.GetLength(1); j++)
                if (matrix[row, j] > max) max = matrix[row, j];
            return max;
        }

        public void ReplaceByZero(int[,] matrix, int row, int maxValue)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (matrix[row, j] == maxValue) matrix[row, j] = 0;
        }

        public void MultiplyByColumn(int[,] matrix, int row, int maxValue)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (matrix[row, j] == maxValue) matrix[row, j] *= (j + 1);
        }

        public double SumA(double x)
        {
            double s = 1.0, fact = 1.0;
            for (int i = 1; i <= 20; i++) { fact *= i; s += Math.Cos(i * x) / fact; }
            return s;
        }
        public double YA(double x) => Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
        
        public double SumB(double x)
        {
            double S = -2.0 * Math.PI * Math.PI / 3.0, sign = 1, t = 1;

            for (int i = 1; Math.Abs(t) >= 0.000001; i++)
            {
                sign *= -1;
                t = sign * (Math.Cos(i * x) / (i * i));
                S += t;
            }

            return S;
        }
        public double YB(double x) => (x * x - 3.0 * Math.PI * Math.PI) / 4.0;

        public int Sum(int[] array) => array.Sum(x => x * x);

        public int[] GetUpperTriangle(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int[] res = new int[n * (n + 1) / 2];
            for (int i = 0, k = 0; i < n; i++)
                for (int j = i; j < n; j++) res[k++] = matrix[i, j];
            return res;
        }

        public int[] GetLowerTriangle(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int[] res = new int[n * (n + 1) / 2];
            for (int i = 0, k = 0; i < n; i++)
                for (int j = 0; j <= i; j++) res[k++] = matrix[i, j];
            return res;
        }

        public bool CheckTransformAbility(int[][] array)
        {
            if (array == null || array.Length == 0) return false;
            int total = 0;
            foreach(var r in array) if (r != null) total += r.Length;
            return total % array.Length == 0;
        }

        public bool CheckSumOrder(int[][] array)
        {
            if (array == null || array.Length == 0) return false;
            if (array.Length == 1) return true;
            double[] sums = array.Select(r => (double)(r?.Sum() ?? 0)).ToArray();
            bool asc = true, desc = true;
            for (int i = 1; i < sums.Length; i++)
            {
                if (sums[i] <= sums[i - 1]) asc = false;
                if (sums[i] >= sums[i - 1]) desc = false;
            }
            return asc || desc;
        }

        public bool CheckArraysOrder(int[][] array)
        {
            if (array == null) return false;
            if (array.Length == 0) return true;
            foreach (var r in array)
            {
                if (r == null) continue;
                if (r.Length < 2) return true;
                bool asc = true, desc = true;
                for (int j = 1; j < r.Length; j++)
                {
                    if (r[j] <= r[j - 1]) asc = false;
                    if (r[j] >= r[j - 1]) desc = false;
                }
                if (asc || desc) return true;
            }
            return false;
        }
    }
}