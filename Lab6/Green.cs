using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
            public delegate void Sorting(int[] row);

    public class Green
    {

        public void Task1(ref int[] A, ref int[] B)
        {

            // code here
            if (A == null || B == null) { A = null; B = null; return; }
            DeleteMaxElement(ref A);
            DeleteMaxElement(ref B);
            A = CombineArrays(A, B);
            // end

        }
        public void Task2(int[,] matrix, int[] array)
        {

            // code here
            if (array.Length == 0 || matrix.GetLength(0) != array.Length) return;
            for (int i = 0; i < array.Length; i++)
            {
                int maxvalue = FindMaxInRow(matrix, i, out int maxcol);
                if (maxvalue < array[i])
                {
                    matrix[i, maxcol] = array[i];
                }
            }
            // end

        }
        public void Task3(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m) return;
            int row, col;
            FindMax(matrix, out row, out col);
            SwapColWithDiagonal(matrix, col);
            // end

        }
        public void Task4(ref int[,] matrix)
        {

            // code here
            if (matrix == null) { matrix = null; return; }
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            bool[] keep = new bool[rows];
            int k = 0;
            for (int i = 0; i < rows; i++)
            {
                bool hasZero = false;
                for (int j = 0; j < cols; j++) { if (matrix[i, j] == 0) { hasZero = true; break; } }
                keep[i] = !hasZero;
                if (keep[i]) k++;
            }
            int[,] res = new int[k, cols];
            int r = 0;
            for (int i = 0; i < rows; i++)
            {
                if (!keep[i]) continue;
                for (int j = 0; j < cols; j++) res[r, j] = matrix[i, j];
                r++;
            }
            matrix = res;
            // end

        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix == null) return null;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols) return null;
            int[] rez = new int[n];
            for (int i = 0; i < n; i++)
            {
                int min = matrix[i, i];
                for (int j = i; j < m; j++) if (matrix[i, j] < min) min = matrix[i, j];
                rez[i] = min;
            }
            answer = rez;
            // end

            return answer;
        }
        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;

            // code here
            int[] arr1 = SumPositiveElementsInColumns(A);
            int[] arr2 = SumPositiveElementsInColumns(B);
            answer = CombineArrays(arr1, arr2);
            // end

            return answer;
        }
        public void Task7(int[,] matrix, Sorting sort)
        {

            // code here
            if (matrix == null || sort == null) return;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int[] rowArr = new int[cols];
                for (int j = 0; j < cols; j++) rowArr[j] = matrix[i, j];
                sort(rowArr);
                for (int j = 0; j < cols; j++) matrix[i, j] = rowArr[j];
            }
            // end

        }
        public int Task8(double[] A, double[] B)
                    {
                        int answer = 0;
                    
                        // code here
                        if (A == null || B == null || A.Length != 3 || B.Length != 3) return 0;
                        double a1 = GeronArea(A[0], A[1], A[2]);
                        double a2 = GeronArea(B[0], B[1], B[2]);
                        if (a1 == 0 && a2 == 0) return 0;
                        answer = (a1 >= a2) ? 1 : 2;  // tie -> 1
                        // end
                    
                        return answer;
                    }
        public void Task9(int[,] matrix, Action<int[]> sorter)
        {

            // code here
            if (matrix == null || sorter == null) return;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i += 2)
            {
                int[] row = new int[cols];
                for (int j = 0; j < cols; j++) row[j] = matrix[i, j];
                sorter(row);
                ReplaceRow(matrix, i, row);
            }
            // end

        }
        public double Task10(int[][] array, Func<int[][], double> func)
        {
            double res = 0;

            // code here
            if (array == null || func == null) return 0;
            res = func(array);
            // end

            return res;
        }

        public void DeleteMaxElement(ref int[] array)
        {
            if (array.Length == 0) return;

            int max = array[0];
            int ind = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    ind = i;
                }
            }
            int[] newarr = new int[array.Length - 1];
            for (int i = 0; i < newarr.Length; i++)
            {
                if (i < indmax)
                {
                    newarr[i] = array[i];
                }
                else
                {
                    newarr[i] = array[i + 1];
                }
            }
            array = newarr;
        }
        public int[] CombineArrays(int[] A, int[] B)
        {
            int[] rez = new int[A.Length + B.Length];
            for (int i = 0; i < rez.Length; i++)
            {
                if (i < A.Length) rez[i] = A[i];
                else rez[i] = B[i - A.Length];
            }
            return rez;
        }
        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            int cols = matrix.GetLength(1);
            int max = matrix[row, 0];
            col = 0;
            for (int j = 1; j < cols; j++)
            {
                if (matrix[row, j] > max)
                {
                    max = matrix[row, j];
                    col = j;
                }
            }
            return max;
        }
        public void FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0; col = 0;
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            int max = matrix[0, 0];
            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                {
                    int v = matrix[i, j];
                    if (v > max) { max = v; row = i; col = j; }
                }
        }
        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m || col < 0 || col >= m) return;
            for (int i = 0; i < n; i++)
            {
                int tmp = matrix[i, i];
                matrix[i, i] = matrix[i, col];
                matrix[i, col] = tmp;
            }
        }
        public void RemoveRow(ref int[,] matrix, int row)
        {
            if (matrix == null) { matrix = null; return; }
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (row < 0 || row >= n) return;
            int[,] res = new int[n - 1, m];
            int w = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == row) continue;
                for (int j = 0; j < m; j++) res[w, j] = matrix[i, j];
                w++;
            }
            matrix = res;
        }
        public int[] GetRowsMinElements(int[,] matrix)
        {
            if (matrix == null) return null;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m) return null;
            int[] res = new int[n];
            for (int i = 0; i < n; i++)
            {
                int min = matrix[i, i];
                for (int j = i; j < m; j++) if (matrix[i, j] < min) min = matrix[i, j];
                res[i] = min;
            }
            return res;
        }
        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] array = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                int sum = 0;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] > 0) sum += matrix[i, j];
                }
                array[j] = sum;
            }
            return array;
        }
        public void SortEndAscending(int[] row)
        {
            if (row == null || row.Length <= 1) return;
            int max = row[0], idx = 0;
            for (int i = 1; i < row.Length; i++) if (row[i] > max) { max = row[i]; idx = i; }
            if (idx + 1 >= row.Length) return;
            int len = row.Length - (idx + 1);
            int[] tail = new int[len];
            for (int i = 0; i < len; i++) tail[i] = row[idx + 1 + i];
            System.Array.Sort(tail);
            for (int i = 0; i < len; i++) row[idx + 1 + i] = tail[i];
        }
        public void SortEndDescending(int[] row)
        {
            if (row == null || row.Length <= 1) return;
            int max = row[0], idx = 0;
            for (int i = 1; i < row.Length; i++) if (row[i] > max) { max = row[i]; idx = i; }
            if (idx + 1 >= row.Length) return;
            int len = row.Length - (idx + 1);
            int[] tail = new int[len];
            for (int i = 0; i < len; i++) tail[i] = row[idx + 1 + i];
            System.Array.Sort(tail);
            System.Array.Reverse(tail);
            for (int i = 0; i < len; i++) row[idx + 1 + i] = tail[i];
        }
        public double GeronArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0) return 0;
            if (a + b <= c || a + c <= b || b + c <= a) return 0;
            double p = (a + b + c) / 2.0;
            double s2 = p * (p - a) * (p - b) * (p - c);
            return s2 <= 0 ? 0 : System.Math.Sqrt(s2);
        }
        public void ReplaceRow(int[,] matrix, int row, int[] array)
        {
            if (matrix == null || array == null) return;
            int cols = matrix.GetLength(1);
            if (row < 0 || row >= matrix.GetLength(0) || array.Length != cols) return;
            for (int j = 0; j < cols; j++) matrix[row, j] = array[j];
        }
        public void SortAscending(int[] arr)
        {
            if (arr == null) return;
            System.Array.Sort(arr);
        }
        public void SortDescending(int[] arr)
        {
            if (arr == null) return;
            System.Array.Sort(arr);
            System.Array.Reverse(arr);
        }
        public void SortMatrixRow(int[,] matrix, int row, Action<int[]> sorter)
        {
            if (matrix == null || sorter == null) return;
            if (row < 0 || row >= matrix.GetLength(0)) return;
            int cols = matrix.GetLength(1);
            int[] tmp = new int[cols];
            for (int j = 0; j < cols; j++) tmp[j] = matrix[row, j];
            sorter(tmp);
            for (int j = 0; j < cols; j++) matrix[row, j] = tmp[j];
        }
         public double CountZeroSum(int[][] array)
        {
            if (array == null) return 0;
            int cnt = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int[] row = array[i] ?? System.Array.Empty<int>();
                long s = 0;
                for (int j = 0; j < row.Length; j++) s += row[j];
                if (s == 0) cnt++;
            }
            return cnt;
        }
        public double FindMedian(int[][] array)
        {
            if (array == null) return 0;
            int total = 0;
            for (int i = 0; i < array.Length; i++) total += (array[i]?.Length ?? 0);
            if (total == 0) return 0;
            int[] flat = new int[total];
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int[] row = array[i] ?? System.Array.Empty<int>();
                for (int j = 0; j < row.Length; j++) flat[k++] = row[j];
            }
            System.Array.Sort(flat);
            if ((total & 1) == 1) return flat[total / 2];
            return (flat[total / 2 - 1] + flat[total / 2]) / 2.0;
        }
        public double CountLargeElements(int[][] array)
        {
            if (array == null) return 0;
            long cnt = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int[] row = array[i] ?? System.Array.Empty<int>();
                if (row.Length == 0) continue;
                long sum = 0;
                for (int j = 0; j < row.Length; j++) sum += row[j];
                double avg = (double)sum / row.Length;
                for (int j = 0; j < row.Length; j++) if (row[j] > avg) cnt++;
            }
            return cnt;
        }
    }
}






