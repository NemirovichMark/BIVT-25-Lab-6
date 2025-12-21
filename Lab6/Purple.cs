using System;

namespace Lab6
{

    public delegate void Sorting(int[] array);
    public delegate void SortRowsByMax(int[,] matrix);
    public delegate int[] FindNegatives(int[,] matrix);
    public delegate int[,] MathInfo(int[,] matrix);
    public delegate int GetTriangle(int[,] matrix);
    public delegate int[][] Predicate(int[][] array);

    public class Purple
    {



        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            if (matrix == null) return -1;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m) return -1;

            int maxIndex = 0;
            int maxValue = matrix[0, 0];
            for (int i = 1; i < n; i++)
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
            if (A == null || B == null) return;
            int nA = A.GetLength(0);
            int mA = A.GetLength(1);
            int nB = B.GetLength(0);
            int mB = B.GetLength(1);

            if (rowIndex < 0 || rowIndex >= nA || columnIndex < 0 || columnIndex >= mB) return;
            if (mA != nB) return;

            for (int j = 0; j < mA; j++)
            {
                int temp = A[rowIndex, j];
                A[rowIndex, j] = B[j, columnIndex];
                B[j, columnIndex] = temp;
            }
        }


        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            if (matrix == null) return 0;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (row < 0 || row >= n) return 0;

            int count = 0;
            for (int j = 0; j < m; j++)
                if (matrix[row, j] > 0)
                    count++;

            return count;
        }


        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            if (matrix == null) return 0;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (col < 0 || col >= m) return 0;

            int count = 0;
            for (int i = 0; i < n; i++)
                if (matrix[i, col] > 0)
                    count++;

            return count;
        }


        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            if (A == null || B == null) return;
            int nA = A.GetLength(0);
            int mA = A.GetLength(1);
            int nB = B.GetLength(0);
            int mB = B.GetLength(1);

            if (columnIndex < 0 || columnIndex >= mB) return;
            if (nB != mA) return;
            if (rowIndex < 0 || rowIndex > nA) return;

            int[,] result = new int[nA + 1, mA];

            int r = 0;
            for (int i = 0; i < nA + 1; i++)
            {
                if (i == rowIndex + 1)
                {
                    for (int j = 0; j < mA; j++)
                        result[i, j] = B[j, columnIndex];
                }
                else
                {
                    for (int j = 0; j < mA; j++)
                        result[i, j] = A[r, j];
                    r++;
                }
            }

            A = result;
        }


        public void ChangeMatrixValues(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int total = rows * cols;
            if (total == 0) return;

            if (total < 5)
            {
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        matrix[i, j] *= 2;
                return;
            }

            int[] values = new int[total];
            int[] indices = new int[total];

            int k = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    values[k] = matrix[i, j];
                    indices[k] = k;
                    k++;
                }
            }



            Array.Sort(indices, (a, b) =>
            {
                int va = values[a];
                int vb = values[b];
                if (va != vb) return vb.CompareTo(va);
                return a.CompareTo(b);
            });

            bool[] isTop5 = new bool[total];
            for (int i = 0; i < 5; i++)
                isTop5[indices[i]] = true;

            k = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (isTop5[k])
                        matrix[i, j] *= 2;
                    else
                        matrix[i, j] /= 2;
                    k++;
                }
            }
        }


        public int[] CountNegativesPerRow(int[,] matrix)
        {
            if (matrix == null) return Array.Empty<int>();
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] < 0)
                        count++;
                result[i] = count;
            }

            return result;
        }


        public int FindMaxIndex(int[] array)
        {
            if (array == null || array.Length == 0) return -1;
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


        public void SortNegativeAscending(int[] matrix)
        {
            if (matrix == null || matrix.Length == 0) return;

            int negCount = 0;
            for (int i = 0; i < matrix.Length; i++)
                if (matrix[i] < 0) negCount++;

            if (negCount == 0) return;

            int[] negatives = new int[negCount];
            int idx = 0;
            for (int i = 0; i < matrix.Length; i++)
                if (matrix[i] < 0) negatives[idx++] = matrix[i];

            Array.Sort(negatives);

            int negIndex = 0;
            for (int i = 0; i < matrix.Length; i++)
                if (matrix[i] < 0) matrix[i] = negatives[negIndex++];
        }


        public void SortNegativeDescending(int[] matrix)
        {
            if (matrix == null || matrix.Length == 0) return;

            int negCount = 0;
            for (int i = 0; i < matrix.Length; i++)
                if (matrix[i] < 0) negCount++;

            if (negCount == 0) return;

            int[] negatives = new int[negCount];
            int idx = 0;
            for (int i = 0; i < matrix.Length; i++)
                if (matrix[i] < 0) negatives[idx++] = matrix[i];

            Array.Sort(negatives, (a, b) => b.CompareTo(a));

            int negIndex = 0;
            for (int i = 0; i < matrix.Length; i++)
                if (matrix[i] < 0) matrix[i] = negatives[negIndex++];
        }


        public int GetRowMax(int[,] matrix, int row)
        {
            if (matrix == null) return 0;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (row < 0 || row >= n || m == 0) return 0;

            int max = matrix[row, 0];
            for (int j = 1; j < m; j++)
                if (matrix[row, j] > max)
                    max = matrix[row, j];
            return max;
        }


        public void SortRowsByMaxAscending(int[,] matrix)
        {
            SortRowsHelper(matrix, true);
        }


        public void SortRowsByMaxDescending(int[,] matrix)
        {
            SortRowsHelper(matrix, false);
        }


        private void SortRowsHelper(int[,] matrix, bool ascending)
        {
            if (matrix == null) return;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n <= 1) return;

            int[] maxes = new int[n];
            int[] indices = new int[n];

            for (int i = 0; i < n; i++)
            {
                maxes[i] = GetRowMax(matrix, i);
                indices[i] = i;
            }

            Array.Sort(indices, (a, b) =>
            {
                int cmp = maxes[a].CompareTo(maxes[b]);
                if (cmp != 0) return ascending ? cmp : -cmp;

                return a.CompareTo(b);
            });


            int[,] temp = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                int oldRow = indices[i];
                for (int j = 0; j < m; j++)
                {
                    temp[i, j] = matrix[oldRow, j];
                }
            }


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = temp[i, j];
                }
            }
        }


        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            return CountNegativesPerRow(matrix);
        }

        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            if (matrix == null) return Array.Empty<int>();
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] result = new int[m];

            for (int j = 0; j < m; j++)
            {
                bool hasNegative = false;
                int maxNeg = int.MinValue;
                for (int i = 0; i < n; i++)
                {
                    int v = matrix[i, j];
                    if (v < 0)
                    {
                        if (!hasNegative || v > maxNeg)
                        {
                            maxNeg = v;
                            hasNegative = true;
                        }
                    }
                }
                result[j] = hasNegative ? maxNeg : 0;
            }
            return result;
        }



        public int[,] DefineSeq(int[,] matrix)
        {
            if (matrix == null) return null;
            int cols = matrix.GetLength(1);



            if (cols < 2) return new int[0, 0];

            bool nonDecreasing = true;
            bool nonIncreasing = true;

            for (int j = 1; j < cols; j++)
            {
                if (matrix[1, j] < matrix[1, j - 1]) nonDecreasing = false;
                if (matrix[1, j] > matrix[1, j - 1]) nonIncreasing = false;
            }

            int[,] res = new int[1, 1];


            if (nonDecreasing && nonIncreasing)
            {
                res[0, 0] = 0;
                return res;
            }

            if (nonDecreasing) res[0, 0] = 1;
            else if (nonIncreasing) res[0, 0] = -1;
            else res[0, 0] = 0;

            return res;
        }



        public int[,] FindAllSeq(int[,] matrix)
        {
            if (matrix == null) return new int[0, 0];
            int cols = matrix.GetLength(1);
            if (cols < 2) return new int[0, 0];

            int[][] tempIntervals = new int[cols][];
            int intervalCount = 0;

            int start = 0;
            int dir = 0;

            for (int i = 0; i < cols - 1; i++)
            {
                int y1 = matrix[1, i];
                int y2 = matrix[1, i + 1];

                int currentDir = 0;
                if (y2 > y1) currentDir = 1;
                else if (y2 < y1) currentDir = -1;

                if (currentDir == 0) continue;

                if (dir == 0)
                {
                    dir = currentDir;

                }
                else if (dir != currentDir)
                {
                    tempIntervals[intervalCount] = new int[] { matrix[0, start], matrix[0, i] };
                    intervalCount++;
                    start = i;
                    dir = currentDir;
                }
            }


            if (dir != 0)
            {
                tempIntervals[intervalCount] = new int[] { matrix[0, start], matrix[0, cols - 1] };
                intervalCount++;
            }


            int[,] result = new int[intervalCount, 2];
            for (int i = 0; i < intervalCount; i++)
            {
                result[i, 0] = tempIntervals[i][0];
                result[i, 1] = tempIntervals[i][1];
            }
            return result;
        }


        public int[,] FindLongestSeq(int[,] matrix)
        {
            int[,] all = FindAllSeq(matrix);
            if (all == null || all.GetLength(0) == 0) return new int[0, 0];

            int maxLenIndex = 0;
            int maxLen = -1;

            for (int i = 0; i < all.GetLength(0); i++)
            {
                int len = Math.Abs(all[i, 1] - all[i, 0]);
                if (len > maxLen)
                {
                    maxLen = len;
                    maxLenIndex = i;
                }
            }
            return new int[,] { { all[maxLenIndex, 0], all[maxLenIndex, 1] } };
        }


        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            if (func == null) return 0;
            if (h <= 0 || a >= b) return 0;

            int flips = 0;
            double prevVal = func(a);



            int steps = (int)Math.Round((b - a) / h);

            for (int i = 1; i <= steps; i++)
            {
                double x = a + i * h;
                double curVal = func(x);

                if (curVal == 0)
                {

                }
                else
                {
                    if (prevVal != 0 && Math.Sign(prevVal) != Math.Sign(curVal))
                    {
                        flips++;
                    }
                    prevVal = curVal;
                }
            }
            return flips;
        }

        public double FuncA(double x) => x * x - Math.Sin(x);
        public double FuncB(double x) => Math.Exp(x) - 1.0;


        public void SortInCheckersOrder(int[][] array)
        {
            if (array == null) return;
            for (int i = 0; i < array.Length; i++)
            {
                var row = array[i];
                if (row == null || row.Length <= 1) continue;

                Array.Sort(row);
                if (i % 2 != 0) Array.Reverse(row);
            }
        }

        public void SortBySumDesc(int[][] array)
        {
            if (array == null) return;
            int n = array.Length;
            if (n <= 1) return;

            int[] sums = new int[n];
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                var row = array[i];
                if (row != null)
                    for (int j = 0; j < row.Length; j++)
                        sum += row[j];
                sums[i] = sum;
            }


            for (int i = 0; i < n - 1; i++)
            {
                int maxIdx = i;
                for (int j = i + 1; j < n; j++)
                    if (sums[j] > sums[maxIdx])
                        maxIdx = j;

                if (maxIdx != i)
                {
                    int[] tmpRow = array[i];
                    array[i] = array[maxIdx];
                    array[maxIdx] = tmpRow;

                    int ts = sums[i];
                    sums[i] = sums[maxIdx];
                    sums[maxIdx] = ts;
                }
            }
        }

        public void TotalReverse(int[][] array)
        {
            if (array == null) return;
            int n = array.Length;

            for (int i = 0; i < n / 2; i++)
            {
                var tmp = array[i];
                array[i] = array[n - 1 - i];
                array[n - 1 - i] = tmp;
            }

            for (int i = 0; i < n; i++)
            {
                var row = array[i];
                if (row == null) continue;
                Array.Reverse(row);
            }
        }



        public void Task1(int[,] A, int[,] B)
        {
            if (A == null || B == null) return;
            if (A.GetLength(0) != A.GetLength(1) || B.GetLength(0) != B.GetLength(1)) return;
            int rowA = FindDiagonalMaxIndex(A);
            int colB = FindDiagonalMaxIndex(B);
            if (rowA == -1 || colB == -1) return;
            SwapRowColumn(A, rowA, B, colB);
        }

        public void Task2(ref int[,] A, int[,] B)
        {
            if (A == null || B == null) return;
            int nA = A.GetLength(0);
            int nB = B.GetLength(0);
            int mB = B.GetLength(1);
            if (nB == 0 || mB == 0) return;

            int bestRow = 0;
            int bestCountRow = CountPositiveElementsInRow(A, 0);
            for (int i = 1; i < nA; i++)
            {
                int c = CountPositiveElementsInRow(A, i);
                if (c > bestCountRow)
                {
                    bestCountRow = c;
                    bestRow = i;
                }
            }

            int bestCol = -1;
            int bestCountCol = 0;
            for (int j = 0; j < mB; j++)
            {
                int c = CountPositiveElementsInColumn(B, j);
                if (c > bestCountCol)
                {
                    bestCountCol = c;
                    bestCol = j;
                }
            }

            if (bestCol == -1 || bestCountCol == 0) return;
            InsertColumn(ref A, bestRow, bestCol, B);
        }

        public void Task3(int[,] matrix)
        {
            ChangeMatrixValues(matrix);
        }

        public void Task4(int[,] A, int[,] B)
        {
            if (A == null || B == null) return;
            int[] negA = CountNegativesPerRow(A);
            int[] negB = CountNegativesPerRow(B);
            int idxA = FindMaxIndex(negA);
            int idxB = FindMaxIndex(negB);

            if (idxA == -1 || idxB == -1) return;
            if (negA[idxA] == 0 || negB[idxB] == 0) return;

            int mA = A.GetLength(1);
            int mB = B.GetLength(1);
            if (mA != mB) return;

            for (int j = 0; j < mA; j++)
            {
                int tmp = A[idxA, j];
                A[idxA, j] = B[idxB, j];
                B[idxB, j] = tmp;
            }
        }

        public void Task5(int[] matrix, Sorting sort)
        {
            if (matrix == null || sort == null) return;
            sort(matrix);
        }

        public void Task6(int[,] matrix, SortRowsByMax sort)
        {
            if (matrix == null || sort == null) return;
            sort(matrix);
        }

        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            if (matrix == null || find == null) return Array.Empty<int>();
            var res = find(matrix);
            return res ?? Array.Empty<int>();
        }

        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            if (matrix == null || info == null) return new int[0, 0];
            var res = info(matrix);
            return res ?? new int[0, 0];
        }

        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            return CountSignFlips(a, b, h, func);
        }

        public void Task10(int[][] array, Action<int[][]> func)
        {
            if (array == null || func == null) return;
            func(array);
        }
    }
}
