using System;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int size = matrix.GetLength(0);

            if (size != matrix.GetLength(1))
                return 0;

            int maxIndex = 0;
            int maxValue = matrix[0, 0];

            for (int i = 1; i < size; i++)
            {
                if (matrix[i, i] > maxValue)
                {
                    maxValue = matrix[i, i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        public void SwapRowColumn(int[,] A, int rowIndex, int[,] B, int columnIndex)
        {
            int sizeA = A.GetLength(0);
            int sizeB = B.GetLength(0);

            if (A.GetLength(0) != A.GetLength(1) || B.GetLength(0) != B.GetLength(1))
                return;

            if (rowIndex < 0 || rowIndex >= sizeA || columnIndex < 0 || columnIndex >= sizeB)
                return;

            for (int i = 0; i < sizeA; i++)
            {
                int temp = A[rowIndex, i];
                A[rowIndex, i] = B[i, columnIndex];
                B[i, columnIndex] = temp;
            }
        }

        public void Task1(int[,] A, int[,] B)
        {
            if (A.GetLength(0) != A.GetLength(1) || B.GetLength(0) != B.GetLength(1) ||
                A.GetLength(0) != B.GetLength(0))
                return;

            int rowIndex = FindDiagonalMaxIndex(A);
            int columnIndex = FindDiagonalMaxIndex(B);

            SwapRowColumn(A, rowIndex, B, columnIndex);
        }

        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int count = 0;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] > 0)
                    count++;
            }

            return count;
        }

        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, col] > 0)
                    count++;
            }

            return count;
        }

        public void InsertColumn(ref int[,] matrixA, int rowIndex, int columnIndex, int[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int[,] newMatrix = new int[rowsA + 1, colsA];

            for (int i = 0; i <= rowIndex; i++)
            for (int j = 0; j < colsA; j++)
                newMatrix[i, j] = matrixA[i, j];

            for (int j = 0; j < matrixB.GetLength(0); j++)
                newMatrix[rowIndex + 1, j] = matrixB[j, columnIndex];

            for (int i = rowIndex + 2; i < newMatrix.GetLength(0); i++)
            for (int j = 0; j < colsA; j++)
                newMatrix[i, j] = matrixA[i - 1, j];

            matrixA = newMatrix;
        }

        public void Task2(ref int[,] A, int[,] B)
        {
            if (A == null || B == null || A.GetLength(1) != B.GetLength(0))
                return;

            int maxRowIndex = 0;
            int maxRowPositives = CountPositiveElementsInRow(A, 0);

            for (int i = 1; i < A.GetLength(0); i++)
            {
                int count = CountPositiveElementsInRow(A, i);
                if (count > maxRowPositives)
                {
                    maxRowPositives = count;
                    maxRowIndex = i;
                }
            }

            int maxColIndex = 0;
            int maxColPositives = 0;

            for (int j = 0; j < B.GetLength(1); j++)
            {
                int count = CountPositiveElementsInColumn(B, j);
                if (count > maxColPositives)
                {
                    maxColPositives = count;
                    maxColIndex = j;
                }
            }

            if (maxColPositives == 0)
                return;

            InsertColumn(ref A, maxRowIndex, maxColIndex, B);
        }

        public void ChangeMatrixValues(int[,] matrix)
        {
            if (matrix == null) return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int total = rows * cols;

            if (total <= 5)
            {
                for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] *= 2;
                return;
            }

            bool[,] top5 = new bool[rows, cols];

            for (int c = 0; c < 5; c++)
            {
                int max = int.MinValue;
                int maxRow = -1;
                int maxCol = -1;

                for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (!top5[i, j] && matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxRow = i;
                        maxCol = j;
                    }

                if (maxRow != -1 && maxCol != -1)
                    top5[maxRow, maxCol] = true;
            }

            for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                matrix[i, j] = top5[i, j] ? matrix[i, j] * 2 : matrix[i, j] / 2;
        }

        public void Task3(int[,] matrix)
        {
            if (matrix == null) return;
            ChangeMatrixValues(matrix);
        }

        public int[] CountNegativesPerRow(int[,] matrix)
        {
            if (matrix == null) return null;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] negativesCount = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                    if (matrix[i, j] < 0)
                        count++;
                negativesCount[i] = count;
            }

            return negativesCount;
        }

        public int FindMaxIndex(int[] array)
        {
            if (array == null || array.Length == 0)
                return -1;

            int maxIndex = 0;
            int maxValue = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        public void Task4(int[,] A, int[,] B)
        {
            if (A == null || B == null) return;

            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);

            if (rowsA != rowsB || colsA != colsB) return;

            int[] negCountA = CountNegativesPerRow(A);
            int[] negCountB = CountNegativesPerRow(B);
            int maxRowA = FindMaxIndex(negCountA);
            int maxRowB = FindMaxIndex(negCountB);

            if (negCountA[maxRowA] == 0 || negCountB[maxRowB] == 0) return;

            for (int j = 0; j < colsA; j++)
            {
                int temp = A[maxRowA, j];
                A[maxRowA, j] = B[maxRowB, j];
                B[maxRowB, j] = temp;
            }
        }

        public delegate void Sorting(int[] array);

        public void SortNegativeAscending(int[] array)
        {
            int countNeg = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i] < 0)
                    countNeg++;

            if (countNeg == 0) return;

            int[] negatives = new int[countNeg];
            int index = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i] < 0)
                    negatives[index++] = array[i];

            Array.Sort(negatives);

            index = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i] < 0)
                    array[i] = negatives[index++];
        }

        public void SortNegativeDescending(int[] array)
        {
            int countNeg = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i] < 0)
                    countNeg++;

            if (countNeg == 0) return;

            int[] negatives = new int[countNeg];
            int index = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i] < 0)
                    negatives[index++] = array[i];

            Array.Sort(negatives);
            Array.Reverse(negatives);

            index = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i] < 0)
                    array[i] = negatives[index++];
        }

        public void Task5(int[] array, Sorting sort)
        {
            sort(array);
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

        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

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

        public void Task6(int[,] matrix, SortRowsByMax sort)
        {
            sort(matrix);
        }

        public delegate int[] FindNegatives(int[,] matrix);

        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int[] result = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int countNeg = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] < 0)
                        countNeg++;

                result[i] = countNeg;
            }

            return result;
        }

        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int cols = matrix.GetLength(1);
            int rows = matrix.GetLength(0);
            int[] result = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                int max = int.MinValue;
                int countNeg = 0;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] < 0)
                        countNeg++;

                    if (matrix[i, j] < 0 && matrix[i, j] > max)
                        max = matrix[i, j];
                }

                result[j] = countNeg == 0 ? 0 : max;
            }

            return result;
        }

        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            return find(matrix);
        }

        public delegate int[,] MathInfo(int[,] matrix);

        public int[,] DefineSeq(int[,] matrix)
        {
            int n = matrix.GetLength(1);
            bool increasing = true;
            bool decreasing = true;

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
            result[0, 0] = increasing ? 1 : decreasing ? -1 : 0;
            return result;
        }

        public int[,] FindAllSeq(int[,] matrix)
        {
            int n = matrix.GetLength(1);
            if (n <= 1) return new int[0, 0];

            bool allEqual = true;
            for (int i = 0; i < n - 1; i++)
                if (matrix[1, i] != matrix[1, i + 1])
                {
                    allEqual = false;
                    break;
                }

            if (allEqual) return new int[0, 0];

            int trend = 0;
            int countSeq = 0;

            for (int i = 0; i < n - 1; i++)
            {
                int diff = matrix[1, i + 1] - matrix[1, i];
                if (diff == 0) continue;

                int newTrend = diff > 0 ? 1 : -1;

                if (trend == 0)
                {
                    trend = newTrend;
                    countSeq = 1;
                }
                else if (newTrend != trend)
                {
                    countSeq++;
                    trend = newTrend;
                }
            }

            int[,] result = new int[countSeq, 2];
            int startIndex = 0;
            trend = 0;
            int idx = 0;

            for (int i = 0; i < n - 1; i++)
            {
                int diff = matrix[1, i + 1] - matrix[1, i];
                if (diff == 0) continue;

                int newTrend = diff > 0 ? 1 : -1;

                if (trend == 0)
                    trend = newTrend;
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

        public int[,] FindLongestSeq(int[,] matrix)
        {
            int[,] allSeq = FindAllSeq(matrix);
            int rows = allSeq.GetLength(0);
            if (rows == 0) return new int[0, 0];

            int bestIdx = 0;
            int bestLen = allSeq[0, 1] - allSeq[0, 0];

            for (int i = 1; i < rows; i++)
            {
                int len = allSeq[i, 1] - allSeq[i, 0];
                if (len > bestLen)
                {
                    bestLen = len;
                    bestIdx = i;
                }
            }

            int[,] result = new int[1, 2];
            result[0, 0] = allSeq[bestIdx, 0];
            result[0, 1] = allSeq[bestIdx, 1];

            return result;
        }

        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            return info(matrix);
        }

        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            if (h <= 0 || a >= b) return 0;

            int flips = 0;
            double prevValue = func(a);
            int prevSign = Math.Sign(prevValue);

            for (double x = a + h; x <= b + 1e-12; x += h)
            {
                double currentValue = func(x);
                int currentSign = Math.Sign(currentValue);

                if (currentSign != 0 && prevSign != 0 && currentSign != prevSign)
                    flips++;

                if (currentSign != 0)
                    prevSign = currentSign;

                prevValue = currentValue;
            }

            return flips;
        }

        public double FuncA(double x) => x * x - Math.Sin(x);
        public double FuncB(double x) => Math.Exp(x) - 1;

        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            return CountSignFlips(a, b, h, func);
        }

        public void SortInCheckersOrder(int[][] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    int n = array[i].Length;
                    for (int k = 0; k < n - 1; k++)
                    {
                        for (int j = 0; j < n - k - 1; j++)
                            if (array[i][j] > array[i][j + 1])
                                (array[i][j], array[i][j + 1]) = (array[i][j + 1], array[i][j]);
                    }
                }
                else
                {
                    int n = array[i].Length;
                    for (int k = 0; k < n - 1; k++)
                    {
                        for (int j = 0; j < n - k - 1; j++)
                            if (array[i][j] < array[i][j + 1])
                                (array[i][j], array[i][j + 1]) = (array[i][j + 1], array[i][j]);
                    }
                }
            }
        }

        public void SortBySumDesc(int[][] array)
        {
            if (array == null)
            {
                return;
            }

            int[] sums = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    int sum = 0;
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        sum += array[i][j];
                    }

                    sums[i] = sum;
                }
                else
                {
                    sums[i] = 0;
                }
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (sums[j] < sums[j + 1])
                    {
                        int[] temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        int t = sums[j];
                        sums[j] = sums[j + 1];
                        sums[j + 1] = t;
                    }
                }
            }
        }

        public void TotalReverse(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Array.Reverse(array[i]);
            }

            Array.Reverse(array);
        }

        public void Task10(int[][] array, Action<int[][]> func)
        {
            // code here
            func(array);
            // end
        }
    }
}