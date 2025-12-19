namespace Lab6
{
    public class Blue
    {
        public void Task1(ref int[,] matrix)
        {
        
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
        
            if (rows != cols) return;
            
            int mx_i = FindDiagonalMaxIndex(matrix);
            RemoveRow(ref matrix, mx_i);
            // end
        
        }
        
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
        
            int mx = int.MinValue;
            int mx_i = -1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == j)
                    {
                        if (matrix[i, j] > mx)
                        {
                            mx = matrix[i, j];
                            mx_i = i;
                        }
                    }
                }
            }
        
            return mx_i;
        }
        
        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            int[,] nmatrix = new int[rows-1,cols];
        
            for (int i = 0; i < rows - 1; i++)
            {
                if (i < rowIndex)
                    for (int j = 0; j < cols; j++)
                    {
                        nmatrix[i, j] = matrix[i, j];
                    }
                else
                    for (int j = 0; j < cols; j++)
                    {
                        nmatrix[i, j] = matrix[i + 1, j];
                    }
            }
        
            matrix = nmatrix;
        }
        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing
        
            // code here
            double avgA = GetAverageExceptEdges(A);
            double avgB = GetAverageExceptEdges(B);
            double avgC = GetAverageExceptEdges(C);
        
            double[] array = new double[3];
        
            array[0] = avgA;
            array[1] = avgB;
            array[2] = avgC;
        
            for (int i = 0; i < array.Length; i++)
            {
                if ((array[0] < array[1]) && (array[1] < array[2])) return answer = 1;
                if ((array[0] > array[1]) && (array[1] > array[2])) return answer = -1;
                else return answer = 0;
            }
            // end
        
            return answer;
        }
        
        public double GetAverageExceptEdges(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
        
            double avg;
            int mx = int.MinValue;
            int mn = int.MaxValue;
            int sm = 0;
            int cnt = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sm += matrix[i, j];
                    cnt++;
                    
                    if (matrix[i, j] > mx)
                        mx = matrix[i, j];
                    if (matrix[i, j] < mn)
                        mn = matrix[i, j];
                }
            }
        
            sm = sm - mx - mn;
            cnt -= 2;
            avg = (sm * 1.0) / cnt;
            return avg;
        }
        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {
        
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != cols || rows == 0) return;

            int index = method(matrix);
            RemoveColumn(ref matrix, index);
            // end

        }

        public int FindUpperColIndex(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int mx_j = -1;
            int mx = int.MinValue;

            for (int i = 0; i < rows; i++)
            {
                for (int j = i + 1; j < cols; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        mx_j = j;
                    }
                }
            }
            
            return mx_j;
        }

        public int FindLowerColIndex(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int mx_j = -1;
            int mx = int.MinValue;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (j <= i)
                    {
                        if (matrix[i, j] > mx)
                        {
                            mx = matrix[i, j];
                            mx_j = j;
                        }
                    }
                }
            }
            return mx_j;
        }

        public void RemoveColumn(ref int[,] matrix, int col)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] nmatrix = new int[rows, cols-1];
            for (int i = 0; i < rows; i++)
            {
                int new_j = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j == col) continue;

                    nmatrix[i, new_j++] = matrix[i, j];
                }
            }
            matrix = nmatrix;
        }
        public void Task4(ref int[,] matrix)
        {
        
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = cols - 1; j >= 0; j--)
            {
                if (!CheckZerosInColumn(matrix, j))
                    RemoveColumn(ref matrix, j);
            }
            // end

        }

        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            bool answer = false;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, col] == 0) return answer = true;
            }

            return answer;
        }
        
        public void Task5(ref int[,] matrix, Finder find)
        {
        
            // code here
            int value = find(matrix, out _, out _);
            
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = rows - 1; i >= 0; i--)
            {
                bool flag = false;
                for (int j = cols - 1; j >= 0; j--)
                {
                    if (matrix[i, j] == value)
                    {
                        flag = true;
                    }
                }

                if (flag == true)
                {
                    RemoveRow(ref matrix, i);
                }
            }
            // end
        
        }

        public delegate int Finder(int[,] matrix, out int row, out int col);

        public int FindMax(int[,] matrix, out int row, out int col)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            row = 0;
            col = 0;
            int mx = int.MinValue;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            row = 0;
            col = 0;
            int mn = int.MaxValue;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            for (int i = 0; i < rows; i+=3)
            {
                sort(matrix, i);
            }
            // end
        
        }

        public delegate void SortRowsStyle(int[,] matrix, int row);

        public void SortRowAscending(int[,] matrix, int row)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);


            for (int i = 0; i < cols - 1; i++)
            {
                for (int j = 0; j < cols - 1 - i; j++)
                {
                    if (matrix[row, j] > matrix[row, j + 1])
                    {
                        (matrix[row, j], matrix[row, j+1]) = (matrix[row, j+1], matrix[row, j]);
                    }
                }
            }
        }
        
        public void SortRowDescending(int[,] matrix, int row)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);


            for (int i = 0; i < cols - 1; i++)
            {
                for (int j = 0; j < cols - 1 - i; j++)
                {
                    if (matrix[row, j] < matrix[row, j + 1])
                    {
                        (matrix[row, j], matrix[row, j+1]) = (matrix[row, j+1], matrix[row, j]);
                    }
                }
            }
        }
        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {
        
            // code here
            int rows = matrix.GetLength(0);
            int mx = 0;
            for (int i = 0; i < rows; i++)
            {
                mx = FindMaxInRow(matrix, i);
                transform(matrix, i, mx);
            }
            // end

        }

        public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);
        
        public int FindMaxInRow(int[,] matrix, int row)
        {
            int cols = matrix.GetLength(1);
            int mx = int.MinValue;
                
            for (int j = 0; j < cols; j++)
            {
                if (matrix[row, j] > mx)
                    mx = matrix[row, j];
            }

            return mx;
        }

        public void ReplaceByZero(int[,] matrix, int row, int maxValue)
        {
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                if (matrix[row, j] == maxValue)
                    matrix[row, j] = 0;
            }
        }

        public void MultiplyByColumn(int[,] matrix, int row, int maxValue)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            for (int j = 0; j < cols; j++)
            {
                if (matrix[row, j] == maxValue)
                    matrix[row, j] *= (j+1);
            }
        }
        
        public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
        {
        
            // code here
            double[,] answer = GetSumAndY(a, b, h, getSum, getY);
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
            double S = 1.0;
            double fact = 1.0;

            for (int i = 1; i <= 20; i++)
            {
                fact *= i;
                S += Math.Cos(i * x) / fact;
            }

            return S;
        }

        public double YA(double x)
        {
            return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
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
        
        public int Task9(int[,] matrix, GetTriangle triangle)
        {
            int answer = 0;
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows == cols)
            {
                answer = GetSum(triangle, matrix);
            }

            // end
        
            return answer;
        }

        public delegate int[] GetTriangle(int[,] matrix);

        public int Sum(int[] array)
        {
            int S = 0;
            foreach (int num in array)
                S += num * num;

            return S;
        }

        public int[] GetUpperTriangle(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int size = n * (n + 1) / 2;
            int[] result = new int[size];
            int k = 0;

            for (int i = 0; i < n; i++)
                for (int j = i; j < n; j++)
                    result[k++] = matrix[i, j];

            return result;
        }
        
        public int[] GetLowerTriangle(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int size = n * (n + 1) / 2;
            int[] result = new int[size];
            int k = 0;

            for (int i = 0; i < n; i++)
            for (int j = 0; j <= i; j++)
                result[k++] = matrix[i, j];

            return result;
        }
        
        
        public int GetSum(GetTriangle transformer, int[,] matrix)
        {
            int[] triangle = transformer(matrix);
            int S = Sum(triangle);
            
            return S;
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
            bool res = false;
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                count += array[i].Length;
            }

            if (count % array.Length == 0) res = true;
            return res;
        }

        public bool CheckSumOrder(int[][] array)
        {
            if (array.Length < 2) return true;
            bool res = false;
            int[] temp = new int[array.Length];
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    temp[k] += array[i][j];
                }
                k++;
            }

            for (int i = 0; i < temp.Length-1; i++)
            {
                if (temp[i] > temp[i + 1])
                {
                    res = true;
                }
                else
                {
                    res = false;
                    break;
                }
                
            }
            if (res) return res;
            for (int i = 0; i < temp.Length - 1; i++)
            {
                if (temp[i] < temp[i + 1])
                {
                    res = true;
                }
                else
                {
                    res = false;
                    break;
                }
            }
            return res;
        }

        public bool CheckArraysOrder(int[][] array)
        {
            
            bool res = false;
            for (int i = 0; i < array.Length; i++)
            {
                 if (array[i].Length < 2) return true;
                for (int j = 0; j < array[i].Length-1; j++)
                {
                    if (array[i][j] >= array[i][j+1])
                    {
                        res = true;
                    }
                    else
                    {
                        res = false;
                        break;
                    }
                    
                }
                if (res) return true;
                for (int j = 0; j < array[i].Length-1; j++)
                {
                    if (array[i][j] <= array[i][j+1])
                    {
                        res = true;
                    }
                    else
                    {
                        res = false;
                        break;
                    }
                    
                }
                if (res) return true;
            }
            return res;
        }
    }
    
    // ХОЧУ 20 баллов на КР-4 !!!
}
