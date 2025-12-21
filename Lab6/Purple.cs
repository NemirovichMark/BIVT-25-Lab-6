using System;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public const int INF = (int)1e9 + 7;

        public const double E = 1e-10;

        public delegate void Sorting(int[] matrix);

        public delegate void SortRowsByMax(int[,] matrix);

        public delegate int[] FindNegatives(int[,] matrix);

        public delegate int[,] MathInfo(int[,] matrix);
        public void Task1(int[,] A, int[,] B)
        {

            if (A.GetLength(0) != A.GetLength(1) ||
                B.GetLength(0) != B.GetLength(1) ||
                A.GetLength(0) != B.GetLength(0))
            {
                return;
            }
            int i_A = FindDiagonalMaxIndex(A);
            int j_B = FindDiagonalMaxIndex(B);
            SwapRowColumn(A, i_A, B, j_B);

        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int i_max = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > matrix[i_max, i_max])
                {
                    i_max = i;
                }
            }
            return i_max;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex,
            int[,] B, int columnIndex)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                (matrix[rowIndex, i], B[i, columnIndex]) =
                   (B[i, columnIndex], matrix[rowIndex, i]);
            }
        }
        public void Task2(ref int[,] A, int[,] B)
        {

            if (A.GetLength(1) != B.GetLength(0))
            {
                return;
            }

            int a_i = 0, a_cnt = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                int cnt = CountPositiveElementsInRow(A, i);
                if (cnt > a_cnt)
                {
                    a_cnt = cnt;
                    a_i = i;
                }
            }

            int b_j = 0, b_cnt = 0;
            for (int j = 0; j < B.GetLength(1); j++)
            {
                int cnt = CountPositiveElementsInColumn(B, j);
                if (cnt > b_cnt)
                {
                    b_cnt = cnt;
                    b_j = j;
                }
            }

            if (b_cnt > 0)
            {
                InsertColumn(ref A, a_i, b_j, B);
            }

        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int ans = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > 0)
                {
                    ans++;
                }
            }
            return ans;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int ans = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > 0)
                {
                    ans++;
                }
            }
            return ans;
        }
        public void InsertColumn(ref int[,] A, int rowIndex,
            int columnIndex, int[,] B)
        {
            var Ans = new int[A.GetLength(0) + 1, A.GetLength(1)];
            for (int i = 0; i <= rowIndex; i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    Ans[i, j] = A[i, j];
                }
            }
            for (int j = 0; j < A.GetLength(1); j++)
            {
                Ans[rowIndex + 1, j] = B[j, columnIndex];
            }
            for (int i = rowIndex + 1; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    Ans[i + 1, j] = A[i, j];
                }
            }
            A = Ans;
        }
        public void Task3(int[,] matrix)
        {

            ChangeMatrixValues(matrix);

        }
        public void ChangeMatrixValues(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            var used = new bool[n, m];
            for (int iter = 0; iter < Math.Min(5, matrix.Length); iter++)
            {
                int i_max = -1, j_max = -1, max_val = -INF;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (!used[i, j] && max_val < matrix[i, j])
                        {
                            max_val = matrix[i, j];
                            i_max = i;
                            j_max = j;
                        }
                    }
                }
                if (i_max != -1)
                {
                    used[i_max, j_max] = true;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (used[i, j])
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

            if (A.GetLength(1) != B.GetLength(1))
            {
                return;
            }
            var cnt_neg_A = CountNegativesPerRow(A);
            int ind_A = FindMaxIndex(cnt_neg_A);
            var cnt_neg_B = CountNegativesPerRow(B);
            int ind_B = FindMaxIndex(cnt_neg_B);
            if (cnt_neg_A[ind_A] > 0 && cnt_neg_B[ind_B] > 0)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    (A[ind_A, j], B[ind_B, j]) = (B[ind_B, j], A[ind_A, j]);
                }
            }

        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            var ans = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        ans[i]++;
                    }
                }
            }
            return ans;
        }
        public int FindMaxIndex(int[] array)
        {
            int i_a = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > array[i_a])
                {
                    i_a = i;
                }
            }
            return i_a;
        }
        public void Task5(int[] matrix, Sorting sort)
        {

            sort(matrix);

        }
        public void SortNegativeAscending(int[] matrix)
        {
            int cnt_neg = 0;
            foreach (int x in matrix)
            {
                if (x < 0)
                {
                    cnt_neg++;
                }
            }

            var neg = new int[cnt_neg];
            int neg_i = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    neg[neg_i++] = matrix[i];
                }
            }

            for (int i = 0; i < cnt_neg - 1; i++)
            {
                for (int j = 0; j < cnt_neg - 1 - i; j++)
                {
                    if (neg[j] > neg[j + 1])
                    {
                        (neg[j], neg[j + 1]) = (neg[j + 1], neg[j]);
                    }
                }
            }

            neg_i = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = neg[neg_i++];
                }
            }
        }
        public void SortNegativeDescending(int[] matrix)
        {
            int cnt_neg = 0;
            foreach (int x in matrix)
            {
                if (x < 0)
                {
                    cnt_neg++;
                }
            }

            var neg = new int[cnt_neg];
            int neg_i = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    neg[neg_i++] = matrix[i];
                }
            }

            for (int i = 0; i < cnt_neg - 1; i++)
            {
                for (int j = 0; j < cnt_neg - 1 - i; j++)
                {
                    if (neg[j] < neg[j + 1])
                    {
                        (neg[j], neg[j + 1]) = (neg[j + 1], neg[j]);
                    }
                }
            }

            neg_i = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = neg[neg_i++];
                }
            }
        }
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            sort(matrix);

        }
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            var dir = new (int, int)[n];
            for (int i = 0; i < n; i++)
            {
                dir[i] = (GetRowMax(matrix, i), i);
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (dir[j].Item1 > dir[j + 1].Item1)
                    {
                        (dir[j], dir[j + 1]) = (dir[j + 1], dir[j]);
                    }
                }
            }

            var Ans = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Ans[i, j] = matrix[dir[i].Item2, j];
                }
            }
            Array.Copy(Ans, matrix, n * m);
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            var dir = new (int, int)[n];
            for (int i = 0; i < n; i++)
            {
                dir[i] = (GetRowMax(matrix, i), i);
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (dir[j].Item1 < dir[j + 1].Item1)
                    {
                        (dir[j], dir[j + 1]) = (dir[j + 1], dir[j]);
                    }
                }
            }

            var Ans = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Ans[i, j] = matrix[dir[i].Item2, j];
                }
            }
            Array.Copy(Ans, matrix, n * m);
        }
        public int GetRowMax(int[,] matrix, int row)
        {
            int j_max = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > matrix[row, j_max])
                {
                    j_max = j;
                }
            }
            return matrix[row, j_max];
        }
        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            negatives = find(matrix);

            return negatives;
        }
        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            var ans = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        ans[i]++;
                    }
                }
            }
            return ans;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            var ans = new int[m];
            for (int j = 0; j < m; j++)
            {
                int max_neg = -INF;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] < 0 && max_neg < matrix[i, j])
                    {
                        max_neg = matrix[i, j];
                    }
                }
                if (max_neg != -INF)
                {
                    ans[j] = max_neg;
                }
            }
            return ans;
        }
        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            answer = info(matrix);

            return answer;
        }
        public int[,] DefineSeq(int[,] matrix)
        {
            bool all_eq = true;
            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
                if (matrix[1, i] != matrix[1, i + 1])
                {
                    all_eq = false;
                    break;
                }
            }
            if (all_eq)
            {
                return new int[0, 0] { };
            }

            bool incr = true;
            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
                if (!(matrix[1, i] <= matrix[1, i + 1]))
                {
                    incr = false;
                    break;
                }
            }
            if (incr)
            {
                return new int[1, 1] { { 1 } };
            }

            bool decr = true;
            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
                if (!(matrix[1, i] >= matrix[1, i + 1]))
                {
                    decr = false;
                    break;
                }
            }
            if (decr)
            {
                return new int[1, 1] { { -1 } };
            }
            else
            {
                return new int[1, 1] { { 0 } };
            }
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            int n = matrix.GetLength(1);

            int ans_len = 0;
            int l = 0;
            bool inc = true;
            for (int r = 0; r < n; r++)
            {
                if (inc)
                {
                    if (r == n - 1 || matrix[1, r] > matrix[1, r + 1])
                    {
                        inc = false;
                        if (l < r)
                        {
                            ans_len++;
                        }
                        l = r;
                    }
                }
                else
                {
                    if (r == n - 1 || matrix[1, r] < matrix[1, r + 1])
                    {
                        inc = true;
                        if (l < r)
                        {
                            ans_len++;
                        }
                        l = r;
                    }
                }
            }
            if (ans_len == 0)
            {
                return new int[0, 0] { };
            }

            int[,] ans = new int[ans_len, 2];
            int ans_i = 0;
            l = 0;
            inc = true;
            for (int r = 0; r < n; r++)
            {
                if (inc)
                {
                    if (r == n - 1 || matrix[1, r] > matrix[1, r + 1])
                    {
                        inc = false;
                        if (l < r)
                        {
                            ans[ans_i, 0] = matrix[0, l];
                            ans[ans_i, 1] = matrix[0, r];
                            ans_i++;
                        }
                        l = r;
                    }
                }
                else
                {
                    if (r == n - 1 || matrix[1, r] < matrix[1, r + 1])
                    {
                        inc = true;
                        if (l < r)
                        {
                            ans[ans_i, 0] = matrix[0, l];
                            ans[ans_i, 1] = matrix[0, r];
                            ans_i++;
                        }
                        l = r;
                    }
                }
            }
            return ans;
        }
        public int[,] FindLongestSeq(int[,] matrix)
        {
            var tmp = FindAllSeq(matrix);
            if (tmp.GetLength(0) == 0)
            {
                return tmp;
            }
            int ans_l = 0, ans_r = 0;
            for (int i = 0; i < tmp.GetLength(0); i++)
            {
                if (tmp[i, 1] - tmp[i, 0] > ans_r - ans_l)
                {
                    ans_l = tmp[i, 0];
                    ans_r = tmp[i, 1];
                }
            }
            return new int[,] { { ans_l, ans_r } };
        }
        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            answer = CountSignFlips(a, b, h, func);

            return answer;
        }
        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            if (b < a || h <= 0)
            {
                return 0;
            }

            int len = 0;
            for (double x = a; x <= b + E; x += h)
            {
                if (Math.Abs(func(x)) > E)
                {
                    len++;
                }
            }

            var vals = new double[len];
            int ind = 0;
            for (double x = a; x <= b + E; x += h)
            {
                double val0 = func(x);
                if (Math.Abs(val0) > E)
                {
                    vals[ind++] = val0;
                }
            }

            int flips = 0;
            for (int i = 0; i < vals.Length - 1; i++)
            {
                if (vals[i] * vals[i + 1] < 0)
                {
                    flips++;
                }
            }           

            return flips;
        }

        public double FuncA(double x)
        {
            return x * x - Math.Sin(x);
        }

        public double FuncB(double x)
        {
            return Math.Exp(x) - 1;
        }
        public void Task10(int[][] array, Action<int[][]> func)
        {

            func(array);

        }

        public void SortInCheckersOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    continue;
                }
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
            var sums = new int[array.Length];
            var indices = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                indices[i] = i;
                if (array[i] != null)
                {
                    foreach (var val in array[i])
                    {
                        sums[i] += val;
                    }
                }
            }

            Array.Sort(indices, (a, b) => sums[b].CompareTo(sums[a]));

            var temp = new int[array.Length][];
            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[indices[i]];
            }

            Array.Copy(temp, array, array.Length);
        }
        public void TotalReverse(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    Array.Reverse(array[i]);
                }
            }
            Array.Reverse(array);
        }
    }
}
