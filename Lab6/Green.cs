using System;

namespace Lab6
{
    public class White
    {
        public int FindMaxIndex(double[] array)
        {
            if (array == null || array.Length == 0) return 0;

            int max_i = 0;
            for (int i = 1; i < array.Length; i++)
                if (array[i] > array[max_i])
                    max_i = i;

            return max_i;
        }

        public void Task1(double[] A, double[] B)
        {
            if (A == null && B == null) return;

            int hasA = (A != null && A.Length > 0) ? 1 : 0;
            int hasB = (B != null && B.Length > 0) ? 1 : 0;

            if (hasA == 0 && hasB == 0) return;

            int maxA = hasA == 1 ? FindMaxIndex(A) : -1;
            int maxB = hasB == 1 ? FindMaxIndex(B) : -1;

            int distA = (hasA == 1) ? (A.Length - 1 - maxA) : -1;
            int distB = (hasB == 1) ? (B.Length - 1 - maxB) : -1;

            if (distA >= distB)
            {
                if (hasA == 0) return;
                if (maxA == A.Length - 1) return;

                double sum = 0;
                int cnt = 0;
                for (int i = maxA + 1; i < A.Length; i++)
                {
                    sum += A[i];
                    cnt++;
                }
                if (cnt > 0) A[maxA] = sum / cnt;
            }
            else
            {
                if (hasB == 0) return;
                if (maxB == B.Length - 1) return;

                double sum = 0;
                int cnt = 0;
                for (int i = maxB + 1; i < B.Length; i++)
                {
                    sum += B[i];
                    cnt++;
                }
                if (cnt > 0) B[maxB] = sum / cnt;
            }
        }

        public int FindMaxRowIndexInColumn(int[,] matrix, int col)
        {
            if (matrix == null) return 0;
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) return 0;
            if (col < 0 || col >= matrix.GetLength(1)) return 0;

            int max_i = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
                if (matrix[i, col] > matrix[max_i, col])
                    max_i = i;

            return max_i;
        }

        public void Task2(int[,] A, int[,] B)
        {
            if (A == null || B == null) return;

            if (A.GetLength(0) != B.GetLength(0) || A.GetLength(1) != B.GetLength(1)) return;
            if (A.GetLength(0) == 0 || A.GetLength(1) == 0) return;

            int rowA = FindMaxRowIndexInColumn(A, 0);
            int rowB = FindMaxRowIndexInColumn(B, 0);

            for (int j = 0; j < A.GetLength(1); j++)
                (A[rowA, j], B[rowB, j]) = (B[rowB, j], A[rowA, j]);
        }

        public int[] GetNegativeCountPerRow(int[,] matrix)
        {
            if (matrix == null) return Array.Empty<int>();

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] ans = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int cnt = 0;
                for (int j = 0; j < cols; j++)
                    if (matrix[i, j] < 0)
                        cnt++;

