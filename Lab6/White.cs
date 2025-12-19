using System;
using System.Linq;

namespace Lab6
{
    public class White
    {
        public void Task1(double[] A, double[] B)
        {
            int maxPlaceA = 0;
            double maxValueA = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] > maxValueA)
                {
                    maxValueA = A[i];
                    maxPlaceA = i;
                }
            }

            int maxPlaceB = 0;
            double maxValueB = B[0];
            for (int i = 1; i < B.Length; i++)
            {
                if (B[i] > maxValueB)
                {
                    maxValueB = B[i];
                    maxPlaceB = i;
                }
            }

            int distanceA = A.Length - 1 - maxPlaceA;
            int distanceB = B.Length - 1 - maxPlaceB;

            double[] arrayToChange = A;
            int elementPlace = maxPlaceA;

            if (distanceB > distanceA)
            {
                arrayToChange = B;
                elementPlace = maxPlaceB;
            }

            if (elementPlace == arrayToChange.Length - 1)
            {
                return;
            }

            double total = 0;
            int count = 0;
            for (int i = elementPlace + 1; i < arrayToChange.Length; i++)
            {
                total += arrayToChange[i];
                count++;
            }

            double average = total / count;
            arrayToChange[elementPlace] = average;
        }

        public void Task2(int[,] A, int[,] B)
        {
            if (A.GetLength(0) != B.GetLength(0) || A.GetLength(1) != B.GetLength(1))
            {
                return;
            }

            int maxRowA = 0;
            int maxInColA = A[0, 0];
            for (int i = 1; i < A.GetLength(0); i++)
            {
                if (A[i, 0] > maxInColA)
                {
                    maxInColA = A[i, 0];
                    maxRowA = i;
                }
            }

            int maxRowB = 0;
            int maxInColB = B[0, 0];
            for (int i = 1; i < B.GetLength(0); i++)
            {
                if (B[i, 0] > maxInColB)
                {
                    maxInColB = B[i, 0];
                    maxRowB = i;
                }
            }

            for (int j = 0; j < A.GetLength(1); j++)
            {
                int temp = A[maxRowA, j];
                A[maxRowA, j] = B[maxRowB, j];
                B[maxRowB, j] = temp;
            }
        }

        public int Task3(int[,] matrix)
        {
            int answer = 0;

            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);

            int[] negativeCount = new int[rowCount];

            for (int i = 0; i < rowCount; i++)
            {
                int count = 0;
                for (int j = 0; j < colCount; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
                negativeCount[i] = count;
            }

            int maxCount = negativeCount[0];
            answer = 0;

            for (int i = 1; i < rowCount; i++)
            {
                if (negativeCount[i] > maxCount)
                {
                    maxCount = negativeCount[i];
                    answer = i;
                }
            }
            return answer;
        }

        public void Task4(int[,] A, int[,] B)
        {
            int rowA = 0;
            int colA = 0;
            int maxA = A[0, 0];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (A[i, j] > maxA)
                    {
                        maxA = A[i, j];
                        rowA = i;
                        colA = j;
                    }
                }
            }

            int rowB = 0;
            int colB = 0;
            int maxB = B[0, 0];

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    if (B[i, j] > maxB)
                    {
                        maxB = B[i, j];
                        rowB = i;
                        colB = j;
                    }
                }
            }

            A[rowA, colA] = maxB;
            B[rowB, colB] = maxA;
        }

        public void Task5(int[,] A, int[,] B)
        {
            int rowA = 0;
            int colA = 0;
            int maxA = A[0, 0];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (A[i, j] > maxA)
                    {
                        maxA = A[i, j];
                        rowA = i;
                        colA = j;
                    }
                }
            }

            int rowB = 0;
            int colB = 0;
            int maxB = B[0, 0];

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    if (B[i, j] > maxB)
                    {
                        maxB = B[i, j];
                        rowB = i;
                        colB = j;
                    }
                }
            }

            if (A.GetLength(0) != B.GetLength(0))
            {
                return;
            }

            for (int i = 0; i < A.GetLength(0); i++)
            {
                int temp = A[i, colA];
                A[i, colA] = B[i, colB];
                B[i, colB] = temp;
            }
        }

        public void Task6(int[,] matrix, Sorting sort)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }

            sort(matrix);
        }

        public long Task7(int n, int k)
        {
            long answer = 0;

            if (k > n || n < 0 || k < 0)
            {
                return 0;
            }

            long factN = 1;
            for (int i = 2; i <= n; i++)
            {
                factN = factN * i;
            }

            long factK = 1;
            for (int i = 2; i <= k; i++)
            {
                factK = factK * i;
            }

            long factNK = 1;
            int diff = n - k;
            for (int i = 2; i <= diff; i++)
            {
                factNK = factNK * i;
            }

            answer = factN / (factK * factNK);
            return answer;
        }

        public double Task8(double v, double a, BikeRide ride)
        {
            double answer = 0;
            answer = ride(v, a);
            return answer;
        }

        public int Task9(int[][] array)
        {
            int answer = 0;

            if (array.Length % 2 == 0)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    double[] tempArray = new double[array[i].Length];
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        tempArray[j] = array[i][j];
                    }

                    for (int j = 0; j < tempArray.Length - 1; j += 2)
                    {
                        double temp = tempArray[j];
                        tempArray[j] = tempArray[j + 1];
                        tempArray[j + 1] = temp;
                    }
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    double[] tempArray = new double[array[i].Length];
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        tempArray[j] = array[i][j];
                    }

                    for (int j = tempArray.Length - 1; j > 0; j -= 2)
                    {
                        double temp = tempArray[j];
                        tempArray[j] = tempArray[j - 1];
                        tempArray[j - 1] = temp;
                    }
                }
            }

            double totalSum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 1)
                {
                    double[] tempArray = new double[array[i].Length];
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        tempArray[j] = array[i][j];
                    }

                    for (int j = 0; j < tempArray.Length; j++)
                    {
                        if (j % 2 == 0)
                        {
                            totalSum += tempArray[j];
                        }
                    }
                }
            }

            answer = (int)totalSum;
            return answer;
        }

        public int Task10(int[][] array, Func<int[][], int> func)
        {
            int answer = 0;
            answer = func(array);
            return answer;
        }
    }

    public delegate void Sorting(int[,] matrix);
    public delegate double BikeRide(double v, double a);
    public delegate int Finder(int[,] matrix);
    public delegate void SortRowsStyle(int[,] matrix);
    public delegate void ReplaceMaxElements(int[,] matrix, int value);
    public delegate int[,] GetTriangle(int[,] matrix);
    public delegate void SortRowsByMax(int[,] matrix);
    public delegate int FindNegatives(int[,] matrix);
    public delegate double MathInfo(int[,] matrix);
}
