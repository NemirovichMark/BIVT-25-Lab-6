using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class White

    {
        public int FindMax(double[] array)
        {
            if (array == null || array.Length == 0) return -1;

            int maxIndex = 0;
            for (int i = 1; i < array.Length; i++)
                if (array[i] > array[maxIndex])
                    maxIndex = i;

            return maxIndex;
        }

        // Метод для поиска строки с максимальным элементом в заданном столбце (Task2)
        public int FindMaxInColumn(int[,] matrix, int column)
        {
            if (matrix == null || column < 0 || column >= matrix.GetLength(1))
                return -1;

            int maxRow = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
                if (matrix[i, column] > matrix[maxRow, column])
                    maxRow = i;

            return maxRow;
        }

        // Метод для подсчёта отрицательных элементов в строке (Task3)
        public int GetNegativeCount(int[,] matrix, int row)
        {
            if (matrix == null || row < 0 || row >= matrix.GetLength(0))
                return 0;

            int count = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (matrix[row, j] < 0)
                    count++;

            return count;
        }

        // Метод для поиска максимального элемента в матрице (Task4)
        public int FindMax(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return 0;

            int max = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > max)
                        max = matrix[i, j];

            return max;
        }

        // Метод для поиска столбца с максимальным элементом (Task5)
        public int FindMaxColumn(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return -1;

            int max = matrix[0, 0];
            int col = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        col = j;
                    }
                }
            }

            return col;
        }

        
        public void SwapColumns(int[,] matrixA, int colA, int[,] matrixB, int colB)
        {
            if (matrixA.GetLength(0) != matrixB.GetLength(0))
                return;

            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                int temp = matrixA[i, colA];
                matrixA[i, colA] = matrixB[i, colB];
                matrixB[i, colB] = temp;
            }
        }

        public long Factorial(int n)
        {
            if (n <= 1) return 1;
            return n * Factorial(n - 1);
        }
        public void Task1(double[] A, double[] B)
        {

            // code here
            if (A == null || B == null || A.Length == 0 || B.Length == 0)
                return;

            int maxIndexA = FindMax(A);
            int maxIndexB = FindMax(B);

            if (maxIndexA == -1 || maxIndexB == -1)
                return;

            double maxA = A[maxIndexA];
            double maxB = B[maxIndexB];

            // Выбираем массив для изменения
            double[] targetArray;
            int targetIndex;

            if (maxA >= maxB)
            {
                targetArray = A;
                targetIndex = maxIndexA;
            }
            else
            {
                targetArray = B;
                targetIndex = maxIndexB;
            }

            // Если максимальный элемент не последний
            if (targetIndex < targetArray.Length - 1)
            {
                double sum = 0;
                int count = 0;

                for (int i = targetIndex + 1; i < targetArray.Length; i++)
                {
                    sum += targetArray[i];
                    count++;
                }

                targetArray[targetIndex] = sum / count;
            }
            // end

        }
        public void Task2(int[,] A, int[,] B)
        {

            // code here
            if (A == null || B == null ||
                A.GetLength(0) != B.GetLength(0) ||
                A.GetLength(1) != B.GetLength(1))
                return;

            int rowA = FindMaxInColumn(A, 0);
            int rowB = FindMaxInColumn(B, 0);

            if (rowA == -1 || rowB == -1)
                return;

            // Обмен строк
            for (int j = 0; j < A.GetLength(1); j++)
            {
                int temp = A[rowA, j];
                A[rowA, j] = B[rowB, j];
                B[rowB, j] = temp;
            }
            // end

        }
        public int Task3(int[,] matrix)
        {
            int answer = 0;

            // code here
            if (matrix == null || matrix.GetLength(0) == 0)
                return -1;

            int maxRow = -1;
            int maxCount = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = GetNegativeCount(matrix, i);
                if (count > maxCount)
                {
                    maxCount = count;
                    maxRow = i;
                }
            }
            answer = maxCount > 0 ? maxRow : -1;
                // end

                return answer;
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            if (A == null || B == null || A.Length == 0 || B.Length == 0)
                return;

            // Находим индексы максимальных элементов
            (int rowA, int colA) = FindMaxIndices(A);
            (int rowB, int colB) = FindMaxIndices(B);

            if (rowA == -1 || rowB == -1)
                return;

            // Меняем местами
            int temp = A[rowA, colA];
            A[rowA, colA] = B[rowB, colB];
            B[rowB, colB] = temp;
        }

        private (int row, int col) FindMaxIndices(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return (-1, -1);

            int maxRow = 0, maxCol = 0;
            int max = matrix[0, 0];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            return (maxRow, maxCol);
            // end

        }
        public void Task5(int[,] A, int[,] B)
        {

            // code here
            if (A == null || B == null || A.GetLength(0) != B.GetLength(0))
                return;

            int colA = FindMaxColumn(A);
            int colB = FindMaxColumn(B);

            if (colA == -1 || colB == -1)
                return;

            SwapColumns(A, colA, B, colB);
            // end

        }
        public void Task6(int[,] matrix, Sorting sort)
        {

            // code here
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1) || sort == null)
                return;

            sort.SortAscending(matrix);
            // end

        }
        public long Task7(int n, int k)
        {
            long answer = 0;

            // code here
            if (n < 0 || k < 0 || k > n)
                return 0;

            long numerator = Factorial(n);
            long denominator = Factorial(k) * Factorial(n - k);

            answer =  denominator == 0 ? 0 : numerator / denominator;
            // end

            return answer;
        }
        public double Task8(double v, double a, BikeRide ride)
        {
            double answer = 0;

            // code here
            if (ride == null)
                return 0;

            answer = ride.CalcDistance(v, a);
            // end

            return answer;
        }
        public int Task9(int[][] array)
        {
            int answer = 0;

            // code here
            if (array == null)
                return 0;

            Swapper swapper = new Swapper();

            if (array.Length % 2 == 0)
                swapper.SwapFromStart(array);
            else
                swapper.SwapFromEnd(array);

             answer= (int)swapper.Sum(array);
            // end

            return answer;
        }
        public int Task10(int[][] array, Func<int[][], int> func)
        {
            int answer = 0;

            // code here
            if (array == null || func == null)
                return 0;

            answer= func(array);
            // end

            return answer;
        }
        public class Sorting
        {
            public void SortAscending(int[,] matrix)
            {
                if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
                    return;

                int n = matrix.GetLength(0);
                int[] diagonal = new int[n];

               
                for (int i = 0; i < n; i++)
                    diagonal[i] = matrix[i, i];

             
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        if (diagonal[j] > diagonal[j + 1])
                        {
                            int temp = diagonal[j];
                            diagonal[j] = diagonal[j + 1];
                            diagonal[j + 1] = temp;
                        }
                    }
                }

                for (int i = 0; i < n; i++)
                    matrix[i, i] = diagonal[i];
            }

            public void SortDescending(int[,] matrix)
            {
                if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
                    return;

                int n = matrix.GetLength(0);
                int[] diagonal = new int[n];

                for (int i = 0; i < n; i++)
                    diagonal[i] = matrix[i, i];

       
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        if (diagonal[j] < diagonal[j + 1])
                        {
                            int temp = diagonal[j];
                            diagonal[j] = diagonal[j + 1];
                            diagonal[j + 1] = temp;
                        }
                    }
                }

                for (int i = 0; i < n; i++)
                    matrix[i, i] = diagonal[i];
            }
        }

        public class BikeRide
        {
            public double CalcDistance(double v, double a)
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

            public double CalcTime(double v, double a, double s)
            {
                double time = 0;
                double currentV = v;
                double distance = 0;

                while (distance < s && time < 100) 
                {
                    distance += currentV;
                    currentV += a;
                    time++;
                }

                return time;
            }
        }

        public class Swapper
        {
            public double Sum(int[][] array)
            {
                double sum = 0;

                foreach (var subArray in array)
                {
                    if (subArray != null)
                    {
                        foreach (var element in subArray)
                        {
                            sum += element;
                        }
                    }
                }

                return sum;
            }

            public void SwapFromStart(int[][] array)
            {
                for (int i = 0; i < array.Length - 1; i += 2)
                {
                    if (array[i] != null && array[i + 1] != null)
                    {
                        int[] temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            }

            public void SwapFromEnd(int[][] array)
            {
                for (int i = array.Length - 1; i > 0; i -= 2)
                {
                    if (array[i] != null && array[i - 1] != null)
                    {
                        int[] temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                    }
                }
            }
        }
    }
}