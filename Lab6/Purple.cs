using System;
using System.Buffers;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6
{
    public class Purple
    {
        public void Task1(int[,] A, int[,] B)
        {

            // code here
            int mA = FindDiagonalMaxIndex(A);
            int mB = FindDiagonalMaxIndex(B);

            SwapRowColumn(A, mA, B, mB);
            // end

        }

        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int max_i = 0;
            int max = matrix[0, 0];
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    max_i = i;
                }
            }
            return max_i;
        }

        public void SwapRowColumn(int[,] A, int rowIndex, int[,] B, int columnIndex) // заменил matrix на A
        {
            int n = A.GetLength(0);
            if (A.GetLength(0) != A.GetLength(1) || B.GetLength(0) != B.GetLength(0) || A.GetLength(0) != B.GetLength(0))
            {
                return;
            }
            for (int i = 0; i < n; i++)
            {
                int temp = A[rowIndex, i];
                A[rowIndex, i] = B[i, columnIndex];
                B[i, columnIndex] = temp;
            }
        }

        public void InsertColumn(ref int[,] A, int rowIndex, int columnIndex, int[,] B)
        {
            int rows = A.GetLength(0);
            int cols = A.GetLength(1);
            int b_rows = B.GetLength(0);
            int b_cols = B.GetLength(1);
            if (b_rows != cols)
            {
                return;
            }
            int[,] newA = new int[rows + 1, cols];
            for (int i = 0; i <= rowIndex && i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    newA[i, j] = A[i, j];
                }
            }
            for (int j = 0; j < cols; j++)
            {
                newA[rowIndex + 1, j] = B[j, columnIndex];
            }

            for (int i = rowIndex + 1; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    newA[i + 1, j] = A[i, j];
                }
            }
            A = newA;
        }

        public int CountPositiveElementsInRow(int[,] matrix, int row)
        {
            int cnt = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > 0)
                {
                    cnt++;
                }
            }
            return cnt;
        }

        public int CountPositiveElementsInColumn(int[,] matrix, int col)
        {
            int cnt = 0;
            for (int i = 0;  i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] > 0)
                {
                    cnt++;
                }
            }
            return cnt;
        }

        public void ChangeMatrixValues(int[,] matrix)
        {
            if (matrix == null)
            {
                return;
            }
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int elems = rows * cols;
            if (elems <= 5)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = matrix[i, j] * 2;
                    }
                }
                return;
            }
            bool[,] top_5 = new bool[rows, cols];
            for (int count = 0; count < 5; count++)
            {
                int maxx = -10000000;
                int max_i = -1;
                int max_j = -1;
                for (int i =0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (!top_5[i,j] && matrix[i, j] > maxx)
                        {
                            maxx = matrix[i, j];
                            max_i = i; max_j = j;
                        }
                    }
                }
                if (max_i != -1 && max_j != -1)
                {
                    top_5[max_i, max_j] = true;
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j =0; j < cols; j++)
                {
                    if (top_5[i, j] == true)
                    {
                        matrix[i,j] = matrix[i, j] * 2;
                    } else
                    {
                        matrix[i, j] = matrix[i, j] / 2;
                    }
                }
            }
        }

        public int[] CountNegativesPerRow(int[,] matrix)
        {
            if (matrix == null)
            {
                return new int[0];
            }
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                int cnt = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i,j] < 0)
                    {
                        cnt++;
                    }
                }
                array[i] = cnt;
            }
            return array;
        }

        public int FindMaxIndex(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return 0;
            }
            int max_i = 0;
            int maxx = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxx)
                {
                    maxx = array[i];
                    max_i = i;
                }
            }
            return max_i;
        }

        public void SortNegativeAscending(int[] array)
        {
            if (array == null)
            {
                return;
            }
            int cnt = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    cnt++;
                }
            }
            if (cnt == 0)
            {
                return;
            }
            int[] otr = new int[cnt];
            int[] otr_i = new int[cnt];
            int ind = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    otr[ind] = array[i];
                    otr_i[ind] = i;
                    ind++;
                }
            }
            for (int i = 0; i < cnt - 1; i++)
            {
                for (int j = 0; j < cnt - 1 - i; j++)
                {
                    if (otr[j] > otr[j + 1])
                    {
                        int temp = otr[j];
                        otr[j] = otr[j + 1];
                        otr[j + 1] = temp;
                    }
                }
            }
            for (int i = 0; i < cnt; i++)
            {
                array[otr_i[i]] = otr[i];
            }
        }

        public void SortNegativeDescending(int[] array)
        {
            if (array == null)
            {
                return;
            }
            int cnt = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    cnt++;
                }
            }
            if (cnt == 0)
            {
                return;
            }
            int[] otr = new int[cnt];
            int[] otr_i = new int[cnt];
            int ind = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    otr[ind] = array[i];
                    otr_i[ind] = i;
                    ind++;
                }
            }
            for (int i = 0; i < cnt - 1; i++)
            {
                for (int j = 0; j < cnt - 1 - i; j++)
                {
                    if (otr[j] < otr[j + 1])
                    {
                        int temp = otr[j];
                        otr[j] = otr[j + 1];
                        otr[j + 1] = temp;
                    }
                }
            }
            for (int i = 0; i < cnt; i++)
            {
                array[otr_i[i]] = otr[i];
            }
        }
        public void SwapRows(int[,] matrix, int row1, int row2)
        {
            int m = matrix.GetLength(1);
            for (int j = 0; j < m; j++)
            {
                int temp = matrix[row1, j];
                matrix[row1, j] = matrix[row2,j];
                matrix[row2, j] = temp;
            }
        }
        public void SortRowsByMaxAscending(int[,] matrix)
        {
            if (matrix == null)
            {
                return;
            }
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n == 0 || m == 0)
            {
                return;
            }
            int[] maxs = new int[n];
            for (int i = 0; i < n; i++)
            {
                maxs[i] = GetRowMax(matrix, i);
            }
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (maxs[j] > maxs[j + 1])
                    {
                        int temp = maxs[j];
                        maxs[j] = maxs[j + 1];
                        maxs[j + 1] = temp;
                        SwapRows(matrix, j, j + 1);
                    }
                }
            }
        }

        public void SortRowsByMaxDescending(int[,] matrix)
        {
            if (matrix == null)
            {
                return;
            }
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n == 0 || m == 0)
            {
                return;
            }
            int[] maxs = new int[n];
            for (int i = 0; i < n; i++)
            {
                maxs[i] = GetRowMax(matrix, i);
            }
            for (int i = 0; i < n - 1; i++)
            {
                for (int j =0; j < n - 1 - i; j++)
                {
                    if (maxs[j] < maxs[j + 1])
                    {
                        int temp = maxs[j];
                        maxs[j] = maxs[j + 1];
                        maxs[j + 1] = temp;
                        SwapRows(matrix, j, j + 1);
                    }
                }
            }
        }

        public int GetRowMax(int[,] matrix, int row)
        {
            int m = matrix.GetLength(1);
            int maxx = matrix[row, 0];
            for (int j = 1; j < m; j++)
            {
                if (matrix[row, j] > maxx)
                {
                    maxx = matrix[row, j];
                }
            }
            return maxx;
        }

        public int[] FindNegativeCountPerRow(int[,] matrix)
        {
            if (matrix == null)
            {
                return new int[0];
            }
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[] result = new int[n];
            for(int i =0; i < n; i++)
            {
                int cnt = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        cnt++;
                    }
                }
                result[i] = cnt;
            }
            return result;
        }

        public int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            if (matrix == null)
            {
                return new int[0];
            }
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] result = new int[m];

            for (int j = 0; j < m; j++)
            {
                int max = 0;
                bool t = false;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i,j] < 0)
                    {
                        if (!t)
                        {
                            max = matrix[i, j];
                            t = true;
                        } else if (matrix[i,j] > max)
                        {
                            max = matrix[i, j];
                        }
                    }
                }
                if (t)
                {
                    result[j] = max;
                } else
                {
                    result[j] = 0;
                }
            }
            return result;
        }

        public int[,] DefineSeq(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) < 2 || matrix.GetLength(1) < 2)
            {
                return new int[0, 0];
            }
            int n = matrix.GetLength(1);
            bool ravni = true;
            for (int i = 1; i < n; i++)
            {
                if (matrix[0, i] != matrix[0, 0] || matrix[1, i] != matrix[1, 0])
                {
                    ravni = false;
                }
            }
            if (ravni)
            {
                return new int[0,0];
            }

            bool rastet = true;
            bool ubivaet = true;
            for (int i = 1; i < n; i++)
            {
                if (matrix[1, i] < matrix[1, i - 1])
                {
                    rastet = false;
                }
                if (matrix[1, i] > matrix[1, i - 1])
                {
                    ubivaet = false;
                }
            }
            int result = 0;
            if (rastet)
            {
                result = 1;
            } else if (ubivaet)
            {
                result = -1;
            }
            return new int[1,1] { { result } };
        }

        public int[,] FindAllSeq(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength (0) < 2 || matrix.GetLength(1) < 2)
            {
                return new int[0, 0];
            }
            int n = matrix.GetLength(1);
            bool a = true;
            for (int i = 1; i < n; i++)
            {
                if (matrix[0, i] != matrix[0, 0] || matrix[1, i] != matrix[1, 0])
                {
                    a = false;
                }
            }
            if (a)
            {
                return new int[0, 2];
            }
            int[,] inters = new int[n, 2];
            int cnt = 0;
            int s = 0;
            int d = 0;
            int c = 0;
            for (int i = 1; i < n; i++)
            {
                int temp = 0;
                if (matrix[1, i] > matrix[1, i - 1])
                {
                    temp = 1;
                } else if (matrix[1,i] < matrix[1, i - 1])
                {
                    temp = -1;
                } else
                {
                    temp = c;
                }
                if (c == 0)
                {
                    c = temp;
                    s = i - 1;
                } else if (temp != c && temp != 0)
                {
                    inters[cnt, 0] = matrix[0, s];
                    inters[cnt, 1] = matrix[0, i - 1];
                    cnt++;

                    c = temp;
                    s = i - 1;
                }
                if ( i == n - 1)
                {
                    if ( c != 0)
                    {
                        inters[cnt, 0] = matrix[0, s];
                        inters[cnt, 1] = matrix[0, i];
                        cnt++;
                    }
                }
            }
            int[,] result = new int[cnt, 2];
            for (int i = 0; i < cnt; i++)
            {
                result[i, 0] = inters[i, 0];
                result[i, 1] = inters[i, 1];
            }
            for (int i = 0; i < cnt - 1; i++)
            {
                for (int j = 0; j < cnt - 1 - i; j++)
                {
                    if (result[j, 0] > result[j + 1, 0] || (result[j, 0] == result[j + 1, 0] && result[j, 1] > result[j + 1, 1]))
                    {
                        int t_s = result[j, 0];
                        int t_e = result[j, 1];
                        result[j, 0] = result[j + 1, 0];
                        result[j, 1] = result[j + 1, 1];
                        result[j + 1, 0] = t_s;
                        result[j + 1, 1] = t_e;
                    }
                }
            }
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write($"{result[i, j]} ");
                }
                Console.WriteLine();
            }
            return result;

        }

        public int[,] FindLongestSeq(int[,] matrix)
        {
            int[,] inters = FindAllSeq(matrix);
            if (inters.GetLength(0) == 0)
            {
                return new int[0, 0];
            }
            int ind = 0;
            int max_len = 0;
            for (int i = 0; i < inters.GetLength(0); i++)
            {
                int len = Math.Abs(inters[i, 1] - inters[i, 0]);
                if (len > max_len)
                {
                    max_len = len;
                    ind = i;
                }
            }
            int[,] result = new int[1, 2];
            result[0, 0] = inters[ind, 0];
            result[0, 1] = inters[ind, 1];
            return result;
        }

        public int CountSignFlips(double a, double b, double h, Func<double, double> func)
        {
            if (func == null || h <= 0 || a > b)
            {
                return 0;
            }
            int c = 0;
            double last = -2;

            for (double x = a; x <= b + 0.000000001; x += h)
            {
                double y = func(x);
                double s = -2;
                if (Math.Abs(y) < 0.000000001) // типо 0
                {
                    s = 0; 
                } else if (y > 0)
                {
                    s = 1;
                } else
                {
                    s = -1;
                }
                if (last != -2 && s != -2)
                {
                    if (last != 0 && s != 0 && last != s)
                    {
                        c++;
                    }
                }
                if (s != -2 && s != 0)
                {
                    last = s;
                }
            }
            return c;
        }

        public double FuncA(double x)
        {
            return x * x - Math.Sin(x);
        }

        public double FuncB(double x)
        {
            return Math.Exp(x) - 1;
        }

        public void SortInCheckersOrder(int[][] array)
        {
            if (array == null)
            {
                return;
            }
            for ( int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    continue;
                }
                if (i % 2 == 0)
                {
                    for (int j = 0; j < array[i].Length - 1; j++)
                    {
                        for (int k = 0; k < array[i].Length - 1 -j; k++)
                        {
                            if (array[i][k] > array[i][k + 1])
                            {
                                int temp = array[i][k];
                                array[i][k] = array[i][k + 1];
                                array[i][k + 1] = temp;
                            }
                        }
                    }
                } else
                {
                    for (int j = 0; j < array[i].Length - 1; j++)
                    {
                        for (int k = 0; k < array[i].Length - 1 - j; k++)
                        {
                            if (array[i][k] < array[i][k + 1])
                            {
                                int temp = array[i][k];
                                array[i][k] = array[i][k + 1];
                                array[i][k + 1] = temp;
                            } 
                        }
                    }
                }
            }
        }

        public void SortBySumDesc(int[][] array)
        {
            if (array == null)
            {
                return;
            }
            int[] sums = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    int sum = 0;
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        sum += array[i][j];
                    }
                    sums[i] = sum;
                } else
                {
                    sums[i] = 0;
                }
            }
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (sums[j] < sums[j + 1])
                    {
                        int[] temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        int t = sums[j];
                        sums[j] = sums[j + 1];
                        sums[j + 1] = t;
                    }
                }
            }
        }

        public void TotalReverse(int[][] array)
        {
            if (array == null)
            {
                return;
            }
            for (int i = 0; i <array.Length; i++)
            {
                if (array[i] != null)
                {
                    for (int j = 0; j < array[i].Length / 2; j++)
                    {
                        int temp = array[i][j];
                        array[i][j] = array[i][array[i].Length - 1 - j];
                        array[i][array[i].Length - 1 - j] = temp;
                    }
                }
            }
            for ( int i = 0; i < array.Length / 2; i++)
            {
                int[] temp = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = temp;
            }
        }

        public void Task2(ref int[,] A, int[,] B)
        {

            // code here
            int max_r = 0;
            int r = -1;
            int max_c = 0;
            int c = -1;

            for (int i = 0; i < A.GetLength(0); i++)
            {
                int cnt = CountPositiveElementsInRow(A, i);
                if (cnt > max_r)
                {
                    max_r = cnt;
                    r = i;
                }
            }
            for (int j = 0; j < B.GetLength(1); j++)
            {
                int cnt = CountPositiveElementsInColumn(B, j);
                if (cnt > max_c)
                {
                    max_c = cnt;
                    c = j;
                }
            }
            if (r == -1 || max_c == 0)
            {
                return;
            }

            InsertColumn(ref A, r, c, B);
            // end

        }
        public void Task3(int[,] matrix)
        {

            // code here
            if (matrix == null)
            {
                return;
            }
            ChangeMatrixValues(matrix);
            // end

        }
        public void Task4(int[,] A, int[,] B)
        {

            // code here
            if (A == null || B == null)
            {
                return;
            }
            int[] otrA = CountNegativesPerRow(A);
            int[] otrB = CountNegativesPerRow(B);

            int maxA = FindMaxIndex(otrA);
            int maxB = FindMaxIndex(otrB);

            if (otrA[maxA] == 0 || otrB[maxB] == 0)
            {
                return;
            }
            if (A.GetLength(1) != B.GetLength(1))
            {
                return;
            }
            int m = A.GetLength(1);
            for (int j = 0; j < m; j++)
            {
                int temp = A[maxA, j];
                A[maxA, j] = B[maxB, j];
                B[maxB, j] = temp;
            }
            // end

        }

        public delegate void Sorting(int[] array);
        public void Task5(int[] array, Sorting sort)
        {

            // code here
            if (array == null || sort == null)
            {
                return;
            }
            sort(array);
            // end

        }

        public delegate void SortRowsByMax(int[,] matrix);

        public void Task6(int[,] matrix, SortRowsByMax sort)
        {

            // code here
            if (matrix == null || sort == null)
            {
                return;
            }
            sort(matrix);
            // end

        }
        public delegate int[] FindNegatives(int[,] matrix);

        public int[] Task7(int[,] matrix, FindNegatives find)
        {
            int[] negatives = null;

            // code here
            if (matrix == null || find == null)
            {
                return negatives;
            }
            negatives = find(matrix);
            // end

            return negatives;
        }

        public delegate int[,] MathInfo(int[,] matrix);

        public int[,] Task8(int[,] matrix, MathInfo info)
        {
            int[,] answer = null;

            // code here
            if (matrix == null || info == null)
            {
                return answer;
            }
            answer = info(matrix);
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
            if (array == null || func == null)
            {
                return;
            }
            func(array);
            // end

        }
    }
}