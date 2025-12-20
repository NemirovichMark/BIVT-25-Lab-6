using System;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public void Task1(int[,] A, int[,] B)
        {

            // code here
            int nA = A.GetLength(0);
            int mA = A.GetLength(1);
            int nB = B.GetLength(0);
            int mB = B.GetLength(1);
            if (nA != mA || nB != mB)
            {
                return;
            }
            if (nA != nB || mA != mB)
            {
                return;
            }
            int row = FindDiagonalMaxIndex(A);
            int col = FindDiagonalMaxIndex(B);
            SwapRowColumn(A, row, B, col);
            // end
        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int max = int.MinValue;
            int rowcolIndex = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    rowcolIndex = i;
                }
            }
            return rowcolIndex;
        }
        public void SwapRowColumn(int[,] matrixA, int rowIndex, int[,] matrixB, int columnIndex)
        {
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                int tempRow = matrixA[rowIndex, i];
                int tempColumn = matrixB[i, columnIndex];
                matrixA[rowIndex, i] = tempColumn;
                matrixB[i, columnIndex] = tempRow;
            }
        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            int nA = A.GetLength(0);
            int mA = A.GetLength(1);
            int nB = B.GetLength(0);
            int mB = B.GetLength(1);
            if (mA != nB)
            {
                return;
            }
            int maxForRow = int.MinValue;
            int rowMax = -1;
            int colMax = -1;
            for (int i = 0; i < nA; i++)
            {
                int countRowPos = CountPositiveElementsInRow(A, i);
                if (countRowPos > maxForRow)
                {
                    maxForRow = countRowPos;
                    rowMax = i;
                }
            }
            int maxForCol = int.MinValue;
            for (int i = 0; i < mB; i++)
            {
                int countColPos = CountPositiveElementsInColumn(B, i);
                if (countColPos > maxForCol)
                {
                    maxForCol = countColPos;
                    colMax = i;
                }
            }
            InsertColumn(ref A, rowMax, colMax, B);
            // end
        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int nA = A.GetLength(0);
            int mA = A.GetLength(1);
            int[,] answer = new int[nA + 1, mA];
            for (int i = 0; i < nA + 1; i++)
            {
                for (int j = 0; j < mA; j++)
                {
                    if (i <= rowIndex)
                    {
                        answer[i, j] = A[i, j];
                    }
                    else if (i == rowIndex + 1)
                    {
                        answer[i, j] = B[j, columnIndex];
                    }
                    else if (i > rowIndex + 1)
                    {
                        answer[i, j] = A[i - 1, j];
                    }
                }
            }
            A = answer;
        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int countPos = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > 0)
                {
                    countPos++;
                }
            }
            return countPos;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int countPos = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                if (matrix[i, col] > 0)
                {
                    countPos++;
                }
            }
            return countPos;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            ChangeMatrixValues(matrix);
            // end

        }
        public void ChangeMatrixValues(int[,] matrix)
        {
            if (matrix.Length <= 5)
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

            int[] values = new int[matrix.Length];
            int[] index = new int[matrix.Length];
            int k = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    values[k] = matrix[i, j];
                    index[k] = k;
                    k++;
                }
            }

            for (int i = 0; i < values.Length - 1; i++)
            {
                for (int j = 0; j < values.Length - 1 - i; j++)
                {
                    if (values[j] < values[j + 1] || (values[j] == values[j + 1] && index[j] > index[j + 1]))
                    {
                        (values[j], values[j + 1]) = (values[j + 1], values[j]);
                        (index[j], index[j + 1]) = (index[j + 1], index[j]);
                    }
                }
            }

            bool[] maximum = new bool[matrix.Length];
            for (int i = 0; i < 5; i++)
            {
                maximum[index[i]] = true;
            }
            int c = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (maximum[c])
                    {
                        matrix[i, j] *= 2;
                    }
                    else
                    {
                        matrix[i, j] /= 2;
                    }
                    c++;
                }
            }
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            int nA = A.GetLength(0);
            int mA = A.GetLength(1);
            int nB = B.GetLength(0);
            int mB = B.GetLength(1);
            if (nA != nB)
            {
                return;
            }
            int[] negA = CountNegativesPerRow(A);
            int[] negB = CountNegativesPerRow(B);
            if (negA.Sum() == 0 || negB.Sum() == 0)
            {
                return;
            }
            int rowA = FindMaxIndex(negA);
            int rowB = FindMaxIndex(negB);
            for (int j = 0; j < A.GetLength(1); j++)
            {
                int temp = A[rowA, j];
                A[rowA, j] = B[rowB, j];
                B[rowB, j] = temp;
            }         
        }
        public int FindMaxIndex(int[] arr)
        {
            int iMax = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > arr[iMax])
                {
                    iMax = i;
                }
            }
            return iMax;
        }

        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int index = 0;
            int[] answer = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int countNeg = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        countNeg++;
                    }
                }
                answer[index] = countNeg;
                index++;
            }
            return answer;
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
            int countNeg = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    countNeg++;
                }
            }
            int index = 0;
            int[] negatives = new int[countNeg];
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    negatives[index] = matrix[i];
                    index++;
                }
            }
            for (int i = 0; i < negatives.Length - 1; i++)
            {
                for (int j = 0; j < negatives.Length - i - 1; j++)
                {
                    if (negatives[j] > negatives[j + 1])
                    {
                        (negatives[j], negatives[j + 1]) = (negatives[j + 1], negatives[j]);
                    }
                }
            }
            int fill = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = negatives[fill];
                    fill++;
                }
            }
        }
        public void SortNegativeDescending(int[] matrix)
        {
            int countNeg = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    countNeg++;
                }
            }
            int index = 0;
            int[] negatives = new int[countNeg];
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    negatives[index] = matrix[i];
                    index++;
                }
            }
            for (int i = 0; i < negatives.Length - 1; i++)
            {
                for (int j = 0; j < negatives.Length - i - 1; j++)
                {
                    if (negatives[j] < negatives[j + 1])
                    {
                        (negatives[j], negatives[j + 1]) = (negatives[j + 1], negatives[j]);
                    }
                }
            }
            int fill = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = negatives[fill];
                    fill++;
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
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int[] maxEl = new int[matrix.GetLength(0)];
            int[] indEl = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = int.MinValue;
                int index = -1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        index = i;
                    }
                }
                maxEl[i] = max;
                indEl[i] = index;
            }
            for (int i = 0; i < maxEl.Length - 1; i++)
            {
                for (int j = 0; j < maxEl.Length - i - 1; j++)
                {
                    if (maxEl[j] > maxEl[j + 1])
                    {
                        (maxEl[j], maxEl[j + 1]) = (maxEl[j + 1], maxEl[j]);
                        (indEl[j], indEl[j + 1]) = (indEl[j + 1], indEl[j]);
                    }
                }
            }
            int[,] answer = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    answer[i, j] = matrix[indEl[i], j];
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = answer[i, j];
                }
            }
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int[] maxEl = new int[matrix.GetLength(0)];
            int[] indEl = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = int.MinValue;
                int index = -1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        index = i;
                    }
                }
                maxEl[i] = max;
                indEl[i] = index;
            }
            for (int i = 0; i < maxEl.Length - 1; i++)
            {
                for (int j = 0; j < maxEl.Length - i - 1; j++)
                {
                    if (maxEl[j] < maxEl[j + 1])
                    {
                        (maxEl[j], maxEl[j + 1]) = (maxEl[j + 1], maxEl[j]);
                        (indEl[j], indEl[j + 1]) = (indEl[j + 1], indEl[j]);
                    }
                }
            }
            int[,] answer = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    answer[i, j] = matrix[indEl[i], j];
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = answer[i, j];
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

        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int index = 0;
            int[] answer = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int countNeg = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        countNeg++;
                    }
                }
                answer[index] = countNeg;
                index++;
            }
            return answer;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int[] answer = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int max = int.MinValue;
                int count = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                    if (matrix[i, j] < 0 && matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                if (count == 0)
                {
                    answer[j] = 0;
                }
                else { answer[j] = max; }
            }
            return answer;
        }
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here
            answer = info(matrix);
            // end

            return answer;
        }
        public delegate int[,] MathInfo(int[,] matrix);
        public int[,] DefineSeq(int[,] matrix)
        {
            bool up = true, down = true;
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[1, j] > matrix[1, j + 1])
                {
                    up = false;
                }
                if (matrix[1, j] < matrix[1, j + 1])
                {
                    down = false;
                }
            }
            if (up && down)
            {
                return new int[0, 0];
            }
            else if (up)
            {
                return new int[,] { { 1 } };
            }
            else if (down)
            {
                return new int[,] { { -1 } };
            }
            else
            {
                return new int[,] { { 0 } };
            }
        }


        public int[,] FindAllSeq(int[,] matrix)
        {

            int cols = matrix.GetLength(1);
            int[,] emptyMatrix = new int[0, 0];
            if (cols < 2) return emptyMatrix;
            int rowsInResMAtrix = 0;
            int[] arrayY = new int[cols];
            int index = 0;
            for (int col = 0; col < cols; col++)
            {
                arrayY[index++] = matrix[1, col];
            }
            int l = 0;
            int r = 1;
            for (int col = 0; col < cols; col++)
            {
                if (arrayY[l] <= arrayY[r])
                {
                    int startIndex = l;
                    while (r < cols && l < cols && arrayY[l] <= arrayY[r])
                    {
                        l++;
                        r++;
                    }
                    col = l;
                    rowsInResMAtrix++;
                }
                else if (arrayY[l] >= arrayY[r])
                {
                    int startIndex = l;
                    while (r < cols && l < cols && arrayY[l] >= arrayY[r])
                    {
                        l++;
                        r++;
                    }
                    col = l;
                    rowsInResMAtrix++;
                }
            }

            int[,] resMatrix = new int[rowsInResMAtrix, 2];
            int resRow = 0;
            int resCol = 0;
            l = 0;
            r = 1;
            for (int col = 0; col < cols; col++)
            {
                if (arrayY[l] <= arrayY[r])
                {
                    int startIndex = l;
                    while (r < cols && l < cols && arrayY[l] <= arrayY[r])
                    {
                        l++;
                        r++;
                    }
                    col = l;
                    resMatrix[resRow, resCol] = matrix[0, startIndex];
                    resMatrix[resRow, resCol + 1] = matrix[0, l];
                    resRow++;
                }
                else if (arrayY[l] >= arrayY[r])
                {
                    int startIndex = l;
                    while (r < cols && l < cols && arrayY[l] >= arrayY[r])
                    {
                        l++;
                        r++;
                    }
                    col = l;
                    resMatrix[resRow, resCol] = matrix[0, startIndex];
                    resMatrix[resRow, resCol + 1] = matrix[0, l];
                    resRow++;
                }
            }
            return resMatrix;
        }

        public int[,] FindLongestSeq(int[,] matrix)
        {
            int cols = matrix.GetLength(1);
            int[,] emptyMatrix = new int[0, 0];
            if (cols < 2) return emptyMatrix;

            int[] arrayY = new int[cols];
            int index = 0;
            for (int col = 0; col < cols; col++)
            {
                arrayY[index++] = matrix[1, col];
            }

            int[,] resMatrix = new int[1, 2];
            int l = 0;
            int r = 1;
            int mx = 0;
            for (int col = 0; col < cols; col++)
            {
                int interval;

                if (arrayY[l] <= arrayY[r])
                {
                    int startIndex = l;
                    while (r < cols && l < cols && arrayY[l] <= arrayY[r])
                    {
                        l++;
                        r++;
                    }
                    col = l;
                    interval = Math.Abs(matrix[0, l] - matrix[0, startIndex]);
                    if (interval > mx)
                    {
                        mx = interval;
                        resMatrix[0, 0] = matrix[0, startIndex];
                        resMatrix[0, 1] = matrix[0, l];
                    }
                }
                else if (arrayY[l] >= arrayY[r])
                {
                    int startIndex = l;
                    while (r < cols && l < cols && arrayY[l] >= arrayY[r])
                    {
                        l++;
                        r++;
                    }
                    col = l;

                    interval = Math.Abs(matrix[0, l] - matrix[0, startIndex]);
                    if (interval > mx)
                    {
                        mx = interval;
                        resMatrix[0, 0] = matrix[0, startIndex];
                        resMatrix[0, 1] = matrix[0, l];
                    }
                }
            }
            return resMatrix;
        }

        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            // code here
            answer = CountSignFlips(a, b, h, func);
            // end

            return answer;

        }
        public delegate double Func(double x);

        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            int count = 0;
            double y1 = func(a);
            for (double x = a; x + h <= b; x += h)
            {
                double y2 = func(x + h);
                if (y1 * y2 < 0)
                {
                    count++;
                }
                y1 = y2;
            }
            return count;
        }
        public double FuncA(double x)
        {
            return x * x - Math.Sin(x);
        }
        public double FuncB(double x)
        {
            return Math.Pow(Math.E, x) - 1;
        }
        public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here
            func(array);
            // end

        }
        //public delegate void Action(int[][] array);
        public void SortInCheckersOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
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
            if (array == null) return;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j].Sum() < array[j + 1].Sum())
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
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




