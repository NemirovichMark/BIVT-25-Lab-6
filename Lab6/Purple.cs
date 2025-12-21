using System;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        {
        public void Task1(int[,] A, int[,] B)
        {

            // code here

            if (A.GetLength(0) == B.GetLength(1) && B.GetLength(0) == B.GetLength(1))
            {
                SwapRowColumn(A, FindDiagonalMaxIndex(A), B, FindDiagonalMaxIndex(B));
            }
            // end
        }

        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int ind = 0, max = -1000000000;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > max)
                {
                    ind = i;
                    max = matrix[i, i];
                }
            }
            return ind;
        }
        public void Task2(ref int[,] A, int[,] B)

        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                (matrix[rowIndex, i], B[i, columnIndex]) = (B[i, columnIndex], matrix[rowIndex, i]);
            }
        }

        public void Task2(ref int[,] A, int[,] B)
        {
            // code here
            if (A.GetLength(1) == B.GetLength(0))
            {
                int rowInd = -1;
                int colInd = -1;
                int max = -1000000;

                for (int i = 0; i < A.GetLength(0); i++)
                {
                    if (CountPositiveElementsInRow(A, i) > max)
                    {
                        rowInd = i;
                        max = CountPositiveElementsInRow(A, i);
                    }
                }

                max = -10000000;
                for (int i = 0; i < B.GetLength(1); i++)
                {
                    if (CountPositiveElementsInColumn(B, i) > max)
                    {
                        colInd = i;
                        max = CountPositiveElementsInColumn(B, i);
                    }
                }

                InsertColumn(ref A, rowInd, colInd, B);
            }
            // end
        }

        public void InsertColumn(ref int[,] A, int rowAfter, int colIndexB, int[,] B)
        {
            int[,] C = new int[A.GetLength(0) + 1, A.GetLength(1)];
            for (int i = 0; i < A.GetLength(0) + 1; i++)
            {
                if (i < rowAfter + 1)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        C[i, j] = A[i, j];
                    }
                }
                else if (i == rowAfter + 1)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        C[i, j] = B[j, colIndexB];
                    }
                }
                else
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        C[i, j] = A[i - 1, j];
                    }
                }
            }
            A = C;
        }
        public void Task3(int[,] matrix)

        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int c = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] > 0) c++;
            }
            return c;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int c = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > 0) c++;
            }
            return c;
        }

        public void Task3(int[,] matrix)
        {
            // code here

            ChangeMatrixValues(matrix);
            // end
        }

        public void ChangeMatrixValues(int[,] matrix)
        {
            int[] sortArray = new int[matrix.Length];
            int[] tempArray = new int[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                tempArray[i] = matrix[i / (int)matrix.GetLength(1), i % (int)matrix.GetLength(1)];
            }
            for (int i = 0; i < tempArray.Length; i++)
            {
                for (int j = 0; j < tempArray.Length - 1; j++)
                {
                    if (tempArray[j] < tempArray[j + 1])
                    {
                        (tempArray[j], tempArray[j + 1]) = (tempArray[j + 1], tempArray[j]);
                    }
                }
            }
            int k = 0;
            if (matrix.Length < 5)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i / (int)matrix.GetLength(1), i % (int)matrix.GetLength(1)] *= 2;
                }
            }
            else
            {
                int[] aaa = new int[5];
                for (int i = 0; i < matrix.Length; i++)
                {
                    if ((matrix[i / (int)matrix.GetLength(1), i % (int)matrix.GetLength(1)] == tempArray[0] || matrix[i / (int)matrix.GetLength(1), i % (int)matrix.GetLength(1)] == tempArray[1] || matrix[i / (int)matrix.GetLength(1), i % (int)matrix.GetLength(1)] == tempArray[2] || matrix[i / (int)matrix.GetLength(1), i % (int)matrix.GetLength(1)] == tempArray[3] || matrix[i / (int)matrix.GetLength(1), i % (int)matrix.GetLength(1)] == tempArray[4]) && k < 5)
                    {
                        tempArray[Array.IndexOf(tempArray, matrix[i / (int)matrix.GetLength(1), i % (int)matrix.GetLength(1)])] = -1000000000;
                        matrix[i / (int)matrix.GetLength(1), i % (int)matrix.GetLength(1)] *= 2;
                        k++;
                    }
                    else
                    {
                        matrix[i / (int)matrix.GetLength(1), i % (int)matrix.GetLength(1)] /= 2;
                    }
                }
            }
            return;
        }

        public void Task4(int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(1) != B.GetLength(1))
                return;

            int[] negA = CountNegativesPerRow(A);
            int[] negB = CountNegativesPerRow(B);

            bool hasNegativesA = false;
            foreach (int x in negA)
                if (x > 0)
                {
                    hasNegativesA = true;
                    break;
                }
            bool hasNegativesB = false;
            foreach (int x in negB)
                if (x > 0)
                {
                    hasNegativesB = true;
                    break;
                }
            if (!hasNegativesA || !hasNegativesB)
                return;
            int rowA = FindMaxIndex(negA);
            int rowB = FindMaxIndex(negB);
            for (int j = 0; j < A.GetLength(1); j++)
            {
                int temp = A[rowA, j];
                A[rowA, j] = B[rowB, j];
                B[rowB, j] = temp;
            }
            // end
        }

        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] result = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    if (matrix[i, j] < 0)
                        result[i]++;
            }

            return result;
        }
        public void Task5(int[] matrix, Sorting sort)

        public int FindMaxIndex(int[] arr)
        {
            int maxIndex = 0;

            // code here
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] > arr[maxIndex])
                    maxIndex = i;

            return maxIndex;
        }

        public void Task5(int[] matrix, Sorting sort)
        {
            // code here
            sort(matrix);
            // end
        }

        public delegate void Sorting(int[] matrix);

        public void SortNegativeAscending(int[] matrix)
        {
            int negCount = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    negCount++;
            }
            if (negCount == 0) return;
            int[] negatives = new int[negCount];
            int idx = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    negatives[idx++] = matrix[i];
                }
            }
            for (int i = 0; i < negCount - 1; i++)
            {
                for (int j = 0; j < negCount - i - 1; j++)
                {
                    if (negatives[j] > negatives[j + 1])
                    {
                        int temp = negatives[j];
                        negatives[j] = negatives[j + 1];
                        negatives[j + 1] = temp;
                    }
                }
            }
            idx = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    matrix[i] = negatives[idx++];
            }
        }
        public void Task6(int[,] matrix, SortRowsByMax sort)

        public void SortNegativeDescending(int[] matrix)
        {
            int negCount = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    negCount++;
            }

            // code here
            if (negCount == 0) return;

            int[] negatives = new int[negCount];
            int idx = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    negatives[idx++] = matrix[i];
            }

            for (int i = 0; i < negCount - 1; i++)
            {
                for (int j = 0; j < negCount - i - 1; j++)
                {
                    if (negatives[j] < negatives[j + 1])
                    {
                        int temp = negatives[j];
                        negatives[j] = negatives[j + 1];
                        negatives[j + 1] = temp;
                    }
                }
            }

            idx = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    matrix[i] = negatives[idx++];
            }
        }
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {
            // code here
            sort(matrix);
            // end
        }

        public delegate void SortRowsByMax(int[,] matrix);

        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows - 1; i++)
                for (int j = i + 1; j < rows; j++)
                    if (GetRowMax(matrix, i) > GetRowMax(matrix, j))
                        for (int k = 0; k < cols; k++)
                            (matrix[i, k], matrix[j, k]) = (matrix[j, k], matrix[i, k]);
        }
        public int[] Task7(int[,] matrix, FindNegatives find)
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int[] negatives = null;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // code here
            for (int i = 0; i < rows - 1; i++)
                for (int j = i + 1; j < rows; j++)
                    if (GetRowMax(matrix, i) < GetRowMax(matrix, j))
                        for (int k = 0; k < cols; k++)
                            (matrix[i, k], matrix[j, k]) = (matrix[j, k], matrix[i, k]);
        }
        public int GetRowMax(int[,] matrix, int row)
        {
            int max = matrix[row, 0];

            for (int j = 1; j < matrix.GetLength(1); j++)
                if (matrix[row, j] > max)
                    max = matrix[row, j];

            return max;
        }

        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            // code here
            return find(matrix);
            // end
        }

        public delegate int[] FindNegatives(int[,] matrix);

        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] result = new int[rows];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (matrix[i, j] < 0)
                        result[i]++;

            return negatives;
            return result;
        }

        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] result = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                int maxNeg = 0;
                bool hasNeg = false;

                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        if (!hasNeg || matrix[i, j] > maxNeg)
                            maxNeg = matrix[i, j];
                        hasNeg = true;
                    }
                }

                if (hasNeg)
                {
                    result[j] = maxNeg;
                }
                else
                {
                    result[j] = 0;
                }
            }

            return result;
        }


        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            // code here
            int[,] answer = null;
            answer = info(matrix);
            return answer;
            // end
        }

            // code here
        public delegate int[,] MathInfo(int[,] matrix);

            // end
        public int[,] DefineSeq(int[,] matrix)
        {
            int n = matrix.GetLength(1);
            bool increasing = true;
            bool decreasing = true;

            return answer;
            for (int i = 0; i < n - 1; i++)
            {
                if (matrix[1, i] < matrix[1, i + 1])
                    decreasing = false;
                if (matrix[1, i] > matrix[1, i + 1])
                    increasing = false;
            }

            if (increasing && decreasing)
                return new int[0, 0];

            int[,] result = new int[1, 1];
            if (increasing)
                result[0, 0] = 1;
            else if (decreasing)
                result[0, 0] = -1;
            else
                result[0, 0] = 0;

            return result;
        }
        public int Task9(double a, double b, double h, Func<double, double> func)

        public int[,] FindAllSeq(int[,] matrix)
        {
            int answer = 0;
            int n = matrix.GetLength(1);
            if (n <= 1) return new int[0, 0];

            // code here
            bool allEqual = true;
            for (int i = 0; i < n - 1; i++)
            {
                if (matrix[1, i] != matrix[1, i + 1])
                {
                    allEqual = false;
                    break;
                }
            }
            if (allEqual) return new int[0, 0];

            // end
            int trend = 0;
            int count = 0;

            return answer;
            for (int i = 0; i < n - 1; i++)
            {
                int dy = matrix[1, i + 1] - matrix[1, i];
                if (dy == 0) continue;

                int newTrend;
                if (dy > 0)
                    newTrend = 1;
                else
                    newTrend = -1;

                if (trend == 0)
                {
                    trend = newTrend;
                    count = 1;
                }
                else if (newTrend != trend)
                {
                    count++;
                    trend = newTrend;
                }
            }

            int[,] result = new int[count, 2];
            int startIndex = 0;
            trend = 0;
            int idx = 0;

            for (int i = 0; i < n - 1; i++)
            {
                int dy = matrix[1, i + 1] - matrix[1, i];
                if (dy == 0) continue;

                int newTrend;
                if (dy > 0)
                    newTrend = 1;
                else
                    newTrend = -1;

                if (trend == 0)
                {
                    trend = newTrend;
                }
                else if (newTrend != trend)
                {
                    result[idx, 0] = matrix[0, startIndex];
                    result[idx, 1] = matrix[0, i];
                    idx++;
                    startIndex = i;
                    trend = newTrend;
                }
            }

            result[idx, 0] = matrix[0, startIndex];
            result[idx, 1] = matrix[0, n - 1];

            return result;
        }
        public void Task10(int[][] array, Action<int[][]> func)

        public int[,] FindLongestSeq(int[,] matrix)
        {
            int[,] all = FindAllSeq(matrix);
            int rows = all.GetLength(0);
            if (rows == 0) return new int[0, 0];

            int best = 0;
            int bestLen = all[0, 1] - all[0, 0];

            for (int i = 1; i < rows; i++)
            {
                int len = all[i, 1] - all[i, 0];
                if (len > bestLen)
                {
                    bestLen = len;
                    best = i;
                }
            }

            int[,] result = new int[1, 2];
            result[0, 0] = all[best, 0];
            result[0, 1] = all[best, 1];

            return result;
        }


        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            // code here
            return CountSignFlips(a, b, h, func);
            // end
        }

        public delegate double Func(double x);

        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            if (h <= 0 || a > b) return 0;

            int count = 0;
            double prev = func(a);

            for (double x = a + h; x <= b; x += h)
            {
                double curr = func(x);
                if (prev * curr < 0) count++;
                prev = curr;
            }

            return count;
        }

        public double FuncA(double x)
        {
            return x * x - Math.Sin(x);
        }

        public double FuncB(double x)
        {
            return Math.Exp(x) - 1;
        }

        public void Task10(int[][] array, Action<int[][]> func)
        {
            // code here
            func(array);
            // end
        }

        public void SortInCheckersOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null || array[i].Length == 0) continue;

                for (int j = 0; j < array[i].Length - 1; j++)
                {
                    for (int k = 0; k < array[i].Length - j - 1; k++)
                    {
                        if (array[i][k] > array[i][k + 1])
                        {
                            int temp = array[i][k];
                            array[i][k] = array[i][k + 1];
                            array[i][k + 1] = temp;
                        }
                    }
                }

                if (i % 2 != 0)
                {
                    int len = array[i].Length;
                    for (int j = 0; j < len / 2; j++)
                    {
                        int temp = array[i][j];
                        array[i][j] = array[i][len - j - 1];
                        array[i][len - j - 1] = temp;
                    }
                }
            }
        }
        public void SortBySumDesc(int[][] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    int sumI = 0, sumJ = 0;
                    if (array[i] != null)
                        foreach (int val in array[i]) sumI += val;
                    if (array[j] != null)
                        foreach (int val in array[j]) sumJ += val;

                    if (sumI < sumJ)
                    {
                        int[] temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public void TotalReverse(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    int len = array[i].Length;
                    for (int j = 0; j < len / 2; j++)
                    {
                        int temp = array[i][j];
                        array[i][j] = array[i][len - j - 1];
                        array[i][len - j - 1] = temp;
                    }
                }
            }
            int n = array.Length;
            for (int i = 0; i < n / 2; i++)
            {
                int[] temp = array[i];
                array[i] = array[n - i - 1];
                array[n - i - 1] = temp;
            }
        }

    }
} 
}
    }

}
