using System;
using System.Collections.Immutable;
using System.Net.Http.Headers;
using System.Numerics;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int maxIndex = 0;

            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] > matrix[maxIndex, maxIndex])
                {
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            int n = matrix.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                (matrix[rowIndex, i], B[i, columnIndex]) = (B[i, columnIndex], matrix[rowIndex, i]);
            }
        }
        public void Task1(int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(0) != A.GetLength(1) || B.GetLength(0) != B.GetLength(1) || A.GetLength(0) != B.GetLength(0))
            {
                return;
            }

            int aIdx = FindDiagonalMaxIndex(A);
            int bIdx = FindDiagonalMaxIndex(B);

            SwapRowColumn(A, aIdx, B, bIdx);
            // end

        }

        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int count = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > 0)
                    count++;
            }
            return count;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > 0)
                    count++;
            }
            return count;
        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int n = A.GetLength(0); int m = A.GetLength(1);
            int[,] newA = new int[n + 1, m];

            for (int i = 0; i < rowIndex + 1; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    newA[i, j] = A[i, j];
                }
            }

            for (int j = 0; j < m; j++)
            {
                if (j < B.GetLength(0))
                    newA[rowIndex + 1, j] = B[j, columnIndex];
                else
                    newA[rowIndex + 1, j] = 0;
            }

            for (int i = rowIndex + 1; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    newA[i + 1, j] = A[i, j];
                }
            }

            A = newA;
        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(1) != B.GetLength(0)) return;

            int maxPositiveCountRow = int.MinValue; int rowIndex = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                int PositiveCountRow = CountPositiveElementsInRow(A, i);
                if (PositiveCountRow > maxPositiveCountRow)
                {
                    maxPositiveCountRow = PositiveCountRow; 
                    rowIndex = i;
                }
            }

            int maxPositiveCountCol = int.MinValue; int columnIndex = 0;
            for (int j = 0; j < B.GetLength(1); j++)
            {
                int PositiveCountCol = CountPositiveElementsInColumn(B, j);
                if (PositiveCountCol > maxPositiveCountCol)
                {
                    maxPositiveCountCol = PositiveCountCol;
                    columnIndex = j;
                }
            }

            InsertColumn(ref A, rowIndex, columnIndex, B);
            // end

        }
        public void Task3(int[,] matrix)
        {

            // code here
            ChangeMatrixValues(matrix);
            // end

        }
        public void ChangeMatrixValues(int[,] matrix)
        {
            int n = matrix.GetLength(0); int m = matrix.GetLength(1);


            if (matrix.Length <= 5)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        matrix[i, j] *= 2;
                    }
                }
                return;
            }

            int[] array = new int[matrix.Length];
            int[] maxIndexes = new int[matrix.Length];

            int index = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[index] = matrix[i, j];
                    maxIndexes[index] = index;
                    index++;
                }
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if ((array[j] < array[j + 1]) || (array[j] == array[j + 1] && maxIndexes[j] > maxIndexes[j + 1]))
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        (maxIndexes[j], maxIndexes[j + 1]) = (maxIndexes[j + 1], maxIndexes[j]);
                    }
                }
            }

            bool[] isMaxValue = new bool[array.Length];
            for (int i = 0; i < 5; i++)
            {
                isMaxValue[maxIndexes[i]] = true;
            }

            index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (isMaxValue[index++])
                        matrix[i, j] *= 2;
                    else
                        matrix[i, j] /= 2;
                }
            }
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(1) != B.GetLength(1))
                return;

            int[] negativesA = CountNegativesPerRow(A);
            int[] negativesB = CountNegativesPerRow(B);

            int maxIndexA = FindMaxIndex(negativesA);
            int maxIndexB = FindMaxIndex(negativesB);

            if (negativesA[maxIndexA] == 0 || negativesB[maxIndexB] == 0)
                return;

            for (int j = 0; j < A.GetLength(1); j++)
            {
                (A[maxIndexA, j], B[maxIndexB, j]) = (B[maxIndexB, j], A[maxIndexA, j]);
            }
            // end

        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int[] CountNegatives = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                        count++;
                }
                CountNegatives[i] = count;
            }
            return CountNegatives;
        }
        public int FindMaxIndex(int[] array)
        {
            int maxIndex = 0; 

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > array[maxIndex])
                    maxIndex = i;    
            }

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
            int count = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    count++;
            }

            int[] negatives = new int[count];
            int[] negativesIndexes = new int[count];

            int index = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    negatives[index] = matrix[i];
                    negativesIndexes[index] = i;
                    index++;
                }
            }

            for (int i = 0; i < negatives.Length - 1; i++)
            {
                for (int j = 0; j < negatives.Length - 1 - i; j++)
                {
                    if (negatives[j] > negatives[j + 1])
                        (negatives[j], negatives[j + 1]) = (negatives[j + 1], negatives[j]);
                }
            }

            for (int i = 0; i < negativesIndexes.Length; i++)
            {
                matrix[negativesIndexes[i]] = negatives[i];
            }
        }
        public void SortNegativeDescending(int[] matrix)
        {
            int count = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    count++;
            }

            int[] negatives = new int[count];
            int[] negativesIndexes = new int[count];

            int index = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    negatives[index] = matrix[i];
                    negativesIndexes[index] = i;
                    index++;
                }
            }

            for (int i = 0; i < negatives.Length - 1; i++)
            {
                for (int j = 0; j < negatives.Length - 1 - i; j++)
                {
                    if (negatives[j] < negatives[j + 1])
                        (negatives[j], negatives[j + 1]) = (negatives[j + 1], negatives[j]);
                }
            }

            for (int i = 0; i < negativesIndexes.Length; i++)
            {
                matrix[negativesIndexes[i]] = negatives[i];
            }
        }

                public void SortRowsByMaxAscending(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(0) - 1 - i; j++)
                {
                    if (GetRowMax(matrix, j) > GetRowMax(matrix, j + 1))
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            (matrix[j, col], matrix[j+1, col]) = (matrix[j+1, col], matrix[j, col]);
                        }
                    }
                }
            }
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(0) - 1 - i; j++)
                {
                    if (GetRowMax(matrix, j) < GetRowMax(matrix, j + 1))
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            (matrix[j, col], matrix[j + 1, col]) = (matrix[j + 1, col], matrix[j, col]);
                        }
                    }
                }
            }
        }
        public int GetRowMax(int[,] matrix, int row)
        {
            int max = matrix[row, 0];
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > max)
                    max = matrix[row, j]; 
            }
            return max;
        }
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public delegate void SortRowsByMax(int[,] matrix);
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            // code here
            negatives = find(matrix);
            // end

            return negatives;
        }
        public delegate int[] FindNegatives(int[,] matrix);
        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int[] NegativesInRow = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                        count++;
                }
                NegativesInRow[i] = count;
            }
            return NegativesInRow;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int[] MaxNegativesInColumn = new int[matrix.GetLength(1)];

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int max = int.MinValue;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > max && matrix[i, j] < 0)
                        max = matrix[i, j];
                }
                if (max == int.MinValue)
                    MaxNegativesInColumn[j] = 0;
                else
                    MaxNegativesInColumn[j] = max;
            }
            return MaxNegativesInColumn;
        }
        public delegate int[,] MathInfo(int[,] matrix);
        public int[,] DefineSeq(int[,] matrix)
        {
            bool allYEqual = true;
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[1, j] != matrix[1, j + 1])
                {
                    allYEqual = false;
                    break;
                }
            }
            if (allYEqual)
                return new int[0, 0];

            int seq = 0;
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                double y1 = matrix[1, j]; double y2 = matrix[1, j + 1];
                if (y1 < y2)
                {
                    seq = 1;
                    break;
                }
                else if (y1 > y2)
                {
                    seq = -1;
                    break;
                }
            }

            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                double y1 = matrix[1, j]; double y2 = matrix[1, j + 1];
                if (seq == 1)
                {
                    if (y1 > y2)
                        return new int[1, 1] { { 0 } };
                }
                else if (seq == -1)
                {
                    if (y1 < y2)
                        return new int[1, 1] { { 0 } };
                }
            }

            return new int[1, 1] { { seq } };
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            bool allYEqual = true;
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[1, j] != matrix[1, j + 1])
                {
                    allYEqual = false;
                    break;
                }
            }
            if (allYEqual)
                return new int[0, 0];

            int count = 0;
            int seqPrev = 0; int seqCurr = 0;

            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[1, j] < matrix[1, j + 1])
                    seqCurr = 1;
                else if (matrix[1, j] > matrix[1, j + 1])
                    seqCurr = -1;

                if (seqCurr != seqPrev)
                {
                    count++;
                    seqPrev = seqCurr;
                }
                else if (seqPrev == 0)
                {
                    seqPrev = seqCurr;
                }
            }

            int[,] allSeq = new int[count, 2];
            int seqIndex = 0; int firstIndex = 0;

            seqPrev = 0;
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[1, j] < matrix[1, j + 1])
                    seqCurr = 1;
                else if (matrix[1, j] > matrix[1, j + 1])
                    seqCurr = -1;

                if (seqPrev == 0)
                {
                    seqPrev = seqCurr;
                    firstIndex = j;
                }
                else if (seqCurr != seqPrev)
                {

                    allSeq[seqIndex, 0] = matrix[0, firstIndex];
                    allSeq[seqIndex, 1] = matrix[0, j];
                    seqIndex++;

                    firstIndex = j;
                    seqPrev = seqCurr;
                }
            }

            allSeq[seqIndex, 0] = matrix[0, firstIndex];
            allSeq[seqIndex, 1] = matrix[0, matrix.GetLength(1) - 1];

            return allSeq;
        }
        public int[,] FindLongestSeq(int[,] matrix)
        {
            int[,] allSeq = FindAllSeq(matrix);

            if (allSeq.GetLength(0) == 0)
                return new int[0, 0];

            int longestLen = allSeq[0, 1] - allSeq[0, 0];
            int longestIndex = 0;

            for (int i = 0; i < allSeq.GetLength(0); i++)
            {
                int currentLen = allSeq[i, 1] - allSeq[i, 0];
                if (currentLen > longestLen)
                {
                    longestLen = currentLen;
                    longestIndex = i;
                }
            }
            return new int[1, 2] { { allSeq[longestIndex, 0], allSeq[longestIndex, 1] } };
        }
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here
            answer = info(matrix);
            // end

            return answer;
        }
        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            int count = 0;
            for (double x = a; x <= b - h; x += h)
            {
                double y1 = func(x);
                double y2 = func(x + h);

                if ((y1 > 0 && y2 < 0) || (y1 < 0 && y2 > 0))
                {
                    count++;
                }
            }
            return count;
        }
        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            if (h <= 0 || b <= a) return 0;

            int count = 0;
            double prevY = func(a);
            double lastNonZeroY = Math.Abs(prevY) > 0.0001 ? prevY : 0;

            for (double x = a + h; x <= b + 0.0001; x += h)
            {
                double currentX = Math.Min(x, b);
                double currentY = func(currentX);
                if (Math.Abs(currentY) < 0.0001)
                    continue;
                if (Math.Abs(lastNonZeroY) > 0.0001)
                {
                    if (lastNonZeroY * currentY < 0)
                    {
                        count++;
                    }
                }
                lastNonZeroY = currentY;

                if (Math.Abs(currentX - b) < 0.0001)
                    break;
            }

            return count;
        }
        public double FuncA(double x)
        {
            return Math.Pow(x, 2) - Math.Sin(x);
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
                if (i % 2 == 0)
                    Array.Sort(array[i]);
                else
                {
                    Array.Sort(array[i]);
                    Array.Reverse(array[i]);
                }
            }
        }
        public void SortBySumDesc(int[][] array)
        {
            for (int k = 0; k < array.Length - 1; k++)
            {
                for (int i = 0; i < array.Length - 1 - k; i++)
                {
                    int sum1 = 0; int sum2 = 0;

                    for (int j = 0; j < array[i].Length; j++)
                        sum1 += array[i][j];

                    for (int j = 0; j < array[i + 1].Length; j++)
                        sum2 += array[i + 1][j];

                    if (sum1 < sum2)
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
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
    }
}