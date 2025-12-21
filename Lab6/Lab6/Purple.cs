using System;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public void Task1(int[,] A, int[,] B)
        {
            if (A.GetLength(0) != A.GetLength(1) || B.GetLength(0) != B.GetLength(1) || A.GetLength(0) != B.GetLength(1))
            {
                return;
            }
            int ia = FindDiagonalMaxIndex(A);
            int ib = FindDiagonalMaxIndex(B);

            SwapRowColumn(A, ia, B, ib);

        }
        public int FindDiagonalMaxIndex(int[,] matrix) {
            int imx = 0;
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                if (matrix[imx, imx] < matrix[i, i]) imx = i;
            }
            return imx;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex) {
            for (int j = 0; j < matrix.GetLength(0); ++j)
            {
                (matrix[rowIndex, j], B[j, columnIndex]) = (B[j, columnIndex], matrix[rowIndex, j]);
            }
        }
        public void Task2(ref int[,] A, int[,] B)
        {
            if (A.GetLength(1) != B.GetLength(0)) return;
            
            int ab = 0, ai = 0;
            for (int i = 0; i < A.GetLength(0); ++i)
            {
                int now = CountPositiveElementsInRow(A, i);
                if (now > ab)
                {
                    ai = i; ab = now;
                }
            }
            int bb = 0, bj = 0;
            for (int j = 0; j < B.GetLength(1); ++j)
            {
                int now = CountPositiveElementsInColumn(B, j);
                if (now > bb)
                {
                    bj = j; bb = now;
                }
            }
            InsertColumn(ref A, ai, bj, B);

        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B) {
            int[,] newA = new int[A.GetLength(0) + 1, A.GetLength(1)];
            for (int i = 0; i <= rowIndex; ++i)
            {
                for (int j = 0; j < A.GetLength(1); ++j)
                {
                    newA[i, j] = A[i, j];
                }
            }
            for (int j = 0; j < B.GetLength(0); ++j)
            {
                newA[rowIndex + 1, j] = B[j, columnIndex];
            }
            for (int i = rowIndex + 1; i < A.GetLength(0); ++i)
            {
                for (int j = 0; j < A.GetLength(1); ++j)
                {
                    newA[i + 1  , j] = A[i, j];
                }
            }
            A = new int[A.GetLength(0), A.GetLength(1) + 1];
            A = newA;
        }
        public int CountPositiveElementsInRow(int[,] matrix, int row) {
            int cnt = 0;
            for (int j = 0; j < matrix.GetLength(1); ++j)
            {
                if (matrix[row, j] > 0) ++cnt;
            }
            return cnt;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col) {
            int cnt = 0;
            for (int j = 0; j < matrix.GetLength(0); ++j)
            {
                if (matrix[j, col] > 0) ++cnt;
            }
            return cnt;
        }
        public void Task3(int[,] matrix)
        {

            ChangeMatrixValues(matrix);

        }
        public void ChangeMatrixValues(int[,] matrix) {
            if (matrix.GetLength(0) * matrix.GetLength(1) <= 5)
            {
                for (int i = 0; i < matrix.GetLength(0); ++i)
                {
                    for (int j = 0; j < matrix.GetLength(1); ++j)
                    {
                        matrix[i, j] *= 2;
                    }
                }
                return;
            }
            bool[,] used = new bool [matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    used[i, j] = false;
                }
            }
            for (int r = 0; r < 5; ++r)
            {
                int ibest = 0, jbest = 0;
                for (int i = 0; i < matrix.GetLength(0); ++i)
                {
                    for (int j = 0; j < matrix.GetLength(1); ++j)
                    {
                        if (!used[i, j])
                        {
                            if (matrix[i, j] > matrix[ibest, jbest])
                            {
                                ibest = i; jbest = j;
                            }
                        }
                    }
                }
                matrix[ibest, jbest] *= 2;
                used[ibest, jbest] = true;
            }
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    if (!used[i, j])
                    {
                        matrix[i, j] /= 2;
                    }
                }
            }
        }
        public void Task4(int[,] A, int[,] B)
        {

            int[] cntA = CountNegativesPerRow(A);
            int[] cntB = CountNegativesPerRow(B);
            bool isGood = false;
            for (int i = 0; i < cntA.Length; ++i)
            {
                if (cntA[i] != 0) isGood = true;
            }
            if (!isGood) return;
            isGood = false;
            for (int i = 0; i < cntB.Length; ++i)
            {
                if (cntB[i] != 0) isGood = true;
            }
            if (!isGood || A.GetLength(1) != B.GetLength(1)) return;
            int indA = FindMaxIndex(cntA), indB = FindMaxIndex(cntB);
            for (int j = 0; j < A.GetLength(1); ++j)
            {
                (A[indA, j], B[indB, j]) = (B[indB, j], A[indA, j]);
            }
        }
        public int[] CountNegativesPerRow(int[,] matrix) {
            int[] array = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                int cnt = 0;
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    if (matrix[i, j] < 0) ++cnt;
                }
                array[i] = cnt;
            }
            return array;
        }
        public int FindMaxIndex(int[] array) {
            int imx = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i] > array[imx])
                {
                    imx = i;
                }
            }
            return imx;
        }
        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public delegate void Sorting(int[] matrix);
        public void SortNegativeAscending(int[] matrix) {
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
               if (matrix[i] < 0) ++cnt;
            }
            int[] neg = new int[cnt]; cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                if (matrix[i] < 0) neg[cnt++] = i;
            }
            for (int i = 0; i < neg.GetLength(0); ++i)
            {
                for (int j = 0; j < neg.GetLength(0) - i - 1; ++j)
                {
                    if (matrix[neg[j]] > matrix[neg[j + 1]]) {
                        (matrix[neg[j]], matrix[neg[j + 1]]) = (matrix[neg[j + 1]], matrix[neg[j]]);
                    }
                }
            }
        }
        public void SortNegativeDescending(int[] matrix) {
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                if (matrix[i] < 0) ++cnt;
            }
            int[] neg = new int[cnt]; cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                if (matrix[i] < 0) neg[cnt++] = i;
            }
            for (int i = 0; i < neg.GetLength(0); ++i)
            {
                for (int j = 0; j < neg.GetLength(0) - i - 1; ++j)
                {
                    if (matrix[neg[j]] < matrix[neg[j + 1]])
                    {
                        (matrix[neg[j]], matrix[neg[j + 1]]) = (matrix[neg[j + 1]], matrix[neg[j]]);
                    }
                }
            }
        }

        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public delegate void SortRowsByMax(int[,] matrix);
        public int GetRowMax(int[,] matrix, int row) {
            int cols = matrix.GetLength(1);
            int max = matrix[row, 0];

            for (int j = 1; j < cols; j++)
            {
                if (matrix[row, j] > max)
                    max = matrix[row, j];
            }

            return max;
        }

        public void SortRowsByMaxAscending(int[,] matrix) {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows - 1; i++)
            {
                for (int k = i + 1; k < rows; k++)
                {
                    if (GetRowMax(matrix, i) > GetRowMax(matrix, k))
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            int temp = matrix[i, j];
                            matrix[i, j] = matrix[k, j];
                            matrix[k, j] = temp;
                        }
                    }
                }
            }
        }

        public void SortRowsByMaxDescending(int[,] matrix) {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows - 1; i++)
            {
                for (int k = i + 1; k < rows; k++)
                {
                    if (GetRowMax(matrix, i) < GetRowMax(matrix, k))
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            int temp = matrix[i, j];
                            matrix[i, j] = matrix[k, j];
                            matrix[k, j] = temp;
                        }
                    }
                }
            }
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
        public int[] FindNegativeCountPerRow(int[,] matrix) {
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


        public int[] FindMaxNegativePerColumn(int[,] matrix) {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] result = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                int maxNeg = int.MinValue;
                bool hasNegative = false;

                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        hasNegative = true;
                        if (matrix[i, j] > maxNeg)
                            maxNeg = matrix[i, j];
                    }
                }
                result[j] = hasNegative ? maxNeg : 0;
            }
            return result;
        }

        public int[,] Task8(int[,] matrix, MathInfo info) {

            int[,] answer = info(matrix);

            return answer ?? new int[0, 2];
        }

        public delegate int[,] MathInfo(int[,] matrix);

        public int[,] DefineSeq(int[,] matrix) {
            if (matrix == null || matrix.GetLength(0) < 2 || matrix.GetLength(1) < 2)
                return new int[0, 0];

            int n = matrix.GetLength(1);

            bool allEqual = true;
            int firstY = matrix[1, 0];
            for (int i = 1; i < n; i++)
            {
                if (matrix[1, i] != firstY)
                {
                    allEqual = false;
                    break;
                }
            }

            if (allEqual)
                return new int[0, 0];

            bool increasing = true;
            bool decreasing = true;

            for (int i = 1; i < n; i++)
            {
                int prevY = matrix[1, i - 1];
                int currY = matrix[1, i];

                if (currY > prevY) decreasing = false;
                if (currY < prevY) increasing = false;
            }

            int[,] result = new int[1, 1];
            result[0, 0] = increasing ? 1 : (decreasing ? -1 : 0);
            return result;
        }
        public int[,] FindAllSeq(int[,] matrix) {
            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);
            int[,] result = new int[0, 0];

            if (colCount > 1)
            {
                int sequenceType = DefineSeq(matrix)[0, 0];

                if (sequenceType == 1 || sequenceType == -1)
                {
                    result = new int[1, 2];
                    result[0, 0] = matrix[0, 0];
                    result[0, 1] = matrix[0, colCount - 1];
                } else 
                {
                    
                    int[] intervalsUp = new int[colCount];
                    int[] intervalsDown = new int[colCount];
                    int changesCount = 1;

                    for (int j = 1; j < colCount; j++)
                    {
                        if (matrix[1, j - 1] <= matrix[1, j])
                            intervalsUp[j - 1] = 1;
                    }
                    for (int j = 1; j < colCount; j++)
                    {
                        if (matrix[1, j - 1] >= matrix[1, j])
                            intervalsDown[j - 1] = -1;
                    }

                    for (int i = 1; i < colCount - 1; i++)
                    {
                        if (intervalsUp[i - 1] != intervalsUp[i])
                            changesCount++;
                    }

                    result = new int[changesCount, 2];
                    int currentIndex = 0;
                    int consecutiveCount = 0;

                    for (int i = 0; i < colCount; i++)
                    {
                        if (intervalsUp[i] == 1)
                            consecutiveCount++;
                        else
                        {
                            if (consecutiveCount > 0)
                            {
                                result[currentIndex, 0] = matrix[0, i - consecutiveCount];
                                result[currentIndex, 1] = matrix[0, i];
                                currentIndex++;
                                consecutiveCount = 0;
                            }
                        }
                    }

                    consecutiveCount = 0;
                    for (int i = 0; i < colCount; i++)
                    {
                        if (intervalsDown[i] == -1)
                            consecutiveCount++;
                        else
                        {
                            if (consecutiveCount > 0)
                            {
                                result[currentIndex, 0] = matrix[0, i - consecutiveCount];
                                result[currentIndex, 1] = matrix[0, i];
                                currentIndex++;
                                consecutiveCount = 0;
                            }
                        }
                        if (currentIndex == changesCount) break;
                    }

                    for (int k = 0; k < result.GetLength(0); k++)
                    {
                        bool swapped = false;
                        for (int i = 1; i < result.GetLength(0); i++)
                        {
                            if (result[i - 1, 0] > result[i, 0])
                            {
                                (result[i - 1, 0], result[i, 0]) = (result[i, 0], result[i - 1, 0]);
                                (result[i - 1, 1], result[i, 1]) = (result[i, 1], result[i - 1, 1]);
                                swapped = true;
                            }
                        }
                        if (!swapped) break;
                    }

                    int duplicateCount = 0;
                    for (int i = 1; i < result.GetLength(0); i++)
                    {
                        if (result[i - 1, 1] == result[i, 1])
                            duplicateCount++;
                    }

                    if (duplicateCount > 0)
                    {
                        int[,] newResult = new int[changesCount - 1, 2];
                        for (int i = 0; i < changesCount - 1; i++)
                        {
                            for (int j = 0; j < newResult.GetLength(1); j++)
                            {
                                newResult[i, j] = result[i, j];
                            }
                        }
                        result = newResult;
                    }
                }
            }
            return result;
        }

        public int[,] FindLongestSeq(int[,] matrix) {
            int[,] result = new int[0, 0];
            int[,] allIntervals = FindAllSeq(matrix);

            if (allIntervals.Length > 0)
            {
                result = new int[1, 2];

                int maxLength = Math.Abs(allIntervals[0, 1] - allIntervals[0, 0]);
                for (int i = 1; i < allIntervals.GetLength(0); i++)
                {
                    int currentLength = Math.Abs(allIntervals[i, 1] - allIntervals[i, 0]);
                    if (currentLength > maxLength)
                        maxLength = currentLength;
                }

                for (int i = 0; i < allIntervals.GetLength(0); i++)
                {
                    if (Math.Abs(allIntervals[i, 1] - allIntervals[i, 0]) == maxLength)
                    {
                        result[0, 0] = allIntervals[i, 0];
                        result[0, 1] = allIntervals[i, 1];
                        break;
                    }
                }
            }
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
        public delegate double Func<T1, T2>(T1 arg);
        public int CountSignFlips(double a, double b, double h, Func<double, double> func) {
            if (func == null || h <= 0 || a >= b) return 0;

            int count = 0;
            double lastNonZeroSign = 0;
            double x = a;

            while (x <= b + h / 1e9)
            {
                double y = func(x);
                if (Math.Abs(y) > 1e-12)
                {
                    lastNonZeroSign = Math.Sign(y);
                    x += h;
                    break;
                }
                x += h;
            }

            while (x <= b + h / 1e9)
            {
                double y = func(x);
                if (Math.Abs(y) > 1e-12)
                {
                    double currentSign = Math.Sign(y);
                    if (currentSign != lastNonZeroSign)
                    {
                        count++;
                        lastNonZeroSign = currentSign;
                    }
                }
                x += h;
            }

            return count;
        }
        public double FuncA(double x) {
            return x * x - Math.Sin(x);
        }

        public double FuncB(double x) {
            return Math.Exp(x) - 1;
        }

        public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here
            func(array);
            // end

        }
        public void SortInCheckersOrder(int[][] array) {
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0)
                    Array.Sort(array[i]);
                else
                    Array.Sort(array[i], (a, b) => b.CompareTo(a));
            }
        }

        public void SortBySumDesc(int[][] array) {
            Array.Sort(array, (a, b) => b.Sum().CompareTo(a.Sum()));
        }

        public void TotalReverse(int[][] array) {
            foreach (var row in array)
            {
                Array.Reverse(row);
            }
            Array.Reverse(array);
        }
    }
}