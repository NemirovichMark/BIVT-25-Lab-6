using System;

namespace Lab6
{
    public delegate void Sorting(int[,] matrix);
    public delegate double BikeRide(double v, double a);

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

        public void Task1(double[] A, double[] B)
        {
            if (A == null || B == null || A.Length == 0 || B.Length == 0)
                return;

            int maxIndexA = FindMaxIndex(A);
            int maxIndexB = FindMaxIndex(B);

            int distanceA = A.Length - 1 - maxIndexA;
            int distanceB = B.Length - 1 - maxIndexB;

            double[] targetArray;
            if (distanceA > distanceB)
                targetArray = A;
            else if (distanceB > distanceA)
                targetArray = B;
            else
                targetArray = A;

            int maxIndex = (targetArray == A) ? maxIndexA : maxIndexB;

            if (maxIndex == targetArray.Length - 1)
                return;

            double sum = 0;
            int count = 0;
            for (int i = maxIndex + 1; i < targetArray.Length; i++)
            {
                sum += targetArray[i];
                count++;
            }

            if (count > 0)
                targetArray[maxIndex] = sum / count;
        }

        public int FindMaxRowIndexInColumn(int[,] matrix, int col)
        {
            if (matrix == null || col < 0 || col >= matrix.GetLength(1))
                return -1;

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
            if (A == null || B == null || 
                A.GetLength(0) != B.GetLength(0) || 
                A.GetLength(1) != B.GetLength(1))
                return;

            int rowA = FindMaxRowIndexInColumn(A, 0);
            int rowB = FindMaxRowIndexInColumn(B, 0);

            if (rowA == -1 || rowB == -1)
                return;

            for (int j = 0; j < A.GetLength(1); j++)
            {
                int temp = A[rowA, j];
                A[rowA, j] = B[rowB, j];
                B[rowB, j] = temp;
            }
        }

        public int[] GetNegativeCountPerRow(int[,] matrix)
        {
            if (matrix == null)
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

        public int Task3(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return 0;

            int[] negativeCounts = GetNegativeCountPerRow(matrix);
            int maxIndex = 0;

            for (int i = 1; i < negativeCounts.Length; i++)
            {
                if (negativeCounts[i] > negativeCounts[maxIndex])
                    maxIndex = i;
            }
            
            return maxIndex;
        }

        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = -1;
            col = -1;
            
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return 0;

            int maxValue = matrix[0, 0];
            row = 0;
            col = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            return maxValue;
        }

        public void Task4(int[,] A, int[,] B)
        {
            if (A == null || B == null)
                return;

            int rowA, colA, rowB, colB;
            int maxA = FindMax(A, out rowA, out colA);
            int maxB = FindMax(B, out rowB, out colB);

            A[rowA, colA] = maxB;
            B[rowB, colB] = maxA;
        }

        public void SwapColumns(int[,] A, int collIndexA, int[,] B, int collIndexB)
        {
            if (A == null || B == null || 
                A.GetLength(0) != B.GetLength(0) ||
                collIndexA < 0 || collIndexA >= A.GetLength(1) ||
                collIndexB < 0 || collIndexB >= B.GetLength(1))
                return;

            for (int i = 0; i < A.GetLength(0); i++)
            {
                int temp = A[i, collIndexA];
                A[i, collIndexA] = B[i, collIndexB];
                B[i, collIndexB] = temp;
            }
        }

        public void Task5(int[,] A, int[,] B)
        {
            if (A == null || B == null || A.GetLength(0) != B.GetLength(0))
                return;

            int rowA, colA, rowB, colB;
            FindMax(A, out rowA, out colA);
            FindMax(B, out rowB, out colB);

            SwapColumns(A, colA, B, colB);
        }

        public void SortDiagonalAscending(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
                return;

            int n = matrix.GetLength(0);
            
            int[] diagonal = new int[n];
            for (int i = 0; i < n; i++)
                diagonal[i] = matrix[i, i];

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
                matrix[i, i] = diagonal[i];
        }

        public void SortDiagonalDescending(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
                return;

            int n = matrix.GetLength(0);
            
            int[] diagonal = new int[n];
            for (int i = 0; i < n; i++)
                diagonal[i] = matrix[i, i];

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
                matrix[i, i] = diagonal[i];
        }

