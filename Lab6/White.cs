using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public delegate void Sorting(int[,] matrix);
    public delegate double BikeRide(double v, double a);
    public delegate void Swapper(int[] arr);
    public class White
    {


        public int FindMaxIndex(double[] array)
        {
            if (array == null || array.Length == 0)
                return -1;

            int maxIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[maxIndex])
                    maxIndex = i;
            }
            return maxIndex;
        }
        public int FindMaxRowIndexInColumn(int[,] matrix, int col)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0 || col < 0 || col >= matrix.GetLength(1))
                return -1;

            int maxRowIndex = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > matrix[maxRowIndex, col])
                    maxRowIndex = i;
            }
            return maxRowIndex;
        }
        public int[] GetNegativeCountPerRow(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return new int[0];

            int rows = matrix.GetLength(0);
            int[] counts = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                        count++;
                }
                counts[i] = count;
            }
            return counts;
        }
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = -1;
            col = -1;
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return 0;

            int max = matrix[0, 0];
            row = 0;
            col = 0;
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
            if (A == null || B == null || colIndexA < 0 || colIndexB < 0 ||
                colIndexA >= A.GetLength(1) || colIndexB >= B.GetLength(1) ||
                A.GetLength(0) != B.GetLength(0))
                return;

            int rows = A.GetLength(0);
            for (int i = 0; i < rows; i++)
            {
                int temp = A[i, colIndexA];
                A[i, colIndexA] = B[i, colIndexB];
                B[i, colIndexB] = temp;
            }
        }
        public void SortDiagonalAscending(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1) || matrix.GetLength(0) == 0)
                return;

            int n = matrix.GetLength(0);
            int[] diagonal = new int[n];
            for (int i = 0; i < n; i++)
                diagonal[i] = matrix[i, i];

            diagonal = diagonal.OrderBy(x => x).ToArray();

            for (int i = 0; i < n; i++)
                matrix[i, i] = diagonal[i];
        }

        public void SortDiagonalDescending(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1) || matrix.GetLength(0) == 0)
                return;

            int n = matrix.GetLength(0);
            int[] diagonal = new int[n];
            for (int i = 0; i < n; i++)
                diagonal[i] = matrix[i, i];

            diagonal = diagonal.OrderByDescending(x => x).ToArray();

            for (int i = 0; i < n; i++)
                matrix[i, i] = diagonal[i];
        }
        public long Factorial(int n)
        {
            if (n < 0)
                return 0;
            if (n == 0)
                return 1;
            return n * Factorial(n - 1);
        }
        public double GetDistance(double v, double a)
        {
            return 10 * v + 45 * a;
        }

        public double GetTime(double v, double a)
        {
            if (v <= 0)
                return 0;

            double distance = 0;
            double hours = 0;
            double currentSpeed = v;

            while (distance < 100)
            {
                if (currentSpeed <= 0)
                    return 0;

                distance += currentSpeed;
                hours += 1;
                currentSpeed += a;
            }
            return hours;
        }
        public int GetSum(int[] array)
        {
            if (array == null || array.Length <= 1)
                return 0;

            int sum = 0;
            for (int i = 1; i < array.Length; i += 2)
                sum += array[i];
            return sum;
        }

        public void SwapFromLeft(int[] array)
        {
            if (array == null || array.Length < 2)
                return;

            for (int i = 0; i < array.Length - 1; i += 2)
            {
                int temp = array[i];
                array[i] = array[i + 1];
                array[i + 1] = temp;
            }
        }

        public void SwapFromRight(int[] array)
        {
            if (array == null || array.Length < 2)
                return;

            int i = array.Length - 1;
            while (i >= 1)
            {
                int temp = array[i];
                array[i] = array[i - 1];
                array[i - 1] = temp;
                i -= 2;
            }
        }
        public int CountPositive(int[][] array)
        {
            if (array == null)
                return 0;

            int count = 0;
            foreach (int[] row in array)
            {
                if (row == null) continue;
                foreach (int num in row)
                {
                    if (num > 0)
                        count++;
                }
            }
            return count;
        }

        public int FindMax(int[][] array)
        {
            if (array == null || array.Length == 0)
                return 0;

            bool firstValue = true;
            int max = 0;
            foreach (int[] row in array)
            {
                if (row == null) continue;
                foreach (int num in row)
                {
                    if (firstValue || num > max)
                    {
                        max = num;
                        firstValue = false;
                    }
                }
            }
            return firstValue ? 0 : max;
        }

        public int FindMaxRowLength(int[][] array)
        {
            if (array == null || array.Length == 0)
                return 0;

            int maxLength = 0;
            foreach (int[] row in array)
            {
                if (row == null) continue;
                if (row.Length > maxLength)
                    maxLength = row.Length;
            }
            return maxLength;
        }




        public void Task1(double[] A, double[] B)
        {

            // code here
            if (A == null || B == null || A.Length == 0 || B.Length == 0)
                return;

            int maxIndexA = FindMaxIndex(A);
            int maxIndexB = FindMaxIndex(B);

            int distanceFromEndA = A.Length - 1 - maxIndexA;
            int distanceFromEndB = B.Length - 1 - maxIndexB;

            double[] targetArray;
            int maxIndex;

            if (distanceFromEndA > distanceFromEndB)
            {
                targetArray = A;
                maxIndex = maxIndexA;
            }
            else if (distanceFromEndB > distanceFromEndA)
            {
                targetArray = B;
                maxIndex = maxIndexB;
            }
            else
            {
                targetArray = A;
                maxIndex = maxIndexA;
            }

            if (maxIndex == targetArray.Length - 1)
                return;

            double sum = 0;
            int count = 0;
            for (int i = maxIndex + 1; i < targetArray.Length; i++)
            {
                sum += targetArray[i];
                count++;
            }

            double average = count == 0 ? 0 : sum / count;
            targetArray[maxIndex] = average;
            // end

        }
        public void Task2(int[,] A, int[,] B)
        {

            // code here
            if (A == null || B == null)
                return;

            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);

            if (rowsA != rowsB || colsA != colsB || colsA == 0)
                return;

            int rowA = FindMaxRowIndexInColumn(A, 0);
            int rowB = FindMaxRowIndexInColumn(B, 0);

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
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return answer;

            int[] negativeCounts = GetNegativeCountPerRow(matrix);
            int maxCount = negativeCounts[0];
            int maxIndex = 0;

            for (int i = 1; i < negativeCounts.Length; i++)
            {
                if (negativeCounts[i] > maxCount)
                {
                    maxCount = negativeCounts[i];
                    maxIndex = i;
                }
            }
            answer = maxIndex;

            // end

            return answer;
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            if (A == null || B == null || A.GetLength(0) == 0 || A.GetLength(1) == 0 || B.GetLength(0) == 0 || B.GetLength(1) == 0)
                return;

            int rowA, colA, rowB, colB;
            int maxA = FindMax(A, out rowA, out colA);
            int maxB = FindMax(B, out rowB, out colB);

            A[rowA, colA] = maxB;
            B[rowB, colB] = maxA;
            // end

        }
        public void Task5(int[,] A, int[,] B)
        {

            // code here
            if (A == null || B == null)
                return;

            if (A.GetLength(0) != B.GetLength(0))
                return;

            int rowA, colA, rowB, colB;
            FindMax(A, out rowA, out colA);
            FindMax(B, out rowB, out colB);

            SwapColumns(A, colA, B, colB);
            // end

        }
        public void Task6(int[,] matrix, Sorting sort)
        {

            // code here

            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1) || matrix.GetLength(0) == 0)
                return;

            sort(matrix);
            // end

        }
        public long Task7(int n, int k)
        {
            long answer = 0;

            // code here

            if (n < 0 || k < 0 || k > n)
                return answer;

            long numerator = Factorial(n);
            long denominator = Factorial(k) * Factorial(n - k);
            answer = numerator / denominator;
            // end

            return answer;
        }
        public double Task8(double v, double a, BikeRide ride)
        {
            double answer = 0;

            // code here
            if (ride == null)
                return answer;

            answer = ride(v, a);
            // end

            return answer;
        }
        public int Task9(int[][] array)
        {
            int answer = 0;

            // code here
            if (array == null)
                return answer;

            bool isEvenCount = array.Length % 2 == 0;
            Swapper swapper = isEvenCount ? new Swapper(SwapFromLeft) : new Swapper(SwapFromRight);

            foreach (int[] innerArray in array)
            {
                if (innerArray == null || innerArray.Length == 0)
                    continue;


                swapper(innerArray);
                for (int i = 1; i < innerArray.Length; i += 2)
                {
                    answer += (int)innerArray[i];
                }
            }

            // end

            return answer;
        }
        public int Task10(int[][] array, Func<int[][], int> func)
        {
            int answer = 0;

            // code here
            if (func == null || array == null)
                return answer;

            answer = func(array);
            // end

            return answer;
        }
    }
}