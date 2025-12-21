using System;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public delegate void Sorting(int[] array);
    public delegate void SortRowsByMax(int[,] matrix);
    public delegate int[] FindNegatives(int[,] matrix);
    public delegate int[,] MathInfo(int[,] matrix);
    public delegate double Func(double x);
    public delegate void Action(int[][] array);
    public class Purple
    {
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int maxIndex = 0; 
            int curMax = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > curMax)
                {
                    curMax = matrix[i, i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
        public void SwapRowColumn(int[,] A, int rowIndex, int[,] B, int columnIndex)
        {
            int n = A.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                (A[rowIndex, i], B[i, columnIndex]) = (B[i, columnIndex], A[rowIndex, i]);
            }
        }
        public void Task1(int[,] A, int[,] B)
        {

            // code here
            int indA = FindDiagonalMaxIndex(A), indB = FindDiagonalMaxIndex(B);
            if (A.GetLength(0) != A.GetLength(1) || B.GetLength(0) != B.GetLength(1) || A.GetLength(0) != B.GetLength(0))
                return;
            SwapRowColumn(A, indA, B, indB);

            // end

        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int positive = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (matrix[row, j] > 0) positive++;
            return positive;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int positive = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                if (matrix[i, col] > 0) positive++;
            return positive;
        }
        public void InsertColumn(ref int[,] A, int row, int col, int[,] B)
        {
            int[,] newA = new int[A.GetLength(0) + 1, A.GetLength(1)];
            for (int i = 0; i <= row; i++)
            {
                for (int j = 0; j < newA.GetLength(1); j++)
                {
                    newA[i, j] = A[i, j];
                }
            }
            for (int j = 0; j < newA.GetLength(1); j++)
                newA[row+1, j] = B[j, col];
            int i_newA = row + 2;
            for (int i = row+1; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < newA.GetLength(1); j++)
                {
                    newA[i_newA, j] = A[i, j];
                }
                i_newA++;
            }
            A = newA;

        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(1) != B.GetLength(0))
                return;
            int row = 0;
            int col = 0;
            int maxPositives = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                if (CountPositiveElementsInRow(A, i) > maxPositives)
                {
                    maxPositives = CountPositiveElementsInRow(A, i);
                    row = i;
                }
            }
            maxPositives = 0;
            for (int j = 0; j < B.GetLength(1); j++)
            {
                if (CountPositiveElementsInColumn(B, j) > maxPositives)
                {
                    maxPositives = CountPositiveElementsInColumn(B, j);
                    col = j;
                }
            }
            if (maxPositives == 0)
                return;

            InsertColumn(ref A, row, col, B);
            // end

        }

        public void ChangeMatrixValues(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows * cols < 5)
            {
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        matrix[i, j] *= 2;
                return;
            }

            bool[,] curTop = new bool[rows, cols];

            for (int x = 0; x < 5; x++)
            {
                int bestI = 0, bestJ = 0;
                int best = -1000000000;

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (!curTop[i,j] && matrix[i, j] > best)
                        {
                            bestI = i;
                            bestJ = j;
                            best = matrix[i, j];
                        }
                    }
                }
                curTop[bestI, bestJ] = true;
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (curTop[i, j])
                        matrix[i, j] *= 2;
                    else
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
            int[] negatives = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int c = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0) c++;
                }
                negatives[i] = c;
            }
            return negatives;
        }
        public int FindMaxIndex(int[] array)
        {
            int ind = -1;
            int max = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    ind = i;
                    max = array[i];
                }
            }
            return ind;
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            int[] negativesA = CountNegativesPerRow(A);
            int[] negativesB = CountNegativesPerRow(B);

            int indA = FindMaxIndex(negativesA);
            int indB = FindMaxIndex(negativesB);
            if (indA == -1 || indB == -1 || A.GetLength(1) != B.GetLength(1)) return;
            for (int j = 0; j < A.GetLength(1); j++)
                (A[indA, j], B[indB, j]) = (B[indB, j], A[indA, j]);
            // end

        }
        public void SortNegativeAscending(int[] array)
        {
            int c = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i] < 0) c++;
            int[] negativesInd = new int[c];
            int[] negatives = new int[c];
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    negativesInd[counter] = i;
                    negatives[counter] = array[i];
                    counter++;
                }
            }
            Array.Sort(negatives);
            counter = 0;
            foreach(int neg in negativesInd)
            {
                array[neg] = negatives[counter];
                counter++;
            }
        }
        public void SortNegativeDescending(int[] array)
        {
            int c = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i] < 0) c++;
            int[] negativesInd = new int[c];
            int[] negatives = new int[c];
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    negativesInd[counter] = i;
                    negatives[counter] = array[i];
                    counter++;
                }
            }
            Array.Sort(negatives);
            Array.Reverse(negatives);
            counter = 0;
            foreach (int neg in negativesInd)
            {
                array[neg] = negatives[counter];
                counter++;
            }
        }
        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            Sorting negativeAscending = SortNegativeAscending;
            Sorting negativeDescending = SortNegativeDescending;

            sort(matrix);
            // end

        }
        public void SortRowsByMaxAscending(int[,] matrix) {
            int[] maxxes = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
                maxxes[i] = GetRowMax(matrix, i);

            for (int i = 0; i < maxxes.Length; i++)
            {
                for (int j = 0; j < maxxes.Length - i - 1; j++)
                {
                    if (maxxes[j] > maxxes[j+1])
                    {
                        (maxxes[j], maxxes[j + 1]) = (maxxes[j + 1], maxxes[j]);
                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            (matrix[j, k], matrix[j + 1, k]) = (matrix[j + 1, k], matrix[j, k]);
                        }
                    }
                }
            }
        }
        public void SortRowsByMaxDescending(int[,] matrix) {
            int[] maxxes = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
                maxxes[i] = GetRowMax(matrix, i);

            for (int i = 0; i < maxxes.Length; i++)
            {
                for (int j = 0; j < maxxes.Length - i - 1; j++)
                {
                    if (maxxes[j] < maxxes[j + 1])
                    {
                        (maxxes[j], maxxes[j + 1]) = (maxxes[j + 1], maxxes[j]);
                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            (matrix[j, k], matrix[j + 1, k]) = (matrix[j + 1, k], matrix[j, k]);
                        }
                    }
                }
            }
        }
        public int GetRowMax(int[,] matrix, int row)
        {
            int max = matrix[row, 0];
            for (int j = 1; j < matrix.GetLength(1); j++)
                if (matrix[row, j] > max) max = matrix[row, j];
            return max;
        }
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here
            SortRowsByMax SortAscending = SortRowsByMaxAscending;
            SortRowsByMax SortDescending = SortRowsByMaxDescending;

            sort(matrix);
            // end

        }
        public int[] FindNegativeCountPerRow(int[,] matrix) {
            int[] negatives = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int c = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0) c++;
                }
                negatives[i] = c;
            }
            return negatives;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix) {
            int[] maxNegative = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int max = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0 && max == 0) max = matrix[i, j];
                    else if (matrix[i, j] < 0 && matrix[i, j] > max) max = matrix[i, j];
                }
                maxNegative[j] = max;
            }
            return maxNegative;
        }
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            // code here
            FindNegatives FindNegativeCount = FindNegativeCountPerRow;
            FindNegatives FindMaxNegative = FindMaxNegativePerColumn;

            negatives = find(matrix);
            // end

            return negatives;
        }
        public int[,] DefineSeq(int[,] matrix)
        {
            if (matrix.GetLength(1) < 2) return new int[0, 0];


            bool flag = true;
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[1, j] != matrix[1, 0])
                {
                    flag = false;
                    break;
                }
            }
            if (flag) return new int[0, 0];

            bool increasing = true;
            bool decreasing = true;
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[1, j] < matrix[1, j+1]) decreasing = false;
                else if (matrix[1, j] > matrix[1, j + 1]) increasing = false;
            }
            if (increasing)
                return new int[,] { { 1 } };
            if (decreasing)
                return new int[,] { { -1 } };
            return new int[,] { { 0 } };
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            if (matrix.GetLength(1) < 2) return new int[0, 0];

            int[,] defSeq = DefineSeq(matrix);
            if (defSeq.GetLength(0) == 0) return new int[0, 0];
            if (defSeq[0, 0] != 0) return new int[,] { { matrix[0, 0], matrix[0, matrix.GetLength(1) - 1] } };
            

            int changes = 0;
            int direction = 0;

            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                int diff = matrix[1, j] - matrix[1, j - 1];
                if (diff == 0) continue;

                int sign = diff > 0 ? 1 : -1;

                if (direction == 0) direction = sign;
                else if (sign != direction)
                {
                    changes++;
                    direction = sign;
                }
            }
            int[,] result = new int[changes + 1, 2];

            int start = 0;
            changes = 0;
            direction = 0;

            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                int diff = matrix[1, j] - matrix[1, j - 1];
                if (diff == 0) continue;

                int sign = diff > 0 ? 1 : -1;

                if (direction == 0) direction = sign;
                else if (direction != sign)
                {
                    result[changes, 0] = matrix[0, start];
                    result[changes, 1] = matrix[0, j-1];
                    start = j - 1;
                    changes++;
                    direction = sign;

                }
            }
            result[changes, 0] = matrix[0, start];
            result[changes, 1] = matrix[0, matrix.GetLength(1) - 1];

            
            return result;
        }
        public int[,] FindLongestSeq(int[,] matrix)
        {
            matrix = FindAllSeq(matrix);
            int[,] result = new int[1, 2];
            if (matrix.GetLength(0) == 0) return new int[0,0];

            int diff = matrix[0, 1] - matrix[0, 0];
            result[0, 0] = matrix[0, 0];
            result[0, 1] = matrix[0, 1];

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (diff < matrix[i, 1] - matrix[i, 0])
                {
                    diff = matrix[i, 1] - matrix[i, 0];
                    result[0, 0] = matrix[i, 0];
                    result[0, 1] = matrix[i, 1];
                }
            }
            return result;
        }
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here
            MathInfo Seq = DefineSeq;
            MathInfo All = FindAllSeq;
            MathInfo Longest = FindLongestSeq;

            answer = info(matrix);

            // end

            return answer;
        }
        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            int changes = 0;
            double y1 = func(a);
            for (double i = a + h; i <= b + 1e-10; i += h)
            {
                double y2 = func(i);
                int s1 = Math.Sign(y1);
                int s2 = Math.Sign(y2);

                if (s1 == 0) continue;
                if (s2 == 0)
                {
                    s1 = s2;
                    continue;
                }
                if (s1 != s2) changes++;
                y1 = y2;
            }
            return changes;
        }
        public double FuncA(double x) {
            return Math.Pow(x, 2) - Math.Sin(x);
        }
        public double FuncB(double x) {
            return Math.Exp(x) - 1;
        }
        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            // code here
            answer = CountSignFlips(a, b, h, func);
            // end

            return answer;
        }
        public void SortInCheckersOrder(int[][] array) {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null) continue;

                if (i % 2 == 0) Array.Sort(array[i]);
                else
                {
                    Array.Sort(array[i]);
                    Array.Reverse(array[i]);
                }
            }
        }
        public void SortBySumDesc(int[][] array) {
            int[] sums = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }
                sums[i] = sum;
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (sums[j] < sums[j+1])
                    {
                        (sums[j], sums[j + 1]) = (sums[j + 1], sums[j]);
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
        }
        public void TotalReverse(int[][] array) { 
            for (int i = 0; i < array.Length; i++)
            {
                Array.Reverse(array[i]);
            }
            for (int i = 0; i < array.Length / 2; i++)
            {
                (array[i], array[array.Length - 1 - i]) = (array[array.Length - 1 - i], array[i]);
            }
        }

        public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here
            func(array);
            // end

        }
    }
}
