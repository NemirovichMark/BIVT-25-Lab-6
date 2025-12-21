using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public delegate void Sorting(int[,] matrix);
    public delegate double BikeRide(double v, double a);

    public class White
    {
        // Вспомогательные методы (публичные, т.к. тесты их вызывают)
        public int FindMaxIndex(double[] array)
        {
            if (array == null || array.Length == 0)
            {
                return -1;
            }

            double max = array[0];
            int index = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    index = i;
                }
            }
            return index;
        }

        public int FindMaxRowIndexInColumn(int[,] matrix, int col)
        {
            if (matrix == null) return -1;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows == 0 || cols == 0) return -1;
            if (col < 0 || col >= cols) return -1;

            int max = matrix[0, col];
            int rowIndex = 0;
            for (int r = 1; r < rows; r++)
            {
                if (matrix[r, col] > max)
                {
                    max = matrix[r, col];
                    rowIndex = r;
                }
            }
            return rowIndex;
        }

        public int[] GetNegativeCountPerRow(int[,] matrix)
        {
            if (matrix == null) return new int[0];
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows == 0) return new int[0];

            int[] counts = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int cnt = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0) cnt++;
                }
                counts[i] = cnt;
            }
            return counts;
        }

        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = -1;
            col = -1;
            if (matrix == null) return 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows == 0 || cols == 0) return 0;

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
            return max;
        }

        public void SwapColumns(int[,] A, int colIndexA, int[,] B, int colIndexB)
        {
            if (A == null || B == null) return;
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);
            if (rowsA == 0 || colsA == 0 || rowsB == 0 || colsB == 0) return;
            if (colIndexA < 0 || colIndexA >= colsA) return;
            if (colIndexB < 0 || colIndexB >= colsB) return;
            if (rowsA != rowsB) return;

            for (int i = 0; i < rowsA; i++)
            {
                int temp = A[i, colIndexA];
                A[i, colIndexA] = B[i, colIndexB];
                B[i, colIndexB] = temp;
            }
        }

        public void SortDiagonalAscending(int[,] matrix)
        {
            if (matrix == null) return;
            int n = matrix.GetLength(0);
            if (n == 0) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;

            int[] diag = new int[n];
            for (int i = 0; i < n; i++) diag[i] = matrix[i, i];
            System.Array.Sort(diag);
            for (int i = 0; i < n; i++) matrix[i, i] = diag[i];
        }

        public void SortDiagonalDescending(int[,] matrix)
        {
            if (matrix == null) return;
            int n = matrix.GetLength(0);
            if (n == 0) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;

            int[] diag = new int[n];
            for (int i = 0; i < n; i++) diag[i] = matrix[i, i];
            System.Array.Sort(diag);
            System.Array.Reverse(diag);
            for (int i = 0; i < n; i++) matrix[i, i] = diag[i];
        }

        public long Factorial(int n)
        {
            if (n < 0) return 0;
            if (n == 0 || n == 1) return 1;
            return n * Factorial(n - 1);
        }

        public double GetDistance(double v, double a)
        {
            double sum = 0;
            for (int t = 0; t < 10; t++)
            {
                sum += v + a * t;
            }
            return sum;
        }

        public double GetTime(double v, double a)
        {
            if (v <= 0 && a <= 0) return 0;
            double dist = 0;
            int hours = 0;
            while (dist < 100)
            {
                dist += v + a * hours;
                hours++;
                if (hours > 1000000) break;
            }
            return (double)hours;
        }

        public void SwapFromLeft(int[] array)
        {
            if (array == null) return;
            if (array.Length < 2) return;
            for (int i = 0; i + 1 < array.Length; i += 2)
            {
                int temp = array[i];
                array[i] = array[i + 1];
                array[i + 1] = temp;
            }
        }

        public void SwapFromRight(int[] array)
        {
            if (array == null) return;
            if (array.Length < 2) return;
            for (int i = array.Length - 1; i - 1 >= 0; i -= 2)
            {
                int temp = array[i];
                array[i] = array[i - 1];
                array[i - 1] = temp;
            }
        }

        public int GetSum(int[] array)
        {
            if (array == null || array.Length == 0) return 0;
            int sum = 0;
            for (int i = 1; i < array.Length; i += 2) sum += array[i];
            return sum;
        }

        public int CountPositive(int[][] array)
        {
            if (array == null) return 0;
            int cnt = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int[] row = array[i];
                if (row == null) continue;
                for (int j = 0; j < row.Length; j++)
                {
                    if (row[j] > 0) cnt++;
                }
            }
            return cnt;
        }

        public int FindMax(int[][] array)
        {
            if (array == null) return 0;
            bool has = false;
            int max = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int[] row = array[i];
                if (row == null) continue;
                for (int j = 0; j < row.Length; j++)
                {
                    if (!has || row[j] > max)
                    {
                        max = row[j];
                        has = true;
                    }
                }
            }
            if (!has) return 0;
            return max;
        }

        public int FindMaxRowLength(int[][] array)
        {
            if (array == null) return 0;
            int ml = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int[] row = array[i];
                if (row == null) continue;
                if (row.Length > ml) ml = row.Length;
            }
            return ml;
        }

        public void Task1(double[] A, double[] B)
        {

            // code here
            if ((A == null || A.Length == 0) && (B == null || B.Length == 0))
            {
                return;
            }

            int idxA = FindMaxIndex(A);
            int idxB = FindMaxIndex(B);

            int distA = -1;
            if (A != null && idxA >= 0) distA = A.Length - 1 - idxA;
            int distB = -1;
            if (B != null && idxB >= 0) distB = B.Length - 1 - idxB;

            bool operateOnA = false;
            if (distA == -1 && distB == -1)
            {
                return;
            }
            if (distA == -1)
            {
                operateOnA = false;
            }
            else if (distB == -1)
            {
                operateOnA = true;
            }
            else if (distA >= distB)
            {
                operateOnA = true;
            }
            else
            {
                operateOnA = false;
            }

            if (operateOnA)
            {
                if (A == null) return;
                if (idxA < 0 || idxA >= A.Length - 1) return;
                int count = A.Length - 1 - idxA;
                if (count <= 0) return;
                double sum = 0;
                for (int i = idxA + 1; i < A.Length; i++)
                {
                    sum += A[i];
                }
                double avg = 0;
                if (count != 0) avg = sum / count;
                A[idxA] = avg;
            }
            else
            {
                if (B == null) return;
                if (idxB < 0 || idxB >= B.Length - 1) return;
                int count = B.Length - 1 - idxB;
                if (count <= 0) return;
                double sum = 0;
                for (int i = idxB + 1; i < B.Length; i++)
                {
                    sum += B[i];
                }
                double avg = 0;
                if (count != 0) avg = sum / count;
                B[idxB] = avg;
            }
            // end

        }
        public void Task2(int[,] A, int[,] B)
        {

            // code here
            if (A == null || B == null) return;
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);

            if (rowsA == 0 || colsA == 0 || rowsB == 0 || colsB == 0) return;
            if (rowsA != rowsB || colsA != colsB) return;

            int rowA = FindMaxRowIndexInColumn(A, 0);
            int rowB = FindMaxRowIndexInColumn(B, 0);
            if (rowA < 0 || rowB < 0) return;

            for (int j = 0; j < colsA; j++)
            {
                int temp = A[rowA, j];
                A[rowA, j] = B[rowB, j];
                B[rowB, j] = temp;
            }
            // end

        }
        public int Task3(int[,] matrix)
        {
            int answer = 0;

            // code here
            if (matrix == null) return 0;
            int[] counts = GetNegativeCountPerRow(matrix);
            if (counts.Length == 0) return 0;

            int maxCount = counts[0];
            int maxRow = 0;
            for (int i = 1; i < counts.Length; i++)
            {
                if (counts[i] > maxCount)
                {
                    maxCount = counts[i];
                    maxRow = i;
                }
            }

            answer = maxRow;
            // end

            return answer;
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            if (A == null || B == null) return;

            int rowA, colA, rowB, colB;
            int maxA = FindMax(A, out rowA, out colA);
            int maxB = FindMax(B, out rowB, out colB);

            if (rowA < 0 || colA < 0 || rowB < 0 || colB < 0) return;

            int temp = A[rowA, colA];
            A[rowA, colA] = B[rowB, colB];
            B[rowB, colB] = temp;
            // end

        }
        public void Task5(int[,] A, int[,] B)
        {

            // code here
            if (A == null || B == null) return;

            int rowA, colA, rowB, colB;
            FindMax(A, out rowA, out colA);
            FindMax(B, out rowB, out colB);

            if (colA < 0 || colB < 0) return;
            if (A.GetLength(0) != B.GetLength(0)) return;

            SwapColumns(A, colA, B, colB);
            // end

        }
        public void Task6(int[,] matrix, Sorting sort)
        {

            // code here
            if (matrix == null) return;
            if (sort == null) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;

            sort(matrix);
            // end

        }
        public long Task7(int n, int k)
        {
            long answer = 0;

            // code here
            if (n < 0 || k < 0 || k > n) return 0;
            long num = Factorial(n);
            long den1 = Factorial(k);
            long den2 = Factorial(n - k);
            if (den1 == 0 || den2 == 0) return 0;
            answer = num / (den1 * den2);
            // end

            return answer;
        }
        public double Task8(double v, double a, BikeRide ride)
        {
            double answer = 0;

            // code here
            if (ride == null) return 0;
            answer = ride(v, a);
            // end

            return answer;
        }
        public int Task9(int[][] array)
        {
            int answer = 0;

            // code here
            if (array == null || array.Length == 0) return 0;

            bool fromLeft = false;
            if (array.Length % 2 == 0)
            {
                fromLeft = true;
            }
            else
            {
                fromLeft = false;
            }

            if (fromLeft)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    int[] row = array[i];
                    SwapFromLeft(row);
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    int[] row = array[i];
                    SwapFromRight(row);
                }
            }

            int totalOddSum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int[] row = array[i];
                if (row == null || row.Length == 0) continue;
                totalOddSum += GetSum(row);
            }

            answer = totalOddSum;
            // end

            return answer;
        }
        // ---------- Task10 ----------
        public int Task10(int[][] array, Func<int[][], int> func)
        {
            int answer = 0;

            // code here
            if (func == null) return 0;
            answer = func(array);
            // end

            return answer;
        }
    }
}