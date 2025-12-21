using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class White
    {
        public int FindMaxIndex(double[] array)
        {
            int max_i = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > array[max_i])
                {
                    max_i = i;
                }
            }
            return max_i;
        }
        public void Task1(double[] A, double[] B)
        {

            // code here

            int max_in_a = FindMaxIndex(A), max_in_b = FindMaxIndex(B);
            if (A.Length - max_in_a >= B.Length - max_in_b && max_in_a != A.Length)
            {
                double sr = 0, cnt = 0;
                for (int i = max_in_a + 1; i < A.Length; i++)
                {
                    sr += A[i];
                    cnt++;
                }
                sr /= cnt;
                A[max_in_a] = sr;
            }
            else if (A.Length - max_in_a < B.Length - max_in_b && max_in_b != B.Length)
            {
                double sr = 0, cnt = 0;
                for (int i = max_in_b + 1; i < B.Length; i++)
                {
                    sr += B[i];
                    cnt++;
                }
                sr /= cnt;
                B[max_in_b] = sr;
            }
            // end

        }
        public int FindMaxRowIndexInColumn(int[,] matrix, int col)
        {
            int max_i = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > matrix[max_i, col])
                {
                    max_i = i;
                }
            }
            return max_i;
        }
        public void Task2(int[,] A, int[,] B)
        {

            // code here

            if (A.GetLength(0) == B.GetLength(0) && A.GetLength(1) == B.GetLength(1))
            {
                int h_for_a = FindMaxRowIndexInColumn(A, 1), h_for_b = FindMaxRowIndexInColumn(B, 1);
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    (A[h_for_a, j], B[h_for_b, j]) = (B[h_for_b, j], A[h_for_a, j]);
                }
            }
            // end

        }
        public int[] GetNegativeCountPerRow(int[,] matrix)
        {
            int[] ans = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int cnt = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0) cnt++;
                }
                ans[i] = cnt;
            }
            return ans;
        }
        public int Task3(int[,] matrix)
        {
            int answer = 0;

            // code here

            int[] row = GetNegativeCountPerRow(matrix);
            int max_i = 0;
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] > row[max_i])
                {
                    max_i = i;
                }
            }
            answer = max_i;
            // end

            return answer;
        }

        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[row, col])
                    {
                        row = i;
                        col = j;
                    }
                }
            }
            return matrix[row, col];
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here

            int row_a, col_a, col_b, row_b;
            int maxi_a = FindMax(A, out row_a, out col_a), maxi_b = FindMax(B, out row_b, out col_b);
            (A[row_a, col_a], B[row_b, col_b]) = (B[row_b, col_b], A[row_a, col_a]);
            // end

        }

        public void SwapColumns(int[,] A, int colIndexA, int[,] B, int colIndexB)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                (A[i, colIndexA], B[i, colIndexB]) = (B[i, colIndexB], A[i, colIndexA]);
            }
        }
        public void Task5(int[,] A, int[,] B)
        {

            // code here

            int row_a, col_a, row_b, col_b;
            if (A.GetLength(0) == B.GetLength(0))
            {
                int max_A = FindMax(A, out row_a, out col_a), max_B = FindMax(B, out row_b, out col_b);
                SwapColumns(A, col_a, B, col_b);
            }
            // end

        }

        public void SortDiagonalAscending(int[,] matrix)
        {
            int[] row = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                row[i] = matrix[i, i];
            }
            Array.Sort(row);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, i] = row[i];
            }
        }

        public void SortDiagonalDescending(int[,] matrix)
        {
            int[] row = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                row[i] = matrix[i, i];
            }
            Array.Sort(row);
            Array.Reverse(row);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, i] = row[i];
            }
        }

        public delegate void Sorting(int[,] matrix);

        public void Task6(int[,] matrix, Sorting sort)
        {

            // code here

            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                sort(matrix);
            }
            // end

        }

        public long Factorial(long n)
        {
            if (n <= 1)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }
        public long Task7(int n, int k)
        {
            long answer = 0;

            // code here

            answer = Factorial(n) / Factorial(n - k) / Factorial(k);
            // end

            return answer;
        }

        public double GetDistance(double v, double a)
        {
            double ans = 5 * (2 * v + 9 * a);
            return ans;
        }

        public double GetTime(double v, double a)
        {
            double s = v, t = 1;
            while (s < 100)
            {
                s += v + a * t;
                ++t;
            }
            return t;
        }

        public delegate double BikeRide(double v, double a);

        public double Task8(double v, double a, BikeRide ride)
        {
            double answer = 0;

            // code here

            if (v == 0 && a == 0)
                return 0;
            answer = ride(v, a);
            // end

            return answer;
        }

        public delegate void Swapper(int[] array);

        public void SwapFromLeft(int[] array)
        {
            for (int i = 1; i < array.Length; i += 2)
            {
                (array[i], array[i - 1]) = (array[i - 1], array[i]);
            }
        }

        public void SwapFromRight(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i -= 2)
            {
                (array[i], array[i - 1]) = (array[i - 1], array[i]);
            }
        }

        public int GetSum(int[] array)
        {
            int sum = 0;
            for (int i = 1; i < array.Length; i += 2)
            {
                sum += array[i];
            }
            return sum;
        }

        public int Task9(int[][] array)
        {
            int answer = 0;

            // code here

            Swapper op;
            if (array.Length % 2 == 0)
            {
                op = SwapFromLeft;
            }
            else
            {
                op = SwapFromRight;
            }
            for (int i = 0; i < array.Length; ++i)
            {
                op(array[i]);
                answer += GetSum(array[i]);
            }
            // end

            return answer;
        }

        public delegate int Func(int[][] array);

        public int CountPositive(int[][] array)
        {
            int ans = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    ans += (array[i][j] > 0 ? 1 : 0);
                }
            }
            return ans;
        }

        public int FindMax(int[][] matrix)
        {
            int row = 0, col = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] > matrix[row][col])
                    {
                        row = i;
                        col = j;
                    }
                }
            }
            return matrix[row][col];
        }

        public int FindMaxRowLength(int[][] array)
        {
            int ans = 0;
            for (int i = 0; i < array.Length; i++)
            {
                ans = Math.Max(ans, array[i].Length);
            }
            return ans;
        }

        public int Task10(int[][] array, Func<int[][], int> func)
        {
            int answer = 0;

            // code here

            answer = func(array);
            // end

            return answer;
        }
    }
}
