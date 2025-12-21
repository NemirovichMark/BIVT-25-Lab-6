using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class White
    {
        public void Task1(double[] A, double[] B)
        {

            // code here
            int maxIndexA = FindMaxIndex(A);
            int maxIndexB = FindMaxIndex(B);
            if (maxIndexA != -1 && maxIndexB != -1)
            {
                if (A.Length - maxIndexA > B.Length - maxIndexB)
                {
                    if (maxIndexA < A.Length - 1)
                    {
                        double sum = 0;
                        int count = 0;

                        for (int i = maxIndexA + 1; i < A.Length; i++)
                        {
                            sum += A[i];
                            count++;
                        }

                        if (count > 0)
                        {
                            double average = sum / count;
                            A[maxIndexA] = average;
                        }
                    }
                }
                else if (A.Length - maxIndexA < B.Length - maxIndexB)
                {
                    if (maxIndexB < B.Length - 1)
                    {
                        double sum = 0;
                        int count = 0;

                        for (int i = maxIndexB + 1; i < B.Length; i++)
                        {
                            sum += B[i];
                            count++;
                        }

                        if (count > 0)
                        {
                            double average = sum / count;
                            B[maxIndexB] = average; 
                        }
                    }
                }
                else
                {
                    if (maxIndexA < A.Length - 1)
                    {
                        double sum = 0;
                        int count = 0;

                        for (int i = maxIndexA + 1; i < A.Length; i++)
                        {
                            sum += A[i];
                            count++;
                        }

                        if (count > 0)
                        {
                            double average = sum / count;
                            A[maxIndexA] = average;
                        }
                    }
                }
            }
            // end

        }
        public int FindMaxIndex(double[] array)
        {
            int maxIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[maxIndex])
                {
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        public void Task2(int[,] A, int[,] B)
        {

            // code here
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
            // end

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

        public int Task3(int[,] matrix)
        {
            int answer = 0;

            // code here
            int[] negativeCounts = GetNegativeCountPerRow(matrix);

            int maxCount = negativeCounts[0];
            for (int i = 1; i < negativeCounts.Length; i++)
            {
                if (negativeCounts[i] > maxCount)
                {
                    maxCount = negativeCounts[i];
                    answer = i;
                }
            }
            // end

            return answer;
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
                    {
                        count++;
                    }
                }
                negativeCounts[i] = count;
            }
            return negativeCounts;
        }

        public void Task4(int[,] A, int[,] B)
        {

            // code here
            FindMax(A, out int rowA, out int colA);
            FindMax(B, out int rowB, out int colB);

            int temp = A[rowA, colA];
            A[rowA, colA] = B[rowB, colB];
            B[rowB, colB] = temp;
            // end

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

        public void Task5(int[,] A, int[,] B)
        {

            // code here
            FindMax(A, out int rowA, out int colA);
            FindMax(B, out int rowB, out int colB);

            SwapColumns(A, colA, B, colB);
            // end

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

        public void Task6(int[,] matrix, Sorting sort)
        {

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                sort(matrix);
            }
            // end

        }
        public delegate void Sorting(int[,] matrix);
        public void SortDiagonalAscending(int[,] matrix)
        {
            int n = matrix.GetLength(0);

            int[] diagonal = new int[n];
            for (int i = 0; i < n; i++)
            {
                diagonal[i] = matrix[i, i];
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
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
            int n = matrix.GetLength(0); 
            int[] diagonal = new int[n];
            for (int i = 0; i < n; i++)
            {
                diagonal[i] = matrix[i, i];
            }
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
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

        public long Task7(int n, int k)
        {
            long answer = 0;

            // code here
            answer = Factorial(n) / (Factorial(k) * Factorial(n - k));
            // end

            return answer;
        }
        public long Factorial(int n)
        {
            if (n <= 1)
                return 1;
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
            double distance = 0;
            for (int hour = 0; hour < 10; hour++)
            {
                distance += v + hour * a;
            }
            return distance;
        }
        public double GetTime(double v, double a)
        {
            double distance = 0;
            int hours = 0;
            while (distance < 100)
            {
                distance += v + hours * a;
                hours++;
            }
            return hours;
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
            int max = array[0][0];
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
            int maxLength = array[0].Length;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].Length > maxLength)
                {
                    maxLength = array[i].Length;
                }
            }
            return maxLength;
        }
    }
}