using System;
using System.Linq;

namespace Lab6
{
    public class White
    {
        public void Task1(double[] A, double[] B)
        {
            if (A == null && B == null)
            {
                return;
            }

            int? maxIndexA = GetMaxIndexOrNull(A);
            int? maxIndexB = GetMaxIndexOrNull(B);

            if (maxIndexA == null && maxIndexB == null)
            {
                return;
            }

            int distanceA = maxIndexA.HasValue ? A!.Length - 1 - maxIndexA.Value : -1;
            int distanceB = maxIndexB.HasValue ? B!.Length - 1 - maxIndexB.Value : -1;

            double[]? targetArray;
            int maxIndex;

            if (distanceA >= distanceB)
            {
                targetArray = maxIndexA.HasValue ? A : null;
                maxIndex = maxIndexA ?? 0;
            }
            else
            {
                targetArray = maxIndexB.HasValue ? B : null;
                maxIndex = maxIndexB ?? 0;
            }

            if (targetArray == null || maxIndex == targetArray.Length - 1)
            {
                return;
            }

            double sum = 0;
            int count = 0;

            for (int i = maxIndex + 1; i < targetArray.Length; i++)
            {
                sum += targetArray[i];
                count++;
            }

            if (count > 0)
            {
                targetArray[maxIndex] = sum / count;
            }
        }

        public void Task2(int[,] A, int[,] B)
        {
            if (A == null || B == null)
            {
                return;
            }

            if (A.GetLength(0) != B.GetLength(0) || A.GetLength(1) != B.GetLength(1))
            {
                return;
            }

            if (A.GetLength(0) == 0 || B.GetLength(0) == 0)
            {
                return;
            }

            int rowA = FindMaxRowIndexInColumn(A, 0);
            int rowB = FindMaxRowIndexInColumn(B, 0);

            for (int col = 0; col < A.GetLength(1); col++)
            {
                (A[rowA, col], B[rowB, col]) = (B[rowB, col], A[rowA, col]);
            }
        }

        public int Task3(int[,] matrix)
        {
            int answer = 0;

            if (matrix == null)
            {
                return answer;
            }

            int[] negatives = GetNegativeCountPerRow(matrix);
            if (negatives.Length == 0)
            {
                return answer;
            }

            int maxCount = negatives[0];
            for (int i = 1; i < negatives.Length; i++)
            {
                if (negatives[i] > maxCount)
                {
                    maxCount = negatives[i];
                    answer = i;
                }
            }

            return answer;
        }

        public void Task4(int[,] A, int[,] B)
        {
            if (A == null || B == null)
            {
                return;
            }

            int maxA = FindMax(A, out int rowA, out int colA);
            int maxB = FindMax(B, out int rowB, out int colB);

            if (rowA >= A.GetLength(0) || colA >= A.GetLength(1) || rowB >= B.GetLength(0) || colB >= B.GetLength(1))
            {
                return;
            }

            (B[rowB, colB], A[rowA, colA]) = (maxA, maxB);
        }

        public void Task5(int[,] A, int[,] B)
        {
            if (A == null || B == null)
            {
                return;
            }

            if (A.GetLength(0) != B.GetLength(0))
            {
                return;
            }

            FindMax(A, out _, out int colA);
            FindMax(B, out _, out int colB);

            SwapColumns(A, colA, B, colB);
        }

        public void Task6(int[,] matrix, Sorting sort)
        {
            if (matrix == null || sort == null)
            {
                return;
            }

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }

            sort(matrix);
        }

        public long Task7(int n, int k)
        {
            long answer = 0;

            if (n < 0 || k < 0 || k > n)
            {
                return answer;
            }

            long numerator = Factorial(n);
            long denominator = Factorial(k) * Factorial(n - k);

            answer = denominator == 0 ? 0 : numerator / denominator;

            return answer;
        }

        public double Task8(double v, double a, BikeRide ride)
        {
            double answer = 0;

            if (ride == null)
            {
                return answer;
            }

            answer = ride(v, a);

            return answer;
        }

        public int Task9(int[][] array)
        {
            int answer = 0;

            if (array == null)
            {
                return answer;
            }

            Swapper swapper = array.Length % 2 == 0 ? SwapFromLeft : SwapFromRight;

            foreach (int[]? row in array)
            {
                if (row == null)
                {
                    continue;
                }

                swapper(row);
                answer += (int)Sum(row.Select(value => (double)value).ToArray());
            }

            return answer;
        }

        public int Task10(int[][] array, Func<int[][], int> func)
        {
            int answer = 0;

            if (array == null || func == null)
            {
                return answer;
            }

            answer = func(array);

            return answer;
        }

