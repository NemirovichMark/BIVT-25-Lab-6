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
            DeleteMaxElement(ref A);

            DeleteMaxElement(ref B);

            A = CombineArrays(A, B);
        }

        public int FindMaxInRow(int[,] m, int r, out int cl)
        {
            cl = 0;

            if (m == null || r < 0 || r >= m.GetLength(0)) { return 0; }

            int mx = m[r, cl];

            for (int k = 0; k < m.GetLength(1); k++)
            {
                if (m[r, k] > mx)
                {
                    mx = m[r, k];
                    cl = k;
                }
            }

            return mx;
        }

        public void Task2(int[,] matrix, int[] array)
        {
            if (array == null || array.Length == 0 || matrix == null || matrix.GetLength(0) != array.Length) { return; }

            int cl;

            for (int k = 0; k < matrix.GetLength(0); k++)
            {
                if (FindMaxInRow(matrix, k, out cl) < array[k]) { matrix[k, cl] = array[k]; }
            }
        }

        public void FindMax(int[,] m, out int rw, out int cl)
        {
            rw = 0;
            cl = 0;

            int mx = m[rw, cl];

            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (m[i, j] > mx)
                    {
                        mx = m[i, j];
                        rw = i;
                        cl = j;
                    }
                }
            }
        }

        public void SwapColWithDiagonal(int[,] m, int cl)
        {
            if (m == null || m.GetLength(0) != m.GetLength(1)) { return; }

            int sz = m.GetLength(0);

            for (int k = 0; k < sz; k++)
            {
                int tmp = m[k, cl];
                m[k, cl] = m[k, k];
                m[k, k] = tmp;
            }
        }

        public void Task3(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1)) { return; }

            int rw, cl;

            FindMax(matrix, out rw, out cl);

            SwapColWithDiagonal(matrix, cl);
        }

        public void RemoveRow(ref int[,] m, int rw)
        {
            if (m == null || rw < 0 || rw >= m.GetLength(0)) { return; }

            int orw = m.GetLength(0);
            int cls = m.GetLength(1);

            int[,] nm = new int[orw - 1, cls];

            int nr = 0;

            for (int k = 0; k < orw; k++)
            {
                if (k == rw) { continue; }

                for (int j = 0; j < cls; j++)
                {
                    nm[nr, j] = m[k, j];
                }

                nr++;
            }

            m = nm;
        }

        public void Task4(ref int[,] matrix)
        {
            if (matrix == null) { return; }

            int rws = matrix.GetLength(0);
            int cls = matrix.GetLength(1);

            int k = 0;

            while (k < rws)
            {
                bool hz = false;

                for (int j = 0; j < cls; j++)
                {
                    if (matrix[k, j] == 0)
                    {
                        hz = true;
                        break;
                    }
                }

                if (hz)
                {
                    RemoveRow(ref matrix, k);
                    rws = matrix.GetLength(0);
                }
                else
                {
                    k++;
                }
            }
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
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1)) { return null; }

            return GetRowsMinElements(matrix);
        }

        public int[] SumPositiveElementsInColumns(int[,] m)
        {
            if (m == null) { return new int[0]; }

            int[] sums = new int[m.GetLength(1)];

            for (int j = 0; j < m.GetLength(1); j++)
            {
                sums[j] = 0;

                for (int k = 0; k < m.GetLength(0); k++)
                {
                    sums[j] += m[k, j] > 0 ? m[k, j] : 0;
                }
            }

            return sums;
        }

        public int[] Task6(int[,] A, int[,] B)
        {
            int[] asums = SumPositiveElementsInColumns(A);

            int[] bsums = SumPositiveElementsInColumns(B);

            return CombineArrays(asums, bsums);
        }

        private void SelectionSort(int[] arr, bool asc = true)
        {
            if (arr == null) { return; }

            int n = arr.Length;

            for (int k = 0; k < n - 1; k++)
            {
                int ti = k;

                for (int j = k + 1; j < n; j++)
                {
                    if (asc)
                    {
                        if (arr[j] < arr[ti]) { ti = j; }
                    }
                    else
                    {
                        if (arr[j] > arr[ti]) { ti = j; }
                    }
                }

                if (ti != k)
                {
                    int tmp = arr[k];
                    arr[k] = arr[ti];
                    arr[ti] = tmp;
                }
            }
        }

        private int FindMaxIndexInRow(int[,] m, int rw)
        {
            int mi = 0;

            int cls = m.GetLength(1);

            for (int j = 1; j < cls; j++)
            {
                if (m[rw, j] > m[rw, mi]) { mi = j; }
            }

            return mi;
        }

        public void SortEndAscending(int[,] m)
        {
            if (m == null) { return; }

            int rws = m.GetLength(0);
            int cls = m.GetLength(1);

            for (int k = 0; k < rws; k++)
            {
                int mi = FindMaxIndexInRow(m, k);

                if (mi < cls - 1)
                {
                    int sc = cls - mi - 1;
                    int[] sa = new int[sc];

                    for (int p = 0; p < sc; p++) { sa[p] = m[k, mi + 1 + p]; }

                    SelectionSort(sa, true);

                    for (int p = 0; p < sc; p++) { m[k, mi + 1 + p] = sa[p]; }
                }
            }
        }

        public void SortEndDescending(int[,] m)
        {
            if (m == null) { return; }

            int rws = m.GetLength(0);
            int cls = m.GetLength(1);

            for (int k = 0; k < rws; k++)
            {
                int mi = FindMaxIndexInRow(m, k);

                if (mi < cls - 1)
                {
                    int sc = cls - mi - 1;
                    int[] sa = new int[sc];

                    for (int p = 0; p < sc; p++) { sa[p] = m[k, mi + 1 + p]; }

                    SelectionSort(sa, false);

                    for (int p = 0; p < sc; p++) { m[k, mi + 1 + p] = sa[p]; }
                }
            }
        }

        public delegate void Sorting(int[,] matrix);

        public void Task7(int[,] matrix, Sorting sort)
        {
            if (matrix == null || sort == null) { return; }

            sort(matrix);
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
            double aa = GeronArea(A[0], A[1], A[2]);

            double ab = GeronArea(B[0], B[1], B[2]);

            if (aa > ab) { return 1; }

            return 2;
        }

        public void SortMatrixRow(int[,] m, int rw, Action<int[]> sr)
        {
            if (m == null || sr == null) { return; }

            int cls = m.GetLength(1);

            int[] ra = new int[cls];

            for (int cl = 0; cl < cls; cl++) { ra[cl] = m[rw, cl]; }

            sr(ra);

            ReplaceRow(m, rw, ra);
        }

        public void ReplaceRow(int[,] m, int rw, int[] arr)
        {
            if (m == null || arr == null) { return; }

            int cls = m.GetLength(1);

            if (arr.Length != cls || rw < 0 || rw >= m.GetLength(0)) { return; }

            for (int j = 0; j < cls; j++) { m[rw, j] = arr[j]; }
        }

        public void SortAscending(int[] arr) { SelectionSort(arr, true); }

        public void SortDescending(int[] arr) { SelectionSort(arr, false); }

        public void Task9(int[,] matrix, Action<int[]> sorter)
        {
            if (matrix == null || sorter == null) { return; }

            for (int k = 0; k < matrix.GetLength(0); k += 2)
            {
                SortMatrixRow(matrix, k, sorter);
            }
        }

        public delegate double AnalyzeFunc(int[][] array);

        public double CountZeroSum(int[][] arr)
        {
            if (arr == null || arr.Length == 0) { return 0; }

            int cnt = 0;

            for (int k = 0; k < arr.Length; k++)
            {
                if (arr[k] == null || arr[k].Length == 0) { continue; }

                int s = 0;

                for (int j = 0; j < arr[k].Length; j++) { s += arr[k][j]; }

                cnt += s == 0 ? 1 : 0;
            }

            return cnt;
        }

        public double FindMedian(int[][] arr)
        {
            if (arr == null || arr.Length == 0) { return 0; }

            int tot = 0;

            for (int k = 0; k < arr.Length; k++)
            {
                if (arr[k] != null) { tot += arr[k].Length; }
            }

            int[] all = new int[tot];

            int id = 0;

            for (int k = 0; k < arr.Length; k++)
            {
                if (arr[k] != null)
                {
                    for (int j = 0; j < arr[k].Length; j++)
                    {
                        all[id++] = arr[k][j];
                    }
                }
            }

            SelectionSort(all, true);

            double med;

            if (tot % 2 == 1)
            {
                med = all[tot / 2];
            }
            else
            {
                double m1 = all[tot / 2 - 1];
                double m2 = all[tot / 2];
                med = (m1 + m2) / 2.0;
            }

            return med;
        }

        public double CountLargeElements(int[][] arr)
        {
            if (arr == null || arr.Length == 0) { return 0; }

            int tle = 0;

            for (int k = 0; k < arr.Length; k++)
            {
                if (arr[k] == null || arr[k].Length == 0) { continue; }

                double s = 0;

                for (int j = 0; j < arr[k].Length; j++) { s += arr[k][j]; }

                double avg = s / arr[k].Length;

                int le = 0;

                for (int j = 0; j < arr[k].Length; j++)
                {
                    le += arr[k][j] > avg ? 1 : 0;
                }

                tle += le;
            }

            return tle;
        }

        public double Task10(int[][] array, Func<int[][], double> func)
        {
            return func(array);
        }
    }
}