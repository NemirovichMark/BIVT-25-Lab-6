using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public void Task1(int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(0) != A.GetLength(1) || B.GetLength(0) != B.GetLength(1) || A.GetLength(0) != B.GetLength(1))
                return;
            int Amaxid = FindDiagonalMaxIndex(A), Bmaxid = FindDiagonalMaxIndex(B);
            SwapRowColumn(A, Amaxid, B, Bmaxid);
            // end

        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int max = int.MinValue, maxid = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    maxid = i;
                }
            return maxid;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1) || B.GetLength(0) != B.GetLength(1) || matrix.GetLength(0) != B.GetLength(1))
                return;
            int x = matrix.GetLength(0);
            for (int i = 0; i < x; i++)
                (matrix[rowIndex, i], B[i, columnIndex]) = (B[i, columnIndex], matrix[rowIndex, i]);
        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(1) != B.GetLength(0))
                return;
            int maxrow = 0, idrow = 0, idcol = 0, maxcol = 0;
            for (int i = 0; i < A.GetLength(0); i++)
                if (CountPositiveElementsInRow(A, i) > maxrow)
                {
                    maxrow = CountPositiveElementsInRow(A, i);
                    idrow = i;
                }
            for (int i = 0; i < B.GetLength(1); i++)
                if (CountPositiveElementsInColumn(B, i) > maxcol)
                {
                    maxcol = CountPositiveElementsInColumn(B, i);
                    idcol = i;
                }
            if (maxrow == 0 || maxcol == 0)
                return;
            InsertColumn(ref A, idrow, idcol, B);
            // end

        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int[,] newA = new int[A.GetLength(0) + 1, A.GetLength(1)];
            for (int i = 0; i < A.GetLength(0) + 1; i++)
                for (int j = 0; j <  A.GetLength(1); j++)
                {
                    if (i < rowIndex + 1)
                        newA[i, j] = A[i, j];
                    else if (i == rowIndex + 1)
                        newA[i, j] = B[j, columnIndex];
                    else
                        newA[i, j] = A[i - 1, j];
                }
            A = newA;
        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int cow = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
                if (matrix[row, i] > 0)
                    cow++;
            return cow;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int cow = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                if (matrix[i, col] > 0)
                    cow++;
            return cow;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            ChangeMatrixValues(matrix);
            // end

        }
        public void ChangeMatrixValues(int[,] matrix)
        {
            int max = int.MinValue;
            var id1 = (0, 0);
            var id2 = (0, 0);
            var id3 = (0, 0);
            var id4 = (0, 0);
            var id5 = (0, 0);
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        id1 = (i, j);
                    }
            max = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > max && (i, j) != id1)
                    {
                        max = matrix[i, j];
                        id2 = (i, j);
                    }
            max = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > max && (i, j) != id1 && (i, j) != id2)
                    {
                        max = matrix[i, j];
                        id3 = (i, j);
                    }
            max = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > max && (i, j) != id1 && (i, j) != id2 && (i, j) != id3)
                    {
                        max = matrix[i, j];
                        id4 = (i, j);
                    }
            max = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > max && (i, j) != id1 && (i, j) != id2 && (i, j) != id3 && (i, j) != id4)
                    {
                        max = matrix[i, j];
                        id5 = (i, j);
                    }
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i, j) == id1 || (i, j) == id2 || (i, j) == id3 || (i, j) == id4 || (i, j) == id5)
                        matrix[i, j] *= 2;
                    else
                        matrix[i, j] /= 2;
                }
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(1) != B.GetLength(1))
                return;
            int id1 = FindMaxIndex(CountNegativesPerRow(A));
            int id2 = FindMaxIndex(CountNegativesPerRow(B));
            if (id1 == 0 && CountNegativesPerRow(A)[0] == 0)
                return;
            if (id2 == 0 && CountNegativesPerRow(B)[0] == 0)
                return;
            for (int i = 0; i < A.GetLength(1); i++)
                (A[id1, i], B[id2, i]) = (B[id2, i], A[id1, i]);
            // end

        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int[] negativ = new int [matrix.GetLength(0)];
            int cow = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] < 0)
                        cow++;
                negativ[i] = cow;
                cow = 0;
            }
            return negativ;
        }
        public int FindMaxIndex(int[] array)
        {
            int max = int.MinValue, maxid = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i] > max)
                {
                    max = array[i];
                    maxid = i;
                }
            return maxid;
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
            int cow = 0;
            for (int i = 0; i < matrix.Length; i++)
                if (matrix[i] < 0)
                    cow++;
            int[] minuses = new int[cow];
            cow = 0;
            for (int i = 0; i < matrix.Length; i++)
                if (matrix[i] < 0)
                    minuses[cow++] = matrix[i];
            cow = 0;
            Array.Sort(minuses);
            for (int i = 0; i < matrix.Length; i++)
                if (matrix[i] < 0)
                    matrix[i] = minuses[cow++];
        }
        public void SortNegativeDescending(int[] matrix)
        {
            int cow = 0;
            for (int i = 0; i < matrix.Length; i++)
                if (matrix[i] < 0)
                    cow++;
            int[] minuses = new int[cow];
            cow = 0;
            for (int i = 0; i < matrix.Length; i++)
                if (matrix[i] < 0)
                    minuses[cow++] = matrix[i];
            cow = 0;
            Array.Sort(minuses);
            Array.Reverse(minuses);
            for (int i = 0; i < matrix.Length; i++)
                if (matrix[i] < 0)
                    matrix[i] = minuses[cow++];
        }
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public delegate void SortRowsByMax(int[,] matrix);
        public int GetRowMax(int[,] matrix, int row)
        {
            int max = int.MinValue;
            for(int i = 0; i < matrix.GetLength(1); i++)
                if (matrix[row, i] > max)
                    max = matrix[row, i];
            return max;
        }
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            for (int k = 0; k < matrix.GetLength(0) - 1; k++)
                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    if (GetRowMax(matrix, i) > GetRowMax(matrix, i + 1))
                        for (int j = 0; j < matrix.GetLength(1); j++)
                            (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                }
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            for (int k = 0; k <  matrix.GetLength(0) - 1; k++)
                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    if (GetRowMax(matrix, i) < GetRowMax(matrix, i + 1))
                        for (int j = 0; j < matrix.GetLength(1); j++)
                            (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
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
            int[] negat = new int[matrix.GetLength(0)];
            int cow = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] < 0)
                        cow++;
                negat[i] = cow;
                cow = 0;
            }
            return negat;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int[] negat = new int[matrix.GetLength(1)];
            int max = int.MinValue;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                    if (matrix[i, j] < 0 && matrix[i, j] > max)
                        max = matrix[i, j];
                if (max != int.MinValue)
                    negat[j] = max;
                max = int.MinValue;
            }
            return negat;
        }
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here
            answer = new int [0, 0];
            if (matrix.GetLength(1) == 1)
                return answer;
            answer = info(matrix);
            // end

            return answer;
        }
        public delegate int[,] MathInfo(int[,] matrix);
        public int[,] DefineSeq(int[,] matrix)
        {
            int[,] ans = new int[1, 1];
            bool f1 = true, f2 = true;
            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
                if (matrix[1, i] < matrix[1, i + 1])
                    f1 = false;
            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
                if (matrix[1, i] > matrix[1, i + 1])
                    f2 = false;
            
            if (f1) ans[0, 0] = -1;
            else if (f2) ans[0, 0] = 1;
            else ans[0, 0] = 0;
            return ans;
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            int cow = 1;
            for (int i = 0; i < matrix.GetLength(1) - 2; i++)
                if ((matrix[1, i] >= matrix[1, i + 1] && matrix[1, i + 1] < matrix[1, i + 2]) || (matrix[1, i] <= matrix[1, i + 1] && matrix[1, i + 1] > matrix[1, i + 2]))
                    cow++;
            int[,] ans = new int [cow, 2];
            cow = 0;
            ans[0, 0] = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(1) - 2; i++)
                if ((matrix[1, i] >= matrix[1, i + 1] && matrix[1, i + 1] < matrix[1, i + 2]) || (matrix[1, i] <= matrix[1, i + 1] && matrix[1, i + 1] > matrix[1, i + 2]))
                {
                    ans[cow++, 1] = matrix[0, i + 1];
                    ans[cow, 0] = matrix[0, i + 1];
                }
            ans[cow, 1] = matrix[0, matrix.GetLength(1) - 1];
            return ans;
        }
        public int[,] FindLongestSeq(int[,] matrix)
        {
            int[,] ans = new int[1, 2];
            int cow = 0,  startx = 0;
            for (int i = 0; i < matrix.GetLength(1) - 2; i++)
            {
                bool f = true;
                if ((matrix[1, i] >= matrix[1, i + 1] && matrix[1, i + 1] < matrix[1, i + 2]) || (matrix[1, i] <= matrix[1, i + 1] && matrix[1, i + 1] > matrix[1, i + 2]))
                    f = false;
                if (cow < matrix[0, i + 2] - matrix[0, startx] && f)
                {
                    cow = matrix[0, i + 2] - matrix[0, startx];
                    ans[0, 1] = matrix[0, i + 2];
                    ans[0, 0] = matrix[0, startx];
                }
                else if (cow < matrix[0, i + 1] - matrix[0, startx])
                {
                    cow = matrix[0, i + 1] - matrix[0, startx];
                    ans[0, 1] = matrix[0, i + 1];
                    ans[0, 0] = matrix[0, startx];
                }
                if (!f)
                    startx = i + 1;

            }
            Console.WriteLine(ans[0, 0]);
            return ans;
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
            int cow = 0;
            for (double i = a; i + 0.0001 < b; i += h)
                if (func(i) * func(i + h) <= 0 && func(i) != 0)
                    cow++;
            return cow;
        }
        public double FuncA(double x)
        {
            double y = x * x - Math.Sin(x);
            //Console.WriteLine(y);
            return y;
        }
        public double FuncB(double x)
        {
            double y = Math.Exp(x) - 1;
            return y;
        }
        public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here
            func(array);
            // end

        }
        public void SortInCheckersOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i+= 2)
            {
                for (int k = 0; k < array[i].Length; k++)
                    for (int j = 0; j < array[i].Length - 1; j++)
                        if (array[i][j] > array[i][j + 1])
                            (array[i][j], array[i][j + 1]) = (array[i][j + 1], array[i][j]);
            }
            for (int i = 1; i < array.Length; i += 2)
            {
                for (int k = 0; k < array[i].Length; k++)
                    for (int j = 0; j < array[i].Length - 1; j++)
                        if (array[i][j] < array[i][j + 1])
                            (array[i][j], array[i][j + 1]) = (array[i][j + 1], array[i][j]);
            }
        }
        public void SortBySumDesc(int[][] array)
        {
            int sum1 = 0, sum2 = 0;
            for (int k = 0; k < array.Length; k++)
                for (int i = 0; i < array.Length - 1; i++)
                {
                    sum1 = 0;
                    sum2 = 0;
                    for (int j = 0; j < array[i].Length; j++)
                        sum1 += array[i][j];
                    for (int j = 0; j < array[i + 1].Length; j++)
                        sum2 += array[i + 1][j];
                    if (sum2 > sum1)
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                }
        }
        public void TotalReverse(int[][] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
                (array[i], array[array.Length - 1 - i]) = (array[array.Length - 1 - i], array[i]);
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[i].Length / 2; j++)
                    (array[i][j], array[i][array[i].Length - 1 - j]) = (array[i][array[i].Length - 1 - j], array[i][j]);
        }
    }
}