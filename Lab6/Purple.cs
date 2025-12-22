﻿using System;
using System;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

@@ -10,47 +10,100 @@ public void Task1(int[,] A, int[,] B)
        {

            // code here

            if (A.GetLength(0) == A.GetLength(1) && B.GetLength(0) == B.GetLength(1) && A.GetLength(0) == B.GetLength(0))
            {
                int AMax = FindDiagonalMaxIndex(A);
                int BMax = FindDiagonalMaxIndex(B);
                SwapRowColumn(A, AMax, B, BMax);
            }
            // end

        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here

            if (A.GetLength(1) == B.GetLength(0))
            {
                int maxRow = 0, maxCol = 0, temp = 0;
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
                    int MaxR = 0;
                    for (int i = 0; i < A.GetLength(0); i++)
                    {
                        temp = CountPositiveElementsInRow(A, i);
                        if (temp > MaxR)
                        {
                            MaxR = temp;
                            maxRow = i;
                        }
                    }
                    int MaxC = 0;
                    for (int i = 0; i < B.GetLength(1); i++)
                    {
                        temp = CountPositiveElementsInColumn(B, i);
                        if (temp > MaxC)
                        {
                            MaxC = temp;
                            maxCol = i;
                        }
                    }
                    InsertColumn(ref A, maxRow, maxCol, B);
                }
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

            // end
            int[] arrayA = CountNegativesPerRow(A);
            int[] arrayB = CountNegativesPerRow(B);
            int positionA = FindMaxIndex(arrayA);
            int positionB = FindMaxIndex(arrayB);
            if (positionA != -1 && positionB != -1 && A.GetLength(1) == B.GetLength(1)) 
                {
                    for (int i = 0; i < A.GetLength(1); i++)
                    {
                        (A[positionA, i], B[positionB, i]) = (B[positionB, i], A[positionA, i]);
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
@@ -59,7 +112,7 @@ public int[] Task7(int[,] matrix, FindNegatives find)
            int[] negatives = null;

            // code here

            negatives = find(matrix);
            // end

            return negatives;
@@ -69,7 +122,7 @@ public int[] Task7(int[,] matrix, FindNegatives find)
            int[,] answer = null;

            // code here

            answer = info(matrix);
            // end

            return answer;
@@ -79,7 +132,7 @@ public int Task9(double a, double b, double h, Func<double, double> func)
            int answer = 0;

            // code here

            answer = CountSignFlips(a, b, h, func);
            // end

            return answer;
@@ -88,9 +141,749 @@ public void Task10(int[][] array, Action<int[][]> func)
        {

            // code here

            func(array);
            // end

        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int max = matrix[0, 0], maxIndex = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i,i] > max)
                {
                    max = matrix[i, i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                (matrix[rowIndex, i], B[i, columnIndex]) = (B[i, columnIndex], matrix[rowIndex, i]);
            }
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
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] > 0)
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
        public void ChangeMatrixValues(int[,] matrix)
        {
            if (matrix.GetLength(0)*matrix.GetLength(1) < 5)
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
                int t = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        array[t] = matrix[i,j];
                        t++;
                    }
                }
                int n = 1, k = array.Length;
                while (n < k)
                {
                    if (n == 0 || array[n] <= array[n - 1])
                    {
                        n++;
                    }
                    else
                    {
                        (array[n], array[n - 1]) = (array[n - 1], array[n]);
                        n--;
                    }
                }
                int count = 0, k1 = 0, k2 = 0, k3 = 0, k4 = 0, k5 = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (k1 == 0 && count < 5 && matrix[i, j] == array[0])
                        {
                            matrix[i, j] = matrix[i, j] * 2;
                            count++;
                            k1 = 1;
                        }
                        else if (k2 == 0 && count < 5 && matrix[i, j] == array[1])
                        {
                            matrix[i, j] = matrix[i, j] * 2;
                            count++;
                            k2 = 1;
                        }
                        else if (k3 == 0 && count < 5 && matrix[i, j] == array[2])
                        {
                            matrix[i, j] = matrix[i, j] * 2;
                            count++;
                            k3 = 1;
                        }
                        else if (k4 == 0 && count < 5 && matrix[i, j] == array[3])
                        {
                            matrix[i, j] = matrix[i, j] * 2;
                            count++;
                            k4 = 1;
                        }
                        else if (k5 == 0 && count < 5 && matrix[i, j] == array[4])
                        {
                            matrix[i, j] = matrix[i, j] * 2;
                            count++;
                            k5 = 1;
                        }
                        else
                            matrix[i, j] = matrix[i, j] / 2;
                    }
                }
            }
        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)];
            int t = 0;
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
                array[t] = count;
                t++;
            }
            return array;
        }
        public int FindMaxIndex(int[] array)
        {
            int max = 0, position = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    position = i;
                }
            }
            if (max == 0)
            {
                return -1;
            }
            else return position;
        }
        public void SortNegativeAscending(int[] matrix)
        {
            int count = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    count++;
                }
            }
            int[] array = new int[count];
            int t = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    array[t] = matrix[i];
                    t++;
                }
            }
            int k = 1;
            while (k < count)
            {
                if (k == 0 || array[k] > array[k - 1])
                {
                    k++;
                }
                else
                {
                    (array[k], array[k - 1]) = (array[k - 1], array[k]);
                    k--;
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
            int count = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    count++;
                }
            }
            int[] array = new int[count];
            int t = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    array[t] = matrix[i];
                    t++;
                }
            }
            int k = 1;
            while (k < count)
            {
                if (k == 0 || array[k] < array[k - 1])
                {
                    k++;
                }
                else
                {
                    (array[k], array[k - 1]) = (array[k - 1], array[k]);
                    k--;
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
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int k = 1, n = matrix.GetLength(0);
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
            int k = 1, n = matrix.GetLength(0);
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
            int max = matrix[row,0];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row,i] > max)
                {
                    max = matrix[row, i];
                }
            }
            return max;
        }
        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] < 0)
                    {
                        count++;
                    }
                }
                array[i] = count;
            }
            return array;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int max = -1000000000, count = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i,j] > max && matrix[i,j] < 0)
                    {
                        max = matrix[i, j];
                        count++;
                    }
                }
                if (count > 0)
                {
                    array[j] = max;
                }
                else array[j] = 0;
            }
            return array;
        }
        public int[,] DefineSeq(int[,] matrix)
        {
            int[,] result = new int[1, 1];
            int f1 = 0, f0 = 0, fMinus1 = 0;
            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] <= matrix[1, i])
                {
                    f1 = 1;
                }
                else if ((matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] >= matrix[1, i]))
                {
                    fMinus1 = 1;
                }
                else 
                { 
                    f0 = 1;
                }
            }
            int q = matrix[0,0], w = 0;
            for (int i = 0; i < matrix.GetLength(1); i++) // проверка на одинаковые значения
            {
                    if (matrix[0,i] != q)
                    {
                        w = 1;
                    }
            }
            if (w == 1)
            {
                if (f1 == 1 && fMinus1 == 0 && f0 == 0)
                {
                    result[0, 0] = 1;
                }
                else if (f1 == 0 && fMinus1 == 1 && f0 == 0)
                {
                    result[0, 0] = -1;
                }
                else result[0, 0] = 0;
                return result;
            }
            else
            {
                int[,] a = new int[0, 0];// возвращает пустой массив
                return a;
            }
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            int count = 0, f1 = 0, fMinus1 = 0;
            for (int i = 1; i < matrix.GetLength(1); i++) // находим кол-во интервалов
            {
                if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] < matrix[1, i] && fMinus1 == 0 && f1 == 0)
                {
                    count++;
                    f1 = 1;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] > matrix[1, i] && fMinus1 == 0 && f1 == 0)
                {
                    count++;
                    fMinus1 = 1;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] > matrix[1, i] && f1 == 1)
                {
                    count++;
                    fMinus1 = 1;
                    f1 = 0;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] < matrix[1, i] && fMinus1 == 1)
                {
                    count++;
                    fMinus1 = 0;
                    f1 = 1;
                }
            }
            f1 = 0;
            fMinus1 = 0;
            int[,] result = new int[count, 2];
            int t = 0, k = 0;
            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] <= matrix[1, i] && fMinus1 == 0 && f1 == 0) //возр.
                {
                    result[t, 0] = matrix[0, k];
                    f1 = 1;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] >= matrix[1, i] && fMinus1 == 0 && f1 == 0) //убыв.
                {
                    result[t, 0] = matrix[0, k];
                    fMinus1 = 1;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] > matrix[1, i] && f1 == 1)//убыв.
                {
                    result[t, 1] = matrix[0, k];
                    t++;
                    result[t, 0] = matrix[0, k];
                    fMinus1 = 1;
                    f1 = 0;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] < matrix[1, i] && fMinus1 == 1)//возр.
                {
                    result[t, 1] = matrix[0, k];
                    t++;
                    result[t, 0] = matrix[0, k];
                    fMinus1 = 0;
                    f1 = 1;
                }
                k++;
            }
            if (count > 0)
            {
                result[count - 1, 1] = matrix[0, matrix.GetLength(1) - 1];
            }
            int k1 = 1, n = result.GetLength(0);
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
            if (count == 0)
            {
                int[,] a = new int[0, 0];
                return a;
            }
            else return result;

        }
        public int[,] FindLongestSeq(int[,] matrix)
        {
            int count = 0, f1 = 0, fMinus1 = 0;
            for (int i = 1; i < matrix.GetLength(1); i++) // находим кол-во интервалов
            {
                if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] < matrix[1, i] && fMinus1 == 0 && f1 == 0)
                {
                    count++;
                    f1 = 1;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] > matrix[1, i] && fMinus1 == 0 && f1 == 0)
                {
                    count++;
                    fMinus1 = 1;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] > matrix[1, i] && f1 == 1)
                {
                    count++;
                    fMinus1 = 1;
                    f1 = 0;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] < matrix[1, i] && fMinus1 == 1)
                {
                    count++;
                    fMinus1 = 0;
                    f1 = 1;
                }
            }
            f1 = 0;
            fMinus1 = 0;
            int[,] result = new int[count, 2];
            int t = 0, k = 0;
            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] <= matrix[1, i] && fMinus1 == 0 && f1 == 0) //возр.
                {
                    result[t, 0] = matrix[0, k];
                    f1 = 1;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] >= matrix[1, i] && fMinus1 == 0 && f1 == 0) //убыв.
                {
                    result[t, 0] = matrix[0, k];
                    fMinus1 = 1;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] > matrix[1, i] && f1 == 1)//убыв.
                {
                    result[t, 1] = matrix[0, k];
                    t++;
                    result[t, 0] = matrix[0, k];
                    fMinus1 = 1;
                    f1 = 0;
                }
                else if (matrix[0, i - 1] < matrix[0, i] && matrix[1, i - 1] < matrix[1, i] && fMinus1 == 1)//возр.
                {
                    result[t, 1] = matrix[0, k];
                    t++;
                    result[t, 0] = matrix[0, k];
                    fMinus1 = 0;
                    f1 = 1;
                }
                k++;
            }
            if (count > 0)
            {
                result[count - 1, 1] = matrix[0, matrix.GetLength(1) - 1];
            } // result - заполненная таблица координат интервалов
            int max = 0, maxPosition = 0;
            for (int i = 0; i < result.GetLength(0); i++)
            {
                if ((result[i,1] - result[i,0]) > max)
                {
                    max = result[i, 1] - result[i, 0];
                    maxPosition = i;
                }
            }
            if (count == 0)
            {
                int[,] a = new int[0, 0];
                return a;
            }
            else
            {
                int[,] a = new int[1, 2];
                a[0, 0] = result[maxPosition, 0];
                a[0, 1] = result[maxPosition, 1];
                return a;
            }
        }
        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            int count = 0, f1 = 0, fMinus1 = 0;
            for (double x = a; x < b; x += h)
            {
                double y = func(x);
                if (y > 0 && f1 == 0 && fMinus1 == 0)
                {
                    f1 = 1;
                }
                else if (y < 0 && f1 == 0 && fMinus1 == 0)
                {
                    fMinus1 = 1;
                }
                else if (y > 0 && fMinus1 == 1)
                {
                    count++;
                    f1 = 1;
                    fMinus1 = 0;
                }
                else if (y < 0 && f1 == 1)
                {
                    count++;
                    f1 = 0;
                    fMinus1 = 1;
                }
            }
            return count;
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
        public void SortInCheckersOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                    if (i % 2 == 0)
                    {
                        int k = 1, n = array[i].Length;
                        while (k < n)
                        {
                            if ( k == 0 || array[i][k-1] <= array[i][k])
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
                        int k = 1, n = array[i].Length;
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
            int k = 1, n = array.Length;
            while (k < n)
            {
                int sum1 = 0, sum2 = 0;
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
        public delegate void Sorting(int[] array);
        public delegate void SortRowsByMax(int[,] array);
        public delegate int[] FindNegatives(int[,] matrix);
        public delegate int[,] MathInfo(int[,] matrix);
        public delegate double Func(double a);
        public delegate int[][] Action(int[][] array);
    }
}
