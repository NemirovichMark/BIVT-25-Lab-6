using System.Reflection;

namespace Lab6
{
    public class Blue
    {
        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int[,] mat1 = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            for (int i = 0; i < rowIndex; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    mat1[i, j] = matrix[i, j];
                }
            }

            for (int i = rowIndex; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    mat1[i, j] = matrix[i + 1, j];
                }
            }

            matrix = mat1;

        }

        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int ind = -1;
            int mx = -1000000;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > mx)
                {
                    ind = i;
                    mx = matrix[i, i];
                }
            }

            return ind;
        }

        public void Task1(ref int[,] matrix)
        {
            if (matrix.GetLength(0) <= 0 || matrix.GetLength(1) <= 0 || matrix.GetLength(0) != matrix.GetLength(1))
                return;
            int index = FindDiagonalMaxIndex(matrix);
            int[,] a = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            RemoveRow(ref matrix, index);
        }
        public int FindMax(int[,] matrix)
        {
            int r, c;
            return FindMax(matrix, out r, out c);
        }
        public int FindMin(int[,] matrix)
        {
            int r, c;
            return FindMin(matrix, out r, out c);
        }

        public double GetAverageExceptEdges(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int count = n * m;
            if (count <= 2) return 0.0;

            int maxel = FindMax(matrix);
            int minel = FindMin(matrix);

            int sumel = 0;
            bool flagmax = false;
            bool flagmin = false;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sumel += matrix[i, j];

                    if (matrix[i, j] == maxel && !flagmax)
                    {
                        sumel -= matrix[i, j];
                        flagmax = true;
                    }
                    else if (matrix[i, j] == minel && !flagmin)
                    {
                        sumel -= matrix[i, j];
                        flagmin = true;
                    }
                }
            }
            int del = count - 2;
            if (del == 0) return 0.0;
            return (double)sumel / del;
        }

        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing
            int[][,] mat = new int[3][,] { A, B, C };
            double[] a = new double[3];
            int count = 0;
            foreach (int[,] p in mat)
            {
                a[count++] = GetAverageExceptEdges(p);
            }

            if (a[0] < a[1] && a[1] < a[2])
                answer = 1;
            else if (a[0] > a[1] && a[1] > a[2])
                answer = -1;
            else
                answer = 0;
            return answer;
        }

        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {
            if (matrix.GetLength(0) <= 0 || matrix.GetLength(1) <= 0 || matrix.GetLength(0) != matrix.GetLength(1))
                return;
            int a = method(matrix);
            if (a < 0)
                return;
            RemoveColumn(ref matrix, a);

        }

        public int FindUpperColIndex(int[,] matrix)
        {
            int index = -1;
            int mx = -1000000;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (mx < matrix[j, i])
                    {
                        mx = matrix[j, i];
                        index = i;
                    }
                }
            }

            return index;
        }

        public int FindLowerColIndex(int[,] matrix)
        {
            int index = -1;
            int mx = -1000000;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = i; j < matrix.GetLength(0); j++)
                {
                    if (mx < matrix[j, i])
                    {
                        mx = matrix[j, i];
                        index = i;
                    }
                }
            }

            return index;
        }

        public void RemoveColumn(ref int[,] matrix, int col)
        {
            int[,] mat = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (j < col)
                        mat[i, j] = matrix[i, j];
                    else
                    {
                        mat[i, j] = matrix[i, j + 1];
                    }
                }
            }

            matrix = mat;
        }

        public void Task4(ref int[,] matrix)
        {
            if (matrix.GetLength(0) <= 0 || matrix.GetLength(1) <= 0)
                return;

            while (true)
            {
                bool c = false;
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (!CheckZerosInColumn(matrix, i))
                    {
                        c = true;
                        RemoveColumn(ref matrix, i);
                        break;
                    }
                }

                if (c == false)
                    break;
            }
        }

        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            bool result = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] == 0)
                    return true;
            }

            return result;
        }



        public void Task5(ref int[,] matrix, Finder find)
        {
            // code here
            int row, col;
            int c = find(matrix, out row, out col);
            while (find(matrix, out row, out col) == c)
                RemoveRow(ref matrix, row);

            // end

        }

        public delegate int Finder(int[,] matrix, out int row, out int col);

        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            if (matrix == null || matrix.GetLength(0) <= 0 || matrix.GetLength(1) <= 0)
                return 0;
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

            return mx;
        }

        public int FindMin(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            int mn = int.MaxValue;


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < mn)
                    {
                        mn = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }

            return mn;
        }

        public delegate void SortRowsStyle(int[,] matrix, int row);

        public void SortRowAscending(int[,] matrix, int row)
        {
            int[] a = new int[matrix.GetLength(1)];
            int count = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
                a[count++] = matrix[row, i];
            Array.Sort(a);
            for (int i = 0; i < matrix.GetLength(1); i++)
                matrix[row, i] = a[i];
        }

        public void SortRowDescending(int[,] matrix, int row)
        {
            int[] a = new int[matrix.GetLength(1)];
            int count = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
                a[count++] = matrix[row, i];
            Array.Sort(a);
            Array.Reverse(a);
            for (int i = 0; i < matrix.GetLength(1); i++)
                matrix[row, i] = a[i];
        }

        public void Task6(int[,] matrix, SortRowsStyle sort)
        {
            if (matrix == null || matrix.GetLength(0) <= 0 || matrix.GetLength(1) <= 0)
                return;
            // code here
            for (int i = 0; i < matrix.GetLength(0); i += 3)
                sort(matrix, i);
            // end

        }

        public int FindMaxInRow(int[,] matrix, int row)
        {
            int mx = int.MinValue;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] > mx)
                    mx = matrix[row, i];
            }

            return mx;
        }

        public delegate void ReplaceMaxElements(int[,] matrix, int row, int mx);

        public void ReplaceByZero(int[,] matrix, int row, int maxValue)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
                if (matrix[row, i] == maxValue)
                    matrix[row, i] = 0;
        }

        public void MultiplyByColumn(int[,] matrix, int row, int maxValue)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (matrix[row, j] == maxValue)
                    matrix[row, j] = matrix[row, j] * (j + 1);
        }

        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {
            if (matrix == null || matrix.GetLength(0) <= 0 || matrix.GetLength(1) <= 0)
                return;
            // code here

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int mx = FindMaxInRow(matrix, i);
                transform(matrix, i, mx);
            }
            // end

        }


        public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
        {
            double[,] answer = null;

            // code here
            answer = GetSumAndY(a, b, h, getSum, getY);
            // end

            return answer;
        }

        public double[,] GetSumAndY(double a, double b, double h, Func<double, double> sum, Func<double, double> y)
        {
            int n = (int)((b - a) / h) + 1;

            int k = 0;

            double[,] answer = new double[n, 2];

            for (double x = a; x <= b + 1e-9; x += h)
            {
                answer[k, 0] = sum(x);
                answer[k, 1] = y(x);
                k++;
            }

            return answer;
        }

        public double SumA(double x)
        {
            double sum = 1.0;
            double fact = 1.0;
            for (int i = 1; i <= 10; i++)
            {
                fact *= i;
                sum += Math.Cos(i * x) / fact;
            }

            return sum;
        }

        public double SumB(double x)
        {
            double s = -2.0 * Math.PI * Math.PI / 3.0;

            for (double i = 1;; i += 1.0)
            {
                double sign = (i % 2 == 0) ? 1.0 : -1.0;
                s += sign * Math.Cos(i * x) / (i * i);

                if (Math.Abs(sign * Math.Cos(i * x) / (i * i)) < 0.000001) break;
            }

            return s;
        }

        public double YA(double x)
        {
            return Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x));
        }

        public double YB(double x)
        {
            return (x * x) / 4.0 - 3.0 * (Math.PI * Math.PI) / 4.0;
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
        public delegate int[] GetTriangle(int[,] matrix);
        public int Sum(int[] array)
        {
            if (array == null) return 0;
            int n = array.Length;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += (array[i] * array[i]);
            }

            return sum;
        }
        public int GetSum(GetTriangle transformer, int[,] matrix)
        {
            if (transformer == null || matrix == null) return 0;

            int[] array = transformer(matrix);
            int sum = Sum(array);

            return sum;
        }
        public int[] GetUpperTriangle(int[,] matrix)
        {
            if (matrix == null) return null;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m) return null;

            int count = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    count++;
                }
            }

            int[] array = new int[count];
            int k = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    array[k] = matrix[i, j];
                    k++;
                }
            }

            return array;
        }
        public int[] GetLowerTriangle(int[,] matrix)
        {
            if (matrix == null) return null;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m) return null;

            int count = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    count++;
                }
            }

            int[] array = new int[count];
            int k = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    array[k] = matrix[i, j];
                    k++;
                }
            }

            return array;
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
        public bool CheckTransformAbility(int[][] array)
        {
            if (array == null || array.Length == 0) return false;

            int n = array.GetLength(0);
            bool answer = false;

            int count = 0;

            for (int i = 0; i < n; i++)
            {
                if (array[i] == null) return false;
                count += array[i].Length;
            }

            if (count % n == 0) answer = true;

            return answer;
        }
        public bool CheckSumOrder(int[][] array)
        {
            if (array == null || array.Length == 0) return false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null) return false;
            }
                
            if (array.Length == 1) return true;

            int sum = 0;
            for (int j = 0; j < array[0].Length; j++)
            {
                sum += array[0][j];
            }

            bool f1 = true, f2 = true;

            for (int i = 1; i < array.Length; i++)
            {
                int s = 0;
                for (int j = 0; j < array[i].Length; j++) 
                {
                    s += array[i][j];
                }
                if (s <= sum) f1 = false;
                if (s >= sum) f2 = false;

                sum = s;
            }
            if (f1 || f2) return true;

            return false;
        }
        public bool CheckArraysOrder(int[][] array)
        {
            if (array == null || array.Length == 0) return false;

            for (int i = 0; i < array.Length; i++)
            {
                int[] r = array[i];
                if (r == null) return false;

                if (r.Length <= 1) return true;

                bool f1 = true, f2 = true;

                for (int j = 1; j < r.Length; j++)
                {
                    if (r[j] < r[j - 1]) f1 = false;
                    if (r[j] > r[j - 1]) f2 = false;
                }

                if (f1 || f2) return true;
            }

            return false;
        }
    }
}