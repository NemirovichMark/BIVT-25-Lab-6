using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public delegate void Sorting(int[] array);

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
        public void Task2(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int col;
                int max = FindMaxInRow(matrix, i, out col);
                if (i < array.Length && max < array[i]) matrix[i, col] = array[i];
            }
            // end

        }
        public void Task3(int[,] matrix)
        {

            // code here
            FindMax(matrix, out int r, out int c);
            SwapColWithDiagonal(matrix, c);
            // end

        }
        public void Task4(ref int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = n - 1; i >= 0; i--)
            {
                bool hasZero = false;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0) { hasZero = true; break; }
                }
                if (hasZero) RemoveRow(ref matrix, i);
            }
            // end

        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m) return null;
            answer = GetRowsMinElements(matrix);
            // end

            return answer;
        }
        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;

            // code here
            var a = SumPositiveElementsInColumns(A);
            var b = SumPositiveElementsInColumns(B);
            answer = CombineArrays(a, b);
            // end

            return answer;
        }
        public void Task7(int[,] matrix, Sorting sort)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int col;
                FindMaxInRow(matrix, i, out col);
                if (col + 1 >= m) continue;
                int len = m - (col + 1);
                int[] tail = new int[len];
                for (int j = 0; j < len; j++) tail[j] = matrix[i, col + 1 + j];
                sort(tail);
                for (int j = 0; j < len; j++) matrix[i, col + 1 + j] = tail[j];
            }
            // end

        }
        public int Task8(double[] A, double[] B)
        {
            int answer = 0;

            // code here
            if (A == null || B == null || A.Length < 3 || B.Length < 3) return 0;
            double sA = GeronArea(A[0], A[1], A[2]);
            double sB = GeronArea(B[0], B[1], B[2]);
            const double eps = 1e-9;
            if (sA > sB + eps) answer = 1;
            else if (sB > sA + eps) answer = 2;
            else answer = 0;
            // end

            return answer;
        }
        public void Task9(int[,] matrix, Action<int[]> sorter)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i += 2)
            {
                int[] row = new int[m];
                for (int j = 0; j < m; j++) row[j] = matrix[i, j];
                sorter(row);
                for (int j = 0; j < m; j++) matrix[i, j] = row[j];
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
            // code here
            if (array == null || array.Length == 0) { array = new int[0]; return; }
            int max = array[0];
            int idx = 0;
            for (int i = 1; i < array.Length; i++)
                if (array[i] > max) { max = array[i]; idx = i; }
            int[] res = new int[array.Length - 1];
            int w = 0;
            for (int i = 0; i < array.Length; i++)
                if (i != idx) res[w++] = array[i];
            array = res;
            // end
        }

        public int[] CombineArrays(int[] A, int[] B)
        {
            // code here
            int a = A?.Length ?? 0;
            int b = B?.Length ?? 0;
            int[] res = new int[a + b];
            int k = 0;
            if (A != null) for (int i = 0; i < a; i++) res[k++] = A[i];
            if (B != null) for (int i = 0; i < b; i++) res[k++] = B[i];
            return res;
            // end
        }

        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            // code here
            int m = matrix.GetLength(1);
            int max = matrix[row, 0];
            int c = 0;
            for (int j = 1; j < m; j++)
                if (matrix[row, j] > max) { max = matrix[row, j]; c = j; }
            col = c;
            return max;
            // end
        }

        public void FindMax(int[,] matrix, out int row, out int col)
        {
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int max = matrix[0, 0];
            int r = 0, c = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] > max) { max = matrix[i, j]; r = i; c = j; }
            row = r; col = c;
            // end
        }

        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int limit = n < m ? n : m;
            for (int i = 0; i < limit; i++)
            {
                int t = matrix[i, col];
                matrix[i, col] = matrix[i, i];
                matrix[i, i] = t;
            }
            // end
        }

        public void RemoveRow(ref int[,] matrix, int row)
        {
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] res = new int[n - 1, m];
            int w = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == row) continue;
                for (int j = 0; j < m; j++) res[w, j] = matrix[i, j];
                w++;
            }
            matrix = res;
            // end
        }

        public int[] GetRowsMinElements(int[,] matrix)
        {
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int len = n < m ? n : m;
            int[] res = new int[len];
            for (int i = 0; i < len; i++)
            {
                int min = matrix[i, i];
                for (int j = i; j < m; j++)
                    if (matrix[i, j] < min) min = matrix[i, j];
                res[i] = min;
            }
            return res;
            // end
        }

        public int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] res = new int[m];
            for (int j = 0; j < m; j++)
            {
                int sum = 0;
                bool any = false;
                for (int i = 0; i < n; i++)
                {
                    int v = matrix[i, j];
                    if (v > 0) { sum += v; any = true; }
                }
                res[j] = any ? sum : 0;
            }
            return res;
            // end
        }

        public void SortEndAscending(int[] array)
        {
            // code here
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
            // end
        }

        public void SortEndDescending(int[] array)
        {
            // code here
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] < key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
            // end
        }

        public double GeronArea(double a, double b, double c)
        {
            // code here
            if (a <= 0 || b <= 0 || c <= 0) return 0;
            if (a + b <= c || a + c <= b || b + c <= a) return 0;
            double s = (a + b + c) / 2.0;
            return System.Math.Sqrt(System.Math.Max(0, s * (s - a) * (s - b) * (s - c)));
            // end
        }

        public void SortDescending(int[] array)
        {
            // code here
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] < key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
            // end
        }

        public void SortAscending(int[] array)
        {
            // code here
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
            // end
        }

        public double CountZeroSum(int[][] array)
        {
            // code here
            if (array == null) return 0;
            int cnt = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int s = 0;
                var row = array[i] ?? System.Array.Empty<int>();
                for (int j = 0; j < row.Length; j++) s += row[j];
                if (s == 0) cnt++;
            }
            return cnt;
            // end
        }

        public double FindMedian(int[][] array)
        {
            // code here
            if (array == null) return 0;
            int total = 0;
            for (int i = 0; i < array.Length; i++) total += (array[i]?.Length ?? 0);
            if (total == 0) return 0;
            int[] flat = new int[total];
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                var row = array[i] ?? System.Array.Empty<int>();
                for (int j = 0; j < row.Length; j++) flat[k++] = row[j];
            }
            SortAscending(flat);
            if ((total & 1) == 1) return flat[total / 2];
            return (flat[total / 2 - 1] + flat[total / 2]) / 2.0;
            // end
        }

        public double CountLargeElements(int[][] array)
        {
            // code here
            if (array == null) return 0;
            int cnt = 0;
            for (int i = 0; i < array.Length; i++)
            {
                var row = array[i] ?? System.Array.Empty<int>();
                int len = row.Length;
                double avg = 0;
                if (len > 0)
                {
                    long sum = 0;
                    for (int j = 0; j < len; j++) sum += row[j];
                    avg = (double)sum / len;
                }
                for (int j = 0; j < len; j++) if (row[j] > avg) cnt++;
            }
            return cnt;
            // end
        }
    }
}
