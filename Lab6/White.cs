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
            int distA = A.Length - 1 - maxA;
            int distB = B.Length - 1 - maxB;
            
            double[] targetArray = null;
            int targetIndex = -1;
    
            if (distA > distB)
            {
                targetArray = A;
                targetIndex = maxA;
            }
            else if (distB > distA)
            {
                targetArray = B;
                targetIndex = maxB;
            }
            else
            {
                targetArray = A;
                targetIndex = maxA;
            }
            
            if (targetIndex == targetArray.Length - 1)
                return;
            
            double sum = 0;
            int count = 0;
            for (int i = targetIndex + 1; i < targetArray.Length; i++)
            {
                sum += targetArray[i];
                count++;
            }
            double average = sum / count;
            targetArray[targetIndex] = average;
        }

        public int FindMaxIndex(double[] array)
        {
            if (array == null || array.Length == 0)
                return -1;
    
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

            // end

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
            
            if (matrix == null)
                return -1;
    
            int[] negativeCounts = GetNegativeCountPerRow(matrix);
    
            if (negativeCounts.Length == 0)
                return -1;
    
            int maxIndex = 0;
            int maxCount = negativeCounts[0];
    
            for (int i = 1; i < negativeCounts.Length; i++)
            {
                if (negativeCounts[i] > maxCount)
                {
                    maxCount = negativeCounts[i];
                    maxIndex = i;
                }
            }
    
            return maxIndex;
        }
        
        public int[] GetNegativeCountPerRow(int[,] matrix)
        {
            if (matrix == null)
                return new int[0];
    
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
    
            int[] result = new int[rows];
    
            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                        count++;
                }
                result[i] = count;
            }
    
            return result;

            // end

            
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            
            int rowA, colA;
            int colB, rowB;
            int maxA = FindMax(A, out rowA, out colA);
            int maxB = FindMax(B, out rowB, out colB);
            (A[rowA, colA], B[rowB, colB]) = (B[rowB, colB], A[rowA, colA]);
            

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

            // end

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
            

        }
        public void SwapColumns(int[,] A, int colIndexA, int[,] B, int colIndexB)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                (A[i, colIndexA], B[i, colIndexB]) = (B[i, colIndexB], A[i, colIndexA]);
            }

            // end

        }
        public void Task6(int[,] matrix, Sorting sort)
        {

            // code here
            
            if (matrix == null || sort == null) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            sort(matrix);
            
            // end

        }
        public delegate void Sorting(int[,] matrix);
        
        public void SortDiagonalAscending(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1)) 
                return;
    
            int size = matrix.GetLength(0);
            int[] diagonal = new int[size];
            
            for (int i = 0; i < size; i++)
            {
                diagonal[i] = matrix[i, i];
            }
            
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1 - i; j++)
                {
                    if (diagonal[j] > diagonal[j + 1])
                    {
                        int temp = diagonal[j];
                        diagonal[j] = diagonal[j + 1];
                        diagonal[j + 1] = temp;
                    }
                }
            }
            
            for (int i = 0; i < size; i++)
            {
                matrix[i, i] = diagonal[i];
            }
        }

        public void SortDiagonalDescending(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
                return;

            int size = matrix.GetLength(0);
            int[] diagonal = new int[size];
            
            for (int i = 0; i < size; i++)
            {
                diagonal[i] = matrix[i, i];
            }
            
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1 - i; j++)
                {
                    if (diagonal[j] < diagonal[j + 1])
                    {
                        int temp = diagonal[j];
                        diagonal[j] = diagonal[j + 1];
                        diagonal[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < size; i++)
            {
                matrix[i, i] = diagonal[i];
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
            if (v <= 0 && a <= 0)
                return 0;
    
            double totalDistance = 0;
            int hours = 0;
    
            while (totalDistance < 100)
            {
                double speedThisHour = v + a * hours;
                
                if (speedThisHour <= 0)
                    return 0;
                
                totalDistance += speedThisHour;
                hours++;
                
                if (hours > 10000)
                    return 0;
            }
            
            return hours;
        }
        public delegate void Swapper(int[] array);
        public void SwapFromLeft(int[] array)
        {
            for (int i = 0; i <  array.Length - 1; i+=2)
            {
                (array[i], array[i + 1]) = (array[i + 1], array[i]);
            }
        }
        public void SwapFromRight(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i -= 2)
            {
                (array[i], array[i - 1]) = (array[i - 1], array[i]);
            }
        }
        public int GetSum(int[] array)
        {
            int sum = 0;
            for (int i = 1; i < array.Length; i+=2)
            {
                sum += array[i];
            }
            return sum;
        }
        public int Task9(int[][] array)
        {
            int answer = 0;

            // code here
            
            Swapper operation;
            if (array.Length %2 == 0)
            {
                operation = SwapFromLeft;
            }
            else
            {
                operation = SwapFromRight;
            }
            for (int i = 0; i < array.Length; i++)
            {
                operation(array[i]);
                answer += GetSum(array[i]);
            }
            
            // end
    
            return answer;
        }
        
        public delegate int Func(int[][] array);
        public int CountPositive(int[][]array)
        {
            int countPos = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0;  j < array[i].Length; j++)
                {
                    if (array[i][j] > 0)
                    {
                        countPos++;
                    }
                }
            }
            return countPos;
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
        public int FindMaxRowLength(int[][]array)
        {
            int maxrow = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length > maxrow)
                {
                    maxrow = array[i].Length;
                }
            }
            return maxrow;
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
