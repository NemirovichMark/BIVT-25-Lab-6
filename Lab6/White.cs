using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public delegate void Sorting(int[,] matrix);
    public delegate double BikeRide(double v, double a);
    public delegate void Swapper(double[] array);
    public delegate int Func(int[][] array);

    public class White
    {
        public int FindMaxIndex(double[] array)
        {
            if (array == null || array.Length == 0) return -1;
            int maxIndex = 0;
            for (int i = 1; i < array.Length; i++)
                if (array[i] > array[maxIndex]) maxIndex = i;
            return maxIndex;
        }
        public void Task1(double[] A, double[] B)
        {

            // code here
            if (A == null || B == null || A.Length == 0 || B.Length == 0) return;

            int maxIndexA = FindMaxIndex(A);
            int maxIndexB = FindMaxIndex(B);
            int distanceA = A.Length - 1 - maxIndexA;
            int distanceB = B.Length - 1 - maxIndexB;

            if (distanceA == 0 && distanceB == 0) return;

            double[] targetArray;
            int targetIndex;

            if (distanceA > distanceB)
            {
                targetArray = A;
                targetIndex = maxIndexA;
            }
            else if (distanceB > distanceA)
            {
                targetArray = B;
                targetIndex = maxIndexB;
            }
            else
            {
                targetArray = A;
                targetIndex = maxIndexA;
            }

            if (targetIndex == targetArray.Length - 1) return;

            double sum = 0;
            int count = 0;
            for (int i = targetIndex + 1; i < targetArray.Length; i++)
            {
                sum += targetArray[i];
                count++;
            }

            if (count > 0) targetArray[targetIndex] = sum / count;
            // end

        }
        public int FindMaxRowIndexInColumn(int[,] matrix, int col)
        {
            if (matrix == null || col < 0 || col >= matrix.GetLength(1)) return -1;
            int maxRow = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
                if (matrix[i, col] > matrix[maxRow, col]) maxRow = i;
            return maxRow;
        }
        public void Task2(int[,] A, int[,] B)
        {

            // code here
            if (A == null || B == null) return;
            if (A.GetLength(0) != B.GetLength(0) || A.GetLength(1) != B.GetLength(1)) return;
            if (A.GetLength(1) == 0) return;

            int rowA = FindMaxRowIndexInColumn(A, 0);
            int rowB = FindMaxRowIndexInColumn(B, 0);
            if (rowA == -1 || rowB == -1) return;

            for (int j = 0; j < A.GetLength(1); j++)
            {
                int temp = A[rowA, j];
                A[rowA, j] = B[rowB, j];
                B[rowB, j] = temp;
            }
            // end

        }
        public int[] NegativeCountPerRow(int[,] matrix)
        {
            if (matrix == null) return new int[0];

            int rows = matrix.GetLength(0);
            int[] counts = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] < 0) count++;
                counts[i] = count;
            }
            return counts;
        }

        public int Task3(int[,] matrix)
        {
            int answer = 0;

            // code here
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) return -1;

            int[] counts = NegativeCountPerRow(matrix);
            int maxRow = 0;
            for (int i = 1; i < counts.Length; i++)
                if (counts[i] > counts[maxRow]) maxRow = i;
            answer = maxRow;
            // end

            return answer;
        }
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = -1; col = -1;
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) return 0;

            int max = matrix[0, 0];
            row = 0; col = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            return max;
        }

        public void Task4(int[,] A, int[,] B)
        {

            // code here
            if (A == null || B == null) return;

            int rowA, colA, rowB, colB;
            int maxA = FindMax(A, out rowA, out colA);
            int maxB = FindMax(B, out rowB, out colB);

            A[rowA, colA] = maxB;
            B[rowB, colB] = maxA;
            // end

        }
        public void SwapColumns(int[,] A, int colIndexA, int[,] B, int colIndexB)
        {
            if (A == null || B == null || A.GetLength(0) != B.GetLength(0)) return;
            if (colIndexA < 0 || colIndexA >= A.GetLength(1) || colIndexB < 0 || colIndexB >= B.GetLength(1)) return;

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
            if (A == null || B == null || A.GetLength(0) != B.GetLength(0)) return;

            int rowA, colA, rowB, colB;
            FindMax(A, out rowA, out colA);
            FindMax(B, out rowB, out colB);

            SwapColumns(A, colA, B, colB);
            // end

        }
        public void SortDiagonalAscending(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1)) return;

            int n = matrix.GetLength(0);
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (matrix[j, j] > matrix[j + 1, j + 1])
                    {
                        int temp = matrix[j, j];
                        matrix[j, j] = matrix[j + 1, j + 1];
                        matrix[j + 1, j + 1] = temp;
                    }
                }
            }
        }

        public void SortDiagonalDescending(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1)) return;

            int n = matrix.GetLength(0);
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (matrix[j, j] < matrix[j + 1, j + 1])
                    {
                        int temp = matrix[j, j];
                        matrix[j, j] = matrix[j + 1, j + 1];
                        matrix[j + 1, j + 1] = temp;
                    }
                }
            }
        }
        public void Task6(int[,] matrix, Sorting sort)
        {

            // code here
            if (matrix == null || sort == null) return;
            sort(matrix);
            // end

        }
        public long Factorial(int n)
        {
            if (n < 0) return 0;
            long result = 1;
            for (int i = 2; i <= n; i++) result *= i;
            return result;
        }

        public long Task7(int n, int k)
        {
            long answer = 0;

            // code here
            if (n < 0 || k < 0 || k > n) return 0;
            answer = Factorial(n) / (Factorial(k) * Factorial(n - k));
            // end

            return answer;
        }
        public double GetDistance(double v, double a)
        {
            double t = 10.0;
            return v * t + (a * t * t) / 2.0;
        }

        public double GetTime(double v, double a)
        {
            if (Math.Abs(a) < 0.000001)
            {
                if (Math.Abs(v) < 0.000001) return -1;
                return 100.0 / v;
            }

            double discriminant = v * v + 2 * a * 100;
            if (discriminant < 0) return -1;
            return (-v + Math.Sqrt(discriminant)) / a;
        }
        public double Task8(double v, double a, BikeRide ride)
        {
            double answer = 0;

            // code here
            if (ride == null) return 0;
            answer = ride(v, a);
            // end

            return answer;
        }
        public double Sum(double[] array)
        {
            if (array == null) return 0;
            double sum = 0;
            for (int i = 0; i < array.Length; i += 2) sum += array[i];
            return sum;
        }

        public void SwapFromLeft(double[] array)
        {
            if (array == null || array.Length < 2) return;
            for (int i = 0; i < array.Length - 1; i += 2)
            {
                double temp = array[i];
                array[i] = array[i + 1];
                array[i + 1] = temp;
            }
        }

        public void SwapFromRight(double[] array)
        {
            if (array == null || array.Length < 2) return;
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
            if (array == null || array.Length == 0) return 0;

            Swapper swapper = (array.Length % 2 == 0) ? SwapFromLeft : SwapFromRight;

            foreach (var subArray in array)
            {
                if (subArray != null && subArray.Length >= 2)
                {
                    double[] temp = new double[subArray.Length];
                    for (int i = 0; i < subArray.Length; i++) temp[i] = subArray[i];
                    swapper(temp);
                    for (int i = 0; i < subArray.Length; i++) subArray[i] = (int)temp[i];
                }
            }

            int totalSum = 0;
            foreach (var subArray in array)
            {
                if (subArray != null)
                {
                    for (int j = 1; j < subArray.Length; j += 2)
                        totalSum += subArray[j];
                }
            }
            answer = totalSum;
            // end

            return answer;
        }
        public int CountPositive(int[][] array)
        {
            if (array == null) return 0;
            int count = 0;
            foreach (var subArray in array)
            {
                if (subArray != null)
                {
                    foreach (var element in subArray)
                        if (element > 0) count++;
                }
            }
            return count;
        }

        public int FindMax(int[][] array)
        {
            if (array == null || array.Length == 0) return 0;
            int max = int.MinValue;
            bool found = false;
            foreach (var subArray in array)
            {
                if (subArray != null)
                {
                    foreach (var element in subArray)
                    {
                        if (element > max)
                        {
                            max = element;
                            found = true;
                        }
                    }
                }
            }
            return found ? max : 0;
        }

        public int FindMaxRowLength(int[][] array)
        {
            if (array == null || array.Length == 0) return 0;
            int maxLength = 0;
            foreach (var subArray in array)
                if (subArray != null && subArray.Length > maxLength)
                    maxLength = subArray.Length;
            return maxLength;
        }
        public int Task10(int[][] array, Func<int[][], int> func)
        {
            int answer = 0;

            // code here
            if (array == null || func == null) return 0;
            answer = func(array);
            // end

            return answer;
        }
    }
}
