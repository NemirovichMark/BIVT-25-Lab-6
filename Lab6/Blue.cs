namespace Lab6
{
    public class Blue
    {
        public int FindDiagonalMaxIndex(int[,] matrix)
        {
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
            int[,] new_m = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            bool flag = false;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                if (rowIndex == row) flag = true;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (flag) new_m[row, col] = matrix[row + 1, col];
                    else new_m[row, col] = matrix[row, col];
                }
            }

            matrix = new_m;
        }
        public void Task1(ref int[,] matrix)
        {
            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            RemoveRow(ref matrix, FindDiagonalMaxIndex(matrix));
            // end
        }

        public double GetAverageExceptEdges(int[,] matrix)
        {
            double max = matrix[0, 0];
            double min = matrix[0, 0];
            double sum = 0;
            int num = matrix.GetLength(0) * matrix.GetLength(1) - 2;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > max) max = matrix[row, col];
                    if (matrix[row, col] < min) min = matrix[row, col];
                    sum += matrix[row, col];
                }
            }

            return (sum - max - min) / num;
        }
        public int Task2(int[,] A, int[,] B, int[,] C)
        {
            int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

            // code here
            double[] avgs = new double [3]
                { GetAverageExceptEdges(A), GetAverageExceptEdges(B), GetAverageExceptEdges(C) };
            if (avgs[0] > avgs[1] && avgs[1] > avgs[2])
            {
                answer = -1;
            }
            else if (avgs[0] < avgs[1] && avgs[1] < avgs[2])
            {
                answer = 1;
            }
            // end

            return answer;
        }

        public int FindUpperColIndex(int[,] matrix)
        {
            int max = matrix[0, 0];
            int x = 0;
            int s = matrix.GetLength(0);
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    if (j >= i)
                    {
                        if (matrix[i, j] > max)
                        {
                            max = matrix[i, j];
                            x = j;
                        }
                    }
                }
            }

            return x;
        }
        public int FindLowerColIndex(int[,] matrix)
        {
            int max = matrix[0, 0];
            int x = 0;
            int s = matrix.GetLength(0);
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    if (j <= i)
                    {
                        if (matrix[i, j] > max)
                        {
                            max = matrix[i, j];
                            x = j;
                        }
                    }
                }
            }

            return x;
        }
        public void RemoveColumn(ref int[,] matrix, int col)
        {
            int[,] new_m = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
            bool flag = false;
            for (int c = 0; c < matrix.GetLength(1) - 1; c++)
            {
                if (col == c) flag = true;
                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    if (flag) new_m[r, c] = matrix[r, c + 1];
                    else new_m[r, c] = matrix[r, c];
                }
            }

            matrix = new_m;
        }
        public void Task3(ref int[,] matrix, Func<int[,], int> method)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            int col = method(matrix);
            RemoveColumn(ref matrix, col);

            // end

        }
        
        public bool CheckZerosInColumn(int[,] matrix, int col)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                if (matrix[col, r] == 0)
                {
                    return true;
                }
            }

            return false;
        }
        public void Task4(ref int[,] matrix)
        {
            // code here
            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                if (!CheckZerosInColumn(matrix, c))
                {
                    RemoveRow(ref matrix, c);
                }
            }
            // end
        }


        public delegate int Finder(int[,] matrix, out int row, out int col);
        // public int FindMax(int[,] matrix)
        // {
        //     int row, col;
        //     return FindMax(matrix, out row, out col);
        // }
        // public int FindMin(int[,] matrix)
        // {
        //     int row, col;
        //     return FindMin(matrix, out row, out col);
        // }
        public int FindMax(int[,] matrix, out int row, out int col)
        {
            int max = matrix[0, 0];
            row = 0;
            col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[row, col]) (row, col, max) = (i, j, matrix[i, j]);
                }
            }

            return max;
        }
        public int FindMin(int[,] matrix, out int row, out int col)
        {
            int min = matrix[0, 0];
            row = 0;
            col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < matrix[row, col])
                        (row, col, min) = (i, j, matrix[i, j]);
                }
            }

            return min;
        }
        public void Task5(ref int[,] matrix, Finder find)
        {

            // code here
            int row, col;
            int a = find(matrix, out row, out col);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bool flag = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] == a)
                        flag = true;
                if (flag) RemoveRow(ref matrix, i);
            }
            // end

        }

        public delegate void SortRowsStyle(int[,] matrix, int row);
        public void SortRowAscending(int[,] matrix, int row)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j > matrix.GetLength(1) - 1 - i; j++)
                {
                    if (matrix[row, j] < matrix[row, j + 1])
                    {
                        (matrix[row, j], matrix[row, j + 1]) = (matrix[row, j + 1], matrix[row, j]);
                    }
                }
            }
        }
        public void SortRowDescending(int[,] matrix, int row)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1 - i; j++)
                {
                    if (matrix[row, j] < matrix[row, j + 1])
                    {
                        (matrix[row, j], matrix[row, j + 1]) = (matrix[row, j + 1], matrix[row, j]);
                    }
                }
            }
        }
        public void Task6(int[,] matrix, SortRowsStyle sort)
        {
            // code here
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 3 == 0)
                {
                    sort(matrix, row);
                }
            }
            // end
        }

        public delegate void ReplaceMaxElements(int[,] matrix, int row, int maxValue);
        public int FindMaxInRow(int[,] matrix, int row)
        {
            int max = matrix[row, 0];
            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] > max) max = matrix[row, i];
            }

            return max;
        }
        public void ReplaceByZero(int[,] matrix, int row, int maxValue)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] == maxValue) matrix[row, i] = 0;
            }
        }
        public void MultiplyByColumn(int[,] matrix, int row, int maxValue)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] == maxValue) matrix[row, i] = matrix[row, i] * i;
            }
        }
        public void Task7(int[,] matrix, ReplaceMaxElements transform)
        {
            // code here
            for (int row = 0; row < matrix.GetLength(0); row++) transform(matrix, row, FindMaxInRow(matrix, row));
            // end
        }
        
        public double SumA(double x)
        {
            double s = 1, d = 1;
            for (int i = 1; i < 11; i++)
            {
                d *= i;
                s += (Math.Cos(i * x) / d);
            }
            return s;
        }
        public double SumB(double x)
        {
            double s = -2.0 * Math.Pow(Math.PI, 2) / 3.0, sign = 1, t = 1;
            for (int i = 1; Math.Abs(t) >= 0.000001; i++)
            {
                sign *= -1;
                t = sign * (Math.Cos(i * x) / Math.Pow(i, 2));
                s += t;
            }
            return s;
        }
        public double YA(double x)
        {
            return Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x));
        }
        public double YB(double x)
        {
            return Math.Pow(x, 2) / 4 - Math.Pow(Math.PI, 2) / 12;
        }
        public double[,] GetSumAndY(double a, double b, double h, Func<double, double> sum, Func<double, double> y)
        {
            if (((a < b) && (h < 0)) || ((a > b) && (h > 0))) h = -h;
            int count = 0;
            for (double x = a; x <= b; x = Math.Round(x + h, 7)) count++;
            double[,] lst = new double[count, 2];
            count = 0;
            for (double x = a; x <= b; x = Math.Round(x + h, 7)) (lst[count, 0], lst[count++, 1]) = (sum(x), y(x));
            return lst;
        }
        public double[,] Task8(double a, double b, double h, Func<double, double> getSum, Func<double, double> getY)
        {
            double[,] answer = null;
            // code here
            answer = GetSumAndY(a, b, h, getSum, getY);
            // end
            return answer;
        }
        
        public delegate int[] GetTriangle(int[,] matrix);
        public int Sum(int[] array)
        {
            int answer = 0;
            foreach (int i in array)
                answer += (i * i);
            return answer;
        }
        public int GetSum(GetTriangle transformer, int[,] matrix)
        {
            return Sum(transformer(matrix));
        }
        public int[] GetUpperTriangle(int[,] matrix)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i <= j) count++;
                }
            }
            int[] answer = new int[count];
            count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i <= j) answer[count++] = matrix[i, j];
                }
            }
            return answer;
        }
        public int[] GetLowerTriangle(int[,] matrix)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i >= j) count++;
                }
            }
            int[] answer = new int[count];
            count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i >= j) answer[count++] = matrix[i, j];
                }
            }
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

        public delegate bool Predicate(int[][] array);
        public bool CheckTransformAbility(int[][] array)
        {
            bool flag = false;
            double s = 0;
            for (int i = 0; i < array.Length; i++) s += array[i].Length;
            s = s / array.Length;
            if (Math.Floor(s) == s) flag = true;
            return flag;
        }
        public bool CheckSumOrder(int[][] array)
        {
            int flagInt = 0;
            int[] arr = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    arr[i] += array[i][j];
                }
            }
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] < arr[i]) flagInt++;
            }
            if (flagInt == arr.Length - 1) return true;
            flagInt = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i]) flagInt++;
            }
            if (flagInt == arr.Length - 1) return true;
            return false;
        }
        public bool CheckArraysOrder(int[][] array)
        {
            bool[] arr = new bool[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int flagInt = 0;
                for (int j = 1; j < array[i].Length; j++)
                {
                    if (array[i][j - 1] < array[i][j]) flagInt++;
                }
                if (flagInt == array[i].Length - 1)
                {
                    arr[i] = true;
                    continue;
                }
                flagInt = 0;
                for (int j = 1; j < array[i].Length; j++)
                {
                    if (array[i][j - 1] > array[i][j]) flagInt++;
                }
                if (flagInt == array[i].Length - 1)
                {
                    arr[i] = true;
                    continue;
                }
                arr[i] = false;
            }
            bool flag = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]) flag = true;
            }
            return flag;
        }
        public bool Task10(int[][] array, Predicate<int[][]> func)
        {
            bool res = false;
            // code here
            res = func(array);
            // end
            return res;
        }
        
        
    }
}