        public void Task6(int[,] matrix, Sorting sort)
        {
            if (matrix == null || sort == null)
                return;

            sort(matrix);
        }

        public long Factorial(int n)
        {
            if (n < 0) return 0;
            if (n <= 1) return 1;
            
            return n * Factorial(n - 1);
        }

        public long Task7(int n, int k)
        {
            if (n < 0 || k < 0 || k > n)
                return 0;

            long numerator = Factorial(n);
            long denominator = Factorial(k) * Factorial(n - k);
            
            if (denominator == 0)
                return 0;

            return numerator / denominator;
        }

        public double GetDistance(double v, double a)
        {
            double distance = 0;
            double currentSpeed = v;
            
            for (int hour = 1; hour <= 10; hour++)
            {
                distance += currentSpeed;
                currentSpeed += a;
            }
            
            return distance;
        }

        public double GetTime(double v, double a)
        {
            const double targetDistance = 100.0;
            double distance = 0;
            double currentSpeed = v;
            int hours = 0;
            
            while (distance < targetDistance)
            {
                distance += currentSpeed;
                currentSpeed += a;
                hours++;
                
                if (hours > 1000)
                    return -1;
            }
            
            return hours;
        }

        public double Task8(double v, double a, BikeRide ride)
        {
            if (ride == null)
                return 0;

            return ride(v, a);
        }

        public double Sum(double[] array)
        {
            if (array == null || array.Length == 0)
                return 0;

            double sum = 0;
            for (int i = 1; i < array.Length; i += 2)
            {
                sum += array[i];
            }
            return sum;
        }

        public void SwapFromLeft(double[] array)
        {
            if (array == null || array.Length < 2)
                return;

            for (int i = 0; i < array.Length - 1; i += 2)
            {
                double temp = array[i];
                array[i] = array[i + 1];
                array[i + 1] = temp;
            }
        }

        public void SwapFromRight(double[] array)
        {
            if (array == null || array.Length < 2)
                return;

            int start = array.Length % 2 == 0 ? 0 : 1;
            for (int i = start; i < array.Length - 1; i += 2)
            {
                double temp = array[i];
                array[i] = array[i + 1];
                array[i + 1] = temp;
            }
        }

        public int Task9(int[][] array)
        {
            if (array == null || array.Length == 0)
                return 0;

            if (array.Length % 2 == 0)
            {
                foreach (var arr in array)
                {
                    if (arr != null)
                        SwapFromLeft(Array.ConvertAll(arr, item => (double)item));
                }
            }
            else
            {
                foreach (var arr in array)
                {
                    if (arr != null)
                        SwapFromRight(Array.ConvertAll(arr, item => (double)item));
                }
            }

            int totalSum = 0;
            foreach (var arr in array)
            {
                if (arr != null)
                {
                    double[] doubleArr = Array.ConvertAll(arr, item => (double)item);
                    totalSum += (int)Sum(doubleArr);
                }
            }

            return totalSum;
        }

        public int CountPositive(int[][] array)
        {
            if (array == null)
                return 0;

            int count = 0;
            foreach (var arr in array)
            {
                if (arr != null)
                {
                    foreach (var item in arr)
                    {
                        if (item > 0)
                            count++;
                    }
                }
            }
            return count;
        }

        public int FindMax(int[][] array)
        {
            if (array == null || array.Length == 0)
                return 0;

            int max = int.MinValue;
            bool found = false;

            foreach (var arr in array)
            {
                if (arr != null && arr.Length > 0)
                {
                    foreach (var item in arr)
                    {
                        if (item > max)
                        {
                            max = item;
                            found = true;
                        }
                    }
                }
            }

            return found ? max : 0;
        }

        public int FindMaxRowLength(int[][] array)
        {
            if (array == null || array.Length == 0)
                return 0;

            int maxLength = 0;
            foreach (var arr in array)
            {
                if (arr != null && arr.Length > maxLength)
                    maxLength = arr.Length;
            }
            return maxLength;
        }

        public int Task10(int[][] array, Func<int[][], int> func)
        {
            if (array == null || func == null)
                return 0;

            return func(array);
        }
    }
}
