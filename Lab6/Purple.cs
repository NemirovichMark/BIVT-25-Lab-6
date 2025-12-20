using System;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public void Task1(int[,] A, int[,] B)
        {

            // code here

            int An = A.GetLength(0), Am = A.GetLength(1);
            int Bn = B.GetLength(0), Bm = B.GetLength(1);

            if (An != Am) return;
            if (Bn != Bm) return;
            if (An != Bn) return;

            int rowIndexA = FindDiagonalMaxIndex(A);
            int columnIndexB = FindDiagonalMaxIndex(B);
            SwapRowColumn(A, rowIndexA, B, columnIndexB);

            // end

        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0);

            int maxElement = matrix[0, 0];
            int maxIndex = 0;

            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > maxElement)
                {
                    maxElement = matrix[i, i];
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
                int temp = matrix[rowIndex, i];
                matrix[rowIndex, i] = B[i, columnIndex];
                B[i, columnIndex] = temp;
            }
        }

        public void Task2(ref int[,] A, int[,] B)
        {

            // code here

            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);

            if (colsA != rowsB)
            {
                return;
            }

            int maxPositiveCountInColumnB = -1;
            int bestColumnIndexB = -1;

            for (int j = 0; j < colsB; j++)
            {
                int currentCount = CountPositiveElementsInColumn(B, j);
                if (currentCount > maxPositiveCountInColumnB)
                {
                    maxPositiveCountInColumnB = currentCount;
                    bestColumnIndexB = j;
                }
            }

            if (maxPositiveCountInColumnB <= 0)
            {
                return;
            }

            int maxPositiveCountInRowA = -1;
            int insertAfterRowIndex = -1;

            for (int i = 0; i < rowsA; i++)
            {
                int currentCount = CountPositiveElementsInRow(A, i);
                if (currentCount > maxPositiveCountInRowA)
                {
                    maxPositiveCountInRowA = currentCount;
                    insertAfterRowIndex = i;
                }
            }

            if (insertAfterRowIndex == -1)
            {
                insertAfterRowIndex = rowsA - 1;
            }

            InsertColumn(ref A, insertAfterRowIndex, bestColumnIndexB, B);

            // end

        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int oldRowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);

            int[,] newA = new int[oldRowsA + 1, colsA];

            for (int i = 0; i <= rowIndex; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    newA[i, j] = A[i, j];
                }
            }

            for (int j = 0; j < colsA; j++)
            {

                newA[rowIndex + 1, j] = B[j, columnIndex];
            }

            for (int i = rowIndex + 1; i < oldRowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    newA[i + 1, j] = A[i, j];
                }
            }

            A = newA;
        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int count = 0;
            int cols = matrix.GetLength(1);
            for (int j = 0; j < cols; j++)
            {
                if (matrix[row, j] > 0)
                {
                    count++;
                }
            }
            return count;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int count = 0;
            int rows = matrix.GetLength(0);
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, col] > 0)
                {
                    count++;
                }
            }
            return count;
        }

        public void Task3(int[,] matrix)
        {

            // code here

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows == 0 || cols == 0) return;

            ChangeMatrixValues(matrix);

            // end

        }
        public void ChangeMatrixValues(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int totalElements = rows * cols;

            if (totalElements < 5)
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

            int[] values = new int[totalElements];
            int[] rowsIndices = new int[totalElements];
            int[] colsIndices = new int[totalElements];

            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    values[index] = matrix[i, j];
                    rowsIndices[index] = i;
                    colsIndices[index] = j;
                    index++;
                }
            }

            for (int i = 0; i < totalElements - 1; i++)
            {
                for (int j = 0; j < totalElements - i - 1; j++)
                {
                    if (values[j] < values[j + 1])
                    {
                        int tempVal = values[j];
                        values[j] = values[j + 1];
                        values[j + 1] = tempVal;

                        int tempRow = rowsIndices[j];
                        rowsIndices[j] = rowsIndices[j + 1];
                        rowsIndices[j + 1] = tempRow;

                        int tempCol = colsIndices[j];
                        colsIndices[j] = colsIndices[j + 1];
                        colsIndices[j + 1] = tempCol;
                    }
                }
            }

            bool[,] toDouble = new bool[rows, cols];

            for (int i = 0; i < 5; i++)
            {
                toDouble[rowsIndices[i], colsIndices[i]] = true;
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (toDouble[i, j])
                    {
                        matrix[i, j] *= 2;
                    }
                    else
                    {
                        matrix[i, j] /= 2;
                    }
                }
            }
        }

        public void Task4(int[,] A, int[,] B)
        {

            // code here

            int rowsA = A.GetLength(0);
            int rowsB = B.GetLength(0);
            int colsA = A.GetLength(1);
            int colsB = B.GetLength(1);

            if (rowsA == 0 || colsA == 0 || rowsB == 0 || colsB == 0)
            {
                return;
            }

            int[] negCountA = CountNegativesPerRow(A);
            int[] negCountB = CountNegativesPerRow(B);

            int maxNegRowA = FindMaxIndex(negCountA);
            int maxNegRowB = FindMaxIndex(negCountB);

            bool hasNegativesInA = negCountA[maxNegRowA] > 0;
            bool hasNegativesInB = negCountB[maxNegRowB] > 0;

            if (hasNegativesInA && hasNegativesInB)
            {
                if (colsA == colsB)
                {
                    for (int j = 0; j < colsA; j++)
                    {
                        int temp = A[maxNegRowA, j];
                        A[maxNegRowA, j] = B[maxNegRowB, j];
                        B[maxNegRowB, j] = temp;
                    }
                }
                else
                {
                    return;
                }
            }

            // end

        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] negativesPerRow = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
                negativesPerRow[i] = count;
            }

            return negativesPerRow;
        }
        public int FindMaxIndex(int[] array)
        {
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

        public void Task5(int[] matrix, Sorting sort)
        {

            // code here

            sort(matrix);

            // end

        }
        public delegate void Sorting(int[] matrix);
        public void SortNegativeAscending(int[] matrix)
        {
            int negativeCount = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    negativeCount++;
                }
            }

            if (negativeCount == 0) return;

            int[] negativeValues = new int[negativeCount];
            int[] negativeIndices = new int[negativeCount];

            int index = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    negativeValues[index] = matrix[i];
                    negativeIndices[index] = i;
                    index++;
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
                matrix[negativeIndices[i]] = negativeValues[i];
            }
        }
        public void SortNegativeDescending(int[] matrix)
        {
            int negativeCount = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    negativeCount++;
                }
            }

            if (negativeCount == 0) return;

            int[] negativeValues = new int[negativeCount];
            int[] negativeIndices = new int[negativeCount];

            int index = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    negativeValues[index] = matrix[i];
                    negativeIndices[index] = i;
                    index++;
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
                matrix[negativeIndices[i]] = negativeValues[i];
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

            int[] tempRow = new int[cols];

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    int max1 = GetRowMax(matrix, j);
                    int max2 = GetRowMax(matrix, j + 1);

                    if (max1 > max2)
                    {
                        for (int k = 0; k < cols; k++)
                        {
                            tempRow[k] = matrix[j, k];
                        }

                        for (int k = 0; k < cols; k++)
                        {
                            matrix[j, k] = matrix[j + 1, k];
                        }

                        for (int k = 0; k < cols; k++)
                        {
                            matrix[j + 1, k] = tempRow[k];
                        }
                    }
                }
            }
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] tempRow = new int[cols];

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    int max1 = GetRowMax(matrix, j);
                    int max2 = GetRowMax(matrix, j + 1);

                    if (max1 < max2)
                    {
                        for (int k = 0; k < cols; k++)
                        {
                            tempRow[k] = matrix[j, k];
                        }

                        for (int k = 0; k < cols; k++)
                        {
                            matrix[j, k] = matrix[j + 1, k];
                        }

                        for (int k = 0; k < cols; k++)
                        {
                            matrix[j + 1, k] = tempRow[k];
                        }
                    }
                }
            }
        }
        public int GetRowMax(int[,] matrix, int row)
        {

            int cols = matrix.GetLength(1);
            int max = matrix[row, 0];

            for (int j = 1; j < cols; j++)
            {
                if (matrix[row, j] > max)
                {
                    max = matrix[row, j];
                }
            }

            return max;
        }

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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] result = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
                result[i] = count;
            }

            return result;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] result = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                int maxNegative = 0;
                bool foundNegative = false;

                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        if (!foundNegative)
                        {
                            maxNegative = matrix[i, j];
                            foundNegative = true;
                        }
                        else if (matrix[i, j] > maxNegative)
                        {
                            maxNegative = matrix[i, j];
                        }
                    }
                }
                result[j] = foundNegative ? maxNegative : 0;
            }
            return result;
        }

        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != 2 || cols < 2)
            {
                return new int[0, 0];
            }

            answer = info(matrix);

            // end

            return answer;
        }
        public delegate int[,] MathInfo(int[,] matrix);
        private bool AreAllElementsEqual(int[] array)
        {
            if (array.Length == 0) return true;

            int first = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] != first)
                {
                    return false;
                }
            }
            return true;
        }
        private int[] GetYArray(int[,] matrix)
        {
            int cols = matrix.GetLength(1);
            int[] yArray = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                yArray[j] = matrix[1, j];
            }

            return yArray;
        }
        private int[] GetXArray(int[,] matrix)
        {
            int cols = matrix.GetLength(1);
            int[] xArray = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                xArray[j] = matrix[0, j];
            }

            return xArray;
        }

        public int[,] DefineSeq(int[,] matrix)
        {
            int cols = matrix.GetLength(1);
            int[] yArray = GetYArray(matrix);

            if (AreAllElementsEqual(yArray))
            {
                return new int[0, 0];
            }

            bool isIncreasing = true;
            bool isDecreasing = true;

            for (int j = 0; j < cols - 1; j++)
            {
                int y1 = matrix[1, j];
                int y2 = matrix[1, j + 1];

                if (y1 > y2) isIncreasing = false;
                if (y1 < y2) isDecreasing = false;
            }

            int[,] result = new int[1, 1];

            if (isIncreasing)
            {
                result[0, 0] = 1;
            }
            else if (isDecreasing)
            {
                result[0, 0] = -1;
            }
            else
            {
                result[0, 0] = 0;
            }

            return result;
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            int cols = matrix.GetLength(1);
            int[] xArray = GetXArray(matrix);
            int[] yArray = GetYArray(matrix);

            if (AreAllElementsEqual(yArray))
            {
                return new int[0, 0];
            }

            int intervalCount = 1;
            int start = 0;
            bool isNonDecreasing = true;
            bool isNonIncreasing = true;

            for (int j = 0; j < cols - 1; j++)
            {
                int diff = yArray[j + 1] - yArray[j];

                bool canBeNonDecreasing = isNonDecreasing && (diff >= 0);
                bool canBeNonIncreasing = isNonIncreasing && (diff <= 0);

                if (canBeNonDecreasing || canBeNonIncreasing)
                {
                    isNonDecreasing = canBeNonDecreasing;
                    isNonIncreasing = canBeNonIncreasing;
                }
                else
                {
                    intervalCount++;
                    start = j;
                    isNonDecreasing = true;
                    isNonIncreasing = true;

                    diff = yArray[j + 1] - yArray[j];
                    isNonDecreasing = (diff >= 0);
                    isNonIncreasing = (diff <= 0);
                }
            }

            int[] startPoints = new int[intervalCount];
            int[] endPoints = new int[intervalCount];

            int intervalIndex = 0;
            start = 0;
            isNonDecreasing = true;
            isNonIncreasing = true;

            for (int j = 0; j < cols - 1; j++)
            {
                int diff = yArray[j + 1] - yArray[j];

                bool canBeNonDecreasing = isNonDecreasing && (diff >= 0);
                bool canBeNonIncreasing = isNonIncreasing && (diff <= 0);

                if (canBeNonDecreasing || canBeNonIncreasing)
                {
                    isNonDecreasing = canBeNonDecreasing;
                    isNonIncreasing = canBeNonIncreasing;
                }
                else
                {
                    startPoints[intervalIndex] = xArray[start];
                    endPoints[intervalIndex] = xArray[j];
                    intervalIndex++;

                    start = j;
                    isNonDecreasing = true;
                    isNonIncreasing = true;

                    diff = yArray[j + 1] - yArray[j];
                    isNonDecreasing = (diff >= 0);
                    isNonIncreasing = (diff <= 0);
                }
            }

            startPoints[intervalIndex] = xArray[start];
            endPoints[intervalIndex] = xArray[cols - 1];

            for (int i = 0; i < intervalCount - 1; i++)
            {
                for (int j = 0; j < intervalCount - i - 1; j++)
                {
                    if (startPoints[j] > startPoints[j + 1] ||
                        (startPoints[j] == startPoints[j + 1] && endPoints[j] > endPoints[j + 1]))
                    {
                        int tempStart = startPoints[j];
                        startPoints[j] = startPoints[j + 1];
                        startPoints[j + 1] = tempStart;

                        int tempEnd = endPoints[j];
                        endPoints[j] = endPoints[j + 1];
                        endPoints[j + 1] = tempEnd;
                    }
                }
            }

            // Создаем результирующую матрицу
            int[,] result = new int[intervalCount, 2];

            for (int i = 0; i < intervalCount; i++)
            {
                result[i, 0] = startPoints[i];
                result[i, 1] = endPoints[i];
            }

            return result;
        }

        public int[,] FindLongestSeq(int[,] matrix)
        {
            int cols = matrix.GetLength(1);
            int[] xArray = GetXArray(matrix);
            int[] yArray = GetYArray(matrix);

            if (AreAllElementsEqual(yArray))
            {
                return new int[0, 0];
            }

            int longestStart = 0;
            int longestEnd = 0;
            int longestLength = 0;

            int start = 0;
            bool isNonDecreasing = true;
            bool isNonIncreasing = true;

            for (int j = 0; j < cols - 1; j++)
            {
                int diff = yArray[j + 1] - yArray[j];

                bool canBeNonDecreasing = isNonDecreasing && (diff >= 0);
                bool canBeNonIncreasing = isNonIncreasing && (diff <= 0);

                if (canBeNonDecreasing || canBeNonIncreasing)
                {
                    isNonDecreasing = canBeNonDecreasing;
                    isNonIncreasing = canBeNonIncreasing;

                    int currentLength = Math.Abs(xArray[j + 1] - xArray[start]);
                    if (currentLength > longestLength)
                    {
                        longestLength = currentLength;
                        longestStart = start;
                        longestEnd = j + 1;
                    }
                }
                else
                {
                    int currentLength = Math.Abs(xArray[j] - xArray[start]);
                    if (currentLength > longestLength)
                    {
                        longestLength = currentLength;
                        longestStart = start;
                        longestEnd = j;
                    }

                    start = j;
                    isNonDecreasing = true;
                    isNonIncreasing = true;

                    diff = yArray[j + 1] - yArray[j];
                    isNonDecreasing = (diff >= 0);
                    isNonIncreasing = (diff <= 0);

                    currentLength = Math.Abs(xArray[j + 1] - xArray[start]);
                    if (currentLength > longestLength)
                    {
                        longestLength = currentLength;
                        longestStart = start;
                        longestEnd = j + 1;
                    }
                }
            }

            int lastLength = Math.Abs(xArray[cols - 1] - xArray[start]);
            if (lastLength > longestLength)
            {
                longestLength = lastLength;
                longestStart = start;
                longestEnd = cols - 1;
            }

            int[,] result = new int[1, 2];
            result[0, 0] = xArray[longestStart];
            result[0, 1] = xArray[longestEnd];

            return result;
        }

        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            // code here

            if (h <= 0)
            {
                return 0;
            }

            if (a > b)
            {
                double temp = a;
                a = b;
                b = temp;
            }

            answer = CountSignFlips(a, b, h, func);

            // end

            return answer;
        }
        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            int signChanges = 0;

            double x = a;
            double yPrev = func(x);
            int prevSign = Math.Sign(yPrev);

            while (x <= b)
            {
                x += h;

                if (x > b)
                {
                    x = b;
                }

                double yCurrent = func(x);
                int currentSign = Math.Sign(yCurrent);

                if (prevSign != 0 && currentSign != 0 && prevSign != currentSign)
                {
                    signChanges++;
                }

                if (currentSign != 0)
                {
                    prevSign = currentSign;
                }

                if (Math.Abs(x - b) < 1e-10)
                {
                    break;
                }
            }

            return signChanges;
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
                if (array[i] == null) continue;

                if (i % 2 == 0)
                {
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
                }
                else
                {
                    for (int j = 0; j < array[i].Length - 1; j++)
                    {
                        for (int k = 0; k < array[i].Length - j - 1; k++)
                        {
                            if (array[i][k] < array[i][k + 1])
                            {
                                int temp = array[i][k];
                                array[i][k] = array[i][k + 1];
                                array[i][k + 1] = temp;
                            }
                        }
                    }
                }
            }
        }
        public void SortBySumDesc(int[][] array)
        {
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
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (sums[j] < sums[j + 1])
                    {
                        int[] tempArray = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tempArray;

                        int tempSum = sums[j];
                        sums[j] = sums[j + 1];
                        sums[j + 1] = tempSum;
                    }
                }
            }
        }

        public void TotalReverse(int[][] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                int[] temp = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = temp;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    for (int j = 0; j < array[i].Length / 2; j++)
                    {
                        int temp = array[i][j];
                        array[i][j] = array[i][array[i].Length - 1 - j];
                        array[i][array[i].Length - 1 - j] = temp;
                    }
                }
            }
        }
    }
}