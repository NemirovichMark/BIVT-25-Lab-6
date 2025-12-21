using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

namespace Lab6
{
    public class Green
    {
        public void Task1(ref int[] A, ref int[] B)
        {
            DeleteMaxElement(ref A);
            DeleteMaxElement(ref B);

            A = CombineArrays(A, B);
        }
        public void DeleteMaxElement(ref int[] array)
        {
            int max = int.MinValue;
            int imax = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    imax = i;
                }
            }
            int[] help = new int[array.Length - 1];
            for (int i = 0; i < array.Length; i++)
            {
                if (i < imax) help[i] = array[i];
                if (i > imax) help[i - 1] = array[i];
            }

            array = help;
        }
        public int[] CombineArrays(int[] A, int[] B)
        {
            int[] res = new int[A.Length + B.Length];
            for (int i = 0; i < A.Length; i++)
            {
                res[i] = A[i];
            }
            int j = A.Length;
            for (int i = 0; i < B.Length; i++)
            {
                res[j + i] = B[i];
                //j++;
            }
            return res;
        }

        public void Task2(int[,] matrix, int[] array)
        {
            if (array.Length == 0) return;
            if (matrix.GetLength(0) != array.Length) return;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int col;
                int max = FindMaxInRow(matrix, row, out col);

                if (max < array[row])
                {
                    matrix[row, col] = array[row];
                }
            }
        }
        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            int max = int.MinValue;
            col = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > max)
                {
                    max = matrix[row, j];
                    col = j;
                }
            }
            return max;
        }
        public void Task3(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            int row, col;
            FindMax(matrix, out row, out col);
            SwapColWithDiagonal(matrix, col);

        }
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            int max = int.MinValue;
            col = 0;
            row = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            return max;
        }
        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int help = matrix[i, i];
                matrix[i, i] = matrix[i, col];
                matrix[i, col] = help;
            }
        }
        public void Task4(ref int[,] matrix)
        {
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                bool f = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0) { f = true; break; }
                }
                if (f) RemoveRow(ref matrix, i);

            }

        }
        public void RemoveRow(ref int[,] matrix, int row)
        {
            int[,] help = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            int k = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i != row)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        help[k, j] = matrix[i, j];
                    }
                    k++;
                }
            }
            matrix = help;

        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return null;
            // code here

            // end
            answer = GetRowsMinElements(matrix);
            return answer;
        }
        public int[] GetRowsMinElements(int[,] matrix)
        {

            int[] help = new int[matrix.GetLength(0)];
            int k = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = int.MaxValue;
                for (int j = i; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
                help[i] = min;

            }
            return help;
        }
        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;
            int[] a = SumPositiveElementsInColumns(A);
            int[] b = SumPositiveElementsInColumns(B);

            answer = CombineArrays(a, b);
            // code here

            // end

            return answer;
        }
        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            int cnt = 0;
            int[] a = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int sum = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > 0) sum += matrix[i, j];
                }
                a[j] = sum;
            }
            return a;
        }
        public int[] CombineArrays(int[] A, int[] B)
        {
            int[] res = new int[A.Length + B.Length];
            for (int i = 0; i < A.Length; i++)
            {
                res[i] = A[i];
            }
            int k = A.Length;
            for (int j = 0; j < B.Length; j++)
            {
                res[k + j] = B[j];
            }
            return res;
        }
        public void Task7(int[,] matrix, Sorting sort)
        {

            // code here
            if (matrix == null) return;
            sort(matrix);
            // end

        }
        public delegate void Sorting(int[,] matrix);
        public void SortEndAscending(int[,] matrix)
        {
            if (matrix == null) return;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = int.MinValue;
                int imax = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        imax = j;
                    }
                }
                if (imax == matrix.GetLength(1) - 1) continue;
                for (int k = 0; k < matrix.GetLength(1) - 1; k++)
                {
                    for (int l = imax + 1; l < matrix.GetLength(1) - k - 1; l++)
                    {
                        if (matrix[i, l] > matrix[i, l + 1])
                        {
                            (matrix[i, l], matrix[i, l + 1]) = (matrix[i, l + 1], matrix[i, l]);
                        }
                    }
                }
            }
        }

        public void SortEndDescending(int[,] matrix)
        {
            if (matrix == null) return;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = int.MinValue;
                int imax = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        imax = j;
                    }
                }
                if (imax == matrix.GetLength(1) - 1) continue;
                for (int k = 0; k < matrix.GetLength(1) - 1; k++)
                {
                    for (int l = imax + 1; l < matrix.GetLength(1) - k - 1; l++)
                    {
                        if (matrix[i, l] < matrix[i, l + 1])
                        {
                            (matrix[i, l], matrix[i, l + 1]) = (matrix[i, l + 1], matrix[i, l]);
                        }
                    }
                }
            }
        }
        public int Task8(double[] A, double[] B)
        {
            int answer = 0;
            double t1 = GeronArea(A[0], A[1], A[2]);
            double t2 = GeronArea(B[0], B[1], B[2]);
            if (t1 == 0 || t2 == 0) answer = 0;

            if (t1 > t2)
            {
                answer = 1;
            }
            else
            {
                answer = 2;
            }
            // code here

            // end

            return answer;
        }
        public double GeronArea(double a, double b, double c)
        {
            double s = 0;
            if (a + b > c && a + c > b && b + c > a)
            {
                double p = (a + b + c) / 2;
                double help = p * (p - a) * (p - b) * (p - c);
                s = Math.Pow(help, 0.5);
            }
            return s;
        }
        public void Task9(int[,] matrix, Action<int[]> sorter)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    SortMatrixRow(matrix, i, sorter);
                }
            }
            // code here

            // end

        }
        public void SortMatrixRow(int[,] matrix, int row, Action<int[]> sorter)
        {
            int[] help = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                help[j] = matrix[row, j];
            }
            sorter(help);
            ReplaceRow(matrix, row, help);
        }
        public void ReplaceRow(int[,] matrix, int row, int[] array)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[row, j] = array[j];
            }
        }
        public void SortAscending(int[] array)
        {
            Array.Sort(array);
        }
        public void SortDescending(int[] array)
        {
            Array.Sort(array);
            Array.Reverse(array);
        }
        public double Task10(int[][] array, Func<int[][], double> func)
        {
            double res = 0;

            if (array == null || func == null) return 0;
            // code here

            // end
            res = func(array);
            return res;
        }
        public double CountZeroSum(int[][] array)
        {
            double cnt = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double sum = 0; 
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }
                if (sum == 0)
                {
                    cnt++;
                }
            }
            return cnt;
        }
        public double FindMedian(int[][] array)
        {
            int l = 0;
            for (int i = 0; i < array.Length; i++)
            {
                l += array[i].Length;
            }
            int[] help = new int[l];
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    help[k] = array[i][j];
                    k++;
                }
            }
            Array.Sort(help);
            double ans = 0;
            if (help.Length % 2 == 0)
            {
                ans = (help[l / 2] + help[l / 2 - 1]) / 2.0;
            }
            else
            {
                ans = help[l / 2];
            }
            return ans;
        }
        public double CountLargeElements(int[][] array)
        {
            double m = 0;
            double cnt = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }
                m = sum / array[i].Length;
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > m)
                    {
                        cnt++;
                    }
                }
            }
            return cnt;
        }
    }
}
