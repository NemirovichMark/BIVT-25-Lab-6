using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class Green
    {
        public void Task1(ref int[] A, ref int[] B)
        {

            // code here
            DeleteMaxElement(ref A);
            DeleteMaxElement(ref B);
            A = CombineArrays(A, B);
            // end

        }
        public void DeleteMaxElement(ref int[] array)
        {
            int ix = 0;
            int mx = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > mx)
                {
                    mx = array[i];
                    ix = i;
                }
            }
            int[] arr = new int[array.Length - 1];
            for (int i = 0; i < arr.Length; i++)
            {
                if (i < ix) arr[i] = array[i];
                else arr[i] = array[i + 1];
            }
            array = arr;
        }
        public int[] CombineArrays(int[] A, int[] B)
        {
            int[] AB = new int[A.Length + B.Length];
            int j = 0;
            for (int i = 0; i < A.Length; i++)
            {
                AB[i] = A[i];
            }
            for (int i = A.Length; i < AB.Length; i++)
            {
                AB[i] = B[j++];
            }
            return AB;
        }

        public void Task2(int[,] matrix, int[] array)
        {

            // code here
            if (array == null) return;
            if (matrix == null) return;
            if (array.Length != matrix.GetLength(0)) return;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int j;
                int m = FindMaxInRow(matrix, i, out j);
                if (m < array[i])
                {
                    matrix[i, j] = array[i];
                }
            }
            // end
        }

        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            col = 0;
            int mx = int.MinValue;
            int len = matrix.GetLength(1);
            for (int j = 0; j < len; j++)
            {
                if (matrix[row, j] > mx)
                {
                    mx = matrix[row, j];
                    col = j;
                }
            }
            return mx;
        }

        public void Task3(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            int r, cl;
            FindMax(matrix, out r, out cl);
            SwapColWithDiagonal(matrix, cl);
            // end

        }
        public void FindMax(int[,] matrix, out int row, out int col)
        {
            col = 0;
            row = 0;
            int mx = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
        }
        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            for (int k = 0; k < matrix.GetLength(0); k++)
            {
                int temp = matrix[k, k];
                matrix[k, k] = matrix[k, col];
                matrix[k, col] = temp;
            }
        }

        public void Task4(ref int[,] matrix)
        {

            // code here
            if (matrix == null) return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bool zero = false;
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[i, c] == 0)
                    {
                        zero = true;
                        break;
                    }
                }

                if (zero) RemoveRow(ref matrix, i--);
            }
            // end

        }
        public void RemoveRow(ref int[,] matrix, int row)
        {
            int[,] temp = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            int leni = matrix.GetLength(0);
            int lenj = matrix.GetLength(1);
            for (int i = 0, k = 0; i < leni; i++)
            {
                if (i == row) continue;
                for (int j = 0; j < lenj; j++)
                {
                    temp[k, j] = matrix[i, j];
                }
                k++;
            }
            matrix = temp;
        }

        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return null;
            if (matrix == null) return null;
            answer = GetRowsMinElements(matrix);
            // end

            return answer;
        }
        public int[] GetRowsMinElements(int[,] matrix)
        {
            int[] arr = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int mn = int.MaxValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j >= i)
                    {
                        if (matrix[i, j] < mn) mn = matrix[i, j];
                    }
                }
                arr[i] = mn;
            }
            return arr;
        }
        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;

            // code here
            int[] a = SumPositiveElementsInColumns(A);
            int[] b = SumPositiveElementsInColumns(B);
            answer = CombineArrays(a, b);
            // end

            return answer;
        }
        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            int[] tl = new int[matrix.GetLength(1)];

            int cl = matrix.GetLength(1);
            for (int c = 0; c < cl; c++)
            {
                int ac = 0;
                int ct = matrix.GetLength(0);

                for (int r = 0; r < ct; r++)
                {
                    if (matrix[r, c] > 0)
                        ac += matrix[r, c];
                }
                tl[c] = ac;
            }
            return tl;
        }


        public void Task7(int[,] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // end

        }

        public delegate void Sorting(int[,] matrix);

        public void SortEndAscending(int[,] matrix)
        {
            int rw = matrix.GetLength(0);
            int cl = matrix.GetLength(1);
            for (int i = 0; i < rw; i++)
            {
                int ps = 0, vl = matrix[i, 0];
                for (int c = 1; c < cl; c++)
                {
                    if (matrix[i, c] > vl)
                    {
                        ps = c;
                        vl = matrix[i, c];
                    }
                }
                for (int p = ps + 1; p < cl; p++)
                {
                    for (int q = ps + 1; q < cl - p + ps; q++)
                    {
                        if (matrix[i, q] > matrix[i, q + 1]) (matrix[i, q], matrix[i, q + 1]) = (matrix[i, q + 1], matrix[i, q]);
                    }
                }
            }
        }

        public void SortEndDescending(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int mx = matrix[i, 0];
                int pos = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        pos = j;
                    }
                }
                if (pos == matrix.GetLength(1) - 1) continue;

                for (int k = pos + 1; k < matrix.GetLength(1) - 1; k++)
                {
                    for (int l = pos + 1; l < matrix.GetLength(1) - 1; l++)
                    {
                        if (matrix[i, l] < matrix[i, l + 1])
                            (matrix[i, l], matrix[i, l + 1]) = (matrix[i, l + 1], matrix[i, l]);
                    }
                }
            }
        }

        public int Task8(double[] A, double[] B)
        {
            int answer = 0;

            // code here
            double a = GeronArea(A[0], A[1], A[2]);
            double b = GeronArea(B[0], B[1], B[2]);
            if (a > b) answer = 1;
            else answer = 2;
            // end

            return answer;
        }
        public double GeronArea(double a, double b, double c)
        {
            if (a + b <= c || b + c < a || a + c <= b) return 0;
            double p = (a + b + c) / 2;
            double ans = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            return ans;
        }
        public void Task9(int[,] matrix, Action<int[]> sorter)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    SortMatrixRow(matrix, i, sorter);
                }
            }
            // end

        }
        public void SortMatrixRow(int[,] matrix, int row, Action<int[]> sorter)
        {
            int[] array = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                array[j] = matrix[row, j];
            }
            sorter(array);
            ReplaceRow(matrix, row, array);
        }
        public void ReplaceRow(int[,] matrix, int row, int[] array)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[row, j] = array[j];
            }
            ;
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

            // code here
            if (array == null) return 0;
            res = func(array);
            // end

            return res;
        }
        public double FindMedian(int[][] array)
        {
            double median;
            int len = 0;
            for (int i = 0; i < array.Length; i++)
            {
                len += array[i].Length;
            }

            int[] arr = new int[len];
            for (int i = 0, k = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    arr[k++] = array[i][j];
                }
            }
            SortAscending(arr);
            if (arr.Length % 2 == 0)
            {
                median = (double)(arr[len / 2 - 1] + arr[len / 2]) / 2;
            }
            else median = arr[len / 2];
            return median;
        }

        public double CountZeroSum(int[][] array)
        {
            double c = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double s = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    s += array[i][j];
                }
                if (s == 0)
                {
                    c++;
                }
            }
            return c;
        }
        public double CountLargeElements(int[][] array)
        {
            double c = 0;
            double a = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double s = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    s += array[i][j];
                }
                a = s / array[i].Length;
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > a)
                    {
                        c++;
                    }
                }
            }
            return c;
        }
    }
}
