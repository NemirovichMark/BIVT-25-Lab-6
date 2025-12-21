using System;

namespace Lab6
{
    public class Blue
    {
        public delegate int Finder(int[,] m, out int r, out int c);
        public delegate void SortRowsStyle(int[,] m, int r);
        public delegate void ReplaceMaxElements(int[,] m, int r, int v);
        public delegate int[] GetTriangle(int[,] m);
        public delegate bool Predicate(int[][] a);

        
        public int FindDiagonalMaxIndex(int[,] m)
        {
            int p = 0;
            int v = m[0, 0];

            for (int i = 0; i < m.GetLength(0); i++)
                if (m[i, i] > v)
                {
                    v = m[i, i];
                    p = i;
                }
            return p;
        }

        public void RemoveRow(ref int[,] m, int r)
        {
            int[,] t = new int[m.GetLength(0) - 1, m.GetLength(1)];
            int k = 0;

            for (int i = 0; i < m.GetLength(0); i++)
            {
                if (i == r) continue;

                for (int j = 0; j < m.GetLength(1); j++)
                    t[k, j] = m[i, j];
                k++;
            }
            m = t;
        }

        public void Task1(ref int[,] m)
        {
            if (m.GetLength(0) == m.GetLength(1))
                RemoveRow(ref m, FindDiagonalMaxIndex(m));
        }

        public double GetAverageExceptEdges(int[,] m)
        {
            double s = 0;
            int a = m[0, 0], b = m[0, 0];

            for (int i = 0; i < m.GetLength(0); i++)

                for (int j = 0; j < m.GetLength(1); j++)
                {
                    int x = m[i, j];
                    s += x;
                    if (x > a) a = x;
                    if (x < b) b = x;
                }
            return (s - a - b) / (m.Length - 2);
        }

        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            double x = GetAverageExceptEdges(A);
            double y = GetAverageExceptEdges(B);
            double z = GetAverageExceptEdges(C);
            if (x < y && y < z) return 1;
            if (x > y && y > z) return -1;

            return 0;
        }

        
        public int FindUpperColIndex(int[,] m)
        {
            int v = int.MinValue, p = 0;

            for (int i = 0; i < m.GetLength(0); i++)

                for (int j = i + 1; j < m.GetLength(1); j++)
                    if (m[i, j] > v)
                    {
                        v = m[i, j];
                        p = j;
                    }
            return p;
        }

        public int FindLowerColIndex(int[,] m)
        {
            int v = int.MinValue, p = 0;

            for (int i = 0; i < m.GetLength(0); i++)

                for (int j = 0; j <= i; j++)
                    if (m[i, j] > v)
                    {
                        v = m[i, j];
                        p = j;
                    }
            return p;
        }

        public void RemoveColumn(ref int[,] m, int c)
        {
            int[,] t = new int[m.GetLength(0), m.GetLength(1) - 1];

            for (int i = 0; i < m.GetLength(0); i++)
            {
                int k = 0;

                for (int j = 0; j < m.GetLength(1); j++)
                    if (j != c) t[i, k++] = m[i, j];
            }
            m = t;
        }

        public void Task3(ref int[,] m, Func<int[,], int> f)
        {
            if (m.GetLength(0) == m.GetLength(1))
                RemoveColumn(ref m, f(m));
        }

        public bool CheckZerosInColumn(int[,] m, int c)
        {
            for (int i = 0; i < m.GetLength(0); i++)
                if (m[i, c] == 0) return true;
            return false;
        }

        public void Task4(ref int[,] m)
        {
            for (int j = m.GetLength(1) - 1; j >= 0; j--)
                if (!CheckZerosInColumn(m, j))
                    RemoveColumn(ref m, j);
        }

        
        public int FindMax(int[,] m, out int r, out int c)
        {
            int v = m[0, 0];
            r = c = 0;

            for (int i = 0; i < m.GetLength(0); i++)

                for (int j = 0; j < m.GetLength(1); j++)
                    if (m[i, j] > v)
                    {
                        v = m[i, j];
                        r = i;
                        c = j;
                    }
            return v;
        }

        public int FindMin(int[,] m, out int r, out int c)
        {
            int v = m[0, 0];
            r = c = 0;

            for (int i = 0; i < m.GetLength(0); i++)

                for (int j = 0; j < m.GetLength(1); j++)
                    if (m[i, j] < v)
                    {
                        v = m[i, j];
                        r = i;
                        c = j;
                    }
            return v;
        }

        public int FindMax(int[,] m) { int r, c; return FindMax(m, out r, out c); }
        public int FindMin(int[,] m) { int r, c; return FindMin(m, out r, out c); }

        public void Task5(ref int[,] m, Finder f)
        {
            int r, c;
            int v = f(m, out r, out c);

            for (int i = m.GetLength(0) - 1; i >= 0; i--)

                for (int j = 0; j < m.GetLength(1); j++)
                    if (m[i, j] == v)
                    {
                        RemoveRow(ref m, i);
                        break;
                    }
        }

