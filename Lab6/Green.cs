using System;
using System.Linq;

namespace Lab6
{
    public delegate void Sorting(int[,] matrix);

    public class Green
    {
        public void Task1(ref int[] A, ref int[] B)
        {
            if (A == null || B == null)
            {
                return;
            }

            DeleteMaxElement(ref A);
            DeleteMaxElement(ref B);
            A = CombineArrays(A, B) ?? Array.Empty<int>();
        }

        public void Task2(int[,] matrix, int[] array)
        {
            if (matrix == null || array == null || matrix.GetLength(0) > array.Length)
            {
                return;
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int max = FindMaxInRow(matrix, row, out int col);
                if (col >= 0 && max < array[row])
                {
                    matrix[row, col] = array[row];
                }
            }
        }

        public void Task3(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }

            FindMax(matrix, out int row, out int col);
            if (row < 0 || col < 0)
            {
                return;
            }

            SwapColWithDiagonal(matrix, col);
        }

        public void Task4(ref int[,] matrix)
        {
            if (matrix == null)
            {
                return;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            bool[] hasZero = new bool[rows];
            int keep = rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero[i] = true;
                        keep--;
                        break;
                    }
                }
            }

            int[,] result = new int[keep, cols];
            int newRow = 0;
            for (int i = 0; i < rows; i++)
            {
                if (hasZero[i])
                {
                    continue;
                }

                for (int j = 0; j < cols; j++)
                {
                    result[newRow, j] = matrix[i, j];
                }

                newRow++;
            }

            matrix = result;
        }

        public int[] Task5(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
            {
                return null;
            }

            return GetRowsMinElements(matrix);
        }

        public int[] Task6(int[,] A, int[,] B)
        {
            if (A == null || B == null)
            {
                return null;
            }

            int[] sumsA = SumPositiveElementsInColumns(A);
            int[] sumsB = SumPositiveElementsInColumns(B);
            if (sumsA == null || sumsB == null)
            {
                return null;
            }

            return CombineArrays(sumsA, sumsB);
        }

        public void Task7(int[,] matrix, Sorting sort)
        {
            if (matrix == null || sort == null)
            {
                return;
            }

            sort(matrix);
        }

        public int Task8(double[] A, double[] B)
        {
            if (A == null || B == null || A.Length < 3 || B.Length < 3)
            {
                return 0;
            }

            double areaA = GeronArea(A[0], A[1], A[2]);
            double areaB = GeronArea(B[0], B[1], B[2]);

            return areaA > areaB ? 1 : 2;
        }

        public void Task9(int[,] matrix, Action<int[]> sorter)
        {
            if (matrix == null || sorter == null)
            {
                return;
            }

            for (int i = 0; i < matrix.GetLength(0); i += 2)
            {
                SortMatrixRow(matrix, i, sorter);
            }
        }

        public double Task10(int[][] array, Func<int[][], double> func)
        {
            if (array == null || func == null)
            {
                return 0;
            }

            return func(array);
        }

        public void DeleteMaxElement(ref int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return;
            }

            int maxIndex = 0;
            int maxValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                    maxIndex = i;
                }
            }

            int[] result = new int[array.Length - 1];
            int idx = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i == maxIndex)
                {
                    continue;
                }

                result[idx++] = array[i];
            }

            array = result;
        }

        public int[] CombineArrays(int[] A, int[] B)
        {
            if (A == null && B == null)
            {
                return null;
            }

            A ??= Array.Empty<int>();
            B ??= Array.Empty<int>();

            int[] result = new int[A.Length + B.Length];
            for (int i = 0; i < A.Length; i++)
            {
                result[i] = A[i];
            }

            for (int i = 0; i < B.Length; i++)
            {
                result[A.Length + i] = B[i];
            }

            return result;
        }

        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            col = -1;
            if (matrix == null || row < 0 || row >= matrix.GetLength(0))
            {
                return 0;
            }

            int cols = matrix.GetLength(1);
            int max = matrix[row, 0];
            col = 0;
            for (int j = 1; j < cols; j++)
            {
                if (matrix[row, j] > max)
                {
                    max = matrix[row, j];
                    col = j;
                }
            }

            return max;
        }

        public void FindMax(int[,] matrix, out int row, out int col)
        {
            row = -1;
            col = -1;
            if (matrix == null || matrix.Length == 0)
            {
                return;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int max = matrix[0, 0];
            row = 0;
            col = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
        }

        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            int size = matrix.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                (matrix[i, col], matrix[i, i]) = (matrix[i, i], matrix[i, col]);
            }
        }

        public void RemoveRow(ref int[,] matrix, int row)
        {
            if (matrix == null || row < 0 || row >= matrix.GetLength(0))
            {
                matrix = new int[0, 0];
                return;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] result = new int[rows - 1, cols];
            int newRow = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i == row)
                {
                    continue;
                }

                for (int j = 0; j < cols; j++)
                {
                    result[newRow, j] = matrix[i, j];
                }

                newRow++;
            }

            matrix = result;
        }

        public int[] GetRowsMinElements(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
            {
                return null;
            }

            int size = matrix.GetLength(0);
            int[] mins = new int[size];
            for (int i = 0; i < size; i++)
            {
                int min = matrix[i, i];
                for (int j = i + 1; j < size; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }

                mins[i] = min;
            }

            return mins;
        }

        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            if (matrix == null)
            {
                return null;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] sums = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                int sum = 0;
                bool hasPositive = false;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        hasPositive = true;
                    }
                }

                sums[j] = hasPositive ? sum : 0;
            }

            return sums;
        }

        public void SortEndAscending(int[,] matrix)
        {
            if (matrix == null)
            {
                return;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int maxIndex = 0;
                int maxValue = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }

                if (maxIndex + 1 >= cols)
                {
                    continue;
                }

                int length = cols - maxIndex - 1;
                int[] tail = new int[length];
                for (int j = 0; j < length; j++)
                {
                    tail[j] = matrix[i, maxIndex + 1 + j];
                }

                Array.Sort(tail);
                for (int j = 0; j < length; j++)
                {
                    matrix[i, maxIndex + 1 + j] = tail[j];
                }
            }
        }

        public void SortEndDescending(int[,] matrix)
        {
            if (matrix == null)
            {
                return;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int maxIndex = 0;
                int maxValue = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }

                if (maxIndex + 1 >= cols)
                {
                    continue;
                }

                int length = cols - maxIndex - 1;
                int[] tail = new int[length];
                for (int j = 0; j < length; j++)
                {
                    tail[j] = matrix[i, maxIndex + 1 + j];
                }

                Array.Sort(tail);
                Array.Reverse(tail);
                for (int j = 0; j < length; j++)
                {
                    matrix[i, maxIndex + 1 + j] = tail[j];
                }
            }
        }

        public double GeronArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0 || a + b <= c || a + c <= b || b + c <= a)
            {
                return 0;
            }

            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public void SortMatrixRow(int[,] matrix, int row, Action<int[]> sorter)
        {
            if (matrix == null || sorter == null || row < 0 || row >= matrix.GetLength(0))
            {
                return;
            }

            int cols = matrix.GetLength(1);
            int[] temp = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                temp[j] = matrix[row, j];
            }

            sorter(temp);
            ReplaceRow(matrix, row, temp);
        }

        public void ReplaceRow(int[,] matrix, int row, int[] array)
        {
            if (matrix == null || array == null || row < 0 || row >= matrix.GetLength(0) || array.Length != matrix.GetLength(1))
            {
                return;
            }

            for (int j = 0; j < array.Length; j++)
            {
                matrix[row, j] = array[j];
            }
        }

        public void SortAscending(int[] array)
        {
            if (array == null)
            {
                return;
            }

            Array.Sort(array);
        }

        public void SortDescending(int[] array)
        {
            if (array == null)
            {
                return;
            }

            Array.Sort(array);
            Array.Reverse(array);
        }

        public double CountZeroSum(int[][] array)
        {
            if (array == null)
            {
                return 0;
            }

            double count = 0;
            foreach (int[] row in array)
            {
                if (row == null)
                {
                    continue;
                }

                int sum = 0;
                for (int i = 0; i < row.Length; i++)
                {
                    sum += row[i];
                }

                if (sum == 0)
                {
                    count++;
                }
            }

            return count;
        }

        public double FindMedian(int[][] array)
        {
            if (array == null)
            {
                return 0;
            }

            int[] values = array
                .Where(a => a != null)
                .SelectMany(a => a)
                .OrderBy(x => x)
                .ToArray();

            if (values.Length == 0)
            {
                return 0;
            }

            int mid = values.Length / 2;
            if (values.Length % 2 == 1)
            {
                return values[mid];
            }

            return (values[mid - 1] + values[mid]) / 2.0;
        }

        public double CountLargeElements(int[][] array)
        {
            if (array == null)
            {
                return 0;
            }

            double count = 0;
            foreach (int[] row in array)
            {
                if (row == null || row.Length == 0)
                {
                    continue;
                }

                double average = row.Average();
                for (int i = 0; i < row.Length; i++)
                {
                    if (row[i] > average)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
