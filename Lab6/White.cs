using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class White
    {
        public void Task1(double[] A, double[] B)
        {
            int maxIndexA = FindMaxIndex(A);
            int maxIndexB = FindMaxIndex(B);

            int elementsA = A.Length - 1 - maxIndexA; 
            int elementsB = B.Length - 1 - maxIndexB;

            
            bool modifyA = (elementsA >= elementsB); 

            if (modifyA)
            {
                if (elementsA == 0) return; 

                double sum = 0;
                for (int i = maxIndexA + 1; i < A.Length; i++)
                {
                    sum += A[i];
                }

                double promedio = sum / elementsA;
                A[maxIndexA] = promedio;
            }
            else
            {
                if (elementsB == 0) return;

                double sum = 0;
                for (int i = maxIndexB + 1; i < B.Length; i++)
                {
                    sum += B[i];
                }

                double promedio = sum / elementsB;
                B[maxIndexB] = promedio;
            }
        }

        public int FindMaxIndex(double[] array)
        {
            int maxIndex = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[maxIndex])
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }
        public void Task2(int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(0) != B.GetLength(0) || A.GetLength(1) != B.GetLength(1)) return;
            if (A.GetLength(1) <= 1) return;
            int maxIndexA = FindMaxRowIndexInColumn(A, 1);
            int maxIndexB = FindMaxRowIndexInColumn(B, 1);
            for ( int j = 0; j < A.GetLength(1); j++)
            {
                int firstnumA = A[maxIndexA, j];
                A[maxIndexA, j] = B[maxIndexB, j];
                B[maxIndexB, j] = firstnumA;

            }

            // end

        }
        public int FindMaxRowIndexInColumn(int[,] matrix, int col)
        {
            int indexRow = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > matrix[indexRow, col])
                {
                    indexRow = i;
                }
            }
            return indexRow;
        }
        public int Task3(int[,] matrix)
        {
            int answer = 0;

            // code here

            // end

            return answer;
        }
        public int[] GetNegativeCountPerRow(int[,] matrix)
        {
            int[] rows = new int[matrix.GetLength(0)];
            int temCount = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        temCount += 1;
                    }
                }
                rows[i] = temCount;
                temCount = 0;
            }
            return rows ;
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            int filaA, columnaA;
            int maximoA = FindMax(A, out filaA, out columnaA);
            int filaB, columnaB;
            int maximoB = FindMax(B, out filaB, out columnaB);
            A[filaA, columnaA] = maximoB;
            B[filaB, columnaB] = maximoA;
            // end

        }
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            int maxNum = matrix[0, 0];
            row = 0;
            col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxNum)
                    {
                        maxNum = matrix[i, j];
                        col = j;
                        row = i;
                    }
                }
            }
            return maxNum;
        }
        public void Task5(int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(0) != B.GetLength(0)) return;
            if (A.GetLength(1) == 0 || B.GetLength(1) == 0) return;
            int filaA, columnaA;
            int maxA = FindMax(A, out filaA, out columnaA);
            int filaB, columnaB;
            int maxB = FindMax(B, out filaB, out columnaB);

            SwapColumns(A, columnaA, B, columnaB);

            // end

        }
        public void SwapColumns(int[,] A, int colIndexA, int[,] B, int colIndexB)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                int firstnumA = A[i, colIndexA];
                A[i, colIndexA] = B[i, colIndexB];
                B[i, colIndexB] = firstnumA;
            }
        }
        public delegate void Sorting(int[,] matrix);
        public void Task6(int[,] matrix, Sorting sort)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;

            sort(matrix);
            // end

        }
        public void SortDiagonalAscending(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int[] diagonal = new int[n];
            for (int i = 0; i < diagonal.Length; i++)
            {
                diagonal[i] = matrix[i, i];
            }
            Array.Sort(diagonal);
            for (int i = 0; i < diagonal.Length; i++)
            {
                matrix[i, i] = diagonal[i];
            }
        }
        public void SortDiagonalDescending(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int[] diagonal = new int[n];
            for (int i = 0; i < diagonal.Length; i++)
            {
                diagonal[i] = matrix[i, i];
            }
            Array.Sort(diagonal);
            Array.Reverse(diagonal);
            for (int i = 0; i < diagonal.Length; i++)
            {
                matrix[i, i] = diagonal[i];
            }
        }

        public long Task7(int n, int k)
        {
            long answer = 0;

            // code here
            if (n < 0 || k < 0 || k > n)
                return 0;

            if (k == 0 || k == n)
                return 1;

            answer = Factorial(n) / (Factorial(k) * Factorial(n - k));
                // end

            return answer;
        }
        public long Factorial(int x)
        {
            long result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }   

            return result;
        }
    public delegate double BikeRide(double v, double a);

    public double Task8(double v, double a, BikeRide ride)
    {
        return ride(v, a);
    }

    public double GetDistance(double v, double a)
    {
        double distance = 0;
        double speed = v;

        for (int hour = 1; hour <= 10; hour++)
        {
            distance += speed;
            speed += a;
        }

        return distance;
    }

    public double GetTime(double v, double a)
    {
        double distance = 0;
        double speed = v;
        int hours = 0;

        while (distance < 100)
        {
            distance += speed;
            speed += a;
            hours++;
        }

        return hours;
    }
    public delegate void Swapper(double[] array);

    public int Task9(int[][] array)
    {
        if (array == null) return 0;

        Swapper swapper = (array.Length % 2 == 0) ? SwapFromLeft : SwapFromRight;


        for (int r = 0; r < array.Length; r++)
        {
            if (array[r] == null || array[r].Length <= 1) continue;


            double[] temp = new double[array[r].Length];
            for (int i = 0; i < array[r].Length; i++)
                temp[i] = array[r][i];

            swapper(temp);


            for (int i = 0; i < array[r].Length; i++)
                array[r][i] = (int)temp[i];
        }

        long totalSum = 0;
        long evenSum = 0;

        for (int r = 0; r < array.Length; r++)
        {
            if (array[r] == null || array[r].Length == 0) continue;

            double[] temp = new double[array[r].Length];
            for (int i = 0; i < array[r].Length; i++)
            {
                temp[i] = array[r][i];
                totalSum += array[r][i];
            }

            evenSum += (long)Sum(temp); 
        }

        long oddSum = totalSum - evenSum;
        return (int)oddSum;
    }

    public double Sum(double[] array)
    {
        if (array == null) return 0;

        double sum = 0;
        for (int i = 0; i < array.Length; i += 2)
            sum += array[i];

        return sum;
    }

    public void SwapFromLeft(double[] array)
    {
        if (array == null) return;

        for (int i = 0; i + 1 < array.Length; i += 2)
        {
            double t = array[i];
            array[i] = array[i + 1];
            array[i + 1] = t;
        }
    }

    public void SwapFromRight(double[] array)
    {
        if (array == null) return;

        for (int i = array.Length - 1; i - 1 >= 0; i -= 2)
        {
            double t = array[i];
            array[i] = array[i - 1];
            array[i - 1] = t;
        }
    }
public int Task10(int[][] array, Func<int[][], int> func)
    {
        if (array == null || func == null) return 0;
        return func(array);
    }

    public int CountPositive(int[][] array)
    {
        if (array == null) return 0;

        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == null) continue;

            for (int j = 0; j < array[i].Length; j++)
            {
                if (array[i][j] > 0)
                    count++;
            }
        }
        return count;
    }

    public int FindMax(int[][] array)
    {
        if (array == null || array.Length == 0) return 0;

        int max = 0;
        bool initialized = false;

        for (int i = 0; i < array.Length && !initialized; i++)
        {
            if (array[i] != null && array[i].Length > 0)
            {
                max = array[i][0];
                initialized = true;
            }
        }

        if (!initialized) return 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == null) continue;

            for (int j = 0; j < array[i].Length; j++)
            {
                if (array[i][j] > max)
                    max = array[i][j];
            }
        }

        return max;
    }

    public int FindMaxRowLength(int[][] array)
    {
        if (array == null) return 0;

        int maxLen = 0;
        for (int i = 0; i < array.Length; i++)
        {
            int len = (array[i] == null) ? 0 : array[i].Length;
            if (len > maxLen)
                maxLen = len;
        }
        return maxLen;
    }
    }
}