        public void SortRowAscending(int[,] m, int r)
        {
            for (int i = 0; i < m.GetLength(1); i++)

                for (int j = 0; j < m.GetLength(1) - 1; j++)
                    if (m[r, j] > m[r, j + 1])
                        (m[r, j], m[r, j + 1]) = (m[r, j + 1], m[r, j]);
        }

        public void SortRowDescending(int[,] m, int r)
        {
            for (int i = 0; i < m.GetLength(1); i++)

                for (int j = 0; j < m.GetLength(1) - 1; j++)
                    if (m[r, j] < m[r, j + 1])
                        (m[r, j], m[r, j + 1]) = (m[r, j + 1], m[r, j]);
        }

        public void Task6(int[,] m, SortRowsStyle s)
        {
            for (int i = 0; i < m.GetLength(0); i += 3)
                s(m, i);
        }

        public int FindMaxInRow(int[,] m, int r)
        {
            int v = m[r, 0];

            for (int j = 1; j < m.GetLength(1); j++)
                if (m[r, j] > v) v = m[r, j];
            return v;
        }

        public void ReplaceByZero(int[,] m, int r, int v)
        {
            for (int j = 0; j < m.GetLength(1); j++)
                if (m[r, j] == v) m[r, j] = 0;
        }

        public void MultiplyByColumn(int[,] m, int r, int v)
        {
            for (int j = 0; j < m.GetLength(1); j++)
                if (m[r, j] == v) m[r, j] *= (j + 1);
        }

        public void Task7(int[,] m, ReplaceMaxElements f)
        {
            for (int i = 0; i < m.GetLength(0); i++)
                f(m, i, FindMaxInRow(m, i));
        }

        
        public double SumA(double x)
        {
            double s = 1, t = 1;

            for (int i = 1; i <= 10; i++)
            {
                t *= i;
                s += Math.Cos(i * x) / t;
            }
            return s;
        }

        public double YA(double x)
        {
            return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
        }

        public double SumB(double x)
        {
            double s = -2 * Math.PI * Math.PI / 3, t;

            for (int i = 1; ; i++)
            {
                t = Math.Pow(-1, i) * Math.Cos(i * x) / (i * i);
                s += t;
                if (Math.Abs(t) < 1e-6) break;
            }
            return s;
        }

        public double YB(double x)
        {
            return x * x / 4 - 3 * Math.PI * Math.PI / 4;
        }

        public double[,] GetSumAndY(double a, double b, double h,
            Func<double, double> s, Func<double, double> y)
        {
            int n = (int)((b - a) / h) + 1;
            double[,] r = new double[n, 2];

            for (int i = 0; i < n; i++)
            {
                double x = a + i * h;
                r[i, 0] = s(x);
                r[i, 1] = y(x);
            }
            return r;
        }

        public double[,] Task8(double a, double b, double h,
            Func<double, double> s, Func<double, double> y)
        {
            return GetSumAndY(a, b, h, s, y);
        }

        public int Sum(int[] a)
        {
            int s = 0;
            foreach (int x in a) s += x * x;
            return s;
        }

        public int[] GetUpperTriangle(int[,] m)
        {
            int n = m.GetLength(0);
            int[] a = new int[n * (n + 1) / 2];
            int k = 0;

            for (int i = 0; i < n; i++)
                for (int j = i; j < n; j++)
                    a[k++] = m[i, j];
            return a;
        }

        public int[] GetLowerTriangle(int[,] m)
        {
            int n = m.GetLength(0);
            int[] a = new int[n * (n + 1) / 2];
            int k = 0;

            for (int i = 0; i < n; i++)
                for (int j = 0; j <= i; j++)
                    a[k++] = m[i, j];
            return a;
        }

        public int Task9(int[,] m, GetTriangle g)
        {
            if (m.GetLength(0) != m.GetLength(1)) return 0;
            return Sum(g(m));
        }

        
        public bool CheckTransformAbility(int[][] a)
        {
            int s = 0;
            foreach (var x in a) s += x.Length;
            return s % a.Length == 0;
        }

        public bool CheckSumOrder(int[][] a)
        {
            if (a.Length < 2) return true;
            int[] s = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
                foreach (int x in a[i]) s[i] += x;

            bool inc = true, dec = true;

            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] >= s[i + 1]) inc = false;
                if (s[i] <= s[i + 1]) dec = false;
            }
            return inc || dec;
        }

        public bool CheckArraysOrder(int[][] a)
        {
            foreach (var x in a)
            {
                bool inc = true, dec = true;

                for (int i = 0; i < x.Length - 1; i++)
                {
                    if (x[i] >= x[i + 1]) inc = false;
                    if (x[i] <= x[i + 1]) dec = false;
                }
                if (inc || dec) return true;
            }
            return false;
        }

        public bool Task10(int[][] a, Predicate f)
        {
            return f(a);
        }
    }
}
