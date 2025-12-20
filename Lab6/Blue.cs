namespace Lab6
{
    public class Blue
    {
        public void Task1(ref int[,] matrix)
        {
            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            int idx = FindDiagonalMaxIndex(matrix);
            if (idx != -1) RemoveRow(ref matrix, idx);
            // end
        }

        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

            // code here
            double avgA = GetAverageExceptEdges(A);
            double avgB = GetAverageExceptEdges(B);
            double avgC = GetAverageExceptEdges(C);

            if (avgA < avgB && avgB < avgC) answer = 1;
            else if (avgA > avgB && avgB > avgC) answer = -1;
            else answer = 0;
            // end

            return answer;
        }

        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {
            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            int col = method(matrix);
            if (col != -1) RemoveColumn(ref matrix, col);
            // end
        }

        public void Task4(ref int[,] matrix)
        {
            // code here
            int cols = matrix.GetLength(1);
            for (int col = cols - 1; col >= 0; col--)
            {
                if (!CheckZerosInColumn(matrix, col))
                    RemoveColumn(ref matrix, col);
            }
            // end
        }

        public void Task5(ref int[,] matrix, Finder find)
        {
            // code here
            int value = find(matrix, out int targetRow, out int targetCol);

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                bool containsValue = false;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == value)
                    {
                        containsValue = true;
                        break;
                    }
                }
                if (containsValue) RemoveRow(ref matrix, row);
            }
            // end
        }

        public void Task6(int[,] matrix, SortRowsStyle sort)
        {
            // code here
            for (int row = 0; row < matrix.GetLength(0); row += 3)
            {
                sort(matrix, row);
            }
            // end
        }

        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {
            // code here
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int max = FindMaxInRow(matrix, row);
                transform(matrix, row, max);
            }
            // end
        }

        public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
        {
            double[,] answer = null;

            // code here
            answer = GetSumAndY(a, b, h, getSum, getY);
            // end

            return answer;
        }

        public int Task9(int[,] matrix, GetTriangle triangle)
        {
            int answer = 0;

            // code here
            answer = GetSum(triangle, matrix);
            // end

            return answer;
        }

        public bool Task10(int[][] array, Predicate<int[][]> func)
        {
            bool res = false;

            // code here
            res = func(array);
            // end

            return res;
        }

        //Task1
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1) || matrix.GetLength(0) == 0)
                return -1;
            int max = matrix[0, 0];
            int idx = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, row] > max)
                {
                    max = matrix[row, row];
                    idx = row;
                }
            }
            return idx;
        }
        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            if (matrix.GetLength(0) <= 1)
            {
                matrix = new int[0, matrix.GetLength(1)];
                return;
            }
            int[,] new_m = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row < rowIndex)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                        new_m[row, col] = matrix[row, col];
                }
                else if (row > rowIndex)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                        new_m[row - 1, col] = matrix[row, col];
                }
            }
            matrix = new_m;
        }

        //Task2
        public double GetAverageExceptEdges(int[,] matrix)
        {
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return 0;
            int min = matrix[0, 0];
            int max = matrix[0, 0];
            int sum = 0;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    int val = matrix[i, j];
                    sum += val;
                    if (val < min) min = val;
                    if (val > max) max = val;
                }
            int count = n * m;
            if (count <= 2) return 0;
            return (double)(sum - min - max) / (count - 2);
        }

        //Task3
        public int FindUpperColIndex(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1) || matrix.GetLength(0) == 0)
                return -1;
            int max = int.MinValue;
            int colIdx = -1;
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        colIdx = j;
                    }
            return colIdx;
        }
        public int FindLowerColIndex(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1) || matrix.GetLength(0) == 0)
                return -1;
            int max = int.MinValue;
            int colIdx = -1;
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
                for (int j = 0; j <= i; j++)
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        colIdx = j;
                    }
            return colIdx;
        }
        public void RemoveColumn(ref int[,] matrix, int col)
        {
            if (matrix.GetLength(1) <= 1 || col < 0 || col >= matrix.GetLength(1))
            {
                matrix = new int[matrix.GetLength(0), 0];
                return;
            }
            int[,] new_m = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j < col) new_m[row, j] = matrix[row, j];
                    else if (j > col) new_m[row, j - 1] = matrix[row, j];
                }
            }
            matrix = new_m;
        }

        //Task4
        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            if (col < 0 || col >= matrix.GetLength(1))
                return false;
            for (int row = 0; row < matrix.GetLength(0); row++)
                if (matrix[row, col] == 0) return true;
            return false;
        }

        //Task5
        public delegate int Finder(int[,] matrix, out int row, out int col);
        public int FindMax(int[,] matrix)
        {
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return 0;
            int max = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
            }
            return max;
        }
        public int FindMin(int[,] matrix)
        {
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return 0;
            int min = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
            }
            return min;
        }
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return 0;
            int max = matrix[0, 0];
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
            row = 0;
            col = 0;
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return 0;
            int min = matrix[0, 0];
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

        //Task6
        public delegate void SortRowsStyle(int[,] matrix, int row);
        public void SortRowAscending(int[,] matrix, int row)
        {
            int cols = matrix.GetLength(1);
            int[] rowArray = new int[cols];
            for (int col = 0; col < cols; col++)
                rowArray[col] = matrix[row, col];
            for (int i = 0; i < cols - 1; i++)
            {
                for (int j = 0; j < cols - i - 1; j++)
                {
                    if (rowArray[j] > rowArray[j + 1])
                    {
                        int temp = rowArray[j];
                        rowArray[j] = rowArray[j + 1];
                        rowArray[j + 1] = temp;
                    }
                }
            }
            for (int col = 0; col < cols; col++)
                matrix[row, col] = rowArray[col];
        }
        public void SortRowDescending(int[,] matrix, int row)
        {
            int cols = matrix.GetLength(1);
            int[] rowArray = new int[cols];
            for (int col = 0; col < cols; col++)
                rowArray[col] = matrix[row, col];
            for (int i = 0; i < cols - 1; i++)
            {
                for (int j = 0; j < cols - i - 1; j++)
                {
                    if (rowArray[j] < rowArray[j + 1])
                    {
                        int temp = rowArray[j];
                        rowArray[j] = rowArray[j + 1];
                        rowArray[j + 1] = temp;
                    }
                }
            }
            for (int col = 0; col < cols; col++)
                matrix[row, col] = rowArray[col];
        }

        //Task7
        public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);
        public int FindMaxInRow(int[,] matrix, int row)
        {
            if (matrix.GetLength(1) == 0)
                return 0;
            int max = matrix[row, 0];
            for (int col = 1; col < matrix.GetLength(1); col++)
                if (matrix[row, col] > max) max = matrix[row, col];
            return max;
        }
        public void ReplaceByZero(int[,] matrix, int row, int maxValue)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
                if (matrix[row, col] == maxValue) matrix[row, col] = 0;
        }
        public void MultiplyByColumn(int[,] matrix, int row, int maxValue)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
                if (matrix[row, col] == maxValue) matrix[row, col] *= col + 1;
        }

        //Task8
        public double[,] GetSumAndY(double a, double b, double h, Func<double, double> sum, Func<double, double> y)
        {
            double[,] matrix = new double[(int)((b - a) / h) + 1, 2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double x = a + i * h;
                matrix[i, 0] = sum(x);
                matrix[i, 1] = y(x);
            }
            return matrix;
        }
        public double SumA(double x)
        {
            double sum = 1.0;
            double summ = 0.0;
            double fac = 1.0;
            int i = 1;
            do
            {
                summ = sum;
                fac *= i;
                sum += Math.Cos(i * x) / fac;
                i++;
            }
            while (Math.Abs(sum - summ) >= 0.0001);
            return sum;
        }
        public double YA(double x)
        {
            double result = 0;
            result = Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
            return result;
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

        //Task9
        public delegate int[] GetTriangle(int[,] matrix);
        public int Sum(int[] array)
        {
            int sum = 0;
            foreach (int val in array) sum += val * val;
            return sum;
        }
        public int[] GetUpperTriangle(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1) || matrix.GetLength(0) == 0)
                return new int[0];
            int n = matrix.GetLength(0);
            int totalElements = n * (n + 1) / 2;
            int[] result = new int[totalElements];
            int index = 0;
            for (int i = 0; i < n; i++)
                for (int j = i; j < n; j++)
                    result[index++] = matrix[i, j];
            return result;
        }
        public int[] GetLowerTriangle(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1) || matrix.GetLength(0) == 0)
                return new int[0];
            int n = matrix.GetLength(0);
            int totalElements = n * (n + 1) / 2;
            int[] result = new int[totalElements];
            int index = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j <= i; j++)
                    result[index++] = matrix[i, j];
            return result;
        }
        public int GetSum(GetTriangle transformer, int[,] matrix)
        {
            int[] triangle = transformer(matrix);
            return Sum(triangle);
        }

        //Task10
        public bool CheckTransformAbility(int[][] array)
        {
            if (array == null || array.Length == 0) return false;
            int totalElements = 0;
            int rows = array.Length;
            foreach (var row in array)
            {
                if (row == null) return false;
                totalElements += row.Length;
            }
            return totalElements % rows == 0;
        }
        public bool CheckSumOrder(int[][] array)
        {
            if (array == null || array.Length <= 1) return true;
            int[] sums = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null) return false;
                sums[i] = array[i].Sum();
            }
            bool asc = true, desc = true;
            for (int i = 1; i < sums.Length; i++)
            {
                if (sums[i] < sums[i - 1]) asc = false;
                if (sums[i] > sums[i - 1]) desc = false;
                if (!asc && !desc) break;
            }
            return asc || desc;
        }
        public bool CheckArraysOrder(int[][] array)
        {
            if (array == null) return false;
            foreach (var row in array)
            {
                if (row == null) continue;
                if (row.Length <= 1)
                {
                    return true;
                }
                bool asc = true;
                bool desc = true;
                for (int i = 1; i < row.Length; i++)
                {
                    if (row[i] > row[i - 1]) desc = false;
                    else if (row[i] < row[i - 1]) asc = false;
                }
                if (asc || desc) return true;
            }
            return false;
        }
    }
}
