namespace Lab6
{
    public class Blue
    {
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            int maxIndex = 0;
            for (int i = 1; i < size; i++)
            {
                if (matrix[i, i] > matrix[maxIndex, maxIndex])
                {
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] newMatrix = new int[rows - 1, cols];

            for (int i = 0, newRow = 0; i < rows; i++)
            {
                if (i == rowIndex) continue;
                for (int j = 0; j < cols; j++)
                {
                    newMatrix[newRow, j] = matrix[i, j];
                }
                newRow++;
            }
            matrix = newMatrix;
        }
        public void Task1(ref int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows == 0 || cols == 0 || rows != cols) return;
            int maxRowIndex = FindDiagonalMaxIndex(matrix);
            RemoveRow(ref matrix, maxRowIndex);
            // end

        }
        public double GetAverageExceptEdges(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows == 0 || cols == 0) return 0;

            double sum = 0;
            int count = 0;
            int min = matrix[0, 0];
            int max = matrix[0, 0];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int val = matrix[i, j];
                    sum += val;
                    count++;
                    if (val < min) min = val;
                    if (val > max) max = val;
                }
            }

            sum -= min + max;
            count -= 2;

            return count > 0 ? sum / count : 0;
        }

        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0;

            // code here
            double avgA = GetAverageExceptEdges(A);
            double avgB = GetAverageExceptEdges(B);
            double avgC = GetAverageExceptEdges(C);

            if (avgA < avgB && avgB < avgC) return 1;
            if (avgA > avgB && avgB > avgC) return -1;
            return 0;
            // end

            
        }
        public int FindUpperColIndex(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            int maxValue = int.MinValue;
            int colIndex = -1;

            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        colIndex = j;
                    }
                }
            }
            return colIndex;
        }
        public int FindLowerColIndex(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            int maxValue = int.MinValue;
            int colIndex = -1;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        colIndex = j;
                    }
                }
            }
            return colIndex;
        }
        public void RemoveColumn(ref int[,] matrix, int col)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (col < 0 || col >= cols) return;

            int[,] newMatrix = new int[rows, cols - 1];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0, newCol = 0; j < cols; j++)
                {
                    if (j == col) continue;
                    newMatrix[i, newCol] = matrix[i, j];
                    newCol++;
                }
            }

            matrix = newMatrix;
        }
        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {

            // code here
            if (matrix == null || method == null) return;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows == 0 || cols == 0 || rows != cols) return;

            int colToRemove = method(matrix);
            if (colToRemove >= 0 && colToRemove < cols)
            {
                RemoveColumn(ref matrix, colToRemove);
            }
            // end

        }
        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            int rows = matrix.GetLength(0);
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, col] == 0) return true;
            }
            return false;
        }

        public void RemoveCol(ref int[,] matrix, int col)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] newMatrix = new int[rows, cols - 1];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0, newCol = 0; j < cols; j++)
                {
                    if (j == col) continue;
                    newMatrix[i, newCol] = matrix[i, j];
                    newCol++;
                }
            }

            matrix = newMatrix;
        }

        public void Task4(ref int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int cols = matrix.GetLength(1);

            for (int j = cols - 1; j >= 0; j--)
            {
                if (!CheckZerosInColumn(matrix, j))
                {
                    RemoveCol(ref matrix, j);
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
            int max = matrix[0, 0];

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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            row = 0;
            col = 0;
            int min = matrix[0, 0];

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

        public void Task5(ref int[,] matrix, Finder find)
        {

            // code here
            if (matrix == null || find == null) return;
            if (matrix.Length == 0) return;

            int targetRow, targetCol;
            int targetValue = find(matrix, out targetRow, out targetCol);

            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                bool containsValue = false;
                int cols = matrix.GetLength(1);

                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == targetValue)
                    {
                        containsValue = true;
                        break;
                    }
                }

                if (containsValue)
                {
                    RemoveRow(ref matrix, i);
                }
            }
            // end

        }
        public delegate void SortRowsStyle(int[,] matrix, int row);

        public void SortRowAscending(int[,] matrix, int row)
        {
            int cols = matrix.GetLength(1);
            int[] temp = new int[cols];

            for (int j = 0; j < cols; j++)
                temp[j] = matrix[row, j];

            Array.Sort(temp);

            for (int j = 0; j < cols; j++)
                matrix[row, j] = temp[j];
        }

        public void SortRowDescending(int[,] matrix, int row)
        {
            int cols = matrix.GetLength(1);
            int[] temp = new int[cols];

            for (int j = 0; j < cols; j++)
                temp[j] = matrix[row, j];

            Array.Sort(temp);
            Array.Reverse(temp);

            for (int j = 0; j < cols; j++)
                matrix[row, j] = temp[j];
        }
        public void Task6(int[,] matrix, SortRowsStyle sort)
        {

            // code here
            if (matrix == null || sort == null) return;
            int rows = matrix.GetLength(0);

            for (int i = 0; i < rows; i += 3)
            {
                sort(matrix, i);
            }
            // end

        }
        public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);

        public int FindMaxInRow(int[,] matrix, int row)
        {
            int cols = matrix.GetLength(1);
            int max = matrix[row, 0];

            for (int j = 1; j < cols; j++)
            {
                if (matrix[row, j] > max)
                    max = matrix[row, j];
            }

            return max;
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
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                if (matrix[row, j] == maxValue)
                    matrix[row, j] *= (j + 1);
            }
        }
        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {

            // code here
            if (matrix == null || transform == null) return;
            int rows = matrix.GetLength(0);

            for (int i = 0; i < rows; i++)
            {
                int maxValue = FindMaxInRow(matrix, i);
                transform(matrix, i, maxValue);
            }
            // end

        }

        public double SumA(double x)
        {
            const double eps = 1e-12;
            return SumARecursive(x, 0, 1.0, 1.0, eps);
        }

        private double SumARecursive(double x, int n, double term, double factorial, double eps)
        {
            if (Math.Abs(term) < eps)
                return term;

            double nextFactorial = factorial * (n + 1);
            double nextTerm = Math.Cos((n + 1) * x) / nextFactorial;

            double rest = SumARecursive(x, n + 1, nextTerm, nextFactorial, eps);
            return term + rest;
        }

        public double YA(double x)
        {
            return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
        }

        public double SumB(double x)
        {
            double s = -2.0 * Math.PI * Math.PI / 3.0;

            for (int i = 1; ; i++)
            {
                double sign = (i % 2 == 0) ? 1.0 : -1.0;
                double term = sign * Math.Cos(i * x) / (i * (double)i);

                s += term;

                if (Math.Abs(term) < 1e-6)
                    break;
            }

            return s;
        }

        public double YB(double x)
        {
            return x * x / 4.0 - 3.0 * Math.PI * Math.PI / 4.0;
        }

        public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
        {
            int n = (int)Math.Round((b - a) / h) + 1;
            double[,] result = new double[n, 2];

            for (int i = 0; i < n; i++)
            {
                double x = a + i * h;
                result[i, 0] = getSum(x);
                result[i, 1] = getY(x);
            }

            return result;
        }

        public delegate int[] GetTriangle(int[,] matrix);

        public int Sum(int[] array)
        {
            int sum = 0;
            foreach (int val in array)
            {
                sum += val * val;
            }
            return sum;
        }

        public int[] GetUpperTriangle(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            List<int> result = new List<int>();

            for (int i = 0; i < size; i++)
            {
                for (int j = i; j < size; j++)
                {
                    result.Add(matrix[i, j]);
                }
            }

            return result.ToArray();
        }

        public int[] GetLowerTriangle(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            List<int> result = new List<int>();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    result.Add(matrix[i, j]);
                }
            }

            return result.ToArray();
        }
        public int Task9(int[,] matrix, GetTriangle triangle)
        {
            int answer = 0;

            // code here
            if (matrix == null || triangle == null) return 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols) return 0;

            int[] triangleArray = triangle(matrix);
            answer = Sum(triangleArray);
            // end

            return answer;
        }
        public bool CheckTransformAbility(int[][] array)
        {
            int totalElements = 0;
            foreach (int[] row in array)
                totalElements += row.Length;
            return totalElements % array.Length == 0;
        }

        public bool CheckSumOrder(int[][] array)
        {
            if (array.Length == 1) return true; // one row → ordered

            int[] sums = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;
                foreach (int val in array[i])
                    sum += val;
                sums[i] = sum;
            }

            bool inc = true, dec = true;
            for (int i = 1; i < sums.Length; i++)
            {
                if (sums[i] <= sums[i - 1]) inc = false;
                if (sums[i] >= sums[i - 1]) dec = false;
            }
            return inc || dec;
        }

        public bool CheckArraysOrder(int[][] array)
        {
            foreach (int[] row in array)
            {
                bool inc = true, dec = true;
                for (int j = 1; j < row.Length; j++)
                {
                    if (row[j] <= row[j - 1]) inc = false;
                    if (row[j] >= row[j - 1]) dec = false;
                }
                if (inc || dec) return true;
            }
            return false;
        }

        public bool Task10(int[][] array, Predicate<int[][]> func)
        {
            return func(array);
        }

    }
}