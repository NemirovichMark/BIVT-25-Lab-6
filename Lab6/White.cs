using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class White
    {
        public void Task1(double[] A, double[] B)
        {

            // code here
            int maxIndexA = 0;
            for (int i = 1; i < A.Length; i++)
                if (A[i] > A[maxIndexA])
                    maxIndexA = i;

            int maxIndexB = 0;
            for (int i = 1; i < B.Length; i++)
                if (B[i] > B[maxIndexB])
                    maxIndexB = i;

            int distanceA = A.Length - 1 - maxIndexA;
            int distanceB = B.Length - 1 - maxIndexB;

            double[] targetArray;
            int targetMaxIndex;

            if (distanceA > distanceB || distanceA == distanceB)
            {
                targetArray = A;
                targetMaxIndex = maxIndexA;
            }
            else
            {
                targetArray = B;
                targetMaxIndex = maxIndexB;
            }

            if (targetMaxIndex == targetArray.Length - 1)
                return;

            double sum = 0;
            int count = 0;
            for (int i = targetMaxIndex + 1; i < targetArray.Length; i++)
            {
                sum += targetArray[i];
                count++;
            }

            targetArray[targetMaxIndex] = sum / count;
            // end

        }
        public void Task2(int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(0) != B.GetLength(0) || A.GetLength(1) != B.GetLength(1))
                return;

            
            int maxRowA = 0;
            for (int i = 1; i < A.GetLength(0); i++)
                if (A[i, 0] > A[maxRowA, 0])
                    maxRowA = i;

            int maxRowB = 0;
            for (int i = 1; i < B.GetLength(0); i++)
                if (B[i, 0] > B[maxRowB, 0])
                    maxRowB = i;

            
            for (int j = 0; j < A.GetLength(1); j++)
            {
                int temp = A[maxRowA, j];
                A[maxRowA, j] = B[maxRowB, j];
                B[maxRowB, j] = temp;
            }
            // end

        }

        public int[] ng(int[,] matrix)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            int[] nr = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        nr[i]++;
                    }
                }
            }
            return nr;
        }
        public int Task3(int[,] matrix)
        {
            int answer = 0;

            // code here
            int count = -1;
            int[] negativeData = ng(matrix);
            int maxStr = negativeData.Max();
            answer = Array.IndexOf(negativeData, maxStr);
            // end

            return answer;
        }
        public int fmax(int[,] matrix, out int row, out int col)
        {
            row = 0; col = 0;
            int maxValue = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        row = i; col = j;
                        maxValue = matrix[i, j];
                    }
                }
            }
            return maxValue;
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            int rowA, rowB, colA, colB;
            int maxA = fmax(A, out rowA, out colA);
            int maxB = fmax(B, out rowB, out colB);
            A[rowA, colA] = maxB;
            B[rowB, colB] = maxA;
            // end

        }
        public int FMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[row, col])
                    {
                        row = i;
                        col = j;
                    }
                }
            }

            return matrix[row, col];
        }

        public void SColumns(int[,] A, int colIndexA, int[,] B, int colIndexB)
        {
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
            if (A.GetLength(0) != B.GetLength(0))
                return;

            int rowA, colA;
            FMax(A, out rowA, out colA);

            int rowB, colB;
            FMax(B, out rowB, out colB);

            SColumns(A, colA, B, colB);
            // end

        }
        public delegate void Sorting(int[,] matrix);
        public void diagonalascending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] diagonal = new int[rows];
            if (rows == cols)
            {
                for (int i = 0; i < rows; i++)
                {
                    diagonal[i] = matrix[i, i];
                }
                for (int i = 0; i < rows - 1; i++)
                {
                    for (int j = 0; j < rows - i - 1; j++)
                    {
                        if (diagonal[j] > diagonal[j + 1])
                        {
                            int temp = diagonal[j];
                            diagonal[j] = diagonal[j + 1];
                            diagonal[j + 1] = temp;
                        }
                    }
                }
                for (int i = 0; i < rows; i++)
                {
                    matrix[i, i] = diagonal[i];
                }
            }
        }

        public void diagonaldescending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] diagonal = new int[rows];
            if (rows == cols)
            {
                for (int i = 0; i < rows; i++)
                {
                    diagonal[i] = matrix[i, i];
                }
                for (int i = 0; i < rows - 1; i++)
                {
                    for (int j = 0; j < rows - i - 1; j++)
                    {
                        if (diagonal[j] < diagonal[j + 1])
                        {
                            int temp = diagonal[j];
                            diagonal[j] = diagonal[j + 1];
                            diagonal[j + 1] = temp;
                        }
                    }
                }
                for (int i = 0; i < rows; i++)
                {
                    matrix[i, i] = diagonal[i];
                }
            }
        }
        public void Task6(int[,] matrix, Sorting sort)
        {

            // code here
            int n = matrix.GetLength(0);

            
            int[] diagonal = new int[n];
            for (int i = 0; i < n; i++)
                diagonal[i] = matrix[i, i];

            
            if (sort == diagonalascending)
            {
                
                for (int i = 0; i < n - 1; i++)
                    for (int j = 0; j < n - 1 - i; j++)
                        if (diagonal[j] > diagonal[j + 1])
                        {
                            int temp = diagonal[j];
                            diagonal[j] = diagonal[j + 1];
                            diagonal[j + 1] = temp;
                        }
            }
            else if (sort == diagonaldescending)
            {
                
                for (int i = 0; i < n - 1; i++)
                    for (int j = 0; j < n - 1 - i; j++)
                        if (diagonal[j] < diagonal[j + 1])
                        {
                            int temp = diagonal[j];
                            diagonal[j] = diagonal[j + 1];
                            diagonal[j + 1] = temp;
                        }
            }

            
            for (int i = 0; i < n; i++)
                matrix[i, i] = diagonal[i];
            // end

        }

        public long fact(int n)
        {
            if (n <= 1) return 1;
            else
                return n * fact(n - 1);
        }
        public long Task7(int n, int k)
        {
            long answer = 0;

            // code here
            if (n >= k)
            {
                answer = fact(n) / (fact(k) * fact(n - k));
            }
            else
                answer = 0;
            // end

            return answer;
        }
        public delegate double BikeRide(double v, double a);
        public double GetDistance(double v, double a)
        {
            int time = 10;
            double dist = 0;
            for (int i = 0; i < time; i++)
            {
                dist += v;
                v += a;
            }
            return dist;
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
        public delegate void Swapper(double[] array);
        public double Sum(double[] array)
        {
            double sum = 0;
            for (int i = 1; i < array.Length; i += 2)
            {
                sum += array[i];
            }
            return sum;
        }

        public void Left(double[] array)
        {
            for (int i = 0; i < array.Length - 1; i += 2)
            {
                double temp = array[i];
                array[i] = array[i + 1];
                array[i + 1] = temp;
            }
        }

        public void Right(double[] array)
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
            double totalSum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                double[] doubleArray = Array.ConvertAll(array[i], x => (double)x);

                if (array.Length % 2 == 0)
                {
                    Left(doubleArray);
                }
                else
                {
                    Right(doubleArray);
                }

                totalSum += Sum(doubleArray);
            }

            // end

            return (int)totalSum;
        }
        public delegate int Func(int[][] array); 
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