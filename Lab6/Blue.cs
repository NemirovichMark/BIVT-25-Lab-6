namespace Lab6
{
    public class Blue
    {
        public void Task1(ref int[,] matrix)
        {

            // code here

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            } 
            int maxel_ind = FindDiagonalMaxIndex(matrix);
            Console.WriteLine(maxel_ind);
            RemoveRow(ref matrix, maxel_ind);

            // end

        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int maxel = int.MinValue;
            int k = 0;
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] > maxel)
                {
                    maxel = matrix[i, i];
                    k = i;
                }
            }
            return k;
        }
        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int index = 0;

            int[,] answer = new int[n - 1, m];

            for (int i = 0; i < n; i++)
            {
                if (i == rowIndex) continue; 

                for (int j = 0; j < m; j++)
                {
                    answer[index, j] = matrix[i, j];
                }
                index++;
            }

            matrix = answer; 
        }
        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

            // code here


            double avg1 = GetAverageExceptEdges(A);

            double avg2 = GetAverageExceptEdges(B);

            double avg3 = GetAverageExceptEdges(C);

            double[] array = new double[] { avg1, avg2, avg3 };

            if (array[0] > array[1] && array[1] > array[2])
            {
                answer = -1;
            }
            else if (array[0] < array[1] && array[1] < array[2])
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
            int s = 0;
            int maxel = int.MinValue;
            int minel = int.MaxValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxel)
                    {
                        maxel = matrix[i, j];
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minel)
                    {
                        minel = matrix[i, j];
                    }
                }
            }


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != maxel && matrix[i, j] != minel)
                    {
                        s += matrix[i, j];
                    }
                }
            }

            double avg = (double)s / (matrix.GetLength(0) * matrix.GetLength(1) - 2);
            return avg;
        }
        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }

            int col = method(matrix);
            RemoveCol(ref matrix, col);
            // end

        }
        public int FindUpperColIndex(int[,] matrix)
        {
            int k = 0;
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int maxel = int.MinValue;
            for (int i = 0; i < m; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    if (matrix[i, j] > maxel)
                    {
                        maxel = matrix[i, j];
                        k = j;
                    }
                }
            }
            return k;
        }
        public int FindLowerColIndex(int[,] matrix)
        {
            int k = 0;
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int maxel = int.MinValue;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (matrix[i, j] > maxel)
                    {
                        maxel = matrix[i, j];
                        k = j;
                    }
                }
            }
            return k;
        }
        public void RemoveCol(ref int[,] matrix, int col)
        {


            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);


            int[,] answer = new int[rows, cols - 1];

            for (int i = 0; i < rows; i++)
            {
                int index = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j == col) continue;
                    {
                        answer[i, index] = matrix[i, j];
                        index++;
                    }
                }
            }

            // Заменяем исходную матрицу новой
            matrix = answer;
        }
        public void Task4(ref int[,] matrix)
        {

            // code here
            int m = matrix.GetLength(1);

            bool flag = true;

            for (int j = m - 1; j >= 0; j--)
            {
                flag = CheckZerosInColumn(matrix, j);
                if (!flag)
                {
                    RemoveCol(ref matrix, j);
                }
            }
            // end

        }
        public bool
        CheckZerosInColumn(int[,] matrix, int col)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, col] == 0)
                {
                    return true;
                }
            }
            return false;
        }
        public void Task5(ref int[,] matrix, Finder find)
        {

            // code here

            int m, n;
            int targetValue = find(matrix, out m, out n);

            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == targetValue)
                    {
                        RemoveRow(ref matrix, i);
                        break; 
                    }
                }
            }
            //end
        }
        public delegate int Finder(int[,] matrix, out int row, out int col);

        public int FindMax(int[,] matrix, out int row, out int col)
        {
            int maxel = int.MinValue;
            row = 0;
            col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxel)
                    {
                        maxel = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            return maxel;
        }


        public int FindMax(int[,] matrix)
        {
            int row;
            int col;
            return FindMax(matrix, out row, out col);
        }

        public int FindMin(int[,] matrix, out int row, out int col)
        {
            int minel = int.MaxValue;
            row = 0;
            col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minel)
                    {
                        minel = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            return minel;
        }
        public int FindMin(int[,] matrix)
        {
            int row;
            int col;
            return FindMin(matrix, out row, out col);
        }
        public void Task6(int[,] matrix, SortRowsStyle sort)
        {

            // code here
            int rows = matrix.GetLength(0);

            for (int i = 0; i < rows; i += 3)
            {
                sort(matrix, i);
            }
            // end

        }
        public delegate void SortRowsStyle(int[,] matrix, int row);

        public void SortRowAscending(int[,] matrix, int row)
        {
            int n = matrix.GetLength(1);
            int[] buffer = new int[n];

            for (int j = 0; j < n; j++)
            {
                buffer[j] = matrix[row, j];
            }

            Array.Sort(buffer);

            for (int j = 0; j < n; j++)
            {
                matrix[row, j] = buffer[j];
            }
        }

        public void SortRowDescending(int[,] matrix, int row)
        {
            int n = matrix.GetLength(1);
            int[] buffer = new int[n];

            for (int j = 0; j < n; j++)
            {
                buffer[j] = matrix[row, j];
            }

            Array.Sort(buffer);
            Array.Reverse(buffer);

            for (int j = 0; j < n; j++)
            {
                matrix[row, j] = buffer[j];
            }
        }
        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {

            // code here

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int z = FindMaxInRow(matrix, i);
                transform(matrix, i, z);
            }
            // end
        }
        public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);
        public int FindMaxInRow(int[,] matrix, int row)
        {
            int maxel = int.MinValue;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > maxel)
                {
                    maxel = matrix[row, j];
                }
            }
            return maxel;
        }
        public void ReplaceByZero(int[,] matrix, int row, int maxValue)
        {

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] == maxValue)
                {
                    matrix[row, j] = 0;
                }
            }
        }
        public void MultiplyByColumn(int[,] matrix, int row, int maxValue)
        {

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] == maxValue)
                {
                    matrix[row, j] *= (j + 1);
                }
            }
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

            if (a < b && h < 0)  
                h = -h;
            if (a > b && h > 0) 
                h = -h;

            double steps = (b - a) / h;
            int n = (int)Math.Round(steps) + 1;
            if (n <= 0) return null;

            double[,] mat = new double[n, 2];

            for (int i = 0; i < n; i++)
            {
                double x = a + i * h;
                mat[i, 0] = sum(x);
                mat[i, 1] = y(x);
            }

            return mat;

        }
        public double SumA(double x)
        {
            double s = 1;
            double d = 1;

            for (int i = 1; i <= 10; i++)
            {
                d *= i;
                s += Math.Cos(i * x) / d;
            }
            return s;
        }
        public double YA(double x)
        {
            return (Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x)));
        }
        public double SumB(double x)
        {
            double s = -2 * Math.PI * Math.PI / 3;

            for (double i = 1; ; i += 1.0)
            {
                double p;
                if (i % 2 == 0)
                {
                    p = 1;
                }
                else
                {
                    p = -1;
                }
                s += p * Math.Cos(i * x) / (i * i);

                if (Math.Abs(p * Math.Cos(i * x) / (i * i)) < 0.000001) break;
            }

            return s;
        }
        public double YB(double x)
        {
            return (x * x) / 4.0 - 3.0 * (Math.PI * Math.PI) / 4.0;
        }
        public int Task9(int[,] matrix, GetTriangle triangle)
        {
            int answer = 0;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return 0 ;
            }
            answer = GetSum(triangle, matrix);
            // end

            return answer;
        }
        public delegate int[] GetTriangle(int[,] matrix);
        public int Sum(int[] array)
        {
            if (array == null)
                return 0;
            int s = 0;

            for (int i = 0; i < array.Length; i++)
            {
                s += array[i] * array[i];
            }

            return s;
        }
        public int GetSum(GetTriangle transformer, int[,] matrix)
        {

            int[] array = transformer(matrix);
            int s = Sum(array);

            return s;
        }
        public int[] GetUpperTriangle(int[,] matrix)
        {

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int cnt = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    cnt++;
                }
            }

            int[] array = new int[cnt];
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
            int count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    count++;
                }
            }

            int[] array = new int[count];
            int n = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    array[n] = matrix[i, j];
                    n++;
                }
            }

            return array;
        }
        public bool Task10(int[][] array, Predicate<int[][]> func)
        {
            bool res = false;

            // code here
            if (array == null || func == null)
            {
                return res;
            }
            res = func(array);
            // end

            return res;
        }
        public delegate int Predicate(int[][] array);
        public bool CheckTransformAbility(int[][] array)
        {
            int all = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    return false;
                }

                all += array[i].Length;
            }

            return all % array.Length == 0;
        }

        public bool CheckSumOrder(int[][] array)
        {
            int[] s = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    return false;
                }

                int curs = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    curs += array[i][j];
                }

                s[i] = curs;
            }

            bool m = true;
            bool n = true;
            for (int i = 1; i < array.Length; i++)
            {
                if (s[i - 1] >= s[i])
                {
                    m = false;
                }

                if (s[i - 1] <= s[i])
                {
                    n = false;
                }
            }

            return m || n;
        }

        public bool CheckArraysOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int[] current = array[i];
                if (current == null)
                {
                    return false;
                }

                if (current.Length <= 1)
                {
                    return true;
                }

                bool m = true;
                bool n = true;
                for (int j = 1; j < current.Length; j++)
                {
                    if (current[j - 1] >= current[j])
                    {
                        m = false;
                    }

                    if (current[j - 1] <= current[j])
                    {
                        n = false;
                    }
                }

                if (m || n)
                {
                    return true;
                }
            }

            return false;
        }
        public void RemoveColumn(ref int[,] matrix, int col)
        {

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int c = cols - 1;
            if (c < 0)
            {
                c = 0;
            }

            int[,] mat = new int[rows, c];
            for (int i = 0; i < rows; i++)
            {
                int newCol = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j == col)
                    {
                        continue;
                    }

                    mat[i, newCol] = matrix[i, j];
                    newCol++;
                }
            }

            matrix = mat;
        }


    }
}