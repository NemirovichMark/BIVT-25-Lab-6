using System;

namespace Lab6
{
    public delegate void Sorting(int[] row);

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

            int rows = matrix.GetLength(0);
            if (array.Length != rows) return;

            for (int i = 0; i < rows; i++)
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

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m) return;

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

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m) return null;

            int[] res = new int[n];

            for (int i = 0; i < n; i++)
            {
                int min = matrix[i, i];
                for (int j = i; j < m; j++)
                    if (matrix[i, j] < min)
                        min = matrix[i, j];

                res[i] = min;
            }

            return res;
        }

        public int[] Task6(int[,] A, int[,] B)
        {
            if (A == null || B == null) return null;

            int[] sA = SumPositiveElementsInColumns(A);
            int[] sB = SumPositiveElementsInColumns(B);

            return CombineArrays(sA, sB);
        }

        public void Task7(int[,] matrix, Sorting sort)
        {
            if (matrix == null || sort == null) return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int[] rowArr = new int[cols];
                for (int j = 0; j < cols; j++)
                    rowArr[j] = matrix[i, j];

                sort(rowArr);

                for (int j = 0; j < cols; j++)
                    matrix[i, j] = rowArr[j];
            }
        }

        public int Task8(double[] A, double[] B)
        {
            if (A == null || B == null) return 0;
            if (A.Length != 3 || B.Length != 3) return 0;

            double a1 = GeronArea(A[0], A[1], A[2]);
            double a2 = GeronArea(B[0], B[1], B[2]);

            if (a1 == 0 && a2 == 0) return 0;
            return (a1 >= a2) ? 1 : 2;
        }

        public void Task9(int[,] matrix, Action<int[]> sorter)
        {
            if (matrix == null || sorter == null) return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i += 2)
            {
                int[] row = new int[cols];
                for (int j = 0; j < cols; j++)
                    row[j] = matrix[i, j];

                sorter(row);
                ReplaceRow(matrix, i, row);
            }
        }

        public double Task10(int[][] array, Func<int[][], double> func)
        {
            if (array == null || func == null) return 0;
            return func(array);
        }

        public void DeleteMaxElement(ref int[] array)
        {
            if (array == null)
            {
                array = null;
                return;
            }

            if (array.Length == 0) return;

            int idx = 0;
            int max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    idx = i;
                }
            }

            int[] res = new int[array.Length - 1];
            int w = 0;

            for (int i = 0; i < array.Length; i++)
                if (i != idx)
                    res[w++] = array[i];

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

            int cols = matrix.GetLength(1);
            int max = matrix[row, 0];

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
            row = 0;
            col = 0;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int max = matrix[0, 0];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
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
            int m = matrix.GetLength(1);

            if (n != m) return;
            if (col < 0 || col >= m) return;

            for (int i = 0; i < n; i++)
            {
                int tmp = matrix[i, i];
                matrix[i, i] = matrix[i, col];
                matrix[i, col] = tmp;
            }
        }

        public void RemoveRow(ref int[,] matrix, int row)
        {
            if (matrix == null)
            {
                matrix = null;
                return;
            }

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (row < 0 || row >= n) return;

            if (n == 1)
            {
                matrix = new int[0, m];
                return;
            }

            int[,] res = new int[n - 1, m];
            int w = 0;

            for (int i = 0; i < n; i++)
            {
                if (i == row) continue;

                for (int j = 0; j < m; j++)
                    res[w, j] = matrix[i, j];

                w++;
            }

            matrix = res;
        }

        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            if (matrix == null) return null;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] res = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                int s = 0;
                for (int i = 0; i < rows; i++)
                    if (matrix[i, j] > 0)
                        s += matrix[i, j];

                res[j] = s;
            }

            return res;
        }

        public void SortEndAscending(int[] row)
        {
            if (row == null || row.Length <= 1) return;

            int max = row[0], idx = 0;
            for (int i = 1; i < row.Length; i++)
                if (row[i] > max)
                {
                    max = row[i];
                    idx = i;
                }

            if (idx == row.Length - 1) return;

            int len = row.Length - idx - 1;
            int[] tail = new int[len];

            for (int i = 0; i < len; i++)
                tail[i] = row[idx + 1 + i];

            Array.Sort(tail);

            for (int i = 0; i < len; i++)
                row[idx + 1 + i] = tail[i];
        }

        public void SortEndDescending(int[] row)
        {
            if (row == null || row.Length <= 1) return;

            int max = row[0], idx = 0;
            for (int i = 1; i < row.Length; i++)
                if (row[i] > max)
                {
                    max = row[i];
                    idx = i;
                }

            if (idx == row.Length - 1) return;

            int len = row.Length - idx - 1;
            int[] tail = new int[len];

            for (int i = 0; i < len; i++)
                tail[i] = row[idx + 1 + i];

            Array.Sort(tail);
            Array.Reverse(tail);

            for (int i = 0; i < len; i++)
                row[idx + 1 + i] = tail[i];
        }

        public void ReplaceRow(int[,] matrix, int row, int[] array)
        {
            if (matrix == null || array == null) return;

            int cols = matrix.GetLength(1);
            if (array.Length != cols) return;
            if (row < 0 || row >= matrix.GetLength(0)) return;

            for (int j = 0; j < cols; j++)
                matrix[row, j] = array[j];
        }

        public double GeronArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0) return 0;
            if (a + b <= c || a + c <= b || b + c <= a) return 0;

            double p = (a + b + c) / 2.0;
            double s2 = p * (p - a) * (p - b) * (p - c);

            if (s2 <= 0) return 0;
            return Math.Sqrt(s2);
        }

        public double CountZeroSum(int[][] array)
        {
            if (array == null) return 0;

            int cnt = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int[] row = array[i];
                if (row == null) continue;

                long s = 0;
                for (int j = 0; j < row.Length; j++)
                    s += row[j];

                if (s == 0) cnt++;
            }

            return cnt;
        }

        public double FindMedian(int[][] array)
        {
            if (array == null) return 0;

            int total = 0;
            for (int i = 0; i < array.Length; i++)
                total += (array[i]?.Length ?? 0);

            if (total == 0) return 0;

            int[] flat = new int[total];
            int k = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int[] row = array[i];
                if (row == null) continue;

                for (int j = 0; j < row.Length; j++)
                    flat[k++] = row[j];
            }

            Array.Sort(flat);

            if ((total & 1) == 1) return flat[total / 2];
            return (flat[total / 2 - 1] + flat[total / 2]) / 2.0;
        }

        public double CountLargeElements(int[][] array)
        {
            if (array == null) return 0;

            long cnt = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int[] row = array[i];
                if (row == null || row.Length == 0) continue;

                long sum = 0;
                for (int j = 0; j < row.Length; j++)
                    sum += row[j];

                double avg = (double)sum / row.Length;

                for (int j = 0; j < row.Length; j++)
                    if (row[j] > avg)
                        cnt++;
            }

            return cnt;
        }
    }
}
