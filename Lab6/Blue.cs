namespace Lab6
{
    public class Blue
    {   
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return -1;

            int index = 0;

            for (int i = 1; i < matrix.GetLength(0); i++)
                if (matrix[i, i] > matrix[index, index])
                    index = i;

            return index;
        }
        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= matrix.GetLength(0))
                return;

            if (matrix.GetLength(0) == 1)
            {
                matrix = new int[0, matrix.GetLength(1)];
                return;
            }

            int[,] res = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            int r = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
                if (i != rowIndex)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        res[r, j] = matrix[i, j];
                    r++;
                }

            matrix = res;
        }
        public void Task1(ref int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;

            RemoveRow(ref matrix, FindDiagonalMaxIndex(matrix));
            // end

        }
        
        public double GetAverageExceptEdges(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int min = matrix[0, 0], max = matrix[0, 0];
            double sum = 0;
            int cnt = n * m;

            for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
            {
                int v = matrix[i, j];
                sum += v;
                if (v < min) min = v;
                if (v > max) max = v;
            }

            if (cnt <= 2)
                return 0;

            return (sum - min - max) / (cnt - 2);
        }
        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

            // code here
            double a = GetAverageExceptEdges(A);
            double b = GetAverageExceptEdges(B);
            double c = GetAverageExceptEdges(C);

            if (a < b && b < c)
                answer = 1;
            else if (a > b && b > c)
                answer = -1;
            // end

            return answer;
        }
        public int FindUpperColIndex(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return -1;

            int n = matrix.GetLength(0);
            int r = -1, c = -1;

            for (int i = 0; i < n; i++)
            for (int j = i + 1; j < n; j++)
                if (r == -1 || matrix[i, j] > matrix[r, c])
                {
                    r = i;
                    c = j;
                }

            return c;
        }

        public int FindLowerColIndex(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return -1;

            int n = matrix.GetLength(0);
            int r = -1, c = -1;

            for (int i = 0; i < n; i++)
            for (int j = 0; j <= i; j++)
                if (r == -1 || matrix[i, j] > matrix[r, c])
                {
                    r = i;
                    c = j;
                }

            return c;
        }

        public void RemoveColumn(ref int[,] matrix, int col)
        {
            if (col < 0 || col >= matrix.GetLength(1))
                return;

            int n = matrix.GetLength(0), m = matrix.GetLength(1);

            if (m == 1)
            {
                matrix = new int[n, 0];
                return;
            }

            int[,] res = new int[n, m - 1];
            int nc;

            for (int i = 0; i < n; i++)
            {
                nc = 0;
                for (int j = 0; j < m; j++)
                    if (j != col)
                        res[i, nc++] = matrix[i, j];
            }

            matrix = res;
        }
        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;

            int col = method(matrix);
            RemoveColumn(ref matrix, col);
            // end

        }
        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                if (matrix[i, col] == 0)
                    return true;
            return false;
        }
        public void Task4(ref int[,] matrix)
        {

            // code here
            for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                if (!CheckZerosInColumn(matrix, j))
                    RemoveColumn(ref matrix, j);
            // end

        }
        
        public delegate int Finder(int[,] matrix, out int row, out int col);

        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0; col = 0;
            int v = matrix[0, 0];

            for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (matrix[i, j] > v)
                {
                    v = matrix[i, j];
                    row = i;
                    col = j;
                }

            return v;
        }

        public int FindMin(int[,] matrix, out int row, out int col)
        {
            row = 0; col = 0;
            int v = matrix[0, 0];

            for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (matrix[i, j] < v)
                {
                    v = matrix[i, j];
                    row = i;
                    col = j;
                }

            return v;
        }

        public void Task5(ref int[,] matrix, Finder find)
        {

            // code here
            int r, c;
            int v = find(matrix, out r, out c);

            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (matrix[i, j] == v)
                {
                    RemoveRow(ref matrix, i);
                    break;
                }
            // end

        }
        public delegate void SortRowsStyle(int[,] matrix, int row);
        public void SortRowAscending(int[,] matrix, int row)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int k = 0; k < m; k++)
            for (int j = 0; j < m - k - 1; j++)
                if (matrix[row, j] > matrix[row, j + 1])
                    (matrix[row, j], matrix[row, j + 1]) = (matrix[row, j + 1], matrix[row, j]);
        }
        public void SortRowDescending(int[,] matrix, int row)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int k = 0; k < m; k++)
            for (int j = 0; j < m - k - 1; j++)
                if (matrix[row, j] < matrix[row, j + 1])
                    (matrix[row, j], matrix[row, j + 1]) = (matrix[row, j + 1], matrix[row, j]);
        }
        public void Task6(int[,] matrix, SortRowsStyle sort)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (sort == null) return;
            for (int i = 0; i < n; i++)
                if ((i) % 3 == 0)
                    sort(matrix, i);
            // end

        }
        
        public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);

        public int FindMaxInRow(int[,] matrix, int row)
        {
            int max = matrix[row, 0];
            for (int j = 1; j < matrix.GetLength(1); j++)
                if (matrix[row, j] > max)
                    max = matrix[row, j];
            return max;
        }

        public void ReplaceByZero(int[,] matrix, int row, int maxValue)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (matrix[row, j] == maxValue)
                    matrix[row, j] = 0;
        }

        public void MultiplyByColumn(int[,] matrix, int row, int maxValue)
        {
            if (matrix == null ||
                row < 0 ||
                row >= matrix.GetLength(0))
                return;

            for (int j = 0; j < matrix.GetLength(1); j++)
                if (matrix[row, j] == maxValue)
                    matrix[row, j] *= (j + 1);
        }
        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = FindMaxInRow(matrix, i);
                transform(matrix, i, max);
            }
            // end

        }
        public double[,] GetSumAndY(double a, double b, double h, Func<double, double> sum, Func<double, double> y)
        {
            if (sum == null || y == null || a > b || h <= 0) return null;
            int k = 0;
            for (double i = a; i <= b + 1e-10; i += h) k++;
            double[,] mat = new double[k, 2];
            double x = a;
            for (int i = 0; i < k; i++)
            {
                mat[i, 0] = sum(x);
                mat[i, 1] = y(x);
                x += h;
            }
            return mat;
        }

        private static long Factorial(int k)
        {
            if (k <= 1) return 1;
            long r = 1;
            for (int i = 2; i <= k; i++) r *= i;
            return r;
        }

        public double SumA(double x)
        {
            double s = 1.0;
            int i = 1; double t;
            do
            {
                t = Math.Cos(i * x) / Factorial(i);
                s += t;
                i++;
            }
            while (Math.Abs(t) > 1e-10 && i <= 10);
            return s;
        }

        public double YA(double x)
        {
            return Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x));
        }

        public double SumB(double x)
        {
            double s = -2.0 * Math.PI * Math.PI / 3.0, mn = -1, t = 1;
            for (int i = 1; Math.Abs(t) >= 0.000001; i++)
            {
                t = mn * (Math.Cos(i * x) / (i * i));
                mn *= -1;
                s += t;
            }
            return s;
        }

        public double YB(double x)
        {
            double y = (x * x / 4) - (Math.PI * Math.PI * 3) / 4;
            return y;
        }
        public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
        {
            double[,] answer = null;

            // code here
            answer = GetSumAndY(a, b, h, getSum, getY);
            // end

            return answer;
        }
        public delegate int[] GetTriangle(int[,] matrix);
        public int Sum(int[] array)
        {
            int s = 0;
            for (int i = 0; i < array.Length; i++) s += array[i] * array[i];
            return s;
        }

        public int GetSum(GetTriangle transformer, int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) return 0;
            return Sum(transformer(matrix));
        }

        public int[] GetUpperTriangle(int[,] matrix)
        {
            int n = matrix.GetLength(0), k = n * (n + 1) / 2, p = 0;
            int[] r = new int[k];
            for (int i = 0; i < n; i++)
            for (int j = i; j < n; j++)
                r[p++] = matrix[i, j];
            return r;
        }

        public int[] GetLowerTriangle(int[,] matrix)
        {
            int n = matrix.GetLength(0), k = n * (n + 1) / 2, p = 0;
            int[] r = new int[k];
            for (int i = 0; i < n; i++)
            for (int j = 0; j <= i; j++)
                r[p++] = matrix[i, j];
            return r;
        }
        public int Task9(int[,] matrix, GetTriangle triangle)
        {
            int answer = 0;

            // code here
            if (matrix == null || triangle == null) return 0;
            answer = GetSum(triangle, matrix);
            // end

            return answer;
        }
        public bool CheckTransformAbility(int[][] array)
        {
            if (array == null || array.Length == 0)
                return false;

            int rowCount = array.Length;
            int elementSum = 0;

            for (int i = 0; i < rowCount; i++)
            {
                if (array[i] == null)
                    return false;

                elementSum += array[i].Length;
            }

            return elementSum % rowCount == 0;
        }

        public bool CheckSumOrder(int[][] array)
        {
            if (array.Length < 2) return true;
            int[] s = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            for (int j = 0; j < array[i].Length; j++)
                s[i] += array[i][j];
            bool inc = true, dec = true;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] < s[i - 1]) inc = false;
                if (s[i] > s[i - 1]) dec = false;
            }
            return inc || dec;
        }

        public bool CheckArraysOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length < 2) return true;
                bool inc = true, dec = true;
                for (int j = 1; j < array[i].Length; j++)
                {
                    if (array[i][j] < array[i][j - 1]) inc = false;
                    if (array[i][j] > array[i][j - 1]) dec = false;
                }
                if (inc || dec) return true;
            }
            return false;
        }
        public bool Task10(int[][] array, Predicate<int[][]> func)
        {
            bool res = false;

            // code here
            if (array == null || func == null) return false;
            res = func(array);
            // end

            return res;
        }
    }
}