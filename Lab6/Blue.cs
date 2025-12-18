using System;

namespace Lab6
{
    public delegate int Finder(int[,] matrix, out int row, out int col);
    public delegate void SortRowsStyle(int[,] matrix, int row);
    public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);
    public delegate int[] GetTriangle(int[,] matrix);

    public class Blue
    {
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int maxIndex = -1;
            int maxValue = -9999999;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > maxValue)
                {
                    maxValue = matrix[i, i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= matrix.GetLength(0))
            {
                return;
            }

            int oldRows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] temp = new int[oldRows - 1, cols];

            int currentRow = 0;
            for (int i = 0; i < oldRows; i++)
            {
                if (i != rowIndex)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        temp[currentRow, j] = matrix[i, j];
                    }
                    currentRow = currentRow + 1;
                }
            }
            matrix = temp;
        }

        public void Task1(ref int[,] matrix)
        {
            if (matrix == null) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;

            int index = FindDiagonalMaxIndex(matrix);
            if (index != -1)
            {
                RemoveRow(ref matrix, index);
            }
        }

        public double GetAverageExceptEdges(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0) return 0;

            int max = -9999999;
            int min = 9999999;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max) max = matrix[i, j];
                    if (matrix[i, j] < min) min = matrix[i, j];
                }
            }

            double sum = 0;
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != max && matrix[i, j] != min)
                    {
                        sum = sum + matrix[i, j];
                        count = count + 1;
                    }
                }
            }

            if (count == 0)
            {
                return 0;
            }
            return sum / count;
        }

        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            double avgA = GetAverageExceptEdges(A);
            double avgB = GetAverageExceptEdges(B);
            double avgC = GetAverageExceptEdges(C);

            if (avgA < avgB && avgB < avgC)
            {
                return 1;
            }
            if (avgA > avgB && avgB > avgC)
            {
                return -1;
            }
            return 0;
        }

        public int FindUpperColIndex(int[,] matrix)
        {
            int maxVal = -999999;
            int resCol = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        resCol = j;
                    }
                }
            }
            return resCol;
        }

        public int FindLowerColIndex(int[,] matrix)
        {
            int maxVal = -999999;
            int resCol = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j <= i && j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        resCol = j;
                    }
                }
            }
            return resCol;
        }

        public void RemoveColumn(ref int[,] matrix, int colIndex)
        {
            if (colIndex < 0 || colIndex >= matrix.GetLength(1)) return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] temp = new int[rows, cols - 1];

            for (int i = 0; i < rows; i++)
            {
                int currentCol = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j != colIndex)
                    {
                        temp[i, currentCol] = matrix[i, j];
                        currentCol = currentCol + 1;
                    }
                }
            }
            matrix = temp;
        }

        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {
            if (matrix == null || method == null) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            int col = method(matrix);
            if (col != -1)
            {
                RemoveColumn(ref matrix, col);
            }
        }

        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void Task4(ref int[,] matrix)
        {
            if (matrix == null) return;
            for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
            {
                bool hasZero = CheckZerosInColumn(matrix, j);
                if (hasZero == false)
                {
                    RemoveColumn(ref matrix, j);
                }
            }
        }

        public int FindMax(int[,] matrix, out int r, out int c)
        {
            int max = -999999;
            r = 0; c = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        r = i;
                        c = j;
                    }
                }
            }
            return max;
        }

        public int FindMax(int[,] matrix)
        {
            int max = -999999;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max) max = matrix[i, j];
                }
            }
            return max;
        }

        public int FindMin(int[,] matrix, out int r, out int c)
        {
            int min = 999999;
            r = 0; c = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        r = i;
                        c = j;
                    }
                }
            }
            return min;
        }

        public int FindMin(int[,] matrix)
        {
            int min = 999999;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min) min = matrix[i, j];
                }
            }
            return min;
        }

        public void Task5(ref int[,] matrix, Finder find)
        {
            if (matrix == null || find == null) return;
            int rowIdx, colIdx;
            int targetValue = find(matrix, out rowIdx, out colIdx);

            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                bool found = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == targetValue)
                    {
                        found = true;
                        break;
                    }
                }
                if (found == true)
                {
                    RemoveRow(ref matrix, i);
                }
            }
        }

        public void SortRowAscending(int[,] matrix, int row)
        {
            int n = matrix.GetLength(1);
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (matrix[row, j] > matrix[row, j + 1])
                    {
                        int temp = matrix[row, j];
                        matrix[row, j] = matrix[row, j + 1];
                        matrix[row, j + 1] = temp;
                    }
                }
            }
        }

        public void SortRowDescending(int[,] matrix, int row)
        {
            int n = matrix.GetLength(1);
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (matrix[row, j] < matrix[row, j + 1])
                    {
                        int temp = matrix[row, j];
                        matrix[row, j] = matrix[row, j + 1];
                        matrix[row, j + 1] = temp;
                    }
                }
            }
        }

        public void Task6(int[,] matrix, SortRowsStyle sort)
        {
            if (matrix == null || sort == null) return;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 3 == 0)
                {
                    sort(matrix, i);
                }
            }
        }

        public int FindMaxInRow(int[,] matrix, int row)
        {
            int m = -999999;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > m) m = matrix[row, j];
            }
            return m;
        }

        public void ReplaceByZero(int[,] matrix, int row, int maxV)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] == maxV) matrix[row, j] = 0;
            }
        }

        public void MultiplyByColumn(int[,] matrix, int row, int maxV)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] == maxV) matrix[row, j] = matrix[row, j] * (j + 1);
            }
        }

        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {
            if (matrix == null || transform == null) return;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxVal = FindMaxInRow(matrix, i);
                transform(matrix, i, maxVal);
            }
        }

        public double SumA(double x)
        {
            double s = 1.0;
            double factorial = 1.0;
            for (int i = 1; i <= 10; i++)
            {
                factorial = factorial * i;
                s = s + Math.Cos(i * x) / factorial;
            }
            return s;
        }

        public double YA(double x)
        {
            return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
        }

        public double SumB(double x)
        {
            double s = -2.0 * Math.PI * Math.PI / 3.0, sign = 1, t = 1;
            for (int i = 1; Math.Abs(t) >= 0.000001; i++)
            {
                sign *= -1;
                t = sign * (Math.Cos(i * x) / (i * i));
                s += t;
            }
            return s;
        }

        public double YB(double x)
        {
            return (((x * x) / 4) - (3 * (Math.PI * Math.PI) / 4)); ;
        }

        public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
        {
            if (getSum == null || getY == null) return null;
            int n = (int)((b - a) / h + 0.0001) + 1;
            double[,] table = new double[n, 2];
            for (int i = 0; i < n; i++)
            {
                double currentX = a + i * h;
                table[i, 0] = getSum(currentX);
                table[i, 1] = getY(currentX);
            }
            return table;
        }

        public int[] GetUpperTriangle(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols) return new int[0];
            int size = rows * (rows + 1) / 2;
            int[] result = new int[size];
            int k = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = i; j < rows; j++)
                {
                    result[k] = matrix[i, j];
                    k = k + 1;
                }
            }
            return result;
        }

        public int[] GetLowerTriangle(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols) return new int[0];
            int size = rows * (rows + 1) / 2;
            int[] result = new int[size];
            int k = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    result[k] = matrix[i, j];
                    k = k + 1;
                }
            }
            return result;
        }

        public int Task9(int[,] matrix, GetTriangle triangle)
        {
            if (matrix == null || triangle == null) return 0;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return 0;
            int[] elements = triangle(matrix);
            int total = 0;
            for (int i = 0; i < elements.Length; i++)
            {
                total = total + elements[i] * elements[i];
            }
            return total;
        }

        public bool CheckTransformAbility(int[][] array)
        {
            if (array == null || array.Length == 0) return false;

            bool allEqual = true;
            int firstLen = array[0].Length;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].Length != firstLen)
                {
                    allEqual = false;
                    break;
                }
            }
            if (allEqual) return true;

            if (array[0].Length == array.Length)
            {
                bool triangleDesc = true;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Length != array.Length - i)
                    {
                        triangleDesc = false;
                        break;
                    }
                }
                if (triangleDesc) return true;
            }

            if (array[array.Length - 1].Length == array.Length)
            {
                bool triangleAsc = true;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Length != i + 1)
                    {
                        triangleAsc = false;
                        break;
                    }
                }
                if (triangleAsc) return true;
            }

            return false;
        }

        public bool Task10(int[][] array, Predicate<int[][]> func)
        {
            if (array == null || func == null) return false;
            bool result = func(array);
            return result;
        }

        public int Sum(int[] arr)
        {
            int s = 0;
            foreach (int x in arr) s += x * x;
            return s;
        }

        public bool CheckSumOrder(int[][] array)
        {
            if (array == null || array.Length == 0) return false;
            int prevSum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int currentSum = 0;
                foreach (int x in array[i]) currentSum += x;
                if (i > 0 && currentSum <= prevSum) return false;
                prevSum = currentSum;
            }
            return true;
        }

        public bool CheckArraysOrder(int[][] array)
        {
            if (array == null || array.Length == 0) return false;
            foreach (int[] row in array)
            {
                if (row.Length < 2)
                {
                    if (row.Length == 1) return true;
                    continue;
                }
                bool asc = true;
                bool desc = true;
                for (int i = 0; i < row.Length - 1; i++)
                {
                    if (row[i] > row[i + 1]) asc = false;
                    if (row[i] < row[i + 1]) desc = false;
                }
                if (asc || desc) return true;
            }
            return false;
        }
    }
}
