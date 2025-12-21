using System.ComponentModel.Design;
using System.Numerics;
using System.Reflection;

namespace Lab6
{
    public class Blue
    {
        public void Task1(ref int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int ind = FindDiagonalMaxIndex(matrix);
                RemoveRow(ref matrix, ind);
            }
            // end

        }
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int size = matrix.GetLength(0);

            int maxIndex = 0;
            int maxValue = matrix[0, 0];

            for (int i = 1; i < size; i++)
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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);


            int[,] newMatrix = new int[rows - 1, cols];

            for (int i = 0; i < rowIndex; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    newMatrix[i, j] = matrix[i, j];
                }
            }

            for (int i = rowIndex + 1; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    newMatrix[i - 1, j] = matrix[i, j];
                }
            }

            matrix = newMatrix;
        }

        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

            // code here
            double[] sr = { 0, 0, 0 };
            sr[0] = GetAverageExceptEdges(A);
            sr[1] = GetAverageExceptEdges(B);
            sr[2] = GetAverageExceptEdges(C);
            if (sr[0] < sr[1] && sr[1] < sr[2])
            {
                answer = 1;
            }
            else if (sr[0] > sr[1] && sr[1] > sr[2])
            {
                answer = -1;
            }
            // end

            return answer;
        }
        public double GetAverageExceptEdges(int[,] matrix)
        {
            if (matrix.Length < 3)
            {
                return 0;
            }
            int maxindi = 0, minindi = 0, minindj = 0, maxindj = 0;
            int max = matrix[0, 0], min = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minindi = i;
                        minindj = j;
                    }
                    else if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxindi = i;
                        maxindj = j;
                    }
                }
            }
            double sum = 0;
            int kolvo = matrix.GetLength(0) * matrix.GetLength(1) - 2;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                }
            }
            return (sum - max - min) / kolvo;
        }
        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {
            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int colToRemove = method(matrix);

                if (colToRemove != -1)
                {
                    RemoveColumn(ref matrix, colToRemove);
                }
            }
            // end

        }
        public int FindLowerColIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (n == 0 || n != matrix.GetLength(1)) return -1;
            int[] colMaxs = new int[n];
            for (int j = 0; j < n; j++) colMaxs[j] = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (matrix[i, j] > colMaxs[j])
                    {
                        colMaxs[j] = matrix[i, j];
                    }
                }
            }
            int globalMax = int.MinValue;
            int maxCol = -1;

            for (int j = 0; j < n; j++)
            {
                if (colMaxs[j] > globalMax)
                {
                    globalMax = colMaxs[j];
                    maxCol = j;
                }
            }
            return maxCol;
        }
        public int FindUpperColIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (n == 0 || n != matrix.GetLength(1)) return -1;
            int[] colMaxs = new int[n];
            for (int j = 0; j < n; j++) colMaxs[j] = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (matrix[i, j] > colMaxs[j])
                    {
                        colMaxs[j] = matrix[i, j];
                    }
                }
            }
            int globalMax = int.MinValue;
            int maxCol = -1;

            for (int j = 0; j < n; j++)
            {
                if (colMaxs[j] > globalMax)
                {
                    globalMax = colMaxs[j];
                    maxCol = j;
                }
            }

            return maxCol;
        }
        public void RemoveColumn(ref int[,] matrix, int col)
        {

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] newMatrix = new int[rows, cols - 1];

            for (int i = 0; i < rows; i++)
            {
                int newCol = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j != col)
                    {
                        newMatrix[i, newCol] = matrix[i, j];
                        newCol++;
                    }
                }
            }

            matrix = newMatrix;
        }

        public void Task4(ref int[,] matrix)
        {

            // code here
            if (matrix == null || matrix.Length == 0)
                return;

            int cols = matrix.GetLength(1);

            for (int j = cols - 1; j >= 0; j--)
            {
                if (!CheckZerosInColumn(matrix, j))
                {
                    RemoveColumn(ref matrix, j);
                }
            }
            // end

        }
        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            if (matrix == null || col < 0 || col >= matrix.GetLength(1))
            {
                return false;
            }

            int rows = matrix.GetLength(0);

            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, col] == 0)
                {
                    return true;
                }
            }

            return false;
        }
        public void RemoveColumn(ref int[,] matrix, int col)
        {
            if (matrix == null || col < 0 || col >= matrix.GetLength(1))
                return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] newMatrix = new int[rows, cols - 1];

            for (int i = 0; i < rows; i++)
            {
                int newCol = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j != col)
                    {
                        newMatrix[i, newCol] = matrix[i, j];
                        newCol++;
                    }
                }
            }

            matrix = newMatrix;
        }
        public void Task5(ref int[,] matrix, Finder find)
        {

            // code here
            if (matrix == null || matrix.GetLength(0) == 0)
                return;
            int value = find(matrix, out int r, out int c);

            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                bool shouldDelete = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == value)
                    {
                        shouldDelete = true;
                        break;
                    }
                }
                if (shouldDelete)
                {
                    RemoveRow(ref matrix, i);
                }
            }
            // end

        }
        public delegate int Finder(int[,] matrix, out int row, out int col);
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            if (matrix == null || matrix.Length == 0)
            {
                row = -1;
                col = -1;
                return 0;
            }

            int max = matrix[0, 0];
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
            if (matrix == null || matrix.Length == 0)
            {
                row = -1;
                col = -1;
                return 0;
            }

            int min = matrix[0, 0];
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
        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] newMatrix = new int[rows - 1, cols];

            for (int i = 0; i < rowIndex; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    newMatrix[i, j] = matrix[i, j];
                }
            }

            for (int i = rowIndex + 1; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    newMatrix[i - 1, j] = matrix[i, j];
                }
            }

            matrix = newMatrix;
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
            int cols = matrix.GetLength(1);
            int[] temp = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                temp[j] = matrix[row, j];
            }

            Array.Sort(temp);

            for (int j = 0; j < cols; j++)
            {
                matrix[row, j] = temp[j];
            }
        }

        public void SortRowDescending(int[,] matrix, int row)
        {
            int cols = matrix.GetLength(1);
            int[] temp = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                temp[j] = matrix[row, j];
            }

            Array.Sort(temp);
            Array.Reverse(temp);

            for (int j = 0; j < cols; j++)
            {
                matrix[row, j] = temp[j];
            }
        }
        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {

            // code here
            if (matrix == null) return;
            int rows = matrix.GetLength(0);
            for (int i = 0; i < rows; i++)
            {
                int maxValue = FindMaxInRow(matrix, i);
                transform(matrix, i, maxValue);
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
                    matrix[row, j] = maxValue * (j + 1);
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
        public delegate double Func(double x);
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
            double prevSum = 0.0;
            double factorial = 1.0;

            int i = 1;
            do
            {
                prevSum = sum;
                factorial *= i;
                sum += Math.Cos(i * x) / factorial;
                i++;
            }
            while (Math.Abs(sum - prevSum) >= 0.0001);

            return sum;
        }

        public double YA(double x)
        {
            double res = 0;
            res = Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
            return res;
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

        public int Sum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i] * array[i];
            }
            return sum;
        }
        public int Task9(int[,] matrix, GetTriangle triangle)
        {
            int answer = 0;

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int[] array = triangle(matrix);
                answer = Sum(array);
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
        public int[] GetSum(GetTriangle transformer, int[,] matrix)
        {
            int[] res = transformer(matrix);
            return res;
        }
        public int[] GetUpperTriangle(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int[] array = new int[n * (n + 1) / 2];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < matrix.GetLength(1); j++)
                {
                    array[k++] = matrix[i, j];
                }
            }
            return array; ;
        }
        public int[] GetLowerTriangle(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int[] array = new int[n * (n + 1) / 2];
            int k = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    array[k++] = matrix[i, j];
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

            for (int i = 0; i < temp.Length - 1; i++)
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
                for (int j = 0; j < array[i].Length - 1; j++)
                {
                    if (array[i][j] >= array[i][j + 1])
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
                for (int j = 0; j < array[i].Length - 1; j++)
                {
                    if (array[i][j] <= array[i][j + 1])
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
}
