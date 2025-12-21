using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class White
    {
        public delegate void Sorting(int[,] matrix);

        public delegate double BikeRide(double v, double a);

        public delegate void Swapper(int[] array);
        public void Task1(double[] A, double[] B)
        {

            // code here

            int i_A = FindMaxIndex(A);
            int i_B = FindMaxIndex(B);
            if (A.Length - i_A >= B.Length - i_B)
            {
                ReplaceMaxesWithMids(i_A, A);
            }
            else if (A.Length - i_A < B.Length - i_B)
            {
                ReplaceMaxesWithMids(i_B, B);
            }

            // end

        }
        public int FindMaxIndex(double[] array)
        {
            int ans_i = 0;
            for (int i = 0; i < array.Length;i++)
            {
                if (array[i] > array[ans_i])
                {
                    ans_i = i;
                }
            }
            return ans_i;
        }
        public void ReplaceMaxesWithMids(int i_max, double[] array)
        {
            if (i_max == array.Length - 1)
            {
                return;
            }
            double s = 0;
            for (int i = i_max + 1; i < array.Length; i++)
            {
                s += array[i];
            }
            double mid = s / (array.Length - i_max - 1);
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == array[i_max]) {
                    array[i] = mid;
                }
            }
        }
        public void Task2(int[,] A, int[,] B)
        {

            // code here

            if (A.GetLength(1) != B.GetLength(1))
            {
                return;
            }
            int i_A = FindMaxRowIndexInColumn(A, 0);
            int i_B = FindMaxRowIndexInColumn(B, 0);
            for (int j = 0; j < A.GetLength(1); j++)
            {
                (A[i_A, j], B[i_B, j]) = (B[i_B, j], A[i_A, j]);
            }

            // end

        }
        public int FindMaxRowIndexInColumn(int[,] matrix, int col)
        {
            int i_max = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > matrix[i_max, col])
                {
                    i_max = i;
                }
            }
            return i_max;
        }
        public int Task3(int[,] matrix)
        {
            int answer = 0;

            // code here

            var cnt = GetNegativeCountPerRow(matrix);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (cnt[i] > cnt[answer])
                {
                    answer = i;
                }
            }
            Console.WriteLine(string.Join(" ", cnt));

            // end

            return answer;
        }
        public int[] GetNegativeCountPerRow(int[,] matrix)
        {
            int[] ans = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        ans[i]++;
                    }
                }
            }
            return ans;
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here

            int maxA = FindMax(A, out int iA, out int jA);
            int maxB = FindMax(B, out int iB, out int jB);
            A[iA, jA] = maxB;
            B[iB, jB] = maxA;

            // end

        }
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0; col = 0;
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
        public void Task5(int[,] A, int[,] B)
        {

            // code here

            if (A.GetLength(0) != B.GetLength(0))
            {
                return;
            }
            FindMax(A, out int rowA, out int colA);
            FindMax(B, out int rowB, out int colB);
            SwapColumns(A, colA, B, colB);

            // end

        }
        public void SwapColumns(int[,] A, int colIndexA,
            int[,] B, int colIndexB)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                (A[i, colIndexA], B[i, colIndexB]) =
                    (B[i, colIndexB], A[i, colIndexA]);
            }
        }
        public void Task6(int[,] matrix, Sorting sort)
        {

            // code here

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            sort(matrix);

            // end  

        }
        public void SortDiagonalAscending(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            
            /*
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{matrix[i, i],5}");
            }
            Console.WriteLine('\n');
            */

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (matrix[j, j] > matrix[j + 1, j + 1])
                    {
                        (matrix[j, j], matrix[j + 1, j + 1]) =
                            (matrix[j + 1, j + 1], matrix[j, j]);
                    }
                }
            }
        }
        public void SortDiagonalDescending(int[,] matrix)
        {
            int n = matrix.GetLength(0);

            /*
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{matrix[i, i],5}");
            }
            Console.WriteLine('\n');
            */

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (matrix[j, j] < matrix[j + 1, j + 1])
                    {
                        (matrix[j, j], matrix[j + 1, j + 1]) =
                            (matrix[j + 1, j + 1], matrix[j, j]);
                    }
                }
            }
        }
        public long Task7(int n, int k)
        {
            long answer = 0;

            // code here

            if (0 <= k && k <= n)
            {
                answer = Factorial(n) / Factorial(k) / Factorial(n - k);
            }

            // end

            return answer;
        }
        public long Factorial(long n)
        {
            if (n == 0)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }
        public double Task8(double v, double a, BikeRide ride)
        {
            double answer = 0;

            // code here

            answer = ride(v, a);

            // end

            return answer;
        }
        public double GetDistance(double v, double a)
        {
            double ans = 0;
            for (int i = 0; i < 10; i++)
            {
                ans += v;
                v += a;
            }
            return ans;
        }
        public double GetTime(double v, double a)
        {
            int time = 0;
            double dist = 0;
            while (dist < 100)
            {
                dist += v;
                time++;
                //
                v += a;
            }
            return time;
        }
        public int Task9(int[][] array)
        {
            int answer = 0;

            // code here

            Swapper swapper;
            if (array.GetLength(0) % 2 == 0)
            {
                swapper = SwapFromLeft;
            }
            else
            {
                swapper = SwapFromRight;
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                swapper(array[i]);
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                answer += GetSum(array[i]);
            }

            // end

            return answer;
        }
        public void SwapFromLeft(int[] array)
        {
            for (int i = 1; i < array.Length; i += 2)
            {
                (array[i - 1], array[i]) = (array[i], array[i - 1]);
            }
        }
        public void SwapFromRight(int[] array)
        {
            for (int i = array.Length - 2; i >= 0; i -= 2)
            {
                (array[i], array[i + 1]) = (array[i + 1], array[i]);
            }
        }
        public int GetSum(int[] array)
        {
            int answer = 0;
            for (int i = 1; i < array.Length; i += 2)
            {
                answer += array[i];
            }
            return answer;
        }
        public int Task10(int[][] array, Func<int[][], int> func)
        {
            int answer = 0;

            // code here

            answer = func(array);

            // end

            return answer;
        }
        public int CountPositive(int[][] array)
        {
            int answer = 0;
            foreach(var a in array)
            {
                if (a!= null)
                {
                    foreach(var elem in a)
                    {
                        if (elem > 0)
                        {
                            answer++;
                        }
                    }
                }
            }
            return answer;
        }
        public int FindMax(int[][] array)
        {
            int answer = (int)(-1e9 + 7);
            foreach (var a in array)
            {
                if (a != null)
                {
                    foreach (var elem in a)
                    {
                        answer = Math.Max(answer, elem);
                    }
                }
            }
            return answer;
        }
        public int FindMaxRowLength(int[][] array)
        {
            int answer = 0;
            foreach (var a in array)
            {
                if (a != null)
                {
                    answer = Math.Max(answer, a.Length);
                }
            }
            return answer;
        }
    }
}