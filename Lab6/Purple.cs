using System;
using System.Net.Mime;
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
            int rowA = A.GetLength(0), columnA = A.GetLength(1);
            int rowB = B.GetLength(0), columnB = B.GetLength(1);
            if (rowA == columnA && rowB == columnB && rowA == rowB)
            {
                int rowMax = FindDiagonalMaxIndex(A);
                int columnMax = FindDiagonalMaxIndex(B);
                SwapRowColumn(A,rowMax,B,columnMax);
            }
            // end

        }

        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int imax = 0;
            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                if (matrix[i, i] > matrix[imax, imax])
                {
                    imax = i;
                }
            }

            return imax;
        }

        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int tmp = matrix[rowIndex, j];
                matrix[rowIndex, j] = B[j, columnIndex];
                B[j, columnIndex] = tmp;
            }
        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            int countMax1 = int.MinValue,imax=-1;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                int count = CountPositiveElementsInRow(A,i);
                if (count > countMax1)
                {
                    imax = i;
                    countMax1 = count;
                }
            }

            int countMax2 = int.MinValue, jmax = -1;
            for (int j = 0; j < B.GetLength(1); j++)
            {
                int count = CountPositiveElementsInColumn(B, j);
                if (count > countMax2)
                {
                    jmax = j;
                    countMax2 = count;
                }
            }

            if (imax != -1 && jmax != -1 && B.GetLength(0) == A.GetLength(1))
            {
                InsertColumn(ref A,imax,jmax,B);
            }
            // end

        }

        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int[,] tmp = new int[A.GetLength(0) + 1, A.GetLength(1)];
            for (int i = 0; i < tmp.GetLength(0); i++)
            {
                for (int j = 0; j < tmp.GetLength(1); j++)
                {
                    if (i <= rowIndex)
                    {
                        tmp[i, j] = A[i, j];
                    }
                    else if (i == rowIndex + 1)
                    {
                        tmp[i, j] = B[j, columnIndex];
                    }
                    else
                    {
                        tmp[i, j] = A[i - 1, j];
                    }
                }
            }

            A = new int[A.GetLength(0) + 1, A.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i, j] = tmp[i, j];
                }
            }
        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int count = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > 0)
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
        public void Task3(int[,] matrix)
        {

            // code here
            ChangeMatrixValues(matrix);
            // end

        }

        public void ChangeMatrixValues(int[,] matrix)
        {
            if (matrix.Length > 5)
            {
                int[] max_elem = new int[matrix.Length];
                int[] array = new int[matrix.Length];
                int i1 = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        max_elem[i1] = matrix[i, j];
                        array[i1] = matrix[i, j];
                        i1++;
                    }
                }

                i1 = 0;
                while (i1 < max_elem.Length)
                {
                    if (i1 == 0 || max_elem[i1] <= max_elem[i1 - 1])
                    {
                        i1++;
                    }
                    else
                    {
                        int tmp = max_elem[i1];
                        max_elem[i1] = max_elem[i1 - 1];
                        max_elem[i1 - 1] = tmp;
                        i1--;
                    }
                }
                
                bool[] check = new bool[5];
                for (int i = 0; i < array.Length; i++)
                {
                    bool tmp = false;
                    for (int j = 0; j < 5; j++)
                    {
                        if (array[i] == max_elem[j] && check[j]==false)
                        {
                            array[i] *= 2;
                            check[j] = true;
                            tmp = true;
                            break;
                        }
                    }

                    if (!tmp)
                    {
                        array[i] /= 2;
                    }
                }

                i1 = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = array[i1];
                        i1++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] *= 2;
                    }
                }
            }
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            int[] countA = CountNegativesPerRow(A);
            int[] countB = CountNegativesPerRow(B);
            int imaxA = FindMaxIndex(countA);
            int imaxB = FindMaxIndex(countB);
            if (imaxA != -1 && imaxB != -1 && A.GetLength(1) == B.GetLength(1))
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    int tmp = A[imaxA, j];
                    A[imaxA, j] = B[imaxB, j];
                    B[imaxB, j] = tmp;
                }
            }
            // end

        }

        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)];
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

                array[i] = count;
            }

            return array;
        }

        public int FindMaxIndex(int[] array)
        {
            bool check = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0)
                {
                    check = true;
                    break;
                }
            }

            if (!check) return -1;
            int imax = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[imax])
                {
                    imax = i;
                }
            }

            return imax;
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
            int count = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    count++;
                }
            }

            int[] array = new int[count];
            int i1 = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    array[i1] = matrix[i];
                    i1++;
                }
            }

            i1 = 0;
            while (i1 < array.Length)
            {
                if (i1 == 0 || array[i1] >= array[i1 - 1])
                {
                    i1++;
                }
                else
                {
                    int tmp = array[i1];
                    array[i1] = array[i1 - 1];
                    array[i1 - 1] = tmp;
                    i1--;
                }
            }

            i1 = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = array[i1];
                    i1++;
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
            int i1 = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    array[i1] = matrix[i];
                    i1++;
                }
            }

            i1 = 0;
            while (i1 < array.Length)
            {
                if (i1 == 0 || array[i1] <= array[i1 - 1])
                {
                    i1++;
                }
                else
                {
                    int tmp = array[i1];
                    array[i1] = array[i1 - 1];
                    array[i1 - 1] = tmp;
                    i1--;
                }
            }

            i1 = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = array[i1];
                    i1++;
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
            int[] max = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                max[i] = GetRowMax(matrix, i);
            }

            int i1 = 0;
            while (i1 < max.Length)
            {
                if (i1 == 0 || max[i1] >= max[i1 - 1])
                {
                    i1++;
                }
                else
                {
                    int tmp = max[i1];
                    max[i1] = max[i1 - 1];
                    max[i1 - 1] = tmp;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        int tmp1 = matrix[i1, j];
                        matrix[i1, j] = matrix[i1 - 1, j];
                        matrix[i1 - 1, j] = tmp1;
                    }

                    i1--;
                }
            }
        }

        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int[] max = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                max[i] = GetRowMax(matrix, i);
            }

            int i1 = 0;
            while (i1 < max.Length)
            {
                if (i1 == 0 || max[i1] <= max[i1 - 1])
                {
                    i1++;
                }
                else
                {
                    int tmp = max[i1];
                    max[i1] = max[i1 - 1];
                    max[i1 - 1] = tmp;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        int tmp1 = matrix[i1, j];
                        matrix[i1, j] = matrix[i1 - 1, j];
                        matrix[i1 - 1, j] = tmp1;
                    }

                    i1--;
                }
            }
        }
        public int GetRowMax(int[,] matrix, int row)
        {
            int jmax = 0, max_elem = matrix[row,0];
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > matrix[row, jmax])
                {
                    max_elem = matrix[row, j];
                    jmax = j;
                }
            }

            return max_elem;
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
            int[] array = new int[matrix.GetLength(0)];
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

                array[i] = count;
            }

            return array;
        }

        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int max_elem = int.MinValue;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0 && matrix[i, j] > max_elem)
                    {
                        max_elem = matrix[i, j];
                    }
                }

                if (max_elem == int.MinValue) max_elem = 0;
                array[j] = max_elem;
            }

            return array;
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
            if (matrix.GetLength(1) < 2) return new int[,] { };
            bool check = true;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < j; i++)
                {
                    if (matrix[1, i] > matrix[1, j])
                    {
                        check = false;
                        break;
                    }
                }
            }

            if (check) return new int[,] { { 1 } };
            check = true;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < j; i++)
                {
                    if (matrix[1, i] < matrix[1, j])
                    {
                        check = false;
                        break;
                    }
                }
            }

            if (check) return new int[,] { { -1 } };
            return new int[,] { { 0 } };
        }

        public int[,] FindAllSeq(int[,] matrix)
        {
            if (matrix.GetLength(1) < 2) return new int[,] { }; 
            if (DefineSeq(matrix)[0, 0] != 0)
            {
                int[,] ans = new int[1, 2];
                ans[0, 0] = matrix[0, 0];
                ans[0, 1] = matrix[0, matrix.GetLength(1) - 1];
                return ans;
            }

            int count = 0;
            for (int j = 1; j + 1 < matrix.GetLength(1); j++)
            {
                if ((matrix[1, j] > matrix[1, j + 1] && matrix[1, j] > matrix[1, j - 1]) ||
                    (matrix[1, j] < matrix[1, j + 1] && matrix[1, j] < matrix[1, j - 1]))
                {
                    count++;
                }
            }

            int[] ct = new int[count+2];
            int i1 = 1;
            for (int j = 1; j + 1 < matrix.GetLength(1); j++)
            {
                if ((matrix[1, j] > matrix[1, j + 1] && matrix[1, j] > matrix[1, j - 1]) ||
                    (matrix[1, j] < matrix[1, j + 1] && matrix[1, j] < matrix[1, j - 1]))
                {
                    ct[i1] = matrix[0,j];
                    i1++;
                }
            }

            ct[0] = matrix[0, 0];
            ct[ct.Length - 1] = matrix[0, matrix.GetLength(1) - 1];
            int[,] answer = new int[count + 1, 2];
            i1 = 0;
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    answer[i, j] = ct[i1];
                    i1++;
                }

                i1--;
            }
            
            return answer;
        }

        public int[,] FindLongestSeq(int[,] matrix)
        {
            if (matrix.GetLength(1) < 2) return new int[,] { };
            int[,] ans = new int[1, 2];
            int[,] array = FindAllSeq(matrix);
            int max = int.MinValue;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int diff = array[i, 1] - array[i, 0];
                if (diff > max)
                {
                    max = diff;
                    ans[0, 0] = array[i, 0];
                    ans[0, 1] = array[i, 1];
                }
            }

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
            int count = 0;
            for (double x = a; x + h <= b + 0.0001; x += h)
            {
                double y1 = func(x);
                double y2 = func(x + h);
                if (y1 * y2 < 0) count++;
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

        public void SortInCheckersOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0)
                {
                    int j = 0;
                    while (j < array[i].Length)
                    {
                        if (j == 0 || array[i][j] >= array[i][j - 1])
                        {
                            j++;
                        }
                        else
                        {
                            int tmp = array[i][j];
                            array[i][j] = array[i][j - 1];
                            array[i][j - 1] = tmp;
                            j--;
                        }
                    }
                }
                else
                {
                    int j = 0;
                    while (j < array[i].Length)
                    {
                        if (j == 0 || array[i][j] <= array[i][j - 1])
                        {
                            j++;
                        }
                        else
                        {
                            int tmp = array[i][j];
                            array[i][j] = array[i][j - 1];
                            array[i][j - 1] = tmp;
                            j--;
                        }
                    }
                }
            }
        }

        public void SortBySumDesc(int[][] array)
        {
            int[] sum = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int tong = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    tong += array[i][j];
                }

                sum[i] = tong;
            }

            int i1 = 0;
            while (i1 < sum.Length)
            {
                if (i1 == 0 || sum[i1] <= sum[i1 - 1])
                {
                    i1++;
                }
                else
                {
                    int tmp = sum[i1];
                    sum[i1] = sum[i1 - 1];
                    sum[i1 - 1] = tmp;
                    int[] tmp1 = new int[array[i1].Length];
                    for (int j = 0; j < array[i1].Length; j++)
                    {
                        tmp1[j] = array[i1][j];
                    }

                    int[] tmp2 = new int[array[i1 - 1].Length];
                    for (int j = 0; j < array[i1 - 1].Length; j++)
                    {
                        tmp2[j] = array[i1 - 1][j];
                    }

                    int n = array[i1].Length;
                    array[i1] = new int[array[i1 - 1].Length];
                    array[i1 - 1] = new int[n];
                    for (int j = 0; j < array[i1].Length; j++)
                    {
                        array[i1][j] = tmp2[j];
                    }

                    for (int j = 0; j < array[i1 - 1].Length; j++)
                    {
                        array[i1 - 1][j] = tmp1[j];
                    }

                    i1--;
                }
            }
        }

        public void TotalReverse(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int n = array[i].Length / 2 - 1;
                int j1 = array[i].Length - 1;
                for (int j = 0; j <= n; j++)
                {
                    int tmp = array[i][j];
                    array[i][j] = array[i][j1];
                    array[i][j1] = tmp;
                    j1--;
                }
            }

            int i1 = array.Length - 1;
            for (int i = 0; i <= array.Length / 2 - 1; i++)
            {
                int[] tmp1 = new int[array[i].Length];
                int[] tmp2 = new int[array[i1].Length];
                for (int j = 0; j < array[i].Length; j++)
                {
                    tmp1[j] = array[i][j];
                }

                for (int j = 0; j < array[i1].Length; j++)
                {
                    tmp2[j] = array[i1][j];
                }

                int n = array[i].Length;
                array[i] = new int[array[i1].Length];
                array[i1] = new int[n];
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = tmp2[j];
                }

                for (int j = 0; j < array[i1].Length; j++)
                {
                    array[i1][j] = tmp1[j];
                }

                i1--;
            }
        }
    }
}
