using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class White
    {
        public void Task1(double[] A, double[] B)
        {

            // code here
            int maxA = FindMaxIndex(A);
            int maxB = FindMaxIndex(B);

            if (maxA == -1 || maxB == -1)
            {
                return;
            }

            int na = A.Length;
            int nb = B.Length;

            int AFromEnd = na - 1 - maxA;
            int BFromEnd = nb - 1 - maxB;

            if (AFromEnd == 0)
            {
                return;
            }
            if (BFromEnd == 0)
            {
                return;
            }

            double srA = 0;
            double srB = 0;
            for (int i = maxA + 1; i < na; i++)
            {
                srA += A[i];

            }
            srA = srA / AFromEnd;
            for (int i = maxB + 1; i < nb; i++)
            {
                srB += B[i];

            }
            srB = srB / BFromEnd;
            if (AFromEnd >= BFromEnd)
            {
                A[maxA] = srA;
            }
            else
            {
                B[maxB] = srB;
            }
            // end

        }
        public int FindMaxIndex(double[] array)
        {
            if (array == null || array.Length == 0)
            {
                return -1;
            }

            int x = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > array[x])
                {
                    x = i;
                }
            }

            return x;
        }
        public void Task2(int[,] A, int[,] B)
        {

            // code here

            int na1 = A.GetLength(0);
            int na2 = A.GetLength(1);
            int nb1 = B.GetLength(0);
            int nb2 = B.GetLength(1);
            if (na1 == nb1 && na2 == nb2)
            {
                int a = FindMaxRowIndexInColumn(A, 1), b = FindMaxRowIndexInColumn(B, 1);
                for (int j = 0; j < na2; j++)
                {
                    (A[a, j], B[b, j]) = (B[b, j], A[a, j]);
                }
            }

            // end

        }
        public int FindMaxRowIndexInColumn(int[,] matrix, int col)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || col < 0 || col >= matrix.GetLength(1))
            {
                return -1;
            }

            int maxi = 0;
            int max = matrix[0, col];

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > max)
                {
                    max = matrix[i, col];
                    maxi = i;
                }
            }

            return maxi;
        }
        public int Task3(int[,] matrix)
        {
            int answer = 0;

            // code here
            int[] x = GetNegativeCountPerRow(matrix);
            int maxi = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] > x[maxi])
                {
                    maxi = i;
                }
            }
            answer = maxi;
            // end

            return answer;
        }
        public int[] GetNegativeCountPerRow(int[,] matrix)
        {
            if (matrix == null)
                return new int[0];

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] neg = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                        count++;
                }
                neg[i] = count;
            }

            return neg;
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here

            if (A == null || B == null)
            {

            }
            int maxiA, maxjA, maxiB, maxjB;
            int maxA = FindMax(A, out maxiA, out maxjA);
            int maxB = FindMax(B, out maxiB, out maxjB);

            if (maxiA == -1 || maxiB == -1)
            {
                return;
            }

            (A[maxiA, maxjA], B[maxiB, maxjB]) = (B[maxiB, maxjB], A[maxiA, maxjA]);
            // end

        }
        public int FindMax(int[,] matrix, out int row, out int col)
        {

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

            return max;
        }
        public void Task5(int[,] A, int[,] B)
        {

            // code here
            int maxia, maxja, maxib, maxjb;
            if (A.GetLength(0) == B.GetLength(0))
            {
                int maxA = FindMax(A, out maxia, out maxja), maxB = FindMax(B, out maxib, out maxjb);
                SwapColumns(A, maxja, B, maxjb);
            }
            // end

        }
        public void SwapColumns(int[,] A, int colIndexA, int[,] B, int colIndexB)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                (A[i, colIndexA], B[i, colIndexB]) = (B[i, colIndexB], A[i, colIndexA]);
            }
        }
        public void Task6(int[,] matrix, Sorting sort)
        {

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                sort(matrix);
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

        public long Task7(int n, int k)
        {
            long answer = 0;

            // code here
            answer = Factorial(n) / Factorial(n - k) / Factorial(k);
            // end

            return answer;
        }
        public long Factorial(long n)
        {
            if (n < 2)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
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
        public delegate double BikeRide(double v, double a);

        public double GetDistance(double v, double a)
        {
            double x = 10 * v + 45 * a;
            return x;
        }
        public double GetTime(double v, double a)
        {
            double s = v, x = 1;
            while (s < 100)
            {
                s += v + a * x;
                ++x;
            }
            return x;
        }
        public int Task9(int[][] array)
        {
            int answer = 0;

            // code here
            Swapper op;
            int n = array.Length;
            if (n % 2 == 1)
                op = SwapFromRight;
            else
                op = SwapFromLeft;
            for (int i = 0; i < n; i++)
            {
                op(array[i]);
                answer += GetSum(array[i]);
            }
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
        public int Task10(int[][] array, Func<int[][], int> func)
        {
            int answer = 0;

            // code here
            answer = func(array);
            // end

            return answer;
        }
        public delegate int Func(int[][] array);
        public int CountPositive(int[][] array)
        {
            int x = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > 0)
                        x++;
                }
            }
            return x;
        }
        public int FindMax(int[][] array)
        {
            int row = 0, col = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > array[row][col])
                    {
                        row = i;
                        col = j;
                    }
                }
            }
            return array[row][col];
        }
        public int FindMaxRowLength(int[][] array)
        {
            int x = 0;
            for (int i = 0; i < array.Length; i++)
            {
                x = Math.Max(x, array[i].Length);
            }
            return x;
        }
    
    }
}