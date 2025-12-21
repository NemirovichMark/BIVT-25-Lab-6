using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class White
    {
        public int FindMaxIndex(double[] array)
        {
            double mx = int.MinValue; int imax = -1; 
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > mx)
                {
                    mx = array[i];
                    imax = i;
                }
            }
            return imax;
        }
        public void Task1(double[] A, double[] B)
        {

            // code here
            int imaxA = FindMaxIndex(A);
            int imaxB = FindMaxIndex(B);
            double sum = 0; int count = 0; double sred = 0;
            if ((A.Length - imaxA) >= (B.Length - imaxB))
            {
                for (int i = imaxA + 1; i < A.Length; i++)
                {
                    count = A.Length - (imaxA+1);
                    sum += A[i];
                }
                sred = sum/count;
                A[imaxA] = sred;
            }
            else
            {
                for (int i = imaxB + 1; i < B.Length; i++)
                {
                    count = B.Length - (imaxB + 1);
                    sum += B[i];
                }
                sred = sum / count;
                B[imaxB] = sred;
            }
            
            // end
            
        }
        public int FindMaxRowIndexInColumn(int[,] matrix, int col)
        {
            int mx = int.MinValue; int icol = -1;
            for (int i = 0;  i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > mx)
                {
                    mx = matrix[i, col];
                    icol = i;
                }
            }
            return icol;
        }
        public void Task2(int[,] A, int[,] B)
        {

            // code here
            int rowA = FindMaxRowIndexInColumn(A,0); int rowB = FindMaxRowIndexInColumn(B,0);
            if ((A.GetLength(0) == B.GetLength(0)) && (A.GetLength(1) == B.GetLength(1)))
            {
                for (int i =0;  i < A.GetLength(1); i++)
                {
                    (A[rowA, i], B[rowB, i]) = (B[rowB, i], A[rowA, i]);
                }
            }
            // end

        }
        public int[] GetNegativeCountPerRow(int[,] matrix)
        {
            int count = 0;
            int[] array = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
                array[i] = count;
                count = 0;
            }
            return array;
        }
        public int Task3(int[,] matrix)
        {
            int answer = 0;

            // code here
            int[] array = GetNegativeCountPerRow(matrix);
            int mx = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (array[i] > mx)
                {
                    mx = array[i];
                    answer = i;
                }
            }
            // end

            return answer;
        }
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0; col = 0;
            int mx = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > mx)
                    {
                        mx = matrix[i,j];
                        row = i; col = j;
                    }
                }
            }
            return mx;
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            int maxA = FindMax(A, out int rowA, out int colA);
            int maxB = FindMax(B, out int rowB, out int colB);
            A[rowA,colA] = maxB;
            B[rowB,colB] = maxA;
            // end

        }
        public void SwapColumns(int[,] A, int colIndexA, int[,] B, int colIndexB)
        {
            for (int i = 0; i < A.GetLength(0);i++)
            {
                (A[i, colIndexA], B[i, colIndexB]) = (B[i, colIndexB], A[i, colIndexA]);
            }
        }
            
        public void Task5(int[,] A, int[,] B)
        {

            // code here
            int maxA = FindMax(A, out int rowA, out int colA);
            int maxB = FindMax(B, out int rowB, out int colB);
            if (A.GetLength(0) == B.GetLength(0))
            {
                SwapColumns(A,colA, B, colB);
            }
            // end

        }
        public delegate void Sorting(int[,] matrix);
        public void SortDiagonalAscending(int[,] matrix)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i - 1, i - 1] > matrix[i, i])
                    {
                        (matrix[i - 1, i - 1], matrix[i, i]) = (matrix[i, i], matrix[i - 1, i - 1]);
                    }
                }
            }
        }
        public void SortDiagonalDescending(int[,] matrix)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i - 1, i - 1] < matrix[i, i])
                    {
                        (matrix[i - 1, i - 1], matrix[i, i]) = (matrix[i, i], matrix[i - 1, i - 1]);
                    }
                }
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
        public long Factorial(long n)
        {
            if (n <= 1) return 1;
            return n * Factorial(n-1);
        }
        public long Task7(int n, int k)
        {
            long answer = 0;

            // code here
            answer = Factorial(n) / Factorial(n-k) / Factorial(k);
            // end

            return answer;
        }
        public delegate double BikeRide(double v, double a);
        public double GetDistance(double v, double a)
        {
            double t = 10;
            double S = 5 * (2 * v + 9 * a);
            return S;
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
