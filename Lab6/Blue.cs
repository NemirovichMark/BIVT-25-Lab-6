using System;

namespace Lab6
{
    public class Blue
    {
        public void Task1(ref int[,] matrix)
        {
            // code here
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
                return;

            int maxIndex = FindDiagonalMaxIndex(matrix);
            if (maxIndex >= 0)
                RemoveRow(ref matrix, maxIndex);
            // end
        }

        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
                return -1;

            int maxVal = matrix[0, 0];
            int maxIndex = 0;

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > maxVal)
                {
                    maxVal = matrix[i, i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            if (matrix == null || rowIndex < 0 || rowIndex >= matrix.GetLength(0))
                return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] newMatrix = new int[rows - 1, cols];

            for (int i = 0, newRow = 0; i < rows; i++)
            {
                if (i == rowIndex)
                    continue;

                for (int j = 0; j < cols; j++)
                {
                    newMatrix[newRow, j] = matrix[i, j];
                }
                newRow++;
            }

            matrix = newMatrix;
        }






        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

            // code here
            double avgA = GetAverageExceptEdges(A);
            double avgB = GetAverageExceptEdges(B);
            double avgC = GetAverageExceptEdges(C);

            if (avgA < avgB && avgB < avgC)
                answer = 1;
            else if (avgA > avgB && avgB > avgC)
                answer = -1;
            // end

            return answer;
        }

        public double GetAverageExceptEdges(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return 0;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows * cols <= 2)
                return 0;

            int min = matrix[0, 0];
            int max = matrix[0, 0];
            double sum = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int val = matrix[i, j];
                    sum += val;

                    if (val < min) min = val;
                    if (val > max) max = val;
                }
            }

            sum -= (min + max);
            return sum / (rows * cols - 2);
        }






        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {
            // code here
            if (matrix == null)
                return;

            int colIndex = method(matrix);
            if (colIndex >= 0)
                RemoveColumn(ref matrix, colIndex);
            // end
        }

        public int FindUpperColIndex(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
                return -1;

            int n = matrix.GetLength(0);
            int maxVal = int.MinValue;
            int colIndex = -1;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        colIndex = j;
                    }
                }
            }

            return colIndex;
        }

        public int FindLowerColIndex(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
                return -1;

            int n = matrix.GetLength(0);
            int maxVal = int.MinValue;
            int colIndex = -1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        colIndex = j;
                    }
                }
            }

            return colIndex;
        }

        public void RemoveColumn(ref int[,] matrix, int col)
        {
            if (matrix == null || col < 0 || col >= matrix.GetLength(1))
                return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] newMatrix = new int[rows, cols - 1];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0, newCol = 0; j < cols; j++)
                {
                    if (j == col)
                        continue;

                    newMatrix[i, newCol] = matrix[i, j];
                    newCol++;
                }
            }

            matrix = newMatrix;
        }






        public void Task4(ref int[,] matrix)
        {
            // code here
            if (matrix == null)
                return;

            int cols = matrix.GetLength(1);

            for (int j = cols - 1; j >= 0; j--)
            {
                if (!CheckZerosInColumn(matrix, j))
                {
                    RemoveCol(ref matrix, j);
                }
            }
            // end
        }

        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            if (matrix == null || col < 0 || col >= matrix.GetLength(1))
                return false;

            int rows = matrix.GetLength(0);

            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, col] == 0)
                    return true;
            }

            return false;
        }

        public void RemoveCol(ref int[,] matrix, int col)
        {
            RemoveColumn(ref matrix, col);
        }






        public delegate int Finder(int[,] matrix, out int row, out int col);

        public void Task5(ref int[,] matrix, Finder find)
        {
            // code here
            if (matrix == null || matrix.Length == 0)
                return;

            int targetValue = find(matrix, out int foundRow, out int foundCol);

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            bool[] rowsToRemove = new bool[rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == targetValue)
                    {
                        rowsToRemove[i] = true;
                        break;
                    }
                }
            }

            for (int i = rows - 1; i >= 0; i--)
            {
                if (rowsToRemove[i])
                {
                    RemoveRow(ref matrix, i);
                }
            }
            // end
        }

        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;

            if (matrix == null || matrix.Length == 0)
                return 0;

            int maxVal = matrix[0, 0];
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }

            return maxVal;
        }

        public int FindMin(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;

            if (matrix == null || matrix.Length == 0)
                return 0;

            int minVal = matrix[0, 0];
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < minVal)
                    {
                        minVal = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }

            return minVal;
        }







        public delegate void SortRowsStyle(int[,] matrix, int row);

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





        public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);

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

            return answer;
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






        public delegate int[] GetTriangle(int[,] matrix);

        public int Task9(int[,] matrix, GetTriangle triangle)
        {
            int answer = 0;

            // code here
            answer = GetSum(triangle, matrix);
            // end

            return answer;
        }

        public int Sum(int[] array)
        {
            if (array == null)
                return 0;

            int sum = 0;

            foreach (int val in array)
            {
                sum += val * val;
            }

            return sum;
        }

        public int GetSum(GetTriangle transformer, int[,] matrix)
        {
            if (transformer == null || matrix == null)
                return 0;

            int[] triangle = transformer(matrix);
            return Sum(triangle);
        }

        public int[] GetUpperTriangle(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
                return new int[0];

            int n = matrix.GetLength(0);
            int size = n * (n + 1) / 2;
            int[] result = new int[size];
            int index = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    result[index] = matrix[i, j];
                    index++;
                }
            }

            return result;
        }

        public int[] GetLowerTriangle(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
                return new int[0];

            int n = matrix.GetLength(0);
            int size = n * (n + 1) / 2;
            int[] result = new int[size];
            int index = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    result[index] = matrix[i, j];
                    index++;
                }
            }

            return result;
        }






        public bool Task10(int[][] array, Predicate<int[][]> func)
        {
            bool res = false;

            // code here
            res = func(array);
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
            int[] mas = new int[n];
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
            {
                k = 0; m = 0;
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


