namespace Lab6
{
    public class Blue
    {
        public void Task1(ref int[,] matrix)
        {

            // code here
            int n  = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == m)
            {
                int rowIndex = FindDiagonalMaxIndex(matrix);
                RemoveRow(ref matrix, rowIndex);
            }
            // end

        }

        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int maxElement = int.MinValue;
            int rowIndex = 0;

            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] > maxElement)
                {
                    maxElement = matrix[i, i];
                    rowIndex = i;
                }
            }
            
            return rowIndex;
        }

        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int[,] answer = new int[ matrix.GetLength(0) - 1, matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i < rowIndex)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else if (i == rowIndex) continue;
                    else if (i > rowIndex)
                    {
                        answer[i - 1, j] = matrix[i, j];
                    }
                }
            }
            
            matrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];

            for (int i = 0; i < answer.GetLength(0); i++)
            {
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    matrix[i, j] = answer[i, j];
                }
            }
        }
        
        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

            // code here
            double [] averageValues = new double [3];
            averageValues[0] = GetAverageExceptEdges(A);
            averageValues[1] = GetAverageExceptEdges(B);
            averageValues[2] = GetAverageExceptEdges(C);
            
            bool increasing =  true;
            bool decreasing = true;
            
            for (int i = 1; i < averageValues.Length; i++)
            {
                if (averageValues[i] > averageValues[i - 1])
                {
                    decreasing = false;
                }
                else if (averageValues[i] < averageValues[i - 1])
                {
                    increasing = false;
                }
                else
                {
                    increasing = false;
                    decreasing = false;
                };
            }

            if (increasing && !decreasing) answer = 1;
            else if (decreasing && !increasing) answer = -1;
            else answer = 0;
            // end

            return answer;
        }

        public double GetAverageExceptEdges(int[,] matrix)
        {
            int maxElement = int.MinValue;
            int minElement = int.MaxValue;
            double average = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxElement) maxElement = matrix[i, j];
                    if (matrix[i, j] < minElement) minElement = matrix[i, j];
                    average += matrix[i, j];
                }
            }
            
            average = (average - maxElement - minElement)/(matrix.GetLength(0) * matrix.GetLength(1) - 2);
            return average;
        }
        
        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n == m)
            {
                if (matrix == null || matrix.Length == 0 || matrix.GetLength(0) == 1 || matrix.GetLength(1) == 1) return;
                int colToRemove = method(matrix);
                RemoveColumn(ref matrix, colToRemove);
            }
            // end

        }

        public delegate int Func(int[,] matrix);

        public int FindUpperColIndex(int[,] matrix)
        {
            int n  = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            
            int MaxElemColInd = 0;
            int MaxElem = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    if (matrix[i, j] > MaxElem)
                    {
                        MaxElem = matrix[i, j];
                        MaxElemColInd = j;
                    }
                }
            }

            return MaxElemColInd;
        }

        public int FindLowerColIndex(int[,] matrix)
        {
            int n  = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            
            int MaxElemColInd = 0;
            int MaxElem = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i && j < m; j++)
                {
                    if (matrix[i, j] > MaxElem)
                    {
                        MaxElem = matrix[i, j];
                        MaxElemColInd = j;
                    }
                }
            }

            return MaxElemColInd;
        }

        public void RemoveColumn(ref int[,] matrix, int col)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] answer = new int[n, m - 1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j < col)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else if (j > col)
                    {
                        answer[i, j - 1] = matrix[i, j];
                    }
                }
            }
            matrix = answer;
        }
        
        public void Task4(ref int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == 0 || m == 0) return;
            for (int j = m - 1; j >= 0; j--)
            {
                if (CheckZerosInColumn(matrix, j) == false)
                {
                    RemoveColumn(ref matrix, j);
                }
            }
            // end

        }

        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            int n  = matrix.GetLength(0);
            bool flag = false;

            for (int i = 0; i < n; i++)
            {
                if (matrix[i, col] == 0)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        
        public void Task5(ref int[,] matrix, Finder find)
        {

            // code here
            if (matrix == null || find == null) return;
            int value = find(matrix, out int row, out int col);
            
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int cnt = 0;
            int i = 0;
    
            while (i < n - cnt)
            {
                bool found = false;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == value)
                    {
                        found = true;
                        break;
                    }
                }
        
                if (found)
                {
                    RemoveRow(ref matrix, i);
                    cnt++;
                }
                else
                {
                    i++;
                }
            }
        }
        
        public delegate int Finder (int[,] matrix, out int row, out int col);

        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = matrix.GetLength(0);
            col = matrix.GetLength(1);
            int maxElement = int.MinValue;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i, j] > maxElement) maxElement = matrix[i, j];
                }
            }
            
            return maxElement;
        }

        public int FindMin(int[,] matrix, out int row, out int col)
        {
            row = matrix.GetLength(0);
            col = matrix.GetLength(1);
            int minElement = int.MaxValue;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i, j] < minElement) minElement = matrix[i, j];
                }
            }
            
            return minElement;
        }
        
        public void Task6(int[,] matrix, SortRowsStyle sort)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i+=3)
            {
                for (int j = 0; j < m; j++)
                {
                    sort(matrix, i);
                }
            }
            // end

        }
        
        public delegate void SortRowsStyle (int[,] matrix, int row);

        public void SortRowAscending(int[,] matrix, int row)
        {
            int n = matrix.GetLength(1);

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (matrix[row, j] > matrix[row, j + 1])
                    {
                        (matrix[row, j], matrix[row, j + 1]) = (matrix[row, j + 1], matrix[row, j]);
                    }
                }
            }
        }

        public void SortRowDescending(int[,] matrix, int row)
        {
            int n = matrix.GetLength(1);

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (matrix[row, j] < matrix[row, j + 1])
                    {
                        (matrix[row, j], matrix[row, j + 1]) = (matrix[row, j + 1], matrix[row, j]);
                    }
                }
            }
        }
        
        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {

            // code here
            int n  = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                int maxValue = FindMaxInRow(matrix, i);
                transform(matrix, i, maxValue);
            }
            // end

        }
        
        public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);

        public int FindMaxInRow(int[,] matrix, int row)
        {
            int m = matrix.GetLength(1);
            int maxElement = int.MinValue;

            for (int j = 0; j < m; j++)
            {
                if (matrix[row, j] > maxElement) maxElement = matrix[row, j];
            }
            
            return maxElement;
        }

        public void ReplaceByZero(int[,] matrix, int row, int maxValue)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row,j] == maxValue) matrix[row,j] = 0;
            }
        }

        public void MultiplyByColumn(int[,] matrix, int row, int maxValue)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] == maxValue) matrix[row, j] *= j + 1;
            }
        }
        
        public double[,] Task8(double a, double b, double h, Func<double, double> sum, Func<double, double> y)
        {
            double[,] answer = null;

            // code here
            int n = (int)((b - a) / h + 1);
            
            answer = new double[n, 2];

            for (int i = 0; i < n; i++)
            {
                double x = a + i * h;
                answer[i, 0] = sum(x);
                answer[i, 1] = y(x);
            }
            
            // end

            return answer;
        }
        
        public double SumA(double x)
        {
            double S = 1.0;
            double prevSum = 0.0;
            double fact = 1.0;
            int i = 1;

            do
            {
                prevSum = S;
                fact *= i;
                S += Math.Cos(i * x) / fact;
                i++;
            } while (Math.Abs(S - prevSum) >= 0.00001);
            
            return S;
        }

        public double YA(double x)
        {
            return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));

        }

        public double SumB(double x)
        {
            double S = -2.0 * Math.PI * Math.PI / 3.0;
            
            for (double i = 1.0; ; i += 1.0)
            {
                double sign = (i % 2 == 0)? 1.0 : -1.0;
                S += sign * Math.Cos(i * x) / (i * i);

                if (Math.Abs(sign * Math.Cos(i * x) / (i * i)) < 0.000001) break;
            }
            
            return S;
        }

        public double YB(double x)
        {
            return x * x / 4.0 - 3.0 * Math.PI * Math.PI / 4.0;
        }
        
        public int Task9(int[,] matrix, GetTriangle triangle)
        {
            int answer = 0;

            // code here
            answer = GetSum(triangle, matrix);
            // end

            return answer;
        }

        public delegate int[] GetTriangle(int[,] matrix);

        public int Sum(int[] array)
        {
            if (array == null) return 0;
            
            int sum = 0;

            foreach (int num in array)
            {
                sum += num * num;
            }

            return sum;
        }

        public int GetSum(GetTriangle transformer, int[,] matrix)
        {
            int[] triangle = transformer(matrix);
            
            return Sum(triangle);
        }

        public int[] GetUpperTriangle(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m) return null;
            
            int size = n * (n + 1) / 2;
            int[] upper = new int[size];
            size = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    upper[size] = matrix[i, j];
                    size++;
                }
            }
            
            return upper;
        }

        public int[] GetLowerTriangle(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            
            if (n != m) return null;
            
            int size = n * (n + 1) / 2;
            int[] lower = new int[size];
            size = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    lower[size] =  matrix[i, j];
                    size++;
                }
            }
            
            return lower;
        }
        
        public bool Task10(int[][] array, Predicate<int[][]> func)
        {
            bool res = false;

            // code here
            res = func(array);
            // end

            return res;
        }

        public delegate bool Predicate(int[][] array);

        public bool CheckTransformAbility(int[][] array)
        {
            bool transform = false;
            
            int n =  array.Length;
            int elemCounter = 0;
            
            for (int i = 0; i < n; i ++)
            {
                elemCounter += array[i].Length;
            }
            
            if (elemCounter % n == 0)  transform = true;
            return transform;
        }

        public bool CheckSumOrder(int[][] array)
        {
            int n = array.Length;
            int[] sums = new int[n];

            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }
                sums[i] = sum;
            }
            
            bool strictlyIncreasing = true;
            bool strictlyDecreasing = true;
            
            for (int i = 1; i < sums.Length; i++)
            {
                if (sums[i] > sums[i - 1])
                {
                    strictlyDecreasing = false;
                }
                else if (sums[i] < sums[i - 1])
                {
                    strictlyIncreasing = false;
                }
                else
                {
                    return false;
                }
            }
            
            return strictlyIncreasing || strictlyDecreasing;
        }

        public bool CheckArraysOrder(int[][] array)
        {
            int n =  array.Length;
            bool order = false;

            for (int i = 0; i < n; i++)
            {
                bool strictlyIncreasing = true;
                bool strictlyDecreasing = true;
                bool isOrdered = true;
                
                for (int j = 1; j < array[i].Length; j++)
                {
                    if (array[i][j] > array[i][j - 1])
                    {
                        strictlyDecreasing = false;
                    }
                    else if (array[i][j] < array[i][j - 1])
                    {
                        strictlyIncreasing = false;
                    }
                    else
                    {
                        isOrdered = false;
                        break;
                    }
                    
                    if (!strictlyIncreasing && !strictlyDecreasing)
                    {
                        isOrdered = false;
                        break;
                    }
                }
                
                if (isOrdered && (strictlyIncreasing || strictlyDecreasing))
                {
                    return true;
                }
            }
    
            return false;
        }
    }
}
