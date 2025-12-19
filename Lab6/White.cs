using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class White
    {
        public int FindMaxIndex(double[] array)
        {
            int len = array.Length;
            double maxValue = double.MinValue;
            int maxIndex = 0;
            for (int i = 0; i < len; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
        public void Task1(double[] A, double[] B)
        {

            // code here

            double sumOfArray = 0;
            int count = 0;
            double median = 0;
            int indexA = FindMaxIndex(A);
            int indexB = FindMaxIndex(B);
            if ((A.Length - indexA) >= (B.Length - indexB))
            {
                for (int i = indexA + 1; i < A.Length; i++)
                {
                    sumOfArray += A[i];
                    count++;
                }
                median = sumOfArray / count;
                A[indexA] = median;
            }
            else
            {
                for (int i = indexB + 1; i < B.Length; i++)
                {
                    sumOfArray += B[i];
                    count++;
                }
                median = sumOfArray / count;
                B[indexB] = median;
            }
            // end

        }
        public int FindMaxRowIndexInColumn(int[,] matrix, int col)
        {
            int amountOfRows = matrix.GetLength(0);
            int maxValue = int.MinValue;
            int maxIndex = 0;
            for (int row = 0; row < amountOfRows; row++)
            {
                if (matrix[row, col] > maxValue)
                {
                    maxValue = matrix[row, col];
                    maxIndex = row;
                }
            }
            return maxIndex;
        }
        public void Task2(int[,] A, int[,] B)
        {

            // code here

            int rowA = FindMaxRowIndexInColumn(A, 1), rowB = FindMaxRowIndexInColumn(B, 1);
            if ((A.GetLength(0) == B.GetLength(0)) && (A.GetLength(1) == B.GetLength(1)))
            {
                for (int col = 0; col < A.GetLength(0); col++)
                {
                    (A[rowA, col], B[rowB, col]) = (B[rowB, col], A[rowA, col]);
                }
            }
            // end

        }
        public int[] GetNegativeCountPerRow(int[,] matrix)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            int[] NegInRow = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        NegInRow[i]++;
                    }
                }
            }
            return NegInRow;
        }
        public int Task3(int[,] matrix)
        {
            int answer = 0;

            // code here

            int count = -1;
            int[] negativeData = GetNegativeCountPerRow(matrix);
            int maxStr = negativeData.Max();
            //// code here
            answer = Array.IndexOf(negativeData, maxStr);
            // end

            return answer;
        }
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0; col = 0;
            int MaxValue = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > MaxValue)
                    {
                        row = i; col = j;
                        MaxValue = matrix[i, j];
                    }
                }
            }
            return MaxValue;
        }
        public void Task4(int[,] A, int[,] B)
        {

            int rowA, rowB, colA, colB;
            // code here

            int maxA = FindMax(A, out rowA, out colA);
            int maxB = FindMax(B, out rowB, out colB);
            A[rowA, colA] = maxB;
            B[rowB, colB] = maxA;
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

            int rowA, rowB, colA, colB;
            int maxA = FindMax(A, out rowA, out colA);
            int maxB = FindMax(B, out rowB, out colB);
            if (A.GetLength(0) == B.GetLength(0))
            {
                SwapColumns(A, colA, B, colB);
            }
            // end

        }
        public delegate void Sorting(int[,] matrix);
        public void SortDiagonalAscending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] diagonal = new int[rows];
            if (rows == cols)
            {
                for (int i = 0; i < rows; i++)
                {
                    diagonal[i] = matrix[i, i];
                }
                for (int i = 0; i < rows - 1; i++)
                {
                    for (int j = 0; j < rows - i - 1; j++)
                    {
                        if (diagonal[j] > diagonal[j + 1])
                        {
                            int temp = diagonal[j];
                            diagonal[j] = diagonal[j + 1];
                            diagonal[j + 1] = temp;
                        }
                    }
                }
                for (int i = 0; i < rows; i++)
                {
                    matrix[i, i] = diagonal[i];
                }
            }
        }

        public void SortDiagonalDescending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] diagonal = new int[rows];
            if (rows == cols)
            {
                for (int i = 0; i < rows; i++)
                {
                    diagonal[i] = matrix[i, i];
                }
                for (int i = 0; i < rows - 1; i++)
                {
                    for (int j = 0; j < rows - i - 1; j++)
                    {
                        if (diagonal[j] < diagonal[j + 1])
                        {
                            int temp = diagonal[j];
                            diagonal[j] = diagonal[j + 1];
                            diagonal[j + 1] = temp;
                        }
                    }
                }
                for (int i = 0; i < rows; i++)
                {
                    matrix[i, i] = diagonal[i];
                }
            }
        }

        public void Task6(int[,] matrix, Sorting sort)
        {

            // code here

            sort(matrix);
            // end

        }
        public long Factorial(int n)
        {
            if (n <= 1) return 1;
            else
                return n * Factorial(n - 1);
        }
        public long Task7(int n, int k)
        {
            long answer = 0;

            // code here

            if (n >= k)
            {
                answer = Factorial(n) / (Factorial(k) * Factorial(n - k));
            }
            else
                answer = 0;
            // end

            return answer;
        }
        public delegate double BikeRide(double v, double a);
        public double GetDistance(double v, double a)
        {
            int time = 10;
            double dist = 0;
            for (int i = 0; i < time; i++)
            {
                dist += v;
                v += a;
            }
            return dist;
        }
        public double GetTime(double v, double a)
        {
            double s = 0;
            int t = 0;
            while (s < 100)
            {
                s += v;
                v += a;
                t++;
            }
            return t;
        }
        public double Task8(double v, double a, BikeRide ride)
        {
            double answer = 0;

            // code here

            answer = ride(v, a);
            // end

            return answer;
        }
        public delegate void Swapper(int[] array);
        public void SwapFromLeft(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i += 2)
            {
                (array[i], array[i + 1]) = (array[i + 1], array[i]);
            }
        }
        public void SwapFromRight(int[] array)
        {
            int n = array.Length;
            for (int i = n - 1; i > 0; i -= 2)
            {
                (array[i], array[i - 1]) = (array[i - 1], array[i]);
            }
        }
        public int GetSum(int[] array)
        {
            int n = array.Length;
            int sum = 0;
            for (int i = 1; i < n; i += 2)
            {
                sum += array[i];
            }
            return sum;
        }
        public int Task9(int[][] array)
        {
            int answer = 0;

            // code here

            int len = array.Length;
            Swapper swap;
            swap = (len % 2 == 0) ? SwapFromLeft : SwapFromRight;
            foreach (int[] array2 in array)
            {
                swap(array2);
                answer += GetSum(array2);
            }
            // end

            return answer;
        }
        public delegate int Func(int[][] array);
        public int CountPositive(int[][] array)
        {
            int countPos = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > 0) countPos++;
                }
            }
            return countPos;
        }
        public int FindMax(int[][] array)
        {
            int maxValue = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > maxValue)
                    {
                        maxValue = array[i][j];
                    }
                }
            }
            return maxValue;
        }
        public int FindMaxRowLength(int[][] array)
        {
            int maxLength = array[0].Length;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length > maxLength) maxLength = array[i].Length;
            }
            return maxLength;
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
