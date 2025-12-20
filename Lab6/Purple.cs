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
            if (A.GetLength(0) != A.GetLength(1) || B.GetLength(0) != B.GetLength(1) || A.GetLength(0) != B.GetLength(0)) return;
            int rowIndex = FindDiagonalMaxIndex(A);
            int columnIndex = FindDiagonalMaxIndex(B);
            SwapRowColumn(A, rowIndex, B, columnIndex);
        }
        // end
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int ind = -1;
            int max = -10000;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    ind = i;
                }
            }
            return ind;
        }
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
            if (A.GetLength(1) != B.GetLength(0)) return;
            int ind0 = -1;
            int count0 = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                int k0 = CountPositiveElementsInRow(A, i);
                if (k0 > count0)
                {
                    count0 = k0;
                    ind0 = i;
                }
            }
            int ind1 = -1;
            int count1 = 0;

            for (int j = 0; j < B.GetLength(1); j++)
            {
                int k1 = CountPositiveElementsInColumn(B, j);
                if (k1 > count1)
                {
                    count1 = k1;
                    ind1 = j;
                }
            }
            if (count1 == 0) return;
            InsertColumn(ref A, ind0, ind1, B);
            // end

        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int k = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] > 0)
                    k++;
            }
            return k;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int k = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > 0)
                    k++;
            }
            return k;
        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int[,] answer = new int[A.GetLength(0) + 1, A.GetLength(1)];
            for (int i = 0; i <= rowIndex; i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    answer[i, j] = A[i, j];
                }
            }
            for (int j = 0; j < A.GetLength(1); j++)
            {
                answer[rowIndex + 1, j] = B[j, columnIndex];
            }
            for (int i = rowIndex + 1; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    answer[i + 1, j] = A[i, j];
                }
            }
            A = answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            ChangeMatrixValues(matrix);
            // end

        }
        public void ChangeMatrixValues(int[,] matrix)
        {
            if (matrix.GetLength(0) * matrix.GetLength(1) < 5)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] *= 2;
                    }
                }
                return;
            }
            int[] max5 = new int[matrix.GetLength(0) * matrix.GetLength(1)];
            int[] ind = new int[max5.Length];
            int c = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    max5[c] = matrix[i, j];
                    ind[c] = i * matrix.GetLength(1) + j;
                    c++;
                }
            }
            for (int i = 0; i < max5.Length - 1; i++)
            {
                for (int j = 0; j < max5.Length - i - 1; j++)
                {
                    if (max5[j] < max5[j + 1])
                    {
                        (max5[j], max5[j + 1]) = (max5[j + 1], max5[j]);
                        (ind[j], ind[j + 1]) = (ind[j + 1], ind[j]);
                    }
                }
            }
            int count = 0;
            int[] fiveind = new int[5];
            for (int i = 0; i < 5; i++)
                fiveind[i] = ind[i];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int currentind = i * matrix.GetLength(1) + j;
                    bool flag = false;

                    for (int k = 0; k < 5; k++)
                    {
                        if (fiveind[k] == currentind)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag && count < 5)
                    {
                        matrix[i, j] *= 2;
                        count++;
                    }
                    else
                        matrix[i, j] /= 2;
                }
            }
        }

        public void Task4(int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(1) != B.GetLength(1)) return;
            int indA = FindMaxIndex(CountNegativesPerRow(A));
            int indB = FindMaxIndex(CountNegativesPerRow(B));

            if (indA >= 0 && indB >= 0 && CountNegativesPerRow(A)[indA] > 0 && CountNegativesPerRow(B)[indB] > 0)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    (A[indA, j], B[indB, j]) = (B[indB, j], A[indA, j]);
                }
            }
            // end

        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int[] neg = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                        count++;
                }
                neg[i] = count;
            }
            return neg;
        }
        public int FindMaxIndex(int[] array)
        {
            if (array.Length == 0)
                return 0;
            int maxind = -1;
            int max = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    maxind = i;
                }
            }
            return maxind;
        }
        public delegate void Sorting(int[] array);
        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public void SortNegativeAscending(int[] array)
        {
            int[] negatives = new int[array.Length];
            int[] ind = new int[array.Length];
            int c = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    negatives[c] = array[i];
                    ind[c] = i;
                    c++;
                }
            }

            for (int i = 0; i < c - 1; i++)
            {
                for (int j = 0; j < c - i - 1; j++)
                {
                    if (negatives[j] > negatives[j + 1])
                    {
                        (negatives[j], negatives[j + 1]) = (negatives[j + 1], negatives[j]);
                    }
                }
            }
            for (int i = 0; i < c; i++)
            {
                array[ind[i]] = negatives[i];
            }
        }
        public void SortNegativeDescending(int[] array)
        {
            int[] negatives = new int[array.Length];
            int[] ind = new int[array.Length];
            int c = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    negatives[c] = array[i];
                    ind[c] = i;
                    c++;
                }
            }

            for (int i = 0; i < c - 1; i++)
            {
                for (int j = 0; j < c - i - 1; j++)
                {
                    if (negatives[j] < negatives[j + 1])
                    {
                        (negatives[j], negatives[j + 1]) = (negatives[j + 1], negatives[j]);
                    }
                }
            }

            for (int i = 0; i < c; i++)
            {
                array[ind[i]] = negatives[i];
            }
        }
        public delegate void SortRowsByMax(int[,] matrix);
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int[] maxVal = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                maxVal[i] = GetRowMax(matrix, i);
            }

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(0) - i - 1; j++)
                {
                    if (maxVal[j] > maxVal[j + 1])
                    {
                        (maxVal[j], maxVal[j + 1]) = (maxVal[j + 1], maxVal[j]);

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
            int[] maxVal = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                maxVal[i] = GetRowMax(matrix, i);
            }

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(0) - i - 1; j++)
                {
                    if (maxVal[j] < maxVal[j + 1])
                    {
                        (maxVal[j], maxVal[j + 1]) = (maxVal[j + 1], maxVal[j]);

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
            int max = int.MinValue;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > max)
                    max = matrix[row, j];
            }
            return max;
        }
        public delegate int[] FindNegatives(int[,] matrix);
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            // code here
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
                int maxNeg = 0;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        if (maxNeg == 0 || matrix[i, j] > maxNeg)
                        {
                            maxNeg = matrix[i, j];
                        }
                    }
                }

                result[j] = maxNeg;
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
            int[,] ans = new int[1, 1];
            bool vos = true, ub = true;
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[1, j] < matrix[1, j + 1]) ub = false;
                if (matrix[1, j] > matrix[1, j + 1]) vos = false;
            }
            if (vos == false && ub == false) ans[0, 0] = 0;
            else if (vos == true && ub == true) return new int[0, 0];
            else if (vos == true && ub == false) ans[0, 0] = 1;
            else ans[0, 0] = -1;
            return ans;
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            if (matrix.GetLength(1) < 2) return new int[0, 0];

            int[,] inter = new int[matrix.GetLength(1), 2];
            int interCount = 0;
            int l = 0;
            while (l < matrix.GetLength(1) - 1)
            {
                if (matrix[1, l] == matrix[1, l + 1])
                {
                    l++;
                    continue;
                }

                bool vosr = matrix[1, l] < matrix[1, l + 1];
                int r = l + 1;

                while (r < matrix.GetLength(1) - 1)
                {
                    if ((vosr && matrix[1, r] > matrix[1, r + 1]) || (!vosr && matrix[1, r] < matrix[1, r + 1]))
                        break;
                    r++;
                }

                inter[interCount, 0] = matrix[0, l];
                inter[interCount, 1] = matrix[0, r];
                interCount++;
                l = r;
            }

            int[,] result = new int[interCount, 2];
            for (int i = 0; i < interCount; i++)
            {
                result[i, 0] = inter[i, 0];
                result[i, 1] = inter[i, 1];
            }

            return result;
        }
        public int[,] FindLongestSeq(int[,] matrix)
        {
            int[,] intervals = FindAllSeq(matrix);
            if (intervals.GetLength(0) == 0)
                return new int[0, 0];
            int longestIndex = 0;
            int maxLength = 0;

            for (int i = 0; i < intervals.GetLength(0); i++)
            {
                int length = intervals[i, 1] - intervals[i, 0];

                if (length > maxLength)
                {
                    maxLength = length;
                    longestIndex = i;
                }
            }
            int[,] result = new int[1, 2];
            result[0, 0] = intervals[longestIndex, 0];
            result[0, 1] = intervals[longestIndex, 1];
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
        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            if (h <= 0 || a > b) return 0;
            int count = 0;
            int currSign = 0;
            bool firstSign = false;

            for (double x = a; x <= b + 0.0001; x += h)
            {
                double y = func(x);
                int newSign = Math.Sign(y);

                if (!firstSign)
                {
                    if (newSign != 0)
                    {
                        currSign = newSign;
                        firstSign = true;
                    }
                    continue;
                }

                if (newSign != 0 && newSign != currSign)
                {
                    count++;
                    currSign = newSign;
                }
            }
            return count;
        }
        public double FuncA(double x)
        {
            return x * x - Math.Sin(x);
        }
        public double FuncB(double x)
        {
            return Math.Cos(x) - 0.5 * x;
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
                {
                    for (int j = 0; j < array[i].Length - 1; j++)
                    {
                        for (int k = 0; k < array[i].Length - 1 - j; k++)
                        {
                            if (array[i][k] > array[i][k + 1])
                                (array[i][k], array[i][k + 1]) = (array[i][k + 1], array[i][k]);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < array[i].Length - 1; j++)
                    {
                        for (int k = 0; k < array[i].Length - 1 - j; k++)
                        {
                            if (array[i][k] < array[i][k + 1])
                                (array[i][k], array[i][k + 1]) = (array[i][k + 1], array[i][k]);
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
                int sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }
                sums[i] = sum;
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (sums[j] < sums[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        (sums[j], sums[j + 1]) = (sums[j + 1], sums[j]);
                    }
                }
            }
        }
        public void TotalReverse(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int left = 0;
                int right = array[i].Length - 1;
                while (left < right)
                {
                    (array[i][right], array[i][left]) = (array[i][left], array[i][right]);
                    left++;
                    right--;
                }
            }
            int start = 0;
            int end = array.Length - 1;
            while (start < end)
            {
                (array[start], array[end]) = (array[end], array[start]);
                start++;
                end--;
            }
        }
    }
}