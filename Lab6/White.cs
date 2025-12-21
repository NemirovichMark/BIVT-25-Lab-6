using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class White
    {
        public int FindMaxIndex(double[] array)
        {
            int index = 0;
            for (int i = 1; i < array.Length; i++) if (array[i] > array[index]) index = i;
            return index;
        }
        public void Task1(double[] A, double[] B)
        {

            int q = FindMaxIndex(A),w = FindMaxIndex(B);
            int distA = A.Length - 1 - q,distB = B.Length - 1 - w;
            double[] t;
            int index = 0;
            if (distA >= distB) {
                t = A;
                index = q;
            }
            else {
                t = B;
                index = w;
            }
            if (index == t.Length - 1) return;
            double s = 0;
            int x = 0;
            for (int i = index + 1; i < t.Length; i++)
            {
                s += t[i];
                x++;
            }
            t[index] = s / x;
        }
        public int FindMaxRowIndexInColumn(int[,] matrix, int col)
        {
            int row = 0;

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > matrix[row, col])
                {
                    row = i;
                }
            }

            return row;
        }
        public void Task2(int[,] A, int[,] B)
        {
            if (A.GetLength(0) != B.GetLength(0) || A.GetLength(1) != B.GetLength(1)) return;
            int q = FindMaxRowIndexInColumn(A, 0);
            int w = FindMaxRowIndexInColumn(B, 0);
            for (int j = 0; j < A.GetLength(1); j++)  (A[q, j], B[w, j]) = (B[w, j], A[q, j]);
        }
        public int[] GetNegativeCountPerRow(int[,] matrix)
        {
            int rows = matrix.GetLength(0),cols = matrix.GetLength(1);
            int[] result = new int[rows];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (matrix[i, j] < 0) result[i]++;
            return result;
        }
        public int Task3(int[,] matrix)
        {
            int answer = 0;
            int[] counts = GetNegativeCountPerRow(matrix);
            for (int i = 1; i < counts.Length; i++)
                if (counts[i] > counts[answer]) answer = i;
            return answer;
        }
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            int maxs = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    if (matrix[i, j] > maxs) {
                        maxs = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            return maxs;
        }
        public void Task4(int[,] A, int[,] B)
        {
            FindMax(A, out int rA, out int cA);
            FindMax(B, out int rB, out int cB);
            (A[rA, cA], B[rB, cB]) = (B[rB, cB], A[rA, cA]);
        }
        public void SwapColumns(int[,] A, int colA, int[,] B, int colB)
        {
            for (int i = 0; i < A.GetLength(0); i++) (A[i, colA], B[i, colB]) = (B[i, colB], A[i, colA]);
        }
        public void Task5(int[,] A, int[,] B)
        {

            if (A.GetLength(0) != B.GetLength(0)) return;
            FindMax(A, out int rowA, out int colA);
            FindMax(B, out int rowB, out int colB);
            SwapColumns(A, colA, B, colB);
        }
        public delegate void Sorting(int[,] matrix);
        public void SortDiagonalAscending(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int[] x = new int[n];

            for (int i = 0; i < n; i++) x[i] = matrix[i, i];
            

            Array.Sort(x);

            for (int i = 0; i < n; i++)
            {
                matrix[i, i] = x[i];
            }
        }
        public void SortDiagonalDescending(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int[] x = new int[n];
            for (int i = 0; i < n; i++) x[i] = matrix[i, i];
            Array.Sort(x);
            Array.Reverse(x);
            for (int i = 0; i < n; i++)  matrix[i, i] = x[i];
        }
        public void Task6(int[,] matrix, Sorting sort)
        {

            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            sort(matrix);
        }
        public long Factorial(int n)
        {
            if (n <= 1) return 1;
            return n * Factorial(n - 1);
        }
        public long Task7(int n, int k)
        {
            long q = 0;
            q = Factorial(n) / (Factorial(k) * Factorial(n - k));
            return q;
        }
        public delegate double BikeRide(double v, double a);
        public double GetDistance(double v, double a)
        {
            double s = 0;
            for (int i = 0; i < 10; i++) s += v + a * i;
            return s;
        }
        public double GetTime(double v, double a)
        {
            double s = 0;
            int t = 0;
            while (s < 100)
            {
                s += v + a * t;
                t++;
            }
            return t;
        }
        public double Task8(double v, double a, BikeRide ride)
        {
            double q = 0;
            q = ride(v, a);
            return q;
        }
        public delegate void Swapper(double[] array);
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
        public void SwapFromLeft(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i += 2)
            {
                int temp = array[i];
                array[i] = array[i + 1];
                array[i + 1] = temp;
            }
        }
        public void SwapFromRight(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i -= 2)
            {
                int t = array[i];
                array[i] = array[i - 1];
                array[i - 1] = t;
            }
        }
        public double Sum(double[] array)
        {
            double sum = 0;
            for (int i = 1; i < array.Length; i += 2) sum += array[i];
            return sum;
        }
        public int Task9(int[][] array)
        {
            int x = 0;
            bool isEvenRowCount = array.Length % 2 == 0;

            Swapper swapper;
            if (isEvenRowCount) swapper = SwapFromLeft;
                           else swapper = SwapFromRight;

            for (int row = 0; row < array.Length; row++)
            {
                double[] doubleRow = new double[array[row].Length];
                for (int col = 0; col < array[row].Length; col++)
                {
                    doubleRow[col] = array[row][col];
                }

                swapper(doubleRow);

                x += (int)Sum(doubleRow);
            }

            return x;
        }
        public int CountPositive(int[][] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[i].Length; j++)
                    if (array[i][j] > 0) count++; 
            return count;
        }
        public int FindMax(int[][] array)
        {
            int max = int.MinValue;
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[i].Length; j++) 
                    if (array[i][j] > max) max = array[i][j];
            return max;
        }
        public int FindMaxRowLength(int[][] array)
        {
            int maxLen = 0;
            for (int i = 0; i < array.Length; i++) if (array[i].Length > maxLen) maxLen = array[i].Length;
            return maxLen;
        }
        public int Task10(int[][] array, Func<int[][], int> func)
        {
            int x = 0;
            x = func(array);
            return x;
        }
        public int GetSum(int[] array)
        {
            int s = 0;
            for (int i = 1; i < array.Length; i += 2) s += array[i];
            return s;
        }
    }
}
