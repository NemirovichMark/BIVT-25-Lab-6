using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class White
    {
        public void Task1(double[] A, double[] B)
        {

            // code here
            int imaxA = FindMaxIndex(A);
            int imaxB = FindMaxIndex(B);
            if (imaxA != A.Length - 1 && imaxB != B.Length - 1)
            {
                if (A.Length - 1 - imaxA >= B.Length - 1 - imaxB)
                {
                    double tb = 0;
                    int count = 0;
                    for (int i = imaxA + 1; i < A.Length; i++)
                    {
                        tb += A[i];
                        count++;
                    }

                    tb = tb / count;
                    A[imaxA] = tb;
                }
                else
                {
                    double tb = 0;
                    int count = 0;
                    for (int i = imaxB + 1; i < B.Length; i++)
                    {
                        tb += B[i];
                        count++;
                    }

                    tb = tb / count;
                    B[imaxB] = tb;
                }
            }
            else if (imaxA != A.Length - 1)
            {
                double tb = 0;
                int count = 0;
                for (int i = imaxA + 1; i < A.Length; i++)
                {
                    tb += A[i];
                    count++;
                }

                tb = tb / count;
                A[imaxA] = tb;
            }
            else if (imaxB != B.Length - 1)
            {
                double tb = 0;
                int count = 0;
                for (int i = imaxB + 1; i < B.Length; i++)
                {
                    tb += B[i];
                    count++;
                }

                tb = tb / count;
                B[imaxB] = tb;
            }
            // end

        }

        public int FindMaxIndex(double[] array)
        {
            int imax = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[imax])
                {
                    imax = i;
                }
            }

            return imax;
        }
        public void Task2(int[,] A, int[,] B)
        {

            // code here

            if (A.GetLength(1) == B.GetLength(1))
            {
                int imaxA = FindMaxRowIndexInColumn(A, 0);
                int imaxB = FindMaxRowIndexInColumn(B, 0);
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    int tmp = A[imaxA, j];
                    A[imaxA, j] = B[imaxB, j];
                    B[imaxB, j] = tmp;
                }
            }
            // end

        }

        public int FindMaxRowIndexInColumn(int[,] matrix, int col)
        {
            int imax = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > matrix[imax, col])
                {
                    imax = i;
                }
            }

            return imax;
        }
        public int Task3(int[,] matrix)
        {
            int answer = 0;

            // code here
            int[] array = GetNegativeCountPerRow(matrix);
            int imax = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[imax])
                {
                    imax = i;
                }
            }

            answer = imax;
            // end

            return answer;
        }

        public int[] GetNegativeCountPerRow(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }

                array[i] = count;
            }

            return array;
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here

            int max_elemA, rowA, colA;
            max_elemA = FindMax(A, out rowA, out colA);
            int max_elemB, rowB, colB;
            max_elemB = FindMax(B, out rowB, out colB);
            if (rowA != -1 && colA != -1 && rowB != -1 && colB != -1)
            {
                int tmp = A[rowA, colA];
                A[rowA, colA] = B[rowB, colB];
                B[rowB, colB] = tmp;
            }
            // end

        }

        public int FindMax(int[,] matrix, out int row, out int col)
        {
            int max_elem = int.MinValue;
            row = -1;
            col = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max_elem)
                    {
                        max_elem = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            return max_elem;
        }
        public void Task5(int[,] A, int[,] B)
        {

            // code here

            if (A.GetLength(0) == B.GetLength(0))
            {
                int max_elemA = int.MinValue, rowA, colA;
                max_elemA = FindMax(A, out rowA, out colA);
                int max_elemB = int.MinValue, rowB, colB;
                max_elemB = FindMax(B, out rowB, out colB);
                SwapColumns(A, colA, B, colB);
            }
            // end

        }

        public void SwapColumns(int[,] A, int colIndexA, int[,] B, int colIndexB)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                int tmp = A[i, colIndexA];
                A[i, colIndexA] = B[i, colIndexB];
                B[i, colIndexB] = tmp;
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
            int i = 0;
            while (i < matrix.GetLength(0))
            {
                if (i == 0 || matrix[i, i] >= matrix[i - 1, i - 1])
                {
                    i++;
                }
                else
                {
                    int tmp = matrix[i, i];
                    matrix[i, i] = matrix[i - 1, i - 1];
                    matrix[i - 1, i - 1] = tmp;
                    i--;
                }
            }
        }

        public void SortDiagonalDescending(int[,] matrix)
        {
            int i = 0;
            while (i < matrix.GetLength(0))
            {
                if (i == 0 || matrix[i, i] <= matrix[i - 1, i - 1])
                {
                    i++;
                }
                else
                {
                    int tmp = matrix[i, i];
                    matrix[i, i] = matrix[i - 1, i - 1];
                    matrix[i - 1, i - 1] = tmp;
                    i--;
                }
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
            if (n <= 1) return 1;
            return n * Factorial(n - 1);
        }
        public double Task8(double v, double a, BikeRide ride)
        {
            double answer = 0;

            // code here

            answer = ride(v, a);
            // end

            return answer;
        }

        public delegate double BikeRide(double v, double a);

        public double GetDistance(double v, double a)
        {
            double s = 0;
            double gt = 0;
            for (int i = 1; i <= 10; i++)
            {
                s += v + gt;
                gt += a;
            }

            return s;
        }

        public double GetTime(double v, double a)
        {
            double s = 0, gt = 0;
            double t = 0;
            while (s < 100)
            {
                s += v + gt;
                t++;
                gt += a;
            }

            return t;
        }
        public int Task9(int[][] array)
        {
            int answer = 0;

            // code here
            Swapper swap = (array.Length % 2 == 0) ? SwapFromLeft : SwapFromRight;
            for (int i = 0; i < array.Length; i++)
            {
                swap(array[i]);
            }

            for (int i = 0; i < array.Length; i++)
            {
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
            for (int i = 0; i < array.Length - 1; i += 2)
            {
                int tmp = array[i];
                array[i] = array[i + 1];
                array[i + 1] = tmp;
            }
        }

        public void SwapFromRight(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i -= 2)
            {
                int tmp = array[i];
                array[i] = array[i - 1];
                array[i - 1] = tmp;
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
            int max_elem = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > max_elem)
                    {
                        max_elem = array[i][j];
                    }
                }
            }

            return max_elem;
        }

        public int FindMaxRowLength(int[][] array)
        {
            int max = array[0].Length;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].Length > max)
                {
                    max = array[i].Length;
                }
            }

            return max;
        }
    }
}

