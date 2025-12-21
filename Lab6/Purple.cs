using System;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public void Task1(int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(0) == A.GetLength(1) && B.GetLength(0) == B.GetLength(1) && A.GetLength(0) == B.GetLength(0))
            {
                int index_A = FindDiagonalMaxIndex(A);
                int index_B = FindDiagonalMaxIndex(B);
                SwapRowColumn(A, index_A, B, index_B);
            }
            // end

        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int max_in = 0; int max_n = matrix[0, 0]; 
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i,i] > max_n)
                {
                    max_n = matrix[i, i]; max_in = i;
                }
            }
            return max_in;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            for (int i = 0;  i < matrix.GetLength(0); i++)
            {
                (matrix[rowIndex, i], B[i, columnIndex]) = (B[i, columnIndex], matrix[rowIndex, i]);
            }
        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(1) == B.GetLength(0))
            {
                int rowIndex = -1; int A_cnt = 0;
                int colIndex = -1; int B_cnt = 0;
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    int c = CountPositiveElementsInRow(A, i);
                    if (c > A_cnt) { A_cnt = c; rowIndex = i; }
                }
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    int c = CountPositiveElementsInColumn(B, j);
                    if (c > B_cnt) { B_cnt = c; colIndex = j; }
                }
                if (rowIndex >= 0 && colIndex >= 0)
                {
                    InsertColumn(ref A, rowIndex, colIndex, B);
                }
            }
            // end

        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int cnt = 0;
            for (int j = 0; j < matrix.GetLength(1);  j++)
            {
                if (matrix[row, j] > 0) cnt++;
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
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int[,] newA = new int[A.GetLength(0) + 1, A.GetLength(1)];
            for (int i = 0;i < newA.GetLength(0);i++)
            {
                for (int j = 0;j < newA.GetLength(1);j++)
                {
                    if (i <= rowIndex) newA[i,j] = A[i,j];
                    else if (i == rowIndex + 1) newA[i, j] = B[j, columnIndex];
                    else newA[i, j] = A[i - 1, j];
                }
            }
            A = newA;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            ChangeMatrixValues(matrix);
            // end

        }
        public void ChangeMatrixValues(int[,] matrix)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            if (row * col < 5)
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        matrix[i, j] *= 2;
                    }
                }
            }
            else
            {
                int[] arr = new int[row * col]; int c = 0;
                for (int i = 0;i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        arr[c++] = matrix[i, j];
                    }
                }
                c = 0;
                Array.Sort(arr);
                Array.Reverse(arr);
                int[][] coord = new int[5][];
                for (int k = 0; k < 5; k++)
                {
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            if (matrix[i,j] == arr[k] && !coord.Any(a => a != null && a[0] == i && a[1] == j))
                            {
                                coord[k] = new int[] { i, j };
                                break;
                            }
                        }
                        if (coord[k] != null) break;
                    }
                }
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if (coord.Any(a => a[0] == i && a[1] == j)) matrix[i, j] *= 2;
                        else matrix[i, j] /= 2;
                    }
                }
            }
        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            int[] count_A = CountNegativesPerRow(A);
            int[] count_B = CountNegativesPerRow(B);
            if (A.GetLength(1) == B.GetLength(1) && count_A.Any(x => x != 0) && count_B.Any(x => x != 0))
            {
                int index_A = FindMaxIndex(count_A);
                int index_B = FindMaxIndex(count_B);
                for (int i = 0; i < A.GetLength(1); i++)
                {
                    (A[index_A, i], B[index_B, i]) = (B[index_B, i], A[index_A, i]);
                }
            }
            // end

        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)]; int c = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int cnt = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0) cnt++;
                }
                array[c++] = cnt;
            }
            return array;
        }
        public int FindMaxIndex(int[] array)
        {
            int max_index = 0; int max = 0;
            for (int i = 0; i <  array.Length; i++)
            {
                if (array[i] > max) { max =  array[i]; max_index = i;}
            }
            return max_index;
        }
        public delegate void Sorting(int[] m);
        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public void SortNegativeAscending(int[] matrix)
        {
            int[] new_matrix = matrix.Where(x => x < 0).Order().ToArray(); int c = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0) matrix[i] = new_matrix[c++];
            }
        }
        public void SortNegativeDescending(int[] matrix)
        {
            int[] new_matrix = matrix.Where(x => x < 0).OrderDescending().ToArray(); int c = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0) matrix[i] = new_matrix[c++];
            }
        }
        public delegate void SortRowsByMax(int[,] matrix);
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public int GetRowMax(int[,] matrix, int row)
        {
            int max_el = matrix[row, 0];
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > max_el) max_el = matrix[row, j];
            }
            return max_el;
        }
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            int[] array = new int[row]; int c = 0;
            for (int i = 0; i < row; i++)
            {
                array[c++] = GetRowMax(matrix, i);
            }
            int[] sorted_array = (int[])array.Clone();
            Array.Sort(sorted_array);
            int[,] new_matrix = new int[row, col];
            for (int i = 0;i < row; i++)
            {
                int index = 0;
                for (int k = 0; k < row; k++)
                {
                    if (sorted_array[i] == array[k]) { index = k; break; }
                }
                array[index] = -1;
                for (int j = 0;  j < col; j++) new_matrix[i, j] = matrix[index, j];
            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0;j < col; j++) matrix[i,j] = new_matrix[i, j];
            }
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            int[] array = new int[row]; int c = 0;
            for (int i = 0; i < row; i++)
            {
                array[c++] = GetRowMax(matrix, i);
            }
            int[] sorted_array = (int[])array.Clone();
            Array.Sort(sorted_array);
            Array.Reverse(sorted_array);
            int[,] new_matrix = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                int index = 0;
                for (int k = 0; k < row; k++)
                {
                    if (sorted_array[i] == array[k]) { index = k; break; }
                }
                array[index] = -1;
                for (int j = 0; j < col; j++) new_matrix[i, j] = matrix[index, j];
            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++) matrix[i, j] = new_matrix[i, j];
            }
        }
        public delegate int[] FindNegatives(int[,] matrix);
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
            int row = matrix.GetLength(0); int col = matrix.GetLength(1);
            int[] array = new int[row]; int c = 0;
            for (int i = 0; i < row; i++)
            {
                int cnt = 0;
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i, j] < 0) cnt++;
                }
                array[c++] = cnt;
            }
            return array;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int row = matrix.GetLength(0); int col = matrix.GetLength(1);
            int[] array = new int[col]; int c = 0;
            for (int j = 0; j < col; j++)
            {
                int max = int.MinValue;
                for (int i = 0; i < row; i++)
                {
                    if (matrix[i, j] < 0 && matrix[i, j] > max) max = matrix[i, j];
                }
                if (max == int.MinValue) array[c++] = 0;
                else array[c++] = max;
            }
            return array;
        }
        public delegate int[,] MathInfo(int[,] matrix);
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
            int row = matrix.GetLength(0); int col = matrix.GetLength(1);
            int[,] answer = new int[0, 0];
            if (col > 1)
            {
                answer = new int[1, 1];
                bool check1 = true;
                for (int j = 1; j < col; j++)
                {
                    if (!(matrix[1, j - 1] <= matrix[1, j])) check1 = false;
                }
                bool check2 = true;
                for (int j = 1; j < col; j++)
                {
                    if (!(matrix[1, j - 1] >= matrix[1, j])) check2 = false;
                }
                if (check1 == true) answer[0, 0] = 1;
                else if (check2 == true) answer[0, 0] = -1;
            }
            return answer;
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            int row = matrix.GetLength(0); int col = matrix.GetLength(1);
            int[,] answer = new int[0, 0];
            if (col > 1)
            {
                int func = DefineSeq(matrix)[0, 0];
                if (func == 1 || func == -1)
                {
                    answer = new int[1, 2];
                    answer[0, 0] = matrix[0, 0];
                    answer[0, 1] = matrix[0, col - 1];
                }
                else
                {
                    int[] intervals_up = new int[col]; int c = 0;
                    int[] intervals_down = new int[col];
                    int changes = 1;
                    for (int j = 1; j < col; j++)
                    {
                        if (matrix[1, j - 1] <= matrix[1, j]) intervals_up[j - 1] = 1;
                    }
                    c = 0;
                    for (int j = 1; j < col; j++)
                    {
                        if (matrix[1, j - 1] >= matrix[1, j]) intervals_down[j - 1] = -1;
                    }
                    for (int i = 1; i < col - 1; i++)
                    {
                        if (intervals_up[i - 1] != intervals_up[i]) changes++;
                    }
                    answer = new int[changes, 2];
                    int cnt = 0;
                    for (int i = 0; i < col; i++)
                    {
                        if (intervals_up[i] == 1) cnt++;
                        else
                        {
                            if (cnt > 0)
                            {
                                answer[c, 0] = matrix[0, i - cnt];
                                answer[c, 1] = matrix[0, i];
                                c++;
                                cnt = 0;
                            }
                        }
                    }
                    cnt = 0;
                    for (int i = 0; i < col; i++)
                    {
                        if (intervals_down[i] == -1) cnt++;
                        else
                        {
                            if (cnt > 0)
                            {
                                answer[c, 0] = matrix[0, i - cnt];
                                answer[c, 1] = matrix[0, i];
                                c++;
                                cnt = 0;
                            }
                        }
                        if (c == changes) break;
                    }
                    for (int k = 0; k < answer.GetLength(0); k++)
                    {
                        bool f = false;
                        for (int i = 1; i < answer.GetLength(0); i++)
                        {
                            if (answer[i - 1, 0] > answer[i, 0])
                            {
                                (answer[i - 1, 0], answer[i, 0]) = (answer[i, 0], answer[i - 1, 0]);
                                (answer[i - 1, 1], answer[i, 1]) = (answer[i, 1], answer[i - 1, 1]);
                                f = true;
                            }
                        }
                        if (!f) break;
                    }
                    int count = 0;
                    for (int i = 1; i < answer.GetLength(0); i++)
                    {
                        if (answer[i - 1, 1] == answer[i, 1]) count++;
                    }
                    Console.WriteLine(count);
                    if (count > 0)
                    {
                        int[,] new_answer = new int[changes - 1, 2];
                        for (int i = 0; i < changes - 1; i++)
                        {
                            for (int j = 0; j < new_answer.GetLength(1); j++)
                            {
                                new_answer[i, j] = answer[i, j];
                            }
                        }
                        answer = new int[changes - 1, 2];
                        for (int i = 0; i < changes - 1; i++)
                        {
                            for (int j = 0; j < new_answer.GetLength(1); j++)
                            {
                                answer[i, j] = new_answer[i, j];
                            }
                        }
                    }
                }
            }
            return answer;
        }
        public int[,] FindLongestSeq(int[,] matrix)
        {
            int[,] answer = new int[0,0];
            int[,] intervals = FindAllSeq(matrix);
            if (intervals.Length > 0)
            {
                answer = new int[1, 2];
                int max = Math.Abs(intervals[0, 1] - intervals[0,0]);
                for (int i = 1; i < intervals.GetLength(0);  i++)
                {
                    if (Math.Abs(intervals[i, 1] - intervals[i, 0]) > max)
                    {
                        max = Math.Abs(intervals[i, 1] - intervals[i, 0]);
                    }
                }
                for (int i = 0; i < intervals.GetLength(0); i++)
                {
                    if (Math.Abs(intervals[i, 1] - intervals[i, 0]) == max)
                    {
                        answer[0, 0] = intervals[i, 0];
                        answer[0, 1] = intervals[i, 1];
                        break;
                    }
                }
            }
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
        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            int cnt = 0;
            for (double x = a;  x <= b; x+= h)
            {
                cnt++;
            }
            int[] znak = new int[cnt]; ; int c = 0;
            for (double x = a; x <= b; x += h)
            {
                if (func(x) >= 0) znak[c++] = 1;
                else if (func(x) < 0) znak[c++] = -1;
            }
            int ans = 0;
            for (int i = 1; i < cnt; i++)
            {
                if (znak[i - 1] != znak[i]) ans++;
            }
            return ans;
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
                if (i % 2 == 0) Array.Sort(array[i]);
                else { Array.Sort(array[i]); Array.Reverse(array[i]); }
            }
        }
        public void SortBySumDesc(int[][] array)
        {
            int[] sums = new int[array.Length]; int c = 0;
            foreach (int[] a in array)
            {
                int s = 0;
                foreach (int el in a) s += el;
                sums[c++] = s;
            }
            Array.Sort(sums);
            Array.Reverse(sums);
            int[][] new_array = new int[array.Length][];
            for (int k = 0; k < sums.Length; k++)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    int s = 0; 
                    for (int j = 0;  j < array[i].Length; j++)
                    {
                        s += array[i][j];
                    }
                    if (s == sums[k])
                    {
                        new_array[k] = (int[])array[i].Clone();
                        for (int j = 0; j < array[i].Length; j++) array[i][j] = -100;
                        break;
                    }
                }
            }
            for (int i = 0; i < new_array.Length;i++)
            {
                array[i] = new int[new_array[i].Length];
                for (int j = 0;j < new_array[i].Length;j++)
                {
                    array[i][j] = new_array[i][j];
                }
            }
        }
        public void TotalReverse(int[][] array)
        {
            foreach (int[] a in array)
            {
                Array.Reverse(a);
            }
            Array.Reverse(array);
        }
    }
}