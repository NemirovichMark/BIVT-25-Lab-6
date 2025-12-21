namespace Lab6
{
    public class Blue
    {
        public void Task1(ref int[,] matrix)
        {
            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);

            if (rowCount != colCount)
                return;

            int diagonalMaxRow = FindDiagonalMaxIndex(matrix);
            RemoveRow(ref matrix, diagonalMaxRow);
        }

        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int currentMax = matrix[0, 0];
            int maxRowIndex = 0;

            for (int index = 1; index < matrix.GetLength(0); index++)
            {
                if (matrix[index, index] > currentMax)
                {
                    currentMax = matrix[index, index];
                    maxRowIndex = index;
                }
            }

            return maxRowIndex;
        }

        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= matrix.GetLength(0))
                return;

            int originalRows = matrix.GetLength(0);
            int originalCols = matrix.GetLength(1);

            int[,] result = new int[originalRows - 1, originalCols];

            int targetRow = 0;

            for (int sourceRow = 0; sourceRow < originalRows; sourceRow++)
            {
                if (sourceRow == rowIndex)
                    continue;

                for (int col = 0; col < originalCols; col++)
                {
                    result[targetRow, col] = matrix[sourceRow, col];
                }

                targetRow++;
            }

            matrix = result;
        }

        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            double[] averages = new double[3];

            averages[0] = GetAverageExceptEdges(A);
            averages[1] = GetAverageExceptEdges(B);
            averages[2] = GetAverageExceptEdges(C);

            if (averages[0] > averages[1] && averages[1] > averages[2])
                return -1;

            if (averages[0] < averages[1] && averages[1] < averages[2])
                return 1;

            return 0;
        }

        public double GetAverageExceptEdges(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int minValue = matrix[0, 0];
            int maxValue = matrix[0, 0];

            int minRow = 0, minCol = 0;
            int maxRow = 0, maxCol = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int value = matrix[row, col];

                    if (value < minValue)
                    {
                        minValue = value;
                        minRow = row;
                        minCol = col;
                    }

                    if (value > maxValue)
                    {
                        maxValue = value;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            int totalSum = 0;
            int elementsCount = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if ((row == minRow && col == minCol) ||
                        (row == maxRow && col == maxCol))
                        continue;

                    totalSum += matrix[row, col];
                    elementsCount++;
                }
            }

            return elementsCount > 0 ? (double)totalSum / elementsCount : 0;
        }

        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {
            if (matrix == null || method == null) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            int col = method(matrix);
            if (col != -1)
            {
                RemoveColumn(ref matrix, col);
            }
        }

        public int FindUpperColIndex(int[,] matrix)
        {
            int maxValue = int.MinValue;
            int resultColumn = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = row + 1; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > maxValue)
                    {
                        maxValue = matrix[row, col];
                        resultColumn = col;
                    }
                }
            }

            return resultColumn;
        }

        public int FindLowerColIndex(int[,] matrix)
        {
            int maxValue = int.MinValue;
            int resultColumn = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col <= row && col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > maxValue)
                    {
                        maxValue = matrix[row, col];
                        resultColumn = col;
                    }
                }
            }

            return resultColumn;
        }

        public void RemoveColumn(ref int[,] matrix, int col)
        {
            if (col < 0 || col >= matrix.GetLength(1)) return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] temp = new int[rows, cols - 1];

            for (int i = 0; i < rows; i++)
            {
                int currentCol = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j != col)
                    {
                        temp[i, currentCol] = matrix[i, j];
                        currentCol = currentCol + 1;
                    }
                }
            }
            matrix = temp;
        }

        public void Task4(ref int[,] matrix)
        {
            for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
            {
                if (!CheckZerosInColumn(matrix, col))
                {
                    RemoveColumn(ref matrix, col);
                }
            }
        }

        public bool CheckZerosInColumn(int[,] matrix, int colIndex)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, colIndex] == 0)
                    return true;
            }

            return false;
        }

        public delegate int Finder(int[,] matrix, out int row, out int col);

        public void Task5(ref int[,] matrix, Finder find)
        {
            int foundRow, foundCol;
            int targetValue = find(matrix, out foundRow, out foundCol);

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                bool containsTarget = false;

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == targetValue)
                    {
                        containsTarget = true;
                        break;
                    }
                }

                if (containsTarget)
                    RemoveRow(ref matrix, row);
            }
        }

        public int FindMax(int[,] matrix, out int row, out int col)
        {
            int maxValue = int.MinValue;
            row = 0;
            col = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] > maxValue)
                    {
                        maxValue = matrix[r, c];
                        row = r;
                        col = c;
                    }
                }
            }

            return maxValue;
        }

        public int FindMin(int[,] matrix, out int row, out int col)
        {
            int minValue = int.MaxValue;
            row = 0;
            col = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] < minValue)
                    {
                        minValue = matrix[r, c];
                        row = r;
                        col = c;
                    }
                }
            }

            return minValue;
        }
        public delegate void SortRowsStyle(int[,] matrix, int row);

        public void Task6(int[,] matrix, SortRowsStyle sort)
        {
            if (matrix == null || sort == null)
                return;

            int rowCount = matrix.GetLength(0);

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                if (rowIndex % 3 == 0)
                    sort(matrix, rowIndex);
            }
        }

        public void SortRowAscending(int[,] matrix, int row)
        {
            int columnCount = matrix.GetLength(1);
            int[] copy = new int[columnCount];

            for (int col = 0; col < columnCount; col++)
                copy[col] = matrix[row, col];

            int currentIndex = 1;
            int nextStart = 2;

            while (currentIndex < copy.Length)
            {
                if (currentIndex == 0 || copy[currentIndex] >= copy[currentIndex - 1])
                {
                    currentIndex = nextStart;
                    nextStart++;
                }
                else
                {
                    (copy[currentIndex], copy[currentIndex - 1]) =
                        (copy[currentIndex - 1], copy[currentIndex]);
                    currentIndex--;
                }
            }

            for (int col = 0; col < columnCount; col++)
                matrix[row, col] = copy[col];
        }

        public void SortRowDescending(int[,] matrix, int row)
        {
            int columnCount = matrix.GetLength(1);
            int[] buffer = new int[columnCount];

            for (int col = 0; col < columnCount; col++)
                buffer[col] = matrix[row, col];

            int currentIndex = 1;
            int nextStart = 2;

            while (currentIndex < buffer.Length)
            {
                if (currentIndex == 0 || buffer[currentIndex] <= buffer[currentIndex - 1])
                {
                    currentIndex = nextStart;
                    nextStart++;
                }
                else
                {
                    (buffer[currentIndex], buffer[currentIndex - 1]) =
                        (buffer[currentIndex - 1], buffer[currentIndex]);
                    currentIndex--;
                }
            }

            for (int col = 0; col < columnCount; col++)
                matrix[row, col] = buffer[col];
        }

        public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);

        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {
            int rowCount = matrix.GetLength(0);

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                int maxInRow = FindMaxInRow(matrix, rowIndex);
                transform(matrix, rowIndex, maxInRow);
            }
        }

        public int FindMaxInRow(int[,] matrix, int row)
        {
            int columnCount = matrix.GetLength(1);
            int maxValue = int.MinValue;

            for (int col = 0; col < columnCount; col++)
            {
                if (matrix[row, col] > maxValue)
                    maxValue = matrix[row, col];
            }

            return maxValue;
        }

        public void ReplaceByZero(int[,] matrix, int row, int maxValue)
        {
            int columnCount = matrix.GetLength(1);

            for (int col = 0; col < columnCount; col++)
            {
                if (matrix[row, col] == maxValue)
                    matrix[row, col] = 0;
            }
        }

        public void MultiplyByColumn(int[,] matrix, int row, int maxValue)
        {
            int columnCount = matrix.GetLength(1);

            for (int col = 0; col < columnCount; col++)
            {
                if (matrix[row, col] == maxValue)
                    matrix[row, col] *= (col + 1);
            }
        }

        public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
        {
            int pointCount = (int)((b - a) / h + 0.0001) + 1;
            double[,] table = new double[pointCount, 2];

            for (int index = 0; index < pointCount; index++)
            {
                double xValue = a + index * h;
                table[index, 0] = getSum(xValue);
                table[index, 1] = getY(xValue);
            }

            return table;
        }

        public double SumA(double x)
        {
            double result = 1.0;
            double factorial = 1.0;

            for (int index = 1; index <= 10; index++)
            {
                factorial *= index;
                result += Math.Cos(index * x) / factorial;
            }

            return result;
        }

        public double SumB(double x)
        {
            double result = -2.0 * Math.PI * Math.PI / 3.0;
            double sign = 1.0;
            double term = 1.0;

            for (int index = 1; Math.Abs(term) >= 0.000001; index++)
            {
                sign *= -1;
                term = sign * (Math.Cos(index * x) / (index * index));
                result += term;
            }

            return result;
        }

        public double YA(double x)
        {
            return Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x));
        }
        
        public double YB(double x)
        {
            return (x * x / 4) - (Math.PI * Math.PI * 3) / 4;
        }

        public delegate int[] GetTriangle(int[,] matrix);

        public int Task9(int[,] matrix, GetTriangle triangle)
        {
            return GetSum(triangle, matrix);
        }

        public int Sum(int[] values)
        {
            int total = 0;

            foreach (int value in values)
                total += value * value;

            return total;
        }

        public int[] GetUpperTriangle(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            if (size != matrix.GetLength(1))
                return new int[0];

            int elementCount = size * (size + 1) / 2;
            int[] result = new int[elementCount];

            int index = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = row; col < size; col++)
                {
                    result[index++] = matrix[row, col];
                }
            }

            return result;
        }

        public int[] GetLowerTriangle(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            if (size != matrix.GetLength(1))
                return new int[0];

            int elementCount = size * (size + 1) / 2;
            int[] result = new int[elementCount];

            int index = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    result[index++] = matrix[row, col];
                }
            }

            return result;
        }

        public int GetSum(GetTriangle transformer, int[,] matrix)
        {
            return Sum(transformer(matrix));
        }

        public delegate bool Predicate(int[][] array);

        public bool Task10(int[][] array, Predicate<int[][]> func)
        {
            return func(array);
        }

        public bool CheckTransformAbility(int[][] array)
        {
            int rowCount = array.Length;
            int firstLength = array[0].Length;

            bool isRectangular = true;
            for (int i = 1; i < rowCount; i++)
            {
                if (array[i].Length != firstLength)
                {
                    isRectangular = false;
                    break;
                }
            }
            if (isRectangular)
                return true;

            bool descendingTriangle = true;
            if (array[0].Length == rowCount)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    if (array[i].Length != rowCount - i)
                    {
                        descendingTriangle = false;
                        break;
                    }
                }
                if (descendingTriangle)
                    return true;
            }

            bool ascendingTriangle = true;
            if (array[rowCount - 1].Length == rowCount)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    if (array[i].Length != i + 1)
                    {
                        ascendingTriangle = false;
                        break;
                    }
                }
                if (ascendingTriangle)
                    return true;
            }

            return false;
        }

        public bool CheckSumOrder(int[][] array)
        {
            bool ascending = true;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (Sum(array[i]) > Sum(array[i + 1]))
                {
                    ascending = false;
                    break;
                }
            }
            if (ascending)
                return true;

            bool descending = true;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (Sum(array[i]) < Sum(array[i + 1]))
                {
                    descending = false;
                    break;
                }
            }

            return descending;
        }

        public static bool IsSorted(int[] array)
        {
            if (array == null || array.Length <= 1)
                return true;

            bool ascending = true;
            bool descending = true;

            for (int index = 1; index < array.Length; index++)
            {
                if (array[index - 1] > array[index])
                    ascending = false;

                if (array[index - 1] < array[index])
                    descending = false;

                if (!ascending && !descending)
                    return false;
            }

            return true;
        }

        public bool CheckArraysOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (IsSorted(array[i]))
                    return true;
            }

            return false;
        }
    }
}
