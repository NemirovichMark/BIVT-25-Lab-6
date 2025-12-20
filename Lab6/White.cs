using System.Linq;
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
            double sum = 0;
            double m = 0;
            double count = 0;
            if (((A.Length - maxA) >= (B.Length - maxB)) && maxA != A.Length)
            {
                for (int i = maxA + 1; i < A.Length; i++)
                {
                    sum += A[i];
                    count++;
                }
                m = sum / count;
                A[maxA] = m;
            }
            else if (((A.Length - maxA) >= (B.Length - maxB)) && maxB != B.Length)
            {
                for (int i = maxB + 1; i < B.Length; i++)
                {
                    sum += B[i];
                    count++;
                }
                m = sum / count;
                B[maxB] = m;
            }
            // end

        }
        public int FindMaxIndex(double[] array)
        {
            double max = double.MinValue;
            int maxi = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    maxi = i;
                }
            }
            return maxi;
        }

        public void Task2(int[,] A, int[,] B)
        {

            // code here
            int rowA = FindMaxRowIndexInColumn(A, 1);
            int rowB = FindMaxRowIndexInColumn(B, 1);
            if (A.GetLength(0) == B.GetLength(0) && A.GetLength(1) == B.GetLength(1))
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    (A[rowA, j], B[rowB, j]) = (B[rowB, j], A[rowA, j]);
                }
            }
            // end

        }
        public int FindMaxRowIndexInColumn(int[,] matrix, int col)
        {
            int max = int.MinValue;
            int maxi = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > matrix[maxi, col])
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
            int[] negative = GetNegativeCountPerRow(matrix);
            int maxi = 0;
            for (int i = 0; i < negative.Length; i++)
            {
                if (negative[i] > negative[maxi])
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
            int[] newMatrix = new int[matrix.GetLength(0)];
            int count = 0;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
                newMatrix[i] = count;
            }
            return newMatrix;
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            int rowA, colA;
            int colB, rowB;
            int maxA = FindMax(A, out rowA, out colA);
            int maxB = FindMax(B, out rowB, out colB);
            (A[rowA, colA], B[rowB, colB]) = (B[rowB, colB], A[rowA, colA]);
            // end

        }
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            int max = int.MinValue;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > matrix[row, col])
                    {
                        row = i;
                        col = j;
                        max = matrix[i, j];
                    }
                }
            }
            return max;
        }
        public void Task5(int[,] A, int[,] B)
        {

            // code here
            int rowA, rowB, colA, colB;
            int maxA = FindMax(A, out rowA, out colA);
            int maxB = FindMax(B, out rowB, out colB);
            if (A.GetLength(0) == B.GetLength(0))
            {
                SwapColumns(A, colA, B, colB);
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
            sort(matrix);
            // end

        }
        public delegate void Sorting(int[,] matrix);
        public void SortDiagonalAscending(int[,] matrix)
        {
            int[] newMatrix = new int[matrix.GetLength(0)];
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    newMatrix[i] = matrix[i, i];
                }
                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    for (int j = 0; i < matrix.GetLength(0) - i - 1; j++)
                    {
                        if (newMatrix[j] > newMatrix[j + 1])
                        {
                            int temp = newMatrix[j];
                            newMatrix[j] = newMatrix[j + 1];
                            newMatrix[j + 1] = temp;
                        }
                    }
                }
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, i] = newMatrix[i];
                }
            }
        }
        public void SortDiagonalDescending(int[,] matrix)
        {
            int[] newMatrix = new int[matrix.GetLength(0)];
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    newMatrix[i] = matrix[i, i];
                }
                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    for (int j = 0; i < matrix.GetLength(0) - i - 1; j++)
                    {
                        if (newMatrix[j] > newMatrix[j + 1])
                        {
                            (newMatrix[j], newMatrix[j + 1]) = (newMatrix[j + 1], newMatrix[i]);
                        }
                    }
                }
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, i] = newMatrix[i];
                }
            }
        }
        public long Task7(int n, int k)
        {
            long answer = 0;

            // code here
            if (n >= k)
            {
                answer = Factorial(n) / ((Factorial(k) * Factorial(n - k)));
            }
            else
                answer = 0;
            // end

            return answer;
        }
        public long Factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
        public double Task8(double v, double a, BikeRide ride)
        {
            double answer = 0;

            // code here
            if (v == 0 && a == 0)
            {
                return 0;
            }
            else
            {
                answer = ride(v, a);
            }
            // end

            return answer;
        }
        public delegate double BikeRide(double v, double a);
        public double GetDistance(double v, double a)
        {
            double distance = 0;
            for (int i = 0; i < 10; i++)
            {
                distance += v + a * i;
            }
            return distance;
        }
        public double GetTime(double v, double a)
        {
            double distance = v;
            double time = 0;
            while (distance < 100)
            {
                distance += v + a * distance;
                time++;
            }
            return time;
        }
        public int Task9(int[][] array)
        {
            int answer = 0;

            // code here
            Swapper swap;
            if (array.Length % 2 == 0)
            {
                swap = SwapFromLeft;
            }
            else
            {
                swap = SwapFromRight;
            }
            for (int i = 0; i < array.Length; i++)
            {
                swap(array[i]);
                answer += GetSum(array[i]);
            }
            // end

            return answer;
        }
        public delegate void Swapper(int[] array);
        public int GetSum(int[] array)
        {
            int sum = 0;
            for (int i = 1; i < array.Length; i += 2)
            {
                sum += array[i];
            }
            return sum;
        }
        public void SwapFromLeft(int[] array)
        {
            for (int i = 1; i < array.Length - 1; i += 2)
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
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public int FindMax(int[][] array)
        {
            int max = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > max)
                    {
                        max = array[i][j];
                    }
                }
            }
            return max;
        }
        public int FindMaxRowLength(int[][] array)
        {
            int maxl = 0;
            for (int i = 0; i < array[0].Length; i++)
            {
                if (array[i].Length > maxl)
                {
                    maxl = array[i].Length;
                }
            }
            return maxl;
        }
    }
}
