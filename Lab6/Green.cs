using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class Green
    {
        public void DeleteMaxElement(ref int[] arr)
        {
            if (arr == null || arr.Length == 0) { return; }
            int idx = 0;
            int mx = arr[idx];
            for (int k = 0; k < arr.Length; k++)
            {
                if (arr[k] > mx) { mx = arr[k]; idx = k; }
            }
            int[] na = new int[arr.Length - 1];
            for (int k = 0; k < idx; k++) { na[k] = arr[k]; }
            for (int k = idx + 1; k < arr.Length; k++) { na[k - 1] = arr[k]; }
            arr = na;
        }

        public int[] CombineArrays(int[] a1, int[] a2)
        {
            if (a1 == null) { a1 = new int[0]; }
            if (a2 == null) { a2 = new int[0]; }
            int[] c = new int[a1.Length + a2.Length];
            for (int k = 0; k < a1.Length; k++) { c[k] = a1[k]; }
            for (int k = 0; k < a2.Length; k++) { c[a1.Length + k] = a2[k]; }
            return c;
        }

        public void Task1(ref int[] A, ref int[] B)
        {
            // code here
            DeleteMaxElement(ref A);
            DeleteMaxElement(ref B);
            A = CombineArrays(A, B);
            // end
        }

        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            col = 0;
            int max = matrix[row, 0];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] > max)
                {
                    max = matrix[row, i];
                    col = i;
                }
            }
            return max;
        }

        public void Task2(int[,] matrix, int[] array)
        {

            // code here
            if (array.Length == 0)
                return;
            if (array.Length != matrix.GetLength(0))
                return;
            for (int i = 0; i < array.Length; i++)
            {
                int max = FindMaxInRow(matrix, i, out int col);
                if (max < array[i])
                {
                    matrix[i, col] = array[i];
                }
            }
            // end

        }

        public void FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            int max = matrix[0, 0];
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

        }
        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                (matrix[i, i], matrix[i, col]) = (matrix[i, col], matrix[i, i]);
            }
        }
        public void Task3(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;
            FindMax(matrix, out int row, out int col);
            SwapColWithDiagonal(matrix, col);
            // end

        }

        public void RemoveRow(ref int[,] matrix, int row)
        {
            int[,] matrix0 = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == row)
                    continue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix0[count, j] = matrix[i, j];
                }
                count++;
            }
            matrix = matrix0;
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
        public int[] GetRowsMinElements(int[,] m)
        {
            if (m == null || m.GetLength(0) != m.GetLength(1)) { return null; }
            int[] mins = new int[m.GetLength(0)];
            for (int k = 0; k < m.GetLength(0); k++)
            {
                int mn = m[k, k];
                for (int j = k; j < m.GetLength(1); j++)
                {
                    if (m[k, j] < mn) { mn = m[k, j]; }
                }
                mins[k] = mn;
            }
            return mins;
        }
        public int[] Task5(int[,] matrix)
        {
            // code here
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1)) { return null; }
            return GetRowsMinElements(matrix);
            // end
        }
        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int sum = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] > 0)
                    {
                        sum += matrix[j, i];
                    }
                }
                array[i] = sum;
            }
            return array;
        }
        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;

            // code here
            int[] array1 = SumPositiveElementsInColumns(A);
            int[] array2 = SumPositiveElementsInColumns(B);
            answer = CombineArrays(array1, array2);
            // end

            return answer;
        }

        public void SortEndAscending(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = matrix[i, 0];
                int jmax = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        jmax = j;
                    }
                }
                if (jmax == matrix.GetLength(1) - 1)
                    continue;
                for (int j1 = jmax + 1; j1 < matrix.GetLength(1) - 1; j1++)
                {
                    for (int j = jmax + 1; j < matrix.GetLength(1) - 1; j++)
                    {
                        if (matrix[i, j] > matrix[i, j + 1])
                        {
                            (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                        }
                    }
                }
            }
        }
        public void SortEndDescending(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = matrix[i, 0];
                int jmax = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        jmax = j;
                    }
                }
                if (jmax == matrix.GetLength(1) - 1)
                    continue;
                for (int j1 = jmax + 1; j1 < matrix.GetLength(1) - 1; j1++)
                {
                    for (int j = jmax + 1; j < matrix.GetLength(1) - 1; j++)
                    {
                        if (matrix[i, j] < matrix[i, j + 1])
                        {
                            (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                        }
                    }
                }
            }
        }
        public delegate void Sorting(int[,] matrix);
        public void Task7(int[,] matrix, Sorting sort)
        {

            // code here
            sort(matrix);
            // end

        }
        public double GeronArea(double x, double y, double z)
        {
            if (x <= 0 || y <= 0 || z <= 0) { return 0; }
            if (x + y <= z || x + z <= y || y + z <= x) { return 0; }
            double p = (x + y + z) / 2;
            return Math.Sqrt(p * (p - x) * (p - y) * (p - z));
        }
        public int Task8(double[] A, double[] B)
        {
            // code here
            double aa = GeronArea(A[0], A[1], A[2]);
            double ab = GeronArea(B[0], B[1], B[2]);
            if (aa > ab) { return 1; }
            return 2;
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
                if (sum == 0)
                {
                    count++;
                }
            }
            return count;
        }
        public double FindMedian(int[][] array)
        {
            int length = 0;
            for (int i = 0; i < array.Length; i++)
            {
                length += array[i].Length;
            }
            int[] array0 = new int[length];
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    array0[count++] = array[i][j];
                }
            }
            Array.Sort(array0);
            double median = 0;
            if (array0.Length % 2 == 0)
            {
                median = (double)(array0[length / 2 - 1] + array0[length / 2]) / 2;
            }
            else
            {
                median = (double)array0[length / 2];
            }
            return median;
        }
        public double CountLargeElements(int[][] array)
        {
            double count = 0;
            double srznach = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }
                srznach = sum / array[i].Length;
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > srznach)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public double Task10(int[][] array, Func<int[][], double> func)
        {
            double res = 0;

            // code here
            res = func(array);
            // end

            return res;
        }
    }
}