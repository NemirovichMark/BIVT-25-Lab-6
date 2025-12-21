using System;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        private static void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void Task1(int[,] A, int[,] B)
        {
            if (A.GetLength(0) != A.GetLength(1) || B.GetLength(0) != B.GetLength(1) ||
                A.GetLength(0) != B.GetLength(0)) return;


            int mx_row = FindDiagonalMaxIndex(A);
            int mx_col = FindDiagonalMaxIndex(B);
            SwapRowColumn(A, mx_row, B, mx_col);
        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {

            int mx = matrix[0, 0];
            int mx_ind = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > mx)
                {
                    mx = matrix[i, i];
                    mx_ind = i;
                }
            }
            return mx_ind;
        }

        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            int m = matrix.GetLength(1);
            int[] row = new int[m];
            int[] col = new int[m];
            for (int i = 0; i < m; i++)
            {
                row[i] = matrix[rowIndex, i];
                col[i] = B[i, columnIndex];
            }
            for (int i = 0; i < m; i++)
            {
                B[i, columnIndex] = row[i];
                matrix[rowIndex, i] = col[i];
            }

        }
        public void Task2(ref int[,] A, int[,] B)
        {

            // code here

            int na = A.GetLength(0);
            int ma = A.GetLength(1);
            int nb = B.GetLength(0);
            int mb = B.GetLength(1);
            if (ma == nb)
            {
                int mxb = int.MinValue;
                int mxbi = -1;
                for (int i = 0; i < mb; i++)
                {
                    if (mxb < CountPositiveElementsInColumn(B, i))
                    {
                        mxb = CountPositiveElementsInColumn(B, i);
                        mxbi = i;
                    }
                }
                Console.WriteLine(mxbi);
                Console.WriteLine(mxb);
                if (mxb > 0)
                {
                    int mxa = int.MinValue;
                    int mxai = -1;
                    for (int i = 0; i < na; i++)
                    {
                        if (mxa < CountPositiveElementsInRow(A, i))
                        {
                            mxa = CountPositiveElementsInRow(A, i);
                            mxai = i;
                        }
                    }
                    InsertColumn(ref A, mxai, mxbi, B);
                }
            }
            // end

        }
        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int c = 0;
            for (int i = 0; i < m; i++)
            {
                if (matrix[row, i] > 0)
                {
                    c++;
                }
            }
            return c;
        }
        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int c = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, col] > 0)
                {
                    c++;
                }
            }
            return c;
        }
        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            rowIndex += 1;
            int na = A.GetLength(0);
            int ma = A.GetLength(1);
            int[,] newA = new int[na + 1, ma];
            for (int i = 0; i < na + 1; i++)
            {

                for (int j = 0; j < ma; j++)
                {

                    if (i < rowIndex)
                    {
                        newA[i, j] = A[i, j];
                    }
                    else if (i == rowIndex)
                    {
                        newA[i, j] = B[j, columnIndex];
                    }
                    else
                    {
                        newA[i, j] = A[i - 1, j];
                    }
                }
            }
            A = newA;
        }

        public void Task3(int[,] matrix)
        {

            //Console.WriteLine(string.Join(" ", Find_5_max(matrix)));
            ChangeMatrixValues(matrix);

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
                    bool t = false;
                    for (int j = 0; j < 5; j++)
                    {
                        if (array[i] == max_elem[j] && check[j]==false)
                        {
                            array[i] *= 2;
                            check[j] = true;
                            t = true;
                            break;
                        }
                    }

                    if (!t)
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


            int[] Ai = CountNegativesPerRow(A);
            int[] Bi = CountNegativesPerRow(B);
            int Aind = FindMaxIndex(Ai);
            int Bind = FindMaxIndex(Bi);
            int Am = A.GetLength(1);
            int Bm = B.GetLength(1);
            if (Aind != -1 && Bind != -1 && Am == Bm)
            {
                int n = A.GetLength(1);
                for (int i = 0; i < n; i++)
                {
                    (A[Aind, i], B[Bind, i]) = (B[Bind, i], A[Aind, i]);
                }
            }


        }
        public int[] CountNegativesPerRow(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] Ai = new int[n];
            for (int i = 0; i < n; i++)
            {
                int k = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        k++;
                    }
                }
                Ai[i] = k;
            }
            return Ai;
        }
        public int FindMaxIndex(int[] array)
        {
            int n = array.Length;
            int mx = 0;
            int mxi = -1;
            for (int i = 0; i < n; i++)
            {
                if (array[i] > mx)
                {
                    mx = array[i];
                    mxi = i;
                }
            }
            return mxi;
        }

        public void Task5(int[] matrix, Sorting sort)
        {
            sort(matrix);

        }
        public delegate void Sorting(int[] matrix);


        public void SortNegativeAscending(int[] matrix)
        {

            int cnt = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    cnt++;
            }
            int k = 0;
            int[] neg_arr = new int[cnt];
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    neg_arr[k++] = matrix[i];
                }
            }
            for (int i = 0; i < neg_arr.Length; i++)
            {
                for (int j = 0; j < neg_arr.Length - 1; j++)
                {
                    if (neg_arr[j] > neg_arr[j + 1])
                        (neg_arr[j], neg_arr[j + 1]) = (neg_arr[j + 1], neg_arr[j]);
                }
            }
            k = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    matrix[i] = neg_arr[k++];
            }
        }
        public void SortNegativeDescending(int[] matrix)
        {
            int cnt = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    cnt++;
            }
            int k = 0;
            int[] neg_arr = new int[cnt];
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                {
                    neg_arr[k++] = matrix[i];
                }
            }
            for (int i = 0; i < neg_arr.Length; i++)
            {
                for (int j = 0; j < neg_arr.Length - 1; j++)
                {
                    if (neg_arr[j] < neg_arr[j + 1])
                        (neg_arr[j], neg_arr[j + 1]) = (neg_arr[j + 1], neg_arr[j]);
                }
            }
            k = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] < 0)
                    matrix[i] = neg_arr[k++];
            }
        }

        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            sort(matrix);

        }
        public delegate void SortRowsByMax(int[,] matrix);
        public int GetRowMax(int[,] matrix, int row)
        {
            int mx_elem = matrix[row, 0];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > mx_elem)
                {
                    mx_elem = matrix[row, j];
                }
            }
            return mx_elem;
        }
        private void SwapmyRows(int[,] marix, int row1, int row2)
        {
            int m = marix.GetLength(1);
            for (int j = 0; j< m; j++)
            {
                (marix[row1, j], marix[row2, j]) = (marix[row2, j], marix[row1, j]);
            }
        }
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int n = matrix.GetLength(0);

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    int max1 = GetRowMax(matrix, j);
                    int max2 = GetRowMax(matrix, j + 1);

                    if (max1 > max2)
                    {
                        SwapmyRows(matrix, j, j + 1);
                    }
                }
            }
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int n = matrix.GetLength(0);

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    int max1 = GetRowMax(matrix, j);
                    int max2 = GetRowMax(matrix, j + 1);

                    if (max1 < max2)
                    {
                        SwapmyRows(matrix, j, j + 1);
                    }
                }
            }
        }

        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            negatives = find(matrix);
            Console.WriteLine(string.Join(" ", negatives));
            Console.WriteLine();

            return negatives;
        }
        public delegate int[] FindNegatives(int[,] matrix);
        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] arr = new int[n];
            for (int i = 0; i<n; i++)
            {
                int cnt = 0;
                for (int j = 0; j<m; j++)
                {
                    if (matrix[i, j] < 0)
                        cnt++;
                }
                arr[i] = cnt;
            }
            return arr;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] arr = new int[m];
            for (int i = 0; i < m; i++)
            {
                int mx_elem = int.MinValue;
                bool flag = false;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[j, i] > mx_elem && matrix[j, i] < 0)
                    {
                        mx_elem = matrix[j, i];
                        flag = true;
                    }
                }
                if (flag == true)
                    arr[i] = mx_elem;
                else
                    arr[i] = 0;
            }
            return arr;
        }

        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;
            answer = info(matrix);
            
            return answer;
        }
        public delegate int[,] MathInfo(int[,] matrix);
        private bool Up(int[,] matrix)
        {
            bool flag = true;
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[1, j] > matrix[1, j + 1])
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        private bool Down(int[,] matrix)
        {
            bool flag = true;
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[1, j] < matrix[1, j + 1])
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        public int[,] DefineSeq(int[,] matrix)
        {

            int[,] ans = new int[1, 1];
            bool flag = true;

            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[1, j] != matrix[1, j + 1])
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true)
            {
                return new int[0, 0];
            }
            if (Up(matrix) == true)
            {
                ans[0,0] = 1;
                Print(ans);

            }
            else if (Down(matrix) == true)
                ans[0, 0] = -1;
            else
                ans[0, 0] = 0;
            Console.WriteLine();
            return ans;
            
        }

        public int[,] FindAllSeq(int[,] matrix)
        {
            int n = matrix.GetLength(1);
            if (n < 2) return new int[0, 0];
            if (DefineSeq(matrix)[0, 0] != 0)
            {
                int[,] ans = new int[1, 2];
                ans[0, 0] = matrix[0, 0];
                ans[0, 1] = matrix[0, n - 1];
                return ans;
            }

            int count = 0;
            for (int j = 1; j + 1 < n; j++)
            {
                if ((matrix[1, j] > matrix[1, j + 1] && matrix[1, j] > matrix[1, j - 1]) ||
                    (matrix[1, j] < matrix[1, j + 1] && matrix[1, j] < matrix[1, j - 1]))
                {
                    count++;
                }
            }

            int[] c = new int[count + 2];
            int i1 = 1;
            for (int j = 1; j + 1 < n; j++)
            {
                if ((matrix[1, j] > matrix[1, j + 1] && matrix[1, j] > matrix[1, j - 1]) ||
                    (matrix[1, j] < matrix[1, j + 1] && matrix[1, j] < matrix[1, j - 1]))
                {
                    c[i1] = matrix[0, j];
                    i1++;
                }
            }

            c[0] = matrix[0, 0];
            c[c.Length - 1] = matrix[0, n - 1];
            int[,] answer = new int[count + 1, 2];
            i1 = 0;
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    answer[i, j] = c[i1];
                    i1++;
                }

                i1--;
            }

            return answer;
        }

        public int[,] FindLongestSeq(int[,] matrix)
        {
            if (matrix.GetLength(1) < 2) return new int[0,0];
            int[,] ans = new int[1, 2];
            int[,] array = FindAllSeq(matrix);
            int max = int.MinValue;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int dfr = array[i, 1] - array[i, 0];
                if (dfr > max)
                {
                    max = dfr;
                    ans[0, 0] = array[i, 0];
                    ans[0, 1] = array[i, 1];
                }
            }

            return ans;
        }

        public int Task9(double a, double b, double h, Func<double, double> func)
        {
            int answer = 0;

            if (a > b) return 0;
            answer = CountSignFlips(a, b, h, func);
            return answer;
        }
        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            int cnt = 0;
            int prev = Math.Sign(func(a));
            double start = a + h;
            int now = Math.Sign(func(a + h));

            for (double i = start; i <= b; i += h)
            {
                double val = func(i);
                now = Math.Sign(val);
                if (val == 0)
                {
                    
                    continue;
                }
                if (now != prev)
                {
                    cnt++;
                    prev = now;
                }


            }
            return cnt;
        }

        public delegate double Func(double x);
        public double FuncA(double x)
        {
            double y = x * x - Math.Sin(x);
            return y;
        }
        public double FuncB(double x)
        {
            double y = Math.Exp(x) - 1;
            return y;
        }
        public void Task10(int[][] array, Action<int[][]> func)
        {

            func(array);

        }
        public delegate void Action(int[][] array);

        public void SortInCheckersOrder(int[][] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                int m = array[i].Length;
                for (int j1 = 0; j1<m; j1++)
                {
                    for (int j2 = 0; j2 < m-1-j1; j2++)
                    {
                        if (array[i][j2] >  array[i][j2 + 1] && i % 2 == 0)
                            (array[i][j2], array[i][j2 + 1]) = (array[i][j2 + 1], array[i][j2]);
                        if (array[i][j2] < array[i][j2 + 1] && i % 2 == 1)
                            (array[i][j2], array[i][j2 + 1]) = (array[i][j2 + 1], array[i][j2]);
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
                    int sum1 = CalculateSum(array[j]);
                    int sum2 = CalculateSum(array[j + 1]);

                    if (sum1 < sum2)
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
        }
        
        private int CalculateSum(int[] arr)
        {
            int sum = 0;
            foreach (int num in arr)
            {
                sum += num;
            }
            return sum;
        }
        

        public void TotalReverse(int[][] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                int m = array[i].Length;
                for (int j = 0; j < m/2; j++)
                {
                    (array[i][j], array[i][m - 1-j]) = (array[i][m-1-j], array[i][j]);
                }
            }
            for (int i = 0; i < n/ 2; i++)
            {
                (array[i], array[n-1-i]) = (array[n-1-i], array[i]);
                //Console.WriteLine(string.Join(" ", array[i]));
            }

        }


    }
}
