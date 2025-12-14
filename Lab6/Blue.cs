namespace Lab6
{
    public class Blue
    {
        public void Task1(ref int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int imax = FindDiagonalMaxIndex(matrix);
                RemoveRow(ref matrix, imax);
            }
            // end

        }

        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int[,] tmp = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            for (int i = 0; i < tmp.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i < rowIndex)
                    {
                        tmp[i, j] = matrix[i, j];
                    }
                    else
                    {
                        tmp[i, j] = matrix[i + 1, j];
                    }
                }
            }

            matrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = tmp[i, j];
                }
            }
        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int imax = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > matrix[imax, imax])
                {
                    imax = i;
                }
            }

            return imax;
        }
        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

            // code here
            double averageA = GetAverageExceptEdges(A);
            double averageB = GetAverageExceptEdges(B);
            double averageC = GetAverageExceptEdges(C);
            
            if (averageA > averageB && averageB > averageC)
            {
                answer = -1;
            }
            else if (averageA < averageB && averageB < averageC)
            {
                answer = 1;
            }
            // end

            return answer;
        }

        public double GetAverageExceptEdges(int[,] matrix)
        {
            int max_elem = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max_elem)
                    {
                        max_elem = matrix[i, j];
                    }
                }
            }

            int min_elem = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min_elem)
                    {
                        min_elem = matrix[i, j];
                    }
                }
            }

            double tb = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != max_elem && matrix[i, j] != min_elem)
                    {
                        tb += matrix[i, j];
                    }
                }
            }

            tb = tb / (matrix.Length - 2);
            return tb;
        }
        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int col = method(matrix);
                RemoveCol(ref matrix, col);
            }
            // end

        }

        public void RemoveCol(ref int[,] matrix, int col)
        {
            int[,] tmp = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
            for (int i = 0; i < tmp.GetLength(0); i++)
            {
                for (int j = 0; j < tmp.GetLength(1); j++)
                {
                    if (j < col)
                    {
                        tmp[i, j] = matrix[i, j];
                    }
                    else
                    {
                        tmp[i, j] = matrix[i, j + 1];
                    }
                }
            }

            matrix = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = tmp[i, j];
                }
            }
        }
        public int FindLowerColIndex(int[,] matrix)
        {
            int imax = 0, jmax = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (matrix[i, j] > matrix[imax, jmax])
                    {
                        imax = i;
                        jmax = j;
                    }
                }
            }

            return jmax;
        }
        public int FindUpperColIndex(int[,] matrix)
        {
            int imax = 0, jmax = 1;
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[imax, jmax])
                    {
                        imax = i;
                        jmax = j;
                    }
                }
            }

            return jmax;
        }
        public void Task4(ref int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(1);
            for (int j = 0; j < n; j++)
            {
                if (!(CheckZerosInColumn(matrix, j)))
                {
                    RemoveCol(ref matrix,j);
                    n--;
                    j--;
                }
            }
            // end

        }

        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            bool check = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] == 0)
                {
                    check = true;
                    break;
                }
            }

            return check;
        }
        public void Task5(ref int[,] matrix, Finder find)
        {

            // code here
            int row, col;
            int elem = find(matrix, out row, out col);
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == elem)
                    {
                        RemoveRow(ref matrix,i);
                        n--;
                        i--;
                        break;
                    }
                }
            }
            // end

        }

        public delegate int Finder(int[,] matrix, out int row, out int col);

        public int FindMax(int[,] matrix, out int row, out int col)
        {
            int max_elem = matrix[0, 0];
            row = 0;
            col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[row, col])
                    {
                        max_elem = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }

            return max_elem;
        }

        public int FindMin(int[,] matrix, out int row, out int col)
        {
            int min_elem = matrix[0, 0];
            row = 0;
            col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < matrix[row, col])
                    {
                        min_elem = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }

            return min_elem;
        }
        public void Task6(int[,] matrix, SortRowsStyle sort)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i += 3)
            {
                sort(matrix, i);
            }
            // end

        }
        public delegate void SortRowsStyle(int[,] matrix, int row);

        public void SortRowAscending(int[,] matrix, int row)
        {
            int j = 0;
            while (j < matrix.GetLength(1))
            {
                if (j == 0 || matrix[row, j] >= matrix[row, j - 1])
                {
                    j++;
                }
                else
                {
                    int tmp = matrix[row, j];
                    matrix[row, j] = matrix[row, j - 1];
                    matrix[row, j - 1] = tmp;
                    j--;
                }
            }
        }

        public void SortRowDescending(int[,] matrix, int row)
        {
            int j = 0;
            while (j < matrix.GetLength(1))
            {
                if (j == 0 || matrix[row, j] <= matrix[row, j - 1])
                {
                    j++;
                }
                else
                {
                    int tmp = matrix[row, j];
                    matrix[row, j] = matrix[row, j - 1];
                    matrix[row, j - 1] = tmp;
                    j--;
                }
            }
        }
        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max_elem = FindMaxInRow(matrix, i);
                transform(matrix,i,max_elem);
            }
            // end

        }

        public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);

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
        public int FindMaxInRow(int[,] matrix, int row)
        {
            int jmax = 0;
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > matrix[row, jmax])
                {
                    jmax = j;
                }
            }

            return matrix[row,jmax];
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
            int n = (int)((b - a) / h + 1);
            double[,] ans = new double[n, 2];
            int i = 0;
            for (double x = a; x <= b + 0.0001; x += h)
            {
                ans[i, 0] = sum(x);
                ans[i, 1] = y(x);
                i++;
            }

            return ans;
        }
        public double SumA(double x)
        {
            double s = 1;
            double a = x, b = 1;
            int i = 1;
            while (true)
            {
                double tmp = Math.Cos(a) / b;
                s += tmp;
                if (Math.Abs(tmp) < 0.0001) break;
                a += x;
                b *= (i + 1);
                i++;
            }

            return s;
        }

        public double YA(double x)
        {
            return Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x));
        }

        public double SumB(double x)
        {
            double s = -2*Math.PI*Math.PI/3;
            double a = -1, b = x, c = 1;
            while (true)
            {
                double tmp = a * Math.Cos(b) / (c * c);
                s += tmp;
                if (Math.Abs(tmp) < 0.000001) break;
                b += x;
                a *= -1;
                c++;
            }
            return s;
        }

        public double YB(double x)
        {
            return (x * x) / 4 - 3*(Math.PI * Math.PI) / 4;
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

        public delegate int[] GetTriangle(int[,] matrix);

        public int Sum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i] * array[i];
            }

            return sum;
        }
        public int GetSum(GetTriangle transformer, int[,] matrix)
        {
            int[] array = transformer(matrix);
            return Sum(array);
        }
        public int[] GetUpperTriangle(int[,] matrix)
        {
            int n = 0;
            for (int i = 1; i <= matrix.GetLength(0); i++)
            {
                n += i;
            }

            int[] ans = new int[n];
            int i1 = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = i; j < matrix.GetLength(1); j++)
                {
                    ans[i1] = matrix[i, j];
                    i1++;
                }
            }

            return ans;
        }

        public int[] GetLowerTriangle(int[,] matrix)
        {
            int n = 0;
            for (int i = 1; i <= matrix.GetLength(0); i++)
            {
                n += i;
            }

            int[] ans = new int[n];
            int i1 = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    ans[i1] = matrix[i, j];
                    i1++;
                }
            }

            return ans;
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
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                count += array[i].Length;
            }

            if (count % array.Length == 0) return true;
            return false;
        }

        public bool CheckSumOrder(int[][] array)
        {
            int[] tmp = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }

                tmp[i] = sum;
            }

            bool check1 = true;
            for (int i = 1; i < tmp.Length-1; i++)
            {
                if (!(tmp[i] > tmp[i - 1] && tmp[i] < tmp[i + 1]))
                {
                    check1 = false;
                    break;
                }
            }

            bool check2 = true;
            for (int i = 1; i < tmp.Length - 1; i++)
            {
                if (!(tmp[i] > tmp[i + 1] && tmp[i] < tmp[i - 1]))
                {
                    check2 = false;
                    break;
                }
            }

            if (check1 || check2) return true;
            return false;
        }

        public bool CheckArraysOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                bool check1 = true;
                for (int j = 1; j < array[i].Length - 1; j++)
                {
                    if (!(array[i][j] >= array[i][j - 1] && array[i][j] <= array[i][j + 1]))
                    {
                        check1 = false;
                        break;
                    }
                }

                bool check2 = true;
                for (int j = 1; j < array[i].Length - 1; j++)
                {
                    if (!(array[i][j] >= array[i][j + 1] && array[i][j] <= array[i][j - 1]))
                    {
                        check2 = false;
                        break;
                    }
                }

                if (check1 || check2) return true;
            }

            return false;
        }
    }
}
