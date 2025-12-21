using System;

namespace Lab6
{
    public delegate void Sorting(int[,] matrix);

    public class Green
    {
        public void Task1(ref int[] A, ref int[] B)
        {
            if (A == null || B == null)
            {
                A = null;
                B = null;
                return;
            }

            DeleteMaxElement(ref A);
            DeleteMaxElement(ref B);

            A = CombineArrays(A, B);
        }

        public void Task2(int[,] matrix, int[] array)
        {
            if (matrix == null || array == null) return;
            if (array.Length != matrix.GetLength(0)) return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int col;
                int max = FindMaxInRow(matrix, i, out col);
                if (max < array[i])
                    matrix[i, col] = array[i];
            }
        }

        public void Task3(int[,] matrix)
        {
            if (matrix == null) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;

            int row, col;
            FindMax(matrix, out row, out col);
            SwapColWithDiagonal(matrix, col);
        }

        public void Task4(ref int[,] matrix)
        {
            if (matrix == null)
            {
                matrix = null;
                return;
            }

            int i = 0;
            while (i < matrix.GetLength(0))
            {
                bool hasZero = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }

                if (hasZero)
                    RemoveRow(ref matrix, i);
                else
                    i++;
            }
        }

        public int[] Task5(int[,] matrix)
        {
            if (matrix == null) return null;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return null;

            return GetRowsMinElements(matrix);
        }

        public int[] Task6(int[,] A, int[,] B)
        {
            if (A == null || B == null) return null;

            return CombineArrays(
                SumPositiveElementsInColumns(A),
                SumPositiveElementsInColumns(B)
            );
        }

        public void Task7(int[,] matrix, Sorting sort)
        {
            if (matrix == null || sort == null) return;
            sort(matrix);
        }

        public int Task8(double[] A, double[] B)
        {
            if (A == null || B == null) return 0;
            if (A.Length != 3 || B.Length != 3) return 0;

            double sA = GeronArea(A[0], A[1], A[2]);
            double sB = GeronArea(B[0], B[1], B[2]);

            if (sA == 0 && sB == 0) return 0;
            return sA >= sB ? 1 : 2;
        }

        public void Task9(int[,] matrix, Action<int[]> sorter)
        {
            if (matrix == null || sorter == null) return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                    SortMatrixRow(matrix, i, sorter);
            }
        }

        public double Task10(int[][] array, Func<int[][], double> func)
        {
            if (array == null || func == null) return 0;
            return func(array);
        }

        public void DeleteMaxElement(ref int[] array)
        {
            if (array == null) return;
            if (array.Length == 0) return;

            int max = array[0];
            int idx = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    idx = i;
                }
            }

            int[] res = new int[array.Length - 1];
            int k = 0;

            for (int i = 0; i < array.Length; i++)
                if (i != idx)
                    res[k++] = array[i];

            array = res;
        }

        public int[] CombineArrays(int[] A, int[] B)
        {
            if (A == null || B == null) return null;

            int[] res = new int[A.Length + B.Length];
            int k = 0;

            for (int i = 0; i < A.Length; i++)
                res[k++] = A[i];

            for (int i = 0; i < B.Length; i++)
                res[k++] = B[i];

            return res;
        }

        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            col = 0;
            int max = matrix[row, 0];

            for (int j = 1; j < matrix.GetLength(1); j++)
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
            row = 0;
            col = 0;

            int max = matrix[0, 0];

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        row = i;
                        col = j;
                    }
        }

        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1)) return;
            if (col < 0 || col >= n) return;

            for (int i = 0; i < n; i++)
            {
                int tmp = matrix[i, i];
                matrix[i, i] = matrix[i, col];
                matrix[i, col] = tmp;
            }
        }

        public void RemoveRow(ref int[,] matrix, int row)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows == 1)
            {
                matrix = new int[0, cols];
                return;
            }

            int[,] res = new int[rows - 1, cols];
            int r = 0;

            for (int i = 0; i < rows; i++)
            {
                if (i == row) continue;
                for (int j = 0; j < cols; j++)
                    res[r, j] = matrix[i, j];
                r++;
            }

            matrix = res;
        }

        public int[] GetRowsMinElements(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int[] res = new int[n];

            for (int i = 0; i < n; i++)
            {
                int min = matrix[i, i];
                for (int j = i; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] < min)
                        min = matrix[i, j];
                res[i] = min;
            }

            return res;
        }

        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            int cols = matrix.GetLength(1);
            int[] res = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                int sum = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                    if (matrix[i, j] > 0)
                        sum += matrix[i, j];
                res[j] = sum;
            }

            return res;
        }

        public void SortEndAscending(int[,] matrix)
        {
            SortEnd(matrix, true);
        }

        public void SortEndDescending(int[,] matrix)
        {
            SortEnd(matrix, false);
        }

        private void SortEnd(int[,] matrix, bool asc)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = matrix[i, 0];
                int idx = 0;

                for (int j = 1; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        idx = j;
                    }

                for (int k = idx + 1; k < matrix.GetLength(1); k++)
                {
                    int key = matrix[i, k];
                    int j = k - 1;

                    while (j > idx && (asc ? matrix[i, j] > key : matrix[i, j] < key))
                    {
                        matrix[i, j + 1] = matrix[i, j];
                        j--;
                    }

                    matrix[i, j + 1] = key;
                }
            }
        }

        public double GeronArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0) return 0;
            if (a + b <= c || a + c <= b || b + c <= a) return 0;

            double p = (a + b + c) / 2.0;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public void SortMatrixRow(int[,] matrix, int row, Action<int[]> sorter)
        {
            int cols = matrix.GetLength(1);
            int[] tmp = new int[cols];

            for (int j = 0; j < cols; j++)
                tmp[j] = matrix[row, j];

            sorter(tmp);

            ReplaceRow(matrix, row, tmp);
        }

        public void ReplaceRow(int[,] matrix, int row, int[] array)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                matrix[row, j] = array[j];
        }

        public void SortAscending(int[] array)
        {
            InsertionSort(array, true);
        }

        public void SortDescending(int[] array)
        {
            InsertionSort(array, false);
        }

        private void InsertionSort(int[] a, bool asc)
        {
            for (int i = 1; i < a.Length; i++)
            {
                int key = a[i];
                int j = i - 1;

                while (j >= 0 && (asc ? a[j] > key : a[j] < key))
                {
                    a[j + 1] = a[j];
                    j--;
                }

                a[j + 1] = key;
            }
        }

        public double CountZeroSum(int[][] array)
        {
            int cnt = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                    sum += array[i][j];
                if (sum == 0) cnt++;
            }

            return cnt;
        }

        public double FindMedian(int[][] array)
        {
            int total = 0;
            for (int i = 0; i < array.Length; i++)
                total += array[i].Length;

            if (total == 0) return 0;

            int[] flat = new int[total];
            int k = 0;

            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[i].Length; j++)
                    flat[k++] = array[i][j];

            InsertionSort(flat, true);

            return total % 2 == 1
                ? flat[total / 2]
                : (flat[total / 2 - 1] + flat[total / 2]) / 2.0;
        }

        public double CountLargeElements(int[][] array)
        {
            int cnt = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                    sum += array[i][j];

                double avg = (double)sum / array[i].Length;

                for (int j = 0; j < array[i].Length; j++)
                    if (array[i][j] > avg)
                        cnt++;
            }

            return cnt;
        }
    }
}
