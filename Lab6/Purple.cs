using System;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int size = Math.Min(rows, cols);

            (int, int) max = (int.MinValue, 0);
            for (int i = 0; i < size; i++)
            {
                if (matrix[i, i] > max.Item1)
                {
                    max = (matrix[i, i], i);
                }
            }

            return max.Item2;
        }

        public void SwapRowColumn(int[,] A, int rowIndex, int[,] B, int columnIndex)
        {
            int elementsToSwap = Math.Min(
                A.GetLength(1),
                B.GetLength(0)
            );

            for (int i = 0; i < elementsToSwap; i++)
            {
                int temp = A[rowIndex, i];
                A[rowIndex, i] = B[i, columnIndex];
                B[i, columnIndex] = temp;
            }
        }

        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);

            if (rowsB != colsA)
            {
                return;
            }

            int[,] newA = new int[rowsA + 1, colsA];

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

            for (int i = rowIndex + 1; i < rowsA; i++)
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

        public void ChangeMatrixValues(int[,] matrix)
        {
            if (matrix == null) return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int totalElements = rows * cols;

            if (totalElements <= 5)
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

            int[,] elements = new int[totalElements, 3];
            int index = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    elements[index, 0] = matrix[i, j];
                    elements[index, 1] = i;
                    elements[index, 2] = j;
                    index++;
                }
            }

            for (int i = 0; i < totalElements - 1; i++)
            {
                for (int j = 0; j < totalElements - i - 1; j++)
                {
                    bool shouldSwap = false;

                    if (elements[j, 0] < elements[j + 1, 0])
                    {
                        shouldSwap = true;
                    }
                    else if (elements[j, 0] == elements[j + 1, 0])
                    {
                        if (elements[j, 1] > elements[j + 1, 1])
                        {
                            shouldSwap = true;
                        }
                        else if (elements[j, 1] == elements[j + 1, 1])
                        {
                            if (elements[j, 2] > elements[j + 1, 2])
                            {
                                shouldSwap = true;
                            }
                        }
                    }

                    if (shouldSwap)
                    {
                        int tempValue = elements[j, 0];
                        elements[j, 0] = elements[j + 1, 0];
                        elements[j + 1, 0] = tempValue;

                        int tempRow = elements[j, 1];
                        elements[j, 1] = elements[j + 1, 1];
                        elements[j + 1, 1] = tempRow;

                        int tempCol = elements[j, 2];
                        elements[j, 2] = elements[j + 1, 2];
                        elements[j + 1, 2] = tempCol;
                    }
                }
            }

            bool[,] isTopFive = new bool[rows, cols];

            for (int i = 0; i < 5 && i < totalElements; i++)
            {
                int row = elements[i, 1];
                int col = elements[i, 2];
                isTopFive[row, col] = true;
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (isTopFive[i, j])
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

        public int[] CountNegativesPerRow(int[,] matrix)
        {
            if (matrix == null) return null;

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

        public void SortNegativeAscending(int[] array)
        {
            if (array == null || array.Length == 0)
                return;

            int negativeCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    negativeCount++;
                }
            }

            if (negativeCount == 0) return;

            int[] negativeIndices = new int[negativeCount];
            int[] negativeValues = new int[negativeCount];

            int idx = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    negativeIndices[idx] = i;
                    negativeValues[idx] = array[i];
                    idx++;
                }
            }

            Array.Sort(negativeValues);

            for (int i = 0; i < negativeCount; i++)
            {
                array[negativeIndices[i]] = negativeValues[i];
            }
        }


        public void SortNegativeDescending(int[] array)
        {
            if (array == null || array.Length == 0)
                return;

            int negativeCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    negativeCount++;
                }
            }

            if (negativeCount == 0) return;

            int[] negativeIndices = new int[negativeCount];
            int[] negativeValues = new int[negativeCount];

            int idx = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    negativeIndices[idx] = i;
                    negativeValues[idx] = array[i];
                    idx++;
                }
            }

            Array.Sort(negativeValues, (a, b) => b.CompareTo(a));

            for (int i = 0; i < negativeCount; i++)
            {
                array[negativeIndices[i]] = negativeValues[i];
            }
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

                        int tempMax = maxValues[j];
                        maxValues[j] = maxValues[j + 1];
                        maxValues[j + 1] = tempMax;

                        for (int k = 0; k < cols; k++)
                        {
                            int temp = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = temp;
                        }
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

                        int tempMax = maxValues[j];
                        maxValues[j] = maxValues[j + 1];
                        maxValues[j + 1] = tempMax;

                        for (int k = 0; k < cols; k++)
                        {
                            int temp = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = temp;
                        }
                    }
                }
            }
        }

        public int GetRowMax(int[,] matrix, int row)
        {
            if (matrix == null || row < 0 || row >= matrix.GetLength(0))
                return int.MinValue;

            int cols = matrix.GetLength(1);
            int max = matrix[row, 0];

            for (int j = 1; j < cols; j++)
            {
                if (matrix[row, j] > max)
                    max = matrix[row, j];
            }

            return max;
        }

        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            if (matrix == null) return null;

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
            if (matrix == null) return null;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] result = new int[cols];

            for (int j = 0; j < cols; j++)
            {

                int maxNegative = 0;

                bool hasNegative = false;

                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        if (!hasNegative)
                        {

                            maxNegative = matrix[i, j];
                            hasNegative = true;
                        }
                        else if (matrix[i, j] > maxNegative)
                        {
                            maxNegative = matrix[i, j];
                        }
                    }
                }

                result[j] = hasNegative ? maxNegative : 0;
            }

            return result;
        }

        public int[,] DefineSeq(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) < 2)
                return new int[0, 0];

            int cols = matrix.GetLength(1);

            bool allEqual = true;
            for (int j = 1; j < cols; j++)
            {
                if (matrix[1, j] != matrix[1, 0])
                {
                    allEqual = false;
                    break;
                }
            }

            if (allEqual)
                return new int[0, 0];

            bool increasing = true;
            bool decreasing = true;

            for (int j = 0; j < cols - 1; j++)
            {
                if (matrix[1, j] < matrix[1, j + 1])
                    decreasing = false;
                if (matrix[1, j] > matrix[1, j + 1])
                    increasing = false;
            }

            int[,] result = new int[1, 1];

            if (increasing)
                result[0, 0] = 1;
            else if (decreasing)
                result[0, 0] = -1;
            else
                result[0, 0] = 0;

            return result;
        }

        public int[,] FindAllSeq(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) < 2)
                return new int[0, 0];

            int cols = matrix.GetLength(1);

            if (cols < 2)
                return new int[0, 0];


            bool allEqual = true;
            for (int j = 1; j < cols; j++)
            {
                if (matrix[1, j] != matrix[1, 0])
                {
                    allEqual = false;
                    break;
                }
            }

            if (allEqual)
                return new int[0, 0];


            int intervalCount = 0;
            int currentStart = 0;
            int currentDirection = 0;

            for (int j = 0; j < cols - 1; j++)
            {
                int direction = 0;
                if (matrix[1, j] < matrix[1, j + 1])
                    direction = 1;
                else if (matrix[1, j] > matrix[1, j + 1])
                    direction = -1;

                if (currentDirection == 0)
                {
                    currentDirection = direction;
                }
                else if (direction != 0 && direction != currentDirection)
                {
                    intervalCount++;
                    currentDirection = direction;
                }
            }
            intervalCount++;

            int[,] intervals = new int[intervalCount, 2];
            int intervalIndex = 0;

            currentStart = 0;
            currentDirection = 0;

            for (int j = 0; j < cols - 1; j++)
            {
                int direction = 0;
                if (matrix[1, j] < matrix[1, j + 1])
                    direction = 1;
                else if (matrix[1, j] > matrix[1, j + 1])
                    direction = -1;

                if (currentDirection == 0)
                {
                    currentDirection = direction;
                }
                else if (direction != 0 && direction != currentDirection)
                {

                    intervals[intervalIndex, 0] = matrix[0, currentStart];
                    intervals[intervalIndex, 1] = matrix[0, j];
                    intervalIndex++;


                    currentStart = j;
                    currentDirection = direction;
                }
            }


            intervals[intervalIndex, 0] = matrix[0, currentStart];
            intervals[intervalIndex, 1] = matrix[0, cols - 1];

            for (int i = 0; i < intervalCount - 1; i++)
            {
                for (int j = 0; j < intervalCount - i - 1; j++)
                {
                    if (intervals[j, 0] > intervals[j + 1, 0] ||
                        (intervals[j, 0] == intervals[j + 1, 0] && intervals[j, 1] > intervals[j + 1, 1]))
                    {

                        int tempStart = intervals[j, 0];
                        int tempEnd = intervals[j, 1];
                        intervals[j, 0] = intervals[j + 1, 0];
                        intervals[j, 1] = intervals[j + 1, 1];
                        intervals[j + 1, 0] = tempStart;
                        intervals[j + 1, 1] = tempEnd;
                    }
                }
            }

            return intervals;
        }

        public int[,] FindLongestSeq(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) < 2)
                return new int[0, 0];

            int cols = matrix.GetLength(1);

            if (cols < 2)
                return new int[0, 0];

            bool allEqual = true;
            for (int j = 1; j < cols; j++)
            {
                if (matrix[1, j] != matrix[1, 0])
                {
                    allEqual = false;
                    break;
                }
            }

            if (allEqual)
                return new int[0, 0];


            int longestStart = 0;
            int longestEnd = 0;
            double longestLength = 0;

            int currentStart = 0;
            int currentDirection = 0;

            for (int j = 0; j < cols - 1; j++)
            {
                int direction = 0;
                if (matrix[1, j] < matrix[1, j + 1])
                    direction = 1;
                else if (matrix[1, j] > matrix[1, j + 1])
                    direction = -1;

                if (currentDirection == 0)
                {
                    currentDirection = direction;
                }
                else if (direction != 0 && direction != currentDirection)
                {

                    double currentLength = matrix[0, j] - matrix[0, currentStart];
                    if (currentLength > longestLength)
                    {
                        longestLength = currentLength;
                        longestStart = currentStart;
                        longestEnd = j;
                    }

                    currentStart = j;
                    currentDirection = direction;
                }
            }

            double lastLength = matrix[0, cols - 1] - matrix[0, currentStart];
            if (lastLength > longestLength)
            {
                longestStart = currentStart;
                longestEnd = cols - 1;
            }

            int[,] result = new int[1, 2];
            result[0, 0] = matrix[0, longestStart];
            result[0, 1] = matrix[0, longestEnd];

            return result;
        }

        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            if (h <= 0 || a >= b)
                return 0;

            double prevValue = func(a);
            int prevSign = Math.Sign(prevValue);

            for (double x = a + h; x <= b + 1e-12; x += h)
            {
                double currentValue = func(x);
                int currentSign = Math.Sign(currentValue);


                if (currentSign != 0 && prevSign != 0 && currentSign != prevSign)
                {
                    answer++;
                }

                if (currentSign != 0)
                {
                    prevSign = currentSign;
                }

                prevValue = currentValue;
            }

            return answer;
        }


        public double FuncA(double x)
        {
            return x * x - Math.Sin(x);
        }

        public double FuncB(double x)
        {
            return Math.Exp(x) - 1;
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

        public void SortBySumDesc(int[][] array)
        {
            if (array == null) return;


            var sumsWithIndices = new (int Sum, int Index)[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;
                if (array[i] != null)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        sum += array[i][j];
                    }
                }
                sumsWithIndices[i] = (sum, i);
            }


            Array.Sort(sumsWithIndices, (x, y) => y.Sum.CompareTo(x.Sum));

            var sortedArray = new int[array.Length][];
            for (int i = 0; i < sumsWithIndices.Length; i++)
            {
                sortedArray[i] = array[sumsWithIndices[i].Index];
            }

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = sortedArray[i];
            }
        }

        public delegate void SortRowsByMax(int[,] matrix);

        public delegate int[] FindNegatives(int[,] matrix);

        public delegate int[,] MathInfo(int[,] matrix);

        public delegate void Sorting(int[] matrix);

        public void Task1(int[,] A, int[,] B)
        {
            if (A == null || B == null) return;

            if (A.GetLength(1) != B.GetLength(0))
                return;

            int aIndex = FindDiagonalMaxIndex(A);
            int bIndex = FindDiagonalMaxIndex(B);

            SwapRowColumn(A, aIndex, B, bIndex);
        }

        public void Task2(ref int[,] A, int[,] B)
        {
            if (A == null || B == null)
                return;

            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);

            int maxPositiveRow = -1;
            int maxPositiveCount = -1;

            for (int i = 0; i < rowsA; i++)
            {
                int count = CountPositiveElementsInRow(A, i);
                if (count > maxPositiveCount)
                {
                    maxPositiveCount = count;
                    maxPositiveRow = i;
                }
            }

            int maxPositiveCol = -1;
            int maxPositiveColCount = -1;

            for (int j = 0; j < colsB; j++)
            {
                int count = CountPositiveElementsInColumn(B, j);
                if (count > maxPositiveColCount)
                {
                    maxPositiveColCount = count;
                    maxPositiveCol = j;
                }
            }


            if (maxPositiveColCount == 0)
                return;

            if (rowsB != colsA)
                return;


            InsertColumn(ref A, maxPositiveRow, maxPositiveCol, B);
        }
        public void Task3(int[,] matrix)
        {

            // code here
            ChangeMatrixValues(matrix);
            // end

        }
        public void Task4(int[,] A, int[,] B)
        {

            if (A == null || B == null)
                return;

            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);

            if (rowsA != rowsB || colsA != colsB)
                return;


            int[] negCountA = CountNegativesPerRow(A);
            int[] negCountB = CountNegativesPerRow(B);


            int maxRowA = FindMaxIndex(negCountA);
            int maxRowB = FindMaxIndex(negCountB);


            if (negCountA[maxRowA] == 0 || negCountB[maxRowB] == 0)
                return;


            for (int j = 0; j < colsA; j++)
            {
                int temp = A[maxRowA, j];
                A[maxRowA, j] = B[maxRowB, j];
                B[maxRowB, j] = temp;
            }
        }
        public void Task5(int[] matrix, Sorting sort)
        {
            if (matrix == null || sort == null)
                return;

            sort(matrix);
        }

        public void Task6(int[,] matrix, SortRowsByMax sort)
{

            if (matrix == null || sort == null)
                return;
    

            sort(matrix);
        }
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;


            if (matrix == null || find == null)
                return negatives;


            negatives = find(matrix);

            return negatives;
        }
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            if (matrix == null || info == null)
                return new int[0, 0];

            int cols = matrix.GetLength(1);

            bool allEqual = true;
            if (cols > 0)
            {
                int firstY = matrix[1, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[1, j] != firstY)
                    {
                        allEqual = false;
                        break;
                    }
                }
            }

            if (allEqual)
                return new int[0, 0];

            return info(matrix);
        }
        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            return CountSignFlips(a, b, h, func);
        }

        public void Task10(int[][] array, Action<int[][]> func)
        {
            // code here
            func(array);
            // end
        }
    }
}