using System;
using System.Linq;

namespace Lab6
{
    public class White
    {
        public void Task1(double[] A, double[] B)
        {
            // code here
            if (A == null || B == null || A.Length == 0 || B.Length == 0)
                return;
            
            // Find max element and its position in A
            int maxIndexA = 0;
            double maxA = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] > maxA)
                {
                    maxA = A[i];
                    maxIndexA = i;
                }
            }
            
            // Find max element and its position in B
            int maxIndexB = 0;
            double maxB = B[0];
            for (int i = 1; i < B.Length; i++)
            {
                if (B[i] > maxB)
                {
                    maxB = B[i];
                    maxIndexB = i;
                }
            }
            
            // Calculate distance from end
            int distanceA = A.Length - 1 - maxIndexA;
            int distanceB = B.Length - 1 - maxIndexB;
            
            // Choose array to modify
            double[] arrayToModify;
            int maxIndex;
            
            if (distanceB > distanceA)
            {
                arrayToModify = B;
                maxIndex = maxIndexB;
            }
            else
            {
                arrayToModify = A;
                maxIndex = maxIndexA;
            }
            
            // If max is last element, do nothing
            if (maxIndex == arrayToModify.Length - 1)
                return;
            
            // Calculate average of elements after max
            double sum = 0;
            int count = 0;
            for (int i = maxIndex + 1; i < arrayToModify.Length; i++)
            {
                sum += arrayToModify[i];
                count++;
            }
            
            double average = sum / count;
            
            // Replace max with average
            arrayToModify[maxIndex] = average;
            // end
        }
        
        public void Task2(int[,] A, int[,] B)
        {
            // code here
            if (A == null || B == null || A.GetLength(0) == 0 || B.GetLength(0) == 0)
                return;
            
            int rowsA = A.GetLength(0);
            int rowsB = B.GetLength(0);
            
            // Find row with max in first column of A
            int maxRowA = 0;
            int maxValueA = A[0, 0];
            for (int i = 1; i < rowsA; i++)
            {
                if (A[i, 0] > maxValueA)
                {
                    maxValueA = A[i, 0];
                    maxRowA = i;
                }
            }
            
            // Find row with max in first column of B
            int maxRowB = 0;
            int maxValueB = B[0, 0];
            for (int i = 1; i < rowsB; i++)
            {
                if (B[i, 0] > maxValueB)
                {
                    maxValueB = B[i, 0];
                    maxRowB = i;
                }
            }
            
            // Swap rows if matrices have same number of columns
            int colsA = A.GetLength(1);
            int colsB = B.GetLength(1);
            
            if (colsA == colsB)
            {
                for (int j = 0; j < colsA; j++)
                {
                    int temp = A[maxRowA, j];
                    A[maxRowA, j] = B[maxRowB, j];
                    B[maxRowB, j] = temp;
                }
            }
            // end
        }
        
        public int Task3(int[,] matrix)
        {
            int answer = 0;
            // code here
            if (matrix == null || matrix.GetLength(0) == 0)
                return answer;
            
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            int maxNegativeCount = -1;
            
            for (int i = 0; i < rows; i++)
            {
                int negativeCount = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negativeCount++;
                    }
                }
                
                if (negativeCount > maxNegativeCount)
                {
                    maxNegativeCount = negativeCount;
                    answer = i;
                }
            }
            // end
            return answer;
        }
        
        public void Task4(int[,] A, int[,] B)
        {
            // code here
            if (A == null || B == null || A.GetLength(0) == 0 || B.GetLength(0) == 0)
                return;
            
            // Find max in A
            int maxRowA = 0, maxColA = 0;
            int maxA = A[0, 0];
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    if (A[i, j] > maxA)
                    {
                        maxA = A[i, j];
                        maxRowA = i;
                        maxColA = j;
                    }
                }
            }
            
            // Find max in B
            int maxRowB = 0, maxColB = 0;
            int maxB = B[0, 0];
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);
            
            for (int i = 0; i < rowsB; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    if (B[i, j] > maxB)
                    {
                        maxB = B[i, j];
                        maxRowB = i;
                        maxColB = j;
                    }
                }
            }
            
            // Swap max elements
            A[maxRowA, maxColA] = maxB;
            B[maxRowB, maxColB] = maxA;
            // end
        }
        
        public void Task5(int[,] A, int[,] B)
        {
            // code here
            if (A == null || B == null || A.GetLength(0) == 0 || B.GetLength(0) == 0)
                return;
            
            // Find max in A and its column
            int maxRowA = 0, maxColA = 0;
            int maxA = A[0, 0];
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    if (A[i, j] > maxA)
                    {
                        maxA = A[i, j];
                        maxRowA = i;
                        maxColA = j;
                    }
                }
            }
            
            // Find max in B and its column
            int maxRowB = 0, maxColB = 0;
            int maxB = B[0, 0];
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);
            
            for (int i = 0; i < rowsB; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    if (B[i, j] > maxB)
                    {
                        maxB = B[i, j];
                        maxRowB = i;
                        maxColB = j;
                    }
                }
            }
            
            // Check if same number of rows
            if (rowsA == rowsB)
            {
                // Swap columns
                for (int i = 0; i < rowsA; i++)
                {
                    int temp = A[i, maxColA];
                    A[i, maxColA] = B[i, maxColB];
                    B[i, maxColB] = temp;
                }
            }
            // end
        }
        
        public void Task6(int[,] matrix, Sorting sort)
        {
            // code here
            if (matrix == null || sort == null)
                return;
            
            // Apply the sorting function
            sort(matrix);
            // end
        }
        
        public long Task7(int n, int k)
        {
            long answer = 0;
            // code here
            if (n < 0 || k < 0 || k > n)
                return answer;
            
            // Calculate C(n, k) = n! / (k! * (n-k)!)
            long numerator = 1;
            long denominator = 1;
            
            // Optimize: C(n, k) = C(n, n-k)
            if (k > n - k)
                k = n - k;
            
            for (int i = 1; i <= k; i++)
            {
                numerator *= (n - k + i);
                denominator *= i;
            }
            
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
            if (array == null || array.Length == 0)
                return answer;
            
            bool isEvenCount = array.Length % 2 == 0;
            
            // Process each subarray
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null || array[i].Length < 2)
                    continue;
                
                if (isEvenCount)
                {
                    // Swap from left for all arrays
                    for (int j = 0; j < array[i].Length - 1; j += 2)
                    {
                        int temp = array[i][j];
                        array[i][j] = array[i][j + 1];
                        array[i][j + 1] = temp;
                    }
                }
                else
                {
                    // Swap from right for all arrays
                    for (int j = array[i].Length - 1; j > 0; j -= 2)
                    {
                        int temp = array[i][j];
                        array[i][j] = array[i][j - 1];
                        array[i][j - 1] = temp;
                    }
                }
            }
            
            // Calculate sum of elements at even indices in odd-positioned arrays (1, 3, 5...)
            for (int i = 1; i < array.Length; i += 2)
            {
                if (array[i] == null)
                    continue;
                    
                for (int j = 0; j < array[i].Length; j += 2)
                {
                    answer += array[i][j];
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
    
    // Delegate definitions
    public delegate void Sorting(int[,] matrix);
    public delegate double BikeRide(double v, double a);
}
