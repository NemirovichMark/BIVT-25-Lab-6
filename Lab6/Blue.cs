using System.Data;
using System.Net.Sockets;
using System.Numerics;

namespace Lab6
{
    public class Blue
    {
        public void Task1(ref int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int imx = FindDiagonalMaxIndex(matrix);
                RemoveRow(ref matrix, imx);
            }


            // end

        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int imx = -1;
            int mx = -10000;
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, i] > mx)
                    {
                        mx = matrix[i, i];
                        imx = i;
                    }
                }
            }
            return imx;
        }
        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int[,] matrix1 = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    if (i < rowIndex)
                    {
                        matrix1[i, j] = matrix[i, j];
                    }
                    else
                    {
                        matrix1[i, j] = matrix[i + 1, j];
                    }
                }
            }
            matrix = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix1[i, j];
                }
            }


        }
        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 2; ; // 1 - increasing   0 - no sequence   -1 - decreasing

            // code here
            double[] arr = new double[3];
            arr[0] = GetAverageExceptEdges(A);
            arr[1] = GetAverageExceptEdges(B);
            arr[2] = GetAverageExceptEdges(C);
            int c1 = 0;
            int c2 = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    c1++;
                }
                if (arr[i] < arr[i + 1])
                {
                    c2++;
                }
            }
            if (c1 == 2)
            {
                answer = -1;
            }
            else if (c2 == 2)
            {
                answer = 1;
            }
            else
            {
                answer = 0;
            }
            // end

            return answer;
        }
        public double GetAverageExceptEdges(int[,] matrix)
        {
            int mx = -1000;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                    }
                }
            }
            double sr = 0;
            double sum = 0;
            double c = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                    c++;
                }
            }
            sum -= mx;
            sr = sum / c;
            return sr;
        }

        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int a = method(matrix);
                RemoveCol(ref matrix, a);

            }
           
            // end

        }
        public  void RemoveCol(ref int[,] matrix, int col)
        {
            int[,] matrix1 = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
            for (int j = 0; j < matrix1.GetLength(1); j++)
            {
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    if (j < col)
                    {
                        matrix1[i, j] = matrix[i, j];
                    }
                    else
                    {
                        matrix1[i, j] = matrix[i, j + 1];
                    }
                }
            }
            matrix = matrix1;
        }
        public int FindUpperColIndex(int[,] matrix)
        {
            int jmx = -1;
            int mx = -10000;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j > i)
                    {
                        if (matrix[i, j] > mx)
                        {
                            mx = matrix[i, j];

                            jmx = j;
                        }
                    }
                }
            }
            return jmx;
        }
        public int FindLowerColIndex(int[,] matrix)
        {
            int jmx = -1;
            int mx = -10000;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j <= i)
                    {
                        if (matrix[i, j] > mx)
                        {
                            mx = matrix[i, j];

                            jmx = j;
                        }
                    }
                }
            }
            return jmx;
        }
        public void Task4(ref int[,] matrix)
        {

            // code here
            RemoveCol(ref matrix);
            // end

        }
        public static bool CheckZerosInColumn(int[,] matrix, int col)
        {
            int c = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] == 0)
                {
                    c++;
                }

            }
            if (c == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void RemoveCol(ref int[,] matrix)
        {
            int c = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (CheckZerosInColumn(matrix, j) == true)
                {
                    c++;
                }
            }

            int[,] matrix1 = new int[matrix.GetLength(0), c];
            int k = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (CheckZerosInColumn(matrix, j) == true)
                    {
                        matrix1[i, k] = matrix[i, j];
                    }
                }
                if (CheckZerosInColumn(matrix, j) == true)
                {
                    k++;
                }

            }
            matrix = matrix1;

        }


        public void Task5(ref int[,] matrix, Finder find)
        {

            // code here
            RemoveRow(ref matrix, find);
            // end

        }
        public delegate int Finder( int[,] matrix, out int row, out int col);
        public delegate int FindElement(int[,] matrix, out int row, out int col);
        public void RemoveRow(ref int[,] matrix, Finder find)
        {
            int row = 0;
            int col = 0;
            int mx = find(matrix,out row , out col);
            int k = 0;
            int[] answer;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int c = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == mx)
                    {
                        c++;
                    }

                }
                if (c == 0)
                {
                    k++;
                }
            }
            answer = new int[k];
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int c = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == mx)
                    {
                        c++;
                    }

                }
                if (c == 0)
                {
                    answer[count++] = i;
                }
            }
            int[,] matrix1 = new int[k, matrix.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    matrix1[i, j] = matrix[answer[i], j];
                }
            }
            matrix = matrix1;
        }
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            int mx = -1000;
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
            int mn = 1000;
            row = 0;
            col = 0;
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
        public void Task6(int[,] matrix, SortRowsStyle sort)
        {

            // code here
            int row = 1;
            sort(matrix, row);
            // end

        }
        public delegate void SortRowsStyle(int[,] matrix, int row);
        public void SortRowAscending(int[,] matrix, int row)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if ((i) % 3 == 0 || i == 0)
                {
                    for (int K = 0; K < matrix.GetLength(1); K++)
                    {
                        for (int j = 1; j < matrix.GetLength(1); j++)
                        {
                            if (matrix[i, j - 1] > matrix[i, j])
                            {
                                (matrix[i, j - 1], matrix[i, j]) = (matrix[i, j], matrix[i, j - 1]);
                            }
                        }
                    }
                }
            }
        }
        public void SortRowDescending(int[,] matrix, int row)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if ((i) % 3 == 0 || i == 0)
                {
                    for (int K = 0; K < matrix.GetLength(1); K++)
                    {
                        for (int j = 1; j < matrix.GetLength(1); j++)
                        {
                            if (matrix[i, j - 1] < matrix[i, j])
                            {
                                (matrix[i, j - 1], matrix[i, j]) = (matrix[i, j], matrix[i, j - 1]);
                            }
                        }
                    }
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
        public delegate void ReplaceMaxElements (int[,] matrix, int row, int maxValue);
        public int FindMaxInRow(int[,] matrix, int row)
        {
            int mx = -1000;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > mx)
                {
                    mx = matrix[row, j];
                }
            }
            return mx;
        }
        public  void ReplaceByZero(int[,] matrix, int row, int maxValue)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] == maxValue)
                {
                    matrix[row, j] = 0;
                }
            }
        }
        public  void MultiplyByColumn(int[,] matrix, int row, int maxValue)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] == maxValue)
                {
                    matrix[row, j] = matrix[row, j] * (j+1);
                }
            }
        }

        public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
        {
            double[,] answer = null;

            // code here
            answer = answer = GetSumAndY(a, b, h, getSum, getY);
            // end

            return answer;
        }
        public double[,] GetSumAndY(double a, double b, double h, Func<double, double> sum, Func<double, double> y)
        {
            if (sum == null || y == null) return null;
            if (h == 0) return null;
            if (a < b && h < 0) h = -h;
            if (a > b && h > 0) h = -h;
            double steps = (b - a) / h;
            int n = (int)Math.Round(steps) + 1;
            if (n <= 0) return null;
            double[,] res = new double[n, 2];
            for (int i = 0; i < n; i++)
            {
                double x = a + i * h;
                res[i, 0] = sum(x);
                res[i, 1] = y(x);
            }
            return res;
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
        public double YA(double x)
        {
            return Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x));
        }
        public double SumB(double x)
        {
            double s = -2.0 * Math.PI * Math.PI / 3.0;
            for (double i = 1; ; i += 1.0)
            {
                double sign = (i % 2 == 0) ? 1.0 : -1.0;
                s += sign * Math.Cos(i * x) / (i * i);
                if (Math.Abs(sign * Math.Cos(i * x) / (i * i)) < 0.000001) break;
            }
            return s;
        }
        public double YB(double x)
        {
            return (x * x) / 4.0 - 3.0 * (Math.PI * Math.PI) / 4.0;
        }
        //9


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
        public delegate int[] GetTriangle(int[,] matrix);
        public int GetSum(GetTriangle transformer, int[,] matrix)
        {
            int answer = 0;
            int[] arr = transformer(matrix);
            for (int i = 0; i < arr.Length; i++)
            {
                answer += arr[i] * arr[i];
            }
            return answer;
        }
        public int[] GetUpperTriangle(int[,] matrix)
        {
            int c = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j >= i)
                    {
                        c++;
                    }
                }
            }
            int[] matrix1 = new int[c];
            int k = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j >= i)
                    {
                        matrix1[k++] = matrix[i, j];

                    }
                }

            }
            return matrix1;
        }
        public int[] GetLowerTriangle(int[,] matrix)
        {
            int c = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j <= i)
                    {
                        c++;
                    }
                }
            }
            int[] matrix1 = new int[c];
            int k = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j <= i)
                    {
                        matrix1[k++] = matrix[i, j];

                    }
                }

            }
            return matrix1;
        }
        public bool Task10(int[][] array, Predicate<int[][]> func)
        {
            bool res = false;

            // code here
            res = func(array);
            // end

            return res;
        }
        public bool CheckTransformAbility(int[][] array)
        {
            double c = 0;
            for (int i = 0; i < array.Length; i++)
            {
                c += array[i].Length;
            }
            double b = c / array.Length;
            if (Math.Floor(b) == Math.Ceiling(b))
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        public bool CheckSumOrder(int[][] array)
        {

            int[] answer = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    answer[i] += array[i][j];
                }
            }
            int c = 0;
            int k = 0;
            for (int i = 1; i < answer.Length; i++)
            {
                if (answer[i] > answer[i - 1])
                {
                    c++;
                }
                if (answer[i] < answer[i - 1])
                {
                    k++;
                }
            }
            if (c == (answer.Length - 1) || k == (answer.Length - 1))
            {
                return true;
            }
            else { return false; }
        }
        public bool CheckArraysOrder(int[][] array)
        {
            int itog = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int c = 0;
                int c1 = 0;
                for (int j = 1; j < array[i].Length; j++)
                {
                    if (array[i][j - 1] > array[i][j])
                    {
                        c++;
                    }
                    if (array[i][j - 1] < array[i][j])
                    {
                        c1++;
                    }
                }
                if ((c == array[i].Length - 1) || (c1 == array[i].Length - 1))
                {
                    itog++;
                }

            }
            if (itog > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
