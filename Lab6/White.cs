using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Schema;

namespace Lab6
{
    public class White
    {
        public int FindMaxIndex(double[] array)
        {
            double arrayMax = array[0];
            int imax = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > arrayMax)
                {
                    arrayMax = array[i];
                    imax = i;
                }
            }
            return imax;
        }
        public void Task1(double[] A, double[] B)
        {

            // code here
            double Amax = 0;
            double Bmax = 0;
            int iAmax =  FindMaxIndex(A);
            int iBmax = FindMaxIndex(B);
            int distA = A.Length - 1 - iAmax;
            int distB = B.Length - 1 - iBmax;
            if (distA == 0 && distB == 0)
            {
                return;
            }
            if(distA >= distB)
            {
                if(distA == 0)
                {
                    return;
                }
                double sum = 0;
                double sr = 0;
                int count = 0;
                for (int i = iAmax + 1; i < A.Length; i++)
                {
                    count++;
                    sum += A[i];
                    sr = sum / count;
                }
                A[iAmax] = sr;
            }
            else
            {
                if(distB == 0)
                {
                    return;
                }
                double sum = 0;
                double sr = 0;
                int count = 0;
                for (int i = iBmax + 1; i < B.Length; i++)
                {
                    sum += B[i];
                    count++;
                    sr = sum / count;
                }
                B[iBmax] = sr;
            }
            // end

        }
        public int FindMaxRowIndexInColumn(int[,] matrix, int col)
        {
            int maxEl = matrix[0, 0];
            int imaxEl = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                if(matrix[i, col] > maxEl)
                {
                    maxEl = matrix[i, col];
                    imaxEl = i;
                }
            }
            return imaxEl;
        }
        public void Task2(int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(0) != B.GetLength(0) || A.GetLength(1) != B.GetLength(1))
            {
                return;
            }
            int MaxRowA = FindMaxRowIndexInColumn(A, 0);
            int MaxRowB = FindMaxRowIndexInColumn(B, 0);
            for (int j = 0; j < B.GetLength(1); j++)
            {
                (A[MaxRowA, j], B[MaxRowB, j]) = (B[MaxRowB, j], A[MaxRowA, j]);
            }
            // end

        }
        public int[] GetNegativeCountPerRow(int[,] matrix)
        {
            int[] negative = new int[matrix.GetLength(0)];
            for(int i = 0;i < matrix.GetLength(0); i++)
            {
                int rowNeg = 0;
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        rowNeg++;
                    }
                    negative[i] = rowNeg;
                }
                
            }
            return negative;
        }
        public int Task3(int[,] matrix)
        {
            int answer = 0;
            
            // code here
            int[] result = GetNegativeCountPerRow(matrix);
            int imax = 0;
            for(int i = 0; i < result.Length; i++)
            {
                if (result[i] > imax)
                {
                    imax = result[i];
                    answer = i;
                }
            }
            // end

            return answer;
        }
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0; col = 0;
            int maxEl = matrix[0, 0];
            
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0;j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxEl)
                    {
                        maxEl = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            return maxEl;
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            int maxA = FindMax(A, out int rowA, out int colA);
            int maxB = FindMax(B, out int rowB, out int colB);
            (A[rowA, colA], B[rowB,colB]) = ( B[rowB, colB], A[rowA, colA]);
            // end

        }
        public void SwapColumns(int[,] A, int colIndexA, int[,] B, int colIndexB)
        {
            for(int i = 0; i <  A.GetLength(0); i++)
            {
                (A[i, colIndexA], B[i, colIndexB]) = (B[i, colIndexB], A[i, colIndexA]);
            }
        }
        public void Task5(int[,] A, int[,] B)
        {

            // code here
            if(A.GetLength(0) != B.GetLength(0))
            {
                return;
            }
            FindMax(A, out int rowA, out int colA);
            FindMax(B, out int rowB,out int colB);
            SwapColumns(A, colA, B, colB);
            // end

        }
        public delegate void Sorting(int[,] matrix);
        public void SortDiagonalAscending(int[,] matrix)
        {
            
            int[] array = new int[matrix.GetLength(0)];
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                    array[i] = matrix[i, i];
            }
            Array.Sort(array);
            for(int i = 0; i < array.Length; i++)
            {
                matrix[i, i] = array[i];
            }
            
        }
        public void SortDiagonalDescending(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)];
            for (int i = 0;i < matrix.GetLength(0); i++)
            {
                array[i] = matrix[i, i];
            }
            Array.Sort(array);
            Array.Reverse(array);
            for (int i = 0; i < array.Length; i++)
            {
               matrix[i, i] = array[i];
            }
        }
        public void Task6(int[,] matrix, Sorting sort)
        {

            // code here
            if(matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            sort(matrix);
            // end

        }
        public long Factorial(int n)
        {
            if(n <= 1)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }
        public long Task7(int n, int k)
        {
            long answer = 0;

            // code here
            answer = (int) (Factorial(n)/ (Factorial(k) * Factorial(n - k)));
            // end

            return answer;
        }
        public delegate double BikeRide(double v, double a);
        public double GetDistance(double v, double a)
        {
            double dist = 0;
            for(int hour = 0; hour < 10; hour++)
            {
                dist += v;
                v += a;
            }
            return dist;

        }
        public double GetTime(double v, double a)
        {
            double dist = 0;
            double time = 0;
            while(dist < 100)
            {
                dist += v;
                v += a;
                time++;
            }
            return time;
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
        public double Sum(double[] array)
        {
            double sum = 0;
            for (int i = 1; i < array.Length; i += 2)
            {
                sum += array[i];
            }
            return sum;
        }
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
            if(array.Length == 0)
            {
                return;
            }
            for(int i = 0;i < array.Length - 1; i += 2)
            {
              
                    (array[i], array[i + 1]) = (array[i + 1], array[i]);
            }
        }
        public void SwapFromRight(int[] array)
        {
            if(array.Length == 0)
            {
                return;
            }
            for( int i = array.Length - 1; i > 0; i -= 2)
            {
                (array[i], array[i - 1]) = (array[i - 1], array[i]);
            }
        }
        public int Task9(int[][] array)
        {
            int answer = 0;

            // code here

            Swapper swapper;
            if (array.Length % 2 == 0)
            {
                swapper = SwapFromLeft;
            }
            else
            {
                swapper = SwapFromRight;
            }

            for (int i = 0; i < array.Length; i++)
            {
                int[] ARRAY = new int[array[i].Length];
                for (int j = 0; j < array[i].Length; j++)
                {
                    ARRAY[j] = array[i][j];
                }
                swapper(ARRAY);

                answer += GetSum(ARRAY);
            }


            // end

            return answer;
        }
        public int CountPositive(int[][] array)
        {
            int count = 0;
            for(int i = 0; i < array.Length; i++)
            {
                for( int j = 0; j < array[i].Length; j++)
                {
                    if( array[i][j] > 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public int FindMax(int[][] array)
        {
            int maxEl = array[0][0];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > maxEl)
                    {
                        maxEl = array[i][j];
                    }
                }
            }
            return maxEl;
        }
        public int FindMaxRowLength(int[][] array)
        {
            int maxLength = 0;
            for(int i = 0; i < array.Length; i++)
            {
                int Length = array[i].Length;
                if( Length > maxLength)
                {
                    maxLength = Length;
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