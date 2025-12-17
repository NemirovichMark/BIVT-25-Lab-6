using System;

namespace Lab6
{
    public class Blue
    {
        public void Task1(ref int[,] matrix)
        {

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m) return;

            int RowToRemove = FindDiagonalMaxIndex(matrix);
            if (RowToRemove != -1)
            {
                RemoveRow(ref matrix, RowToRemove);
            }


        }

        public int FindDiagonalMaxIndex(int[,] matrix)
        {
            int indexx = -1;
            int n = matrix.GetLength(0);
            int maxEl = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] > maxEl && i == j)
                    {
                        maxEl = matrix[i, j];
                        indexx = i;
                    }
                }
            }
            return indexx;
        }

        public void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] neww = new int[n - 1, m];
            int newIndex = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != rowIndex)
                    {
                        matrix[newIndex, j] = neww[i, j];
                    }
                    newIndex++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (i != rowIndex)
                {
                    for (int j = 0; j < m; j++)
                    {  
                        neww[newIndex, j] = matrix[i, j];
                    }
                    newIndex++;
                }
            }
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = neww[i, j];
                }
            }
        }

        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

            double first = GetAverageExceptEdges(A);
            double second = GetAverageExceptEdges(B);
            double third = GetAverageExceptEdges(C);
            double[] newArray = { first, second, third };
            for (int i = 0; i < newArray.Length; i++)
            {
                if (first < second && second < third)
                {
                    answer = 1;
                }
                else if (first > second && second > third)
                {
                    answer = -1;
                }
            }

            return answer;
        }

        public double GetAverageExceptEdges(int[,] matrix)
        {
            if (matrix.GetLength(0) == 0 ||  matrix.GetLength(1) == 0) { return 0; }
            double answer = 0;
            int max = FindMaxEl(matrix);
            int min = FindMinEl(matrix);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != max && matrix[i,j] != min)
                    {
                        answer += matrix[i,j];
                    }
                }
            }
            answer = answer / ((matrix.GetLength(0) * matrix.GetLength(1)) - 2);
            return answer;
        }

        public int FindMaxEl(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int maxx = int.MinValue;
            //int indexI = -1;
            //int indexJ = -1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i,j] > maxx)
                    {
                        maxx = matrix[i,j];
                        //indexI = i;
                        //indexJ = j;
                    }
                }
            }
            return maxx;
        }

        public int FindMinEl(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int minn = int.MaxValue;
            //int indexI = -1;
            //int indexJ = -1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < minn)
                    {
                        minn = matrix[i, j];
                        //indexI = i;
                        //indexJ = j;
                    }
                }
            }
            return minn;
        }

        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m) return;

            int collIndex = method(matrix);
            RemoveColumn(ref matrix, collIndex);

        }

        public int FindUpperColIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int maxx = int.MinValue;
            int IndexI = 0;
            int IndexJ = 0;

            for (int i = 0;i < n; i++)
            {
                for (int j =0; j < m; j++)
                {
                    if (matrix[i,j] > maxx && j > i)
                    {
                        maxx = matrix[i,j];
                        IndexI =i;
                        IndexJ =j;
                    }
                }
            }
            return IndexJ;
        }

        public int FindLowerColIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int maxx = int.MinValue;
            int IndexI = 0;
            int IndexJ = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i,j] > maxx && j <= i)
                    {
                        maxx = matrix[i,j];
                        IndexI =i;
                        IndexJ =j;
                    }
                }
            }
            return IndexJ;
        }

        public void RemoveColumn(ref int[,] matrix, int col)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);


            int[,] neww = new int[n, m - 1];

            for (int i = 0;i < n; i++)
            {
                int inxnew = 0;
                for (int j = 0;j < m; j++)
                {
                    if (j != col)
                    {
                        neww[i,inxnew] = matrix[i,j];
                        inxnew++;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m - 1; j++)
                {
                    matrix[i, j] = neww[i, j];
                }
            }
        }


        public void Task4(ref int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int j = m - 1; j >= 0; j++)
            {
                if (CheckZerosInColumn(matrix, j) == false)
                {
                    RemoveColumn(ref matrix, j);
                    m--;
                }

            }
        }

        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            bool hasZeros = false;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, col] == 0)
                {
                    hasZeros = true; break;
                }
            }
            if ( !hasZeros )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        
        public void Task5(ref int[,] matrix, Finder find)
        {
            int row, col;
            int value = find(matrix, out row, out col);
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == value)
                    {
                        RemoveRow(ref matrix, i);
                    }
                }
            }
           

        }
        public delegate int Finder(int[,] matrix, out int row, out int col);

        public int FindMax(int[,] matrix, out int row, out int col)
        {
            int maxx = int.MinValue;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            row = -1;
            col = -1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i,j] > maxx)
                    {
                        maxx = matrix[i,j];
                        row = i;
                        col = j;
                    }
                }
            }
            return maxx;
        }

        public int FindMin(int[,] matrix, out int row, out int col)
        {
            int min = int.MaxValue;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            row = -1;
            col = -1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
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
            int rows = matrix.GetLength(0);
            for (int i = 2; i < rows; i+= 3)
            {
                sort(matrix, i);
            }
        }

        public void SortRowAscending(int[,] matrix, int row)
        {
            int cols = matrix.GetLength(1);

            for (int i = 0; i < cols - 1; i++)
            {
                for (int j = 0; j < cols - i - 1; j++)
                {
                    if (matrix[row, j] > matrix[row, j + 1])
                    {
                        int temp;
                        temp = matrix[row, j];
                        matrix[row,j] = matrix[row, j + 1];
                        matrix[row, j + 1] = temp;
                    }
                }
            }
        }

        public void SortRowDescending(int[,] matrix, int row)
        {
            int cols = matrix.GetLength(1);

            for (int i = 0; i < cols - 1; i++)
            {
                for (int j = 0; j < cols - i - 1; j++)
                {
                    if (matrix[row, j] < matrix[row, j + 1])
                    {
                        int temp;
                        temp = matrix[row, j];
                        matrix[row, j] = matrix[row, j + 1];
                        matrix[row, j + 1] = temp;
                    }
                }
            }
        }


        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxV = FindMaxInRow(matrix, i);
                transform(matrix, i, maxV);
            }
        }

 
        public int FindMaxInRow(int[,] matrix, int row)
        {
            int max = int.MinValue;
            for (int j = 0; j < matrix.GetLength(1); j++)
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
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row,j] == maxValue)
                {
                    matrix[row, j] = 0;
                }
            }
        }

        public void MultiplyByColumn(int[,] matrix, int row, int maxValue)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[row,j] == maxValue)
                {
                    matrix[row,j] = matrix[row,j] * j;
                }
            }
        }


        public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
        {
            int n = (int)Math.Floor((b - a) / h) + 1;
            double[,] answer = new double[2, n];

            double x = a;
            for (int j = 0; j < n; j++)
            {
                answer[0, j] = getSum(x);
                answer[1, j] = getY(x);
                x += h;
            }

            return answer;
        }

        public double[,] GetSumAndY(double a, double b, double h, Func<double, double> sum, Func<double, double> y)
        {
            int n = (int)Math.Floor((b - a) / h) + 1;
            double[,] answer = new double[2, n];

            double x = a;
            for (int j = 0; j < n; j++)
            {
                answer[0, j] = sum(x);
                answer[1, j] = y(x);
                x += h;
            }

            return answer;
        }

        public double SumA(double x)
        {
            double eps = 1e-4;
            double sum = 1.0; 
            double term = 1.0;

            int i = 1;
            while (true)
            {
                term *= i;
                double add = Math.Cos(i * x) / term;

                if (Math.Abs(add) < eps)
                    break;

                sum += add;
                i++;
            }

            return sum;
        }

        public double YA(double x)
        {
            return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
        }

        public double SumB(double x)
        {
            double eps = 1e-4;
            double sum = 0.0;
            int i = 1;

            while (true)
            {
                double term = Math.Pow(-1, i) * Math.Cos(i * x) / (i * i);
                if (Math.Abs(term) < eps)
                    break;

                sum += term;
                i++;
            }

            return sum;
        }

        public double YB(double x)
        {
            return x * x / 4.0 - Math.PI * Math.PI / 12.0;
        }

        public int Task9(int[,] matrix, GetTriangle triangle)
        {
            int answer = 0;

            int[] triangleArray = triangle(matrix);
            answer = Sum(triangleArray);

            return answer;
        }

        public int Sum(int[] array)
        {
            int sum = 0;
            foreach (int element in array)
            {
                sum += element * element;
            }
            return sum;
        }

        public int GetSum(GetTriangle transformer, int[,] matrix)
        {
            return Sum(transformer(matrix));
        }

        public int[] GetUpperTriangle(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    count++;
                }
            }
            int[] result = new int[count];
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    result[index++] = matrix[i, j];
                }
            }
            return result;
        }

        public int[] GetLowerTriangle(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    count++;
                }
            }
            int[] result = new int[count];
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    result[index++] = matrix[i, j];
                }
            }
            return result;
        }
        public bool Task10(int[][] array, Predicate<int[][]> func)
        {
            bool res = false;

            if (array != null && array.Length > 0)
            {
                res = func(array);
            }

            return res;
        }

        public bool CheckTransformAbility(int[][] array)
        {
            int maxLength = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null) return false;
                if (array[i].Length > maxLength)
                    maxLength = array[i].Length;
            }
            return maxLength > 0;
        }

        public bool CheckSumOrder(int[][] array)
        {
            int[] sums = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                sums[i] = array[i].Sum();
            }

            bool asc = true, desc = true;
            for (int i = 1; i < sums.Length; i++)
            {
                if (sums[i] <= sums[i - 1]) asc = false;
                if (sums[i] >= sums[i - 1]) desc = false;
            }

            return asc || desc;
        }

        public bool CheckArraysOrder(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null || array[i].Length <= 1) continue;

                bool asc = true, desc = true;
                for (int j = 1; j < array[i].Length; j++)
                {
                    if (array[i][j] <= array[i][j - 1]) asc = false;
                    if (array[i][j] >= array[i][j - 1]) desc = false;
                }
                if (asc || desc) return true;
            }
            return false;
        }
    }
}
