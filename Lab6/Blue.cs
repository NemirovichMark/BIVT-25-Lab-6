namespace Lab6
{
    public class Blue
    {
        public void Task1(ref int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (n != m)
                return;
            int index = FindDiagonalMaxIndex(matrix);
            RemoveRow(ref matrix, index);
            // end

        }

        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int maxValue = matrix[0, 0], maxIndex = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > maxValue)
                {
                    maxValue = matrix[i, i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= matrix.GetLength(0))
                return;
            
            int[,] temp = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int it = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i != rowIndex)
                    {
                        temp[it, j] = matrix[i, j];
                    }

                    if (i == rowIndex && j == matrix.GetLength(1) - 1)
                        it--;
                }

                it++;
            }
            matrix = temp;
        }
        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing
        
            // code here
            double[] values = new double[3];
            values[0] = GetAverageExceptEdges(A);
            values[1] = GetAverageExceptEdges(B);
            values[2] = GetAverageExceptEdges(C);
            if (values[0] > values[1] && values[1] > values[2])
                answer = -1;
            else if (values[0] < values[1] && values[1] < values[2])
                answer = 1;
            else answer = 0;
            
            // end
        
            return answer;
        }

        public double GetAverageExceptEdges(int[,] matrix)
        {
            int minValue = matrix[0, 0], minI = 0, minJ = 0, maxValue = matrix[0, 0], maxI = 0, maxJ = 0;
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < minValue)
                    {
                        minValue = matrix[i, j];
                        minI = i;
                        minJ = j;
                    }

                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxI = i;
                        maxJ = j;
                    }
                }
            }

            int sum = 0, count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i == minI && j == minJ) || (i == maxI && j == maxJ))
                        continue;
                    sum += matrix[i, j];
                    count++;
                }
            }

            if (count != 0)
                return (double) sum / count;
            else return 0;
        }
        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {
        
            // code here
            if (matrix == null || method == null) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            int col = method(matrix);
            if (col != -1)
            {
                RemoveColumn(ref matrix, col);
            }
            // end
        
        }

        public int FindUpperColIndex(int[,] matrix)
        {
            int maxVal = Int32.MinValue;
            int resCol = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        resCol = j;
                    }
                }
            }
            return resCol;
        }

        public int FindLowerColIndex(int[,] matrix)
        {
            int maxVal = Int32.MinValue;
            int resCol = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j <= i && j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        resCol = j;
                    }
                }
            }
            return resCol;

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
        
            // code here
            for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
            {
                bool hasZero = CheckZerosInColumn(matrix, j);
                if (hasZero == false)
                {
                    RemoveColumn(ref matrix, j);
                }
            }
            // end
        
        }

        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            bool res = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, col] == 0)
                    res = true;
            }

            return res;
        }
        public delegate int Finder(int[,] matrix, out int row, out int col);
        public void Task5(ref int[,] matrix, Finder find)
        {
        
            // code here
            if (matrix == null || find == null) return;
            int rowIdx, colIdx;
            int targetValue = find(matrix, out rowIdx, out colIdx);

            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                bool found = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == targetValue)
                    {
                        found = true;
                        break;
                    }
                }
                if (found == true)
                {
                    RemoveRow(ref matrix, i);
                }
            }
            // end
        
        }

        public int FindMax(int[,] matrix, out int row, out int col)
        {
            int max = Int32.MinValue;
            row = 0;
            col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
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
            int min = Int32.MaxValue;
            row = 0;
            col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
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

        public delegate void SortRowsStyle(int[,] matrix, int row);
        public void Task6(int[,] matrix, SortRowsStyle sort)
        {
        
            // code here
            if (matrix == null || sort == null) return;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 3 == 0)
                    sort(matrix, i);
            }
            // end
        
        }

        public void SortRowAscending(int[,] matrix, int row)
        {
            int[] sortedRow = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sortedRow[j] = matrix[row, j];
            }

            int i = 1, js = 2;
            while (i < sortedRow.Length)
            {
                if (i == 0 || sortedRow[i] >= sortedRow[i - 1])
                {
                    i = js;
                    js++;
                }
                else
                {
                    (sortedRow[i], sortedRow[i - 1]) = (sortedRow[i - 1], sortedRow[i]);
                    i--;
                }
            }

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[row, j] = sortedRow[j];
            }
            
        }

        public void SortRowDescending(int[,] matrix, int row)
        {
            int[] sortedRow = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sortedRow[j] = matrix[row, j];
            }

            int i = 1, js = 2;
            while (i < sortedRow.Length)
            {
                if (i == 0 || sortedRow[i] <= sortedRow[i - 1])
                {
                    i = js;
                    js++;
                }
                else
                {
                    (sortedRow[i], sortedRow[i - 1]) = (sortedRow[i - 1], sortedRow[i]);
                    i--;
                }
            }

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[row, j] = sortedRow[j];
            }
        }
        public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);
        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {
        
            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxVal = FindMaxInRow(matrix, i);
                transform(matrix, i, maxVal);
            }
            // end
        
        }

        public int FindMaxInRow(int[,] matrix, int row)
        {
            int maxValue = Int32.MinValue;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] > maxValue)
                    maxValue = matrix[row, j];
            }

            return maxValue;
        }

        public void ReplaceByZero(int[,] matrix, int row, int maxValue)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] == maxValue) matrix[row, j] = 0;
            }
        }

        public void MultiplyByColumn(int[,] matrix, int row, int maxValue)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row, j] == maxValue) matrix[row, j] = matrix[row, j] * (j + 1);
            }
        }
        public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
        {
            double[,] answer = null;
        
            // code here
            int n = (int)((b - a) / h + 0.0001) + 1;
            double[,] table = new double[n, 2];
            for (int i = 0; i < n; i++)
            {
                double currentX = a + i * h;
                table[i, 0] = getSum(currentX);
                table[i, 1] = getY(currentX);
            }
            return table;
            // end
        
            return answer;
        }
        public double SumA(double x)
        {
            double s = 1.0;
            double factorial = 1.0;
            for (int i = 1; i <= 10; i++)
            {
                factorial = factorial * i;
                s = s + Math.Cos(i * x) / factorial;
            }
            return s;
        }
        public double SumB(double x)
        {
            double s = -2.0 * Math.PI * Math.PI / 3.0, sign = 1, t = 1;
            for (int i = 1; Math.Abs(t) >= 0.000001; i++)
            {
                sign *= -1;
                t = sign * (Math.Cos(i * x) / (i * i));
                s += t;
            }
            return s;
        }
        public double YA(double x)
        {
            return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
        }
        public double YB(double x)
        {
            return (((x * x) / 4) - (3 * (Math.PI * Math.PI) / 4)); ;
        }
        public delegate int[] GetTriangle(int[,] matrix);
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
            foreach (int i in array)
                sum += i * i;
            return sum;
        }

        public int[] GetUpperTriangle(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols) return new int[0];
            int size = rows * (rows + 1) / 2;
            int[] result = new int[size];
            int k = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = i; j < rows; j++)
                {
                    result[k] = matrix[i, j];
                    k = k + 1;
                }
            }
            return result;
        }

        public int[] GetLowerTriangle(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols) return new int[0];
            int size = rows * (rows + 1) / 2;
            int[] result = new int[size];
            int k = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    result[k] = matrix[i, j];
                    k = k + 1;
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
            bool res = false;
        
            // code here
            res = func(array);
            // end
        
            return res;
        }

        public bool CheckTransformAbility(int[][] array)
        {
            bool allEqual = true;
            int firstLen = array[0].Length;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].Length != firstLen)
                {
                    allEqual = false;
                    break;
                }
            }
            if (allEqual) return true;

            if (array[0].Length == array.Length)
            {
                bool triangleDesc = true;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Length != array.Length - i)
                    {
                        triangleDesc = false;
                        break;
                    }}
                if (triangleDesc) return true;
            }

            if (array[array.Length - 1].Length == array.Length)
            {
                bool triangleAsc = true;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Length != i + 1)
                    {
                        triangleAsc = false;
                        break;
                    }
                }
                if (triangleAsc) return true;
            }

            return false;
        }

        public bool CheckSumOrder(int[][] array)
        {
            bool res = true;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (Sum(array[i]) <= Sum(array[i + 1]))
                    continue;
                else res = false;
            }

            if (res) return true;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (Sum(array[i]) >= Sum(array[i + 1]))
                    continue;
                else res = false;
            }

            return res;
        }

        public static bool IsSorted(int[] array)
        {
            if (array == null || array.Length <= 1)
                return true;

            bool isAscending = true;
            bool isDescending = true;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                    isAscending = false;
                
                if (array[i - 1] < array[i])
                    isDescending = false;
                
                if (!isAscending && !isDescending)
                    return false;
            }
            
            return isAscending || isDescending;
        }

        public bool CheckArraysOrder(int[][] array)
        {
            bool res = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (IsSorted(array[i]))
                    res = true;
            }

            return res;
        }
    }
}
