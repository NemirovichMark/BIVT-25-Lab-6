using System;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public void Task1(int[,] A, int[,] B)
        {

            // code here
            int LenA = A.GetLength(0);
            int LenB = B.GetLength(0);
            if (LenA != A.GetLength(1) || LenB != B.GetLength(1) || LenA != LenB)
            {
                return;
            }
            int index_A = FindDiagonalMaxIndex(A);
            int index_B = FindDiagonalMaxIndex(B);
            SwapRowColumn(A, index_A, B, index_B);
            // end

        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int MaxIndex = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > matrix[MaxIndex, MaxIndex])
                {
                    MaxIndex = i;
                }
            }
            return MaxIndex;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            int LenA = matrix.GetLength(0);
            for (int i = 0; i <  LenA; i++)
            {
                int temp = matrix[rowIndex, i];
                matrix[rowIndex, i] = B[i, columnIndex];
                B[i, columnIndex] = temp;
            }
        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(1) == B.GetLength(0))
            {
                int max_Row = 0;
                int max_Col = 0;
                int temp = 0;
                for (int i = 0; i < B.GetLength(0); i++)
                {
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                        if (B[i, j] > 0)
                        {
                            temp++;
                        }
                    }
                }
                if (temp > 0)
                {
                    int max_Row1 = 0;
                    for (int i = 0; i < A.GetLength(0); i++)
                    {
                        temp = CountPositiveElementsInRow(A, i);
                        if (temp > max_Row1)
                        {
                            max_Row1 = temp;
                            max_Row = i;
                        }
                    }
                    int max_Col1 = 0;
                    for (int i = 0; i < B.GetLength(1); i++)
                    {
                        temp = CountPositiveElementsInColumn(B, i);
                        if (temp > max_Col1)
                        {
                            max_Col1 = temp;
                            max_Col = i;
                        }
                    }
                    InsertColumn(ref A, max_Row, max_Col, B);
                }
            }
            // end

        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] > 0)
                {
                    counter++;
                }
            }
            return counter;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > 0)
                {
                    counter++;
                }
            }
            return counter;
        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int[,] result = new int[A.GetLength(0) + 1, A.GetLength(1)];
            for (int i = 0; i <= rowIndex; i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    result[i, j] = A[i, j];
                }
            }
            for (int i = 0; i < A.GetLength(1); i++)
            {
                result[rowIndex + 1, i] = B[i, columnIndex];
            }
            for (int i = rowIndex + 1; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    result[i + 1, j] = A[i, j];
                }
            }
            A = result;
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
                        matrix[i, j] = matrix[i, j] * 2;
                    }
                }
            }
            else
            {
                int[] array = new int[matrix.GetLength(0) * matrix.GetLength(1)];
                int k = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        array[k] = matrix[i, j];
                        k++;
                    }
                }
                int n = 1;
                int len = array.Length;
                while (n < len)
                {
                    if (n == 0 || array[n] <= array[n - 1])
                    {
                        n++;
                    }
                    else
                    {
                        (array[n], array[n-1]) = (array[n-1], array[n]);
                        n--;
                    }
                }
                int counter = 0;
                int k1 = 0, k2 = 0, k3 = 0, k4 = 0, k5 = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (k1 == 0 && counter < 5 && matrix[i, j] == array[0])
                        {
                            matrix[i, j] = matrix[i, j] * 2;
                            counter++;
                            k1 = 1;
                        }
                        else if (k2 == 0 && counter < 5 && matrix[i, j] == array[1])
                        {
                            matrix[i, j] = matrix[i, j] * 2;
                            counter++;
                            k2 = 1;
                        }
                        else if (k3 == 0 && counter < 5 && matrix[i, j] == array[2])
                        {
                            matrix[i, j] = matrix[i, j] * 2;
                            counter++;
                            k3 = 1;
                        }
                        else if (k4 == 0 && counter < 5 && matrix[i, j] == array[3])
                        {
                            matrix[i, j] = matrix[i, j] * 2;
                            counter++;
                            k4 = 1;
                        }
                        else if (k5 == 0 && counter < 5 && matrix[i, j] == array[4])
                        {
                            matrix[i, j] = matrix[i, j] * 2;
                            counter++;
                            k5 = 1;
                        }
                        else matrix[i, j] = matrix[i, j] / 2;
                    }
                }
            }
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            int[] array_A = CountNegativesPerRow(A);
            int[] array_B = CountNegativesPerRow(B);
            int pos_A = FindMaxIndex(array_A);
            int pos_B = FindMaxIndex(array_B);
            if (pos_A != -1 && pos_B != -1 && A.GetLength(1) == B.GetLength(1))
            {
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    (A[pos_A, i], B[pos_B, i]) = (B[pos_B, i], A[pos_A, i]);
                }
            }
            // end

        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)];
            int k = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int counter = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        counter++;
                    }
                }
                array[k] = counter;
                k++;
            }
            return array;
        }
        public int FindMaxIndex(int[] array)
        {
            int max_val = 0;
            int max_index = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max_val)
                {
                    max_val = array[i];
                    max_index = i;
                }
            }
            if (max_val == 0)
            {
                return -1;
            }
            else return max_index;
        }
        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public void SortNegativeAscending(int[] matrix)
        {
            int counter = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    counter++;
                }
            }
            int[] array = new int[counter];
            int k = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    array[k] = matrix[i];
                    k++;
                }
            }
            int n = 1;
            while (n < counter)
            {
                if (n == 0 || array[n] > array[n - 1])
                {
                    n++;
                }
                else
                {
                    (array[n], array[n - 1]) = (array[n - 1], array[n]);
                    n--;
                }
            }
            int x = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = array[x];
                    x++;
                }
            }
        }
        public void SortNegativeDescending(int[] matrix)
        {
            int counter = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    counter++;
                }
            }
            int[] array = new int[counter];
            int k = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    array[k] = matrix[i];
                    k++;
                }
            }
            int n = 1;
            while (n < counter)
            {
                if (n == 0 || array[n] < array[n - 1])
                {
                    n++;
                }
                else
                {
                    (array[n], array[n - 1]) = (array[n - 1], array[n]);
                    n--;
                }
            }
            int x = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = array[x];
                    x++;
                }
            }
        }
        public delegate void Sorting(int[] array);
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int k = 1;
            int n = matrix.GetLength(0);
            while (k < n)
            {
                if (k != 0)
                {
                    int max2 = GetRowMax(matrix, k);
                    int max1 = GetRowMax(matrix, k - 1);
                    if (max1 <= max2)
                    {
                        k++;
                    }
                    else
                    {
                        for (int i = 0; i < matrix.GetLength(1); i++)
                        {
                            (matrix[k, i], matrix[k - 1, i]) = (matrix[k - 1, i], matrix[k, i]);
                        }
                        k--;
                    }
                }
                else k++;
            }
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int k = 1;
            int n = matrix.GetLength(0);
            while (k < n)
            {
                if (k != 0)
                {
                    int max2 = GetRowMax(matrix, k);
                    int max1 = GetRowMax(matrix, k - 1);
                    if (max1 >= max2)
                    {
                        k++;
                    }
                    else
                    {
                        for (int i = 0; i < matrix.GetLength(1); i++)
                        {
                            (matrix[k, i], matrix[k - 1, i]) = (matrix[k - 1, i], matrix[k, i]);
                        }
                        k--;
                    }
                }
                else k++;
            }
        }
        public int GetRowMax(int[,] matrix, int row)
        {
            int max = matrix[row, 0];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] > max)
                {
                    max = matrix[row, i];
                }
            }
            return max;
        }
        public delegate void SortRowsByMax(int[,] array);
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
            int[] array = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int counter = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        counter++;
                    }
                }
                array[i] = counter;
            }
            return array;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int max = int.MinValue;
                int counter = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > max && matrix[i, j] < 0)
                    {
                        max = matrix[i, j];
                        counter++;
                    }
                }
                if (counter > 0)
                {
                    array[j] = max;
                }
                else array[j] = 0;
            }
            return array;
        }
        public delegate int[] FindNegatives(int[,] matrix);
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
            int[,] result = new int[1, 1];
            int f0 = 0;
            int f1 = 0;
            int f_minus = 0;
            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                if (matrix[0, i- 1] < matrix[0, i] && matrix[1, i - 1] <= matrix[1, i])
                {
                    f1 = 1;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] >= matrix[1, i])
                {
                    f_minus = 1;
                }
                else
                {
                    f0 = 1;
                }
            }
            int q = matrix[0, 0];
            int w = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[0, i] != q)
                {
                    w = 1;
                }
            }
            if (w == 1)
            {
                if (f1 == 1 && f_minus == 0 && f0 == 0)
                {
                    result[0, 0] = 1;
                }
                else if (f1 == 0 && f_minus == 1 && f0 == 0)
                {
                    result[0, 0] = -1;
                }
                else result[0, 0] = 0;
                return result;
            }
            else
            {
                int[,] a = new int[0, 0];
                return a;
            }
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            int counter = 0;
            int f1 = 0;
            int f_minus = 0;
            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] < matrix[1, i] && f_minus == 0 && f1 == 0)
                {
                    counter++;
                    f1 = 1;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] > matrix[1, i] && f_minus == 0 && f1 == 0)
                {
                    counter++;
                    f_minus = 1;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] > matrix[1, i] && f1 == 1)
                {
                    counter++;
                    f_minus = 1;
                    f1 = 0;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] < matrix[1, i] && f_minus == 1)
                {
                    counter++;
                    f_minus = 0;
                    f1 = 1;
                }
            }
            f1 = 0;
            f_minus = 0;
            int[,] result = new int[counter, 2];
            int t = 0;
            int k = 0;
            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] <= matrix[1, i] && f_minus == 0 && f1 == 0)
                {
                    result[t, 0] = matrix[0, k];
                    f1 = 1;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] >= matrix[1, i] && f_minus == 0 && f1 == 0)
                {
                    result[t, 0] = matrix[0, k];
                    f_minus = 1;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] > matrix[1, i] && f1 == 1)
                {
                    result[t, 1] = matrix[0, k];
                    t++;
                    result[t, 0] = matrix[0, k];
                    f_minus = 1;
                    f1 = 0;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] < matrix[1, i] && f_minus == 1)
                {
                    result[t, 1] = matrix[0, k];
                    t++;
                    result[t, 0] = matrix[0, k];
                    f_minus = 0;
                    f1 = 1;
                }
                k++;
            }
            if (counter > 0)
            {
                result[counter - 1, 1] = matrix[0, matrix.GetLength(1) - 1];
            }
            int k1 = 1;
            int n = result.GetLength(0);
            while (k1 < n)
            {
                if (k1 == 0 || result[k1 - 1, 0] <= result[k1, 0])
                {
                    k1++;
                }
                else
                {
                    (result[k1 - 1, 0], result[k1, 0]) = (result[k1, 0], result[k1 - 1, 0]);
                    (result[k1 - 1, 1], result[k1, 1]) = (result[k1, 1], result[k1 - 1, 1]);
                    k1--;
                }
            }
            int k2 = 1;
            while (k2 < n)
            {
                if (k2 == 0 || result[k2 - 1, 1] <= result[k2, 1])
                {
                    k2++;
                }
                else
                {
                    (result[k2 - 1, 0], result[k2, 0]) = (result[k2, 0], result[k2 - 1, 0]);
                    (result[k2 - 1, 1], result[k2, 1]) = (result[k2, 1], result[k2 - 1, 1]);
                    k2--;
                }
            }
            if (counter == 0)
            {
                int[,] a = new int[0, 0];
                return a;
            }
            else return result;
        }
        public int[,] FindLongestSeq(int[,] matrix)
        {
            int counter = 0;
            int f1 = 0;
            int f_minus = 0;
            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] < matrix[1, i] && f_minus == 0 && f1 == 0)
                {
                    counter++;
                    f1 = 1;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] > matrix[1, i] && f_minus == 0 && f1 == 0)
                {
                    counter++;
                    f_minus = 1;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] > matrix[1, i] && f1 == 1)
                {
                    counter++;
                    f_minus = 1;
                    f1 = 0;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] < matrix[1, i] && f_minus == 1)
                {
                    counter++;
                    f_minus = 0;
                    f1 = 1;
                }
            }
            f1 = 0;
            f_minus = 0;
            int[,] result = new int[counter, 2];
            int t = 0;
            int k = 0;
            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] <= matrix[1, i] && f_minus == 0 && f1 == 0)
                {
                    result[t, 0] = matrix[0, k];
                    f1 = 1;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] >= matrix[1, i] && f_minus == 0 && f1 == 0)
                {
                    result[t, 0] = matrix[0, k];
                    f_minus = 1;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] > matrix[1, i] && f1 == 1)
                {
                    result[t, 1] = matrix[0, k];
                    t++;
                    result[t, 0] = matrix[0, k];
                    f_minus = 1;
                    f1 = 0;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] < matrix[1, i] && f_minus == 1)
                {
                    result[t, 1] = matrix[0, k];
                    t++;
                    result[t, 0] = matrix[0, k];
                    f_minus = 0;
                    f1 = 1;
                }
                    k++;
            }
            if (counter > 0)
            {
                result[counter - 1, 1] = matrix[0, matrix.GetLength(1) - 1];
            }
            int max = int.MinValue;
            int max_index = -1;
            for (int i = 0; i < result.GetLength(0); i++)
            {
                if ((result[i, 1] - result[i, 0]) > max)
                {
                    max = result[i, 1] - result[i, 0];
                    max_index = i;
                }
            }
            if (counter == 0)
            {
                int[,] a = new int[0, 0];
                return a;
            }
            else
            {
                int[,] a = new int[1, 2];
                a[0, 0] = result[max_index, 0];
                a[0, 1] = result[max_index, 1];
                return a;
            }
        }
        public delegate int[,] MathInfo(int[,] matrix);
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
            int counter = 0;
            int f1 = 0;
            int f_minus = 0;
            for (double x = a; x < b; x += h)
            {
                double y = func(x);
                if (y > 0 && f1 == 0 && f_minus == 0)
                {
                    f1 = 1;
                }
                else if (y < 0 && f1 == 0 && f_minus == 0)
                {
                    f_minus = 1;
                }
                else if (y > 0 && f_minus == 1)
                {
                    counter++;
                    f1 = 1;
                    f_minus = 0;
                }
                else if (y < 0 && f1 == 1)
                {
                    counter++;
                    f1 = 0;
                    f_minus = 1;
                }
            }
            return counter;
        }
        public double FuncA(double x)
        {
            double y = x * x - Math.Sin(x);
            return y;
        }
        public double FuncB(double x)
        {
            double y = Math.Pow(Math.E, x) - 1;
            return y;
        }
        public delegate double Func(double a);
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
                    int k = 1;
                    int n = array[i].Length;
                    while (k < n)
                    {
                        if (k == 0 || array[i][k-1] <= array[i][k])
                        {
                            k++;
                        }
                        else
                        {
                            (array[i][k - 1], array[i][k]) = (array[i][k], array[i][k - 1]);
                            k--;
                        }
                    }
                }
                else
                {
                    int k = 1;
                    int n = array[i].Length;
                    while (k < n)
                    {
                        if (k == 0 || array[i][k - 1] >= array[i][k])
                        {
                            k++;
                        }
                        else
                        {
                            (array[i][k - 1], array[i][k]) = (array[i][k], array[i][k - 1]);
                            k--;
                        }
                    }
                }
            }
        }
        public void SortBySumDesc(int[][] array)
        {
            int k = 1;
            int n = array.Length;
            while (k < n)
            {
                int sum1 = 0;
                int sum2 = 0;
                if (k > 0)
                {
                    for (int j1 = 0; j1 < array[k - 1].Length; j1++)
                    {
                        sum1 += array[k - 1][j1];
                    }
                    for (int j2 = 0; j2 < array[k].Length; j2++)
                    {
                        sum2 += array[k][j2];
                    }
                }
                if (k == 0 || sum1 >= sum2)
                {
                    k++;
                }
                else
                {
                    int[] a1 = new int[array[k - 1].Length];
                    int[] a2 = new int[array[k].Length];
                    for (int i = 0; i < array[k-1].Length; i++)
                    {
                        a1[i] = array[k - 1][i];
                    }
                    for (int i = 0; i < array[k].Length; i++)
                    {
                        a2[i] = array[k][i];
                    }
                    array[k - 1] = a2;
                    array[k] = a1;
                    k--;
                }
            }
        }
        public void TotalReverse(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length/2; j++)
                {
                    (array[i][j], array[i][^(j + 1)]) = (array[i][^(j + 1)], array[i][j]);
                }
            }
            for (int i = 0; i < array.Length/2; i++)
            {
                (array[i], array[^(i + 1)]) = (array[^(i + 1)], array[i]);
            }
        }
        public delegate int[][] Action(int[][] array);
    }
}
