using System.Diagnostics.Metrics;
using System.Security.Cryptography;

namespace Lab6
{
    public class Blue
    {
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0), ind = 0;

            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > matrix[ind, ind])
                    ind = i;
            }
            return ind;
        }
        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[,] newMatrix = new int[n - 1, m];
            int ind = 0;

            for (int i = 0; i < n; i++)
            {
                if (i != rowIndex)
                {
                    for (int j = 0; j < m; j++)
                        newMatrix[ind, j] = matrix[i, j];
                    ind++;
                }
            }
            matrix = newMatrix;
        }

        public void Task1(ref int[,] matrix)
        {
            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1)){
                RemoveRow(ref matrix, FindDiagonalMaxIndex(matrix));
            }
            // end
        }

        public double GetAverageExceptEdges(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            double ave = 0;
            int max = matrix[0, 0], min = matrix[0, 0];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    ave += matrix[i, j];
                    max = Math.Max(max, matrix[i, j]);
                    min = Math.Min(min, matrix[i, j]);
                }
            }
            return (ave - max - min) / (n * m - 2);
        }
        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

            // code here
            double aveA = GetAverageExceptEdges(A), aveB = GetAverageExceptEdges(B),
                aveC = GetAverageExceptEdges(C);
            if ((aveA < aveB) && (aveB < aveC))
            {
                answer = 1;
            }
            else if ((aveA > aveB) && (aveB > aveC))
            {
                answer = -1;
            }
            else
            {
                answer = 0;
            }
            // end

            return answer;
        }

        public int FindUpperColIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int ind_i = 0, ind_j = 0;
            for (int i=0; i < n; i++)
            {
                for (int j=i+1; j < n; j++)
                {
                    if (matrix[ind_i, ind_j] < matrix[i, j])
                    {
                        ind_i = i;
                        ind_j = j;
                    }
                }
            }
            return ind_j;
        }
        public int FindLowerColIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int ind_i = 0, ind_j = 0;
            for (int i=0; i < n; i++)
            {
                for (int j=0; j <= i; j++)
                {
                    if (matrix[ind_i, ind_j] < matrix[i, j])
                    {
                        ind_i = i;
                        ind_j = j;
                    }
                }
            }
            return ind_j;
        }
        public void RemoveColumn(ref int[,] matrix, int col)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[,] new_matrix = new int[n, m - 1];
            int ind = 0;
            for (int j = 0; j < m; j++)
            {
                if (j != col)
                {
                    for (int i = 0; i < n; i++)
                        new_matrix[i, ind] = matrix[i, j];
                    ind++;
                }
            }
            matrix = new_matrix;
        }
        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                RemoveColumn(ref matrix, method(matrix));
            }
            // end

        }

        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            bool b = false;
            for (int i=0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] == 0)
                {
                    b = true;
                    break;
                }
            }
            return b;
        }

        public void Task4(ref int[,] matrix)
        {

            // code here
            int col = 0;
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int j = 0; j < m; j++)
            {
                if (CheckZerosInColumn(matrix, j))
                {
                    col++;
                }
            }
            int[,] new_matrix = new int[n, col];
            int ind = 0;
            for (int j = 0; j < m; j++)
            {
                if (CheckZerosInColumn(matrix, j))
                {
                    for (int i=0; i < n; i++)
                    {
                        new_matrix[i, ind] = matrix[i, j];
                    }
                    ind++;
                }
            }
            matrix = new_matrix;
            // end

        }

        public delegate int Finder(int[,] matrix, out int row, out int col);
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[row, col] < matrix[i, j])
                    {
                        row = i;
                        col = j;
                    }
                }
            }
            return matrix[row, col];
        }
        public int FindMin(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[row, col] > matrix[i, j])
                    {
                        row = i;
                        col = j;
                    }
                }
            }
            return matrix[row, col];
        }


        public void Task5(ref int[,] matrix, Finder find)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int row, col;
            int value = find(matrix, out row, out col);
            int ind = 0;
            bool b = true;
            for (int i = 0; i < n; i++)
            {
                b = true;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == value)
                    {
                        b = false;
                    }
                }
                if (b)
                {
                    ind++;
                }
            }
            int[,] new_matrix = new int[ind, m];
            ind = 0;
            for (int i = 0; i < n; i++)
            {
                b = true;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == value)
                    {
                        b = false;
                    }
                }
                if (b)
                {
                    for (int j = 0; j < m; j++)
                    {
                        new_matrix[ind, j] = matrix[i, j];
                    }
                    ind++;
                }
            }
            matrix = new_matrix;
            // end

        }

        public delegate void SortRowsStyle(int[,] matrix, int row);
        public void SortRowAscending(int[,] matrix, int row)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[row, j] < matrix[row, j - 1])
                    {
                        (matrix[row, j], matrix[row, j-1]) = (matrix[row, j-1], matrix[row, j]);
                    }
                }
            }
        }
        public void SortRowDescending(int[,] matrix, int row)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[row, j] > matrix[row, j - 1])
                    {
                        (matrix[row, j], matrix[row, j-1]) = (matrix[row, j-1], matrix[row, j]);
                    }
                }
            }
        }

        public void Task6(int[,] matrix, SortRowsStyle sort)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int i=0; i < n; i+=3)
            {
                sort(matrix, i);
            }
            // end

        }

        public int FindMaxInRow(int[,] matrix, int row)
        {
            int mx = matrix[row, 0];
            for (int j=0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > mx)
                {
                    mx = matrix[row, j];
                }
            }
            return mx;
        }

        public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);
        public void ReplaceByZero(int[,] matrix, int row, int maxValue)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int j = 0; j < m; j++)
            {
                if (matrix[row, j] == maxValue)
                {
                    matrix[row, j] = 0;
                }
            }
        }
        public void MultiplyByColumn(int[,] matrix, int row, int maxValue)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int j = 0; j < m; j++)
            {
                if (matrix[row, j] == maxValue)
                {
                    matrix[row, j] *= j+1;
                }
            }
        }

        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                transform(matrix, i, FindMaxInRow(matrix, i));
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
        public delegate double Func(double x);
        public double[,] GetSumAndY(double a, double b, double h, Func<double, double> sum, Func<double, double> y)
        {
            double[,] matrix = new double[(int)((b - a) / h) + 1, 2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double x = a + i * h;
                matrix[i, 0] = sum(x);
                matrix[i, 1] = y(x);
            }
            return matrix;
        }

        public double SumA(double x)
        {
            double sum = 1.0;
            double prevSum = 0.0;
            double factorial = 1.0;

            int i = 1;
            do
            {
                prevSum = sum;
                factorial *= i;
                sum += Math.Cos(i * x) / factorial;
                i++;
            }
            while (Math.Abs(sum - prevSum) >= 0.0001);

            return sum;
        }

        public double YA(double x)
        {
            double res = 0;
            res = Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
            return res;
        }

        public double SumB(double x)
        {
            double s = -2.0 * Math.PI * Math.PI / 3.0;

            for (double i = 1; ; i += 1.0)
            {
                s += Math.Pow(-1, i) * Math.Cos(i * x) / (i * i);

                if (Math.Abs(Math.Pow(-1, i) * Math.Cos(i * x) / (i * i)) < 0.000001) break;
            }
            return s;
        }

        public double YB(double x)
        {
            return (x * x) / 4.0 - 3.0 * (Math.PI * Math.PI) / 4.0;
        }

        public int Sum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i] * array[i];
            }
            return sum;
        }

        public delegate int[] GetTriangle(int[,] matrix);
        public int[] GetUpperTriangle(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int size = n * (n + 1) / 2;
            int[] array = new int[size];
            int ind = 0;
            for (int i=0; i < n; i++)
            {
                for (int j=i; j < n; j++)
                {
                    array[ind] = matrix[i, j];
                    ind++;
                }
            }
            return array;
        }
        public int[] GetLowerTriangle(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int size = n * (n + 1) / 2;
            int[] array = new int[size];
            int ind = 0;
            for (int i=0; i < n; i++)
            {
                for (int j=0; j <= i; j++)
                {
                    array[ind] = matrix[i, j];
                    ind++;
                }
            }
            return array;
        }

        public int GetSum(GetTriangle transformer, int[,] matrix)
        {
            return Sum(transformer(matrix));
        }

        public int Task9(int[,] matrix, GetTriangle triangle)
        {
            int answer = 0;

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                answer = GetSum(triangle, matrix);
            }
            // end

            return answer;
        }

        public delegate bool Predicate(int[][] array);
        public bool CheckTransformAbility(int[][] array)
        {
            bool b = false;
            int count = 0;
            for (int i=0; i <  array.Length; i++)
            {
                count += array[i].Length;
            }
            if (count % array.Length == 0)
            {
                b = true;
            }
            return b;
        }
        public bool CheckSumOrder(int[][] array)
        {
            bool b1 = true, b2 = true;
            int[] list = new int[array.Length];
            for (int i=0; i <  array.Length; i++)
            {
                for (int j=0; j < array[i].Length; j++)
                {
                    list[i] += array[i][j];
                }
            }
            for (int i=1; i <list.Length; i++)
            {
                if (list[i] <= list[i - 1])
                {
                    b1 = false;
                }
                if (list[i] >= list[i - 1])
                {
                    b2 = false;
                }
            }
            return b1 || b2;
        }
        public bool CheckArraysOrder(int[][] array)
        {
            bool b = false, b1 = true, b2 = true;
            for (int i=0; i < array.Length; i++)
            {
                b1 = true;
                b2 = true;
                for (int j = 1; j < array[i].Length; j++)
                {
                    if (array[i][j] < array[i][j - 1])
                    {
                        b1 = false;
                    }
                    if (array[i][j] > array[i][j - 1])
                    {
                        b2 = false;
                    }
                }
                if (b1 || b2)
                {
                    b = true;
                    break;
                }
            }
            return b;
        }
        public bool Task10(int[][] array, Predicate<int[][]> func)
        {
            bool res = false;

            // code here
            res = func(array);
            // end

            return res;
        }
    }
}