                ans[i] = cnt;
            }
            return ans;
        }

        public int Task3(int[,] matrix)
        {
            if (matrix == null) return 0;
            if (matrix.GetLength(0) == 0) return 0;

            int[] neg = GetNegativeCountPerRow(matrix);
            if (neg.Length == 0) return 0;

            int max_i = 0;
            for (int i = 1; i < neg.Length; i++)
                if (neg[i] > neg[max_i])
                    max_i = i;

            return max_i;
        }

        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;

            if (matrix == null) return 0;
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) return 0;

            int max = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        row = i;
                        col = j;
                    }

            return max;
        }

        public void Task4(int[,] A, int[,] B)
        {
            if (A == null || B == null) return;
            if (A.GetLength(0) == 0 || A.GetLength(1) == 0) return;
            if (B.GetLength(0) == 0 || B.GetLength(1) == 0) return;

            int rowA, colA, rowB, colB;
            FindMax(A, out rowA, out colA);
            FindMax(B, out rowB, out colB);

            (A[rowA, colA], B[rowB, colB]) = (B[rowB, colB], A[rowA, colA]);
        }

        public void SwapColumns(int[,] A, int colIndexA, int[,] B, int colIndexB)
        {
            if (A == null || B == null) return;
            if (A.GetLength(0) != B.GetLength(0)) return;

            if (colIndexA < 0 || colIndexA >= A.GetLength(1)) return;
            if (colIndexB < 0 || colIndexB >= B.GetLength(1)) return;

            for (int i = 0; i < A.GetLength(0); i++)
                (A[i, colIndexA], B[i, colIndexB]) = (B[i, colIndexB], A[i, colIndexA]);
        }

        public void Task5(int[,] A, int[,] B)
        {
            if (A == null || B == null) return;
            if (A.GetLength(0) == 0 || A.GetLength(1) == 0) return;
            if (B.GetLength(0) == 0 || B.GetLength(1) == 0) return;

            if (A.GetLength(0) != B.GetLength(0)) return;

            int rowA, colA, rowB, colB;
            FindMax(A, out rowA, out colA);
            FindMax(B, out rowB, out colB);

            SwapColumns(A, colA, B, colB);
        }

        public void SortDiagonalAscending(int[,] matrix)
        {
            if (matrix == null) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;

            int n = matrix.GetLength(0);
            int[] diag = new int[n];
            for (int i = 0; i < n; i++) diag[i] = matrix[i, i];

            Array.Sort(diag);

            for (int i = 0; i < n; i++) matrix[i, i] = diag[i];
        }

        public void SortDiagonalDescending(int[,] matrix)
        {
            if (matrix == null) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;

            int n = matrix.GetLength(0);
            int[] diag = new int[n];
            for (int i = 0; i < n; i++) diag[i] = matrix[i, i];

            Array.Sort(diag);
            Array.Reverse(diag);

            for (int i = 0; i < n; i++) matrix[i, i] = diag[i];
        }

        public delegate void Sorting(int[,] matrix);

        public void Task6(int[,] matrix, Sorting sort)
        {
            if (matrix == null || sort == null) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;

            sort(matrix);
        }

        public long Factorial(int n)
        {
            if (n < 0) return 0;
            long res = 1;
            for (int i = 2; i <= n; i++) res *= i;
            return res;
        }

        public long Task7(int n, int k)
        {
            if (n < 0 || k < 0 || k > n) return 0;

            long fn = Factorial(n);
            long fk = Factorial(k);
            long fnk = Factorial(n - k);

            if (fk == 0 || fnk == 0) return 0;
            return fn / (fk * fnk);
        }

        public double GetDistance(double v, double a)
        {
            return 10 * v + 45 * a;
        }

        public double GetTime(double v, double a)
        {
            if (v <= 0 && a <= 0) return 0;

            double dist = 0;
            double speed = v;
            int hours = 0;

            while (dist < 100)
            {
                if (speed <= 0) return 0;
                dist += speed;
                hours++;
                speed += a;

                if (hours > 100000) return 0;
            }

            return hours;
        }

        public delegate double BikeRide(double v, double a);

        public double Task8(double v, double a, BikeRide ride)
        {
            if (ride == null) return 0;
            return ride(v, a);
        }

        public delegate void Swapper(int[] array);

        public void SwapFromLeft(int[] array)
        {
            if (array == null) return;

            for (int i = 1; i < array.Length; i += 2)
                (array[i], array[i - 1]) = (array[i - 1], array[i]);
        }

        public void SwapFromRight(int[] array)
        {
            if (array == null) return;

            for (int i = array.Length - 1; i > 0; i -= 2)
                (array[i], array[i - 1]) = (array[i - 1], array[i]);
        }

        public int GetSum(int[] array)
        {
            if (array == null) return 0;

            int sum = 0;
            for (int i = 1; i < array.Length; i += 2)
                sum += array[i];

            return sum;
        }

        public int Task9(int[][] array)
        {
            if (array == null) return 0;

            int answer = 0;

            Swapper op = (array.Length % 2 == 0) ? SwapFromLeft : SwapFromRight;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null) continue;
                op(array[i]);
                answer += GetSum(array[i]);
            }

            return answer;
        }

        public int CountPositive(int[][] array)
        {
            if (array == null) return 0;

            int ans = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null) continue;
                for (int j = 0; j < array[i].Length; j++)
                    if (array[i][j] > 0) ans++;
            }
            return ans;
        }

        public int FindMax(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0) return 0;

            bool has = false;
            int max = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] == null || matrix[i].Length == 0) continue;
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (!has || matrix[i][j] > max)
                    {
                        max = matrix[i][j];
                        has = true;
                    }
                }
            }

            return has ? max : 0;
        }

        public int FindMaxRowLength(int[][] array)
        {
            if (array == null) return 0;

            int ans = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i] != null)
                    ans = Math.Max(ans, array[i].Length);

            return ans;
        }

        public int Task10(int[][] array, System.Func<int[][], int> func)
        {
            if (array == null || func == null) return 0;
            return func(array);
        }
    }
}

