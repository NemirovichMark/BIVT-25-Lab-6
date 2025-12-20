using System;
using System.Collections.Immutable;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public delegate void Sorting(int[] array);

    public delegate void SortRowsByMax(int[,] matrix);

    public delegate int[] FindNegatives(int[,] matrix);

    public delegate int[,] MathInfo(int[,] matrix);

    public delegate double Func(double x);   // Func<double,double>

    public delegate void Action(int[][] array);   // Action<int[][]>


    public class Purple
    {
        public void Task1(int[,] A, int[,] B)
        {

            // code here
            int idA = FindDiagonalMaxIndex(A);
            int idB = FindDiagonalMaxIndex(B);

            SwapRowColumn(A, idA, B, idB);

            // end

        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            int countA = 0;
            int rowId = 0;
            for (int row = 0; row < A.GetLength(0); row++)
            {
                int positives = CountPositiveElementsInRow(A, row);
                if (countA < positives)
                {
                    countA = positives;
                    rowId = row;
                }
            }

            int countB = 0;
            int colId = 0;
            for (int col = 0; col < B.GetLength(1); col++)
            {
                int positives = CountPositiveElementsInColumn(B, col);
                if (countB < positives)
                {
                    countB = positives;
                    colId = col;
                }
            }


            if (countB > 0 && A.GetLength(1) == B.GetLength(0))
            {
                InsertColumn(ref A, rowId, colId, B);
            }
            // end

        }
        public void Task3(int[,] matrix)
        {

            // code here
            ChangeMatrixValues(matrix);

            // end

        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(1) == B.GetLength(1))
            {
                int idA = FindMaxIndex(CountNegativesPerRow(A));
                int idB = FindMaxIndex(CountNegativesPerRow(B));

                if (idA != -1 && idB != -1)
                {
                    for(int i = 0; i < A.GetLength(1); i++)
                    {
                        (A[idA, i], B[idB, i]) = (B[idB, i], A[idA, i]);
                    }
                }
            }



            // end

        }
        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            // code here
            negatives = find(matrix);
            // end

            return negatives;
        }
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here

            // end

            return answer;
        }
        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            // code here
            answer = CountSignFlips(a, b, h, func);
            // end

            return answer;
        }
        public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here
            func(array);
            // end

        }

        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int id = -1;
            int mx = int.MinValue;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > mx)
                {
                    id = i;
                    mx = matrix[i, i];
                }
            }


            return id;
        }

        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            if (matrix.GetLength(0) == matrix.GetLength(1) && matrix.GetLength(1) == B.GetLength(0) && B.GetLength(0) == B.GetLength(1))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    (matrix[rowIndex, i], B[i, columnIndex]) = (B[i, columnIndex], matrix[rowIndex, i]);
                }


            }



        }

        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {

            int[,] newMatrix = new int[A.GetLength(0) + 1, A.GetLength(1)];

            for (int i = 0; i <= rowIndex; i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    newMatrix[i, j] = A[i, j];
                }
            }

            for (int i = 0; i < B.GetLength(0); i++)
            {
                newMatrix[rowIndex + 1, i] = B[i, columnIndex];
            }

            for (int i = rowIndex + 1; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    newMatrix[i + 1, j] = A[i, j];
                }
            }

            A = newMatrix;




        }

        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int count = 0;

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] > 0) count++;
            }


            return count;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > 0) count++;
            }


            return count;
        }

        public void ChangeMatrixValues(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int n = rows * cols;

            if (n == 0) return;

            bool[] top = new bool[n];

            if (n <= 5)
            {
                for (int i = 0; i < n; i++) top[i] = true;
            }

            else
            {
                int[] topIdx = new int[5];
                int[] topVal = new int[5];

                int count = 0;
                int idx = 0;

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++, idx++)
                    {
                        int v = matrix[r, c];
                        int pos = 0;

                        while (pos < count && v <= topVal[pos]) pos++;

                        if (pos >= 5)
                            continue;


                        int limit;
                        if (count < 4)
                        {
                            limit = count;
                        }
                        else limit = 4;
                        
                        for (int k = limit; k > pos; k--)
                        {
                            topVal[k] = topVal[k - 1];
                            topIdx[k] = topIdx[k - 1];
                        }
                        topVal[pos] = v;
                        topIdx[pos] = idx;
                        if (count < 5) count++;
                    }
                }
                for (int i = 0; i < 5; i++) top[topIdx[i]] = true;
            }

            int p = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++, p++)
                {
                    matrix[r, c] = top[p] ? matrix[r, c] * 2 : matrix[r, c] / 2;
                }
            }
        }

        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int count = 0;
            int[] mxRow = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                count = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0) count++;
                }

                mxRow[i] = count;
            }


            return mxRow;
        }

        public int FindMaxIndex(int[] array)
        {
            int id = 0;
            int mxCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > mxCount)
                {
                    mxCount = array[i];
                    id = i;
                }
            }

            if (mxCount == 0) return -1;
            
            return id;
        }

        public void SortNegativeAscending(int[] matrix)
        {
            int countNegatives = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0) countNegatives++;
            }

            int[] negativeArray = new int[countNegatives];
            int curId = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    negativeArray[curId++] = matrix[i];
                }
            }

            curId = 0;

            Array.Sort(negativeArray);

            for(int i  = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = negativeArray[curId++];
                }
            }

        }
        public void SortNegativeDescending(int[] matrix)
        {
            int countNegatives = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0) countNegatives++;
            }

            int[] negativeArray = new int[countNegatives];
            int curId = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    negativeArray[curId++] = matrix[i];
                }
            }

            curId = negativeArray.Length - 1;

            Array.Sort(negativeArray);

            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] <  0)
                {
                    matrix[i] = negativeArray[curId--];
                }
            }
        }

        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] max = new int[rows];
            for (int i = 0; i < rows; i++)
                max[i] = GetRowMax(matrix, i);

            for (int pass = 0; pass < rows - 1; pass++)
            {
                for (int i = 0; i < rows - 1 - pass; i++)
                {
                    if (max[i] > max[i + 1])
                    {
                        (max[i], max[i + 1]) = (max[i + 1], max[i]);

                        for (int j = 0; j < cols; j++)
                            (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                    }
                }
            }
        }


        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] max = new int[rows];
            for (int i = 0; i < rows; i++)
                max[i] = GetRowMax(matrix, i);

            for (int pass = 0; pass < rows - 1; pass++)
            {
                for (int i = 0; i < rows - 1 - pass; i++)
                {
                    if (max[i] < max[i + 1])
                    {
                        (max[i], max[i + 1]) = (max[i + 1], max[i]);

                        for (int j = 0; j < cols; j++)
                            (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                    }
                }
            }
        }

        public int GetRowMax(int[,] matrix, int row)
        {
            int mx = int.MinValue;
            int element;

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                element = matrix[row, i];
                if (mx < element) mx = element;
            }

            return mx;
        }

        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int[] negatives = new int[matrix.GetLength(0)];
            int count;

            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0) count++;
                }
                negatives[i] = count;
            }

            return negatives;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int[] negatives = new int[matrix.GetLength(1)];
            int mn;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                mn = int.MinValue;
                for (int i = 0;i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > mn && matrix[i, j] < 0) mn = matrix[i, j];
                }
                if (mn != int.MinValue) negatives[j] = mn;
                else negatives[j] = 0;
            }

            return negatives;
        }

        public int[,] DefineSeq(int[,] matrix)
        {
            return new int[0, 0];
        }

        public int[,] FindAllSeq(int[,] matrix)
        {
            return new int[0, 0];
        }

        public int[,] FindLongestSeq(int[,] matrix)
        {
            return new int[0, 0];
        }

        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            int count = 0;
            double currentArg = func(a);

            for (double x = a + h; x <= b; x += h)
            {
                if (currentArg < 0 && func(x) >= 0 || currentArg >= 0 && func(x) < 0)
                {
                    count++;
                }
                currentArg = func(x);
            }


            return count;
        }

        public double FuncA(double x)
        {
            double argue = 0;

            argue = Math.Pow(x, 2) - Math.Sin(x);


            return argue;
        }

        public double FuncB(double x)
        {
            double argue = 0;

            argue = Math.Exp(x) - 1;

            return argue;
        }

        public void SortInCheckersOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0) Array.Sort(array[i]);
                else
                {
                    Array.Sort(array[i]);
                    Array.Reverse(array[i]);
                }
            }
        }
        public void SortBySumDesc(int[][] array)
        {
            int[] sums = new int[array.Length];
            int currentSum;

            for (int i = 0; i < array.Length; i++)
            {
                currentSum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    currentSum+= array[i][j];
                }
                sums[i] = currentSum;
            }

            for (int i = 0; i <  sums.Length - 1; i++)
            {
                for (int j = 0; j < sums.Length - 1 - i; j++)
                {
                    if (sums[j] < sums[j + 1])
                    {
                        (sums[j], sums[j+1]) = (sums[j+1], sums[j]);
                        (array[j], array[j+1]) = (array[j+1], array[j]);
                    }
                }
            }
            


        }

        public void TotalReverse(int[][] array)
        {
            foreach (int[] x in array)
            {
                Array.Reverse(x);
            }
            Array.Reverse(array);
        }


    }
}