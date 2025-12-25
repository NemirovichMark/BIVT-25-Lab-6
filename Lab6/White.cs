using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class White
    {
        public void Task1(double[] A, double[] B)
        {
            double maxA = A[0];
            int maxIndexA = 0;
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] > maxA)
                {
                    maxA = A[i];
                    maxIndexA = i;
                }
            }

            double maxB = B[0];
            int maxIndexB = 0;
            for (int i = 1; i < B.Length; i++)
            {
                if (B[i] > maxB)
                {
                    maxB = B[i];
                    maxIndexB = i;
                }
            }

            if (maxIndexA < A.Length - 1)
            {
                double temp = A[maxIndexA];
                A[maxIndexA] = A[maxIndexA + 1];
                A[maxIndexA + 1] = temp;
            }

            if (maxIndexB < B.Length - 1)
            {
                double temp = B[maxIndexB];
                B[maxIndexB] = B[maxIndexB + 1];
                B[maxIndexB + 1] = temp;
            }
        }

        public int FindMaxRowIndexInColumn(int[,] matrix, int col)
        {
            int maxRow = 0;
            int maxValue = matrix[0, col];

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > maxValue)
                {
                    maxValue = matrix[i, col];
                    maxRow = i;
                }
            }

            return maxRow;
        }
        public void Task2(int[,] A, int[,] B)
        {
            if (A.GetLength(0) != B.GetLength(0) || A.GetLength(1) != B.GetLength(1))
                return;

            int maxRowA = FindMaxRowIndexInColumn(A, 0);
            int maxRowB = FindMaxRowIndexInColumn(B, 0);

            for (int j = 0; j < A.GetLength(1); j++)
            {
                int temp = A[maxRowA, j];
                A[maxRowA, j] = B[maxRowB, j];
                B[maxRowB, j] = temp;
            }
        }

        public int[] GetNegativeCountPerRow(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int[] negativeCounts = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                        count++;
                }
                negativeCounts[i] = count;
            }

            return negativeCounts;
        }

        public int Task3(int[,] matrix)
        {
            int answer = 0;

            int[] negativeCounts = GetNegativeCountPerRow(matrix);

            int maxIndex = 0;
            int maxCount = negativeCounts[0];

            for (int i = 1; i < negativeCounts.Length; i++)
            {
                if (negativeCounts[i] > maxCount)
                {
                    maxCount = negativeCounts[i];
                    answer = i;
                }
            }

            return answer;
        }

        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            int max = matrix[0, 0];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
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

        public void Task4(int[,] A, int[,] B)
        {
            int rowA, colA, rowB, colB;
            int maxA = FindMax(A, out rowA, out colA);
            int maxB = FindMax(B, out rowB, out colB);

            A[rowA, colA] = maxB;
            B[rowB, colB] = maxA;
        }

        public void SwapColumns(int[,] A, int colIndexA, int[,] B, int colIndexB)
        {
            if (A.GetLength(0) != B.GetLength(0))
                return;

            for (int i = 0; i < A.GetLength(0); i++)
            {
                int temp = A[i, colIndexA];
                A[i, colIndexA] = B[i, colIndexB];
                B[i, colIndexB] = temp;
            }
        }
        public void Task5(int[,] A, int[,] B)
        {
            int rowA, colA, rowB, colB;
            FindMax(A, out rowA, out colA);
            FindMax(B, out rowB, out colB);

            SwapColumns(A, colA, B, colB);
        }

        public void SortDiagonalAscending(int[,] matrix)
        {
            int n = Math.Min(matrix.GetLength(0), matrix.GetLength(1));

            int[] diagonal = new int[n];
            for (int i = 0; i < n; i++)
            {
                diagonal[i] = matrix[i, i];
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (diagonal[j] > diagonal[j + 1])
                    {
                        int temp = diagonal[j];
                        diagonal[j] = diagonal[j + 1];
                        diagonal[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                matrix[i, i] = diagonal[i];
            }
        }

        public void SortDiagonalDescending(int[,] matrix)
        {
            int n = Math.Min(matrix.GetLength(0), matrix.GetLength(1));

            int[] diagonal = new int[n];
            for (int i = 0; i < n; i++)
            {
                diagonal[i] = matrix[i, i];
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (diagonal[j] < diagonal[j + 1])
                    {
                        int temp = diagonal[j];
                        diagonal[j] = diagonal[j + 1];
                        diagonal[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                matrix[i, i] = diagonal[i];
            }
        }
        public void Task6(int[,] matrix, Sorting sort)
        {
            sort(matrix);
        }

        public long Factorial(int n)
        {
            if (n <= 1) return 1;
            return n * Factorial(n - 1);
        }
        public long Task7(int n, int k)
        {
            long answer = 0;

            if (k > n || n < 0 || k < 0) return 0;

            long numerator = Factorial(n);
            long denominator = Factorial(k) * Factorial(n - k);

            answer = numerator / denominator;

            return answer;
        }

        public double GetDistance(double v, double a)
        {
            double distance = 0;
            double currentV = v;

            for (int hour = 1; hour <= 10; hour++)
            {
                distance += currentV;
                currentV += a;
            }

            return distance;
        }

        public double GetTime(double v, double a)
        {
            double distance = 0;
            double currentV = v;
            int hours = 0;

            while (distance < 100)
            {
                hours++;
                distance += currentV;
                currentV += a;

                if (hours > 1000)
                    break;
            }

            return hours;
        }
        public double Task8(double v, double a, BikeRide ride)
        {
            double answer = 0;

            answer = ride(v, a);

            return answer;
        }

        public double Sum(double[] array)
        {
            double sum = 0;
            for (int i = 1; i < array.Length; i += 2)
            {
                sum += array[i];
            }
            return sum;
        }

        public void SwapFromLeft(double[] array)
        {
            for (int i = 0; i < array.Length - 1; i += 2)
            {
                double temp = array[i];
                array[i] = array[i + 1];
                array[i + 1] = temp;
            }
        }

        public void SwapFromRight(double[] array)
        {
            for (int i = array.Length - 1; i > 0; i -= 2)
            {
                double temp = array[i];
                array[i] = array[i - 1];
                array[i - 1] = temp;
            }
        }
        public int Task9(int[][] array)
        {
            if (array.Length % 2 == 0)
            {
                for (int i = 0; i < array.Length - 1; i += 2)
                {
                    int[] temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                }
            }
            else
            {
                for (int i = array.Length - 1; i > 0; i -= 2)
                {
                    int[] temp = array[i];
                    array[i] = array[i - 1];
                    array[i - 1] = temp;
                }
            }

            int totalSum = 0;
            foreach (var subArray in array)
            {
                for (int i = 1; i < subArray.Length; i += 2)
                {
                    totalSum += subArray[i];
                }
            }

            return totalSum;
        }

        public int CountPositive(int[][] array)
        {
            int answer = 0;
            foreach (var subArray in array)
            {
                foreach (var item in subArray)
                {
                    if (item > 0) answer++;
                }
            }
            return answer;
        }

        public int FindMaxInJaggedArray(int[][] array)
        {
            int max = int.MinValue;
            foreach (var subArray in array)
            {
                foreach (var item in subArray)
                {
                    if (item > max) max = item;
                }
            }
            return max;
        }

        public int FindMaxRowLength(int[][] array)
        {
            int maxLength = 0;
            foreach (var subArray in array)
            {
                if (subArray.Length > maxLength)
                    maxLength = subArray.Length;
            }
            return maxLength;
        }
        public int Task10(int[][] array, Func<int[][], int> func)
        {
            int answer = 0;

            answer = func(array);

            return answer;
        }
    }
}
