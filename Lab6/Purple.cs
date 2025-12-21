using System;
using System.Numerics;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public void Task1(int[,] A, int[,] B)
        {

            // code here
            if (A == null || B == null) return;
            if (A.GetLength(0) != A.GetLength(1)) return;
            if (B.GetLength(0) != B.GetLength(1)) return;
            if (A.GetLength(0) != B.GetLength(0)) return;

            int row = FindDiagonalMaxIndex(A);
            int col = FindDiagonalMaxIndex(B);

            SwapRowColumn(A, row, B, col);
            // end

        }

        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int imax = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > matrix[imax, imax])
                {
                    imax = i;
                }
            }

            return imax;
        }

        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            if (matrix.GetLength(1) != B.GetLength(0)) return;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                (matrix[rowIndex, j], B[j, columnIndex]) = (B[j, columnIndex], matrix[rowIndex, j]);
            }
        }

        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            if (A == null || B == null || A.GetLength(1) != B.GetLength(0)) return;

            int countMaxElInRow = 0;
            int indRow = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                if (CountPositiveElementsInRow(A, i) > countMaxElInRow)
                {
                    countMaxElInRow = CountPositiveElementsInRow(A, i);
                    indRow = i;
                }
            }

            int countMaxElInCol = 0;
            int indCol = 0;
            for (int j = 0; j < B.GetLength(1); j++)
            {
                if (CountPositiveElementsInColumn(B, j) > countMaxElInCol)
                {
                    countMaxElInCol = CountPositiveElementsInColumn(B, j);
                    indCol = j;
                }
            }

            if (countMaxElInRow == 0) return;

            InsertColumn(ref A, indRow, indCol, B);

            // end

        }

        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int[,] newA = new int[A.GetLength(0) + 1, A.GetLength(1)];
            int newRow = 0;

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    newA[newRow, j] = A[i, j];
                }
                if (i == rowIndex)
                {
                    newRow++;
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        newA[newRow, j] = B[j, columnIndex];
                    }
                }
                newRow++;
            }

            A = newA;
        }

        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int count = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
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
            for (int i = 0; i < matrix.GetLength(0); i++)
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
            if (matrix == null) return;

            ChangeMatrixValues(matrix);
            // end

        }

        public void ChangeMatrixValues(int[,] matrix)
        {
            int totalEls = matrix.GetLength(0) * matrix.GetLength(1);
            if (totalEls <= 5)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = matrix[i, j] * 2;
                    }
                }
                return;
            }

            int[] values = new int[totalEls];
            int[,] coords = new int[totalEls, 2];
            int index = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    values[index] = matrix[i, j];
                    coords[index, 0] = i;
                    coords[index, 1] = j;
                    index++;
                }
            }

            for (int i = 0; i < totalEls - 1; i++)
            {
                for (int j = 0; j < totalEls - i - 1; j++)
                {
                    if (values[j] < values[j + 1])
                    {
                        (values[j], values[j + 1]) = (values[j + 1], values[j]);
                        (coords[j, 0], coords[j + 1, 0]) = (coords[j + 1, 0], coords[j, 0]);
                        (coords[j, 1], coords[j + 1, 1]) = (coords[j + 1, 1], coords[j, 1]);
                    }
                }
            }

            bool[,] isTop5 = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            for (int k = 0; k < 5; k++)
            {
                int i = coords[k, 0];
                int j = coords[k, 1];
                isTop5[i, j] = true;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (isTop5[i, j])
                        matrix[i, j] *= 2;
                    else
                        matrix[i, j] /= 2;
                }
            }
        }

        public void Task4(int[,] A, int[,] B)
        {

            // code here
            if (A == null || B == null || A.GetLength(1) != B.GetLength(1)) return;

            int iA = FindMaxIndex(CountNegativesPerRow(A));
            int iB = FindMaxIndex(CountNegativesPerRow(B));

            if (iA == -1 || iB == -1) return;

            int[] Aneg = CountNegativesPerRow(A);
            int[] Bneg = CountNegativesPerRow(B);

            if (Aneg[iA] == 0 || Bneg[iB] == 0) return;

            for (int j = 0; j < A.GetLength(1); j++)
            {
                (A[iA, j], B[iB, j]) = (B[iB, j], A[iA, j]);
            }
            // end

        }

        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int[] countNegAr = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
                countNegAr[i] = count;
            }
            return countNegAr;
        }

        public int FindMaxIndex(int[] array)
        {
            if (array == null || array.Length == 0) return -1;

            int max = int.MinValue;
            int ind = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    ind = i;
                }
            }
            return ind;
        }

        public delegate void Sorting(int[] matrix);
        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            if (matrix == null || sort == null) return;
            sort(matrix);
            // end

        }

        public void SortNegativeAscending(int[] matrix)
        {

            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int j = i + 1; j < matrix.Length; j++)
                {
                    if (matrix[i] < 0 && matrix[j] < 0 && matrix[i] > matrix[j])
                    {
                        (matrix[i], matrix[j]) = (matrix[j], matrix[i]);
                    }
                }
            }
        }

        public void SortNegativeDescending(int[] matrix)
        {

            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int j = i + 1; j < matrix.Length; j++)
                {
                    if (matrix[i] < 0 && matrix[j] < 0 && matrix[i] < matrix[j])
                    {
                        (matrix[i], matrix[j]) = (matrix[j], matrix[i]);
                    }
                }
            }
        }

        public delegate void SortRowsByMax(int[,] matrix);
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here
            if (matrix == null || sort == null) return;
            sort(matrix);
            // end

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

        public void SortRowsByMaxAscending(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(0) - i - 1; j++)
                {
                    if (GetRowMax(matrix, j) > GetRowMax(matrix, j + 1))
                    {
                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            (matrix[j, k], matrix[j + 1, k]) = (matrix[j + 1, k], matrix[j, k]);
                        }
                    }
                }
            }
        }

        public void SortRowsByMaxDescending(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(0) - i - 1; j++)
                {
                    if (GetRowMax(matrix, j) < GetRowMax(matrix, j + 1))
                    {
                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            (matrix[j, k], matrix[j + 1, k]) = (matrix[j + 1, k], matrix[j, k]);
                        }
                    }
                }
            }
        }

        public delegate int[] FindNegatives(int[,] matrix);
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            // code here
            if (matrix == null || matrix.Length == 0 || find == null) return null;

            negatives = find(matrix);
            // end

            return negatives;
        }

        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int[] result = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
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
            int[] result = new int[matrix.GetLength(1)];

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int maxNeg = int.MinValue;
                bool IsNegative = false;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        IsNegative = true;
                        if (matrix[i, j] > maxNeg)
                            maxNeg = matrix[i, j];
                    }
                }

                result[j] = IsNegative ? maxNeg : 0;
            }

            return result;
        }

        public delegate int[,] MathInfo(int[,] matrix);
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here

            answer = info(matrix);
            // end

            return answer;
        }

        public int[,] DefineSeq(int[,] matrix)
        {
            int n = matrix.GetLength(1);
            if (n <= 1) return new int[0, 0];

            int prev = matrix[1, 0];
            int dir = 0;

            for (int j = 1; j < n; j++)
            {
                int curr = matrix[1, j];
                if (curr > prev)
                {
                    if (dir == 0) dir = 1;
                    else if (dir == -1) return new int[1, 1] { { 0 } };
                }
                else if (curr < prev)
                {
                    if (dir == 0) dir = -1;
                    else if (dir == 1) return new int[1, 1] { { 0 } };
                }
                prev = curr;
            }

            return new int[1, 1] { { dir } };
        }

        public int[,] FindAllSeq(int[,] matrix)
        {
            int cols = matrix.GetLength(1);

            if (cols < 2) return new int[,] { };

            int count = 0;
            int direction = 0;

            for (int i = 1; i < cols; i++)
            {
                int currentDir;
                if (matrix[1, i] > matrix[1, i - 1]) currentDir = 1;
                else if (matrix[1, i] < matrix[1, i - 1]) currentDir = -1;
                else currentDir = direction;

                if (direction == 0)
                {
                    direction = currentDir;
                }
                else if (currentDir != 0 && currentDir != direction)
                {
                    count++;
                    direction = currentDir;
                }
            }
            if (direction != 0) count++;

            if (count == 0) return new int[,] { };

            int[,] result = new int[count, 2];
            int index = 0;
            int start = 0;
            direction = 0;

            for (int i = 1; i < cols; i++)
            {
                int currentDir;
                if (matrix[1, i] > matrix[1, i - 1]) currentDir = 1;
                else if (matrix[1, i] < matrix[1, i - 1]) currentDir = -1;
                else currentDir = direction;

                if (direction == 0)
                {
                    direction = currentDir;
                }
                else if (currentDir != 0 && currentDir != direction)
                {
                    result[index, 0] = matrix[0, start];
                    result[index, 1] = matrix[0, i - 1];
                    index++;
                    start = i - 1;
                    direction = currentDir;
                }
            }

            if (index < count)
            {
                result[index, 0] = matrix[0, start];
                result[index, 1] = matrix[0, cols - 1];
            }

            return result;
        }

        public int[,] FindLongestSeq(int[,] matrix)
        {
            int[,] allIntervals = FindAllSeq(matrix);

            if (allIntervals.GetLength(0) == 0) return new int[,] { };

            int maxLength = 0;
            int maxStart = 0;
            int maxEnd = 0;

            for (int i = 0; i < allIntervals.GetLength(0); i++)
            {
                int length = allIntervals[i, 1] - allIntervals[i, 0];
                if (length > maxLength)
                {
                    maxLength = length;
                    maxStart = allIntervals[i, 0];
                    maxEnd = allIntervals[i, 1];
                }
            }

            return new int[,] { { maxStart, maxEnd } };
        }

        public double FuncA(double x)
        {
            return x * x - Math.Sin(x);
        }
        public double FuncB(double x)
        {
            return Math.Exp(x) - 1;
        }

        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            // code here
            if (h <= 0 || func == null || b <= a) return 0;

            answer = CountSignFlips(a, b, h, func);
            // end

            return answer;
        }

        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            if (h <= 0 || func == null || b <= a) return 0;

            int flips = 0;
            double prevValue = func(a);
            int prevSign = Math.Sign(prevValue);

            for (double x = a + h; x <= b + 1e-10; x += h)
            {
                double currentValue = func(x);
                int currentSign = Math.Sign(currentValue);

                if (prevSign != 0 && currentSign != 0 && prevSign != currentSign)
                {
                    flips++;
                }

                if (currentSign != 0)
                {
                    prevSign = currentSign;
                }

                prevValue = currentValue;
            }

            return flips;
        }

        public delegate void Action(int[][] array);
        public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here
            if (array == null || func == null) return;

            func(array);
            // end

        }

        public void SortInCheckersOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null) continue;

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
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    int sum1 = array[j]?.Sum() ?? int.MinValue;
                    int sum2 = array[j + 1]?.Sum() ?? int.MinValue;

                    if (sum1 < sum2)
                    {
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        public void TotalReverse(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                    Array.Reverse(array[i]);
            }

            Array.Reverse(array);
        }

    }
}