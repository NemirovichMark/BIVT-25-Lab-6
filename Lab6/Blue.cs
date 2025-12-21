namespace Lab6
{
    public class Blue
    {
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int a= matrix[0, 0];
            int rowIndex = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > a)
                {
                    a= matrix[i, i];
                    rowIndex = i;
                }
            }
            return rowIndex;
        }

        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] res = new int[n - 1, m];
            if (n == 1)
            {
                matrix = new int[0, m];
                return;
            }
            for (int i = 0; i < n - 1; i++)
            {
                if (i < rowIndex)
                {
                    for (int j = 0; j < m; j++)
                    {
                        res[i,j] = matrix[i, j];
                    }
                }
                else
                {
                    for (int j = 0; j < m; j++)
                    {
                        res[i, j] = matrix[i+1, j];
                    }
                }
            }
            matrix = res;
        
        }
        public void Task1(ref int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (matrix == null || (n != m))
            {
                return;
            }

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
        double[] array = new double[3] { GetAverageExceptEdges(A), GetAverageExceptEdges(B), GetAverageExceptEdges(C) };
        bool increasing = true;
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] >= array[i + 1])
            {
                increasing = false;
                break;
            }
        }
        
        bool decreasing = true;
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] <= array[i + 1])
            {
                decreasing = false;
                break;
            }
        }
        
        if (increasing)
        {
            answer = 1;
        }
        else if (decreasing)
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

    public double GetAverageExceptEdges(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int max = matrix[0, 0];
        int min = matrix[0, 0];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                }
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                }
            }
        }
        int kol = 0;
        int sum = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] != max && matrix[i, j] != min)
                {
                    sum += matrix[i, j];
                    kol++;
                }
            }
        }
        double srAr;
        if (kol == 0)
        {
            srAr = 0;
        }
        else
        {
            srAr = (double)sum / kol;
        }
        return srAr;
    }
    public void Task3(ref int[,] matrix, Func<int[,], int> method)
    {
    
        // code here
        if (matrix.GetLength(0) != matrix.GetLength(1)) return;
        int findColIndex = method(matrix);
        RemoveColumn(ref matrix, findColIndex);
        // end
    
    }
    public int FindUpperColIndex(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int max = int.MinValue;
        int index = 1;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    index = j;
                }
                else if (matrix[i, j] == max && j < index)
                {
                    index = j;
                }
            }
        }
        return index;
    }
    public int FindLowerColIndex(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int max = matrix[0, 1];
        int index = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    index = j;
                }
                else if (matrix[i, j] == max && j < index)
                {
                    index = j;
                }
            }
        }
        return index;
    }
    public void RemoveColumn(ref int[,] matrix, int col)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] newMatrix = new int[rows, cols - 1];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < col; j++)
            {
                newMatrix[i, j] = matrix[i, j];
            }
        }
        for (int i = 0; i < rows; i++)
        {
            for (int j = col; j < cols - 1; j++)
            {
                newMatrix[i, j] = matrix[i, j + 1];
            }
        }
        matrix = new int[rows, cols - 1];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols - 1; j++)
            {
                matrix[i, j] = newMatrix[i, j];
            }
        }
    }
    
    public void Task4(ref int[,] matrix)
    {
    
        // code here
        int j = 0;
        while (j < matrix.GetLength(1))
        {
            if (!CheckZerosInColumn(matrix, j))
            {
                RemoveColumn(ref matrix, j);
            }
            else
            {
                j++;
            }
        }
        
    
        // end
    
    }
    public bool CheckZerosInColumn(int[,] matrix, int col)
    {
        int rows = matrix.GetLength(0);
        for (int i = 0; i < rows; i++)
        {
            if (matrix[i, col] == 0)
                return true;
        }
        return false;
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
    public delegate int Finder(int[,] matrix, out int row, out int col);
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
    public delegate void SortRowsStyle(int[,] matrix, int row);
    public void SortRowAscending(int[,] matrix, int row)
    {
        int cols = matrix.GetLength(1);
        for (int j = 0; j < cols; j++)
        {
            for (int k = j; k < cols; k++)
            {
                if (matrix[row, j] > matrix[row, k])
                {
                    (matrix[row, k], matrix[row, j]) = (matrix[row, j], matrix[row, k]);
                }
            }
        }
    }
    public void SortRowDescending(int[,] matrix, int row)
    {
        int cols = matrix.GetLength(1);
        for (int j = 0; j < cols; j++)
        {
            for (int k = j; k < cols; k++)
            {
                if (matrix[row, j] < matrix[row, k])
                {
                    (matrix[row, k], matrix[row, j]) = (matrix[row, j], matrix[row, k]);
                }
            }
        }
    }
    public void Task7(int[,] matrix, ReplaceMaxElements transform)
    {
    
        // code here
        int rows = matrix.GetLength(0);
        for (int i = 0; i < rows; i++)
        {
            int max = FindMaxInRow(matrix, i);
            transform(matrix, i, max);
        }
        // end
    
    }
    public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);
    public int FindMaxInRow(int[,] matrix, int row)
    {
        int cols = matrix.GetLength(1);
        int max = matrix[row, 0];
        for (int j = 0; j < cols; j++)
        {
            if (matrix[row, j] > max)
            {
                max = matrix[row, j];
            }
        }
        return max;
    }
    public void ReplaceByZero(int[,] matrix, int row, int maxValue)
    {
        int cols = matrix.GetLength(1);
        for (int j = 0; j < cols; j++)
        {
            if (matrix[row, j] == maxValue)
            {
                matrix[row, j] = 0;
            }
        }
    }
    public void MultiplyByColumn(int[,] matrix, int row, int maxValue)
    {
        int cols = matrix.GetLength(1);
        for (int j = 0; j < cols; j++)
        {
            if (matrix[row, j] == maxValue)
            {
                matrix[row, j] *= j + 1;
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
        int n = (int)Math.Round((b - a) / h) + 1;

        double[,] matrix = new double[n, 2];

        for (int i = 0; i < n; i++)
        {
            double x = a + i * h;
            matrix[i, 0] = sum(x);
            matrix[i, 1] = y(x);
        }
        return matrix;
    }
    public double SumA(double x)
    {
        double s = 1;
        double a = 0.1;
        double b = 1;
        double h = 0.1;
        int i = 1;
        int det = i;
        for (double k = a; k < b; k += h)
        {
            s += Math.Cos(i * x) / det;
            i++;
            det *= i;
        }
        return s;
    }
    public double YA(double x)
    {
        double result = (double)Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x));
        return result;
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
   public int Task9(int[,] matrix, GetTriangle triangle)
        {
            int answer = 0;

            // code here
            answer = GetSum(triangle, matrix);
            // end

            return answer;
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
        public int GetSum(GetTriangle transformer, int[,] matrix)
        {
            int answer = 0;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return 0;
            int[] array = transformer(matrix);
            answer = Sum(array);
            // end

            return answer;
        }
        public int[] GetUpperTriangle(int[,] matrix)
        {
            int len = 0;
            int n = matrix.GetLength(0);
            for (int i = 0; i <= n; i++)
            {
                len += i;
            }
            int[] array = new int[len];
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    array[index] = matrix[i, j];
                    index++;
                }
            }
            return array;
        }
        public int[] GetLowerTriangle(int[,] matrix)
        {
            int len = 0;
            int n = matrix.GetLength(0);
            for (int i = 0; i <= n; i++)
            {
                len += i;
            }
            int[] array = new int[len];
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    array[index] = matrix[i, j];
                    index++;
                }
            }
            return array;
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
            int maxLen = 0;
            for (int i = 0; i<array.Length; i++)
            {
                if (array[i].Length>maxLen)
                {
                    maxLen = array[i].Length;
                }
            }
            int sum = 0;
            for (int i = 0; i<array.Length; i++)
            {
                for (int j = 0; j<array[i].Length; j++)
                {
                    sum++;
                }
            }
            bool result = false;
            if (((int)(sum / array.Length) == ((double)sum / array.Length)) && array.Length!=0)
            {
                result = true;
            }
            return result;
        }
        public bool CheckSumOrder(int[][] array)
        {
            int[] arrayOfSums = new int[array.Length];
            int index = 0;
            for (int i = 0; i<array.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }
                arrayOfSums[index] = sum;
                index++;
            }
            bool ascending = true;
            for (int i = 0; i<arrayOfSums.Length-1; i++)
            {
                if (arrayOfSums[i] > arrayOfSums[i+1])
                {
                    ascending = false;
                }
            }
            bool descending = true;
            for (int i = 0; i < arrayOfSums.Length - 1; i++)
            {
                if (arrayOfSums[i] < arrayOfSums[i + 1])
                {
                    descending = false;
                }
            }
            bool result = false;
            if (ascending || descending)
            {
                result = true;
            }
            return result;
        }
        public bool CheckArraysOrder(int[][] array)
        {
            bool result = false;
            for (int i = 0; i < array.Length; i++)
            {
                bool ascending = true;
                for (int j = 0; j < array[i].Length - 1; j++)
                {
                    if (array[i][j] > array[i][j + 1])
                    {
                        ascending = false;
                    }
                }
                bool descending = true;
                for (int j = 0; j < array[i].Length - 1; j++)
                {
                    if (array[i][j] < array[i][j + 1])
                    {
                        descending = false;
                    }
                }
                if ((ascending || descending) && result==false)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}

