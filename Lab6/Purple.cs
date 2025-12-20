using System;
using System.Buffers;
using System.Numerics;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public void Task1(int[,] A, int[,] B)
        {
            if (A == null || B == null)
                return;
            int x1 = A.GetLength(0);
            int y1 = A.GetLength(1);
            int x2 = B.GetLength(0);
            int y2 = B.GetLength(1);
            if (x1 != y1 || y2 != x2)
                return;
            if (x1 != x2)
                return;
            int ind_A = FindDiagonalMaxIndex(A);
            int ind_B = FindDiagonalMaxIndex(B);
            SwapRowColumn(A, ind_A, B, ind_B);
            return;



        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int a = matrix.GetLength(0);
            int ind = 0;
            int num = 0;
            for (int i = 0; i < a; i++)
            {
                if (matrix[i, i] > num)
                {
                    num = matrix[i, i];
                    ind = i;
                }
            }
            return ind;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                (matrix[rowIndex, i], B[i, columnIndex]) = (B[i, columnIndex], matrix[rowIndex, i]);
            }
            return;
        }

        public void Task2(ref int[,] A, int[,] B)
        {
            if (A == null || B == null)
                return;
            int x1 = A.GetLength(0);
            int y1 = A.GetLength(1);
            int x2 = B.GetLength(0);
            int y2 = B.GetLength(1);
            if (x2 != y1)
                return;
            int ind_row = 0, k = 0;
            for (int i = 0; i < x1; i++)
            {
                int res = CountPositiveElementsInRow(A, i);
                if (res > k)
                {
                    k = res;
                    ind_row = i;
                }

            }
            int k_2 = 0, ind_col = 0;
            for (int j = 0; j < y2; j++)
            {
                int res_2 = CountPositiveElementsInColumn(B, j);
                if (res_2 > k_2)
                {
                    k_2 = res_2;
                    ind_col = j;
                }
            }
            if (k_2 == 0)
            {
                return;
            }

            InsertColumn(ref A, ind_row, ind_col, B);
        }

        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            if (A == null || B == null)
                return;

            int x1 = A.GetLength(0);
            int y1 = A.GetLength(1);
            int x2 = B.GetLength(0);
            int y2 = B.GetLength(1);
            if (x2 != y1)
                return;
            if (rowIndex < 0 || rowIndex >= x1)
                return;
            if (columnIndex < 0 || columnIndex >= y2)
                return;

            int[,] new_A = new int[x1 + 1, y1];

            for (int i = 0; i < x1 + 1; i++)
            {
                for (int j = 0; j < y1; j++)
                {
                    if (i <= rowIndex)
                    {
                        new_A[i, j] = A[i, j];
                    }
                    if (i == rowIndex + 1)
                    {
                        new_A[i, j] = B[j, columnIndex];
                    }
                    if (i > rowIndex + 1)
                    {
                        new_A[i, j] = A[i - 1, j];
                    }
                }
            }

            A = new_A;
        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            if (matrix == null)
                return 0;
            int y = matrix.GetLength(1);
            int k = 0;
            for (int j = 0; j < y; j++)
            {
                if (matrix[row, j] > 0)
                    k++;
            }
            return k;
        }

        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            if (matrix == null)
                return 0;
            int x = matrix.GetLength(0);
            int k = 0;
            for (int j = 0; j < x; j++)
            {
                if (matrix[j, col] > 0)
                    k++;
            }
            return k;
        }
        public void Task3(int[,] matrix)
        {

            if (matrix == null)
                return;
            ChangeMatrixValues(matrix);

        }
        public void ChangeMatrixValues(int[,] matrix)
        {
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);
            if (x * y < 5)
            {
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        matrix[i, j] *= 2;
                    }
                }
                return;
            }
            int[] values = new int[x * y];
            int[] rows = new int[x * y];
            int[] cols = new int[x * y];
            int ind = 0;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    values[ind] = matrix[i, j];
                    rows[ind] = i;
                    cols[ind] = j;
                    ind++;
                }
            }

    
            int[] array_ind = new int[x * y];
            for (int i = 0; i < array_ind.Length; i++) 
                array_ind[i] = i;

            for (int i = 0; i < array_ind.Length - 1; i++)
            {
                for (int j = i + 1; j < array_ind.Length; j++)
                {
                    if (values[array_ind[i]] < values[array_ind[j]] ||
                        (values[array_ind[i]] == values[array_ind[j]] &&
                         (rows[array_ind[i]] > rows[array_ind[j]] ||
                          (rows[array_ind[i]] == rows[array_ind[j]] && cols[array_ind[i]] > cols[array_ind[j]]))))
                    {
                        
                        (array_ind[i], array_ind[j]) = (array_ind[j], array_ind[i]) ;
                        
                    }
                }
            }

            bool[,] flag = new bool[x, y];
            for (int k = 0; k < 5; k++)
            {
                int idx = array_ind[k];
                flag[rows[idx], cols[idx]] = true;
            }

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (flag[i, j])
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
        public void Task4(int[,] A, int[,] B)
        {

            if (A == null || B == null)
                return;
            var array_A = CountNegativesPerRow(A);
            var array_B = CountNegativesPerRow(B);
            bool flag = true;
            for (int i = 0; i < array_A.Length; i++)
            {
                if (array_A[i] > 0)
                    flag = false;
            }
            if (flag)
                return;
            flag = true;
            for (int i = 0; i < array_B.Length; i++)
            {
                if (array_B[i] > 0)
                    flag = false;
            }
            if (flag)
                return;
            int ind_A = FindMaxIndex(array_A);
            int ind_B = FindMaxIndex(array_B);
            int y1 = A.GetLength(1);
            int y2 = B.GetLength(1);
            if (y1 != y2)
                return;

            int[] temp = new int[y1];

            for (int j = 0; j < y1; j++)
            {
                temp[j] = A[ind_A, j];
            }

            for (int j = 0; j < y1; j++)
            {
                A[ind_A, j] = B[ind_B, j];
            }
            for (int j = 0; j < y1; j++)
            {
                B[ind_B, j] = temp[j];
            }
        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);
            int[] m2 = new int[x];
            for (int i = 0; i < x; i++)
            {
                int k = 0;
                for (int j = 0; j < y; j++)
                {
                    if (matrix[i, j] < 0)
                        k++;
                }
                m2[i] = k;
            }
            return m2;
        }
        public int FindMaxIndex(int[] array)
        {
            int n = array.Length;
            int ind = 0, maxim = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] > maxim)
                {
                    maxim = array[i];
                    ind = i;
                }
            }
            return ind;
        }
        public void Task5(int[] matrix, Sorting sort)
        {
            if (matrix == null || sort == null)
                return;
            sort(matrix);
        }
        public delegate void Sorting(int[] array);
        public void SortNegativeAscending(int[] matrix)
        {
            int cnt = 0, n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i] < 0) cnt++;
            }
            int[] temp = new int[cnt];
            int ind = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i] < 0) temp[ind++] = matrix[i];
            }
            Array.Sort(temp);
            ind = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i] < 0) matrix[i] = temp[ind++];
            }

        }
        public void SortNegativeDescending(int[] matrix)
        {
            int cnt = 0, n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i] < 0) cnt++;
            }
            int[] temp = new int[cnt];
            int ind = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i] < 0) temp[ind++] = matrix[i];
            }
            Array.Sort(temp);
            Array.Reverse(temp);
            ind = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i] < 0) matrix[i] = temp[ind++];
            }
        }

        public void Task6(int[,] matrix, SortRowsByMax sort)
        {
            if (matrix == null || sort == null)
                return;
            sort(matrix);
        }
        public delegate void SortRowsByMax(int[,] matrix);
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);
            for (int k = 0; k < x - 1; k++)
            {
                for (int i = 0; i < x - k - 1; i++)
                {
                    if (GetRowMax(matrix, i) > GetRowMax(matrix, i + 1))
                    {
                        for (int j = 0; j < y; j++)
                        {
                            (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                        }
                    }
                }
            }
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);
            for (int k = 0; k < x - 1; k++)
            {
                for (int i = 0; i < x - k - 1; i++)
                {
                    if (GetRowMax(matrix, i) < GetRowMax(matrix, i + 1))
                    {
                        for (int j = 0; j < y; j++)
                        {
                            (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                        }
                    }
                }
            }
        }
        public int GetRowMax(int[,] matrix, int row)
        {
            int y = matrix.GetLength(1);
            int maxim = int.MinValue;
            for (int j = 0; j < y; j++)
            {
                if (matrix[row, j] > maxim)
                {
                    maxim = matrix[row, j];
                }
            }
            return maxim;
        }
        public int[] Task7(int[,] matrix, FindNegatives find)
        {

            // code here
            if (matrix == null || find == null)
                return null;

            int[] negatives = find(matrix);
            return negatives;
        }
        public delegate int[] FindNegatives(int[,] matrix);
        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);
            int[] negative = new int[x];
            for (int i = 0; i < x; i++)
            {
                int cnt = 0;
                for (int j = 0; j < y; j++)
                {
                    if (matrix[i, j] < 0)
                        cnt++;
                }
                negative[i] = cnt;
            }
            return negative;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);
            int[] negative = new int[y];
            for (int j = 0; j < y; j++)
            {
                bool flag = false;
                int maxim = int.MinValue;
                for (int i = 0; i < x; i++)
                {
                    if (matrix[i, j] < 0 && matrix[i, j] > maxim)
                    {
                        flag = true;
                        maxim = matrix[i, j];
                    }
                }
                if (!flag)
                    maxim = 0;
                negative[j] = maxim;
            }
            return negative;
        }
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;
            if (matrix == null || info == null)
                return null;
            if (matrix.GetLength(0) != 2)
                return null;
            bool flag = true;
            int xOne = matrix[0, 0];
            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                if (matrix[0, i] != xOne)
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                return new int[0, 0];
            }
            matrix = SortedMatrix(matrix);
            answer = info(matrix);

            return answer;
        }
        public delegate int[,] MathInfo(int[,] matrix);

        public int[,] SortedMatrix(int[,] matrix)
        {
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);

            int[] xCoords = new int[y];
            int[] ind = new int[y];
            for (int i = 0; i < y; i++)
            {
                xCoords[i] = matrix[0, i];
                ind[i] = i;
            }

            Array.Sort(xCoords, ind);

            int[,] sortedMatrix = new int[x, y];


            for (int i = 0; i < y; i++)
            {
                int a = ind[i];
                sortedMatrix[0, i] = matrix[0, a];
                sortedMatrix[1, i] = matrix[1, a];
            }

            return sortedMatrix;
        }
        public int[,] DefineSeq(int[,] matrix)
        {
            int[,] answer = new int[1, 1];
            matrix = SortedMatrix(matrix);
            int y = matrix.GetLength(1);
            bool flag_positive = true, flag_negative = true;

            for (int j = 0; j < y - 1; j++)
            {
                if (matrix[1, j] < matrix[1, j + 1])
                {
                    flag_negative = false;
                }
                if (matrix[1, j] > matrix[1, j + 1])
                {
                    flag_positive = false;
                }
            }
            if (flag_positive && !flag_negative)
                answer[0, 0] = 1;
            else if (!flag_positive && flag_negative)
                answer[0, 0] = -1;
            else answer[0, 0] = 0;
            return answer;
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            int x = 2;
            int y = matrix.GetLength(1);
            if (y < 2) return new int[0, 2];
            int[] start = new int[y - 1];
            int[] end = new int[y - 1];
            int cnt = 0, ind = 0;
            while (ind < y - 1)
            {
                int point = ind;
                bool monot = matrix[1, ind] <= matrix[1, ind + 1];
                bool flag = true;
                while (flag && point < y - 1)
                {
                    if (monot)
                    {
                        if (matrix[1, point] <= matrix[1, point + 1])
                            point++;
                        else
                        {
                            flag = false;
                            break;
                        }


                    }
                    else
                    {
                        if (matrix[1, point] >= matrix[1, point + 1])
                            point++;
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                if (point > ind)
                {
                    start[cnt] = matrix[0, ind];
                    end[cnt] = matrix[0, point];
                    cnt++;
                    ind = point;
                }
                else ind++;

            }
            for (int i = 0; i < cnt - 1; i++)
            {
                for (int j = i + 1; j < cnt; j++)
                {
                    if (start[i] > start[j] || (start[i] == start[j] && end[i] > end[j]))
                    {
                        (start[i], start[j]) = (start[j], start[i]);
                        (end[i], end[j]) = (end[j], end[i]);


                    }
                }
            }
            int[,] answer = new int[cnt, 2];
            for (int i = 0; i < cnt; i++)
            {
                answer[i, 0] = start[i];
                answer[i, 1] = end[i];
            }
            return answer;
        }
        public int[,] FindLongestSeq(int[,] matrix)
        {
            int[,] answer = new int[1, 2];
            int[,] all = FindAllSeq(matrix);
            int cnt = all.GetLength(0);
            int maxik = 0;
            if (cnt == 0)
            {
                answer[0, 0] = matrix[0, 0];
                answer[0, 1] = matrix[0, 0];
                return answer;
            }

            for (int i = 0; i < cnt; i++)
            {
                if ((all[i, 1] - all[i, 0]) > maxik)
                {
                    maxik = (all[i, 1] - all[i, 0]);
                    answer[0, 0] = all[i, 0];
                    answer[0, 1] = all[i, 1];
                }
            }
            return answer;
        }
        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            if (h <= 0 || a > b || func == null)
                return 0;

            answer = CountSignFlips(a, b, h, func);

            return answer;
        }
        public delegate double Func(double x);
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
            int cnt = 0;
            double x = a;
            double now = func(x);

            while (Math.Abs(now) < 0.0001 && x < b)
            {
                x += h;
                now = func(x);
            }
            x += h;
            while (x <= b + h / 2)
            {
                double curr =  func(x);
                if (Math.Abs(curr) < 0.0001) curr = 0;
                if (now != 0 && curr != 0 && ((now < 0 && curr > 0) || (now > 0 && curr < 0)))
                {
                    cnt++;
                }
                if (curr != 0)
                    now = curr;
                x += h;
            }

            return cnt;
        }
        public void Task10(int[][] array, Action<int[][]> func)
        {
            if (array == null || func == null)
                return;
            func(array);

            return;

        }
        public delegate void Action(int[][] array);
        public void SortInCheckersOrder(int[][] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                int y = array[i].Length;
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
            int n = array.Length;
            int[] sums = new int[n];
            for (int i = 0; i < n; i++)
            {
                int k = array[i].Length;
                for (int j = 0; j < k; j++)
                {
                    sums[i] += array[i][j];
                }
            }
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (sums[j] < sums[j + 1])
                    {
                        (sums[j], sums[j + 1]) = (sums[j + 1], sums[j]);
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);

                    }
                }
            }

        }
        public void TotalReverse(int[][] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                Array.Reverse(array[i]);
            }
            for (int i = 0; i < n / 2; i++)
            {
                (array[i], array[n - 1 - i]) = (array[n - i - 1], array[i]);
            }
        }

    }
}