        public int FindMaxIndex(double[] array)
        {
            if (array == null || array.Length == 0)
            {
                return 0;
            }

            int index = 0;
            double max = array[0];

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

        private int? GetMaxIndexOrNull(double[]? array)
        {
            if (array == null || array.Length == 0)
            {
                return null;
            }

            return FindMaxIndex(array);
        }

        public int FindMaxRowIndexInColumn(int[,] matrix, int col)
        {
            if (matrix == null)
            {
                return 0;
            }

            if (col < 0 || col >= matrix.GetLength(1))
            {
                return 0;
            }

            int maxRow = 0;
            int max = matrix[0, col];

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, col] > max)
                {
                    max = matrix[row, col];
                    maxRow = row;
                }
            }

            return maxRow;
        }

        public int[] GetNegativeCountPerRow(int[,] matrix)
        {
            if (matrix == null)
            {
                return Array.Empty<int>();
            }

            int rows = matrix.GetLength(0);
            int[] result = new int[rows];

            for (int row = 0; row < rows; row++)
            {
                int count = 0;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] < 0)
                    {
                        count++;
                    }
                }

                result[row] = count;
            }

            return result;
        }

        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;

            if (matrix == null || matrix.Length == 0 || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                return 0;
            }

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

        public void SwapColumns(int[,] A, int colIndexA, int[,] B, int colIndexB)
        {
            if (A == null || B == null)
            {
                return;
            }

            if (A.GetLength(0) != B.GetLength(0))
            {
                return;
            }

            if (colIndexA < 0 || colIndexA >= A.GetLength(1) || colIndexB < 0 || colIndexB >= B.GetLength(1))
            {
                return;
            }

            int rows = A.GetLength(0);

            for (int row = 0; row < rows; row++)
            {
                (A[row, colIndexA], B[row, colIndexB]) = (B[row, colIndexB], A[row, colIndexA]);
            }
        }

        public void SortDiagonalAscending(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }

            int size = matrix.GetLength(0);
            int[] diagonal = new int[size];

            for (int i = 0; i < size; i++)
            {
                diagonal[i] = matrix[i, i];
            }

            Array.Sort(diagonal);

            for (int i = 0; i < size; i++)
            {
                matrix[i, i] = diagonal[i];
            }
        }

        public void SortDiagonalDescending(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }

            int size = matrix.GetLength(0);
            int[] diagonal = new int[size];

            for (int i = 0; i < size; i++)
            {
                diagonal[i] = matrix[i, i];
            }

            Array.Sort(diagonal);
            Array.Reverse(diagonal);

            for (int i = 0; i < size; i++)
            {
                matrix[i, i] = diagonal[i];
            }
        }

        public long Factorial(int n)
        {
            if (n < 0)
            {
                return 0;
            }

            if (n == 0 || n == 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }

        public double GetDistance(double v, double a)
        {
            double distance = 0;

            for (int hour = 0; hour < 10; hour++)
            {
                distance += v + a * hour;
            }

            return distance;
        }

        public double GetTime(double v, double a)
        {
            if (v <= 0 && a <= 0)
            {
                return 0;
            }

            double distance = 0;
            double time = 0;
            double currentSpeed = v;

            while (distance < 100)
            {
                if (currentSpeed <= 0)
                {
                    return 0;
                }

                if (distance + currentSpeed >= 100)
                {
                    double remaining = 100 - distance;
                    time += remaining / currentSpeed;
                    break;
                }

                distance += currentSpeed;
                time++;
                currentSpeed += a;

                if (time > 1000)
                {
                    return 0;
                }
            }

            return time;
        }

        public double Sum(double[] array)
        {
            if (array == null || array.Length == 0)
            {
                return 0;
            }

            double sum = 0;

            for (int i = 1; i < array.Length; i += 2)
            {
                sum += array[i];
            }

            return sum;
        }

        public void SwapFromLeft(int[] array)
        {
            if (array == null)
            {
                return;
            }

            for (int i = 0; i + 1 < array.Length; i += 2)
            {
                (array[i], array[i + 1]) = (array[i + 1], array[i]);
            }
        }

        public void SwapFromRight(int[] array)
        {
            if (array == null)
            {
                return;
            }

            for (int i = array.Length - 1; i - 1 >= 0; i -= 2)
            {
                (array[i], array[i - 1]) = (array[i - 1], array[i]);
            }
        }
    }

    public delegate void Sorting(int[,] matrix);

    public delegate double BikeRide(double v, double a);

    public delegate void Swapper(int[] array);
}
