using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class White
    {
        // Helper method for Task1
        public int FindMaxIndex(double[] array)
        {
            int maxIndex = 0;
            double maxValue = array[0];
            
            for (int i = 1; i < array.Length; i++)
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
            int maxIndexA = FindMaxIndex(A);
            int maxIndexB = FindMaxIndex(B);
            
            int distanceA = A.Length - 1 - maxIndexA;
            int distanceB = B.Length - 1 - maxIndexB;
            
            double[] arrayToModify = A;
            int maxIndex = maxIndexA;
            
            if (distanceB > distanceA)
            {
                arrayToModify = B;
                maxIndex = maxIndexB;
            }
            
            if (maxIndex == arrayToModify.Length - 1)
            {
                return;
            }
            
            double sum = 0;
            int count = 0;
            
            for (int i = maxIndex + 1; i < arrayToModify.Length; i++)
            {
                sum += arrayToModify[i];
                count++;
            }
            
            double average = sum / count;
            arrayToModify[maxIndex] = average;
            // end
        }

        // Helper method for Task2
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
            // code here
            if (A.GetLength(0) != B.GetLength(0) || A.GetLength(1) != B.GetLength(1))
            {
                return;
            }
            
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

        // Helper method for Task3
        public int[] GetNegativeCountPerRow(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int[] result = new int[rows];
            
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
                result[i] = count;
            }
            
            return result;
        }

        public int Task3(int[,] matrix)
        {
            int answer = 0;
            // code here
            int[] negativeCounts = GetNegativeCountPerRow(matrix);
            
            int maxCount = negativeCounts[0];
            answer = 0;
            
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

        // Helper method for Task4 and Task5
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            int maxValue = matrix[0, 0];
            
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
            // code here
            int rowA, colA, rowB, colB;
            int maxA = FindMax(A, out rowA, out colA);
            int maxB = FindMax(B, out rowB, out colB);
            
            A[rowA, colA] = maxB;
            B[rowB, colB] = maxA;
            // end
        }

        // Helper method for Task5
        public void SwapColumns(int[,] A, int colIndexA, int[,] B, int colIndexB)
        {
            if (A.GetLength(0) != B.GetLength(0))
            {
                return;
            }
            
            for (int i = 0; i < A.GetLength(0); i++)
            {
                int temp = A[i, colIndexA];
                A[i, colIndexA] = B[i, colIndexB];
                B[i, colIndexB] = temp;
            }
        }

        public void Task5(int[,] A, int[,] B)
        {
            // code here
            int rowA, colA, rowB, colB;
            FindMax(A, out rowA, out colA);
            FindMax(B, out rowB, out colB);
            
            SwapColumns(A, colA, B, colB);
            // end
        }

        // Delegate for Task6
        public delegate void Sorting(int[,] matrix);

        public void SortDiagonalAscending(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (matrix[i, i] > matrix[j, j])
                    {
                        int temp = matrix[i, i];
                        matrix[i, i] = matrix[j, j];
                        matrix[j, j] = temp;
                    }
                }
            }
        }

        public void SortDiagonalDescending(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (matrix[i, i] < matrix[j, j])
                    {
                        int temp = matrix[i, i];
                        matrix[i, i] = matrix[j, j];
                        matrix[j, j] = temp;
                    }
                }
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

        // Helper method for Task7
        public long Factorial(int n)
        {
            if (n <= 1)
                return 1;
            return n * Factorial(n - 1);
        }

        public long Task7(int n, int k)
        {
            long answer = 0;
            // code here
            if (k > n || n < 0 || k < 0)
                return 0;
            
            long numerator = Factorial(n);
            long denominator = Factorial(k) * Factorial(n - k);
            
            answer = numerator / denominator;
            // end
            return answer;
        }

        // Delegate for Task8
        public delegate double BikeRide(double v, double a);

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
            
            while (distance < 100 && hours < 1000)
            {
                distance += currentV;
                currentV += a;
                hours++;
            }
            
            return hours;
        }

        public double Task8(double v, double a, BikeRide ride)
        {
            double answer = 0;
            // code here
            answer = ride(v, a);
            // end
            return answer;
        }

        // Helper methods for Task9
        public double Sum(double[] array)
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0) // четные индексы (0, 2, 4...)
                {
                    sum += array[i];
                }
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
            int answer = 0;
            // code here
            if (array.Length % 2 == 0)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    double[] doubleArray = array[i].Select(x => (double)x).ToArray();
                    SwapFromLeft(doubleArray);
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    double[] doubleArray = array[i].Select(x => (double)x).ToArray();
                    SwapFromRight(doubleArray);
                }
            }
            
            double totalSum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 1) // нечетные индексы (1, 3, 5...)
                {
                    double[] doubleArray = array[i].Select(x => (double)x).ToArray();
                    totalSum += Sum(doubleArray);
                }
            }
            
            answer = (int)totalSum;
            // end
            return answer;
        }

        // Helper methods for Task10
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

        public int FindMaxInJagged(int[][] array)
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
