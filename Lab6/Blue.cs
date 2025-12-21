namespace Lab6
{
    public delegate int Finder(int[,] matrix, out int row, out int col);
    public delegate void SortRowsStyle(int[,] matrix, int row);
    public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);
    public delegate int[] GetTriangle(int[,] matrix);
    public class Blue
    { 
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int maxxInd = 0;
            int maxx = Int32.MinValue;
            if (n == m)
            {
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, i] > maxx)
                    {
                        maxx = matrix[i, i];
                        maxxInd = i;
                    }
                }
            }
            return maxxInd;
        }
        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] matrix2 = new int[n - 1, m];
            for (int i = 0; i < rowIndex; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix2[i, j] = matrix[i, j];
                }
            }
            for (int i = rowIndex; i < n - 1; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix2[i, j] = matrix[i + 1, j];
                }
            }

            matrix = matrix2; 
        }

        public double GetAverageExceptEdges(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int minn = Int32.MaxValue;
            int maxx = Int32.MinValue;
            int sum = 0;
            int count = n * m - 2;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < minn) minn = matrix[i, j];
                    if (matrix[i, j] > maxx) maxx = matrix[i, j];
                    sum += matrix[i, j];
                } 
            }

            sum -= minn; sum -= maxx;
            double srZnach = (double)sum / count;
            return srZnach;
        }

        public int FindUpperColIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int maxx = Int32.MinValue;
            int maxj = 0;
            if (n == m)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (matrix[i, j] > maxx)
                        {
                            maxx = matrix[i, j]; maxj = j;
                        }
                    }
                }
            }

            return maxj;
        }
        public int FindLowerColIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int maxx = Int32.MinValue;
            int maxj = 0;
            if (n == m)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        if (matrix[i, j] > maxx)
                        {
                            maxx = matrix[i, j]; maxj = j;
                        }
                    }
                }
            }

            return maxj;
        }

        public void RemoveColumn(ref int[,] matrix, int col)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] matrix2 = new int[n, m - 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix2[i, j] = matrix[i, j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = col; j < m - 1; j++)
                {
                    matrix2[i, j] = matrix[i, j + 1];
                }
            }
            matrix = matrix2;
        }

        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] == 0) return true;
            }

            return false;
        }
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            int max = matrix[0, 0];
            row = 0;
            col = 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            return max;
        }
        public int FindMin(int[,] matrix, out int row, out int col)
        {
            int min = matrix[0, 0];
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            row = 0;
            col = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            return min;
        }
        public void Task1(ref int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == m)
            {
                int rowIndex = FindDiagonalMaxIndex(matrix);
                RemoveRow(ref matrix, rowIndex);
            }
            // end

        }

        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

            // code here
            double[] matrix = new double[3];
            matrix[0] = GetAverageExceptEdges(A);
            matrix[1] = GetAverageExceptEdges(B);
            matrix[2] = GetAverageExceptEdges(C);
            if (matrix[0] > matrix[1] && matrix[1] > matrix[2])
            {
                answer = -1;
            }
            else if (matrix[0] < matrix[1] && matrix[1] < matrix[2])
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
        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == m)
            {
                int colToRemove = method(matrix);
                RemoveColumn(ref matrix, colToRemove);
            }
            // end

        }
        public void Task4(ref int[,] matrix)
        {

            // code here
            int m = matrix.GetLength(1);
            for (int j = m - 1; j >= 0; j--)
            {
                if (!CheckZerosInColumn(matrix, j))
                {
                    RemoveColumn(ref matrix, j);
                }
            }
            // end

        }
        public void Task5(ref int[,] matrix, Finder find)
        {

            // code here
            int FindElement = find(matrix, out int row, out int col);
            int index = -1;
            int i = 0;
            while (i < matrix.GetLength(0))
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == FindElement && index == -1)
                    {
                        index = i;
                    }
                }
                if (index == -1)
                {
                    i++;
                }
                else
                {
                    RemoveRow(ref matrix, index);
                    index = -1;
                }
            }
            // end

        }

        public void SortRowAscending(int[,] matrix, int row)
        {
            int[] array = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                array[i] =  matrix[row, i];
            }
            Array.Sort(array);
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[row, i] = array[i];
            }
        }
        public void SortRowDescending(int[,] matrix, int row)
        {
            int[] array = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                array[i] =  matrix[row, i];
            }
            Array.Sort(array);
            Array.Reverse(array);
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[row, i] = array[i];
            }
        }
        public void Task6(int[,] matrix, SortRowsStyle sort)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 3 == 0)
                {
                    sort(matrix, i);
                }
            }
            // end

        }

        public int FindMaxInRow(int[,] matrix, int row)
        {
            int max = Int32.MinValue;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > max) max = matrix[row, j];
            }

            return max;
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
        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                transform(matrix, i, FindMaxInRow(matrix, i));
            }
            // end

        }
        public double SumA(double x)
        {
            double S = 1, del = 1;
            for (int i = 1; i <= 10; i++)
            {
                del *= i;
                S += (Math.Cos(i * x) / del);
            }
            return S;
        }

        public double YA(double x)
        {
            return (Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x)));
        }

        public double SumB(double x)
        {
            double S = -2.0 * Math.PI * Math.PI / 3.0, sign = 1, t = 1;
            for (int i = 1; Math.Abs(t) >= 0.000001; i++)
            {
                sign *= -1;
                t = sign * (Math.Cos(i * x) / (i * i));
                S += t;
            }
            return S;
        }

        public double YB(double x)
        {
            return (((x * x) / 4) - (3 * (Math.PI * Math.PI) / 4));
        }

        public double[,] GetSumAndY(double a, double b, double h, Func<double, double> sum, Func<double, double> y)
        {
            int count = 0;
            for (double x = a; x <= b; x = Math.Round(x + h, 7))
                count++;
            double[,] arr2 = new double[count, 2];
            count = 0;
            for (double x = a; x <= b; x = Math.Round(x + h, 7))
                (arr2[count, 0], arr2[count++, 1]) = (sum(x), y(x));
            return arr2;
        }

        public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
        {
            double[,] answer = null;

            // code here
            answer = GetSumAndY(a, b, h, getSum, getY);
            // end

            return answer;
        }

        public int Sum(int[] array)
        {
            int sq = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sq += array[i] *  array[i];
            }

            return sq;
        }

        public int[] GetUpperTriangle(int[,] matrix)
        {
            int count = 0;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i <= j) count++;
                }
            }
            int[] array = new int[count];
            count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i <= j) array[count++] = matrix[i, j];
                }
            }
            return array;
        }
        public int[] GetLowerTriangle(int[,] matrix)
        {
            int count = 0;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i >= j) count++;
                }
            }
            int[] array = new int[count];
            count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i >= j) array[count++] = matrix[i, j];
                }
            }
            return array;
        }
        public int Task9(int[,] matrix, GetTriangle triangle)
        {
            int answer = 0;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == m)
            {
                answer = Sum(triangle(matrix));
            }
            // end

            return answer;
        }
        
        public delegate bool Predicate(int[][] array);

        public bool CheckTransformAbility(int[][] array)
        {
            bool flag = false;
            double count = 0;
            for (int i = 0; i < array.Length; i++)
                count += array[i].Length;
            count /= array.Length;
            if (Math.Floor(count) == count)
                flag = true;
            return flag;
        }

        public bool CheckSumOrder(int[][] array)
        {
            bool f = false;
            int[] array1 = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }
                array1[i] = sum;
            }
            int count = 0;
            for (int i = 1; i < array1.Length; i++)
            {
                if (array1[i - 1] > array1[i]) count++;
            }

            if (count == array1.Length - 1) f = true;
            count = 0;
            for (int i = 1; i < array1.Length; i++)
            {
                if (array1[i] > array1[i - 1]) count++;
            }
            if (count == array1.Length - 1) f = true;
            return f;
        }

        public bool CheckArraysOrder(int[][] array)
        {
            bool f = false;
            for (int i = 0; i < array.Length; i++)
            {
                int count = 0;
                int[] A = new int[array[i].Length];
                A = array[i];
                for (int j = 1; j < A.Length; j++)
                {
                    if (A[j - 1] > A[j]) count++;
                }

                if (count == A.Length - 1) f = true;
                count = 0;
                for (int j = 1; j < A.Length; j++)
                {
                    if (A[j] > A[j - 1]) count++;
                }
                if (count == A.Length - 1) f = true;
            }
            return f;
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