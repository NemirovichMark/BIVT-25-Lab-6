using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Lab6
{
    public delegate int[] GetTriangle(int[,] matrix);

    public class Blue
    {
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows == cols || rows != 0)
            {
                int maxIndex = 0;
                int maxValue = matrix[0, 0];

                for (int i = 1; i < rows; i++)
                {
                    if (matrix[i, i] > maxValue)
                    {
                        maxValue = matrix[i, i];
                        maxIndex = i;
                    }
                }

                return maxIndex;
            }

            return -1;
        }

        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rowIndex >= 0 || rowIndex < rows)
            {
                if (rows == 1)
                {
                    matrix = new int[0, cols];
                    return;
                }

                int[,] newMatrix = new int[rows - 1, cols];

                int newRow = 0;
                for (int i = 0; i < rows; i++)
                {
                    if (i == rowIndex) continue;

                    for (int j = 0; j < cols; j++)
                    {
                        newMatrix[newRow, j] = matrix[i, j];
                    }

                    newRow++;
                }

                matrix = newMatrix;
            }
        }

        public void Task1(ref int[,] matrix)
        {
            if (matrix == null)
            {
                return;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != cols)
            {
                return;
            }

            if (rows == 0)
            {
                return;
            }

            int rowIndexToRemove = FindDiagonalMaxIndex(matrix);

            RemoveRow(ref matrix, rowIndexToRemove);
        }

        public double GetAverageExceptEdges(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);


            double total_s = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if ((i == 0 && j == 0) || (i == rows - 1 && j == cols - 1))
                    {
                        continue;
                    }

                    total_s += matrix[i, j];
                }
            }

            double answer = ((total_s) / (rows * cols - 2));

            return answer;
        }

        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

            // code here

            double avg_A = GetAverageExceptEdges(A);
            double avg_B = GetAverageExceptEdges(B);
            double avg_C = GetAverageExceptEdges(C);

            if (avg_A > avg_B && avg_B > avg_C)
            {
                answer = -1;
            }

            if (avg_A < avg_B && avg_B < avg_C)
            {
                answer = 1;
            }
            // end

            return answer;
        }

        public void RemoveColumn(ref int[,] matrix, int col)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] res = new int[rows, cols - 1];

            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (j == col) continue;
                    res[i, count] = matrix[i, j];
                    count++;
                }
                count = 0;
            }


            matrix = res;
        }

        public int FindUpperColIndex(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);


            int max_v = -999;
            int res = -1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = i + 1; j < cols; j++)
                {
                    if (matrix[i, j] > max_v)
                    {
                        max_v = matrix[i, j];
                        res = j;
                    }
                }
            }
            return res;
        }

        public int FindLowerColIndex(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);


            int max_v = -999;
            int res = -1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (matrix[i, j] > max_v)
                    {
                        max_v = matrix[i, j];
                        res = j;
                    }
                }
            }
            return res;
        }

        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (matrix == null || rows != cols)
            {
                return;
            }

            int col = method(matrix);
            RemoveColumn(ref matrix, col);


            // end

        }

        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            int rows = matrix.GetLength(0);
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, col] == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveCol(ref int[,] matrix, int col)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] res = new int[rows, cols - 1];
            int count;
            for (int i = 0; i < rows; i++)
            {
                count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j == col)
                    {
                        continue;

                    }
                    else
                    {
                        res[i, count] = matrix[i, j];
                        count++;
                    }

                }
            }
            matrix = res;
        }

        public void Task4(ref int[,] matrix)
        {

            // code here

            int cols = matrix.GetLength(1);
            int cur_pos = 0;
            for (int i = 0; i < cols; i++)
            {
                if (CheckZerosInColumn(matrix, cur_pos) == false)
                {
                    RemoveColumn(ref matrix, cur_pos);
                }
                else
                {
                    cur_pos++;
                }
            }

            // end

        }

        public int FindMax(int[,] matrix, out int row, out int col)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);


            int cur_Max = -999;
            row = 0; col = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > cur_Max)
                    {
                        cur_Max = matrix[i, j];
                        row = i; col = j;
                    }
                }
            }
            return cur_Max;
        }

        public int FindMin(int[,] matrix, out int row, out int col)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);


            int cur_Min = 999;
            row = 0; col = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < cur_Min)
                    {
                        cur_Min = matrix[i, j];
                        row = i; col = j;
                    }
                }
            }
            return cur_Min;
        }


        public delegate int Finder(int[,] matrix, out int row, out int col);



        public void Task5(ref int[,] matrix, Finder find)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int row, col;

            int initial_value = find(matrix, out row, out col);
            while (initial_value == find(matrix, out row, out col))
            {
                RemoveRow(ref matrix, row);
            }


            // end

        }

        public void SortRowAscending(int[,] matrix, int row)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] res = new int[rows, cols];
            int[] targetrow = new int[cols];


            for (int i = 0; i < cols; i++)
            {
                targetrow[i] = matrix[row, i];
            }

            Array.Sort(targetrow);

            for (int j = 0; j < cols; j++)
            {
                matrix[row, j] = targetrow[j];
            }

        }

        public void SortRowDescending(int[,] matrix, int row)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] res = new int[rows, cols];
            int[] targetrow = new int[cols];


            for (int i = 0; i < cols; i++)
            {
                targetrow[i] = matrix[row, i];
            }

            Array.Sort(targetrow);
            Array.Reverse(targetrow);

            for (int j = 0; j < cols; j++)
            {
                matrix[row, j] = targetrow[j];
            }
        }


        public delegate void SortRowsStyle(int[,] matrix, int row);

        public void Task6(int[,] matrix, SortRowsStyle sort)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                if (i % 3 == 0)
                {
                    sort(matrix, i);
                }
            }

            // end

        }

        public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);


        public int FindMaxInRow(int[,] matrix, int row)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int cur_max = -999;
            for (int j = 0; j < cols; j++)
            {
                if (matrix[row, j] > cur_max)
                {
                    cur_max = matrix[row, j];
                }
            }
            return cur_max;
        }
        public void ReplaceByZero(int[,] matrix, int row, int maxValue)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                if (matrix[row, j] == maxValue)
                {
                    matrix[row, j] = 0;
                }
            }
        }

        public void MultiplyByColumn(int[,] matrix, int row, int maxValue)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                if (matrix[row, j] == maxValue)
                {
                    matrix[row, j] = maxValue * (j + 1);
                }
            }
        }


        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int m_elem = FindMaxInRow(matrix, i);
                transform(matrix, i, m_elem);
            }


            // end

        }


        public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
        {
            return GetSumAndY(a, b, h, getSum, getY);
        }

        public double[,] GetSumAndY(double a, double b, double h, Func<double, double> sum, Func<double, double> y)
        {
            if (h == 0) return new double[0, 0];
            int count = (int)Math.Floor((b - a) / h + 0.5) + 1;
            if (count <= 0) count = 0;
            double eps = 1e-12;

            int actualCount = 0;
            for (int k = 0; k < count; k++)
            {
                double x = a + k * h;
                if (h > 0 && x > b + 1e-12) break;
                if (h < 0 && x < b - 1e-12) break;
                actualCount++;
            }

            double[] sums = new double[actualCount];
            double[] ys = new double[actualCount];

            int index = 0;
            for (int k = 0; k < count; k++)
            {
                double x = a + k * h;
                if (h > 0 && x > b + 1e-12) break;
                if (h < 0 && x < b - 1e-12) break;

                double sVal = sum(x);
                double yVal = y(x);
                sums[index] = sVal;
                ys[index] = yVal;
                index++;
            }

            double[,] result = new double[actualCount, 2];
            for (int i = 0; i < actualCount; i++)
            {
                result[i, 0] = sums[i];
                result[i, 1] = ys[i];
            }
            return result;
        }

        public double SumFactorial(double x)
        {
            double eps = 1e-12;
            double s = 1.0;
            double term;
            double factorial = 1.0;
            for (int i = 1; i < 1000; i++)
            {
                factorial *= i;
                term = Math.Cos(i * x) / factorial;
                s += term;
                if (Math.Abs(term) < eps) break;
            }
            return s;
        }

        public double YFactorial(double x)
        {
            return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
        }

        public double SumA(double x)
        {
            return SumFactorial(x);
        }
        public double YA(double x)
        {
            return YFactorial(x);
        }

        public double SumB(double x)
        {
            double epsSum = 1e-6;
            double s = 0.0;
            for (int i = 1; i <= 200000; i++)
            {
                double sign = (i % 2 == 0) ? 1.0 : -1.0;
                double term = sign * Math.Cos(i * x) / (i * (double)i);
                s += term;
                if (Math.Abs(term) < epsSum) break;
            }
            double shift = -2.0 * Math.PI * Math.PI / 3.0;
            return s + shift;
        }

        public double YB(double x)
        {
            return x * x / 4.0 - Math.PI * Math.PI / 12.0 - 2.0 * Math.PI * Math.PI / 3.0;
        }

        public int Sum(int[] array)
        {
            if (array == null) return 0;
            long acc = 0;
            foreach (var v in array)
            {
                acc += (long)v * (long)v;
                if (acc > int.MaxValue) acc = acc % int.MaxValue;
            }
            return (int)acc;
        }

        public int GetSum(GetTriangle transformer, int[,] matrix)
        {
            if (transformer == null || matrix == null) return 0;
            int[] arr = transformer(matrix);
            return Sum(arr);
        }

        public int[] GetUpperTriangle(int[,] matrix)
        {
            if (matrix == null) return new int[0];
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < m; j++)
                {
                    count++;
                }
            }

            int[] result = new int[count];
            int index = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < m; j++)
                {
                    result[index++] = matrix[i, j];
                }
            }

            return result;
        }

        public int[] GetLowerTriangle(int[,] matrix)
        {
            if (matrix == null) return new int[0];
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i && j < m; j++)
                {
                    count++;
                }
            }

            int[] result = new int[count];
            int index = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i && j < m; j++)
                {
                    result[index++] = matrix[i, j];
                }
            }

            return result;
        }

        public int Task9(int[,] matrix, GetTriangle triangle)
        {
            if (matrix == null || triangle == null) return 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols) return 0;
            int[] arr = triangle(matrix);
            return Sum(arr);
        }

        public bool Task10(int[][] array, Predicate<int[][]> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));
            return func(array);
        }

        public bool CheckTransformAbility(int[][] array)
        {
            if (array == null) return false;
            int rows = array.Length;
            if (rows == 0) return true;
            long total = 0;
            foreach (var row in array) if (row != null) total += row.Length;
            return total % rows == 0;
        }

        public bool CheckSumOrder(int[][] array)
        {
            if (array == null) return false;
            int n = array.Length;
            if (n <= 1) return true;

            double[] sums = new double[n];
            for (int i = 0; i < n; i++)
                sums[i] = (array[i] == null) ? 0.0 : array[i].Sum(x => (double)x);

            bool strictlyInc = true;
            bool strictlyDec = true;
            for (int i = 1; i < n; i++)
            {
                if (!(sums[i] > sums[i - 1])) strictlyInc = false;
                if (!(sums[i] < sums[i - 1])) strictlyDec = false;
            }
            return strictlyInc || strictlyDec;
        }

        public bool CheckArraysOrder(int[][] array)
        {
            if (array == null) return false;
            foreach (var row in array)
            {
                if (row == null) continue;
                if (row.Length <= 1) return true;
                bool inc = true, dec = true;
                for (int i = 1; i < row.Length; i++)
                {
                    if (!(row[i] > row[i - 1])) inc = false;
                    if (!(row[i] < row[i - 1])) dec = false;
                }
                if (inc || dec) return true;
            }
            return false;
        }
    }
}