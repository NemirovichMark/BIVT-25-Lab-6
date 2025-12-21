using System;

namespace Lab6
{
    public class Green
    {
        public void Task1(ref int[] A, ref int[] B)
        {
            if (A == null || B == null) return;
            DeleteMaxElement(ref A);
            DeleteMaxElement(ref B);
            A = CombineArrays(A, B);
        }

        public void DeleteMaxElement(ref int[] array)
        {
            if (array == null || array.Length == 0) return;

            int ind = 0;
            int m = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > m)
                {
                    m = array[i];
                    ind = i;
                }
            }

            int[] array1 = new int[array.Length - 1];
            for (int i = 0; i < array1.Length; i++)
            {
                if (i < ind)
                    array1[i] = array[i];
                else
                    array1[i] = array[i + 1];
            }

            array = array1;
        }

        public int[] CombineArrays(int[] A, int[] B)
        {
            if (A == null || B == null) return null;

            int[] arrayAB = new int[A.Length + B.Length];

            for (int i = 0; i < A.Length; i++)
                arrayAB[i] = A[i];

            int k = 0;
            for (int i = A.Length; i < arrayAB.Length; i++)
                arrayAB[i] = B[k++];

            return arrayAB;
        }

        public void Task2(int[,] matrix, int[] array)
        {
            if (array == null || matrix == null) return;
            if (array.Length != matrix.GetLength(0)) return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int j;
                int m = FindMaxInRow(matrix, i, out j);
                if (m < array[i])
                    matrix[i, j] = array[i];
            }
        }

        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            col = 0;
            int max = int.MinValue;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > max)
                {
                    max = matrix[row, j];
                    col = j;
                }
            }

            return max;
        }

        public void Task3(int[,] matrix)
        {
            if (matrix == null) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;

            int row, col;
            FindMax(matrix, out row, out col);
            SwapColWithDiagonal(matrix, col);
        }

        public void FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            int max = int.MinValue;

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
            if (matrix == null) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            if (col < 0 || col >= matrix.GetLength(1)) return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int q = matrix[i, i];
                matrix[i, i] = matrix[i, col];
                matrix[i, col] = q;
            }
        }

        public void Task4(ref int[,] matrix)
        {
            if (matrix == null) return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bool op = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] == 0)
                    {
                        op = true;
                        break;
                    }

                if (op)
                {
                    RemoveRow(ref matrix, i);
                    i--;
                }
            }
        }

        public void RemoveRow(ref int[,] matrix, int row)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] array = new int[rows - 1, cols];

            for (int i = 0, k = 0; i < rows; i++)
            {
                if (i == row) continue;
                for (int j = 0; j < cols; j++)
                    array[k, j] = matrix[i, j];
                k++;
            }

            matrix = array;
        }

        public int[] Task5(int[,] matrix)
        {
            if (matrix == null) return null;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return null;

            return GetRowsMinElements(matrix);
        }

        public int[] GetRowsMinElements(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = int.MaxValue;
                for (int j = i; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] < min)
                        min = matrix[i, j];
                array[i] = min;
            }

            return array;
        }

        public int[] Task6(int[,] A, int[,] B)
        {
            if (A == null || B == null) return null;
            return CombineArrays(
                SumPositiveElementsInColumns(A),
                SumPositiveElementsInColumns(B)
            );
        }

        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            int[] res = new int[matrix.GetLength(1)];

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int s = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                    if (matrix[i, j] > 0)
                        s += matrix[i, j];
                res[j] = s;
            }

            return res;
        }

        public delegate void Sorting(int[,] matrix);

        public void Task7(int[,] matrix, Sorting sort)
        {
            if (matrix == null || sort == null) return;
            sort(matrix);
        }

        public int Task8(double[] A, double[] B)
        {
            if (A == null || B == null) return 0;

            double a = GeronArea(A[0], A[1], A[2]);
            double b = GeronArea(B[0], B[1], B[2]);

            if (a == 0 && b == 0) return 0;
            return a >= b ? 1 : 2;
        }

        public double GeronArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0) return 0;
            if (a + b <= c || a + c <= b || b + c <= a) return 0;

            double p = (a + b + c) / 2.0;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public void Task9(int[,] matrix, Action<int[]> sorter)
        {
            if (matrix == null || sorter == null) return;

            for (int i = 0; i < matrix.GetLength(0); i += 2)
                SortMatrixRow(matrix, i, sorter);
        }

        public void SortMatrixRow(int[,] matrix, int row, Action<int[]> sorter)
        {
            int[] array = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
                array[j] = matrix[row, j];

            sorter(array);
            ReplaceRow(matrix, row, array);
        }

        public void ReplaceRow(int[,] matrix, int row, int[] array)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                matrix[row, j] = array[j];
        }

        public void SortAscending(int[] array)
        {
            Array.Sort(array);
        }

        public void SortDescending(int[] array)
        {
            Array.Sort(array);
            Array.Reverse(array);
        }

        public double Task10(int[][] array, Func<int[][], double> func)
        {
            if (array == null || func == null) return 0;
            return func(array);
        }

        public double CountZeroSum(int[][] array)
        {
            double k = 0;

            for (int i = 0; i < array.Length; i++)
            {
                double s = 0;
                for (int j = 0; j < array[i].Length; j++)
                    s += array[i][j];

                if (s == 0) k++;
            }

            return k;
        }

        public double FindMedian(int[][] array)
        {
            int q = 0;
            for (int i = 0; i < array.Length; i++)
                q += array[i].Length;

            int[] massive = new int[q];
            int k = 0;

            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[i].Length; j++)
                    massive[k++] = array[i][j];

            Array.Sort(massive);

            if (q % 2 == 0)
                return (massive[q / 2 - 1] + massive[q / 2]) / 2.0;

            return massive[q / 2];
        }

        public double CountLargeElements(int[][] array)
        {
            double k = 0;

            for (int i = 0; i < array.Length; i++)
            {
                double s = 0;
                for (int j = 0; j < array[i].Length; j++)
                    s += array[i][j];

                double avg = s / array[i].Length;

                for (int j = 0; j < array[i].Length; j++)
                    if (array[i][j] > avg)
                        k++;
            }

            return k;
        }
    }
}
