using System;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int max = int.MinValue;
            int maxindex = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    maxindex = i;
                }
            }
            return maxindex;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            int temp = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                temp = matrix[rowIndex, i];
                matrix[rowIndex,i] = B[i, columnIndex];
                B[i, columnIndex] = temp;
            }
        }
        public void Task1(int[,] A, int[,] B)
        {

            // code here
            int na = A.GetLength(0);
            int ma = A.GetLength(1);
            int nb = B.GetLength(0);
            int mb = B.GetLength(1);
            if (na != ma || mb != nb || na != nb || A == null || B == null)
            {
                return;
            }

            int rowindex = FindDiagonalMaxIndex(A);
            int columnindex = FindDiagonalMaxIndex(B);
            SwapRowColumn(A, rowindex, B, columnindex);
            // end

        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int positiveCount = 0;
            int columns = matrix.GetLength(1);
            if (columns == 0 || matrix.GetLength(0) == 0)
            {
                return 0;
            }
            for (int col = 0; col < columns; col++)
            {
                if (matrix[row, col] > 0)
                {
                    positiveCount++;
                }
            }
            return positiveCount;
        }

        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int positiveCount = 0;
            int rows = matrix.GetLength(0);
            if (rows == 0 || matrix.GetLength(1) == 0)
            {
                return 0;
            }
            for (int row = 0; row < rows; row++)
            {
                if (matrix[row, col] > 0)
                {
                    positiveCount++;
                }
            }
            return positiveCount;
        }

        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int rowsA = A.GetLength(0);
            int rowsB = B.GetLength(0);
            int colsA = A.GetLength(1);
            int colsB = B.GetLength(1);

            int[,] newMatrix = new int[rowsA + 1, colsA];
            for (int i = 0; i < rowsA + 1; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    if (i > rowIndex + 1)
                    {
                        newMatrix[i, j] = A[i - 1, j];
                    }
                    else if (i == rowIndex + 1)
                    {
                        newMatrix[i, j] = B[j, columnIndex];
                    }
                    else
                    {
                        newMatrix[i, j] = A[i, j];
                    }
                }
            }
            A = newMatrix;
        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            int rowsA = A.GetLength(0);
            int rowsB = B.GetLength(0);
            int colsA = A.GetLength(1);
            int colsB = B.GetLength(1);

            if (colsA != rowsB)
            {
                return;
            }

            int bestRowIndex = 0;
            int maxPositiveInRow = 0;
            int bestColumnIndex = 0;
            int maxPositiveInColumn = 0;

            for (int col = 0; col < colsB; col++)
            {
                int positiveCount = CountPositiveElementsInColumn(B, col);
                if (positiveCount > maxPositiveInColumn)
                {
                    bestColumnIndex = col;
                    maxPositiveInColumn = positiveCount;
                }
            }

            for (int row = 0; row < rowsA; row++)
            {
                int positiveCount = CountPositiveElementsInRow(A, row);
                if (positiveCount > maxPositiveInRow)
                {
                    bestRowIndex = row;
                    maxPositiveInRow = positiveCount;
                }
            }

            if (maxPositiveInColumn == 0)
            {
                return;
            }
            InsertColumn(ref A, bestRowIndex, bestColumnIndex, B);

        }
        public void ChangeMatrixValues(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int totalElements = rows * cols;

            int elementsToIncrease = 5;


            if (totalElements < elementsToIncrease)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] *= 2;
                    }
                }
                return;
            }


            int[,] tempMatrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    tempMatrix[i, j] = matrix[i, j];
                }
            }


            int[,] maxElementPositions = new int[elementsToIncrease, 2];

            int foundCount = 0;
            int minIntValue = int.MinValue;

            while (foundCount < elementsToIncrease)
            {
                int maxValue = minIntValue;
                int maxRow = 0;
                int maxCol = 0;


                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (tempMatrix[i, j] > maxValue)
                        {
                            maxValue = tempMatrix[i, j];
                            maxRow = i;
                            maxCol = j;
                        }
                    }
                }


                maxElementPositions[foundCount, 0] = maxRow;
                maxElementPositions[foundCount, 1] = maxCol;


                tempMatrix[maxRow, maxCol] = minIntValue;
                foundCount++;
            }


            for (int i = 0; i < elementsToIncrease; i++)
            {
                int row = maxElementPositions[i, 0];
                int col = maxElementPositions[i, 1];
                matrix[row, col] *= 4;
            }


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] /= 2;
                }
            }
        }
        public void Task3(int[,] matrix)
        {

            // code here
            ChangeMatrixValues(matrix);
            // end

        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            if (matrix == null) return new int[0];

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] counts = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int count = 0;

                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                        count++;
                }

                counts[i] = count;
            }

            return counts;
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

            // code here
            int rowsA = A.GetLength(0);
            int rowsB = B.GetLength(0);
            int colsA = A.GetLength(1);
            int colsB = B.GetLength(1);

            if (colsA != colsB)
            {
                return;
            }

            int[] negativesInRowsA = CountNegativesPerRow(A);
            int[] negativesInRowsB = CountNegativesPerRow(B);

            int maxRowIndexA = FindMaxIndex(negativesInRowsA);
            int maxRowIndexB = FindMaxIndex(negativesInRowsB);

            if (negativesInRowsA[maxRowIndexA] <= 0)
            {
                return;
            }
            if (negativesInRowsB[maxRowIndexB] <= 0)
            {
                return;
            }

            for (int col = 0; col < colsA; col++)
            {
                (A[maxRowIndexA, col], B[maxRowIndexB, col]) = (B[maxRowIndexB, col], A[maxRowIndexA, col]);
            }
            // end

        }
        public delegate void Sorting(int[] matrix);

        public void SortNegativeAscending(int[] array)
        {
            if (array == null || array.Length == 0) return;

            int negativeCount = 0;
            int[] negativeValues = new int[array.Length];
            int[] negativePositions = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    negativeValues[negativeCount] = array[i];
                    negativePositions[negativeCount] = i;
                    negativeCount++;
                }
            }


            for (int i = 0; i < negativeCount - 1; i++)
            {
                for (int j = 0; j < negativeCount - i - 1; j++)
                {
                    if (negativeValues[j] > negativeValues[j + 1])
                    {
                        int temp = negativeValues[j];
                        negativeValues[j] = negativeValues[j + 1];
                        negativeValues[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < negativeCount; i++)
            {
                array[negativePositions[i]] = negativeValues[i];
            }
        }

        public void SortNegativeDescending(int[] array)
        {
            if (array == null || array.Length == 0) return;

            int negativeCount = 0;
            int[] negativeValues = new int[array.Length];
            int[] negativePositions = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    negativeValues[negativeCount] = array[i];
                    negativePositions[negativeCount] = i;
                    negativeCount++;
                }
            }

            for (int i = 0; i < negativeCount - 1; i++)
            {
                for (int j = 0; j < negativeCount - i - 1; j++)
                {
                    if (negativeValues[j] < negativeValues[j + 1]) 
                    {
                        int temp = negativeValues[j];
                        negativeValues[j] = negativeValues[j + 1];
                        negativeValues[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < negativeCount; i++)
            {
                array[negativePositions[i]] = negativeValues[i];
            }
        }

        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            if (matrix == null || sort == null) return;

            sort(matrix);
            // end

        }
        public delegate void SortRowsByMax(int[,] matrix);

        public int GetRowMax(int[,] matrix, int row)
        {
            if (matrix == null || row < 0 || row >= matrix.GetLength(0))
                return 0;

            int cols = matrix.GetLength(1);
            if (cols == 0) return 0;

            int max = matrix[row, 0];

            for (int j = 1; j < cols; j++)
            {
                if (matrix[row, j] > max)
                    max = matrix[row, j];
            }

            return max;
        }

        public void SortRowsByMaxAscending(int[,] matrix)
        {
            if (matrix == null) return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows <= 1) return;

            int[] maxValues = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                maxValues[i] = GetRowMax(matrix, i);
            }

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    if (maxValues[j] > maxValues[j + 1])
                    {
                        SwapRows(matrix, j, j + 1);

                        int temp = maxValues[j];
                        maxValues[j] = maxValues[j + 1];
                        maxValues[j + 1] = temp;
                    }
                }
            }
        }

        public void SortRowsByMaxDescending(int[,] matrix)
        {
            if (matrix == null) return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows <= 1) return;

            int[] maxValues = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                maxValues[i] = GetRowMax(matrix, i);
            }

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    if (maxValues[j] < maxValues[j + 1]) 
                    {
                        SwapRows(matrix, j, j + 1);

                        int temp = maxValues[j];
                        maxValues[j] = maxValues[j + 1];
                        maxValues[j + 1] = temp;
                    }
                }
            }
        }

        private void SwapRows(int[,] matrix, int row1, int row2)
        {
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                int temp = matrix[row1, j];
                matrix[row1, j] = matrix[row2, j];
                matrix[row2, j] = temp;
            }
        }
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here
            if (matrix == null || sort == null) return;
            sort(matrix);
            // end

        }
        public delegate int[] FindNegatives(int[,] matrix);

        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            if (matrix == null) return new int[0];

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] result = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                        count++;
                }
                result[i] = count;
            }

            return result;
        }

        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            if (matrix == null) return new int[0];

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] result = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                int maxNegative = 0;

                for (int i = 0; i < rows; i++)
                {
                    int current = matrix[i, j];

                    if (current < 0)
                    {
                        if (maxNegative == 0 || current > maxNegative)
                        {
                            maxNegative = current;
                        }
                    }
                }

                result[j] = maxNegative;
            }

            return result;
        }
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            // code here
            if (matrix == null || find == null)
                return new int[0];

            return find(matrix);
            // end

            return negatives;
        }
        public delegate int[,] MathInfo(int[,] matrix);

        public int[,] DefineSeq(int[,] matrix)
        {
            bool allYEqual = true;
            for (int colIndex = 1; colIndex < matrix.GetLength(1); colIndex++)
            {
                if (matrix[1, colIndex] != matrix[1, colIndex + 1])
                {
                    allYEqual = false;
                    break;
                }
            }
            if (allYEqual)
                return new int[0, 0];

            int sequenceType = 0;
            for (int colIndex = 0; colIndex < matrix.GetLength(1) - 1; colIndex++)
            {
                double yCurrent = matrix[1, colIndex];
                double yNext = matrix[1, colIndex + 1];
                if (yCurrent < yNext)
                {
                    sequenceType = 1;
                    break;
                }
                else if (yCurrent > yNext)
                {
                    sequenceType = -1;
                    break;
                }
            }

            for (int colIndex = 0; colIndex < matrix.GetLength(1) - 1; colIndex++)
            {
                double yCurrent = matrix[1, colIndex];
                double yNext = matrix[1, colIndex + 1];
                if (sequenceType == 1)
                {
                    if (yCurrent > yNext)
                        return new int[1, 1] { { 0 } };
                }
                else if (sequenceType == -1)
                {
                    if (yCurrent < yNext)
                        return new int[1, 1] { { 0 } };
                }
            }

            return new int[1, 1] { { sequenceType } };
        }

        public int[,] FindAllSeq(int[,] matrix)
        {
            bool allYEqual = true;
            for (int colIndex = 1; colIndex < matrix.GetLength(1); colIndex++)
            {
                if (matrix[1, colIndex] != matrix[1, colIndex + 1])
                {
                    allYEqual = false;
                    break;
                }
            }
            if (allYEqual)
                return new int[0, 0];

            int intervalCount = 0;
            int previousSequenceType = 0;
            int currentSequenceType = 0;

            for (int colIndex = 0; colIndex < matrix.GetLength(1) - 1; colIndex++)
            {
                if (matrix[1, colIndex] < matrix[1, colIndex + 1])
                    currentSequenceType = 1;
                else if (matrix[1, colIndex] > matrix[1, colIndex + 1])
                    currentSequenceType = -1;

                if (currentSequenceType != previousSequenceType)
                {
                    intervalCount++;
                    previousSequenceType = currentSequenceType;
                }
                else if (previousSequenceType == 0)
                {
                    previousSequenceType = currentSequenceType;
                }
            }

            int[,] allSequences = new int[intervalCount, 2];
            int sequenceIndex = 0;
            int startIndex = 0;

            previousSequenceType = 0;
            for (int colIndex = 0; colIndex < matrix.GetLength(1) - 1; colIndex++)
            {
                if (matrix[1, colIndex] < matrix[1, colIndex + 1])
                    currentSequenceType = 1;
                else if (matrix[1, colIndex] > matrix[1, colIndex + 1])
                    currentSequenceType = -1;

                if (previousSequenceType == 0)
                {
                    previousSequenceType = currentSequenceType;
                    startIndex = colIndex;
                }
                else if (currentSequenceType != previousSequenceType)
                {
                    allSequences[sequenceIndex, 0] = matrix[0, startIndex];
                    allSequences[sequenceIndex, 1] = matrix[0, colIndex];
                    sequenceIndex++;

                    startIndex = colIndex;
                    previousSequenceType = currentSequenceType;
                }
            }

            allSequences[sequenceIndex, 0] = matrix[0, startIndex];
            allSequences[sequenceIndex, 1] = matrix[0, matrix.GetLength(1) - 1];

            return allSequences;
        }

        public int[,] FindLongestSeq(int[,] matrix)
        {
            int[,] allSequences = FindAllSeq(matrix);

            if (allSequences.GetLength(0) == 0)
                return new int[0, 0];

            int longestLength = allSequences[0, 1] - allSequences[0, 0];
            int longestIndex = 0;

            for (int i = 0; i < allSequences.GetLength(0); i++)
            {
                int currentLength = allSequences[i, 1] - allSequences[i, 0];
                if (currentLength > longestLength)
                {
                    longestLength = currentLength;
                    longestIndex = i;
                }
            }

            return new int[1, 2] { { allSequences[longestIndex, 0], allSequences[longestIndex, 1] } };
        }
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here
            if (matrix == null || info == null)
                return new int[0, 0];

            answer = info(matrix);
            // end

            return answer;
        }

        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            int flipCount = 0;
            int previousSign = Math.Sign(func(a));
            double currentX = a + h;
            int currentSign = Math.Sign(func(a + h));

            for (double x = currentX; x <= b; x += h)
            {
                double functionValue = func(x);
                currentSign = Math.Sign(functionValue);

                if (functionValue == 0)
                {
                    continue;
                }

                if (currentSign != previousSign)
                {
                    flipCount++;
                    previousSign = currentSign;
                }
            }
            return flipCount;
        }

        public delegate double Function(double x);

        public double FuncA(double x)
        {
            double result = x * x - Math.Sin(x);
            return result;
        }

        public double FuncB(double x)
        {
            double result = Math.Exp(x) - 1;
            return result;
        }
        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            // code here

            answer = CountSignFlips(a, b, h, func);
            // end

            return answer;
        }

        public void SortInCheckersOrder(int[][] array)
        {
            if (array == null) return;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null) continue;

                if (i % 2 == 0)
                {
                    Array.Sort(array[i]);
                }
                else 
                {
                    Array.Sort(array[i]);
                    Array.Reverse(array[i]);
                }
            }
        }

        public void SortBySumDesc(int[][] array)
        {
            if (array == null || array.Length <= 1) return;

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    int sum1 = GetArraySum(array[j]);
                    int sum2 = GetArraySum(array[j + 1]);

                    if (sum1 < sum2)
                    {
                        int[] temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        private int GetArraySum(int[] arr)
        {
            if (arr == null) return 0;

            int sum = 0;
            foreach (int num in arr)
            {
                sum += num;
            }
            return sum;
        }

        public void TotalReverse(int[][] array)
        {
            if (array == null) return;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    Array.Reverse(array[i]);
                }
            }

            Array.Reverse(array);
        }
        public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here
            if (array == null || func == null) return;

            func(array);
            // end

        }
    }
}
