using System;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int i_mx = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[i, i] > matrix[i_mx, i_mx]) i_mx = i;
            }
            return i_mx;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            for (int i = 0; i <  B.GetLength(0); i++)
            {
                (matrix[rowIndex, i], B[i, columnIndex]) = (B[i, columnIndex], matrix[rowIndex, i]);
            }
        }

        public void Task1(int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(0) != B.GetLength(0)) return;
            SwapRowColumn(A, FindDiagonalMaxIndex(A), B, FindDiagonalMaxIndex(B));
            // end

        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int[,] newA = new int[A.GetLength(0) + 1, A.GetLength(1)];
            for (int i = 0; i <= rowIndex; i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    newA[i, j] = A[i, j];
                }
            }

            for (int j = 0; j < A.GetLength(1); j++)
            {
                newA[rowIndex + 1, j] = B[j, columnIndex];
            }

            for (int i = rowIndex + 2; i < newA.GetLength(0); i++)
            {
                for (int j = 0; j < newA.GetLength(1); j++)
                {
                    newA[i, j] = A[i - 1, j];
                }
            }
            A = newA;
        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] > 0) cnt++;
            }
            return cnt;
        }

        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > 0) cnt++;
            }
            return cnt;
        }
        public void Task2(ref int[,] A, int[,] B)
        {
            if (A.GetLength(1) != B.GetLength(0)) return;

            int rI = 0;
            int maxRowVal = -1;

            for (int i = 0; i < A.GetLength(0); i++)
            {
                int cnt = CountPositiveElementsInRow(A, i);
                if (cnt > maxRowVal)
                {
                    maxRowVal = cnt;
                    rI = i;
                }
            }

            int cI = -1;
            int maxColVal = 0;
            for (int j = 0; j < B.GetLength(1); j++)
            {
                int cnt = CountPositiveElementsInColumn(B, j);

                if (cnt > maxColVal)
                {
                    maxColVal = cnt;
                    cI = j;
                }
            }

            if (cI == -1) return;

            InsertColumn(ref A, rI, cI, B);
        }
        public void ChangeMatrixValues(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int n = rows * cols;
            
            if (n < 5)
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

            int[] indices = new int[n];
            for (int i = 0; i < n; i++)
            {
                indices[i] = i;
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    int index1 = indices[j];
                    int index2 = indices[j + 1];

                    int val1 = matrix[index1 / cols, index1 % cols];
                    int val2 = matrix[index2 / cols, index2 % cols];

                    if (val2 > val1 || (val2 == val1 && index2 < index1))
                    {
                        int temp = indices[j];
                        indices[j] = indices[j + 1];
                        indices[j + 1] = temp;
                    }
                }
            }

            bool[,] shouldDouble = new bool[rows, cols];

            for (int i = 0; i < 5; i++)
            {
                int idx = indices[i];
                shouldDouble[idx / cols, idx % cols] = true;
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (shouldDouble[i, j])
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

        public void Task3(int[,] matrix)
        {

            // code here
            ChangeMatrixValues(matrix);
            // end

        }


        public int[] CountNegativesPerRow(int[,] matrix)
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

        public int FindMaxIndex(int[] array)
        {
            if (array.Length == 0) return -1;

            int maxIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[maxIndex])
                {
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        public void Task4(int[,] A, int[,] B)
        {
            if (A.GetLength(1) != B.GetLength(1)) return;

            int[] negativesA = CountNegativesPerRow(A);
            int[] negativesB = CountNegativesPerRow(B);

            int indexA = FindMaxIndex(negativesA);
            int indexB = FindMaxIndex(negativesB);

            if (indexA == -1 || indexB == -1) return;

            if (negativesA[indexA] == 0 || negativesB[indexB] == 0) return;

            int cols = A.GetLength(1); 
            for (int j = 0; j < cols; j++)
            {
                int temp = A[indexA, j];
                A[indexA, j] = B[indexB, j];
                B[indexB, j] = temp;
            }
        }

        public delegate void Sorting(int[] array);

        public void SortNegativeAscending(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0) continue;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] >= 0) continue;

                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public void SortNegativeDescending(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0) continue;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] >= 0) continue;

                    if (array[i] < array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public void Task5(int[] array, Sorting sort)
        {
            sort(array);
        }

        public delegate void SortRowsByMax(int[,] matrix);

        public int GetRowMax(int[,] matrix, int row)
        {
            int max = matrix[row, 0];
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > max)
                {
                    max = matrix[row, j];
                }
            }
            return max;
        }

        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    if (GetRowMax(matrix, j) > GetRowMax(matrix, j + 1))
                    {
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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    if (GetRowMax(matrix, j) < GetRowMax(matrix, j + 1))
                    {
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

        public void Task6(int[,] matrix, SortRowsByMax sort)
        {
            sort(matrix);
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
                int maxNeg = int.MinValue;
                bool foundNegative = false;

                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        if (!foundNegative || matrix[i, j] > maxNeg)
                        {
                            maxNeg = matrix[i, j];
                            foundNegative = true;
                        }
                    }
                }

                if (!foundNegative)
                {
                    result[j] = 0;
                }
                else
                {
                    result[j] = maxNeg;
                }
            }
            return result;
        }

        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = find(matrix); 

            return negatives;
        }

        public delegate int[,] MathInfo(int[,] matrix);

        public int[,] DefineSeq(int[,] matrix)
        {
            if (matrix.GetLength(1) < 2) return new int[0, 0];

            int cols = matrix.GetLength(1);
            bool isAsc = true;
            bool isDesc = true;

            for (int i = 0; i < cols - 1; i++)
            {
                if (matrix[1, i] < matrix[1, i + 1])
                {
                    isDesc = false;
                }
                if (matrix[1, i] > matrix[1, i + 1])
                {
                    isAsc = false;
                }
            }

            int val = 0;
            if (isAsc && !isDesc) val = 1;
            else if (isDesc && !isAsc) val = -1;
            else val = 0;

            return new int[,] { { val } };
        }

        public int[,] FindAllSeq(int[,] matrix)
        {
            if (matrix.GetLength(1) < 2) return new int[0, 0];

            int count = CountMonotonicIntervals(matrix);

            int[,] result = new int[count, 2];

            int start = 0;
            int dir = 0; 
            int cols = matrix.GetLength(1);
            int index = 0;

            for (int i = 0; i < cols - 1; i++)
            {
                int diff = matrix[1, i + 1] - matrix[1, i];

                if (dir == 0)
                {
                    if (diff > 0) dir = 1;
                    else if (diff < 0) dir = -1;
                }
                else if (dir == 1 && diff < 0)
                {
                    result[index, 0] = matrix[0, start];
                    result[index, 1] = matrix[0, i];
                    index++;
                    start = i;
                    dir = -1;
                }
                else if (dir == -1 && diff > 0)
                {
                    result[index, 0] = matrix[0, start];
                    result[index, 1] = matrix[0, i];
                    index++;
                    start = i;
                    dir = 1;
                }
            }

            if (index < count)
            {
                result[index, 0] = matrix[0, start];
                result[index, 1] = matrix[0, cols - 1];
            }

            return result;
        }

        private int CountMonotonicIntervals(int[,] matrix)
        {
            int count = 0;
            int start = 0;
            int dir = 0;
            int cols = matrix.GetLength(1);

            for (int i = 0; i < cols - 1; i++)
            {
                int diff = matrix[1, i + 1] - matrix[1, i];

                if (dir == 0)
                {
                    if (diff > 0) dir = 1;
                    else if (diff < 0) dir = -1;
                }
                else if (dir == 1 && diff < 0)
                {
                    count++;
                    start = i;
                    dir = -1;
                }
                else if (dir == -1 && diff > 0)
                {
                    count++;
                    start = i;
                    dir = 1;
                }
            }
            count++;
            return count;
        }

        public int[,] FindLongestSeq(int[,] matrix)
        {
            if (matrix.GetLength(1) < 2) return new int[0, 0];

            int start = 0;
            int dir = 0;
            int cols = matrix.GetLength(1);

            int bestStart = matrix[0, 0];
            int bestEnd = matrix[0, 0];
            double maxLen = -1.0; 

            void CheckMax(int sIndex, int eIndex)
            {
                int sVal = matrix[0, sIndex];
                int eVal = matrix[0, eIndex];
                double len = Math.Abs((double)eVal - sVal);

                if (len > maxLen)
                {
                    maxLen = len;
                    bestStart = sVal;
                    bestEnd = eVal;
                }
            }

            for (int i = 0; i < cols - 1; i++)
            {
                int diff = matrix[1, i + 1] - matrix[1, i];

                if (dir == 0)
                {
                    if (diff > 0) dir = 1;
                    else if (diff < 0) dir = -1;
                }
                else if (dir == 1 && diff < 0)
                {
                    CheckMax(start, i);
                    start = i;
                    dir = -1;
                }
                else if (dir == -1 && diff > 0)
                {
                    CheckMax(start, i);
                    start = i;
                    dir = 1;
                }
            }
            CheckMax(start, cols - 1);

            return new int[,] { { bestStart, bestEnd } };
        }

        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            if (matrix.GetLength(1) < 1)
            {
                return new int[0, 0];
            }

            return info(matrix);
        }



        public double FuncA(double x)
        {
            return x * x - Math.Sin(x);
        }

        public double FuncB(double x)
        {
            return Math.Exp(x) - 1;
        }

        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            if (h <= 0 || a >= b) return 0;

            int count = 0;
            int steps = (int)Math.Round((b - a) / h);

            for (int i = 0; i < steps; i++)
            {
                double x1 = a + i * h;
                double x2 = a + (i + 1) * h;

                double y1 = func(x1);
                double y2 = func(x2);

                if (y1 * y2 < 0 || (y1 != 0 && y2 == 0))
                {
                    count++;
                }
            }
            return count;
        }

        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            return CountSignFlips(a, b, h, func);
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
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] == null || array[j + 1] == null) continue;

                    long sum1 = 0;
                    for (int k = 0; k < array[j].Length; k++) sum1 += array[j][k];

                    long sum2 = 0;
                    for (int k = 0; k < array[j + 1].Length; k++) sum2 += array[j + 1][k];

                    if (sum1 < sum2)
                    {
                        int[] temp = array[j];
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
                if (array[i] == null) continue;

                int left = 0;
                int right = array[i].Length - 1;
                while (left < right)
                {
                    int temp = array[i][left];
                    array[i][left] = array[i][right];
                    array[i][right] = temp;
                    left++;
                    right--;
                }
            }

            int top = 0;
            int bottom = array.Length - 1;
            while (top < bottom)
            {
                int[] temp = array[top];
                array[top] = array[bottom];
                array[bottom] = temp;
                top++;
                bottom--;
            }
        }

        public void Task10(int[][] array, Action<int[][]> action)
        {
            action(array);
        }
    }
}
