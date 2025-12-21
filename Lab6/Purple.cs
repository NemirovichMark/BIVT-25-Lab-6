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
            int na = A.GetLength(0);
            int ma = A.GetLength(1);
            int nb = B.GetLength(0);
            int mb = B.GetLength(1);
            int i1 = -1;
            int i2 = -1;
            if (na == ma)
            {
                if (nb == mb)
                {
                    if (nb == ma)
                    {
                        i1 = FindDiagonalMaxIndex(A);
                        i2 = FindDiagonalMaxIndex(B);
                        SwapRowColumn(A, i1, B, i2);
                    }
                }
            }
            // end

        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int mx = int.MinValue;
            int mxi = -1;
            int mxj = -1;
            for (int i = 0; i < n;i++)
            {

                if (matrix[i, i] > mx)
                {
                    mx = matrix[i, i];
                    mxi = i;
                }
            }
            return mxi;
        }
        public void SwapRowColumn(int[,] matrix, int rowIndex, int[,] B, int columnIndex)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                (matrix[rowIndex, i], B[i, columnIndex]) = (B[i, columnIndex], matrix[rowIndex, i]);
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
                Console.WriteLine("--");
                Console.WriteLine(i);
                Console.WriteLine("--");
                for (int j = 0; j < ma; j++)
                {
                    Console.WriteLine(j);
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
            // code here
            ChangeMatrixValues(matrix);
            // end

        }
        public void ChangeMatrixValues(int[,] matrix)
        {
            
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n * m > 5)
            {
                int[,] m2 = new int[n, m];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        m2[i, j] = matrix[i, j];
                    }
                }
                int[,] m3 = new int[n, m];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        m3[i, j] = matrix[i, j];
                    }
                }
                int[,] index = new int[5, 2];
                int k = 0;
                int mx = int.MinValue;
                int mxi = int.MinValue;
                int mxj = int.MinValue;
                while (k < 5)

                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            if (m2[i, j] > mx)
                            {
                                mx = m2[i, j];
                                mxi = i;
                                mxj = j;

                            }
                        }
                    }
                    m2[mxi, mxj] = int.MinValue;
                    index[k, 0] = mxi;
                    index[k, 1] = mxj;
                    k++;
                    mx = int.MinValue;
                }
                for (int i = 0; i < 5; i++)
                {
                    matrix[index[i, 0], index[i, 1]] *= 2;
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] == m3[i, j])
                        {
                            matrix[i, j] /= 2;
                        }
                    }
                }
            }
            else
            {
                for(int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        matrix[i, j] *= 2;
                    }
                }
            }

        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
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
            // end

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
        public delegate void Sorting(int[] matrix);
        
        public void Task5(int[] matrix, Sorting sort)
        {

            // code here
            sort(matrix);


            // end

        }
        public void SortNegativeAscending(int[] matrix)
        {
            int n = matrix.Length;
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i] < 0)
                {
                    k++;
                }
            }
            
            int[] arr = new int[k];
            k = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i] < 0)
                {
                    arr[k] = matrix[i];
                    k++;
                }
            }
            for (int i = 0; i < k - 1; i++)
            {
                for (int j = 0; j < k - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
            }
            k = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = arr[k];
                    k++;
                }
            }
        }
        public void SortNegativeDescending(int[] matrix)
        {
            int n = matrix.Length;
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i] < 0)
                {
                    k++;
                }
            }
            int[] arr = new int[k];
            k = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i] < 0)
                {
                    arr[k] = matrix[i];
                    k++;
                }
            }
            for (int i = 0; i < k - 1; i++)
            {
                for (int j = 0; j < k - i - 1; j++)
                    if (arr[j] < arr[j + 1])
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
            }
            k = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i] < 0)
                {
                    matrix[i] = arr[k];
                    k++;
                }
            }
        }
        public delegate void SortRowsByMax(int[,] matrix);
        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] sm = new int[n, m];
            int[,] ind = new int[n, 2];
            for (int i = 0; i < n; i++)
            {
                ind[i, 0] = matrix[i, GetRowMax2(matrix, i)];
                ind[i, 1] = i;
            }
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (ind[j, 0] > ind[j + 1, 0])
                    {
                        (ind[j, 0], ind[j + 1, 0]) = (ind[j + 1, 0], ind[j, 0]);
                        (ind[j, 1], ind[j + 1, 1]) = (ind[j + 1, 1], ind[j, 1]);
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sm[i, j] = matrix[ind[i, 1], j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = sm[i, j];
                }
            }
        }
        public void SortRowsByMaxDescending(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] sm = new int[n, m];
            int[,] ind = new int[n, 2];
            for (int i = 0; i < n; i++)
            {
                ind[i, 0] = matrix[i, GetRowMax2(matrix, i)];
                ind[i, 1] = i;
            }
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (ind[j, 0] < ind[j + 1, 0])
                    {
                        (ind[j, 0], ind[j + 1, 0]) = (ind[j + 1, 0], ind[j, 0]);
                        (ind[j, 1], ind[j + 1, 1]) = (ind[j + 1, 1], ind[j, 1]);
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sm[i, j] = matrix[ind[i, 1], j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = sm[i, j];
                }
            }
        }
        public int GetRowMax(int[,] matrix, int row)
        {
            int m = matrix.GetLength(1);
            int mx = int.MinValue;
            int mxi = -1;
            for (int i = 0; i < m; i++)
            {
                if (matrix[row, i] > mx)
                {
                    mx = matrix[row, i];
                    mxi = i;
                }
            }
            return mx;
        }
        public int GetRowMax2(int[,] matrix, int row)
        {
            int m = matrix.GetLength(1);
            int mx = int.MinValue;
            int mxi = -1;
            for (int i = 0; i < m; i++)
            {
                if (matrix[row, i] > mx)
                {
                    mx = matrix[row, i];
                    mxi = i;
                }
            }
            return mxi;
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
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] negatives = new int[n];
            for (int i=0; i<n; i++)
            {
                int k = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        k++;
                    }
                }
                negatives[i] = k;
            }
            return negatives;
        }
        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] negatives = new int[m];
            for (int i = 0; i < m; i++)
            {
                int mx=int.MinValue;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[j,i] >mx && matrix[j, i] < 0)
                    {
                        mx = matrix[j, i];
                    }
                }
                if (mx == int.MinValue) mx = 0;
                negatives[i] = mx;
            }
            return negatives;
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
            int m = matrix.GetLength(1);
            int high = 0;
            int low = 0;
            int netr = 0;
            for (int i = 0; i < m - 1; i++)
            {
                if (matrix[1, i] <= matrix[1, i + 1]) high++;
                if (matrix[1, i] >= matrix[1, i + 1]) low++;
            }
            int[,] ans = new int[1, 1];
            if (high == m - 1) ans[0, 0] = 1;
            else if (low == m - 1) ans[0, 0] = -1;
            else ans[0, 0] = 0;
            if (m == 1)
            {
                int[,] ans2 = new int[0, 0];
                return ans2;
            }
            return ans;
        }
        public int[,] FindAllSeq(int[,] matrix)
        {
            int high = 0;
            int low = 0;
            int m = matrix.GetLength(1);
            if (m == 1)
            {
                int[,] ans2 = new int[0,0];
                return ans2;
            }
            int k = 0;
            for (int i = 0; i < m - 1; i++)
            {
                if (matrix[1, i] > matrix[1, i + 1])
                {
                    if (high == 1)
                    {

                    }
                    else
                    {
                        high = 1;
                        low = 0;
                        k++;
                    }
                }
                else if (matrix[1, i] < matrix[1, i + 1])
                {
                    {
                        if (low == 1)
                        {

                        }
                        else
                        {
                            high = 0;
                            low = 1;
                            k++;
                        }
                    }
                }

            }
            int[,] ans = new int[k, 2];
            int b = matrix[0, 0];
            int e = 0;
            k = 0;
            low = 0;
            high = 0;
            for (int i = 0; i < m - 1; i++)
            {
                if (i == 0)
                {
                    if (matrix[1, i] < matrix[1, i + 1]) high = 1;
                    else if (matrix[1, i] > matrix[1, i + 1]) low = 1;
                }
                else
                {

                    if (matrix[1, i] < matrix[1, i + 1])
                    {
                        if (high == 1)
                        {
                            e = matrix[0, i];
                            if (i == m - 2)
                            {
                                ans[k, 0] = b;
                                ans[k, 1] = matrix[0, i + 1];
                            }
                        }
                        else
                        {

                            high = 1;
                            low = 0;
                            ans[k, 0] = b;
                            ans[k, 1] = matrix[0, i];
                            k++;
                            e = matrix[0, i];
                            b = matrix[0, i];
                        }
                    }
                    else if (matrix[1, i] > matrix[1, i + 1])
                    {
                        {
                            if (low == 1)
                            {
                                e = matrix[0, i];
                                if (i == m - 2)
                                {
                                    ans[k, 0] = b;
                                    ans[k, 1] = matrix[0, i + 1];
                                }
                            }
                            else
                            {

                                high = 0;
                                low = 1;
                                ans[k, 0] = b;
                                ans[k, 1] = matrix[0, i];
                                e = matrix[0, i];
                                k++;
                                b = matrix[0, i];
                            }
                        }
                    }
                    else if (matrix[1, i] == matrix[1, i + 1])
                    {
                        e = matrix[0, i];
                        if (i == m - 2)
                        {

                            ans[k, 0] = b;
                            ans[k, 1] = matrix[0, i + 1]; ;

                        }
                    }
                    if (i == m - 2)
                    {

                        if (ans[ans.GetLength(0) - 1, 0] == ans[ans.GetLength(0) - 1, 1])
                        {
                            ans[ans.GetLength(0) - 1, 0] = e;
                            ans[ans.GetLength(0) - 1, 1] = matrix[0, i + 1];
                        }

                    }
                }
            }
            return ans;
        }
        public int[,] FindLongestSeq(int[,] matrix)
        {
            int[,] inter = FindAllSeq(matrix);
            int[,] empty = new int[0, 0];
            int m = matrix.GetLength(1);
            if (m == 1)
            {
                return empty;
            }
            int n = inter.GetLength(0);

            int[] time = new int[n];
            int[,] ans = new int[1, 2];
            for (int i = 0; i < n; i++)
            {
                time[i] = inter[i, 1] - inter[i, 0];
            }
            int mx = int.MinValue;
            int mxi = -1;
            for (int i = 0; i < n; i++)
            {
                if (time[i] > mx)
                {
                    mx = time[i];
                    mxi = i;
                }
            }
            ans[0, 0] = inter[mxi, 0];
            ans[0, 1] = inter[mxi, 1];
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
            int k = 0;
            for (double i = a; i <= b; i += h)
            {
                k++;
            }
            double[,] table = new double[k, 2];
            k = 0;
            for (double i = a; i <= b; i += h)
            {
                table[k, 0] = i;
                table[k, 1] = func(i);
                k++;
            }
            int ans = 0;
            k = table.GetLength(0);
            int high = 0;
            int low = 0;
            if (table[0, 1] > 0)
            {
                high = 1;
            }
            if (table[0, 1] < 0)
            {
                low = 1;
            }
            for (int i = 1; i < k; i++)
            {
                if (table[i, 1] > 0)
                {
                    if (low == 1)
                    {
                        ans++;
                        low = 0;
                        high = 1;
                    }
                }
                if (table[i, 1] < 0)
                {
                    if (high == 1)
                    {
                        ans++;
                        low = 1;
                        high = 0;
                    }
                }
            }
            return ans;
        }
        public double FuncA(double x)
        {
            double y = x*x - Math.Sin(x);
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
            for(int i = 0; i < array.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    int n = array[i].Length;
                    for (int k = 0; k < n - 1; k++) 
                    {
                        for (int j = 0; j < n - k - 1; j++)
                            if (array[i][j] > array[i][j + 1]) 
                                (array[i][j], array[i][j + 1]) = (array[i][j + 1], array[i][j]); 
                    }
                }
                else
                {
                    int n = array[i].Length;
                    for (int k = 0; k < n - 1; k++)
                    {
                        for (int j = 0; j < n - k - 1; j++)
                            if (array[i][j] < array[i][j + 1]) 
                                (array[i][j], array[i][j + 1]) = (array[i][j + 1], array[i][j]); 
                    }
                }
            }
        }
        public void SortBySumDesc(int[][] array)
        {
            int n = array.Length;
            int[][] ans = new int[n][];
            int[,] b = new int[n, 2];
            //заполнение суммами массив б
            for (int i = 0; i < n; i++)
            {
                int m = array[i].Length;
                int s = 0;
                for (int j = 0; j < m; j++)
                {
                    s += array[i][j];
                }
                b[i, 0] = i;
                b[i, 1] = s;
            }
            //сортировка массива б
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                    if (b[j, 1] < b[j + 1, 1])
                    {
                        (b[j, 1], b[j + 1, 1]) = (b[j + 1, 1], b[j, 1]);
                        (b[j, 0], b[j + 1, 0]) = (b[j + 1, 0], b[j, 0]);
                    }
            }
            //заполнение нового массива
            for (int i = 0; i < n; i++)
            {
                int m = array[b[i, 0]].Length;
                ans[i] = new int[m];
                for (int j = 0; j < m; j++)
                {
                    ans[i][j] = array[b[i, 0]][j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                int m = ans[i].Length;
                array[i] = new int[m];
                for (int j = 0; j < m; j++)
                {
                    array[i][j] = ans[i][j];
                }
            }
        }
        public void TotalReverse(int[][] array)
        {
            int n = array.Length;
            int[][] ans = new int[n][];

            for (int i = 0; i < n; i++)
            {
                int m = array[i].Length;
                for (int j = 0; j < m / 2; j++)
                {
                    (array[i][j], array[i][m - j - 1]) = (array[i][m - j - 1], array[i][j]);
                }
            }
            for (int i = 0; i < n; i++)
            {
                ans[i] = new int[array[n - i - 1].Length];
                ans[n - i - 1] = new int[array[i].Length];
                ans[i] = array[n - i - 1];
                ans[n - i - 1] = array[i];
            }
            for (int i = 0; i < n; i++)
            {
                int m = ans[i].Length;
                array[i] = new int[m];
                array[i] = ans[i];
            }
        }
    }
}
