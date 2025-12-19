
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
            if (array.Length == 0) return;
            int mi = 0;
            int mx = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > mx)
                {
                    mx = array[i];
                    mi = i;
                }
            }
            int[] array1 = new int[array.Length - 1];
            for (int i = 0; i < mi; i++)
                array1[i] = array[i];
            for (int i = mi + 1; i < array.Length; i++)
                array1[i - 1] = array[i];
            array = array1;
        }

        public int[] CombineArrays(int[] A, int[] B)
        {
            int ind = 0;
            int[] combined = new int[A.Length + B.Length];
            for (int i = 0; i < combined.Length; i++)
            {
                if (i < A.Length) combined[i] = A[i];
                else
                {
                    combined[i] = B[ind];
                    ind++;
                }
            }
            return combined;
        }
        public void Task2(int[,] matrix, int[] array)
        {

            // code here
            if (array.Length == 0) return;
            if (matrix.GetLength(0) != array.Length) return;
            for (int i = 0; i < array.Length; i++)
            {
                int maxx = FindMaxInRow(matrix, i, out int col);
                if (maxx < array[i]) matrix[i, col] = array[i];
            }
            // end

        }
        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            col = 0;
            int maxx = matrix[row, 0];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > maxx)
                {
                    maxx = matrix[row, j];
                    col = j;
                }
            }
            return maxx;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            FindMax(matrix, out int row, out int col);
            SwapColWithDiagonal(matrix, col);
            // end

        }

        public void FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int mx = matrix[0, 0];
            int mi = 0;
            int mj = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        mi = i;
                        mj = j;
                    }
                }
            }
            row = mi;
            col = mj;
        }

        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m)
            {
                return;
            }
            for (int i = 0; i < n; i++)
            {
                (matrix[i, i], matrix[i, col]) = (matrix[i, col], matrix[i, i]);
            }
        }

        public void Task4(ref int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        RemoveRow(ref matrix, i);
                        i--;
                        break;
                    }
                }
            }
            // end

        }

        public void RemoveRow(ref int[,] matrix, int row)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] New = new int[n - 1, m];
            int r = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == row) continue;
                for (int j = 0; j < m; j++)
                {
                    New[r, j] = matrix[i, j];
                }
                r++;
            }
            matrix = New;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            answer = GetRowsMinElements(matrix);
            // end

            return answer;
        }

        public int[] GetRowsMinElements(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m) return null;
            int[] answer = new int[n];
            for (int i = 0; i < n; i++)
            {
                int minn = matrix[i, i];
                for (int j = i; j < n; j++)
                {
                    if (matrix[i, j] < minn) minn = matrix[i, j];
                }
                answer[i] = minn;
            }
            return answer;
        }

        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;

            // code here
            int[] array = SumPositiveElementsInColumns(A);
            int[] array1 = SumPositiveElementsInColumns(B);
            answer = CombineArrays(array, array1);
            // end

            return answer;
        }
        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] answer = new int[m];
            for (int j = 0; j < m; j++)
            {
                int s = 0;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] > 0) s += matrix[i, j];

                }
                answer[j] = s;
            }
            return answer;
        }
        public delegate void Sorting(int[,] matrix);
        public void Task7(int[,] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // end

        }

        public void SortEndAscending(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int mx = matrix[i, 0];
                int mi = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        mi = j;
                    }
                }
                if (mi == m - 1) continue;
                for (int k = mi + 1; k < m - 1; k++)
                {
                    for (int j = mi + 1; j < m - 1; j++)
                    {
                        if (matrix[i, j] > matrix[i, j + 1]) (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);

                    }
                }
            }
        }
        public void SortEndDescending(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int mx = matrix[i, 0];
                int mi = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        mi = j;
                    }
                }
                if (mi == m - 1) continue;
                for (int k = mi + 1; k < m - 1; k++)
                {
                    for (int j = mi + 1; j < m - 1; j++)
                    {
                        if (matrix[i, j] < matrix[i, j + 1]) (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);

                    }
                }
            }
        }
        public int Task8(double[] A, double[] B)
        {
            int answer = 0;

            // code here
            double areaA = GeronArea(A[0], A[1], A[2]);
            double areaB = GeronArea(B[0], B[1], B[2]);
            if (areaA > areaB) return 1;
            else return 2;
            // end

            return answer;
        }

        public double GeronArea(double a, double b, double c)
        {
            double area = 0;
            if (a + b < c || a + c < b || b + c < a)
            {
                return 0;
            }
            double p = (a + b + c) / 2;
            area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return area;
        }
        public void Task9(int[,] matrix, Action<int[]> sorter)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0) SortMatrixRow(matrix, i, sorter);

            }
            // end

        }

        public void SortMatrixRow(int[,] matrix, int row, Action<int[]> sorter)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] array = new int[m];
            for (int j = 0; j < m; j++)
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
            double r = 0;

            // code here
            r = func(array);
            // end

            return r;
        }

        public double CountZeroSum(int[][] array)
        {
            double count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }
                if (sum == 0) count++;
            }
            return count;
        }
        public double FindMedian(int[][] array)
        {
            int len = 0;
            for (int i = 0; i < array.Length; i++)
            {
                len += array[i].Length;
            }

            int[] array1 = new int[len];
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    array1[k] = array[i][j];
                    k++;
                }
            }
            Array.Sort(array1);
            double m;
            if (array1.Length % 2 == 0)
            {
                m = (double)(array1[len / 2 - 1] + array1[len / 2]) / 2;
            }
            else
            {
                m = (double)array1[len / 2];
            }
            return m;
        }

        public double CountLargeElements(int[][] array)
        {
            double c = 0;
            double a;
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
